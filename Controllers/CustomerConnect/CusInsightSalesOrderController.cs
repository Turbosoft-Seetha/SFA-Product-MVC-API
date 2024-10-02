using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using static MVC_API.Models.CusInsightSalesOrderHelper;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.Customer_Connect
{
    public class CusInsightSalesOrderController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]

        public string SelectSalesOrders([FromForm] CusInsightOrderIn inputParams)
        {
            dm.TraceService("SelectSalesOrders STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Cus_ID = inputParams.Cus_ID == null ? "0" : inputParams.Cus_ID;


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
                    RouteCondition = " and rot_ID in ( " + Route + " )";
                }

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(),Cus_ID.ToString() };
                DataTable dtPicking = dm.loadList("SelSalesOrders", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<CusInsightOrderOut> listItems = new List<CusInsightOrderOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new CusInsightOrderOut
                        {

                            ord_ID = dr["ord_ID"].ToString(),
                            OrderID = dr["OrderID"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            csh_ID = dr["csh_ID"].ToString(),
                            csh_Code = dr["csh_Code"].ToString(),
                            csh_Name = dr["csh_Name"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            SubTotal = dr["ord_SubTotal"].ToString(),
                            VAT = dr["ord_VAT"].ToString(),
                            GrandTotal = dr["ord_GrandTotal"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            ArStatus = dr["ArStatus"].ToString(),
                            Arcsh_Name = dr["csh_NameArabic"].ToString()
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
                dm.TraceService("SelectSalesOrders Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSalesOrders ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        //Filter DropDown
        public string SelectAreaForCusInsightSalesOrder([FromForm] AreaSalesOrderIn inputParams)
        {
            dm.TraceService("SelectAreaForSalesOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Cus_ID = inputParams.Cus_ID == null ? "0" : inputParams.Cus_ID;

                string[] arr = { FromDate.ToString(), ToDate.ToString() , Cus_ID.ToString() };
                DataTable dt = dm.loadList("SelAreaForCusInsightSalesOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<AreaSalesOrderOut> listItems = new List<AreaSalesOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new AreaSalesOrderOut
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
                dm.TraceService("SelectAreaForSalesOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForSalesOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForCusInsightSalesOrder([FromForm] SubAreaSalesOrderIn inputParams)
        {
            dm.TraceService("SelectSubAreaForSalesOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Cus_ID = inputParams.Cus_ID == null ? "0" : inputParams.Cus_ID;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), Cus_ID, AreaID };
                DataTable dt = dm.loadList("SelSubAreaForCusInsightSalesOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<SubAreaSalesOrderOut> listItems = new List<SubAreaSalesOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SubAreaSalesOrderOut
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
                dm.TraceService("SelectSubAreaForSalesOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForSalesOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForCusInsightSalesOrder([FromForm] RouteSalesOrderIn inputParams)
        {
            dm.TraceService("SelectRouteForSalesOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Cus_ID = inputParams.Cus_ID == null ? "0" : inputParams.Cus_ID;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), Cus_ID, SubAreaID };
                DataTable dt = dm.loadList("SelRouteForCusInsightSalesOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<RouteSalesOrderOut> listItems = new List<RouteSalesOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new RouteSalesOrderOut
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
                dm.TraceService("SelectRouteForSalesOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForSalesOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string OrderDetails([FromForm] SalesOrderIn inputParams)
        {
            dm.TraceService("OrderDetails STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Route_ID = inputParams.RouteID == null ? "0" : inputParams.RouteID;
                string Cus_ID = inputParams.CusID == null ? "0" : inputParams.CusID;
                string Order_ID = inputParams.OrderID == null ? "0" : inputParams.OrderID;

                string[] arr = { UserID, Route_ID, Cus_ID, Order_ID };
                DataTable dt = dm.loadList("OrderDetails", "sp_CustomerConnect", Order_ID, arr);
                if (dt.Rows.Count > 0)
                {
                    List<OrderDetailsOut> listItems = new List<OrderDetailsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new OrderDetailsOut
                        {

                            Prd_Code = dr["prd_Code"].ToString(),
                            Prd_Name = dr["prd_Name"].ToString(),
                            Prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            Odd_HigherUOM = dr["odd_HigherUOM"].ToString(),
                            Odd_LowerUOM = dr["odd_LowerUOM"].ToString(),
                            Odd_HigherQty = dr["odd_HigherQty"].ToString(),
                            Odd_LowerQty = dr["odd_LowerQty"].ToString(),
                            Odd_HigherPrice = dr["odd_HigherPrice"].ToString(),
                            Odd_LowerPrice = dr["odd_LowerPrice"].ToString(),
                            Odd_VATAmount = dr["odd_VATAmount"].ToString(),
                            Odd_VATPercent = dr["odd_VATPercent"].ToString(),
                            Odd_Discount = dr["odd_Discount"].ToString(),
                            Odd_SubTotal = dr["odd_SubTotal"].ToString(),
                            Odd_GrandTotal = dr["odd_GrandTotal"].ToString(),
                            Odd_TotalQty = dr["odd_TotalQty"].ToString(),
                            Odd_Price = dr["odd_Price"].ToString(),
                            Odd_TransType = dr["odd_TransType"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),

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
                dm.TraceService("OrderDetails Exception - " + ex.Message.ToString());
            }
            dm.TraceService("OrderDetails ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

    }
}