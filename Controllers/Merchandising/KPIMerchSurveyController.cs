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
    public class KPIMerchSurveyController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Mvc.HttpPost]

        public string GetAssignedSurvey([FromForm] KPIMerchSurveyin inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelectassignedSurvey", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchSurveyOut> listHeader = new List<KPIMerchSurveyOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchSurveyOut
                        {
                            srm_Name = dr["srm_Name"].ToString(),
                            TotalCustomers = dr["TotalCustomers"].ToString(),
                            srm_ID = dr["srm_ID"].ToString()



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
        public string GetAssignedSurveyCustomer([FromForm] KPIMerchSurveyCusin inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string srm_ID = inputParams.srm_ID == null ? "0" : inputParams.srm_ID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { srm_ID };
            DataTable dt = dm.loadList("selectSurveyCustomers", "sp_MerchandisingWebServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchSurveyCusOut> listHeader = new List<KPIMerchSurveyCusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchSurveyCusOut
                        {
                            srm_Name = dr["srm_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            srm_Number = dr["srm_Number"].ToString(),
                            Status = dr["Status"].ToString()


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

        public string ReqCreditNote([FromForm] KPIMerchCreditNotein inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
           
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

           
            DataTable dt = dm.loadList("selectRequestedCreditNote", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchCreditNoteOut> listHeader = new List<KPIMerchCreditNoteOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchCreditNoteOut
                        {
                            cnh_ID = dr["cnh_ID"].ToString(),
                            cnh_Number = dr["cnh_Number"].ToString(),
                            cnh_Amount = dr["cnh_Amount"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            cnh_cus_ID = dr["cnh_cus_ID"].ToString(),
                            cnh_SubTotal = dr["cnh_SubTotal"].ToString(),
                            cnh_VAT = dr["cnh_VAT"].ToString(),


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



        public string CompletedCreditNote([FromForm] KPIMerchCreditNoteComin inputParams)
        {
            dm.TraceService("CompletedCreditNote STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { udp_ID.ToString() };
            DataTable dt = dm.loadList("selectCompletedCreditNote", "sp_MerchandisingWebServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchCreditNoteComOut> listHeader = new List<KPIMerchCreditNoteComOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchCreditNoteComOut
                        {
                            cnh_ID = dr["cnh_ID"].ToString(),
                            cnh_Number = dr["cnh_Number"].ToString(),
                            cnh_Amount = dr["cnh_Amount"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            cnh_cus_ID = dr["cnh_cus_ID"].ToString(),
                            cnh_SubTotal = dr["cnh_SubTotal"].ToString(),
                            cnh_VAT = dr["cnh_VAT"].ToString(),


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
                dm.TraceService("CompletedCreditNote  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CompletedCreditNote ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }



        public string DisputeNoteReq([FromForm] KPIMerchDisputeNotein inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            DataTable dt = dm.loadList("selectRequestedDisputeNote", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchDisputeNoteOut> listHeader = new List<KPIMerchDisputeNoteOut>();
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
                        listHeader.Add(new KPIMerchDisputeNoteOut
                        {
                            drh_TransID = dr["drh_TransID"].ToString(),
                            drh_Amount = dr["drh_Amount"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            drh_OtherInfo = dr["drh_OtherInfo"].ToString(),
                            drh_Remarks = dr["drh_Remarks"].ToString(),
                            drh_Image = imag,
                            DisputeType = dr["DisputeType"].ToString(),
                            drh_cus_ID = dr["drh_cus_ID"].ToString(),
                            drh_ID = dr["drh_ID"].ToString(),


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

        public string DisputeNoteCompleted([FromForm] KPIMerchDisputeNoteComin inputParams)
        {
            dm.TraceService("GetServiceJobsCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arr = { udp_ID.ToString() };

            DataTable dt = dm.loadList("selectCompletedDisputeNote", "sp_MerchandisingWebServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchDisputeNoteComOut> listHeader = new List<KPIMerchDisputeNoteComOut>();
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
                        listHeader.Add(new KPIMerchDisputeNoteComOut
                        {
                            drh_TransID = dr["drh_TransID"].ToString(),
                            drh_Amount = dr["drh_Amount"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            drh_OtherInfo = dr["drh_OtherInfo"].ToString(),
                            drh_Remarks = dr["drh_Remarks"].ToString(),
                            drh_Image = imag,
                            DisputeType = dr["DisputeType"].ToString(),
                            drh_cus_ID = dr["drh_cus_ID"].ToString(),
                            drh_ID = dr["drh_ID"].ToString(),



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

        public string GetCompletedSurvey([FromForm] KPIMerchCompSurveyin inputParams)
        {
            dm.TraceService("GetCompletedSurvey STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { rotID.ToString() };

            DataTable dt = dm.loadList("GetCompletedSurvey", "sp_MerchandisingWebServices", udpID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchCompSurveyOut> listHeader = new List<KPIMerchCompSurveyOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchCompSurveyOut
                        {
                            srm_Name = dr["srm_Name"].ToString(),
                            TotalCustomers = dr["TotalCustomers"].ToString(),
                            srm_ID = dr["srm_ID"].ToString(),
                            Date = dr["CreatedDate"].ToString()



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
                dm.TraceService("GetCompletedSurvey  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCompletedSurvey ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetCompletedSurveyCustomer([FromForm] KPIMerchCompSurveyCusin inputParams)
        {
            dm.TraceService("GetCompletedSurveyCustomer STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string srm_ID = inputParams.srm_ID == null ? "0" : inputParams.srm_ID;
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { srm_ID ,rotID };
            DataTable dt = dm.loadList("GetCompletedSurveyCustomer", "sp_MerchandisingWebServices", udpID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchCompSurveyCusOut> listHeader = new List<KPIMerchCompSurveyCusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchCompSurveyCusOut
                        {
                            srm_Name = dr["srm_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            srm_Number = dr["srm_Number"].ToString(),
                            Status = dr["Status"].ToString(),
                            srh_ID= dr["srh_id"].ToString(),


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
                dm.TraceService("GetCompletedSurveyCustomer  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCompletedSurveyCustomer ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }

        public string CustomerRequest([FromForm] KPIMerchCusReqin inputParams)
        {
            dm.TraceService("CustomerRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            DataTable dt = dm.loadList("selectCustomerRequest", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchCusReqOut> listHeader = new List<KPIMerchCusReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchCusReqOut
                        {
                            req_TransID = dr["req_TransID"].ToString(),
                            req_Code = dr["req_Code"].ToString(),
                            rqt_Name = dr["rqt_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            req_ID= dr["req_ID"].ToString(),
                            cus_ID= dr["req_cus_ID"].ToString()


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
                dm.TraceService("CustomerRequest  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CustomerRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }




        public string RespondedCustomerRequest([FromForm] KPIMerchCusReqResin inputParams)
        {
            dm.TraceService("CustomerRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;


            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { udp_ID.ToString() };
            DataTable dt = dm.loadList("selectCustomerRequestResponded", "sp_MerchandisingWebServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchCusReqResOut> listHeader = new List<KPIMerchCusReqResOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new KPIMerchCusReqResOut
                        {
                            req_TransID = dr["req_TransID"].ToString(),
                            req_Code = dr["req_Code"].ToString(),
                            rqt_Name = dr["rqt_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            req_ID = dr["req_ID"].ToString(),
                            cus_ID = dr["req_cus_ID"].ToString()


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
                dm.TraceService("CustomerRequest  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CustomerRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }

        public string CustomerRequestDetail([FromForm] KPIMerchCusReqDetin inputParams)
        {
            dm.TraceService("CustomerRequestDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.req_ID == null ? "0" : inputParams.req_ID;
            string BackendURL = ConfigurationManager.AppSettings.Get("BackendURL");

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            DataTable dt = dm.loadList("selectCustomerRequestDet", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<KPIMerchCusReqDetOut> listHeader = new List<KPIMerchCusReqDetOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["rei_image"].ToString();

                        string imags = "";
                        string imgs = dr["req_ResponseImage"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["rei_image"].ToString().Replace("../", "")).Split(',');

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
                            string[] ar = (dr["req_ResponseImage"].ToString().Replace("../", "")).Split(',');

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
                        listHeader.Add(new KPIMerchCusReqDetOut
                        {
                            req_Type = dr["rqt_Name"].ToString(),
                            req_Remark = dr["req_Remarks"].ToString(),
                            req_Image = imag,
                            req_Desc= dr["req_Description"].ToString(),
                            resp_Image= imags,
                            res_Type= dr["req_ResponseType"].ToString(),


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
                dm.TraceService("CustomerRequestDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CustomerRequestDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }

        public string GetCompletedCustomerActivity([FromForm] CompCusActin inputParams)
        {
            dm.TraceService("GetCompletedCustomerActivity STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arr = { udpID.ToString() };

            DataTable dt = dm.loadList("GetCompletedCustomerActivity", "sp_MerchandisingWebServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CompCusActOut> listHeader = new List<CompCusActOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CompCusActOut
                        {
                            cah_Code = dr["cah_Code"].ToString(),
                            cah_Name = dr["cah_Name"].ToString(),
                            cah_Description = dr["cah_Description"].ToString(),
                            cah_StartDate = dr["cah_StartDate"].ToString(),
                            cah_EndDate = dr["cah_EndDate"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            TransDate = dr["TransDate"].ToString(),
                            cah_ID = dr["cah_ID"].ToString(),
                            DetailCount = dr["DetailCount"].ToString(),


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
                dm.TraceService("GetCompletedCustomerActivity  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCompletedCustomerActivity ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetOpenCustomerActivity([FromForm] OpenCusActin inputParams)
        {
            dm.TraceService("GetOpenCustomerActivity STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;         
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("GetOpenCustomerActivity", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<OpenCusActOut> listHeader = new List<OpenCusActOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new OpenCusActOut
                        {
                            cah_Code = dr["cah_Code"].ToString(),
                            cah_Name = dr["cah_Name"].ToString(),
                            cah_Description = dr["cah_Description"].ToString(),
                            cah_StartDate = dr["cah_StartDate"].ToString(),
                            cah_EndDate = dr["cah_EndDate"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            TransDate = dr["TransDate"].ToString(),
                            cah_ID = dr["cah_ID"].ToString(),
                            DetailCount = dr["DetailCount"].ToString(),
                            CompletedDetailCount = dr["CompletedDetailCount"].ToString(),

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
                dm.TraceService("GetOpenCustomerActivity  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOpenCustomerActivity ENDED " + DateTime.Now.ToString());
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



        public string GetOpenCustomerActivityDetail([FromForm] OpenCusActDetailin inputParams)
        {
            dm.TraceService("GetOpenCustomerActivity STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Req_ID = inputParams.cad_cah_ID == null ? "0" : inputParams.cad_cah_ID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("GetOpenCustomerActivityDetail", "sp_MerchandisingWebServices", Req_ID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<OpenCusActDetailOut> listHeader = new List<OpenCusActDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";                      
                        string img = dr["cad_ReferenceImage"].ToString();

                       

                        if (img != "")
                        {
                            string[] ar = (dr["cad_ReferenceImage"].ToString().Replace("../", "")).Split(',');

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

                        string imag2 = "";
                        string img2 = dr["cai_CaptureImage"].ToString();



                        if (img2 != "")
                        {
                            string[] ar2 = (dr["cai_CaptureImage"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar2.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag2 = imag2 + "," + url + ar2[i];
                                }
                                else
                                {
                                    imag2 = url + ar2[i];
                                }
                            }

                        }


                        listHeader.Add(new OpenCusActDetailOut
                        {
                            cad_ID = dr["cad_ID"].ToString(),
                            cad_Code = dr["cad_Code"].ToString(),
                            cad_Name = dr["cad_Name"].ToString(),
                            cad_Description = dr["cad_Description"].ToString(),
                            cad_Type = dr["cad_Type"].ToString(),
                            cad_DueDate = dr["cad_DueDate"].ToString(),
                            cad_ReferenceImage = imag,
                            cad_CaptureImage=imag2,
                            cad_Remarks = dr["cad_Remarks"].ToString(),
                            cad_SortOrder = dr["cad_SortOrder"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
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
                dm.TraceService("GetOpenCustomerActivity  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOpenCustomerActivity ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }


        public string GetCompletedCustomerActivityDetail([FromForm] OpenCusActDetailin inputParams)
        {
            dm.TraceService("GetCompletedCustomerActivityDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Req_ID = inputParams.cad_cah_ID == null ? "0" : inputParams.cad_cah_ID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("GetCompletedCustomerActivityDetail", "sp_MerchandisingWebServices", Req_ID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<OpenCusActDetailOut> listHeader = new List<OpenCusActDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";
                        string img = dr["cad_ReferenceImage"].ToString();



                        if (img != "")
                        {
                            string[] ar = (dr["cad_ReferenceImage"].ToString().Replace("../", "")).Split(',');

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

                        string imag2 = "";
                        string img2 = dr["cai_CaptureImage"].ToString();



                        if (img2 != "")
                        {
                            string[] ar2 = (dr["cai_CaptureImage"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar2.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag2 = imag2 + "," + url + ar2[i];
                                }
                                else
                                {
                                    imag2 = url + ar2[i];
                                }
                            }

                        }
                        listHeader.Add(new OpenCusActDetailOut
                        {
                            cad_ID = dr["cad_ID"].ToString(),
                            cad_Code = dr["cad_Code"].ToString(),
                            cad_Name = dr["cad_Name"].ToString(),
                            cad_Description = dr["cad_Description"].ToString(),
                            cad_Type = dr["cad_Type"].ToString(),
                            cad_DueDate = dr["cad_DueDate"].ToString(),
                            cad_ReferenceImage = imag,
                            cad_CaptureImage = imag2,
                            cad_Remarks = dr["cad_Remarks"].ToString(),
                            cad_SortOrder = dr["cad_SortOrder"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            Date= dr["CreatedDate"].ToString(),


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
                dm.TraceService("GetCompletedCustomerActivityDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCompletedCustomerActivityDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }


    }
}