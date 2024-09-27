using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.ApprovalHelper;
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
using System.Web.Security;
using System.Web.UI.WebControls;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;


namespace MVC_API.Controllers.CustomerConnect
{
    public class HomeController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string AppLogin([FromForm] LoginIn inputParams)
        {
            dm.TraceService("AppLogin STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Username = inputParams.Username == null ? "0" : inputParams.Username;
                string Password = inputParams.Password == null ? "0" : inputParams.Password;

                if (Membership.ValidateUser(inputParams.Username, inputParams.Password))
                {
                    string[] arr = { Password.ToString() };

                    DataTable dtLogin = dm.loadList("AppLogin", "sp_CustomerConnect", Username.ToString(), arr);

                    if (dtLogin.Rows.Count > 0)
                    {
                        List<LoginOut> listItems = new List<LoginOut>();
                        foreach (DataRow dr in dtLogin.Rows)
                        {

                            listItems.Add(new LoginOut
                            {
                                FirstName = dr["FirstName"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Email = dr["Email"].ToString(),
                                ContacInfo = dr["ContacInfo"].ToString(),
                                usrID = dr["usrID"].ToString(),
                                UserName = dr["UserName"].ToString(),
                                NewUser = dr["NewUser"].ToString(),
                                Title = dr["Title"].ToString(),
                                Descr = dr["Descr"].ToString(),
                                VersionDate = dr["VersionDate"].ToString(),
                                ArFirstName = dr["ArFirstName"].ToString(),
                                ArLastName = dr["ArLastName"].ToString(),

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
                else
                {

                    List<LoginOut> listItems = new List<LoginOut>();
                    listItems.Add(new LoginOut
                            {
                                FirstName = "",
                                LastName = "",
                                Email = "",
                                ContacInfo = "",
                                usrID = "",
                                UserName = "",
                                NewUser = "",
                                Title = "Failure",
                                Descr = "Invalid User Credentials",
                                VersionDate = "",
                            });
                        

                        string JSONString = JsonConvert.SerializeObject(new
                        {
                            result = listItems
                        });

                        return JSONString;
                    
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(" AppLogin Exception - " + ex.Message.ToString());
            }
            dm.TraceService("AppLogin ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string SelectTotalPickingAndLoadInCounts()
        {
            dm.TraceService("SelectTotalPickingandLoadInCounts STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                DataTable dtLogin = dm.loadList("PickingAndLoadInCount", "sp_CustomerConnect");


                

                if (dtLogin.Rows.Count > 0)
                {
                    List<Counts> listItems = new List<Counts>();


                    
                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        listItems.Add(new Counts
                        {
                            PickingTotal = dr["LoginpickTotalCount"].ToString(),
                            PickingNotStarted = dr["PickingNotStartedCount"].ToString(),
                            PickingNotStartedRoute = dr["PickingNotStartedRouteCount"].ToString(),
                            PickingOngoing = dr["PickingOngoingCount"].ToString(),
                            PickingOngoingRoute = dr["PickingOngoingRouteCount"].ToString(),
                            PickingCompleted = dr["PickingCompletedCount"].ToString(),
                            PickingCompletedRoute = dr["PickingCompletedRouteCount"].ToString(),

                            LoadInTotal = dr["LoadInTotalCount"].ToString(),
                            LoadInPending = dr["LoadInPendingCount"].ToString(),
                            LoadInPendingRoute = dr["LoadInPendingRouteCount"].ToString(),
                            LoadInCompleted = dr["LoadInCompletedCount"].ToString(),
                            LoadInCompletedRoute = dr["LoadInCompletedRouteCount"].ToString(),
                            LoadInCancelled = dr["LoadInCancelledCount"].ToString(),
                            LoadInCancelledRoute = dr["LoadInCancelledRouteCount"].ToString(),

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
                dm.TraceService(" SelectDashboardCounts Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectDashboardCounts ENDED - " + DateTime.Now);
            dm.TraceService("==================");

            return JSONString;
        }
        public string SelectCustomerTransactionCounts()
        {
            dm.TraceService("SelectCustomerTransactionCounts STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                DataTable dtLogin = dm.loadList("CustomerTransactionCount", "sp_CustomerConnect");




                if (dtLogin.Rows.Count > 0)
                {
                    List<CusTrnCounts> listItems = new List<CusTrnCounts>();



                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        listItems.Add(new CusTrnCounts
                        {
                            CusTrnInvoice = dr["CusTrnInvoiceCount"].ToString(),
                            CusTrnARCollection = dr["CusTrnARCollectionCount"].ToString(),
                            InvoiceAmount = dr["InvoiceAmount"].ToString(),
                            ARAmount = dr["ARAmount"].ToString()


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
                dm.TraceService(" SelectCustomerTransactionCounts Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCustomerTransactionCounts ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string SelectSalesOrdersCounts()
        {
            dm.TraceService("SelectSalesOrdersCounts STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                DataTable dtLogin = dm.loadList("SalesOrdersCount", "sp_CustomerConnect");




                if (dtLogin.Rows.Count > 0)
                {
                    List<SalesOrdersCount> listItems = new List<SalesOrdersCount>();



                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        listItems.Add(new SalesOrdersCount
                        {
                            TotalOrders = dr["TotalOrdersCount"].ToString(),
                            TodayDel = dr["TodayDelCount"].ToString(),
                            TodayDelTot= dr["TodayDelTotCount"].ToString(),
                            TotalOrdersAmount = dr["TotalOrdersAmount"].ToString(),
                            TodayDelAmount = dr["TodayDelAmount"].ToString()



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
                dm.TraceService(" SelectSalesOrdersCounts Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSalesOrdersCounts ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectServiceModuleCounts()
        {
            dm.TraceService("SelectServiceModuleCounts STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                DataTable dtLogin = dm.loadList("ServiceModuleCount", "sp_CustomerConnect");




                if (dtLogin.Rows.Count > 0)
                {
                    List<ServiceModuleCount> listItems = new List<ServiceModuleCount>();



                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        listItems.Add(new ServiceModuleCount
                        {
                            ServiceModuleCompleted = dr["ServiceModuleCompletedCount"].ToString(),
                            ServiceModuleInvoice = dr["ServiceModuleInvoiceCount"].ToString(),
                            ServiceModulePending = dr["ServiceModulePendingCount"].ToString()

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
                dm.TraceService(" SelectServiceModuleCounts Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectServiceModuleCounts ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


        public string GetRoute()
        {
            dm.TraceService("GetRoute STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            DataTable dt = dm.loadList("SelectRouteforReturnSC", "sp_Approvals");

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetRouteOut> listHeader = new List<GetRouteOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetRouteOut
                        {
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Name = dr["rot_Name"].ToString()




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
                dm.TraceService("GetRoute  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetRoute ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetUsers()
        {
            dm.TraceService("GetUsers STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            DataTable dt = dm.loadList("SelectUsers", "sp_CustomerConnect");

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetUsersOut> listHeader = new List<GetUsersOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetUsersOut
                        {
                            ID = dr["usr_ID"].ToString(),
                            Name = dr["usr_Name"].ToString()
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
                dm.TraceService("GetUsers  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetUsers ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }
}