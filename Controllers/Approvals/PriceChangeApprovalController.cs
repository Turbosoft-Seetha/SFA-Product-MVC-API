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
    public class PriceChangeApprovalController : Controller
    {
        // GET: PriceChangeApproval
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]




        public string PriceChangeHeader([FromForm] PriceChangeIn inputParams)
        {
            dm.TraceService("PriceChangeHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListPriceUpdateApprovalHeader", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<PriceChangeOut> listHeader = new List<PriceChangeOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new PriceChangeOut
                        {
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            pch_rot_ID = dr["pch_rot_ID"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            pch_ID = dr["pch_ID"].ToString(),
                            csh_Code = dr["csh_Code"].ToString(),
                            csh_Name = dr["csh_Name"].ToString(),
                            pch_ReqID = dr["pch_ReqID"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Type = dr["Type"].ToString(),
                            pch_ApprovalStatus = dr["pch_ApprovalStatus"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arusr_Name = dr["usr_ArabicName"].ToString(),
                            Arcsh_Name = dr["csh_NameArabic"].ToString(),
                            Arpch_ApprovalStatus = dr["Arpch_ApprovalStatus"].ToString(),
                            ArType = dr["ArType"].ToString()
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
                dm.TraceService("PriceChangeHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PriceChangeHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string PriceChangeDetail([FromForm] PriceChangeDetailIn inputParams)
        {
            dm.TraceService("PriceChangeHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string pch_ID = inputParams.pch_ID == null ? "0" : inputParams.pch_ID;

            DataTable dt = dm.loadList("LisPriceUpdateApprovalDetail", "sp_Approvals", pch_ID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<PriceChangeDetailOut> listHeader = new List<PriceChangeDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new PriceChangeDetailOut
                        {
                            pcd_ID = dr["pcd_ID"].ToString(),
                            pcd_pch_ID = dr["pcd_pch_ID"].ToString(),
                            pcd_prd_ID = dr["pcd_prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            pcd_HigherQty = dr["pcd_HigherQty"].ToString(),
                            pcd_HigherUOM = dr["pcd_HigherUOM"].ToString(),
                            pcd_LowerQty = dr["pcd_LowerQty"].ToString(),
                            pcd_LowerUOM = dr["pcd_LowerUOM"].ToString(),
                            pcd_stdHPrice = dr["pcd_stdHPrice"].ToString(),
                            pcd_changedHPrice = dr["pcd_changedHPrice"].ToString(),
                            pcd_stdLPrice = dr["pcd_stdLPrice"].ToString(),
                            pcd_changedLprice = dr["pcd_changedLprice"].ToString(),
                            pcd_HigherLimitPercent = dr["pcd_HigherLimitPercent"].ToString(),
                            pcd_LowerLimtPercent = dr["pcd_LowerLimtPercent"].ToString(),
                            maxHigherlimit = dr["maxHigherlimit"].ToString(),
                            MinHigherLimit = dr["MinHigherLimit"].ToString(),
                            MinLowerLimit = dr["MinLowerLimit"].ToString(),
                            maxLowerlimit = dr["maxLowerlimit"].ToString(),
                            pcd_ApprovalStatus = dr["pcd_ApprovalStatus"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
                            Arpcd_ApprovalStatus = dr["Arpcd_ApprovalStatus"].ToString(),
                            Reason = dr["rsn_Name"].ToString(),
                            ArReason = dr["rsn_NameArabic"].ToString(),
                            pcd_ApprovedHPrice = dr["pcd_ApprovedHPrice"].ToString(),
                            pcd_ApprovedLPrice = dr["pcd_ApprovedLPrice"].ToString()

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
                dm.TraceService("PriceChangeHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PriceChangeHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }



        public string PostPriceChangeApproval([FromForm] PostSpecialPriceData inputParams)
        {
            dm.TraceService("PostReturnRequestApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostSpecialPriceItemData> itemData = JsonConvert.DeserializeObject<List<PostSpecialPriceItemData>>(inputParams.JSONString);
                try
                {
                    string PriceID = inputParams.PriceID == null ? "0" : inputParams.PriceID;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostSpecialPriceItemData id in itemData)
                            {
                                string[] arr = { id.pcd_ID.ToString(), id.Reason.ToString(), id.Status.ToString(), id.aprvdHprice.ToString(), id.aprvdLprice.ToString() };
                                string[] arrName = { "pcd_ID", "Reason", "Status", "aprvdHprice", "aprvdLprice" };
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
                        string[] arr = { userID.ToString(), InputXml.ToString() };
                        DataTable dt = dm.loadList("PriceUpdateApproval", "sp_CustomerConnect", PriceID.ToString(), arr);

                        List<PriceChangeStatus> listStatus = new List<PriceChangeStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PriceChangeStatus> listHeader = new List<PriceChangeStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PriceChangeStatus
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


        public string GetReason([FromForm] ReasonPCIn inputParams)
        {
            dm.TraceService("GetReason STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rsn_Type = inputParams.rsn_Type == null ? "0" : inputParams.rsn_Type;

            DataTable dt = dm.loadList("SelectReasonforReurnReq", "sp_Approvals", rsn_Type.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ReasonPCOut> listHeader = new List<ReasonPCOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ReasonPCOut
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
                dm.TraceService("GetReason  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReason ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }




}