using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
                            ActualDuration= dr["sjh_ActualDuration"].ToString() ,
                            ExpectedStartTime= dr["sjh_ScheduledStartTime"].ToString(),
                            ActualStartTime= dr["sjh_ActualStartTime"].ToString()



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
                            Planogram=url+ dr["ast_Planogram"].ToString()


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

    }
}