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
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVC_API.Controllers.Approvals
{
    public class ReturnApprovalController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]


        public string GetReturnReqHeader([FromForm] ReturnReqIn inputParams)
        {
            dm.TraceService("GetReturnReqHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
           // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListReturnApprovalHeader", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ReturnReqOut> listHeader = new List<ReturnReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ReturnReqOut
                        {
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rrh_RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            rah_ID = dr["rah_ID"].ToString(),
                            csh_Code = dr["csh_Code"].ToString(),
                            csh_Name = dr["csh_Name"].ToString(),
                            Mode = dr["Mode"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            rah_ApprovalStatus = dr["rah_ApprovalStatus"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arusr_Name = dr["usr_ArabicName"].ToString(),
                            Arcsh_Name = dr["csh_NameArabic"].ToString(),
                            Arrah_ApprovalStatus = dr["Arrah_ApprovalStatus"].ToString()
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
                dm.TraceService("GetReturnReqHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReturnReqHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }




        public string GetReturnReqDetail([FromForm] ReturnReqDetailIn inputParams)
        {
            dm.TraceService("GetReturnReqDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Req_ID = inputParams.Req_ID == null ? "0" : inputParams.Req_ID;

            string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;

            string[] arr = { Mode.ToString() };

            DataTable dt = dm.loadList("LisReturnApprovalDetail", "sp_Approvals", Req_ID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ReturnReqDetailOut> listHeader = new List<ReturnReqDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ReturnReqDetailOut
                        {
                            rad_ID = dr["rad_ID"].ToString(),
                            rad_prd_ID = dr["rad_prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            RequestedHQty = dr["RequestedHQty"].ToString(),
                            HUOM = dr["HUOM"].ToString(),
                            RequestedLQty = dr["RequestedLQty"].ToString(),
                            RLUOM = dr["RLUOM"].ToString(),
                            ReturnHQty = dr["ReturnHQty"].ToString(),
                            ReturnedHUOM = dr["ReturnedHUOM"].ToString(),
                            ReturnLQty = dr["ReturnLQty"].ToString(),
                            LUOM = dr["LUOM"].ToString(),
                            AdjustedHQty = dr["AdjustedHQty"].ToString(),
                            AdjustedLQty = dr["AdjustedLQty"].ToString(),
                            ExcessHQty = dr["ExcessHQty"].ToString(),
                            ExcessLQty = dr["ExcessLQty"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            inv_InvoiceID = dr["inv_InvoiceID"].ToString(),
                            rad_ApprovalStatus = dr["rad_ApprovalStatus"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
                            Arrsn_Name = dr["rsn_NameArabic"].ToString()

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
                dm.TraceService("GetReturnReqDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReturnReqDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetReasonFromDrop([FromForm] ReasonIn inputParams)
        {
            dm.TraceService("GetReasonFromDrop STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rsn_Type = inputParams.rsn_Type == null ? "0" : inputParams.rsn_Type;

            DataTable dt = dm.loadList("SelectReasonforReurnReq", "sp_Approvals", rsn_Type.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ReasonOut> listHeader = new List<ReasonOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ReasonOut
                        {
                            rsn_ID = dr["rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            rsn_Type = dr["rsn_Type"].ToString(),
                            rsn_ArName = dr["rsn_NameArabic"].ToString()





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
                dm.TraceService("GetReasonFromDrop  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReasonFromDrop ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string PostReturnRequestApproval([FromForm] PostReturnreqData inputParams)
        {
            dm.TraceService("PostReturnRequestApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostReturnApprovalData> itemData = JsonConvert.DeserializeObject<List<PostReturnApprovalData>>(inputParams.JSONString);
                try
                {
                    string ReturnID = inputParams.ReturnID == null ? "0" : inputParams.ReturnID;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                   

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostReturnApprovalData id in itemData)
                            {
                                string[] arr = { id.rad_ID.ToString(), id.Reason.ToString(), id.Status.ToString() };
                                string[] arrName = { "rad_ID", "Reason", "Status" };
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
                        string[] arr = { userID.ToString(), InputXml.ToString()};
                        DataTable dt = dm.loadList("ReturnApproval", "sp_Approvals", ReturnID.ToString(), arr);

                        List<GetOpenReturnApprovalStatus> listStatus = new List<GetOpenReturnApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetOpenReturnApprovalStatus> listHeader = new List<GetOpenReturnApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetOpenReturnApprovalStatus
                                {
                                    Mode = dr["Res"].ToString(),
                                    Status = dr["Status"].ToString(),
                                    TransID = dr["TransID"].ToString(),
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
            dm.TraceService("PostReturnRequestApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }


    }
}