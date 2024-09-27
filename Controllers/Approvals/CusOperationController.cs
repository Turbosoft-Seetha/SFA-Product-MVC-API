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
    public class CusOperationController : Controller
    {
        // GET: CusOperation
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]


        public string DisputeNoteHeader([FromForm] disputeNoteapprovalIN inputParams)
        {
            dm.TraceService("DisputeNoteHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;
            string MainCondition = "";
            string StatusCondition = "";
            if (Status_Value == "0")
            {
                StatusCondition = "";
            }
            else
            {
                StatusCondition = " and isnull(A.Status,'P') in ( '" + Status_Value + "' )";
            }

            MainCondition += StatusCondition;
            DataTable dt = dm.loadList("ListDisputeHeaderApprovalHeader", "sp_Approvals", MainCondition.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<disputeNoteapprovalOut> listHeader = new List<disputeNoteapprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["drh_Image"].ToString();


                        if (img != "")
                        {
                            string[] ar = (dr["drh_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                                else
                                {
                                    imag = url + ar[i];
                                }
                            }

                        }

                        listHeader.Add(new disputeNoteapprovalOut
                        {
                            drh_ID = dr["drh_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            drh_rot_ID = dr["drh_rot_ID"].ToString(),
                            drh_TransID = dr["drh_TransID"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            drh_Amount = dr["drh_Amount"].ToString(),
                            drh_DisputeType = dr["drh_DisputeType"].ToString(),
                            TransTime = dr["TransTime"].ToString(),
                            drh_OtherInfo = dr["drh_OtherInfo"].ToString(),
                            DisputeType = dr["DisputeType"].ToString(),
                            drh_Remarks = dr["drh_Remarks"].ToString(),
                            Status = dr["Status"].ToString(),
                              Image = imag,
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arusr_Name = dr["usr_ArabicName"].ToString(),
                            Ardrh_OtherInfo = dr["drh_OtherInfoArabic"].ToString(),
                            ArDisputeType = dr["ArDisputeType"].ToString(),
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
                dm.TraceService("DisputeNoteHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("DisputeNoteHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string DisputeNoteDetail([FromForm] disputeNoteDetailIN inputParams)
        {
            dm.TraceService("DisputeNoteDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            DataTable dt = dm.loadList("LisDisputeReqApprovalDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<disputeNoteDetailOut> listHeader = new List<disputeNoteDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                      

                        listHeader.Add(new disputeNoteDetailOut
                        {
                            drd_ID = dr["drd_ID"].ToString(),
                            drd_InvoiceBalance = dr["drd_InvoiceBalance"].ToString(),
                            InvoiceID = dr["InvoiceID"].ToString(),
                            TransTime = dr["TransTime"].ToString(),
                            InvoiceAmount = dr["InvoiceAmount"].ToString(),
                           


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
                dm.TraceService("DisputeNoteDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("DisputeNoteDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string CreditNoteHeader([FromForm] creditNoteapprovalIN inputParams)
        {
            dm.TraceService("CreditNoteHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            //  string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;
            string MainCondition = "";
            string StatusCondition = "";
            if (Status_Value == "0")
            {
                StatusCondition = "";
            }
            else
            {
                StatusCondition = " and isnull(A.Status,'P') in ( '" + Status_Value + "' )";
            }

            MainCondition += StatusCondition;

            DataTable dt = dm.loadList("CreditNotHeader", "sp_Approvals", MainCondition.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<creditNoteapprovalOut> listHeader = new List<creditNoteapprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                       

                        listHeader.Add(new creditNoteapprovalOut
                        {
                            cnh_ID = dr["cnh_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            cnh_Number = dr["cnh_Number"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            cnh_Amount = dr["cnh_Amount"].ToString(),
                            cnh_SubTotal = dr["cnh_SubTotal"].ToString(),
                            cnh_VAT = dr["cnh_VAT"].ToString(),
                            cnh_CreditType = dr["cnh_CreditType"].ToString(),
                            Status = dr["Status"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arusr_Name = dr["usr_ArabicName"].ToString(),
                            Arcnh_CreditType = dr["Arcnh_CreditType"].ToString(),
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
                dm.TraceService("CreditNoteHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CreditNoteHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string CreditNoteDetail([FromForm] creditNoteDetailIN inputParams)
        {
            dm.TraceService("CreditNoteDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            DataTable dt = dm.loadList("CreditNoteReqApprovalDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<creditNoteDetailOut> listHeader = new List<creditNoteDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new creditNoteDetailOut
                        {
                            cnd_ID = dr["cnd_ID"].ToString(),
                            inv_InvoiceID = dr["inv_InvoiceID"].ToString(),
                            TransTime = dr["TransTime"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            HUOM = dr["HUOM"].ToString(),
                            crd_HQty = dr["crd_HQty"].ToString(),
                            LUOM = dr["LUOM"].ToString(),
                            crd_LQty = dr["crd_LQty"].ToString(),
                            cnd_crd_Amount = dr["cnd_crd_Amount"].ToString(),
                            Status = dr["Status"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
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
                dm.TraceService("CreditNoteDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CreditNoteDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string PartialDeliveryHeader([FromForm] PartialDeliveryIN inputParams)
        {
            dm.TraceService("PartialDeliveryHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListApprovalHeader", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<PartialDeliveryOut> listHeader = new List<PartialDeliveryOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new PartialDeliveryOut
                        {
                            dah_ID = dr["dah_ID"].ToString(),
                            OrderID = dr["OrderID"].ToString(),
                            ExpectedDelDate = dr["ExpectedDelDate"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Type = dr["Type"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            dah_ApprovalStatus = dr["dah_ApprovalStatus"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Ardah_ApprovalStatus = dr["Ardah_ApprovalStatus"].ToString(),
                            Status = dr["Status"].ToString(),
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
                dm.TraceService("PartialDeliveryHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PartialDeliveryHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string PartialDeliveryDetail([FromForm] PartialDeliveryDetailIN inputParams)
        {
            dm.TraceService("PartialDeliveryDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            DataTable dt = dm.loadList("LisPartialDeliveryDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<PartialDeliveryDetailOut> listHeader = new List<PartialDeliveryDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new PartialDeliveryDetailOut
                        {
                            dad_ID = dr["dad_ID"].ToString(),
                            dad_prd_ID = dr["dad_prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            OrderedHQty = dr["OrderedHQty"].ToString(),
                            OrderedLQty = dr["OrderedLQty"].ToString(),
                            deliveringHQty = dr["deliveringHQty"].ToString(),
                            DeliveringLQty = dr["DeliveringLQty"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            prd_Description = dr["prd_Description"].ToString(),
                            rsn_ID = dr["rsn_ID"].ToString(),
                            rsn_Type = dr["rsn_Type"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
                            Arrsn_Name = dr["rsn_NameArabic"].ToString(),
                            Arprd_Description = dr["prd_ArabicDescription"].ToString(),
                            Arrsn_Type = dr["rsn_TypeArabic"].ToString(),
                            Status = dr["Status"].ToString(),
                            DetStatus = dr["DetStatus"].ToString(),
                            Reason = dr["rsn_Name"].ToString(),
                            ArReason = dr["rsn_NameArabic"].ToString()

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
                dm.TraceService("PartialDeliveryDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PartialDeliveryDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string ReturnReqSCHeader ([FromForm] ReturnReqSCHeaderIN inputParams)
        {
            dm.TraceService("ReturnReqSCHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListReturnReqApprovalHeader", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ReturnReqSCHeaderOut> listHeader = new List<ReturnReqSCHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new ReturnReqSCHeaderOut
                        {
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rrh_inv_ID = dr["rrh_inv_ID"].ToString(),
                            rrh_RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            rrh_ID = dr["rrh_ID"].ToString(),
                            rrh_Type = dr["rrh_Type"].ToString(),
                            rrh_ReturnType = dr["rrh_ReturnType"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arusr_Name = dr["usr_ArabicName"].ToString(),
                            Arrrh_ReturnType = dr["Arrrh_ReturnType"].ToString(),
                            Arrrh_Type = dr["Arrrh_Type"].ToString(),
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
                dm.TraceService("ReturnReqSCHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("ReturnReqSCHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string ReturnReqSCDetails([FromForm] ReturnReqSCDetailIN inputParams)
        {
            dm.TraceService("ReturnReqSCDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("LisReturnReqApprovalDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ReturnReqSCDetailOut> listHeader = new List<ReturnReqSCDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["rrd_Image"].ToString();


                        if (img != "")
                        {
                            string[] ar = (dr["rrd_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                                else
                                {
                                    imag = url + ar[i];
                                }
                            }

                        }


                        listHeader.Add(new ReturnReqSCDetailOut
                        {
                            rrd_ID = dr["rrd_ID"].ToString(),
                            rrd_rrh_ID = dr["rrd_rrh_ID"].ToString(),
                            rrd_prd_ID = dr["rrd_prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            HQty = dr["HQty"].ToString(),
                            rrd_HUOM = dr["rrd_HUOM"].ToString(),
                            LQty = dr["LQty"].ToString(),
                            rrd_LUOM = dr["rrd_LUOM"].ToString(),
                            rrd_LineNo = dr["rrd_LineNo"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            rsn_ID = dr["rsn_ID"].ToString(),
                            Image = imag,
                            rsn_Type = dr["rsn_Type"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
                            Arrsn_Name = dr["rsn_NameArabic"].ToString(),
                            ArStatus = dr["ArStatus"].ToString(),
                            Arrsn_Type = dr["rsn_TypeArabic"].ToString(),
                            Reason = dr["rsn_Name"].ToString(),
                            ArReason = dr["rsn_NameArabic"].ToString()




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
                dm.TraceService("ReturnReqSCDetails  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("ReturnReqSCDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetReasonForReturnSc([FromForm] ReasonRtnScIn inputParams)
        {
            dm.TraceService("GetReason STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rsn_Type = inputParams.rsn_Type == null ? "0" : inputParams.rsn_Type;

            DataTable dt = dm.loadList("SelectReasonforReurnReq", "sp_Approvals", rsn_Type.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ReasonRtnScOut> listHeader = new List<ReasonRtnScOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ReasonRtnScOut
                        {
                            rsn_ID = dr["rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            rsn_Type = dr["rsn_Type"].ToString()




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


        public string GetDisputeApprovalLevelStatus([FromForm] GetDisputeApprovalLevelStatusIn inputParams)
        {
            dm.TraceService("GetDisputeApprovalLevelStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;

            DataTable dt = dm.loadList("SelectUserLevelforDisputeApproval", "sp_Approvals", UserId.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetDisputeApprovalLevelStatusOut> listHeader = new List<GetDisputeApprovalLevelStatusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetDisputeApprovalLevelStatusOut
                        {
                            Status = dr["Status"].ToString(),
                            CurrentLevel = dr["CurrentLevel"].ToString(),
                            NextLevel = dr["NextLevel"].ToString()




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
                dm.TraceService("GetDisputeApprovalLevelStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetDisputeApprovalLevelStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string DisputeNoteApproval([FromForm] DisputeNoteApprovalIn inputParams)
        {
            dm.TraceService("DisputeNoteApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string Remark = inputParams.Remark == null ? "0" : inputParams.Remark;
            string NextLevel = inputParams.NextLevel == null ? "0" : inputParams.NextLevel;
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            string[] arr = { UserId, NextLevel, Remark };
            DataTable dt = dm.loadList("ApproveDisputeRequest", "sp_Approvals", ReqID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<DisputeNoteApprovalOut> listHeader = new List<DisputeNoteApprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new DisputeNoteApprovalOut
                        {
                            Status = dr["Status"].ToString(),
                          



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
                dm.TraceService("DisputeNoteApproval  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetDisputeApprovalLevelStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string DisputeNoteReject([FromForm] DisputeNoteRejectIn inputParams)
        {
            dm.TraceService("DisputeNoteApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string Remark = inputParams.Remark == null ? "0" : inputParams.Remark;
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            string[] arr = { UserId, Remark };
            DataTable dt = dm.loadList("RejectDisputeRequest", "sp_Approvals", ReqID.ToString(),arr);
            
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<DisputeNoteRejectOut> listHeader = new List<DisputeNoteRejectOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new DisputeNoteRejectOut
                        {
                            Status = dr["Status"].ToString(),




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
                dm.TraceService("DisputeNoteApproval  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetDisputeApprovalLevelStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string GetCreditNoteApprovalLevelStatus([FromForm] GetCraditApprovalLevelStatusIn inputParams)
        {
            dm.TraceService("GetCreditNoteApprovalLevelStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;

            DataTable dt = dm.loadList("SelectUserLevelForCreditNoteApproval", "sp_Approvals", UserId.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetCreditApprovalLevelStatusOut> listHeader = new List<GetCreditApprovalLevelStatusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetCreditApprovalLevelStatusOut
                        {
                            Status = dr["Status"].ToString(),
                            CurrentLevel = dr["CurrentLevel"].ToString(),
                            NextLevel = dr["NextLevel"].ToString(),
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
                dm.TraceService("GetCreditNoteApprovalLevelStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCreditNoteApprovalLevelStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }



        public string CreditNoteApproval([FromForm] CreditNoteApprovalIn inputParams)
        {
            dm.TraceService("CreditNoteApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string Remark = inputParams.Remark == null ? "0" : inputParams.Remark;
            string NextLevel = inputParams.NextLevel == null ? "0" : inputParams.NextLevel;
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            string[] arr = { UserId, NextLevel, Remark };
            DataTable dt = dm.loadList("ApproveCreditNoteRequest", "sp_Approvals", ReqID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CreditNoteApprovalOut> listHeader = new List<CreditNoteApprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CreditNoteApprovalOut
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
                dm.TraceService("CreditNoteApproval  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CreditNoteApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string CreditNoteReject([FromForm] CreditNoteRejectIn inputParams)
        {
            dm.TraceService("CreditNoteReject STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string Remark = inputParams.Remark == null ? "0" : inputParams.Remark;
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            string[] arr = { UserId, Remark };
            DataTable dt = dm.loadList("RejectCreditNoteRequest", "sp_Approvals", ReqID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CreditNoteRejectOut> listHeader = new List<CreditNoteRejectOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CreditNoteRejectOut
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
                dm.TraceService("CreditNoteReject  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CreditNoteReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetRouteForReturnSc()
        {
            dm.TraceService("GetReason STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            DataTable dt = dm.loadList("SelectRouteforSC", "sp_Approvals");

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetRouteForReturnOut> listHeader = new List<GetRouteForReturnOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetRouteForReturnOut
                        {
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Name = dr["rot_Name"].ToString()




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

        public string PostReturnReqSCApprovals([FromForm] PostReturnreqSCData inputParams)
        {
            dm.TraceService("PostReturnReqSCApprovals STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostReturnSCApprovalData> itemData = JsonConvert.DeserializeObject<List<PostReturnSCApprovalData>>(inputParams.JSONString);
                try
                {
                    string ReturnID = inputParams.ReturnID == null ? "0" : inputParams.ReturnID;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string RouteId = inputParams.RouteId == null ? "0" : inputParams.RouteId;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostReturnSCApprovalData id in itemData)
                            {
                                string[] arr = { id.rrd_ID.ToString(), id.Reason.ToString(), id.Status.ToString() };
                                string[] arrName = { "rrd_ID", "Reason", "Status" };
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
                        string[] arr = { userID.ToString(), ReturnID.ToString(), RouteId };
                        DataTable dt = dm.loadList("RetReqApproval", "sp_Approvals", InputXml.ToString(), arr);

                        List<GetOpenReturnSCApprovalStatus> listStatus = new List<GetOpenReturnSCApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetOpenReturnSCApprovalStatus> listHeader = new List<GetOpenReturnSCApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetOpenReturnSCApprovalStatus
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
            dm.TraceService("PostReturnReqSCApprovals ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }


        public string ResonForPartialDelivery([FromForm] ResonForPartialDeliveryIn inputParams)
        {
            dm.TraceService("DisputeNoteHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rsn_Type = inputParams.rsn_Type == null ? "0" : inputParams.rsn_Type;

            DataTable dt = dm.loadList("SelReason", "sp_Approvals", rsn_Type.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ResonForPartialDeliveryOut> listHeader = new List<ResonForPartialDeliveryOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new ResonForPartialDeliveryOut
                        {
                            rsn_ID = dr["rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
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
                dm.TraceService("DisputeNoteHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("DisputeNoteHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string PostPartialDeliveryApprovals([FromForm] PostPartialDelData inputParams)
        {
            dm.TraceService("PostPartialDeliveryApprovals STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostPartialDelDatas> itemData = JsonConvert.DeserializeObject<List<PostPartialDelDatas>>(inputParams.JSONString);
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
                            foreach (PostPartialDelDatas id in itemData)
                            {
                                string[] arr = { id.dad_ID.ToString(), id.Reason.ToString(), id.Status.ToString() };
                                string[] arrName = { "dad_ID", "Reason", "Status" };
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
                        DataTable dt = dm.loadList("PartialDeliveryApproval", "sp_CustomerConnect", ReturnID.ToString(), arr);

                        List<PostPartialDelStatus> listStatus = new List<PostPartialDelStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostPartialDelStatus> listHeader = new List<PostPartialDelStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostPartialDelStatus
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
            dm.TraceService("PostPartialDeliveryApprovals ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }



        public string SelectRouteForReturnSC()
        {
            dm.TraceService("SelectRouteForReturnSC STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {


                DataTable dtLogin = dm.loadList("SelectRouteforReturnSC", "sp_Approvals");




                if (dtLogin.Rows.Count > 0)
                {
                    List<SelectRouteForReturnSCOut> listItems = new List<SelectRouteForReturnSCOut>();



                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        listItems.Add(new SelectRouteForReturnSCOut
                        {
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Name = dr["rot_Name"].ToString()


                        });
                    }


                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(" SelectRouteForReturnSC Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForReturnSC ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }



        public string InventoryReconfirm([FromForm] InventoryReconfirmin inputParams)
        {
            dm.TraceService("InventoryReconfirm STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;

            DataTable dt = dm.loadList("ListInvReconfirmApprovalHeader", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<InventoryReconfirmOut> listHeader = new List<InventoryReconfirmOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                       

                        listHeader.Add(new InventoryReconfirmOut
                        {
                            iah_ID = dr["iah_ID"].ToString(),
                            iah_TransID = dr["iah_TransID"].ToString(),
                            iah_usr_ID = dr["iah_usr_ID"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            iah_rot_ID = dr["iah_rot_ID"].ToString(),
                            iah_Status = dr["iah_Status"].ToString(),
                            Arusr_Name = dr["usr_ArabicName"].ToString(),
                            Ariah_Status = dr["Ariah_Status"].ToString(),

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
                dm.TraceService("InventoryReconfirm  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("InventoryReconfirm ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string InventoryReconfirmDetails([FromForm] InventoryReconfirmDetailin inputParams)
        {
            dm.TraceService("InventoryReconfirmDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            DataTable dt = dm.loadList("ListInvReconfirmApprovalDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<InventoryReconfirmDetailOut> listHeader = new List<InventoryReconfirmDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new InventoryReconfirmDetailOut
                        {
                            iad_ID = dr["iad_ID"].ToString(),
                            iad_prd_ID = dr["iad_prd_ID"].ToString(),
                            iad_HigherQty = dr["iad_HigherQty"].ToString(),
                            iad_LowerQty = dr["iad_LowerQty"].ToString(),
                            iad_PhysicalHQty = dr["iad_PhysicalHQty"].ToString(),
                            iad_PhysicalLQty = dr["iad_PhysicalLQty"].ToString(),
                            iad_DescHQty = dr["iad_DescHQty"].ToString(),
                            iad_DescLQty = dr["iad_DescLQty"].ToString(),
                            iad_HigherUOM = dr["iad_HigherUOM"].ToString(),
                            iad_LowerUOM = dr["iad_LowerUOM"].ToString(),
                            iad_PhysicalHUOM = dr["iad_PhysicalHUOM"].ToString(),
                            iad_DescHUOM = dr["iad_DescHUOM"].ToString(),
                            iad_DescLUOM = dr["iad_DescLUOM"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
                            Status = dr["iad_Status"].ToString(),
                            Reason = dr["rsn_Name"].ToString()

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
                dm.TraceService("InventoryReconfirmDetails  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("InventoryReconfirmDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string InventoryReconfirmApproval([FromForm] InventoryReconfirmApprovalData inputParams)
        {
            dm.TraceService("InventoryReconfirmApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<InventoryReconfirmApprovalDatas> itemData = JsonConvert.DeserializeObject<List<InventoryReconfirmApprovalDatas>>(inputParams.JSONString);
                try
                {
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (InventoryReconfirmApprovalDatas id in itemData)
                            {
                                string[] arr = { id.iad_ID.ToString(), id.Reason.ToString(), id.Status.ToString() };
                                string[] arrName = { "iad_ID", "Reason", "Status" };
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
                        DataTable dt = dm.loadList("InvReconfirmApproval", "sp_MerchandisingWebServices", ReqID.ToString(), arr);
                        
                        List<PostInvRencofirmApprovalStatusOut> listStatus = new List<PostInvRencofirmApprovalStatusOut>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostInvRencofirmApprovalStatusOut> listHeader = new List<PostInvRencofirmApprovalStatusOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostInvRencofirmApprovalStatusOut
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
            dm.TraceService("InventoryReconfirmApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }


        public string GetReasonForInventoryReconfirm()
        {
            dm.TraceService("GetReasonForInventoryReconfirm STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            DataTable dt = dm.loadList("SelectReasonInvReconfirm", "sp_Approvals");
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<Reasons> list = new List<Reasons>();
                    foreach (DataRow dr in dt.Rows)


                    {
                      

                        list.Add(new Reasons
                        {
                            rsn_ID = dr["rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            rsn_ArName = dr["rsn_NameArabic"].ToString()


                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = list
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
                dm.TraceService("GetReasonForInventoryReconfirm  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReasonForInventoryReconfirm ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


    }
}