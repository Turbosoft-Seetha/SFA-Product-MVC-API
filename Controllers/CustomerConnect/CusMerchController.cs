using Microsoft.AspNetCore.Mvc;
using MultipartDataMediaFormatter.Infrastructure;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC_API.Controllers.CustomerConnect
{
    public class CusMerchController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        // OUT OF STOCK STARTS
        public string GetCCOutOfStockCount([FromForm] CCOutOfStockCountIn inputParams)
        {
            dm.TraceService("GetCCOutOfStockCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetCCOutOfStockCount", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCOutOfStockCountOut> listHeader = new List<CCOutOfStockCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCOutOfStockCountOut
                        {

                            ItemCount = dr["OutOfStockItems"].ToString(),
                            CusCount = dr["OutOfStockCustomers"].ToString(),
                            TransCount = dr["OutOfStockCount"].ToString()
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
                dm.TraceService("GetCCOutOfStockCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCOutOfStockCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCOutOfStockItems([FromForm] CCOOSItemsIn inputParams)
        {
            dm.TraceService("GetOutOfStockItems STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };         


            DataTable dt = dm.loadList("GetCCOutOfStockItems", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCOOSItemsOut> listHeader = new List<CCOOSItemsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCOOSItemsOut
                        {
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            osi_ID = dr["osi_ID"].ToString(),
                            cusCount = dr["cusCount"].ToString(),
                            prd_ArName = dr["prd_NameArabic"].ToString(),

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
                dm.TraceService("GetOutOfStockItems  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockItems ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCOutOfStockItemsDetail([FromForm] CCOOSItemsDetIn inputParams)
        {
            dm.TraceService("GetOutOfStockItems STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string osi_ID = inputParams.osi_ID == null ? "0" : inputParams.osi_ID;           

            DataTable dt = dm.loadList("GetCCOutOfStockItemsDetail", "sp_CC_Merchandising_WS", osi_ID.ToString());           

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCOOSItemsDetOut> listHeader = new List<CCOOSItemsDetOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCOOSItemsDetOut
                        {
                            rot_Code = dr["rot_code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_ArName = dr["rot_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString()

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
                dm.TraceService("GetOutOfStockItems  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockItems ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCOutOfStockCustomers([FromForm] CCOOSCusIn inputParams)
        {
            dm.TraceService("GetOutOfStockCustomers STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() }; 

            DataTable dt = dm.loadList("GetCCOutOfStockCustomers", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCOOSCusOut> listHeader = new List<CCOOSCusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCOOSCusOut
                        {                           
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            ProdCount = dr["ProdCount"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString()

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
                dm.TraceService("GetOutOfStockCustomers  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockCustomers ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCOutOfStockCustomersDetail([FromForm] CCOOSCusDetIn inputParams)
        {
            dm.TraceService("GetCCOutOfStockCustomersDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

            DataTable dt = dm.loadList("GetCCOutOfStockCustomersDetail", "sp_CC_Merchandising_WS", cus_ID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCOOSCusDetOut> listHeader = new List<CCOOSCusDetOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCOOSCusDetOut
                        {
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_ArName = dr["prd_NameArabic"].ToString()

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
                dm.TraceService("GetCCOutOfStockCustomersDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCOutOfStockCustomersDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        // OUT OF STOCK END  

        // TASKS START

        public string GetCCTasksCount([FromForm] CCTasksCountIn inputParams)
        {
            dm.TraceService("GetCCTasksCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetCCTasksCount", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCTasksCountOut> listHeader = new List<CCTasksCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCTasksCountOut
                        {

                            AssignedTasks = dr["AssignedTasks"].ToString(),
                            CompletedTasks = dr["CompletedTasks"].ToString()

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
                dm.TraceService("GetCCTasksCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCTasksCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCTask([FromForm] CCTasksIn inputParams)
        {
            dm.TraceService("GetCCTask STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };

            


            DataTable dt = dm.loadList("GetCCTask", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCTasksOut> listHeader = new List<CCTasksOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCTasksOut
                        {
                            TaskName = dr["tsk_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            DueOn = dr["DueDate"].ToString(),
                            CompOn = dr["dph_Time"].ToString(),
                            Status = dr["cst_Status"].ToString(),
                            TaskCode = dr["tsk_Code"].ToString(),
                            TaskArName = dr["tsk_NameArabic"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
                            ArStatus = dr["cst_ArStatus"].ToString()


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
                dm.TraceService("GetCCTask  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCTask ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        // TASKS END

        // SURVEY START

        public string GetCCSurveyCount([FromForm] CCSurveyCountIn inputParams)
        {
            dm.TraceService("GetCCSurveyCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetCCSurveyCount", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCSurveyCountOut> listHeader = new List<CCSurveyCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCSurveyCountOut
                        {

                            AssignedSurvey = dr["Assigned"].ToString(),
                            CompletedSurvey = dr["Completed"].ToString()

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
                dm.TraceService("GetCCSurveyCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCSurveyCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCSurvey([FromForm] CCSurveyIn inputParams)
        {
            dm.TraceService("GetCCSurvey STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };


            DataTable dt = dm.loadList("GetCCSurvey", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCSurveyOut> listHeader = new List<CCSurveyOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCSurveyOut
                        {
                            SurveyName = dr["srm_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            DueOn = dr["crs_StartDate"].ToString(),
                            CompOn = dr["dph_Date"].ToString(),
                            Status = dr["Status"].ToString(),
                            SurveyArName = dr["srm_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
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
                dm.TraceService("GetCCSurvey  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCSurvey ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        // SURVEY END

        // DISPLAY AGREEMENT START

        public string GetCCDisplayCount([FromForm] CCDisplayCountIn inputParams)
        {
            dm.TraceService("GetCCDisplayCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetCCDisplayCount", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCDisplayCountOut> listHeader = new List<CCDisplayCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCDisplayCountOut
                        {

                            Active = dr["ActiveCount"].ToString(),
                            Approved = dr["ApprovedCount"].ToString(),
                            New = dr["NewCount"].ToString()

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
                dm.TraceService("GetCCDisplayCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCDisplayCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCDisplayagreement([FromForm] CCDisplayAgreeIn inputParams)
        {
            dm.TraceService("GetCCDisplayagreement STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };


            DataTable dt = dm.loadList("GetCCDisplayagreement", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCDisplayAgreeOut> listHeader = new List<CCDisplayAgreeOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCDisplayAgreeOut
                        {
                            Number = dr["dag_Number"].ToString(),
                            Type = dr["agt_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            StartDate = dr["dag_StartDate"].ToString(),
                            EndDate = dr["dag_EndDate"].ToString(),
                            Status = dr["DispStatus"].ToString(),
                            ArType = dr["agt_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
                            ArStatus = dr["ArDispStatus"].ToString()


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
                dm.TraceService("GetCCDisplayagreement  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCDisplayagreement ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        //  DISPLAY AGREEMENT END

        // CUSTOMER ACTIVITY START

        public string GetCCCusActCount([FromForm] CCCusActCountIn inputParams)
        {
            dm.TraceService("GetCCCusActCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetCCCusActCount", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCCusActCountOut> listHeader = new List<CCCusActCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCCusActCountOut
                        {

                            Total = dr["Total"].ToString(),
                            ActionTaken = dr["ActionTaken"].ToString()

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
                dm.TraceService("GetCCCusActCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCCusActCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCCustomerActivity([FromForm] CCCusActIn inputParams)
        {
            dm.TraceService("GetCCCustomerActivity STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");
            string Status = inputParams.Status.ToString();

            string[] arr = { ToDate.ToString(), Status };



            DataTable dt = dm.loadList("GetCCCustomerActivity", "sp_CC_Merchandising_WS", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCCusActOut> listHeader = new List<CCCusActOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCCusActOut
                        {
                            ActName = dr["cah_Name"].ToString(),                          
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            StartDate = dr["TransDate"].ToString(),
                            EndDate = dr["cah_EndDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            Act_ArName = dr["cah_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
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
                dm.TraceService("GetCCCustomerActivity  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCCustomerActivity ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        // CUSTOMER ACTIVITY END


    }
}