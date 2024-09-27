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
    public class SpecialPriceController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string SelectSpecialPriceHeader([FromForm] SpecialPriceIn inputParams)
        {
            dm.TraceService("SelectSpecialPriceHeader STARTED -" + DateTime.Now);
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
                if (inputParams.Mode != null)
                {
                    ModeCondition = " and crp_PayMode in ( " + inputParams.Mode + ")";
                }


                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;
                MainCondition += CustomerCondition;
                MainCondition += OutletCondition;
                MainCondition += ModeCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString()  , MainCondition.ToString()  };
                DataTable dt = dm.loadList("SelectSpecialPrice", "sp_CustomerConnect", UserID.ToString(),arr);

                if (dt.Rows.Count > 0)
                {
                    List<SpecialPriceOut> listItems = new List<SpecialPriceOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SpecialPriceOut
                        {
                            prh_ID = dr["prh_ID"].ToString(),
                            prh_Code = dr["prh_Code"].ToString(),
                            prh_Name = dr["prh_Name"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            prh_PayMode = dr["prh_PayMode"].ToString(),
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
                dm.TraceService("SelectSpecialPriceHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSpecialPriceHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSpecialPriceDetail([FromForm] SPDetailIn inputParams)
        {
            dm.TraceService("SelectSpecialPriceDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string prh_ID = inputParams.prh_ID == null ? "0" : inputParams.prh_ID;
                

               
                DataTable dt = dm.loadList("SelSpecialPriceDetail", "sp_CustomerConnect" , prh_ID);

                if (dt.Rows.Count > 0)
                {
                    List<SPDetailOut> listItems = new List<SPDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SPDetailOut
                        {
                           
                            pld_ID = dr["pld_ID"].ToString(),
                            pld_prh_ID = dr["pld_prh_ID"].ToString(),
                            pld_VATPerc = dr["pld_VATPerc"].ToString(),
                            prd_ID = dr["prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            prd_Description = dr["prd_Description"].ToString(),
                            UOM = dr["uom_Name"].ToString(),
                            StdPrice = dr["StdPrice"].ToString(),
                            SpecialPrice = dr["SpecialPrice"].ToString(),
                            pld_ReturnPrice = dr["pld_ReturnPrice"].ToString(),
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
                dm.TraceService("SelectSpecialPriceDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSpecialPriceDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSPAssignedCustomers([FromForm] SpecialPriceCusIn inputParams)
        {
            dm.TraceService("SelectSPAssignedCustomers STARTED -" + DateTime.Now);
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
                string ID = inputParams.ID == null ? "0" : inputParams.ID;

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
                if (inputParams.Mode != null)
                {
                    ModeCondition = " and crp_PayMode in ( " + inputParams.Mode + ")";
                }


                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;
                MainCondition += CustomerCondition;
                MainCondition += OutletCondition;
                MainCondition += ModeCondition;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(),ID };
                DataTable dt = dm.loadList("SelSPAssignedCustomers", "sp_CustomerConnect",UserID.ToString(),arr);

                if (dt.Rows.Count > 0)
                {
                    List<SpecialPriceCusOut> listItems = new List<SpecialPriceCusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SpecialPriceCusOut
                        {
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            csh_ID = dr["csh_ID"].ToString(),
                            csh_Code = dr["csh_Code"].ToString(),
                            csh_Name = dr["csh_Name"].ToString(),
                            Class = dr["cls_Name"].ToString(),
                            Area = dr["are_Name"].ToString(),
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
                dm.TraceService("SelectSPAssignedCustomers Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSPAssignedCustomers ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        //Filter DropDown
        public string SelectAreaForSpecialPrice([FromForm] AreaSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectAreaForSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { FromDate.ToString(), ToDate.ToString() };
                DataTable dt = dm.loadList("SelAreaForSpecialPrice", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<AreaSpecialPriceOut> listItems = new List<AreaSpecialPriceOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new AreaSpecialPriceOut
                        {
                            AreaID = dr["AreaID"].ToString(),
                            Area = dr["Area"].ToString(),
                            AreaCode = dr["dpa_Code"].ToString()

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
                dm.TraceService("SelectAreaForSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForSpecialPrice([FromForm] SubAreaSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectSubAreaForSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), AreaID };
                DataTable dt = dm.loadList("SelSubAreaForSpecialPrice", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<SubAreaSpecialPriceOut> listItems = new List<SubAreaSpecialPriceOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SubAreaSpecialPriceOut
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
                dm.TraceService("SelectSubAreaForSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForSpecialPrice([FromForm] RouteSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectRouteForSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), SubAreaID };
                DataTable dt = dm.loadList("SelRouteForSpecialPrice", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<RouteSpecialPriceOut> listItems = new List<RouteSpecialPriceOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new RouteSpecialPriceOut
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
                dm.TraceService("SelectRouteForSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectCustomerForSpecialPrice([FromForm] CustSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectCustomerForSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string prh_ID = inputParams.prh_ID == null ? "0" : inputParams.prh_ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { FromDate.ToString(), ToDate.ToString() };
                DataTable dtSpecialPrice = dm.loadList("SelCustomerForSpecialPrice", "sp_CustomerConnect", prh_ID.ToString(), arr);

                if (dtSpecialPrice.Rows.Count > 0)
                {
                    List<CustSpecialPriceOut> listItems = new List<CustSpecialPriceOut>();
                    foreach (DataRow dr in dtSpecialPrice.Rows)
                    {

                        listItems.Add(new CustSpecialPriceOut
                        {
                            CusID = dr["csh_ID"].ToString(),
                            CusCode = dr["csh_Code"].ToString(),
                            CusName = dr["csh_Name"].ToString(),
                            ArCusName = dr["csh_NameArabic"].ToString()

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
                dm.TraceService("SelectCustomerForSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCustomerForSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectOutletForSpecialPrice([FromForm] OutletSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectOutletForSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), CusID.ToString() };
                DataTable dtSpecialPrice = dm.loadList("SelOutletForSpecialPrice", "sp_CustomerConnect", UserID.ToString(), arr);
                
                if (dtSpecialPrice.Rows.Count > 0)
                {
                    List<OutletSpecialPriceOut> listItems = new List<OutletSpecialPriceOut>();
                    foreach (DataRow dr in dtSpecialPrice.Rows)
                    {

                        listItems.Add(new OutletSpecialPriceOut
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
                dm.TraceService("SelectOutletForSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectOutletForSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}