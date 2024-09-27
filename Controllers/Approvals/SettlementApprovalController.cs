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
    public class SettlementApprovalController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SettlementApprovalHeader([FromForm] SettlementApprovalHeaderIn inputParams)
        {
            dm.TraceService("SettlementApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListSettlementApprovalHeader", "sp_CustomerConnectApprovals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SettlementApprovalHeaderOut> listHeader = new List<SettlementApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SettlementApprovalHeaderOut
                        {
                            sta_ID = dr["sta_ID"].ToString(),
                            udp_ID = dr["udp_ID"].ToString(),
                            rot_Type = dr["rot_Type"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),                            
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            StartTime = dr["StartTime"].ToString(),
                            Arrot_Name = dr["rot_ArabicName"].ToString(),
                            Arusr_Name = dr["usr_ArabicName"].ToString(),
                            Arrot_Type = dr["Arrot_Type"].ToString()

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
                dm.TraceService("SettlementApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SettlementApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SettlementApprovalCashDetail([FromForm] SettlementApprovalCashDetailIn inputParams)
        {
            dm.TraceService("SettlementApprovalCashDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelTotalCash", "sp_CustomerConnectApprovals", udpID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SettlementApprovalCashDetailOut> listHeader = new List<SettlementApprovalCashDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SettlementApprovalCashDetailOut
                        {
                            CashInv = dr["csInv"].ToString(),
                            CashAR = dr["csAr"].ToString(),
                            debitNote = dr["debitNote"].ToString(),
                            CashTotal = dr["csTotal"].ToString(),
                            CashAdv = dr["csAdp"].ToString(),
                            PendingBalance = dr["PendingBalance"].ToString(),
                            PettyCash = dr["Petty"].ToString()
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
                dm.TraceService("SettlementApprovalCashDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SettlementApprovalCashDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SettlementApprovalPaymodeDetail([FromForm] SettlementApprovalPaymodeDetailIn inputParams)
        {
            dm.TraceService("SettlementApprovalPaymodeDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelectSettlementApprovalPayModes", "sp_CustomerConnectApprovals", udpID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SettlementApprovalPaymodeDetailOut> listHeader = new List<SettlementApprovalPaymodeDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SettlementApprovalPaymodeDetailOut
                        {
                            Mode = dr["Mode"].ToString(),
                            ExpectedAmount = dr["usp_ExpectedAmount"].ToString(),
                            CollectedAmount = dr["usp_CollectedAmount"].ToString(),
                            Variance = dr["usp_Variance"].ToString(),
                            ExpectedAmountTotal = dr["usp_ExpectedAmountTotal"].ToString(),
                            CollectedAmountTotal = dr["usp_CollectedAmountTotal"].ToString(),
                            VarianceTotal = dr["usp_VarianceTotal"].ToString(),
                            VarianceLimit = dr["VarLimit"].ToString(),
                            ArMode = dr["ArMode"].ToString()

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
                dm.TraceService("SettlementApprovalPaymodeDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SettlementApprovalPaymodeDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SettlementApprovalPaymentDetail([FromForm] SettlementApprovalPaymodeDetailIn inputParams)
        {
            dm.TraceService("SettlementApprovalPaymentDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelectPayment", "sp_CustomerConnectApprovals", udpID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SettlementApprovalPaymentDetailOut> listHeader = new List<SettlementApprovalPaymentDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new SettlementApprovalPaymentDetailOut
                        {                           
                            cus_Code = dr["cus_Code"].ToString(),
                            name = dr["name"].ToString(),
                            type = dr["type"].ToString(),
                            chequeNo = dr["chequeNo"].ToString(),
                            chequeDate = dr["chequeDate"].ToString(),
                            bnk_Name = dr["bnk_Name"].ToString(),
                            amount = dr["amount"].ToString(),
                            Arbnk_Name = dr["bnk_NameArabic"].ToString(),
                            Arname = dr["cus_NameArabic"].ToString(),
                            Artype = dr["ArType"].ToString()
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
                dm.TraceService("SettlementApprovalPaymentDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SettlementApprovalPaymentDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string PostSettlementApproval([FromForm] SettlementApprovalPaymodeDetailIn inputParams)
        {
            dm.TraceService("SettlementApprovalPaymentDetail STARTED " + DateTime.Now.ToString());

            dm.TraceService("======================================");
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("PostSettlementApproval", "sp_CustomerConnectApprovals", udpID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<PostSettlementApprovalOut> listHeader = new List<PostSettlementApprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new PostSettlementApprovalOut
                        {
                            Status = dr["Status"].ToString(),
                            Res = dr["Res"].ToString(),
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
                dm.TraceService("SettlementApprovalPaymentDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SettlementApprovalPaymentDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
            
        }
        public string PostSettlementReject([FromForm] SettlementApprovalPaymodeDetailIn inputParams)
        {
            dm.TraceService("SettlementApprovalPaymentDetail STARTED " + DateTime.Now.ToString());

            dm.TraceService("======================================");
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("PostSettlementReject", "sp_CustomerConnectApprovals", udpID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<PostSettlementApprovalOut> listHeader = new List<PostSettlementApprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new PostSettlementApprovalOut
                        {
                            Status = dr["Status"].ToString(),
                            Res = dr["Res"].ToString(),
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
                dm.TraceService("PostSettlementReject  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PostSettlementReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
       
    }
}