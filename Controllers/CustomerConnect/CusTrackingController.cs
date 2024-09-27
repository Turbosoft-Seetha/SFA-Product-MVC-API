using Microsoft.AspNetCore.Mvc;
using MultipartDataMediaFormatter.Infrastructure;
using MVC_API.FE_NAV_Service;
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
    public class CusTrackingController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;    
        
        public string GetTrackingDetails([FromForm] TrackingIn inputParams)
        {
            dm.TraceService("GetTrackingDetails STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.Date.ToString()).ToString("yyyyMMdd");
                string rotID = inputParams.rotID;
                string[] arr = {Date.ToString() };

                DataTable dtAR = dm.loadList("SelectRouteActivity", "sp_Map_CustomerVisit", rotID, arr);
                if (dtAR.Rows.Count > 0)
                {
                    List<TrackingOut> listItems = new List<TrackingOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new TrackingOut
                        {
                           
                            Customer = dr["cus_Name"].ToString(),
                            Duration = dr["duration"].ToString(),
                            Date= dr["CreatedDate"].ToString(),
                            Time = dr["CreatedTime"].ToString(),
                            MoveStatus = dr["MovStatus"].ToString(),
                            Geocode = dr["GeoCode"].ToString(),
                            CustomerAr = dr["cus_NameArabic"].ToString()

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
                dm.TraceService("GetTrackingDetails Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetTrackingDetails ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString; 
        }
        public string GetCurrentLocation([FromForm] CurLocIn inputParams)
        {
            dm.TraceService("GetCurrentLocation STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string Date = DateTime.Parse(inputParams.Date.ToString()).ToString("yyyyMMdd");               

                DataTable dtAR = dm.loadList("SelCurLoc", "sp_Maps", Date);
                if (dtAR.Rows.Count > 0)
                {
                    List<CurLocOut> listItems = new List<CurLocOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {
                        listItems.Add(new CurLocOut
                        {

                            User = dr["usr_Name"].ToString(),
                            Duration = dr["duration"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            Time = dr["CreatedTime"].ToString(),                          
                            Geocode = dr["GeoCode"].ToString(),
                            UserAr = dr["usr_ArabicName"].ToString(),

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
                dm.TraceService("GetCurrentLocation Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetCurrentLocation ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


    }
}