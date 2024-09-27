using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class ActionHistoryController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
      
        public string SelectCusAssetTrackingHeader([FromForm] CusAssetTrackingIn inputParams)
        {
            dm.TraceService("SelectCusAssetTrackingHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            
            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;

            string[] arr = { cus_ID ,cse_ID};
            DataTable dt = dm.loadList("SelCusAssetTrackingHeader", "sp_ActionHistory", udp_ID , arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CusAssetTrackingOut> listHeader = new List<CusAssetTrackingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusAssetTrackingOut
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
                dm.TraceService("SelectCusAssetTrackingHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectCusAssetTrackingHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectCusAssetTrackingDetail([FromForm] CusAssetTrackingDetailIn inputParams)
        {
            dm.TraceService("SelectCusAssetTrackingDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string AssetTrackingID = inputParams.AssetTrackingID == null ? "0" : inputParams.AssetTrackingID;
           
            DataTable dt = dm.loadList("SelCusAssetTrackingDetail", "sp_ActionHistory", AssetTrackingID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CusAssetTrackingDetailOut> listHeader = new List<CusAssetTrackingDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusAssetTrackingDetailOut
                        {
                            
                            AssetTrackingID = dr["ctd_cas_ID"].ToString(),
                            AssetTrackDetailID = dr["ctd_ID"].ToString(),
                            Question = dr["ctd_Question"].ToString(),
                            Answer = dr["ctd_Answer"].ToString(),
                            Type = dr["ctd_Type"].ToString(),
                            Remarks = dr["ctd_Remarks"].ToString(),                           
                            qst_Name = dr["qst_Name"].ToString(),                         
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
                dm.TraceService("SelectCusAssetTrackingDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectCusAssetTrackingDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectAssetAddRequest([FromForm] CusAssetAddReqIn inputParams)
        {
            dm.TraceService("SelectAssetAddRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

            string[] arr = { cus_ID };
            DataTable dt = dm.loadList("SelAssetAddRequest", "sp_ActionHistory", udp_ID, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CusAssetAddReqOut> listHeader = new List<CusAssetAddReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusAssetAddReqOut
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
                dm.TraceService("SelectAssetAddRequest  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectAssetAddRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectAssetRemoveRequest([FromForm] CusAssetRemoveReqIn inputParams)
        {
            dm.TraceService("SelectAssetRemoveRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

            string[] arr = { cus_ID };
            DataTable dt = dm.loadList("SelAssetRemoveRequest", "sp_ActionHistory", udp_ID, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CusAssetRemoveReqOut> listHeader = new List<CusAssetRemoveReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusAssetRemoveReqOut
                        {                          
                            AssetRemoveReqID = dr["arq_ID"].ToString(),                           
                            arq_asc_ID = dr["arq_asc_ID"].ToString(),
                            arq_Remarks = dr["arq_Remarks"].ToString(),
                            arq_img = dr["arq_img"].ToString(),
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
                dm.TraceService("SelectAssetRemoveRequest  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectAssetRemoveRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectServiceRequestHeader([FromForm] ServiceReqIn inputParams)
        {
            dm.TraceService("SelectServiceRequestHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

            string[] arr = { cus_ID };
            DataTable dt = dm.loadList("SelServiceRequestHeader", "sp_ActionHistory", udp_ID, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceReqOut> listHeader = new List<ServiceReqOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ServiceReqOut
                        {
                            ServiceReqID = dr["snr_ID"].ToString(),
                            snr_Code = dr["snr_Code"].ToString(),                            
                            ast_ID = dr["ast_ID"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            atm_ID = dr["atm_ID"].ToString(),
                            atm_Code = dr["atm_Code"].ToString(),
                            atm_Name = dr["atm_Name"].ToString(),
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
                dm.TraceService("SelectServiceRequestHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectServiceRequestHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectServiceRequestDetail([FromForm] ServiceReqDetailIn inputParams)
        {
            dm.TraceService("SelectServiceRequestDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ServiceReqID = inputParams.ServiceReqID == null ? "0" : inputParams.ServiceReqID;

            DataTable dt = dm.loadList("SelServiceRequestDetail", "sp_ActionHistory", ServiceReqID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceReqDetailOut> listHeader = new List<ServiceReqDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ServiceReqDetailOut
                        {  
                            ServiceReqID = dr["snr_ID"].ToString(),
                            snr_Code = dr["snr_Code"].ToString(),
                            snr_Complaint = dr["snr_Complaint"].ToString(),
                            snr_Remarks = dr["snr_Remarks"].ToString(),
                            ast_ID = dr["ast_ID"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            atm_ID = dr["atm_ID"].ToString(),
                            atm_Code = dr["atm_Code"].ToString(),
                            atm_Name = dr["atm_Name"].ToString(),
                            cst_Name = dr["cst_Name"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            snr_Image = dr["snr_Image"].ToString(),
                            ModifiedDate = dr["ModifiedDate"].ToString(),
                            CreatedDate = dr["Date"].ToString(),
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
                dm.TraceService("SelectServiceRequestDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectServiceRequestDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectServiceJobHeader([FromForm] ServiceJobHeadIn inputParams)
        {
            dm.TraceService("SelectServiceJobHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

            string[] arr = { cus_ID };
            DataTable dt = dm.loadList("SelServiceJobHeader", "sp_ActionHistory", udp_ID, arr);
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceJobHeadOut> listHeader = new List<ServiceJobHeadOut>();
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
                        listHeader.Add(new ServiceJobHeadOut
                        {
                            ServiceJobID = dr["sjh_ID"].ToString(),
                            sjh_Number = dr["sjh_Number"].ToString(),
                            ServiceReqID = dr["snr_ID"].ToString(),
                            snr_Code = dr["snr_Code"].ToString(),
                            ast_ID = dr["ast_ID"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            atm_ID = dr["atm_ID"].ToString(),
                            atm_Code = dr["atm_Code"].ToString(),
                            atm_Name = dr["atm_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            CusName = dr["cus_Name"].ToString(),
                            CusCode = dr["cus_Code"].ToString(),
                            ComplaintTypeID = dr["snr_cst_ID"].ToString(),
                            ComplaintTitle= dr["snr_Complaint"].ToString(),
                            ComplaintType= dr["cst_Name"].ToString(),
                            ReqComments= dr["snr_Remarks"].ToString(),
                            ReqImages= imag

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
                dm.TraceService("SelectServiceJobHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectServiceJobHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectServiceJobDetail([FromForm] ServiceJobDetIn inputParams)
        {
            dm.TraceService("SelectServiceJobDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ServiceJobID = inputParams.ServiceJobID == null ? "0" : inputParams.ServiceJobID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceJobDetails", "sp_ServiceRequest", ServiceJobID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<ServiceJobDetOut> listHeader = new List<ServiceJobDetOut>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<ServiceJobDetData> listDetail = new List<ServiceJobDetData>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {




                            listDetail.Add(new ServiceJobDetData
                            {
                                Question = drDetails["sjd_Question"].ToString(),
                                Answer = drDetails["sjd_Answer"].ToString(),
                                Type = drDetails["sjd_Type"].ToString(),
                                Remarks = drDetails["sjd_Remarks"].ToString(),

                            });

                        }

                        listHeader.Add(new ServiceJobDetOut
                        {

                            AssignedRotCode = dr["AssignedRotCode"].ToString(),
                            AssignedRotName = dr["AssignedRotName"].ToString(),
                            AssignedDate = dr["AssignedDate"].ToString(),
                            AssignedToDate = dr["AssignedToDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            sjh_ActionType = dr["sjh_ActionType"].ToString(),

                            JobDetails = listDetail,
                            ActionTakenDate = dr["ModifiedDate"].ToString(),
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
                JSONString = "SelectServiceJobDetails - " + ex.Message.ToString();
            }

            dm.TraceService("SelectServiceJobDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetReturnRequestHeader([FromForm] ReturnRequestHeaderIn inputParams)
        {
            dm.TraceService("GetReturnRequestHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { cus_ID, cse_ID };
            DataTable dtreturn = dm.loadList("SelReturnRequestHeader", "sp_ActionHistory", udp_ID.ToString(),arr);         

            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetRtnRequestHeaderOut> listHeader = new List<GetRtnRequestHeaderOut>();
                    foreach (DataRow dr in dtreturn.Rows)
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

                        listHeader.Add(new GetRtnRequestHeaderOut
                        {

                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            date = dr["CreatedDate"].ToString(),
                            cus_ID = dr["rrh_cus_ID"].ToString(),
                            Request_ID = dr["rrh_ID"].ToString(),
                            inv_ID = dr["rrh_inv_ID"].ToString(),
                            ReturnType = dr["rrh_ReturnType"].ToString(),
                            cus_Code= dr["cus_code"].ToString(),
                            cus_Name= dr["cus_Name"].ToString(),
                            SubTotal = dr["rrh_SubTotal"].ToString(),
                            Vat = dr["rrh_VatPerc"].ToString(),
                            Total = dr["rrh_Total"].ToString(),
                            Signature=imag,
                            Attachment=imags,
                            Remark=dr["rrh_Remarks"].ToString(),
                            Time=dr["CreatedTime"].ToString(),
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
                JSONString = "GetReturnRequestHeader - " + ex.Message.ToString();
            }
            dm.TraceService("GetReturnRequestHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetReturnRequestDetail([FromForm] ReturnRequestDetailIn inputParams)
        {
            dm.TraceService("GetReturnRequestDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");


            string rotID = inputParams.RequestID == null ? "0" : inputParams.RequestID;

            DataTable dtreturn = dm.loadList("SelReturnRequestDetail", "sp_ActionHistory", rotID.ToString());
            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetRtnRequestDetailOut> listHeader = new List<GetRtnRequestDetailOut>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {

                        listHeader.Add(new GetRtnRequestDetailOut
                        {
                            prd_ID = dr["rrd_prd_ID"].ToString(),
                            HUOM = dr["rrd_HUOM"].ToString(),
                            HQty = dr["rrd_HQty"].ToString(),
                            LUOM = dr["rrd_LUOM"].ToString(),
                            LQty = dr["rrd_LQty"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_code = dr["prd_code"].ToString(),
                            prd_LongDesc = dr["prd_ItemLongDesc"].ToString(),
                            prd_cat_id = dr["prd_cat_id"].ToString(),
                            prd_sub_ID = dr["prd_sct_ID"].ToString(),
                            prd_brd_ID = dr["prd_brd_ID"].ToString(),
                            prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            prd_LongDescArabic = dr["prd_ArabicItemLongDesc"].ToString(),
                            prd_Image = dr["prd_Image"].ToString(),
                            HigherPrice = dr["rrd_HigherPrice"].ToString(),
                            LowerPrice = dr["rrd_LowerPrice"].ToString(),
                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            inv_ID = dr["rrh_inv_ID"].ToString(),
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
                JSONString = "GetReturnRequestDetail - " + ex.Message.ToString();
            }
            dm.TraceService("GetReturnRequestDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetDisputeReqHeaderData([FromForm] DisputeNoteHeaderIn inputParams)
        {
            dm.TraceService("GetDisputeReqHeaderData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;

            string[] arr = { cus_ID, cse_ID };
            DataTable dtreturn = dm.loadList("SelDisputeNoteHeader", "sp_ActionHistory", udp_ID.ToString(), arr);
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<PendingDisputeReqOut> listHeader = new List<PendingDisputeReqOut>();
                    foreach (DataRow dr in dtreturn.Rows)
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
                        listHeader.Add(new PendingDisputeReqOut
                        {

                            RequestID = dr["drh_ID"].ToString(),
                            RequestNumber = dr["drh_TransID"].ToString(),
                            rot_ID = dr["drh_rot_ID"].ToString(),
                            Type = dr["drh_DisputeType"].ToString(),
                            Image = imag,
                            OtherInfo = dr["drh_OtherInfo"].ToString(),

                            cus_ID = dr["drh_cus_ID"].ToString(),
                            Remark = dr["drh_Remarks"].ToString(),
                            Amount = dr["drh_Amount"].ToString(),
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
                dm.TraceService(ex.Message.ToString());
                JSONString = "GetDisputeReqHeaderData - " + ex.Message.ToString();
            }
            dm.TraceService("GetDisputeReqHeaderData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetDisputeReqDetailData([FromForm] DisputeNoteDetailIn inputParams)
        {
            dm.TraceService("GetDisputeReqDetailData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.RequestID == null ? "0" : inputParams.RequestID;

            DataTable dtreturn = dm.loadList("SelDisputeNoteDetail", "sp_ActionHistory", rotID.ToString());

            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<DisputeNoteDetailOut> listHeader = new List<DisputeNoteDetailOut>();
                    foreach (DataRow drDetails in dtreturn.Rows)
                    {
                        listHeader.Add(new DisputeNoteDetailOut
                        {
                            RequestID = drDetails["drd_drh_ID"].ToString(),
                            InvoiceAmount = drDetails["InvoiceAmount"].ToString(),
                            InvoicedDate = drDetails["InvoicedOn"].ToString(),
                            InvoiceID = drDetails["InvoiceID"].ToString(),
                            balance = drDetails["drd_InvoiceBalance"].ToString(),
                            oid_ID = drDetails["drd_oid_ID"].ToString(),

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
                JSONString = "GetDisputeReqDetailData - " + ex.Message.ToString();
            }
            dm.TraceService("GetDisputeReqDetailData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string SelCreditNoteHeader([FromForm] CreditNoteHeaderIn inputParams)
        {
            dm.TraceService("SelCreditNoteHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;

            string[] arr = { cus_ID ,cse_ID };
            DataTable dt = dm.loadList("SelCreditNoteHeader", "sp_ActionHistory", udp_ID, arr);
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CreditNoteHeaderOut> listHeader = new List<CreditNoteHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CreditNoteHeaderOut
                        {
                            Reqno = dr["cnh_Number"].ToString(),
                            Amount = dr["cnh_Amount"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
                            Status = dr["Status"].ToString(),
                            vat = dr["cnh_VAT"].ToString(),
                            subtotal = dr["cnh_SubTotal"].ToString(),
                            reqID = dr["cnh_ID"].ToString()
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
                dm.TraceService("SelCreditNoteHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }


            dm.TraceService("SelCreditNoteHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCNRDetail([FromForm] CreditNoteDetailIn inputParams)
        {
            try
            {
                // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetCNRDetail Started==========");

                DataTable CI = dm.loadList("SelCrediNoteReqDetail", "sp_ActionHistory", inputParams.reqID.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<CrditNoteDetailOut> listItems = new List<CrditNoteDetailOut>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new CrditNoteDetailOut
                        {
                            invid = dr["cnd_inv_ID"].ToString(),
                            itmid = dr["crd_itm_ID"].ToString(),
                            prdcode = dr["prd_Code"].ToString(),
                            prdname = dr["prd_Name"].ToString(),
                            hqty = dr["crd_HQty"].ToString(),
                            huom = dr["crd_HUOM"].ToString(),
                            lqty = dr["crd_LQty"].ToString(),
                            luom = dr["crd_LUOM"].ToString(),
                            amount = dr["cnd_crd_Amount"].ToString(),
                            cnrimage = dr["crd_Image"].ToString(),
                            rsnid = dr["crd_rsn_ID"].ToString(),
                            invno = dr["sal_number"].ToString()
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
            dm.TraceService("==========GetCNRDetail End==========");
            return JSONString;
        }
    }
}