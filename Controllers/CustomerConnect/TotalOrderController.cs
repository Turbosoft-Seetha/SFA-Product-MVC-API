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

namespace MVC_API.Controllers.CustomerConnect
{
    public class TotalOrderController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string SelectTotalOrders([FromForm] OrderIn inputParams)
        {
            dm.TraceService("SelectTotalOrders STARTED -" + DateTime.Now);
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
                if (Mode == "0")
                {
                    ModeCondition = "";
                }
                else
                {
                    ModeCondition = " and ord_Type in( " + inputParams.Mode + ")";
                }

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;
                MainCondition += CustomerCondition;
                MainCondition += OutletCondition;
                MainCondition += ModeCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString() };
                DataTable dtOrders = dm.loadList("SelTotalOrders", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtOrders.Rows.Count > 0)
                {
                    List<OrderOut> listItems = new List<OrderOut>();
                    foreach (DataRow dr in dtOrders.Rows)
                    {

                        listItems.Add(new OrderOut
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
                            ord_Type = dr["ord_Type"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arcsh_Name = dr["csh_NameArabic"].ToString(),

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
                dm.TraceService("SelectTotalOrders Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectTotalOrders ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectTotalOrderDetail([FromForm] OrderDetailIn inputParams)
        {
            dm.TraceService("SelectTotalOrderDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string ord_ID = inputParams.ord_ID == null ? "0" : inputParams.ord_ID;
               
               DataTable dtorders = dm.loadList("SelTotalOrderDetail", "sp_CustomerConnect", ord_ID.ToString());

                if (dtorders.Rows.Count > 0)
                {
                    List<OrderDetailOut> listItems = new List<OrderDetailOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new OrderDetailOut
                        { 
                            odd_ID = dr["odd_ID"].ToString(),
                            odd_ord_ID = dr["odd_ord_ID"].ToString(),
                            prd_ID = dr["prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            prd_Description = dr["prd_Description"].ToString(),
                            odd_HigherUOM = dr["odd_HigherUOM"].ToString(),
                            odd_LowerUOM = dr["odd_LowerUOM"].ToString(),
                            odd_HigherQty = dr["odd_HigherQty"].ToString(),
                            odd_LowerQty = dr["odd_LowerQty"].ToString(),
                            odd_HigherPrice = dr["odd_HigherPrice"].ToString(),
                            odd_LowerPrice = dr["odd_LowerPrice"].ToString(),
                            odd_Price = dr["odd_Price"].ToString(),
                            odd_TotalQty = dr["odd_TotalQty"].ToString(),
                            odd_VATPercent = dr["odd_VATPercent"].ToString(),
                            odd_Discount = dr["odd_Discount"].ToString(),
                            odd_SubTotal = dr["odd_SubTotal"].ToString(),
                            odd_VATAmount = dr["odd_VATAmount"].ToString(),
                            odd_GrandTotal = dr["odd_GrandTotal"].ToString(),
                            odd_TransType = dr["odd_TransType"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString()
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
                dm.TraceService("SelectTotalOrderDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectTotalOrderDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        //Filter DropDown
        public string SelectAreaForTotalOrder([FromForm] AreaTotalOrderIn inputParams)
        {
            dm.TraceService("SelectAreaForTotalOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { FromDate.ToString(), ToDate.ToString() };
                DataTable dt = dm.loadList("SelAreaForTotalOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<AreaTotalOrderOut> listItems = new List<AreaTotalOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new AreaTotalOrderOut
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
                dm.TraceService("SelectAreaForTotalOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForTotalOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForTotalOrder([FromForm] SubAreaTotalOrderIn inputParams)
        {
            dm.TraceService("SelectSubAreaForTotalOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), AreaID };
                DataTable dt = dm.loadList("SelSubAreaForTotalOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<SubAreaTotalOrderOut> listItems = new List<SubAreaTotalOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SubAreaTotalOrderOut
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
                dm.TraceService("SelectSubAreaForTotalOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForTotalOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForTotalOrder([FromForm] RouteTotalOrderIn inputParams)
        {
            dm.TraceService("SelectRouteForTotalOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), SubAreaID };
                DataTable dt = dm.loadList("SelRouteForTotalOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<RouteTotalOrderOut> listItems = new List<RouteTotalOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new RouteTotalOrderOut
                        {
                            RouteID = dr["RouteID"].ToString(),
                            Route = dr["Route"].ToString(),
                            Routecode = dr["rot_Code"].ToString()

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
                dm.TraceService("SelectRouteForTotalOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForTotalOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectCustomerForTotalOrder([FromForm] CusTotalOrderIn inputParams)
        {
            dm.TraceService("SelectCustomerForTotalOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { FromDate.ToString(), ToDate.ToString() };
                DataTable dtTotalOrder = dm.loadList("SelCustomerForTotalOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtTotalOrder.Rows.Count > 0)
                {
                    List<CusTotalOrderOut> listItems = new List<CusTotalOrderOut>();
                    foreach (DataRow dr in dtTotalOrder.Rows)
                    {

                        listItems.Add(new CusTotalOrderOut
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
                dm.TraceService("SelectCustomerForTotalOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCustomerForTotalOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectOutletForTotalOrder([FromForm] OutletTotalOrderIn inputParams)
        {
            dm.TraceService("SelectOutletForTotalOrder STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), CusID.ToString() };
                DataTable dtTotalOrder = dm.loadList("SelOutletForTotalOrder", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtTotalOrder.Rows.Count > 0)
                {
                    List<OutletTotalOrderOut> listItems = new List<OutletTotalOrderOut>();
                    foreach (DataRow dr in dtTotalOrder.Rows)
                    {

                        listItems.Add(new OutletTotalOrderOut
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
                dm.TraceService("SelectOutletForTotalOrder Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectOutletForTotalOrder ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}