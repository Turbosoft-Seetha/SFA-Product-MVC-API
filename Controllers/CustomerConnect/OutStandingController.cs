using Microsoft.AspNetCore.Mvc;
using MVC_API.Models.CustomerConnectHelper;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC_API.Controllers.CustomerConnect
{
    public class OutStandingController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string SelectOutstandingHeader([FromForm] OutStandingIn inputParams)
        {
            dm.TraceService("SelectOutstandingHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {

                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Customer = inputParams.Customer == null ? "0" : inputParams.Customer;
                string Outlet = inputParams.Outlet == null ? "0" : inputParams.Outlet;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string Pagenum = inputParams.Pagenum == null ? "1" : inputParams.Pagenum;
                string SearchString = inputParams.SearchString == null ? "0" : inputParams.SearchString;

                string MainCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string RouteCondition = "";
                string CustomerCondition = "";
                string OutletCondition = "";
                string ModeCondition = "";

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
                    RouteCondition = " and rot_ID in ( " + Route + " )";
                }
                if (Customer == "0")
                {
                    CustomerCondition = "";
                }
                else
                {
                    CustomerCondition = " and csh_ID in ( " + Customer + " )";
                }
                if (Outlet == "0")
                {
                    OutletCondition = "";
                }
                else
                {
                    OutletCondition = " and cus_ID in ( " + Outlet + " )";
                }

                if (Mode == "Due")
                {
                    ModeCondition = " and cast(getdate() as date) < cast(InvoicedOn + rcs_CreditDays as date)";
                }
                else if (Mode == "OverDue")
                {
                    ModeCondition = " and cast(getdate() as date) > cast(InvoicedOn + rcs_CreditDays as date)";
                }
                else
                {
                    ModeCondition = "";
                }

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;
                MainCondition += CustomerCondition;
                MainCondition += OutletCondition;
                MainCondition += ModeCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(), Pagenum.ToString(), SearchString.ToString() };
                DataTable dtPicking = dm.loadList("SelOutstandingHeader", "sp_CustomerConnect", UserID.ToString(), arr);
                if (dtPicking.Rows.Count > 0)
                {
                    List<OutStandingOut> listItems = new List<OutStandingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new OutStandingOut
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
                            ID = dr["inv_ID"].ToString(),
                            inv_PayType = dr["inv_PayType"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
                            csh_ArName = dr["csh_NameArabic"].ToString(),
                            rot_ArName = dr["rot_ArabicName"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()

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
                dm.TraceService("SelectOutstandingHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectOutstandingHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectOutStandingCount([FromForm] OutStandingCountIn inputParams)
        {
            dm.TraceService("SelectOutStandingCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Customer = inputParams.Customer == null ? "0" : inputParams.Customer;
                string Outlet = inputParams.Outlet == null ? "0" : inputParams.Outlet;

                string MainCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string RouteCondition = "";
                string CustomerCondition = "";
                string OutletCondition = "";

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
                    RouteCondition = " and rot_ID in ( " + Route + " )";
                }
                if (Customer == "0")
                {
                    CustomerCondition = "";
                }
                else
                {
                    CustomerCondition = " and csh_ID in ( " + Customer + " )";
                }
                if (Outlet == "0")
                {
                    OutletCondition = "";
                }
                else
                {
                    OutletCondition = " and cus_ID in ( " + Outlet + " )";
                }

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;
                MainCondition += CustomerCondition;
                MainCondition += OutletCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString() };
                DataTable dt = dm.loadList("SelOutStandingCount", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<OutStandingCountOut> listItems = new List<OutStandingCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new OutStandingCountOut
                        {

                            DueCount = dr["DueCount"].ToString(),
                            DueAmount = dr["DueAmount"].ToString(),

                            OverDueCount = dr["OverDueCount"].ToString(),
                            OverDueAmount = dr["OverDueAmount"].ToString(),

                            TotCount = dr["totcount"].ToString(),
                            TotAmount = dr["totamount"].ToString(),

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
                dm.TraceService("SelectOutStandingCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectOutStandingCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        //Filter DropDown
        public string SelectAreaForOutStanding([FromForm] AreaOutStandingIn inputParams)
        {
            dm.TraceService("SelectAreaForOutStanding STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { FromDate.ToString(), ToDate.ToString() };
                DataTable dt = dm.loadList("SelAreaForOutStanding", "sp_CustomerConnect", UserID.ToString(), arr);

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
                dm.TraceService("SelectAreaForOutStanding Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForOutStanding ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForOutStanding([FromForm] SubAreaOutStandingIn inputParams)
        {
            dm.TraceService("SelectSubAreaForOutStanding STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), AreaID };
                DataTable dt = dm.loadList("SelSubAreaForOutStanding", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<SubAreaOutStandingOut> listItems = new List<SubAreaOutStandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SubAreaOutStandingOut
                        {
                            SubAreaID = dr["SubAreaID"].ToString(),
                            SubArea = dr["SubArea"].ToString(),
                            Subareacode= dr["dsa_Code"].ToString()
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
                dm.TraceService("SelectSubAreaForOutStanding Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForOutStanding ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForOutStanding([FromForm] RouteOutStandingIn inputParams)
        {
            dm.TraceService("SelectRouteForOutStanding STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), SubAreaID };
                DataTable dt = dm.loadList("SelRouteForOutStanding", "sp_CustomerConnect", UserID.ToString(), arr);

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
                dm.TraceService("SelectRouteForOutStanding Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForOutStanding ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectCustomerForOutStanding([FromForm] CustOutStandingIn inputParams)
        {
            dm.TraceService("SelectCustomerForOutStanding STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { FromDate.ToString(), ToDate.ToString() };
                DataTable dtOutStanding = dm.loadList("SelCustomerForOutStandingInv", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtOutStanding.Rows.Count > 0)
                {
                    List<CustOutStandingOut> listItems = new List<CustOutStandingOut>();
                    foreach (DataRow dr in dtOutStanding.Rows)
                    {

                        listItems.Add(new CustOutStandingOut
                        {
                            CusID = dr["csh_ID"].ToString(),
                            CusCode = dr["csh_Code"].ToString(),
                            CusName = dr["csh_Name"].ToString(),

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
                dm.TraceService("SelectCustomerForOutStanding Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCustomerForOutStanding ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectOutletForOutStanding([FromForm] OutletOutStandingIn inputParams)
        {
            dm.TraceService("SelectOutletForOutStanding STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), CusID.ToString() };
                DataTable dtOutStanding = dm.loadList("SelOutletForOutStandingInv", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtOutStanding.Rows.Count > 0)
                {
                    List<OutletOutStandingOut> listItems = new List<OutletOutStandingOut>();
                    foreach (DataRow dr in dtOutStanding.Rows)
                    {

                        listItems.Add(new OutletOutStandingOut
                        {
                            OutletID = dr["cus_ID"].ToString(),
                            OutletCode = dr["cus_Code"].ToString(),
                            OutletName = dr["cus_Name"].ToString(),

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
                dm.TraceService("SelectOutletForOutStanding Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectOutletForOutStanding ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}