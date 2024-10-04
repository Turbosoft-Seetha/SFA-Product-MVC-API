using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using MultipartDataMediaFormatter.Infrastructure;
using MVC_API.Models;
using Newtonsoft.Json;

namespace MVC_API.Controllers
{
    public class CustomerFOCController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string PostCustomerFOCApproval([FromForm] PostCustomerFOC inputParams)
        {
            dm.TraceService("PostCustomerFOCApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostCustomerFOCApprovalDetData> itemData = JsonConvert.DeserializeObject<List<PostCustomerFOCApprovalDetData>>(inputParams.JSONString);
                try
                {

                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string CusId = inputParams.CusId == null ? "0" : inputParams.CusId;
                    string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
                    string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                    string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                    string Commend = inputParams.Commend == null ? "" : inputParams.Commend;
                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {
                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            foreach (PostCustomerFOCApprovalDetData id in itemData)
                            {
                                string[] arr = { id.prdID.ToString(), id.HUOM.ToString(), id.HQty.ToString(), id.LUOM.ToString(), id.LQty.ToString(), id.totalqty.ToString() };
                                string[] arrName = { "prdID", "HUOM", "HQty", "LUOM", "LQty", "totalqty" };
                                dm.createNode(arr, arrName, writer);
                            }
                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        InputXml = sw.ToString();
                    }
                    try
                    {
                        string[] arr = { CusId.ToString(), FromDate.ToString(), ToDate.ToString(), userID.ToString(), Commend, InputXml.ToString() };
                        DataTable dt = dm.loadList("InsertFOCApp", "sp_Masters_UOM", RotId.ToString(), arr);

                        List<GetFOCApprovalStatus> listStatus = new List<GetFOCApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetFOCApprovalStatus> listHeader = new List<GetFOCApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetFOCApprovalStatus
                                {
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    Descr = dr["Descr"].ToString(),
                                    ReturnId = dr["ReturnId"].ToString(),
                                });
                            }
                            JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listHeader
                            });

                            return JSONString;
                        }
                        else
                        {
                            dm.TraceService("NoDataRes");
                            JSONString = "NoDataRes";
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "NoDataSQL - " + ex.Message.ToString();
                    }
                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "NoDataSQL - " + ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }
            dm.TraceService("PostCustomerFOCApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetFOCList([FromForm] FOCDetailIn inputParams)
        {
            dm.TraceService("SelectCFOCList STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string CusId = inputParams.CusId == null ? "0" : inputParams.CusId;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
            string[] arr = { RotId, CusId };
            DataSet dt = dm.loadListDS("SelFOCList", "sp_Masters_UOM", userID, arr);
            DataTable headerData = dt.Tables[0];

            DataTable DetailData = dt.Tables[1];
            try
            {
                if (headerData.Rows.Count > 0)
                {
                    List<FOCList> listDetail = new List<FOCList>();
                    foreach (DataRow dr in headerData.Rows)
                    {
                        List<FOCApproveDetail> FOCDetail = new List<FOCApproveDetail>();
                        foreach (DataRow dts in DetailData.Rows)
                        {
                            //if (dr["cfh_ID"].ToString() == dts["cfa-cfh_ID"].ToString())
                            //{
                                FOCDetail.Add(new FOCApproveDetail
                                {
                                    prdID = dts["prdID"].ToString(),
                                    HUOM = dts["HUOM"].ToString(),
                                    HQty = dts["HQty"].ToString(),
                                    LUOM = dts["LUOM"].ToString(),
                                    LQty = dts["LQty"].ToString(),
                                    totalqty = dts["totalqty"].ToString()
                                });
                            //}
                        }
                        listDetail.Add(new FOCList
                        {

                            HeaderId = dr["HeaderId"].ToString(),
                            FromDate = dr["FromDate"].ToString(),
                            ToDate = dr["ToDate"].ToString(),
                            Commend = dr["Commend"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            FOCListDetail = FOCDetail,
                        });

                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listDetail
                    });

                    return JSONString;
                }
                else
                {
                    dm.TraceService("NoDataRes");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("SelectCFOCList - Error :   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectCFOCList ENDED ");
            dm.TraceService("======================================");

            return JSONString;

        }
    }
}