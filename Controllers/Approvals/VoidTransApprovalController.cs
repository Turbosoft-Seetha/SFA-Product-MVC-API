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
    public class VoidTransApprovalController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string VoidTransApprovalHeader([FromForm] VoidTransApprovalHeaderIn inputParams)
        {
            dm.TraceService("VoidTransApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListVoidTransApprovalHeader", "sp_CustomerConnectApprovals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<VoidTransApprovalHeaderOut> listHeader = new List<VoidTransApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new VoidTransApprovalHeaderOut
                        {
                            vta_ID = dr["vta_ID"].ToString(),
                            type = dr["vta_type"].ToString(),
                            trn_Number = dr["vta_trn_Number"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            udpID = dr["vta_udp_id"].ToString(),
                            Status = dr["status"].ToString(),
                            Artype = dr["vta_Artype"].ToString(),
                            rot_ArName = dr["rot_ArabicName"].ToString()


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
                dm.TraceService("VoidTransApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("VoidTransApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string PostVoidTransApproval([FromForm] PostVoidTransApprovalIn inputParams)
        {
            dm.TraceService("PostVoidTransApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostVoidTransApprovalData> itemData = JsonConvert.DeserializeObject<List<PostVoidTransApprovalData>>(inputParams.JSONString);
                try
                {                   

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostVoidTransApprovalData id in itemData)
                            {
                                string[] arr = { id.vta_ID.ToString(), id.type.ToString(), id.trn_Number.ToString(), id.udpID.ToString(), id.userID.ToString() };
                                string[] arrName = { "vta_ID", "type", "trn_Number", "udpID", "userID" };
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
                        DataTable dt = dm.loadList("PostVoidTransApproval", "sp_CustomerConnectApprovals", InputXml.ToString());

                        List<PostVoidTranferApprovalStatusOut> listStatus = new List<PostVoidTranferApprovalStatusOut>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostVoidTranferApprovalStatusOut> listHeader = new List<PostVoidTranferApprovalStatusOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostVoidTranferApprovalStatusOut
                                {
                                    Descr = dr["Descr"].ToString(),
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString()

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
            dm.TraceService("PostVoidTransApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string PostVoidTransReject([FromForm] PostVoidTransApprovalIn inputParams)
        {
            dm.TraceService("PostVoidTransReject STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostVoidTransApprovalData> itemData = JsonConvert.DeserializeObject<List<PostVoidTransApprovalData>>(inputParams.JSONString);
                try
                {

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostVoidTransApprovalData id in itemData)
                            {
                                string[] arr = { id.vta_ID.ToString(), id.type.ToString(), id.trn_Number.ToString(), id.udpID.ToString(), id.userID.ToString() };
                                string[] arrName = { "vta_ID", "type", "trn_Number", "udpID", "userID" };
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
                        DataTable dt = dm.loadList("PostVoidTransReject", "sp_CustomerConnectApprovals", InputXml.ToString());

                        List<PostVoidTranferApprovalStatusOut> listStatus = new List<PostVoidTranferApprovalStatusOut>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostVoidTranferApprovalStatusOut> listHeader = new List<PostVoidTranferApprovalStatusOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostVoidTranferApprovalStatusOut
                                {
                                    Descr = dr["Descr"].ToString(),
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString()

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
            dm.TraceService("PostVoidTransReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
    }
}