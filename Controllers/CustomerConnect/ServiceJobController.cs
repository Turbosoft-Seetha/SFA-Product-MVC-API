using Microsoft.AspNetCore.Mvc;
using MVC_API.FE_NAV_Service;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers
{

    public class ServiceJobController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectServiceJobCompletedHeader([FromForm] SJCompletedIn inputParams)
        {
            dm.TraceService("SelectServiceJobCompletedHeader STARTED -" + DateTime.Now);
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
                if (inputParams.Customer != null)
                {
                    CusCondition = " and C.cus_ID in( " + inputParams.Customer + ")";
                }
                if (inputParams.CusOutlet != null)
                {
                    CusOutCondition = " and CH.csh_ID in( " + inputParams.CusOutlet + ")";
                }

                string dateCondition = " And (cast(S.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";



                string[] arr = { dateCondition.ToString(), RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString(),CusCondition.ToString(),CusOutCondition.ToString() };

                DataTable dtLoadIn = dm.loadList("ServiceJobCompleted", "sp_CustomerConnect", "'"+Mode+"'", arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<SJCompletedOut> listItems = new List<SJCompletedOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new SJCompletedOut
                        {

                            SJCode = dr["snr_Code"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            cusName = dr["csh_Name"].ToString(),
                            cusCode = dr["csh_Code"].ToString(),
                            cusOutName = dr["cus_Name"].ToString(),
                            cusOutCode = dr["cus_Code"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            sjh_ID = dr["sjh_ID"].ToString(),
                            snr_ID = dr["snr_ID"].ToString(),
                            salesman= dr["Salesman"].ToString(),
                            PName= dr["prd_Name"].ToString(),




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
                dm.TraceService(" SelectServiceJobCompletedHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectServiceJobCompletedHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SJFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("SJFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("SJAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dpa_ID"].ToString(),
                            Name = dr["dpa_Name"].ToString(),
                            Code = dr["dpa_Code"].ToString()


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
                dm.TraceService("SJFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SJFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SJFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("SJFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("SJSubAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);


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
                dm.TraceService("SJFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SJFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SJFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("SJFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("SJRouteFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

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
                dm.TraceService("SJFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SJFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SJFilterCustomer([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("SJFilterCustomer STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString() };
                DataTable dtLoadIn = dm.loadList("SJCustomerFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["cus_ID"].ToString(),
                            Name = dr["cus_Name"].ToString(),
                            Code = dr["cus_Code"].ToString()

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
                dm.TraceService("  SJFilterCustomer Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" SJFilterCustomer ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SJFilterCustomerOutlet([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" SJFilterCustomerOutlet STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("SJCustomerHeaderFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["csh_ID"].ToString(),
                            Name = dr["csh_Name"].ToString(),
                            Code = dr["csh_Code"].ToString()


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
                dm.TraceService("SJFilterCustomerOutlet Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SJFilterCustomerOutlet ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}