using Microsoft.AspNetCore.Mvc;
using MVC_API.Models.CustomerConnectHelper;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class TargetController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [System.Web.Http.HttpPost]
        public string SelectTargetSummaryMTD([FromForm] TargetIn inputParams)
        {
            dm.TraceService("SelectLoadInHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {



                DataTable dtLoadIn = dm.loadList("selPackSummHeadMTD", "sp_TargetDashboard", inputParams.Route);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<TargetOut> listItems = new List<TargetOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new TargetOut
                        {
                            TargetQty=dr["TargetQty"].ToString(),
                            TargetAmount = dr["TargetAmount"].ToString(),
                            AchievedQty = dr["AchievedQty"].ToString(),
                            AchievedAmount = dr["AchievedAmount"].ToString(),
                            AmountPerc = dr["AmountPerc"].ToString(),
                            QtyPerc = dr["QtyPerc"].ToString(),
                            RemQty = dr["RemQty"].ToString(),
                            RemAmount = dr["RemAmount"].ToString(),
                            RemAmountPerc = dr["RemAmountPerc"].ToString(),
                            RemQtyPerc = dr["RemQtyPerc"].ToString()

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
                dm.TraceService(" SelectLoadInHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectLoadInHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectTargetSummaryMTDHeader([FromForm] TargetIn inputParams)
        {
            dm.TraceService("SelectTargetSummaryMTDHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {



                DataTable dtLoadIn = dm.loadList("selTargetMTDheader", "sp_TargetDashboard", inputParams.Route);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<TargetHeaderOut> listItems = new List<TargetHeaderOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new TargetHeaderOut
                        {
                            month = dr["rmd_Month"].ToString(),
                            TotwrkDays = dr["rmd_WorkingDays"].ToString(),
                            CmpltdwrkDays = dr["cmpltddays"].ToString()
                          

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
                dm.TraceService(" SelectTargetSummaryMTDHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectTargetSummaryMTDHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectTargetSummaryMTDDetails([FromForm] TargetdetailIn inputParams)
        {
            dm.TraceService("SelectTargetSummaryMTDDetails STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                //string date =DateTime.Parse(inputParams.fromdate.ToString()).ToString("yyyyMMdd");

                string[] arr = { inputParams.Route };
                DataTable dtLoadIn = dm.loadList("RouteWiseTargetPackageDetails", "sp_TargetDashboard", inputParams.fromdate, arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<TargetDetailOut> listItems = new List<TargetDetailOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new TargetDetailOut
                        {
                            targetAmnt = dr["TargetAmount"].ToString(),
                            AchvdAmnt = dr["MonthAchAmount"].ToString(),
                            MonthlyGapAmnt = dr["MonthlyGapAmount"].ToString(),
                            MTDGapAmnt = dr["MTDGapAmt"].ToString(),
                            targetQty = dr["TargetQty"].ToString(),
                            AchvdQty = dr["MonthAchQty"].ToString(),
                            MonthlyGapQty = dr["MonthlyGapQty"].ToString(),
                            MTDGapQty = dr["MTDGapQty"].ToString(),
                            AchvdAmntPer = dr["AmountPerc"].ToString(),
                            MonthlyGapAmntper = dr["gapAmountPerc"].ToString(),
                            AchvdQtyper = dr["MonthAchQtyPerc"].ToString(),
                            MonthlyGapQtyper = dr["MonthlyGapQtyPerc"].ToString(),
                            MTDGapAmntper = dr["MTDGapAmtperc"].ToString(),
                            MTDGapQtyper = dr["MTDGapQtyPerc"].ToString()

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
                dm.TraceService(" SelectTargetSummaryMTDDetails Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectTargetSummaryMTDDetails ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectTargetPackageSummaryMTDDetails([FromForm] TargetdetailIn inputParams)
        {
            dm.TraceService("SelectTargetPackageSummaryMTDDetails STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                //string date = DateTime.Parse(inputParams.fromdate.ToString()).ToString("yyyyMMdd");

                string[] arr = { inputParams.Route };
                DataTable dtLoadIn = dm.loadList("RouteWiseTargetPackageSummaryBYID", "sp_TargetDashboard", inputParams.fromdate, arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<TargetPackageOut> listItems = new List<TargetPackageOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new TargetPackageOut
                        {
                            packageNo = dr["tph_Number"].ToString(),
                            package = dr["tph_Name"].ToString(),
                            MTDGapAmnt = dr["MTDGapAmt"].ToString(),
                            MonthlygapAmnt = dr["MonthlyGapAmount"].ToString(),
                            AchvdQty = dr["MonthAchQty"].ToString(),
                            AchvdQtyper = dr["MonthAchQtyPerc"].ToString(),
                            MTDGapQty = dr["MTDGapQty"].ToString(),
                            MonthlyGapQty = dr["MonthlyGapQty"].ToString(),
                            MonthlyGapQtyper =dr["MonthlyGapQtyPerc"].ToString(),
                            targetQty = dr["TargetQty"].ToString(),
                            targetAmnt = dr["TargetAmount"].ToString(),
                            AchvdAmnt = dr["MonthAchAmount"].ToString(),
                            AchvdAmntper = dr["AmountPerc"].ToString(),
                            MonthlygapAmntper = dr["gapAmountPerc"].ToString(),
                            ItemCount = dr["itmCount"].ToString(),
                            pkgId = dr["ID"].ToString(),
                            MTDGapAmntper = dr["MTDGapAmtperc"].ToString(),
                            MTDGapQtyper = dr["MTDGapQtyPerc"].ToString()

                        }) ; 
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
                dm.TraceService(" SelectTargetSummaryMTDDetails Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectTargetSummaryMTDDetails ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
    }
}