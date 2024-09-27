using Microsoft.AspNetCore.Mvc;
using MultipartDataMediaFormatter.Infrastructure;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using static MVC_API.Models.CusInsightARHelper;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;


namespace MVC_API.Controllers.Customer_Connect
{
    public class CusInsightARController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]

        public string CusInsigntARHeader([FromForm] InsCusInsightARHeader inputParams)
        {

            try
            {


                dm.TraceService("CusInsigntARHeader STARTED " + DateTime.Now);
                dm.TraceService("==============================");
                string USRID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string FromDate = inputParams.From_Date == null ? "0" : inputParams.From_Date;
                string ToDate = inputParams.To_Date == null ? "0" : inputParams.To_Date;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;


                string MainCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string RouteCondition = "";

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

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;

                string[] arry = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(), cus_ID.ToString() };
                DataTable dtDN = dm.loadList("SelCusInsightARHeader", "sp_CustomerConnect", USRID.ToString(), arry);
                if (dtDN.Rows.Count > 0)
                {
                    List<OutCusInsightARHeader> listDn = new List<OutCusInsightARHeader>();
                    foreach (DataRow dr in dtDN.Rows)
                    {
                        listDn.Add(new OutCusInsightARHeader
                        {
                            arh_ID = dr["arh_ID"].ToString(),
                            arh_ARNumber = dr["arh_ARNumber"].ToString(),
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
                            PayMode = dr["arh_PayMode"].ToString(),
                            PayType = dr["arh_PayType"].ToString(),
                            CollectedAmount = dr["arh_CollectedAmount"].ToString(),
                            BalanceAmount = dr["arh_BalanceAmount"].ToString(),
                            ChequeNo = dr["arp_ChequeNo"].ToString(),
                            ChequeDate = dr["arp_ChequeDate"].ToString(),
                            arp_Image1 = dr["arp_Image1"].ToString(),
                            bank_Name = dr["bnk_Name"].ToString(),
                            ArPayMode = dr["ArPayMode"].ToString(),
                            Arbank_Name = dr["bnk_NameArabic"].ToString(),
                            Arcsh_Name = dr["csh_NameArabic"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString()

                        });
                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listDn
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                    dm.TraceService("NoDataRes");
                }
            }

            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService("CusInsigntARHeader Exception - " + ex.Message.ToString());
            }


            dm.TraceService("CusInsigntARHeader ENDED " + DateTime.Now);
            dm.TraceService("==========================");
            return JSONString;
        }

        public string CusInsigntARCollectionCount([FromForm] InsCusInsightARCount inputParams)
        {
            try
            {



                dm.TraceService("CusInsigntARCollectionCount STARTED " + DateTime.Now);
                dm.TraceService("==============================");
                string USRID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string From = inputParams.From_Date == null ? "0" : inputParams.From_Date;
                string To = inputParams.To_Date == null ? "0" : inputParams.To_Date;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;


                string MainCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string RouteCondition = "";

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

                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;


                string[] arry = { From.ToString(), To.ToString(), MainCondition.ToString(), cus_ID.ToString() };

                DataTable dtDN = dm.loadList("SelCusInsightARCollectionCount", "sp_CustomerConnect", USRID.ToString(), arry);
                if (dtDN.Rows.Count > 0)
                {
                    List<OutCusInsightARCount> listDn = new List<OutCusInsightARCount>();
                    foreach (DataRow dr in dtDN.Rows)
                    {
                        listDn.Add(new OutCusInsightARCount
                        {
                            Total_Count = dr["Total_Count"].ToString(),
                            HC_Count = dr["HC_Count"].ToString(),
                            POS_Count = dr["POS_Count"].ToString(),
                            Cheque_Count = dr["Cheque_Count"].ToString(),
                            OP_Count = dr["OP_Count"].ToString(),
                            Total_Amount = dr["Total_Amount"].ToString(),
                            HC_Amount = dr["HC_Amount"].ToString(),
                            POS_Amount = dr["POS_Amount"].ToString(),
                            Cheque_Amount = dr["Cheque_Amount"].ToString(),
                            OP_Amount = dr["OP_Amount"].ToString(),




                        });
                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listDn
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                    dm.TraceService("NoDataRes");
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService("CusInsigntARCollectionCount Exception - " + ex.Message.ToString());
            }

            dm.TraceService("CusInsigntARCollectionCount ENDED " + DateTime.Now);
            dm.TraceService("==========================");
            return JSONString;
        }
        public string SelectAreaForARCus([FromForm] AreaARIn inputParams)
        {
            dm.TraceService("SelectAreaForARCus STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), CusID };
                DataTable dtAR = dm.loadList("SelAreaForARCus", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<AreaAROut> listItems = new List<AreaAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new AreaAROut
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
                dm.TraceService("SelectAreaForARCus Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForARCus ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForARCus([FromForm] SubAreaARIn inputParams)
        {
            dm.TraceService("SelectSubAreaForARCus STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), AreaID, CusID };
                DataTable dtAR = dm.loadList("SelSubAreaForARCus", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<SubAreaAROut> listItems = new List<SubAreaAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new SubAreaAROut
                        {
                            SubAreaID = dr["SubAreaID"].ToString(),
                            SubArea = dr["SubArea"].ToString(),
                            SubAreaCode = dr["dsa_Code"].ToString()

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
                dm.TraceService("SelectSubAreaForARCus Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForARCus ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForCusAR([FromForm] RouteARIn inputParams)
        {
            dm.TraceService("SelectRouteForCusAR STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), SubAreaID,CusID };
                DataTable dtAR = dm.loadList("SelRouteForARCus", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<RouteAROut> listItems = new List<RouteAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new RouteAROut
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
                dm.TraceService("SelectRouteForCusAR Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForCusAR ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}