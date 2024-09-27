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
    public class CusActReviewController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;    
        
        public string ActReviewHeaderList([FromForm] ActReviewHeaderListIn inputParams)
        {
            dm.TraceService("ActReviewHeaderList STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rotType = inputParams.rotType == null ? "0" : inputParams.rotType;
                DataTable dtAR = dm.loadList("SelActReviewHeaderList", "sp_CustomerConnect", rotType);
                if (dtAR.Rows.Count > 0)
                {
                    List<ActReviewHeaderListOut> listItems = new List<ActReviewHeaderListOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new ActReviewHeaderListOut
                        {                         
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Type = dr["Type"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            StartTime = dr["udp_StartTime"].ToString(),
                            EndTime = dr["udp_EndTime"].ToString(),
                            udpID= dr["udp_ID"].ToString(),
                            duration = dr["Duration"].ToString(),
                            rot_ArName = dr["rot_ArabicName"].ToString(),
                            rot_ArType = dr["ArType"].ToString(),
                            usr_ArName = dr["usr_ArabicName"].ToString()
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
                dm.TraceService("ActReviewHeaderList Exception - " + ex.Message.ToString());
            }
            dm.TraceService("ActReviewHeaderList ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString; 
        }
        public string ActReviewDetailChartData([FromForm] ActReviewDetailChartDataIn inputParams)
        {
            dm.TraceService("ActReviewDetailChartData STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                DataTable dtAR = dm.loadList("SelActReviewDetailChartData", "sp_CustomerConnect", udpID);
                if (dtAR.Rows.Count > 0)
                {
                    List<ActReviewDetailChartDataOut> listItems = new List<ActReviewDetailChartDataOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new ActReviewDetailChartDataOut
                        {
                            TotTargetAmt = dr["TotalTargetAmount"].ToString(),
                            ProRateTarget = dr["MTD_AMT"].ToString(),
                            SalPerDay = dr["Target_PerDayAmt"].ToString(),
                            MTDWrkDays = dr["WorkedDays"].ToString(),
                            TotWrkDays = dr["rmd_WorkingDays"].ToString(),
                            MTDSales = dr["TotalMonthAchAmount"].ToString(),
                            ExcShtg = dr["excessorshort"].ToString()
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
                dm.TraceService("ActReviewDetailChartData Exception - " + ex.Message.ToString());
            }
            dm.TraceService("ActReviewDetailChartData ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string ActRevTodaysSaleData([FromForm] ActRevTodaysSalesIn inputParams)
        {
            dm.TraceService("ActRevTodaysSaleData STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                DataTable dtAR = dm.loadList("SelTodaysSalesData", "sp_CustomerConnect", udpID);
                if (dtAR.Rows.Count > 0)
                {
                    List<ActRevTodaysSalesOut> listItems = new List<ActRevTodaysSalesOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new ActRevTodaysSalesOut
                        {
                            SalesAmt = dr["invoiceSum"].ToString(),
                            TotVisits = dr["totVisits"].ToString(),
                            ProdVisits = dr["ProdVisits"].ToString()
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
                dm.TraceService("ActRevTodaysSaleData Exception - " + ex.Message.ToString());
            }
            dm.TraceService("ActRevTodaysSaleData ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }        
        public string ActRevDetailVisitData([FromForm] ActRevTotalDataIn inputParams)
        {
            dm.TraceService("ActRevDetailVisitData STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                DataTable dtAR = dm.loadList("SelDailyActivityVisitData", "sp_CustomerConnect", udpID);
                if (dtAR.Rows.Count > 0)
                {
                    List<ActRevTotalDataOut> listItems = new List<ActRevTotalDataOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new ActRevTotalDataOut
                        {
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            StartTime = dr["cse_StartTime"].ToString(),
                            EndTime = dr["cse_EndTime"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            SalesCS = dr["TotalSalCS"].ToString(),
                            SaleCR = dr["TotalSalCR"].ToString(),
                            ReturnCS = dr["TotalrtnCS"].ToString(),
                            ReturnCR = dr["TotalrtnCR"].ToString(),
                            CollectCS = dr["TotalARCS"].ToString(),
                            CollectCR = dr["TotalARCH"].ToString(),
                            TotSalesCS = dr["finalTotalSal_CS"].ToString(),
                            TotSaleCR = dr["finalTotalSal_CR"].ToString(),
                            TotReturnCS = dr["finalTotalrtn_CS"].ToString(),
                            TotReturnCR = dr["finalTotalrtn_CR"].ToString(),
                            TotCollectCS = dr["finalTotalAR_CS"].ToString(),
                            TotCollectCR = dr["finalTotalAR_CH"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString()


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
                dm.TraceService("ActRevDetailVisitData Exception - " + ex.Message.ToString());
            }
            dm.TraceService("ActRevDetailVisitData ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
      

    }
}