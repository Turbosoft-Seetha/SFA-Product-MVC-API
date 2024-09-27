using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System.Configuration;


namespace MVC_API.Controllers
{
    public class MustSellController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]
        public string PostMustSellApproval([FromForm] PostMustSellData inputParams)
        {
            dm.TraceService("PostMustSellApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostMustSellItemData> itemData = JsonConvert.DeserializeObject<List<PostMustSellItemData>>(inputParams.JSONString);
                try
                {
                    
                    string status = inputParams.Status == null ? "P" : inputParams.Status;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                    string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string ReturnMode = inputParams.Type == null ? "" : inputParams.Type;
                    string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostMustSellItemData id in itemData)
                            {
                                string[] arr = { id.ItemId.ToString(), id.HigherUOM.ToString(), id.HigherQty.ToString(), id.LowerUOM.ToString(), id.LowerQty.ToString(), id.IsMustSell.ToString() };
                                string[] arrName = { "ItemId", "HigherUOM", "HigherQty", "LowerUOM", "LowerQty", "IsMustSell" };
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
                        string[] arr = { userID.ToString(), status.ToString(), InputXml.ToString(), udpID.ToString(), rotID.ToString(),  ReturnMode.ToString(),  cus_ID.ToString() };
                        DataTable dt = dm.loadList("InsMustSellApproval", "sp_AppServices", ReqID.ToString(), arr);

                        List<GetMSInsertStatus> listStatus = new List<GetMSInsertStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetMSInsertStatus> listHeader = new List<GetMSInsertStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetMSInsertStatus
                                {
                                    Mode = dr["Res"].ToString(),
                                    Status = dr["Status"].ToString(),
                                    TransID = dr["TransID"].ToString()

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
            dm.TraceService("PostMustSellApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;

        }


        public string MustSellApprovalStatus([FromForm] GetMSStatusIn inputParams)
        {
            dm.TraceService("MustSellApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {

                try
                {
                    string TrnNumber = inputParams.TransID == null ? "0" : inputParams.TransID;



                    try
                    {
                        string[] arr = { };
                        DataTable dt = dm.loadList("SelStatusforMustSellApproval", "sp_AppServices", TrnNumber.ToString(), arr);


                        if (dt.Rows.Count > 0)
                        {
                            List<GetStatusOutMs> listHeader = new List<GetStatusOutMs>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetStatusOutMs
                                {
                                    Status = dr["Status"].ToString()

                                });
                            }

                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listHeader
                            });

                            dm.TraceService("==========JSONString Generated " + JSONString + "==========");
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

                }

            }
            catch (Exception ex)
            {

            }

            dm.TraceService("MustSellApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
    }
}