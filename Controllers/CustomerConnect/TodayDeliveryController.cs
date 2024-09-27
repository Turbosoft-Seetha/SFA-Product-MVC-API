using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.CustomerConnect
{
    public class TodayDeliveryController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectTodayDeliveyHeader([FromForm] LoadInIn inputParams)
        {
            dm.TraceService("SelectTodayDeliveyHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {

                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string Customer = inputParams.Customer == null ? "0" : inputParams.Customer;
                string CusOutlet = inputParams.CusOutlet == null ? "0" : inputParams.CusOutlet;
                string RouteCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string ModeCondition = "";
                string CusCondition = "";
                string CusOutCondition = "";

                if (inputParams.Route != null)
                {
                    RouteCondition = " and R.rot_ID in( " + inputParams.Route + ")";
                }
                if (inputParams.Area != null)
                {
                    AreaCondition = " and Y.dpa_ID in( " + inputParams.Area + ")";
                }
                if (inputParams.SubArea != null)
                {
                    SubAreaCondition = " and X.dsa_ID in( " + inputParams.SubArea + ")";
                }
                if (inputParams.Mode != null)
                {
                    ModeCondition = " and O.Status in( " + inputParams.Mode + ")";
                }
                if (inputParams.Customer != null)
                {
                    CusCondition = " and C.cus_ID in( " + inputParams.Customer + ")";
                }
                if (inputParams.CusOutlet != null)
                {
                    CusOutCondition = " and CH.csh_ID in( " + inputParams.CusOutlet + ")";
                }

                string dateCondition = " And (cast(O.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";



               
                string[] arr = {  RouteCondition.ToString() , ModeCondition, RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString(),CusCondition.ToString(),CusOutCondition.ToString() };

                DataTable dtLoadIn = dm.loadList("TodayDelHeader", "sp_CustomerConnect", dateCondition.ToString(), arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<TodayDelOut> listItems = new List<TodayDelOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new TodayDelOut
                        {

                            OrderID = dr["OrderID"].ToString(),
                            rot_ID = dr["ord_rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            cusName = dr["csh_Name"].ToString(),
                            cusCode = dr["csh_Code"].ToString(),
                            cusOutName = dr["cus_Name"].ToString(),
                            cusOutCode = dr["cus_Code"].ToString(),
                            salesman = dr["salesman"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            ID = dr["ord_ID"].ToString(),
                            SubTotal= dr["ord_SubTotal"].ToString(),
                            VAT= dr["ord_VAT"].ToString(),
                            GrandTotal= dr["ord_GrandTotal"].ToString(),
                            ArcusName = dr["csh_NameArabic"].ToString(),
                            ArStatus = dr["Status"].ToString(),
                            ArcusOutName = dr["cus_NameArabic"].ToString(),
                            Arsalesman = dr["Arsalesman"].ToString()
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
                dm.TraceService(" SelectTodayDeliveyHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectTodayDeliveyHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectTodayDelDetail([FromForm] TodayDelDetailIn inputParams)
        {
            dm.TraceService("SelectTodayDelDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtLoadIn = dm.loadList("TodayDelDetail", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<TodayDelDetailOut> listItems = new List<TodayDelDetailOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new TodayDelDetailOut
                        {
                            prd_ID = dr["odd_itm_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            LowerUOM = dr["LowerUOM"].ToString(),
                            HigherUOM = dr["HigherUOM"].ToString(),
                            LowerQty = dr["odd_LowerQty"].ToString(),
                            HigherQty = dr["odd_HigherQty"].ToString(),
                            Total= dr["odd_GrandTotal"].ToString(),
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
                dm.TraceService(" SelectTodayDelDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectTodayDelDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string TDFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("TDFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString()};
                DataTable dtLoadIn = dm.loadList("TDAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dpa_ID"].ToString(),
                            Name = dr["dpa_Name"].ToString(),


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
                dm.TraceService("TDFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("TDFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string TDFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("TDFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("TDSubAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);


                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dsa_ID"].ToString(),
                            Name = dr["dsa_Name"].ToString(),
                            Code = dr["dsa_Code"].ToString()

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
                dm.TraceService("TDFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("TDFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string TDFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("TDFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("TDRouteFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["rot_ID"].ToString(),
                            Name = dr["rot_Name"].ToString(),
                            Code = dr["rot_Code"].ToString()


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
                dm.TraceService("TDFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService("TDFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string TDFilterCustomer([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" TDFilterCustomer STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString() };
                DataTable dtLoadIn = dm.loadList("TDCustomerFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusFilterOutPut> listItems = new List<CusFilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusFilterOutPut
                        {
                            ID = dr["csh_ID"].ToString(),
                            Name = dr["csh_Name"].ToString(),
                            Code = dr["csh_Code"].ToString(),


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
                dm.TraceService("  PromotionFilterCustomer Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" TDFilterCustomer ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string TDFilterCustomerOutlet([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" TDFilterCustomerOutlet STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                DataTable dtLoadIn = dm.loadList("TDCustomerOutletFilter", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusFilterOutPut> listItems = new List<CusFilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusFilterOutPut
                        {
                            ID = dr["cus_ID"].ToString(),
                            Name = dr["cus_Name"].ToString(),
                            Code = dr["cus_Code"].ToString(),

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
                dm.TraceService("  TDFilterCustomerOutlet Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" TDFilterCustomerOutlet ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}