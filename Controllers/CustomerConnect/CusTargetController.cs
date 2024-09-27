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
    public class CusTargetController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;    
        
        public string TargetHeaderCount([FromForm] CusHeaderChartIn inputParams)
        {
            dm.TraceService("TargetHeaderCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd"); 
                DataTable dtAR = dm.loadList("TargetHeadercounts", "sp_CustomerConnect", Date);
                if (dtAR.Rows.Count > 0)
                {
                    List<CusHeaderChartOut> listItems = new List<CusHeaderChartOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new CusHeaderChartOut
                        {
                            //target amount
                            TotalTargetAmt = dr["TotalTargetAmount"].ToString(),
                            TotalAchAmt = dr["TotalMonthAchAmount"].ToString(),
                            TotalGapAmt= dr["TotalMonthlyGapAmount"].ToString(),

                            //target qty
                            TotalTargetQty = dr["TotalTargetQty"].ToString(),
                            TotalAchQty = dr["TotalMonthAchQty"].ToString(),
                            TotalGapQty = dr["TotalMonthlyGapQty"].ToString(),

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
                dm.TraceService("TargetHeaderCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("TargetHeaderCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString; 
        }
        public string HeaderRouteCount([FromForm] HeaderRotCountIn inputParams)
        {
            dm.TraceService("HeaderRouteCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
                DataTable dtAR = dm.loadList("HeaderRouteCount", "sp_CustomerConnect", Date);
                if (dtAR.Rows.Count > 0)
                {
                    List<HeaderRotCountOut> listItems = new List<HeaderRotCountOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new HeaderRotCountOut
                        {
                            Rotcount = dr["Rotcount"].ToString()

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
                dm.TraceService("HeaderRouteCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("HeaderRouteCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");
            return JSONString;
        }
        public string HeaderRouteWiseTargets([FromForm] CusTargetHeaderIn inputParams)
        {
            dm.TraceService("HeaderRouteWiseTargets STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
                DataTable dtAR = dm.loadList("HeaderRoutetWiseTargets", "sp_CustomerConnect", Date);  
                if (dtAR.Rows.Count > 0)
                {
                    List<CusTargetHeaderOut> listItems = new List<CusTargetHeaderOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new CusTargetHeaderOut
                        {
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            TargetAmt = dr["TargetAmount"].ToString(),
                            TargetQty = dr["TargetQty"].ToString(),
                            AchAmt = dr["MonthAchAmount"].ToString(),
                            AchQty = dr["MonthAchQty"].ToString() ,
                            Arrot_Name = dr["rot_ArabicName"].ToString(),

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
                dm.TraceService("HeaderRouteWiseTargets Exception - " + ex.Message.ToString());
            }
            dm.TraceService("HeaderRouteWiseTargets ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string TargetDaysCount([FromForm] DaysCountIn inputParams)
        {
            dm.TraceService("TargetDaysCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
                string[] arr = { inputParams.rotID };
                DataTable dtAR = dm.loadList("TargetDaysCount", "sp_CustomerConnect", Date, arr);
                if (dtAR.Rows.Count > 0)
                {
                    List<DaysCountOut> listItems = new List<DaysCountOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new DaysCountOut
                        {
                            Month = dr["rmd_Month"].ToString(),
                            TotWorkingDays = dr["rmd_WorkingDays"].ToString(),
                            CompletedDays = dr["cmpltddays"].ToString(),
                            ArMonth = dr["rmd_MonthArabic"].ToString(),

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
                dm.TraceService("TargetDaysCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("TargetDaysCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");
            return JSONString;
        }
        public string TargetDetailAmtCount([FromForm] CusDetailAmtChartIn inputParams)
        {
            dm.TraceService("TargetDetailAmtCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
                string[] arr = { inputParams.rotID };
                DataTable dtAR = dm.loadList("TargetAmtforDetailchart", "sp_CustomerConnect", Date, arr);
                if (dtAR.Rows.Count > 0)
                {
                    List<CusDetailAmtChartOut> listItems = new List<CusDetailAmtChartOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new CusDetailAmtChartOut
                        {                           
                            TotalAmt = dr["TargetAmount"].ToString(),
                            AchAmt = dr["MonthAchAmount"].ToString(),
                            MTDGapAmt = dr["MTDGapAmt"].ToString(),
                            MonthGapAmt = dr["monthlygapamnt"].ToString()                         

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
                dm.TraceService("TargetDetailAmtCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("TargetDetailAmtCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string TargetDetailQtyCount([FromForm] CusDetailQtyChartIn inputParams)
        {
            dm.TraceService("TargetDetailQtyCount STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
                string[] arr = { inputParams.rotID };

                DataTable dtAR = dm.loadList("TargetQtyforDetailchart", "sp_CustomerConnect", Date, arr);
                if (dtAR.Rows.Count > 0)
                {
                    List<CusDetailQtyChartOut> listItems = new List<CusDetailQtyChartOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new CusDetailQtyChartOut
                        {
                            TotalQty = dr["TargetQty"].ToString(),
                            AchQty = dr["MonthAchQty"].ToString(),
                            MTDGapQty = dr["MTDGapQty"].ToString(),
                            MonthGapQty = dr["MonthlyGapQty"].ToString()

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
                dm.TraceService("TargetDetailQtyCount Exception - " + ex.Message.ToString());
            }
            dm.TraceService("TargetDetailQtyCount ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string RouteWiseTargetDetail([FromForm] CusTargetDetailIn inputParams)
        {
            dm.TraceService("RouteWiseTargetDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
                string[] arr = { inputParams.rotID };

                DataTable dtAR = dm.loadList("RouteWiseTargetDetail", "sp_CustomerConnect", Date, arr);
                if (dtAR.Rows.Count > 0)
                {
                    List<CusTargetDetailOut> listItems = new List<CusTargetDetailOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new CusTargetDetailOut
                        {
                            pkgID = dr["ID"].ToString(),
                            pkgName = dr["tph_Name"].ToString(),
                            TargetAmt = dr["TargetAmount"].ToString(),
                            TargetQty = dr["TargetQty"].ToString(),
                            AchAmt = dr["MonthAchAmount"].ToString(),
                            AchQty = dr["MonthAchQty"].ToString(),
                            AchAmtPerc = dr["AmountPerc"].ToString(),
                            AchQtyPerc = dr["MonthAchQtyPerc"].ToString(),
                            MTDGapAmt = dr["MTDGapAmt"].ToString(),
                            MTDGapQty = dr["MTDGapQty"].ToString(),
                            MonthGapAmt = dr["MonthlyGapAmount"].ToString(),
                            MonthGapQty = dr["MonthlyGapQty"].ToString(),
                            MonthGapAmtPerc = dr["gapAmountPerc"].ToString(),
                            MonthGapQtyPerc = dr["MonthlyGapQtyPerc"].ToString(),
                            ArpkgName = dr["tph_NameArabic"].ToString(),

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
                dm.TraceService("RouteWiseTargetDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("RouteWiseTargetDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string RouteWisePackageDetail([FromForm] CusTargetPkgDetailIn inputParams)
        {
            dm.TraceService("RouteWisePackageDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.FromDate.ToString()).ToString("yyyyMMdd");
                string[] arr = { Date, inputParams.rotID,  };

                DataTable dtAR = dm.loadList("RouteWisePackageDetail", "sp_CustomerConnect", inputParams.pkgID, arr);
                if (dtAR.Rows.Count > 0)
                {
                    List<CusTargetPkgDetailOut> listItems = new List<CusTargetPkgDetailOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new CusTargetPkgDetailOut
                        {
                            prdID = dr["prd_ID"].ToString(),
                            prdCode = dr["prd_Code"].ToString(),
                            prdName = dr["prd_Name"].ToString(),
                            AchAmt = dr["AchievedAmount"].ToString(),
                            AchQty = dr["AchievedQty"].ToString(),
                            ArprdName = dr["prd_NameArabic"].ToString(),

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
                dm.TraceService("RouteWisePackageDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("RouteWisePackageDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


    }
}