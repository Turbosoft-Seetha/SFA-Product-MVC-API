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
    public class PickingController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string SelectPickingHeader([FromForm] PickingIn inputParams)
        {
            dm.TraceService("SelectPickingHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
               
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Customer = inputParams.Customer == null ? "0" : inputParams.Customer;
                string Outlet = inputParams.Outlet == null ? "0" : inputParams.Outlet;

                if (Mode == "N")
                {
                    Mode = " and A.Status in ('N')";
                }
                else if (Mode == "O")
                {
                    Mode = " and A.Status in ('O')";
                }
                else if (Mode == "PC")
                {
                    Mode = " and A.Status in ('PC')";
                }
                else
                {
                    Mode = " and A.Status in ('N','O','P','PR','PC')";
                }

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
                    AreaCondition = " and dpa_ID in ( "+ Area +" )";
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

                string[] arr = { Mode.ToString(), FromDate.ToString(), ToDate.ToString() , MainCondition.ToString() };
                DataTable dtPicking = dm.loadList("SelPickingHeader", "sp_CustomerConnect", UserID.ToString(),  arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<PickingOut> listItems = new List<PickingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new PickingOut
                        {
                            PickingID = dr["pkh_ID"].ToString(),
                            PickingNumber = dr["pkh_Number"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rsn_ID = dr["rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
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
                dm.TraceService("SelectPickingHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectPickingHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectPickingDetail([FromForm] PickingDetailIn inputParams)
        {
            dm.TraceService("SelectPickingDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string PickingID = inputParams.PickingID == null ? "0" : inputParams.PickingID;

                DataTable dtorders = dm.loadList("SelPickingDetail", "sp_CustomerConnect", PickingID.ToString());

                if (dtorders.Rows.Count > 0)
                {
                    List<PickingDetailOut> listItems = new List<PickingDetailOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new PickingDetailOut
                        {                           
                            pkd_ID = dr["pkd_ID"].ToString(),
                            pkd_pkh_ID = dr["pkd_pkh_ID"].ToString(),
                            prd_ID = dr["prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            prd_Description = dr["prd_Description"].ToString(),
                            pkd_Higher_uom = dr["pkd_Higher_uom"].ToString(),
                            pkd_Lower_uom = dr["pkd_Lower_uom"].ToString(),
                            pkd_PickedHQty = dr["pkd_PickedHQty"].ToString(),
                            pkd_PickedLQty = dr["pkd_PickedLQty"].ToString(),
                            pkd_RequestedHQty = dr["pkd_RequestedHQty"].ToString(),
                            pkd_RequestedLQty = dr["pkd_RequestedLQty"].ToString(),
                            pkd_TransType = dr["pkd_TransType"].ToString(),
                            prd_ArabicDescription = dr["prd_ArabicDescription"].ToString()

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
                dm.TraceService("SelectPickingDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectPickingDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectAreaForPicking([FromForm] AreaPickingIn inputParams)
        {
            dm.TraceService("SelectAreaForPicking STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                if (Mode == "N")
                {
                    Mode = " and A.Status in ('N')";
                }
                else if (Mode == "O")
                {
                    Mode = " and A.Status in ('O')";
                }
                else if (Mode == "PC")
                {
                    Mode = " and A.Status in ('PC')";
                }
                else
                {
                    Mode = " and A.Status in ('N','O','P','PR','PC')";
                }

                string[] arr = { Mode.ToString(), FromDate.ToString(), ToDate.ToString() };
                DataTable dtPicking = dm.loadList("SelAreaForPicking", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<AreaPickingOut> listItems = new List<AreaPickingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new AreaPickingOut
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
                dm.TraceService("SelectAreaForPicking Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForPicking ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForPicking([FromForm] SubAreaPickingIn inputParams)
        {
            dm.TraceService("SelectSubAreaForPicking STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;

                if (Mode == "N")
                {
                    Mode = " and A.Status in ('N')";
                }
                else if (Mode == "O")
                {
                    Mode = " and A.Status in ('O')";
                }
                else if (Mode == "PC")
                {
                    Mode = " and A.Status in ('PC')";
                }
                else
                {
                    Mode = " and A.Status in ('N','O','P','PR','PC')";
                }

                string[] arr = { Mode.ToString(), FromDate.ToString(), ToDate.ToString(), AreaID };
                DataTable dtPicking = dm.loadList("SelSubAreaForPicking", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<SubAreaPickingOut> listItems = new List<SubAreaPickingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new SubAreaPickingOut
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
                dm.TraceService("SelectSubAreaForPicking Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForPicking ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForPicking([FromForm] RoutePickingIn inputParams)
        {
            dm.TraceService("SelectRouteForPicking STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;

                if (Mode == "N")
                {
                    Mode = " and A.Status in ('N')";
                }
                else if (Mode == "O")
                {
                    Mode = " and A.Status in ('O')";
                }
                else if (Mode == "PC")
                {
                    Mode = " and A.Status in ('PC')";
                }
                else
                {
                    Mode = " and A.Status in ('N','O','P','PR','PC')";
                }

                string[] arr = { Mode.ToString(), FromDate.ToString(), ToDate.ToString(), SubAreaID };
                DataTable dtPicking = dm.loadList("SelRouteForPicking", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<RoutePickingOut> listItems = new List<RoutePickingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new RoutePickingOut
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
                dm.TraceService("SelectRouteForPicking Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForPicking ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectCustomerForPicking([FromForm] CusPickingIn inputParams)
        {
            dm.TraceService("SelectCustomerForPicking STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                if (Mode == "N")
                {
                    Mode = " and A.Status in ('N')";
                }
                else if (Mode == "O")
                {
                    Mode = " and A.Status in ('O')";
                }
                else if (Mode == "PC")
                {
                    Mode = " and A.Status in ('PC')";
                }
                else
                {
                    Mode = " and A.Status in ('N','O','P','PR','PC')";
                }

                string[] arr = { Mode.ToString(), FromDate.ToString(), ToDate.ToString() };
                DataTable dtPicking = dm.loadList("SelCustomerForPicking", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<CusPickingOut> listItems = new List<CusPickingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new CusPickingOut
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
                dm.TraceService("SelectCustomerForPicking Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCustomerForPicking ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectOutletForPicking([FromForm] OutletPickingIn inputParams)
        {
            dm.TraceService("SelectOutletForPicking STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                if (Mode == "N")
                {
                    Mode = " and A.Status in ('N')";
                }
                else if (Mode == "O")
                {
                    Mode = " and A.Status in ('O')";
                }
                else if (Mode == "PC")
                {
                    Mode = " and A.Status in ('PC')";
                }
                else
                {
                    Mode = " and A.Status in ('N','O','P','PR','PC')";
                }

                string[] arr = { Mode.ToString(), FromDate.ToString(), ToDate.ToString(), CusID.ToString() };
                DataTable dtPicking = dm.loadList("SelOutletForPicking", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtPicking.Rows.Count > 0)
                {
                    List<OutletPickingOut> listItems = new List<OutletPickingOut>();
                    foreach (DataRow dr in dtPicking.Rows)
                    {

                        listItems.Add(new OutletPickingOut
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
                dm.TraceService("SelectOutletForPicking Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectOutletForPicking ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}