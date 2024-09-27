using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using System.Web;
using Org.BouncyCastle.Asn1.Ocsp;
using MVC_API.Models.CustomerConnectHelper;
namespace MVC_API.Controllers
{
    public class UnshceduledCusVisitApprovalController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
       
        [HttpPost]       
        public string InsUnshceduledCusVisitApproval([FromForm] InsUnshceduledCusVisitApprovalIn inputParams)
        {
            dm.TraceService("InsUnshceduledCusVisitApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
            string usrID = inputParams.usrID == null ? "0" : inputParams.usrID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { cusID.ToString(), usrID.ToString() };
            DataTable dt = dm.loadList("InsUnScheduledCusVisitApproval", "sp_UnscheduledVisitApproval", rotID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<InsUnshceduledCusVisitApprovalStatusOut> listHeader = new List<InsUnshceduledCusVisitApprovalStatusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new InsUnshceduledCusVisitApprovalStatusOut
                        {
                            Status = dr["Status"].ToString(),
                            Res = dr["Res"].ToString()

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
                dm.TraceService("InsUnshceduledCusVisitApproval  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("InsUnshceduledCusVisitApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetUnscheduledVisitApprovalStatus([FromForm] InsUnshceduledCusVisitApprovalIn inputParams)
        {
            dm.TraceService("GetUnscheduledVisitApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;


            string[] arr = { cusID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelStatus", "sp_UnscheduledVisitApproval", rotID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<GetUnscheduledVisitApprovalStatus> listHeader = new List<GetUnscheduledVisitApprovalStatus>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new GetUnscheduledVisitApprovalStatus
                        {
                            Status = dr["Status"].ToString()
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

            dm.TraceService("GetUnscheduledVisitApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string UnSchCusVisitApprovalHeader([FromForm] UnSchCusVisitApprovalHeaderIn inputParams)
        {
            dm.TraceService("UnSchCusVisitApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;

            DataTable dt = dm.loadList("ListUnscheduledCusVisitHeader", "sp_UnscheduledVisitApproval", Status_Value.ToString());
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<UnSchCusVisitApprovalHeaderOut> listHeader = new List<UnSchCusVisitApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new UnSchCusVisitApprovalHeaderOut
                        {
                            uva_ID = dr["uva_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Type = dr["rot_Type"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["status"].ToString(),
                            rot_ArName = dr["rot_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString()


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
                dm.TraceService("UnSchCusVisitApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("UnSchCusVisitApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string ApproveUnSchCusVisit([FromForm] ApproveUnSchCusVisitIn inputParams)
        {
            dm.TraceService("ApproveUnSchCusVisit STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            try
            {
                List<UnSchCusVisitApprovalData> itemData = JsonConvert.DeserializeObject<List<UnSchCusVisitApprovalData>>(inputParams.JSONString);
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
                            System.Collections.IList list = itemData;
                            for (int i = 0; i < list.Count; i++)
                            {
                                UnSchCusVisitApprovalData id = (UnSchCusVisitApprovalData)list[i];
                                string[] arr = { id.uva_ID.ToString()};
                                string[] arrName = { "uva_ID" };
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
                        DataTable dt = dm.loadList("ApproveUnSchCusVisit", "sp_UnscheduledVisitApproval", InputXml.ToString());

                        List<ApproveUnSchCusVisitOut> listStatus = new List<ApproveUnSchCusVisitOut>();
                        if (dt.Rows.Count > 0)
                        {
                            List<ApproveUnSchCusVisitOut> listHeader = new List<ApproveUnSchCusVisitOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new ApproveUnSchCusVisitOut
                                {
                                    Descr = dr["Descr"].ToString(),
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    ArDescr = dr["ArDescr"].ToString()


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

            dm.TraceService("ApproveUnSchCusVisit ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string RejectUnSchCusVisit([FromForm] RejectUnSchCusVisitIn inputParams)
        {
            dm.TraceService("RejectUnSchCusVisit STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            try
            {
                List<UnSchCusVisitRejectData> itemData = JsonConvert.DeserializeObject<List<UnSchCusVisitRejectData>>(inputParams.JSONString);
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
                            System.Collections.IList list = itemData;
                            for (int i = 0; i < list.Count; i++)
                            {
                                UnSchCusVisitRejectData id = (UnSchCusVisitRejectData)list[i];
                                string[] arr = { id.uva_ID.ToString() };
                                string[] arrName = { "uva_ID" };
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
                        DataTable dt = dm.loadList("RejectUnSchCusVisit", "sp_UnscheduledVisitApproval", InputXml.ToString());

                        List<RejectUnSchCusVisitOut> listStatus = new List<RejectUnSchCusVisitOut>();
                        if (dt.Rows.Count > 0)
                        {
                            List<RejectUnSchCusVisitOut> listHeader = new List<RejectUnSchCusVisitOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new RejectUnSchCusVisitOut
                                {
                                    Descr = dr["Descr"].ToString(),
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    ArDescr = dr["ArDescr"].ToString()


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

            dm.TraceService("RejectUnSchCusVisit ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


    }
}