using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNetCore.Mvc;
using MultipartDataMediaFormatter.Infrastructure;
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

namespace MVC_API.Controllers.Customer_Connect
{
    public class InsightGeoLocationController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]

        public string CusInsightGeolocationHeader([FromForm] CusInGeolocation inputParams)
        {
            dm.TraceService("CusInsightGeolocationHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;


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

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(), cus_ID.ToString() };
                DataTable dt = dm.loadList("SelCusInsightGeolocation", "sp_CustomerConnect", UserID.ToString(), arr);
                string[] mapurl = { "http://maps.google.com?q=" };
                string geolocurl = "";

                if (dt.Rows.Count > 0)
                {
                    List<CusOutGeolocation> listItems = new List<CusOutGeolocation>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new CusOutGeolocation
                        {
                            cgl_ID = dr["cgl_ID"].ToString(),
                            cgl_CusGeoLoc = dr["cgl_CusGeoLoc"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            usr_Code = dr["usr_Code"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            cus_GeoCode = dr["cus_GeoCode"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            geolocurl = mapurl.ToString() + dr["cgl_CusGeoLoc"].ToString(),
                            Status = dr["Status"].ToString(),
                            usr_ArName = dr["usr_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString()

                        }); ;
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
                dm.TraceService("CusInsightGeolocationHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusInsightGeolocationHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string UpdateCustomerGeoLocation([FromForm] CusInUpdateGeolocationIn inputParams)
        {
            dm.TraceService("UpdateCustomerGeoLocation STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string cgl_CusGeoLoc = inputParams.cgl_CusGeoLoc == null ? "0" : inputParams.cgl_CusGeoLoc;
                string cgl_ID = inputParams.cgl_ID == null ? "0" : inputParams.cgl_ID;

                string[] arr = { cus_ID.ToString() };
                DataTable dt = dm.loadList("UpdateCustomerGeoLocation", "sp_CustomerConnect", cus_ID.ToString() , arr);

                if (dt.Rows.Count > 0)
                {
                    List<CusInUpdateGeolocationOut> listItems = new List<CusInUpdateGeolocationOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new CusInUpdateGeolocationOut
                        {
                          
                            Res = dr["Res"].ToString(),
                            Title = dr["Title"].ToString(),
                            Descr = dr["Descr"].ToString(),
                            ArTitle = dr["ArTitle"].ToString()

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
                dm.TraceService("UpdateCustomerGeoLocation Exception - " + ex.Message.ToString());
            }
            dm.TraceService("UpdateCustomerGeoLocation ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

    }
}