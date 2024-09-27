using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.ApprovalHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVC_API.Controllers.Approvals
{
    public class JourneyplanseqController : Controller
    {
        // GET: Journeyplanseq
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]


        public string JourneyplanseqHeader([FromForm] JourneyplanseqHeaderIn inputParams)
        {
            dm.TraceService("JourneyplanseqHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("SelJPSeqApprovalRequests", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<JourneyplanseqHeaderOut> listHeader = new List<JourneyplanseqHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new JourneyplanseqHeaderOut
                        {
                            jps_ID = dr["jps_ID"].ToString(),
                            jps_PrevSeq = dr["jps_PrevSeq"].ToString(),
                            jps_CurrentSeq = dr["jps_CurrentSeq"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            Route = dr["Route"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            ArStatus = dr["ArabicStatus"].ToString()

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
                dm.TraceService("JourneyplanseqHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("JourneyplanseqHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }




        public string PostJourneyplanseqApproval([FromForm] PostJourneyplanseqData inputParams)
        {
            dm.TraceService("PostJourneyplanseqApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostJourneyplanseqDataS> itemData = JsonConvert.DeserializeObject<List<PostJourneyplanseqDataS>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostJourneyplanseqDataS id in itemData)
                            {
                                string[] arr = { id.jps_ID.ToString() };
                                string[] arrName = { "jps_ID"};
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
                        string[] arr = { userID.ToString() };
                        DataTable dt = dm.loadList("ApproveJPSeqRequest", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<PostJourneyplanseqStatus> listStatus = new List<PostJourneyplanseqStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostJourneyplanseqStatus> listHeader = new List<PostJourneyplanseqStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostJourneyplanseqStatus
                                {

                                    Status = dr["Status"].ToString(),
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
            dm.TraceService("PostJourneyplanseqApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }

        public string PostJourneyplanseqReject([FromForm] PostJourneyplanseqrejectData inputParams)
        {
            dm.TraceService("PostJourneyplanseqReject STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostJourneyplanseqrejectDatas> itemData = JsonConvert.DeserializeObject<List<PostJourneyplanseqrejectDatas>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostJourneyplanseqrejectDatas id in itemData)
                            {
                                string[] arr = { id.jps_ID.ToString() };
                                string[] arrName = { "jps_ID" };
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
                        string[] arr = { userID.ToString() };
                        DataTable dt = dm.loadList("RejectJPSeqRequest", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<PostJourneyplanseqrejectStatus> listStatus = new List<PostJourneyplanseqrejectStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostJourneyplanseqrejectStatus> listHeader = new List<PostJourneyplanseqrejectStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostJourneyplanseqrejectStatus
                                {

                                    Status = dr["Status"].ToString(),
                                    ArStatus = dr["ArStatus"].ToString(),
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
            dm.TraceService("PostJourneyplanseqReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
    }
}