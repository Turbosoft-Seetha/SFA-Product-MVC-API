using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Stimulsoft.Report.Check;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using static iTextSharp.text.pdf.PdfStructTreeController;

namespace MVC_API.Controllers
{
    public class MRController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        ProcessJson pj = new ProcessJson();

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [System.Web.Http.HttpPost]
        public string ListMRH([FromForm] ListMRHinParam inParams)
        {
            try
            {
                dm.TraceService("==========MRH Listing Started==========");
                string[] arr = { };
                DataTable CI = dm.loadList("SelectMRHeader", "sp_AppServices", inParams.User);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<ListMRHOutParam> listItems = new List<ListMRHOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new ListMRHOutParam
                        {
                            mrhID = dr["mrh_ID"].ToString(),
                            mrhnumber = dr["mrh_Number"].ToString(),
                            ExpDate = dr["mrh_ExpDate"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            status = dr["mrh_Status"].ToString(),
                            StoreID = dr["mrh_str_id"].ToString(),
                            StoreCode = dr["str_Code"].ToString(),
                            StoreName = dr["str_Name"].ToString(),
                            WarID = dr["war_Id"].ToString(),
                            WarCode = dr["war_code"].ToString(),
                            WarName= dr["war_name"].ToString(),
                            Platform= dr["mrh_platform"].ToString(),
                            Arabic_status = dr["mrh_Arabic_Status"].ToString(),
                            Arabic_StoreName = dr["str_ArabicName"].ToString(),
                            Arabic_WarName = dr["war_ArabicName"].ToString(),
                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========MRH Listing End==========");
            return JSONString;
        }


        public string ListMRD([FromForm] ListMRDinParam inParams)
        {
            try
            {
                dm.TraceService("==========MRD Listing Started==========");
                string[] arr = { };
                DataTable CI = dm.loadList("ListMRApprovalDetail", "sp_AppServices", inParams.mrhID);
                dm.TraceService("==========Query Executed==========");


                string JSONString = string.Empty;
                try
                {
                    if (CI.Rows.Count > 0)
                    {
                        JSONString = pj.MRDetailData(CI);
                    }
                    else
                    {
                        JSONString = "NoDataRes";
                    }
                }
                catch (Exception ex)
                {
                    JSONString = "NoDataSQL";
                }

                return JSONString;

                
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========MRD Listing End==========");
            return JSONString;
        }

        public string RepeatPrevMR([FromForm] ListMRHinParam inParams)
        {
            try
            {
                dm.TraceService("==========RptPrevMR Started==========");

                DataTable CI = dm.loadList("SelectPreviousMR", "sp_AppServices", inParams.User);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<ListMRHOutParam> listItems = new List<ListMRHOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new ListMRHOutParam
                        {
                            mrhID = dr["mrh_ID"].ToString(),
                            mrhnumber = dr["mrh_Number"].ToString(),
                            ExpDate = dr["mrh_ExpDate"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            status = dr["mrh_Status"].ToString(),
                            StoreCode = dr["str_Code"].ToString(),
                            StoreName = dr["str_Name"].ToString(),
                            WarCode = dr["war_code"].ToString(),
                            WarName = dr["war_name"].ToString(),
                            Platform = dr["mrh_platform"].ToString(),
                            Arabic_status = dr["mrh_Arabic_Status"].ToString(),
                            Arabic_StoreName = dr["str_ArabicName"].ToString(),
                            Arabic_WarName = dr["war_ArabicName"].ToString(),
                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========RptPrevMR End==========");
            return JSONString;
        }

        public string InsMR([FromForm] PostMR inputParams)
        {
            dm.TraceService("PostReturnRequestApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostMRDetail> itemData = JsonConvert.DeserializeObject<List<PostMRDetail>>(inputParams.jsonValue);
                try
                {
                    string mrhID = inputParams.MrhID == null ? "0" : inputParams.MrhID;
                    string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                    string status=inputParams.Status == null ? "0" : inputParams.Status;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostMRDetail id in itemData)
                            {
                                string[] arr = { id.prd_ID.ToString(), id.HRQuantity.ToString(), id.LRQuantity.ToString(), id.HUOM.ToString(), id.LUOM.ToString()};
                                string[] arrName = { "prd_ID", "HRQuantity", "LRQuantity", "HUOM", "LUOM" };
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
                        string[] arr = { UserID.ToString(), status.ToString(), InputXml.ToString() };

                        DataTable dt = new DataTable();
                        if (mrhID.ToString() == "0")
                        {
                             dt = dm.loadList("InsMR", "sp_AppServices", mrhID.ToString(), arr);
                        }
                        else
                        {
                            dt = dm.loadList("UpdateMR", "sp_AppServices", mrhID.ToString(), arr);
                        }
                        

                        List<GetReturnInsertStatus> listStatus = new List<GetReturnInsertStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetStatus> listHeader = new List<GetStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetStatus
                                {
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Status"].ToString(),
                                    mrhID = dr["mrhID"].ToString()

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

                }

            }
            catch(Exception ex)
            {

            }

            return JSONString;
        }


        public string PostDraftCancel([FromForm] PostDraftCancel inParams)
        {
            dm.TraceService("PostDraftCancel STARTED ");
            dm.TraceService("===================");
            try
            {
                try
                {
                    string MrhID = inParams.MrhID == null ? "0" : inParams.MrhID;
                    string UserID = inParams.UserID == null ? "0" : inParams.UserID;

                    try
                    {

                        dm.TraceService("==========PostStartPicking Started==========");
                        string[] arr = { UserID };
                        DataTable CI = dm.loadList("CancelDraft", "sp_AppServices", MrhID.ToString(), arr);
                        dm.TraceService("==========Query Executed==========");
                        if (CI.Rows.Count > 0)
                        {
                            dm.TraceService("==========Row Count Greated Than 0==========");
                            string Mode = CI.Rows[0]["res"].ToString();
                            string Title = CI.Rows[0]["Title"].ToString();
                            string Descr = CI.Rows[0]["Descr"].ToString();
                            dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
                            List<GetPickingStatus> listStatus = new List<GetPickingStatus>();
                            listStatus.Add(new GetPickingStatus
                            {
                                Res = Mode,
                                Title = Title,
                                Descr = Descr
                            });

                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listStatus
                            });
                            dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                            return JSONString;
                        }
                        else
                        {
                            dm.TraceService("==========Row Count Equal To 0==========");
                            JSONString = "NoDataRes";
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                        JSONString = "NoDataSQL";
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

            dm.TraceService("PostDraftCancel ENDED ");
            dm.TraceService("=================");

            return JSONString;
        }
    }
}