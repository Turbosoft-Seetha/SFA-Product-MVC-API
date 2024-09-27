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
    public class CusServiceController : Controller
    {
        // GET: CusService
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]

        public string SelectCusServiceCount([FromForm] SelectCusServiceCountIN inputParams)
        {
            dm.TraceService("SelectCusServiceCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

            string[] arr = { ToDate.ToString() };
            DataTable dt = dm.loadList("SelectCusServiceCount", "sp_CustomerConnect", FromDate.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SelectCusServiceCountOUT> listHeader = new List<SelectCusServiceCountOUT>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SelectCusServiceCountOUT
                        {
                            ReqCreditNoteReq = dr["ReqCreditNoteReq"].ToString(),
                            ApprovedCreditNoteReq = dr["ApprovedCreditNoteReq"].ToString(),
                            ReqDisputeNoteReq = dr["ReqDisputeNoteReq"].ToString(),
                            ApprovedDisputeNoteReq = dr["ApprovedDisputeNoteReq"].ToString(),
                            ReqReturnRequest = dr["ReqReturnRequest"].ToString(),
                            ApprovedReturnRequest = dr["ApprovedReturnRequest"].ToString(),
                            NewRequest = dr["NewRequest"].ToString(),
                            RespondedReq = dr["RespondedReq"].ToString()               

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
                dm.TraceService("SelectCusServiceCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectCusServiceCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectReqCreditNoteReq([FromForm] SelectReqCreditNoteReqIN inputParams)
        {
            dm.TraceService("SelectReqCreditNoteReq STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };

            DataTable dt = dm.loadList("selectCusReqCreditNote", "sp_CustomerConnect", FromDate.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SelectReqCreditNoteReqOUT> listHeader = new List<SelectReqCreditNoteReqOUT>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SelectReqCreditNoteReqOUT
                        {
                            cnh_ID = dr["cnh_ID"].ToString(),
                            cnh_Number = dr["cnh_Number"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            status = dr["status"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arstatus = dr["Arstatus"].ToString()





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
                dm.TraceService("SelectReqCreditNoteReq  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectReqCreditNoteReq ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectReqDisputeNoteReq([FromForm] SelectReqDisputeNoteReqIN inputParams)
        {
            dm.TraceService("SelectReqDisputeNoteReq STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate; 
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };
            DataTable dt = dm.loadList("selectCusReqDisputeNote", "sp_CustomerConnect", FromDate.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SelectReqDisputeNoteReqout> listHeader = new List<SelectReqDisputeNoteReqout>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SelectReqDisputeNoteReqout
                        {
                            drh_ID = dr["drh_ID"].ToString(),
                            drh_TransID = dr["drh_TransID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            status = dr["status"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arstatus = dr["Arstatus"].ToString(),



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
                dm.TraceService("SelectReqDisputeNoteReq  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectReqDisputeNoteReq ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectReqReturnReq([FromForm] SelectReqReturnReqReqIN inputParams)
        {
            dm.TraceService("SelectReqReturnReqReq STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };

            DataTable dt = dm.loadList("selectCusReqReturnReq", "sp_CustomerConnect", FromDate.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SelectReqReturnReqReqout> listHeader = new List<SelectReqReturnReqReqout>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SelectReqReturnReqReqout
                        {
                            rrh_ID = dr["rrh_ID"].ToString(),
                            rrh_RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            status = dr["status"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arstatus = dr["Arstatus"].ToString()





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
                dm.TraceService("SelectReqReturnReqReq  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectReqReturnReqReq ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string SelectReqNewRequest([FromForm] SelectReqNewRequestIN inputParams)
        {
            dm.TraceService("SelectReqNewRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };

            DataTable dt = dm.loadList("selectCusReqNewRequest", "sp_CustomerConnect", FromDate.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SelectReqNewRequestOUT> listHeader = new List<SelectReqNewRequestOUT>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SelectReqNewRequestOUT
                        {
                            req_ID = dr["req_ID"].ToString(),
                            req_Code = dr["req_Code"].ToString(),
                            req_TransID = dr["req_TransID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            status = dr["status"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arstatus = dr["Arstatus"].ToString()





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
                dm.TraceService("SelectReqNewRequest  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectReqNewRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


    }
}