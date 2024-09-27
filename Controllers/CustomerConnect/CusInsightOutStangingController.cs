using Microsoft.AspNetCore.Mvc;
using MultipartDataMediaFormatter.Infrastructure;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
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
using static MVC_API.Models.CusInsightARHelper;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.Customer_Connect
{
    public class CusInsightOutStangingController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]

        public string CusInsightOutstandingHeader([FromForm] CusOutStandingIn inputParams)
        {
            dm.TraceService("CusInsightOutstandingHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string MainCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string RouteCondition = "";

                if (Area == "0")
                {
                    AreaCondition = "";
                }
                else
                {
                    AreaCondition = " and dpa_ID in ( " + Area + " )";
                }
                if (SubArea == "0")
                {
                    SubAreaCondition = "";
                }
                else
                {
                    SubAreaCondition = " and dsa_ID in ( " + SubArea + " )";
                }
                if (Route == "0")
                {
                    RouteCondition = "";
                }
                else
                {
                    RouteCondition = " and R.rot_ID in ( " + Route + " )";
                }

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(), cus_ID.ToString() };
                DataTable dtPicking = dm.loadList("SelCusInsightOutstandingHeader", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<CusOutStandingOut> listItems = new List<CusOutStandingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new CusOutStandingOut
                        {
                            InvoiceID = dr["InvoiceID"].ToString(),
                            InvoicedOn = dr["InvoicedOn"].ToString(),
                            InvoiceAmount = dr["InvoiceAmount"].ToString(),
                            AmountPaid = dr["AmountPaid"].ToString(),
                            InvoiceBalance = dr["InvoiceBalance"].ToString(),
                            PDC_Amount = dr["PDC_Amount"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            csh_ID = dr["csh_ID"].ToString(),
                            csh_Code = dr["csh_Code"].ToString(),
                            csh_Name = dr["csh_Name"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            ID = dr["inv_ID"].ToString()

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
                dm.TraceService("CusInsightOutstandingHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusInsightOutstandingHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string CusInsightOutStandingCount([FromForm] CusOutStandingCountIn inputParams)
        {
            dm.TraceService("CusInsightOutStandingCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;



                string MainCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string RouteCondition = "";

                if (Area == "0")
                {
                    AreaCondition = "";
                }
                else
                {
                    AreaCondition = " and dpa_ID in ( " + Area + " )";
                }
                if (SubArea == "0")
                {
                    SubAreaCondition = "";
                }
                else
                {
                    SubAreaCondition = " and dsa_ID in ( " + SubArea + " )";
                }
                if (Route == "0")
                {
                    RouteCondition = "";
                }
                else
                {
                    RouteCondition = " and R.rot_ID in ( " + Route + " )";
                }

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(), cus_ID.ToString() };
                DataTable dt = dm.loadList("SelCusInsightOutStandingCount", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<CusOutStandingCountOut> listItems = new List<CusOutStandingCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new CusOutStandingCountOut
                        {

                            DueCount = dr["DueCount"].ToString(),
                            DueAmount = dr["DueAmount"].ToString(),

                            OverDueCount = dr["OverDueCount"].ToString(),
                            OverDueAmount = dr["OverDueAmount"].ToString(),

                            totCount = dr["totcount"].ToString(),
                            totAmount = dr["totamount"].ToString(),

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
                dm.TraceService("CusInsightOutStandingCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusInsightOutStandingCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string SelectAreaForOutStandingCus([FromForm] AreaOutStandingIn inputParams)
        {
            dm.TraceService("SelectAreaForOutStandingCus STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(),CusID };
                DataTable dt = dm.loadList("SelAreaForOutStandingCus", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<AreaOutStandingOut> listItems = new List<AreaOutStandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new AreaOutStandingOut
                        {
                            AreaID = dr["AreaID"].ToString(),
                            Area = dr["Area"].ToString(),
                            Areacode = dr["dpa_Code"].ToString()

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
                dm.TraceService("SelectAreaForOutStandingCus Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForOutStandingCus ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForOutStandingCus([FromForm] SubAreaOutStandingIn inputParams)
        {
            dm.TraceService("SelectSubAreaForOutStandingCus STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), AreaID,CusID };
                DataTable dt = dm.loadList("SelSubAreaForOutStandingCus", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<SubAreaOutStandingOut> listItems = new List<SubAreaOutStandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SubAreaOutStandingOut
                        {
                            SubAreaID = dr["SubAreaID"].ToString(),
                            SubArea = dr["SubArea"].ToString(),
                            Subareacode = dr["dsa_Code"].ToString()

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
                dm.TraceService("SelectSubAreaForOutStandingCus Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForOutStandingCus ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForOutStandingCus([FromForm] RouteOutStandingIn inputParams)
        {
            dm.TraceService("SelectRouteForOutStandingCus STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), SubAreaID,CusID };
                DataTable dt = dm.loadList("SelRouteForOutStandingCus", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<RouteOutStandingOut> listItems = new List<RouteOutStandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new RouteOutStandingOut
                        {
                            RouteID = dr["RouteID"].ToString(),
                            Route = dr["Route"].ToString(),
                            RouteCode = dr["rot_Code"].ToString()

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
                dm.TraceService("SelectRouteForOutStandingCus Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForOutStandingCus ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}