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
    public class CusChartDashboardController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

      
        public string GetCCRouteCount([FromForm] CCRouteCountIn inputParams)
        {
            dm.TraceService("GetCCRouteCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetRouteCounts", "sp_CustomerConnectDashboard", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCRouteCountOut> listHeader = new List<CCRouteCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCRouteCountOut
                        {

                            Active = dr["active"].ToString(),
                            DaysStarted = dr["DaysStarted"].ToString(),
                            DaysNotStarted = dr["notStarted"].ToString()

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
                dm.TraceService("GetCCRouteCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCRouteCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCPlanVisitCount([FromForm] CCPlanVisitCountIn inputParams)
        {
            dm.TraceService("GetCCPlanVisitCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetPlannedVisitCounts", "sp_CustomerConnectDashboard", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCPlanVisitCountOut> listHeader = new List<CCPlanVisitCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCPlanVisitCountOut
                        {

                            Pending = dr["pending"].ToString(),
                            Visited = dr["visited"].ToString(),
                            Planned = dr["total"].ToString()

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
                dm.TraceService("GetCCPlanVisitCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCPlanVisitCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCActualVisitCount([FromForm] CCActualVisitCountIn inputParams)
        {
            dm.TraceService("GetCCActualVisitCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetActualVisitCounts", "sp_CustomerConnectDashboard", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCActualVisitCountOut> listHeader = new List<CCActualVisitCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCActualVisitCountOut
                        {

                            Planned = dr["Planned"].ToString(),
                            Unplanned = dr["Unplanned"].ToString(),
                            Total = dr["Total"].ToString()

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
                dm.TraceService("GetCCActualVisitCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCActualVisitCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCProductiveVisitCount([FromForm] CCProdVisitCountIn inputParams)
        {
            dm.TraceService("GetCCProductiveVisitCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetProdVisitCounts", "sp_CustomerConnectDashboard", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCProdVisitCountOut> listHeader = new List<CCProdVisitCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCProdVisitCountOut
                        {

                            Planned = dr["ScheduledProdVisits"].ToString(),
                            Unplanned = dr["UnscheduledProdVisits"].ToString(),
                            Total = dr["TotalProdVisits"].ToString()

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
                dm.TraceService("GetCCProductiveVisitCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCProductiveVisitCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCCNonProductiveVisitCount([FromForm] CCNonProdVisitCountIn inputParams)
        {
            dm.TraceService("GetCCNonProductiveVisitCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string FromDate = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
            string ToDate = DateTime.Parse(inputParams.ToDate.ToString()).ToString("yyyyMMdd");

            string[] arr = { ToDate.ToString() };

            DataTable dt = dm.loadList("GetNonProdVisitCounts", "sp_CustomerConnectDashboard", FromDate, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<CCNonProdVisitCountOut> listHeader = new List<CCNonProdVisitCountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCNonProdVisitCountOut
                        {

                            Planned = dr["ScheduledNonProdVisits"].ToString(),
                            Unplanned = dr["UnscheduledNonProdVisits"].ToString(),
                            Total = dr["TotalNonProdVisits"].ToString()

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
                dm.TraceService("GetCCNonProductiveVisitCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCCNonProductiveVisitCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


    }
}