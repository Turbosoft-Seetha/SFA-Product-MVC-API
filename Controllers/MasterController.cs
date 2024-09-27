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

namespace MVC_API.Controllers
{
    public class MasterController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]
        public string GetCustomerDocuments([FromForm] CusDocIn inputParams)
        {
            dm.TraceService("GetCustomerDocuments STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelCustomerDocuments", "sp_App", CusID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CusDocOut> listHeader = new List<CusDocOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusDocOut
                        {
                            DocName = dr["cdc_DocName"].ToString(),
                            DocUrl = url + dr["cdc_DocPath"].ToString(),
                            FromDate = dr["cdc_FromDate"].ToString(),
                            EndDate = dr["cdc_ToDate"].ToString(),

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
                dm.TraceService("GetCustomerDocuments  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCustomerDocuments ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetVehicle([FromForm] getVehicleIn inputParams)
        {
            dm.TraceService("GetVehicle STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string RotID = inputParams.rotID == null ? "0" : inputParams.rotID;



            DataTable dtReturnStatus = dm.loadList("SelVehicle", "sp_App", RotID.ToString());

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<getVehicleOut> listHeader = new List<getVehicleOut>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new getVehicleOut
                        {
                            vehicleID = dr["veh_ID"].ToString(),
                            vehicleNumber = dr["veh_Number"].ToString(),
                            brand= dr["veh_brandName"].ToString(),

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

            dm.TraceService("GetVehicle ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetHelper([FromForm] getHelperIn inputParams)
        {
            dm.TraceService("GetHelper STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string RotID = inputParams.rotID == null ? "0" : inputParams.rotID;



            DataTable dt = dm.loadList("SelHelper", "sp_App", RotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<getHelperOut> listHeader = new List<getHelperOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new getHelperOut
                        {
                            HelperID = dr["hel_ID"].ToString(),
                            HelperCode = dr["hel_Code"].ToString(),
                            HelperName = dr["hel_Name"].ToString(),


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

            dm.TraceService("GetHelper ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetPreviousVariances([FromForm] getVarianceIn inputParams)
        {
            dm.TraceService("GetPreviousVariances STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string RotID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;



            DataTable dt = dm.loadList("SelectVariances", "sp_SFA_App", RotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<getVarianceOut> listHeader = new List<getVarianceOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new getVarianceOut
                        {
                            Variance = dr["Variance"].ToString(),
                            Date = dr["Date"].ToString(),


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

            dm.TraceService("GetPreviousVariances ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCusDocExpiry([FromForm] CusDocExpIn inputParams)
        {
            dm.TraceService("GetCusDocExpiry STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string RotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;



            DataTable dt = dm.loadList("SelCusDocExpiryDate", "sp_App", RotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CusDocExpOut> listHeader = new List<CusDocExpOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusDocExpOut
                        {
                            cusID = dr["cdc_cus_ID"].ToString(),
                            ExpiryDate = dr["cdc_ToDate"].ToString(),



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

            dm.TraceService("GetCusDocExpiry ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string InsJourneyPlanSeqRequest([FromForm] InJourneyPlan inputParams)
        {
            {
                dm.TraceService("InsJourneyPlanSeqRequest STARTED ");
                dm.TraceService("==============================");

                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string rotId = inputParams.rotID == null ? "0" : inputParams.rotID;
                string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
                string udpId = inputParams.udpID == null ? "0" : inputParams.udpID;
                string PrevSeq = inputParams.PrevSeq == null ? "0" : inputParams.PrevSeq;
                string CurrentSeq = inputParams.CurrentSeq == null ? "0" : inputParams.CurrentSeq;
                string rsnID = inputParams.rsnID == null ? "0" : inputParams.rsnID;



                try
                {

                    string[] ar = { cusID, udpId, PrevSeq, CurrentSeq, rsnID, UserID };
                    DataTable dtDN = dm.loadList("InsJourneyPlanReq", "sp_JourneyPlanRequest", rotId, ar);
                    if (dtDN.Rows.Count > 0)
                    {
                        List<OutJourneyPlan> listDn = new List<OutJourneyPlan>();
                        foreach (DataRow dr in dtDN.Rows)
                        {
                            listDn.Add(new OutJourneyPlan
                            {
                                res = dr["res"].ToString(),
                                des = dr["Des"].ToString(),


                            });
                        }
                        JSONString = JsonConvert.SerializeObject(new
                        {
                            result = listDn
                        });

                        return JSONString;
                    }
                    else
                    {
                        JSONString = "NoDataRes";
                        dm.TraceService("NoDataRes");
                    }

                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "NoDataSQL - " + ex.Message.ToString();
                }




            }

            dm.TraceService("InsJourneyPlanSeqRequest ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }
        public string GetJPApprovalStatus([FromForm] JPApprvlIN inputParams)
        {
            dm.TraceService("GetJPApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            
            string ApprovalID = inputParams.ApprovalID == null ? "0" : inputParams.ApprovalID;


           
            DataTable dtStatus = dm.loadList("SelStatusForReturnApproval", "sp_JourneyPlanRequest", ApprovalID.ToString());

            try
            {
                if (dtStatus.Rows.Count > 0)
                {
                    List<JPApprvlOut> listHeader = new List<JPApprvlOut>();
                    foreach (DataRow dr in dtStatus.Rows)
                    {
                        listHeader.Add(new JPApprvlOut
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
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetJPApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetJPApprovalCancel([FromForm] JPApprvlIN inputParams)
        {
            dm.TraceService("GetJPApprovalCancel STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ApprovalID = inputParams.ApprovalID == null ? "0" : inputParams.ApprovalID;



            DataTable dtStatus = dm.loadList("CancelJPApproval", "sp_JourneyPlanRequest", ApprovalID.ToString());

            try
            {
                if (dtStatus.Rows.Count > 0)
                {
                    List<JPApprvlCancelOut> listHeader = new List<JPApprvlCancelOut>();
                    foreach (DataRow dr in dtStatus.Rows)
                    {
                        listHeader.Add(new JPApprvlCancelOut
                        {
                            Res = dr["Res"].ToString(),
                            Message = dr["Message"].ToString(),


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

            dm.TraceService("GetJPApprovalCancel ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
     

    }
}