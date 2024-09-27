using Microsoft.AspNetCore.Mvc;
using MVC_API.FE_NAV_Service;
using MVC_API.Models;
using MVC_API.Models.ApprovalHelper;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.CustomerConnect
{
    public class MustSellApprovalController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string MustSellApprovalHeader([FromForm] MustSellApprovalHeaderIn inputParams)
        {
            dm.TraceService("MustSellApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListMustSellApprovalHeader", "sp_CustomerConnectApprovals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<MustSellApprovalHeaderOut> listHeader = new List<MustSellApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new MustSellApprovalHeaderOut
                        {
                            msa_id = dr["msa_id"].ToString(),
                            msa_TransID = dr["msa_TransID"].ToString(),
                            msa_usr_id = dr["msa_usr_id"].ToString(),
                            userName = dr["userName"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            msa_rot_id = dr["msa_rot_id"].ToString(),
                            OrdNumber = dr["OrdNumber"].ToString(),
                            salNumber = dr["salNumber"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedBy= dr["CreatedBy"].ToString(),
                            type = dr["rot_Type"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            Artype = dr["rot_ArType"].ToString(),
                            rot_ArName = dr["rot_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()



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
                dm.TraceService("MustSellApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("MustSellApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string MustSellApprovalDetail([FromForm] MustSellApprovalDetailsIn inputParams)
        {
            dm.TraceService("MustSellApprovalDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("MustSellApprovalDetail", "sp_CustomerConnectApprovals", HeaderID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<MustSellApprovalDetailsOut> listHeader = new List<MustSellApprovalDetailsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new MustSellApprovalDetailsOut
                        {
                            msd_id = dr["msd_id"].ToString(),
                            msd_msa_id = dr["msd_msa_id"].ToString(),
                            msd_prd_id = dr["msd_prd_id"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            msd_HQty = dr["msd_HQty"].ToString(),
                            HUOM = dr["HUOM"].ToString(),
                            msd_LQty = dr["msd_LQty"].ToString(),
                            LUOM = dr["LUOM"].ToString(),
                            Status = dr["Status"].ToString(),
                            prd_ArName = dr["prd_NameArabic"].ToString(),
                            ArHUOM = dr["ArHUOM"].ToString(),
                            ArLUOM = dr["ArLUOM"].ToString()

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
                dm.TraceService("MustSellApprovalDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("MustSellApprovalDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string PostMustSellApproval([FromForm] PostMustSellApprovalIn inputParams)
        {
            dm.TraceService("PostMustSellApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostMustSellApprovalData> itemData = JsonConvert.DeserializeObject<List<PostMustSellApprovalData>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostMustSellApprovalData id in itemData)
                            {
                                string[] arr = { id.msa_id.ToString(), id.Status.ToString() };
                                string[] arrName = { "msa_id", "Status" };
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
                        string[] arr = { userID.ToString(), TransID.ToString() };
                        DataTable dt = dm.loadList("PostMustSellApproval", "sp_CustomerConnectApprovals", InputXml.ToString(), arr);

                        List<PostMustSellApprovalStatus> listStatus = new List<PostMustSellApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostMustSellApprovalStatus> listHeader = new List<PostMustSellApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostMustSellApprovalStatus
                                {
                                    Status = dr["Status"].ToString(),
                                    Res = dr["Res"].ToString(),
                                    ArStatus = dr["ArStatus"].ToString()

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
    }
}