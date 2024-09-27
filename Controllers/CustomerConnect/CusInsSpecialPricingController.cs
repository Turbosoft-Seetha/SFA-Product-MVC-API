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
using static MVC_API.Models.CustomerConnectHelper.CusInsightHelper;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.CustomerConnect
{
    public class CusInsSpecialPricingController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectCusSPecPricingHeader([FromForm] CusSpecialPricingIn inputParams)
        {
            dm.TraceService("SelectCusSPecPricingHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {

                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                
                string RouteCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
               

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
                



                



                string[] arr = {  RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString(),FromDate.ToString(),ToDate.ToString() };


                DataTable dtLoadIn = dm.loadList("CusSpecialPriceHeader", "sp_CustomerConnect", CusID.ToString(), arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusSpecialPricingOUt> listItems = new List<CusSpecialPricingOUt>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusSpecialPricingOUt
                        {

                            prh_ID = dr["prh_ID"].ToString(),
                            prh_Code = dr["prh_Code"].ToString(),
                            prh_Name = dr["prh_Name"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            prh_PayMode = dr["prh_PayMode"].ToString(),
                            Arprh_Name = dr["prh_NameArabic"].ToString()


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
                dm.TraceService(" SelectCusSPecPricingHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCusSPecPricingHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
       
        //Filter DropDown
        public string SelectAreaForCusSpecialPrice([FromForm] AreaSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectAreaForCusSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(),CusID };
                DataTable dt = dm.loadList("SelAreaForCusSpecialPrice", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<AreaSpecialPriceOut> listItems = new List<AreaSpecialPriceOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new AreaSpecialPriceOut
                        {
                            AreaID = dr["AreaID"].ToString(),
                            Area = dr["Area"].ToString(),
                            AreaCode = dr["dpa_Code"].ToString(),

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
                dm.TraceService("SelectAreaForCusSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForCusSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForCusSpecialPrice([FromForm] SubAreaSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectSubAreaForCusSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), AreaID,CusID };
                DataTable dt = dm.loadList("SelSubAreaForCusSpecialPrice", "sp_CustomerConnect", UserID.ToString(), arr);

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
                dm.TraceService("SelectSubAreaForCusSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForCusSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForCusSpecialPrice([FromForm] RouteSpecialPriceIn inputParams)
        {
            dm.TraceService("SelectRouteForCusSpecialPrice STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), SubAreaID,CusID };
                DataTable dt = dm.loadList("SelRouteForCusSpecialPrice", "sp_CustomerConnect", UserID.ToString(), arr);

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
                dm.TraceService("SelectRouteForCusSpecialPrice Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForCusSpecialPrice ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

    }
}