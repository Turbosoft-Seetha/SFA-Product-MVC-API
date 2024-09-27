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
    public class KPIMerchandisingController : Controller

    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Mvc.HttpPost]

        public string GetInventoryMonitoringCount([FromForm] MerchInvMonitoringIn inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] ar = { udpID.ToString() };
            DataTable dt = dm.loadList("SelectInventoryMonitoring", "sp_KPIServices", rotID.ToString(), ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<MerchInvMonitoringOut> listHeader = new List<MerchInvMonitoringOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new MerchInvMonitoringOut
                        {
                            TotalOutOfStoke = dr["TotalOutOfStoke"].ToString(),
                            OutOfStokeItems = dr["OutOfStokeItems"].ToString(),
                            OutOfStokeCustomers = dr["OutOfStokeCustomers"].ToString(),

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


        public string GetActivityManagementCount([FromForm] MerchActivityManagementIn inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelectActivityManagement", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<MerchActivityManagementOut> listHeader = new List<MerchActivityManagementOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new MerchActivityManagementOut
                        {
                            AssignedTasks = dr["AssignedTasks"].ToString(),
                            AssignedSurvay = dr["AssignedSurvay"].ToString(),
                            NewDisplayAgreementsCount = dr["NewDisplayAgreementsCount"].ToString(),
                            OpenCustomerActivityCount = dr["OpenCustomerActivityCount"].ToString(),

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




        public string GetActivityManagementCompletedCount([FromForm] MerchActivityManagementComIn inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udp_Id = inputParams.udp_Id == null ? "0" : inputParams.udp_Id;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { udp_Id.ToString() };
            DataTable dt = dm.loadList("SelectActivityManagementCompleted", "sp_KPIServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<MerchActivityManagementComOut> listHeader = new List<MerchActivityManagementComOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new MerchActivityManagementComOut
                        {
                            CompletedTasks = dr["CompletedTasks"].ToString(),
                            CompletedSurvay = dr["CompletedSurvay"].ToString(),
                            ActiveDisplayAgreementsCount = dr["ActiveDisplayAgreementsCount"].ToString(),
                            CompletedCustomerActivityCount = dr["CompletedCustomerActivityCount"].ToString(),

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


        public string GetCustomerServiceCount([FromForm] MerchCusServicesIn inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelectCustomerServices", "sp_KPIServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<MerchCusServicesOut> listHeader = new List<MerchCusServicesOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new MerchCusServicesOut
                        {
                            CusNewRequestCount = dr["CusNewRequestCount"].ToString(),
                            CreditNoteReqCount = dr["CreditNoteReqCount"].ToString(),
                            DisputeReqCount = dr["DisputeReqCount"].ToString(),
                            ReturnReqCount = dr["ReturnReqCount"].ToString(),

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



        public string GetCustomerServiceCompletedCount([FromForm] MerchCusServicesComIn inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arr = { udp_ID.ToString() };
            DataTable dt = dm.loadList("SelectCustomerCompletedServices", "sp_KPIServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<MerchCusServicesComOut> listHeader = new List<MerchCusServicesComOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new MerchCusServicesComOut
                        {
                            CusRepondedRequestCount = dr["CusRepondedRequestCount"].ToString(),
                            ApprovedCreditNoteReq = dr["ApprovedCreditNoteReq"].ToString(),
                            ApprovedDisputeReq = dr["ApprovedDisputeReq"].ToString(),
                            ApprovedReturnReq = dr["ApprovedReturnReq"].ToString(),

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

        public string GetReturnReq([FromForm] MerchCusServicesIn inputParams)
        {
            dm.TraceService("GetReturnReq STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { FromDate.ToString(), ToDate.ToString() };
            DataTable dt = dm.loadList("GetReturnReq", "sp_MerchandisingWebServices", rotID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<RetReqOut> listHeader = new List<RetReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["rrh_Signature"].ToString();

                        string imags = "";
                        string imgs = dr["rrh_Attachment"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["rrh_Signature"].ToString().Replace("../", "")).Split(',');

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

                        if (imgs != "")
                        {
                            string[] ar = (dr["rrh_Attachment"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imags = imags + "," + url + ar[i];
                                }
                                else
                                {
                                    imags = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new RetReqOut
                        {
                            Request_ID = dr["rrh_ID"].ToString(),
                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            ReturnType = dr["rrh_ReturnType"].ToString(),
                            InvID= dr["inv_ID"].ToString(),
                            CusID= dr["rrh_cus_ID"].ToString(),
                            Status= dr["Status"].ToString(),
                            cus_Code = dr["cus_code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            SubTotal = dr["rrh_SubTotal"].ToString(),
                            Vat = dr["rrh_VatPerc"].ToString(),
                            Total = dr["rrh_Total"].ToString(),
                            Signature = imag,
                            Attachment = imags,
                            Remark = dr["rrh_Remarks"].ToString(),
                            Time = dr["CreatedTime"].ToString(),

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
                dm.TraceService("GetReturnReq  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReturnReq ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }



        public string GetCompletedReturnReq([FromForm] MerchCusServicesComIn inputParams)
        {
            dm.TraceService("GetReturnReq STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udpID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { udpID.ToString(), FromDate.ToString(), ToDate.ToString() };
            DataTable dt = dm.loadList("GetReturnReqApproved", "sp_MerchandisingWebServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<RetReqComOut> listHeader = new List<RetReqComOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";
                        string img = dr["rrh_Signature"].ToString();

                        string imags = "";
                        string imgs = dr["rrh_Attachment"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["rrh_Signature"].ToString().Replace("../", "")).Split(',');

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

                        if (imgs != "")
                        {
                            string[] ar = (dr["rrh_Attachment"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imags = imags + "," + url + ar[i];
                                }
                                else
                                {
                                    imags = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new RetReqComOut
                        {
                            Request_ID = dr["rrh_ID"].ToString(),
                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            ReturnType = dr["rrh_ReturnType"].ToString(),
                            InvID = dr["inv_ID"].ToString(),
                            CusID = dr["rrh_cus_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            cus_Code = dr["cus_code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            SubTotal = dr["rrh_SubTotal"].ToString(),
                            Vat = dr["rrh_VatPerc"].ToString(),
                            Total = dr["rrh_Total"].ToString(),
                            Signature = imag,
                            Attachment = imags,
                            Remark = dr["rrh_Remarks"].ToString(),
                            Time = dr["CreatedTime"].ToString(),

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
                dm.TraceService("GetReturnReq  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReturnReq ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetTasks([FromForm] MerchCusServicesIn inputParams)
        {
            dm.TraceService("GetTasks STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("GetTasks", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<TasksOut> listHeader = new List<TasksOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";
                        string img = dr["cst_ReferenceImage"].ToString();

                        string imags = "";
                        string imgs = dr["cst_CapturedImage"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["cst_ReferenceImage"].ToString().Replace("../", "")).Split(',');

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

                        if (imgs != "")
                        {
                            string[] ar = (dr["cst_CapturedImage"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imags = imags + "," + url + ar[i];
                                }
                                else
                                {
                                    imags = url + ar[i];
                                }
                            }

                        }

                        listHeader.Add(new TasksOut
                        {
                            cst_ID = dr["cst_ID"].ToString(),
                            cst_brd_ID = dr["cst_brd_ID"].ToString(),
                            cst_cus_ID = dr["cst_cus_ID"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            DueDate = dr["DueDate"].ToString(),
                            cst_Name = dr["cst_Name"].ToString(),
                            cst_Status = dr["cst_Status"].ToString(),
                            cst_cus_Name= dr["cus_Name"].ToString(),
                            cst_brd_Name= dr["brd_name"].ToString(),
                            cst_Desc= dr["cst_Desc"].ToString(),
                            cst_ReferenceImage= imag,
                            Image= imags,
                            Remarks= dr["cst_UserRemarks"].ToString(),

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
                dm.TraceService("GetTasks  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetTasks ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetCompletedTasks([FromForm] MerchCusServicesIn inputParams)
        {
            dm.TraceService("GetCompletedTasks STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arr = { udpID.ToString() };

            DataTable dt = dm.loadList("GetCompletedTasks", "sp_MerchandisingWebServices", rotID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<TasksOut> listHeader = new List<TasksOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";
                        string img = dr["cst_ReferenceImage"].ToString();

                        string imags = "";
                        string imgs = dr["cst_CapturedImage"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["cst_ReferenceImage"].ToString().Replace("../", "")).Split(',');

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

                        if (imgs != "")
                        {
                            string[] ar = (dr["cst_CapturedImage"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imags = imags + "," + url + ar[i];
                                }
                                else
                                {
                                    imags = url + ar[i];
                                }
                            }

                        }

                        listHeader.Add(new TasksOut
                        {
                            cst_ID = dr["cst_ID"].ToString(),
                            cst_brd_ID = dr["cst_brd_ID"].ToString(),
                            cst_cus_ID = dr["cst_cus_ID"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            DueDate = dr["DueDate"].ToString(),
                            cst_Name = dr["cst_Name"].ToString(),
                            cst_Status = dr["cst_Status"].ToString(),
                            cst_cus_Name = dr["cus_Name"].ToString(),
                            cst_brd_Name = dr["brd_name"].ToString(),
                            cst_Desc = dr["cst_Desc"].ToString(),
                            cst_ReferenceImage = imag,
                            Image = imags,
                            Remarks = dr["cst_UserRemarks"].ToString(),

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
                dm.TraceService("GetCompletedTasks  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCompletedTasks ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }

    }
}