using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class KPIServiceController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Mvc.HttpPost]

        public string GetServiceJobsCount([FromForm] PlannedSJIn inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelcountPlannedServiceJob", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<PlannedSJOut> listHeader = new List<PlannedSJOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new PlannedSJOut
                        {
                            totalPlanned = dr["totalPlanned"].ToString(),
                            completed = dr["completed"].ToString(),
                            Pending = dr["Pending"].ToString(),

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
                dm.TraceService("GetServiceJobsCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceJobsCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetAttendedServiceJobsCount([FromForm] PlannedSJIn inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelcountActualServiceJob", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ActualSJOut> listHeader = new List<ActualSJOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ActualSJOut
                        {
                            Actual = dr["Actual"].ToString(),
                            Planned = dr["Planned"].ToString(),
                            UnPlanned = dr["UnPlanned"].ToString(),

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
                dm.TraceService("GetServiceJobsCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceJobsCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetInvoiceAmountServiceJobs([FromForm] PlannedSJIn inputParams)
        {
            dm.TraceService("GetInvoiceAmountServiceJobs STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelInvoiceAmountServiceJob", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<InvoiceSJOut> listHeader = new List<InvoiceSJOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new InvoiceSJOut
                        {
                            InvoicedAmount = dr["InvoicedAmount"].ToString(),
                            Credit = dr["Credit"].ToString(),
                            OnlinePayment = dr["OnlinePayment"].ToString(),
                            POS = dr["POS"].ToString(),
                            HardCash = dr["HardCash"].ToString()

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
                dm.TraceService("GetInvoiceAmountServiceJobs  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetInvoiceAmountServiceJobs ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetInvoiceCountsServiceJobs([FromForm] PlannedSJIn inputParams)
        {
            dm.TraceService("GetInvoiceCountsServiceJobs STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelInvoiceCountsServiceJob", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<InvCountsSJOut> listHeader = new List<InvCountsSJOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new InvCountsSJOut
                        {

                            CRcount = dr["CRcount"].ToString(),
                            CScount = dr["CScount"].ToString(),
                            OPcount = dr["OPcount"].ToString(),
                            POScount = dr["POScount"].ToString()

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
                dm.TraceService("GetInvoiceCountsServiceJobs  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetInvoiceCountsServiceJobs ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetAllAssetsCounts([FromForm] PlannedSJIn inputParams)
        {
            dm.TraceService("GetAllAssetsCounts STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            DataTable dt = dm.loadList("SelServiceJobAssetscounts", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<AssetCountsSJOut> listHeader = new List<AssetCountsSJOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new AssetCountsSJOut
                        {

                            TotalVisited = dr["TotalVisited"].ToString(),
                            Tracked = dr["Tracked"].ToString(),
                            NotTracked = dr["NotTracked"].ToString(),


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
                dm.TraceService("GetAllAssetsCounts  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAllAssetsCounts ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetAssetsAddRemoveReqCounts([FromForm] PlannedSJIn inputParams)
        {
            dm.TraceService("GetAssetsAddRemoveReqCounts STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelAssetAddRemoveReqCount", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<AssetAddRemvReqCountsSJOut> listHeader = new List<AssetAddRemvReqCountsSJOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new AssetAddRemvReqCountsSJOut
                        {

                            AddreqCount = dr["AddreqCount"].ToString(),
                            RemReqCount = dr["RemReqCount"].ToString(),
                            TotalServiceRequest = dr["TotalServiceRequest"].ToString(),
                            OpenServiceRequest = dr["OpenServiceRequest"].ToString(),
                            ResolvedServiceRequest = dr["ResolvedServiceRequest"].ToString()


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
                dm.TraceService("GetAssetsAddRemoveReqCounts  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAssetsAddRemoveReqCounts ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetServiceRequestsDetail([FromForm] KPIServiceReqstDetailIN inputParams)
        {
            dm.TraceService("KPIGetServiceRequestsDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status = inputParams.Status == null ? "0" : inputParams.Status;
            string reqCode = inputParams.ReqCode == null ? "0" : inputParams.ReqCode;
            string[] ar = { reqCode };
            DataTable dt = dm.loadList("SelServiceRequestsDetail", "sp_KPIServices", Status.ToString(), ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIServiceReqstDetailOUT> listHeader = new List<KPIServiceReqstDetailOUT>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new KPIServiceReqstDetailOUT
                        {
                            RespondedDate = dr["RespondedDate"].ToString(),
                            snr_TroubleShoots = dr["snr_TroubleShoots"].ToString(),
                            AssignedToDate = dr["AssignedToDate"].ToString(),
                            AssignedRotCode = dr["AssignedRotCode"].ToString(),
                            AssignedRotName = dr["AssignedRotName"].ToString(),
                            AssignedDate = dr["AssignedDate"].ToString(),



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
                dm.TraceService("KPIGetServiceRequestsDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceRequestsDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetServiceJobDetails([FromForm] KPISJDetailIN inputParams)
        {
            dm.TraceService("KPIGetServiceJobDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string JobID = inputParams.JobID == null ? "0" : inputParams.JobID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceJobDetails", "sp_KPIServices", JobID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];

            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<KPISJDetailOut> listHeader = new List<KPISJDetailOut>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<KPISJDetailData> listDetail = new List<KPISJDetailData>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {
                            listDetail.Add(new KPISJDetailData
                            {
                                Question = drDetails["sjd_Question"].ToString(),
                                Answer = drDetails["sjd_Answer"].ToString(),
                                Type = drDetails["sjd_Type"].ToString(),
                                Remarks = drDetails["sjd_Remarks"].ToString(),

                            });

                        }

                        listHeader.Add(new KPISJDetailOut
                        {

                            AssignedRotCode = dr["AssignedRotCode"].ToString(),
                            AssignedRotName = dr["AssignedRotName"].ToString(),
                            AssignedDate = dr["AssignedDate"].ToString(),
                            AssignedToDate = dr["AssignedToDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            sjh_ActionType = dr["sjh_ActionType"].ToString(),

                            JobDetails = listDetail,
                            ActionTakenDate = dr["ModifiedDate"].ToString(),
                            ActualStartTime = dr["sjh_ActualStartTime"].ToString(),
                            ActualEndTime = dr["sjh_ActualEndTime"].ToString()
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
                JSONString = "KPIGetServiceJobDetails - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceJobDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceJobHeader([FromForm] KPIServiceFieldsIn inputParams)
        {
            dm.TraceService("KPIGetServiceJobHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ServiceReqID = inputParams.ServiceReqID == null ? "0" : inputParams.ServiceReqID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceJobHeader", "sp_KPIServices", ServiceReqID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<KPIServiceFieldsOut> listHeader = new List<KPIServiceFieldsOut>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<KPIServiceJobHeader> listDetail = new List<KPIServiceJobHeader>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {




                            listDetail.Add(new KPIServiceJobHeader
                            {
                                JobID = drDetails["sjh_ID"].ToString(),
                                JobNumber = drDetails["sjh_Number"].ToString(),
                                Asset = drDetails["ast_Name"].ToString(),
                                Date = drDetails["CreatedDate"].ToString(),
                                JobStatus = drDetails["JobStatus"].ToString(),

                            });

                        }

                        listHeader.Add(new KPIServiceFieldsOut
                        {

                            Asset = dr["ast_Name"].ToString(),
                            Date = dr["Date"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            ServiceReqRemarks = dr["snr_Remarks"].ToString(),
                            ServiceReqImages = dr["snr_Image"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            Status = dr["Status"].ToString(),

                            JobHeader = listDetail,
                            RespondedDate = dr["ModifiedDate"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
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
                JSONString = "KPIGetServiceJobHeader - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceJobHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetRequiredParts([FromForm] KPIReqPartsIn inputParams)
        {
            dm.TraceService("KPIGetRequiredParts STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string JobID = inputParams.JobID == null ? "0" : inputParams.JobID;

            DataTable dt = dm.loadList("SelectRequiredParts", "sp_KPIServices", JobID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIReqPartsOut> listHeader = new List<KPIReqPartsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIReqPartsOut
                        {


                            ServiceJobID = dr["srp_sjh_ID"].ToString(),
                            prd_ID = dr["srp_prd_ID"].ToString(),
                            UOM = dr["srp_UOM"].ToString(),
                            Qty = dr["srp_Qty"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            Remarks = dr["sjh_ReqPartsRemarks"].ToString(),
                            CategoryID = dr["cat_ID"].ToString(),
                            BrandID = dr["brd_ID"].ToString(),
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
                dm.TraceService("KPIGetRequiredParts  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetRequiredParts ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceJobInvoice([FromForm] KPIServiceJobInvoiceIN inputParams)
        {
            dm.TraceService("KPIGetServiceJobInvoice STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string JobID = inputParams.JobID == null ? "0" : inputParams.JobID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceJobInvoiceDetails", "sp_KPIServices", JobID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<KPIServiceJobInvoiceOUT> listHeader = new List<KPIServiceJobInvoiceOUT>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<KPIServiceJobInvoiceItems> listDetail = new List<KPIServiceJobInvoiceItems>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {

                            if (drDetails["sld_sal_ID"].ToString() == dr["sal_ID"].ToString())
                            {



                                listDetail.Add(new KPIServiceJobInvoiceItems
                                {
                                    prdID = drDetails["prd_ID"].ToString(),
                                    prdCode = drDetails["prd_Code"].ToString(),
                                    prdName = drDetails["prd_Name"].ToString(),
                                    categoryID = drDetails["cat_ID"].ToString(),
                                    BrandID = drDetails["brd_ID"].ToString(),
                                    IsChargable = drDetails["prd_Chargable"].ToString(),
                                    UOM = drDetails["UOM"].ToString(),
                                    Qty = drDetails["Qty"].ToString(),
                                    Price = drDetails["Price"].ToString(),
                                    LineTotal = drDetails["LineTotal"].ToString(),
                                    Discount = drDetails["Discount"].ToString(),

                                });

                            }
                        }

                        listHeader.Add(new KPIServiceJobInvoiceOUT
                        {

                            VAT = dr["VAT"].ToString(),
                            GrandTotal = dr["inv_GrandTotal"].ToString(),
                            SubTotal = dr["SubTotal"].ToString(),

                            ItemData = listDetail,
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
                JSONString = "KPIGetServiceJobInvoice - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceJobInvoice ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceFields([FromForm] KPIServiceFieldsIn inputParams)
        {
            dm.TraceService("KPIGetServiceFields STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ServiceReqID = inputParams.ServiceReqID == null ? "0" : inputParams.ServiceReqID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceFields", "sp_KPIServices", ServiceReqID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<KPIServiceFieldsOut> listHeader = new List<KPIServiceFieldsOut>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<KPIServiceJobHeader> listDetail = new List<KPIServiceJobHeader>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {




                            listDetail.Add(new KPIServiceJobHeader
                            {
                                JobID = drDetails["sjh_ID"].ToString(),
                                JobNumber = drDetails["sjh_Number"].ToString(),
                                Asset = drDetails["ast_Name"].ToString(),
                                Date = drDetails["CreatedDate"].ToString(),
                                JobStatus = drDetails["JobStatus"].ToString(),
                                ActualStartTime = drDetails["sjh_ActualStartTime"].ToString(),
                                ActualEndtime = drDetails["sjh_ActualEndTime"].ToString(),
                                ScheduledDate = drDetails["sjh_ScheduledDate"].ToString(),
                                Duration = drDetails["sjh_Duration"].ToString(),
                                EstimateStartTime = drDetails["sjh_ScheduledStartTime"].ToString(),
                                EstimateEndTime = drDetails["sjh_EstimatedEndTime"].ToString(),
                                ActualEndTime = drDetails["sjh_ActualEndTime"].ToString(),
                                ActualDuration = drDetails["sjh_ActualDuration"].ToString(),

                            });

                        }

                        listHeader.Add(new KPIServiceFieldsOut
                        {

                            Asset = dr["ast_Name"].ToString(),
                            Date = dr["Date"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            ServiceReqRemarks = dr["snr_Remarks"].ToString(),
                            ServiceReqImages = dr["snr_Image"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            Status = dr["Status"].ToString(),

                            JobHeader = listDetail,
                            RespondedDate = dr["ModifiedDate"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
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
                JSONString = "KPIGetServiceFields - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceFields ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceJobs([FromForm] KPIServiceJobIn inputParams)
        {
            dm.TraceService("KPIGetServiceJobs STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelServiceJob", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIServiceJobOut> listHeader = new List<KPIServiceJobOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

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


                        listHeader.Add(new KPIServiceJobOut
                        {
                            ReqID = dr["snr_ID"].ToString(),
                            AssetID = dr["asc_ID"].ToString(),
                            AssetName = dr["asc_Name"].ToString(),
                            AssetCode = dr["ast_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            ComplaintTypeID = dr["cst_ID"].ToString(),

                            RequestID = dr["snr_Code"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,
                            Remarks = dr["snr_Remarks"].ToString(),
                            ComplaintTitle = dr["snr_Complaint"].ToString(),
                            jobID = dr["sjh_ID"].ToString(),
                            jobNumber = dr["sjh_Number"].ToString(),
                            SerialNo = dr["atm_Code"].ToString(),
                            ScheduledDate = dr["sjh_ScheduledDate"].ToString(),
                            cuscode = dr["cus_Code"].ToString(),
                            cusname = dr["cus_Name"].ToString(),
                            JobStatus = dr["ScheduledDate_Status"].ToString(),
                            Duration = dr["sjh_Duration"].ToString(),
                            ActualDuration = dr["sjh_ActualDuration"].ToString(),
                            ExpectedStartTime = dr["sjh_ScheduledStartTime"].ToString(),
                            ActualStartTime = dr["sjh_ActualStartTime"].ToString()



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
                dm.TraceService("KPIGetServiceJobs  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceJobs ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string SelectCusAssetTrackingHeader([FromForm] KPICusAssetTrackingIn inputParams)
        {
            dm.TraceService("KPISelectCusAssetTrackingHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;


            string[] arr = { };
            DataTable dt = dm.loadList("SelCusAssetTrackingHeader", "sp_KPIServices", udp_ID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPICusAssetTrackingOut> listHeader = new List<KPICusAssetTrackingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPICusAssetTrackingOut
                        {

                            AssetTrackingID = dr["cas_ID"].ToString(),
                            udp_ID = dr["cas_udp_ID"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),

                            atm_ID = dr["atm_ID"].ToString(),
                            atm_Code = dr["atm_Code"].ToString(),
                            atm_Name = dr["atm_Name"].ToString(),

                            usr_ID = dr["cas_usr_ID"].ToString(),
                            usr_Code = dr["usr_Code"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),

                            cus_ID = dr["cas_cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            cus_NameArabic = dr["cus_NameArabic"].ToString(),

                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_ArabicName = dr["rot_ArabicName"].ToString(),

                            ast_ID = dr["ast_ID"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),

                            Image = dr["cas_Image"].ToString(),
                            Temp = dr["cas_Temp"].ToString(),
                            Remarks = dr["cas_Remarks"].ToString(),
                            Images = dr["CreatedDate"].ToString(),
                            //snr_Remarks = dr["snr_Remarks"].ToString(),
                            cas_asn_ID = dr["cas_asn_ID"].ToString(),

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
                dm.TraceService("KPISelectCusAssetTrackingHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPISelectCusAssetTrackingHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectCusAssetTrackingDetail([FromForm] KPICusAssetTrackingDetailIn inputParams)
        {
            dm.TraceService("KPISelectCusAssetTrackingDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string AssetTrackingID = inputParams.AssetTrackingID == null ? "0" : inputParams.AssetTrackingID;

            DataTable dt = dm.loadList("SelCusAssetTrackingDetail", "sp_KPIServices", AssetTrackingID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPICusAssetTrackingDetailOut> listHeader = new List<KPICusAssetTrackingDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPICusAssetTrackingDetailOut
                        {

                            AssetTrackingID = dr["ctd_cas_ID"].ToString(),
                            AssetTrackDetailID = dr["ctd_ID"].ToString(),
                            Question = dr["ctd_Question"].ToString(),
                            Answer = dr["ctd_Answer"].ToString(),
                            Type = dr["ctd_Type"].ToString(),
                            Remarks = dr["ctd_Remarks"].ToString(),
                            qst_Name = dr["qst_Name"].ToString(),
                            Options = dr["Options"].ToString(),
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
                dm.TraceService("KPISelectCusAssetTrackingDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPISelectCusAssetTrackingDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectAssetAddRequest([FromForm] KPICusAssetAddReqIn inputParams)
        {
            dm.TraceService("KPISelectAssetAddRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

            string[] arr = { };
            DataTable dt = dm.loadList("SelAssetAddRequest", "sp_KPIServices", udp_ID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPICusAssetAddReqOut> listHeader = new List<KPICusAssetAddReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPICusAssetAddReqOut
                        {

                            AssetAddReqID = dr["aah_ID"].ToString(),
                            aah_slno = dr["aah_slno"].ToString(),
                            aah_Name = dr["aah_Name"].ToString(),
                            aah_rsn_ID = dr["aah_rsn_ID"].ToString(),
                            aah_Remarks = dr["aah_Remarks"].ToString(),
                            aah_img = dr["aah_img"].ToString(),
                            udp_ID = dr["aah_udp_ID"].ToString(),
                            cus_ID = dr["aah_cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            ast_ID = dr["ast_ID"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            rsn_ID = dr["aah_rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
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
                dm.TraceService("KPISelectAssetAddRequest  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPISelectAssetAddRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectAssetRemoveRequest([FromForm] KPICusAssetRemoveReqIn inputParams)
        {
            dm.TraceService("KPISelectAssetRemoveRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string backendurl = "https://uom-sfa.dev-ts.online/";


            string[] arr = { };
            DataTable dt = dm.loadList("SelAssetRemoveRequest", "sp_KPIServices", udp_ID);
            // string img = dt.Rows[0]["arq_img"].ToString();
            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPICusAssetRemoveReqOut> listHeader = new List<KPICusAssetRemoveReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string image = "";
                        if (dr["arq_img"].ToString().Equals(backendurl))
                        {
                            image = "";
                        }
                        else
                        {
                            image = dr["arq_img"].ToString();
                        }
                        listHeader.Add(new KPICusAssetRemoveReqOut
                        {
                            AssetRemoveReqID = dr["arq_ID"].ToString(),
                            arq_asc_ID = dr["arq_asc_ID"].ToString(),
                            arq_Remarks = dr["arq_Remarks"].ToString(),
                            arq_img = image,
                            atm_Code = dr["atm_Code"].ToString(),
                            atm_Name = dr["atm_Name"].ToString(),
                            cus_ID = dr["arq_cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            ast_ID = dr["arq_ast_ID"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            rsn_ID = dr["arq_rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            rsn_Type = dr["rsn_Type"].ToString(),
                            Status = dr["arq_Status"].ToString(),
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
                dm.TraceService("KPISelectAssetRemoveRequest  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPISelectAssetRemoveRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceRequests([FromForm] KPIServiceRequestIn inputParams)
        {
            dm.TraceService("KPIGetServiceRequests STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelServiceRequests", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIServiceRequestOut> listHeader = new List<KPIServiceRequestOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new KPIServiceRequestOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetRefName = dr["asc_Name"].ToString(),
                            SerialNo = dr["asc_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            AssetMandColumns = dr["asc_MandColumns"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,
                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            AssignedRotID = dr["rot_ID"].ToString(),
                            AssignedRotCode = dr["rot_Code"].ToString(),
                            AssignedRotName = dr["rot_Name"].ToString(),
                            AssignedDate = "",
                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            cuscode = dr["cus_Code"].ToString(),
                            cusname = dr["cus_Name"].ToString()

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
                dm.TraceService("KPIGetServiceRequests  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceRequests ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetOpenServiceRequests([FromForm] KPIServiceRequestIn inputParams)
        {
            dm.TraceService("KPIGetServiceRequests STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelOpenServiceRequests", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIServiceRequestOut> listHeader = new List<KPIServiceRequestOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new KPIServiceRequestOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetRefName = dr["asc_Name"].ToString(),
                            SerialNo = dr["asc_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            AssetMandColumns = dr["asc_MandColumns"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,
                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            AssignedRotID = dr["rot_ID"].ToString(),
                            AssignedRotCode = dr["rot_Code"].ToString(),
                            AssignedRotName = dr["rot_Name"].ToString(),
                            AssignedDate = "",
                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            cuscode = dr["cus_Code"].ToString(),
                            cusname = dr["cus_Name"].ToString()

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
                dm.TraceService("KPIGetServiceRequests  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceRequests ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetClosedServiceRequests([FromForm] KPIServiceRequestIn inputParams)
        {
            dm.TraceService("KPIGetServiceRequests STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelResolvedServiceRequests", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIServiceRequestOut> listHeader = new List<KPIServiceRequestOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new KPIServiceRequestOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetRefName = dr["asc_Name"].ToString(),
                            SerialNo = dr["asc_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            AssetMandColumns = dr["asc_MandColumns"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,
                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            AssignedRotID = dr["rot_ID"].ToString(),
                            AssignedRotCode = dr["rot_Code"].ToString(),
                            AssignedRotName = dr["rot_Name"].ToString(),
                            AssignedDate = "",
                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            cuscode = dr["cus_Code"].ToString(),
                            cusname = dr["cus_Name"].ToString(),
                            CompletedOn = dr["CompletedOn"].ToString()

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
                dm.TraceService("KPIGetServiceRequests  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("KPIGetServiceRequests ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetAssetTypesOfServiceRequests([FromForm] SRAssetTypeIN inputParams)
        {
            dm.TraceService("GetAssetTypesOfServiceRequests STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string cusID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] ar = { cusID.ToString() };

            DataTable dt = dm.loadList("SelAssetTypesInServiceRequest", "sp_KPIServices", rotID.ToString(), ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<SRAssetTypeOut> listHeader = new List<SRAssetTypeOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["ast_Planogram"].ToString();
                        if (img != "")
                        {
                            string[] arr = (dr["ast_Planogram"].ToString().Replace("../../", "")).Split(',');

                            for (int i = 0; i < arr.Length; i++)
                            {
                                imag = url + arr[i];
                            }

                        }

                        listHeader.Add(new SRAssetTypeOut
                        {

                            Planogram = imag,

                            AssetTypeName = dr["ast_Name"].ToString(),

                            AssetTypeID = dr["ast_ID"].ToString(),

                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Count = dr["serviceCount"].ToString()

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
                dm.TraceService("GetAssetTypesOfServiceRequests  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAssetTypesOfServiceRequests ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceRequestsByAssetType([FromForm] SRByAssetTypeIN inputParams)
        {
            dm.TraceService("GetServiceRequestsByAssetType STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string AssetTypeID = inputParams.AssetTypeID == null ? "0" : inputParams.AssetTypeID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arr = { cus_ID.ToString(), AssetTypeID.ToString() };

            DataTable dt = dm.loadList("SelServiceRequestsByAssetType", "sp_KPIServices", rotID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<SRByAssetTypeOut> listHeader = new List<SRByAssetTypeOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new SRByAssetTypeOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetRefName = dr["asc_Name"].ToString(),

                            cus_ID = dr["cus_ID"].ToString(),

                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,



                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),

                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            JobCount = dr["JobCount"].ToString()
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
                dm.TraceService("GetServiceRequestsByAssetType  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceRequestsByAssetType ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetPlannedServiceJobs([FromForm] KPIServiceRequestIn inputParams)
        {
            dm.TraceService("GetPlannedServiceJobs STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelPlannedServiceRequests", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIPlannedServiceRequestOut> listHeader = new List<KPIPlannedServiceRequestOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new KPIPlannedServiceRequestOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetRefName = dr["asc_Name"].ToString(),
                            SerialNo = dr["asc_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),

                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,
                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),

                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),

                            ComplaintType = dr["cst_Name"].ToString(),
                            cuscode = dr["cus_Code"].ToString(),
                            cusname = dr["cus_Name"].ToString(),
                            Type = dr["Type"].ToString(),
                            JobID = dr["sjh_ID"].ToString(),
                            JobNumber = dr["sjh_Number"].ToString(),
                            ScheduledDate = dr["sjh_ScheduledDate"].ToString(),
                            Duration = dr["sjh_Duration"].ToString(),
                            EstimateStartTime = dr["sjh_ScheduledStartTime"].ToString(),
                            EstimateEndTime = dr["sjh_EstimatedEndTime"].ToString(),
                            ActualStartTime = dr["sjh_ActualStartTime"].ToString(),
                            ActualEndTime = dr["sjh_ActualEndTime"].ToString(),
                            ActualDuration = dr["sjh_ActualDuration"].ToString()

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
                dm.TraceService("GetPlannedServiceJobs  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetPlannedServiceJobs ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetActualServiceJobs([FromForm] KPIServiceRequestIn inputParams)
        {
            dm.TraceService("GetActualServiceJobs STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelActualServiceRequests", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIPlannedServiceRequestOut> listHeader = new List<KPIPlannedServiceRequestOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new KPIPlannedServiceRequestOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetRefName = dr["asc_Name"].ToString(),
                            SerialNo = dr["asc_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),

                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,
                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),

                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),

                            ComplaintType = dr["cst_Name"].ToString(),
                            cuscode = dr["cus_Code"].ToString(),
                            cusname = dr["cus_Name"].ToString(),
                            Type = dr["Type"].ToString(),
                            JobID = dr["sjh_ID"].ToString(),
                            JobNumber = dr["sjh_Number"].ToString(),
                            ScheduledDate = dr["sjh_ScheduledDate"].ToString(),
                            Duration = dr["sjh_Duration"].ToString(),
                            EstimateStartTime = dr["sjh_ScheduledStartTime"].ToString(),
                            EstimateEndTime = dr["sjh_EstimatedEndTime"].ToString(),
                            ActualStartTime = dr["sjh_ActualStartTime"].ToString(),
                            ActualEndTime = dr["sjh_ActualEndTime"].ToString(),
                            ActualDuration = dr["sjh_ActualEndTime"].ToString()

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
                dm.TraceService("GetActualServiceJobs  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetActualServiceJobs ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string SelectCusVisitedAndNotTrackedAsset([FromForm] KPICusAssetTrackingIn inputParams)
        {
            dm.TraceService("SelectCusVisitedAndNotTrackedAsset STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { };
            DataTable dt = dm.loadList("SelCusVisitedAndNotTrackedAsset", "sp_KPIServices", udp_ID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIVisitNotTrackingOut> listHeader = new List<KPIVisitNotTrackingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imgs = dr["cas_Image"].ToString();

                        if (imgs != "")
                        {
                            string[] ar = (dr["cas_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imgs = imgs + "," + url + ar[i];
                                }
                                else
                                {
                                    imgs = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new KPIVisitNotTrackingOut
                        {


                            atm_ID = dr["atm_ID"].ToString(),
                            atm_Code = dr["atm_Code"].ToString(),
                            atm_Name = dr["atm_Name"].ToString(),


                            cus_ID = dr["cas_cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            cus_NameArabic = dr["cus_NameArabic"].ToString(),

                            ast_ID = dr["ast_ID"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            Type = dr["Type"].ToString(),

                            aah_Name = dr["aah_Name"].ToString(),
                            aah_rsn_ID = dr["aah_rsn_ID"].ToString(),
                            aah_Remarks = dr["aah_Remarks"].ToString(),
                            aah_img = imgs,
                            Planogram = url + dr["ast_Planogram"].ToString()


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
                dm.TraceService("SelectCusVisitedAndNotTrackedAsset  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectCusVisitedAndNotTrackedAsset ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetAllServiceJobsCount([FromForm] AllCountSJIn inputParams)
        {
            dm.TraceService("GetAllServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelAllServiceJobCount", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<AllCountSJOut> listHeader = new List<AllCountSJOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new AllCountSJOut
                        {
                            All = dr["AllReq"].ToString(),
                            Open = dr["OpenReq"].ToString(),
                            Resolved = dr["RSReq"].ToString(),
                            ActionTaken = dr["ATReq"].ToString(),


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
                dm.TraceService("GetAllServiceJobsCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAllServiceJobsCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetSurveyDetail([FromForm] KPISurveyDetailIn inputParams)
        {
            dm.TraceService("GetSurveyDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string SurveyHeaderID = inputParams.SurveyHeaderID == null ? "0" : inputParams.SurveyHeaderID;

            DataTable dt = dm.loadList("SelectSurveyDetail", "sp_KPIServices", SurveyHeaderID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPISurveyDetailOut> listHeader = new List<KPISurveyDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPISurveyDetailOut
                        {

                            SurveyHeaderID = dr["srd_srh_ID"].ToString(),
                            SurveyDetailID = dr["srd_ID"].ToString(),
                            Question = dr["srd_Question"].ToString(),
                            Answer = dr["srd_Answer"].ToString(),
                            Type = dr["srd_Type"].ToString(),
                            Remarks = dr["srd_Remarks"].ToString(),
                            qst_Name = dr["qst_Name"].ToString(),
                            Options = dr["Options"].ToString(),
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
                dm.TraceService("GetSurveyDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetSurveyDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetSalesOrders([FromForm] SalesOrderInKPI inputParams)
        {
            dm.TraceService("GetSalesOrders STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.type, inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelSalesorders", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<SalesOrderOut> listHeader = new List<SalesOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new SalesOrderOut
                        {
                            ord_id = dr["ord_id"].ToString(),
                            OrdNO = dr["OrderID"].ToString(),
                            cus_ID = dr["ord_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            cusArName = dr["cus_NameArabic"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            Status = dr["Status"].ToString(),
                            Total = dr["ord_SubTotal_WODiscount"].ToString(),
                            ord_Discount = dr["ord_Discount"].ToString(),
                            ord_SubTotal = dr["ord_SubTotal"].ToString(),
                            ord_VATAmount = dr["ord_VAT"].ToString(),
                            ord_GrandTotal = dr["ord_GrandTotal"].ToString(),
                            Void = dr["Void"].ToString(),
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
                dm.TraceService("GetSalesOrders  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetSalesOrders ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetSalesOrderDetail([FromForm] OrderDetailIn inputParams)
        {
            dm.TraceService("GetSalesOrderDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string ord_ID = inputParams.ord_ID == null ? "0" : inputParams.ord_ID;

                DataTable dtorders = dm.loadList("SelTotalOrderDetail", "sp_KPIServices", ord_ID.ToString());

                if (dtorders.Rows.Count > 0)
                {
                    List<SalesOrderDetailOut> listItems = new List<SalesOrderDetailOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new SalesOrderDetailOut
                        {
                            odd_ID = dr["odd_ID"].ToString(),
                            odd_ord_ID = dr["odd_ord_ID"].ToString(),
                            prd_ID = dr["odd_itm_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            odd_HigherUOM = dr["odd_HigherUOM"].ToString(),
                            odd_LowerUOM = dr["odd_LowerUOM"].ToString(),
                            odd_HigherQty = dr["odd_HigherQty"].ToString(),
                            odd_LowerQty = dr["odd_LowerQty"].ToString(),
                            odd_HigherPrice = dr["odd_HigherPrice"].ToString(),
                            odd_LowerPrice = dr["odd_LowerPrice"].ToString(),
                            odd_Price = dr["odd_Price"].ToString(),
                            odd_TotalQty = dr["odd_TotalQty"].ToString(),
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
                dm.TraceService("GetSalesOrderDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetSalesOrderDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }




        // InvRec

        public string GetInvRecHeader([FromForm] InvRecheaderIn inputParams)
        {
            dm.TraceService("GetInvRecHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelInvRecHeader", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<InvRecheaderOut> listHeader = new List<InvRecheaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new InvRecheaderOut
                        {
                            ID = dr["irh_id"].ToString(),
                            TransID = dr["irh_TransID"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
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
                dm.TraceService("GetInvRecHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetInvRecHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetInvReconfirmDetail([FromForm] InvRecDetIn inputParams)
        {
            dm.TraceService("GetInvReconfirmDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string ord_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtorders = dm.loadList("SelInvRecDetail", "sp_KPIServices", ord_ID.ToString());

                if (dtorders.Rows.Count > 0)
                {

                    List<InvRecDetOutKPI> listItems = new List<InvRecDetOutKPI>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new InvRecDetOutKPI
                        {
                            prd_ID = dr["prd_id"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            SysHigherQty = dr["ird_HigherQty"].ToString(),
                            SysLowerQty = dr["ird_LowerQty"].ToString(),
                            SysLowerUOM = dr["ird_LowerUOM"].ToString(),
                            SysHigherUOM = dr["ird_HigherUOM"].ToString(),
                            PhyHigherQty = dr["ird_PhysicalHQty"].ToString(),
                            PhyHigherUOM = dr["ird_PhysicalHUOM"].ToString(),
                            PhyLowerQty = dr["ird_PhysicalLQty"].ToString(),
                            PhyLowerUOM = dr["ird_PhysicalLUOM"].ToString(),
                            ExHigherQty = dr["ird_DescHQty"].ToString(),
                            ExHigherUOM = dr["ird_DescHUOM"].ToString(),
                            ExLowerQty = dr["ird_DescLQty"].ToString(),
                            ExLowerUOM = dr["ird_DescLUOM"].ToString(),
                            CatID = dr["prd_cat_ID"].ToString(),
                            SubCatID = dr["prd_sct_ID"].ToString(),
                            IsNEwlyAdded = dr["ird_Isvanstockitms"].ToString(),
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
                dm.TraceService("GetInvReconfirmDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetInvReconfirmDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string SelectInvoiceDetailTypeWise([FromForm] InvoiceFooterInKPI inputParams)
        {
            dm.TraceService("SelectInvoiceDetailTypeWise STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                DataTable dtLoadIn = dm.loadList("InvoiceDetailFooter", "sp_KPIServices", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<invoiceTypeFooter> listItems = new List<invoiceTypeFooter>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new invoiceTypeFooter
                        {
                            SalesDiscount = dr["SalesDiscount"].ToString(),
                            SalesTotal = dr["SalesTotal"].ToString(),
                            SalesValue = dr["SalesValue"].ToString(),
                            SalesVAT = dr["SalesVAT"].ToString(),
                            GRDiscount = dr["GRDiscount"].ToString(),
                            GRTotal = dr["GRTotal"].ToString(),
                            GRValue = dr["GRValue"].ToString(),
                            GRVAT = dr["GRVAT"].ToString(),
                            BRDiscount = dr["BRDiscount"].ToString(),
                            BRTotal = dr["BRTotal"].ToString(),
                            BRValue = dr["BRValue"].ToString(),
                            BRVAT = dr["BRVAT"].ToString(),
                            FCDiscount = dr["FCDiscount"].ToString(),
                            FCTotal = dr["FCTotal"].ToString(),
                            FCValue = dr["FCValue"].ToString(),
                            FCVAT = dr["FCVAT"].ToString(),
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
                dm.TraceService(" SelectInvoiceDetailTypeWise Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectInvoiceDetailTypeWise ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string SelectInvoiceDetail([FromForm] InvoiceDetailInKPI inputParams)
        {
            dm.TraceService("SelectInvoiceDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                DataTable dtLoadIn = dm.loadList("InvoiceDetail", "sp_KPIServices", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<InvoiceDetailOutKPI> listItems = new List<InvoiceDetailOutKPI>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new InvoiceDetailOutKPI
                        {
                            prd_ID = dr["ind_itm_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            transcationtype = dr["sld_TransType"].ToString(),
                            LowerUOM = dr["LowerUOM"].ToString(),
                            HigherUOM = dr["HigherUOM"].ToString(),
                            LowerQty = dr["sld_LowerQty"].ToString(),
                            HigherQty = dr["sld_HigherQty"].ToString(),
                            Amount = dr["sld_GrandTotal"].ToString(),
                            returnType = dr["sld_ReturnType"].ToString(),
                            huomPrice = dr["sld_HigherPrice"].ToString(),
                            luomPrice = dr["sld_LowerPrice"].ToString(),
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
                dm.TraceService(" SelectInvoiceDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectInvoiceDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string GetInvoiceHeaderKPI([FromForm] SelInvoiceIn inputParams)
        {
            dm.TraceService("GetInvoiceHeaderKPI STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");


            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;
            string[] arr = { inputParams.rotID == null ? "0" : inputParams.rotID };
            DataTable dtreturn = dm.loadList("SelInvoiceHeader", "sp_KPIServices", udpID.ToString(), arr);
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<SelInvoiceOut> listHeader = new List<SelInvoiceOut>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {
                        string imag = "";
                        string img = dr["sal_Attachment"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["sal_Attachment"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i == 0)
                                {
                                    imag = url + ar[i];
                                }
                                else
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                            }
                        }
                        else
                        {
                            imag = "";
                        }

                        // sign

                        string Sign = "";
                        string img1 = dr["sal_Signature"].ToString();
                        if (img1 != "" && img1 != "NULL")
                        {
                            string[] ar2 = (dr["sal_Signature"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar2.Length; i++)
                            {
                                //if (i > 0)
                                //{
                                    Sign = Sign + url + ar2[i];
                                //}
                                
                            }

                        }
                        else
                        {
                            Sign = "";
                        }
                        listHeader.Add(new SelInvoiceOut
                        {

                            ID = dr["sal_ID"].ToString(),
                            InvoiceNo = dr["sal_txn_ID"].ToString(),
                            cusCode = dr["cus_Code"].ToString(),
                            cusName = dr["cus_Name"].ToString(),
                            cusArName = dr["cus_NameArabic"].ToString(),
                            Attachment = imag,
                            Signature = Sign,
                            InvAmount = dr["inv_GrandTotal"].ToString(),
                            PaymentType = dr["inv_PayMode"].ToString(),
                            Balance = dr["Balance"].ToString(),
                            PaidAmount = dr["inv_TotalPaidAmount"].ToString(),
                            Status = dr["Status"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            transType= dr["sld_TransType"].ToString(),

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
                JSONString = "GetInvoiceHeaderKPI - " + ex.Message.ToString();
            }
            dm.TraceService("GetInvoiceHeaderKPI ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }


        ///-----AR------------------------------------------
        ///



        public string SelectARHeader([FromForm] ARHeaderInKPI inputParams)
        {
            dm.TraceService("SelectARHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string udpid = inputParams.udpId == null ? "0" : inputParams.udpId;
                string rotid = inputParams.rotID == null ? "0" : inputParams.rotID;
                string paytype = inputParams.PayType == null ? "0" : inputParams.PayType; 

                string url = ConfigurationManager.AppSettings.Get("BackendUrl");

                string[] arr = { UserID, rotid ,paytype};
                DataTable dtAR = dm.loadList("SelARHeader", "sp_KPIServices", udpid.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<ARHeaderOutKPI> listItems = new List<ARHeaderOutKPI>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        string imag = "";
                        string img = dr["arh_Attachment"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["arh_Attachment"].ToString().Replace("../", "")).Split(',');

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

                        // sign

                        string Sign = "";
                        string img1 = dr["arh_Signature"].ToString();
                        if (img1 != "")
                        {
                            string[] ar = (dr["arh_Signature"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    Sign = Sign + "," + url + ar[i];
                                }
                                else
                                {
                                    Sign = url + ar[i];
                                }
                            }

                        }

                        string Rec = "";
                        string img2 = dr["arh_RecieptImg"].ToString();
                        if (img2 != "")
                        {
                            string[] ar = (dr["arh_RecieptImg"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    Rec = Rec + "," + url + ar[i];
                                }
                                else
                                {
                                    Rec = url + ar[i];
                                }
                            }

                        }
                        listItems.Add(new ARHeaderOutKPI
                        {

                            arh_ID = dr["arh_ID"].ToString(),
                            arh_ARNumber = dr["arh_ARNumber"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            cusArName = dr["cus_NameArabic"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
                            arh_PayMode = dr["arh_PayMode"].ToString(),
                            arh_PayType = dr["arh_PayType"].ToString(),
                            arh_CollectedAmount = dr["arh_CollectedAmount"].ToString(),
                            arh_BalanceAmount = dr["arh_BalanceAmount"].ToString(),
                            arp_ChequeNo = dr["arp_ChequeNo"].ToString(),
                            arp_ChequeDate = dr["arp_ChequeDate"].ToString(),
                            RecImage = Rec,
                            Sign = Sign,
                            Attachment = imag,
                            bankName = dr["bnk_Name"].ToString(),
                            Remark = dr["arh_Remarks"].ToString(),
                            Status = dr["Status"].ToString(),
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
                dm.TraceService("SelectARHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectARHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectARDetail([FromForm] ARDetailInKPI inputParams)
        {
            dm.TraceService("SelectARDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string arh_ID = inputParams.arh_ID == null ? "0" : inputParams.arh_ID;

                DataTable dt = dm.loadList("SelARDetail", "sp_KPIServices", arh_ID.ToString());

                if (dt.Rows.Count > 0)
                {
                    List<ARDetailOutKPI> listItems = new List<ARDetailOutKPI>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new ARDetailOutKPI
                        {
                            ard_ID = dr["ard_ID"].ToString(),
                            ard_arh_ID = dr["ard_arh_ID"].ToString(),
                            ard_Amount = dr["ard_Amount"].ToString(),
                            ard_PDC_Amount = dr["ard_PDC_Amount"].ToString(),
                            InvoiceID = dr["InvoiceID"].ToString(),
                            InvoicedOn = dr["InvoicedOn"].ToString(),
                            InvoiceAmount = dr["InvoiceAmount"].ToString(),
                            AmountPaid = dr["AmountPaid"].ToString(),
                            Balance= dr["Balance"].ToString(),

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
                dm.TraceService("SelectARDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectARDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        //----Adv Payment


        public string GetAdvPaymentKPI([FromForm] SelAdvInKPI inputParams)
        {
            dm.TraceService("GetAdvPaymentKPI STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");


            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;
            string[] arr = { inputParams.rotID == null ? "0" : inputParams.rotID };
            DataTable dtreturn = dm.loadList("SelAdvPayment", "sp_KPIServices", udpID.ToString(), arr);
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<SelAdvOutKPI> listHeader = new List<SelAdvOutKPI>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {


                        // sign

                        string Sign = "";
                        string img1 = dr["adp_Signature"].ToString();
                        if (img1 != "")
                        {
                            string[] ar = (dr["adp_Signature"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    Sign = Sign + "," + url + ar[i];
                                }
                                else
                                {
                                    Sign = url + ar[i];
                                }
                            }

                        }

                        string Rec = "";
                        string img2 = dr["adp_RecieptImg"].ToString();
                        if (img2 != "")
                        {
                            string[] ar = (dr["adp_RecieptImg"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    Rec = Rec + "," + url + ar[i];
                                }
                                else
                                {
                                    Rec = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new SelAdvOutKPI
                        {


                            ID = dr["adp_ID"].ToString(),
                            TransID = dr["adp_Number"].ToString(),
                            cusCode = dr["cus_Code"].ToString(),
                            cusName = dr["cus_Name"].ToString(),
                            cusArName = dr["cus_NameArabic"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
                            PaymentMode = dr["adp_PaymentMode"].ToString(),
                            PaymentType = dr["adp_PayMode"].ToString(),
                            adp_ChequeNo = dr["adp_ChequeNo"].ToString(),
                            adp_ChequeDate = dr["adp_ChequeDate"].ToString(),
                            RecImage = Rec,
                            Sign = Sign,
                            Remark = dr["adp_Remarks"].ToString(),
                            Status = dr["Status"].ToString(),
                            BankName = dr["Bank"].ToString(),
                            CollectedAmount = dr["Collected"].ToString(),

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
                JSONString = "GetAdvPaymentKPI - " + ex.Message.ToString();
            }
            dm.TraceService("GetAdvPaymentKPI ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }


        //----------------------Counts



        public string SelSalesSummeryCount([FromForm] SelInvoiceCountIN inputParams)
        {
            dm.TraceService("SelSalesSummeryCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string arh_ID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string[] ar = { arh_ID };

                DataTable dt = dm.loadList("DashboardSalesCounts", "sp_KPIServices", rotID.ToString(),ar);

                if (dt.Rows.Count > 0)
                {
                    List<SelINvCountOut> listItems = new List<SelINvCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SelINvCountOut
                        {
                            TotInvoice = dr["TotalInvoiceCount"].ToString(),
                            TotInvAmt = dr["TotalInvAmount"].ToString(),
                            SalesInvoice = dr["SalesCount"].ToString(),
                            GD = dr["GoodReturn"].ToString(),
                            BD = dr["BadReturn"].ToString(),
                            FOC = dr["FCCount"].ToString(),
                            NoOfInvHC = dr["HC_Count"].ToString(),
                            NoOfInvCR = dr["CR_Count"].ToString(),
                            NoOfInvPOS = dr["POS_Count"].ToString(),
                            NoOfInvOP = dr["OP_Count"].ToString(),
                            HCAmt = dr["HC_Amount"].ToString(),
                            POSAmount = dr["POS_Amount"].ToString(),
                            OPAmt = dr["OP_Count"].ToString(),
                            CRAmt = dr["CR_Amount"].ToString(),

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
                dm.TraceService("SelSalesSummeryCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelSalesSummeryCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }



        public string SelARCount([FromForm] ARCOuntIn inputParams)
        {
            dm.TraceService("SelARCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                string arh_ID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string[] ar = { arh_ID };

                DataTable dt = dm.loadList("DashboardARCount", "sp_KPIServices", rotID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<ARCOuntOut> listItems = new List<ARCOuntOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new ARCOuntOut
                        {
                           
                            HCAmt = dr["AR_HC_Amount"].ToString(),
                            POSAmount = dr["AR_POS_Amount"].ToString(),
                            OPAmt = dr["AR_OP_Amount"].ToString(),
                            CHAmt = dr["AR_Chq_Amount"].ToString(),
                            TotCollection = dr["TotalARAmount"].ToString(),
                            HCCount = dr["AR_HC_Count"].ToString(),
                            OPCount = dr["AR_OP_Count"].ToString(),
                            POSCount = dr["AR_POS_Count"].ToString(),
                            CHCount = dr["AR_Chq_Count"].ToString(),
                            totCount = dr["TotalArCount"].ToString(),

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
                dm.TraceService("SelARCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelARCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }



        public string SelOutstandingCount([FromForm] ARCOuntIn inputParams)
        {
            dm.TraceService("SelOutstandingCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string arh_ID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string[] ar = { arh_ID };

                DataTable dt = dm.loadList("SelOutstandingCountSplits", "sp_KPIServices", rotID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<SelOutstandingOut> listItems = new List<SelOutstandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SelOutstandingOut
                        {

                            Due = dr["Due"].ToString(),
                            TotalDue = dr["DueAmt"].ToString(),
                            OverDue = dr["OverDue"].ToString(),
                            TotalOverDue = dr["OverDueAmt"].ToString(),
                            OutStandingAmt = dr["OutstandingAmt"].ToString(),
                            TotalOutstanding = dr["TotOutstanding"].ToString(),

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
                dm.TraceService("SelOutstandingCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelOutstandingCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string SelAdvPayCount([FromForm] AdvCountIn inputParams)
        {
            dm.TraceService("SelAdvPayCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string arh_ID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string[] ar = { arh_ID };

                DataTable dt = dm.loadList("DashboardAdvanceCount", "sp_KPIServices", rotID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<AdvCountOut> listItems = new List<AdvCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new AdvCountOut
                        {
                            TotalAdvPayCount = dr["TotalApCount"].ToString(),
                            TotAmt = dr["TotalAPAmount"].ToString(),
                            NoOfHC = dr["AP_HC_Count"].ToString(),
                            NoOfCH = dr["AP_Chq_Count"].ToString(),
                            NoOfPOS = dr["AP_POS_Count"].ToString(),
                            NoOfOP = dr["AP_OP_Count"].ToString(),
                            HCAmt = dr["AP_HC_Amount"].ToString(),
                            POSAmount = dr["AP_POS_Amount"].ToString(),
                            OPAmt = dr["AP_OP_Amount"].ToString(),
                            CHAmt = dr["AP_Chq_Amount"].ToString(),

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
                dm.TraceService("SelAdvPayCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelAdvPayCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelVisitCount([FromForm] SelVisitIN inputParams)
        {
            dm.TraceService("SelVisitCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                string udpId = inputParams.udpId == null ? "0" : inputParams.udpId;

                string[] ar = { udpId };

                DataTable dt = dm.loadList("VisitCounts", "sp_KPIServices", rotID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<SelVisitOut> listItems = new List<SelVisitOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SelVisitOut
                        {
                            totplannedvisit = dr["PlannedVisits"].ToString(),
                            Totalactualvisits = dr["ActualViist"].ToString(),
                            TotProductive = dr["totalProductive"].ToString(),
                            totNonProductive = dr["totalNonProductive"].ToString(),
                            planned = dr["Planned"].ToString(),
                            pending = dr["Pending"].ToString(),
                            ProductivePlanned = dr["ScheduledProdVisits"].ToString(),
                            ProductiveUnplanned = dr["UnscheduledProdVisits"].ToString(),
                            NonProdPlanned = dr["ScheduledNonProdVisits"].ToString(),
                            NonProdUnplanned = dr["UnscheduledNonProdVisits"].ToString(),
                            unplanned = dr["Unplanned"].ToString(),
                            visited = dr["Visited"].ToString(),

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
                dm.TraceService("SelVisitCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelVisitCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string SelInvandVAntoVanCount([FromForm] SelVisitIN inputParams)
        {
            dm.TraceService("SelInvandVAntoVanCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                string udpId = inputParams.udpId == null ? "0" : inputParams.udpId;
                string date = DateTime.Parse(inputParams.date.ToString()).ToString("yyyyMMdd");
                string[] ar = { date, udpId };

                DataTable dt = dm.loadList("SelInventoryandVantoVan", "sp_KPIServices", rotID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<InvRecandV2VOut> listItems = new List<InvRecandV2VOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new InvRecandV2VOut
                        {
                            IvnRecCount = dr["InvRecCount"].ToString(),
                            LoadTransferOut = dr["TransIn"].ToString(),
                            LodTransferIn = dr["TransOut"].ToString(),

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
                dm.TraceService("SelInvandVAntoVanCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelInvandVAntoVanCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string SelDeliveryCount([FromForm] DelCountIn inputParams)
        {
            dm.TraceService("SelDeliveryCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                string udpId = inputParams.udpId == null ? "0" : inputParams.udpId;
                string date = DateTime.Parse(inputParams.date.ToString()).ToString("yyyyMMdd");

                string[] ar = { date, udpId };

                DataTable dt = dm.loadList("SelDeliveryCount", "sp_KPIServices", rotID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<DelCountOut> listItems = new List<DelCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new DelCountOut
                        {
                            plannedDel = dr["planned"].ToString(),
                            NotDel = dr["ND"].ToString(),
                            TotalDel = dr["Delivered"].ToString(),
                            TotalPD = dr["PD"].ToString(),

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
                dm.TraceService("SelDeliveryCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelDeliveryCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string GetTransferIn([FromForm] InvRecheaderIn inputParams)
        {
            dm.TraceService("GetTransferIn STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelTransferIn", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<SelTransferOut> listHeader = new List<SelTransferOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new SelTransferOut
                        {
                            ID = dr["vvh_ID"].ToString(),
                            TransID = dr["vvh_TransID"].ToString(),
                            RouteCode = dr["rot_code"].ToString(),
                            RouteName = dr["rot_Name"].ToString(),
                            Status = dr["status"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),

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
                dm.TraceService("GetTransferIn  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetTransferIn ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetTransferOut([FromForm] InvRecheaderIn inputParams)
        {
            dm.TraceService("GetTransferOut STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelTransferOut", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<SelTransferOut> listHeader = new List<SelTransferOut>();
                    foreach (DataRow dr in dt.Rows)

                    {
                        listHeader.Add(new SelTransferOut
                        {
                            ID = dr["vvh_ID"].ToString(),
                            TransID = dr["vvh_TransID"].ToString(),
                            RouteCode = dr["rot_code"].ToString(),
                            RouteName = dr["rot_Name"].ToString(),
                            Status = dr["status"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
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
                dm.TraceService("GetTransferOut  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetTransferOut ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetTransferDetail([FromForm] SelTransDetailIn inputParams)
        {
            dm.TraceService("GetTransferDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string ord_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtorders = dm.loadList("SelTransferDet", "sp_KPIServices", ord_ID.ToString());

                if (dtorders.Rows.Count > 0)
                {

                    List<SelTransferDetailOut> listItems = new List<SelTransferDetailOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new SelTransferDetailOut
                        {
                            Prd_Name = dr["prd_Name"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            turnouthqty = dr["vvd_HQty"].ToString(),
                            turnouthuom = dr["vvd_HUOM"].ToString(),
                            turnoutlqty = dr["vvd_LQty"].ToString(),
                            turnoutluom = dr["vvd_LUOM"].ToString(),
                            Confhqty = dr["vvd_ConfirmHQty"].ToString(),
                            conflqty = dr["vvd_ConfirmLQty"].ToString(),
                            udjhqty = dr["AdjHQty"].ToString(),
                            udjlqty = dr["AdjLQty"].ToString(),
                            CatId = dr["prd_cat_ID"].ToString(),
                            SubCatId = dr["prd_sct_ID"].ToString(),
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
                dm.TraceService("GetTransferDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetTransferDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string SelOrderCount([FromForm] SelVisitIN inputParams)
        {
            dm.TraceService("SelOrderCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string arh_ID = inputParams.udpId == null ? "0" : inputParams.udpId;
                string[] ar = { arh_ID };

                DataTable dt = dm.loadList("SelOrderCount", "sp_KPIServices", rotID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<OrderCountOut> listItems = new List<OrderCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new OrderCountOut
                        {
                            SalesOrderCount = dr["Order"].ToString(),
                            QuotationCount = dr["Quotation"].ToString(),

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
                dm.TraceService("SelOrderCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelOrderCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


    }


}