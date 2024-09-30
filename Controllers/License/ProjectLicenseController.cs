using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using static MVC_API.Controllers.License.ProjectLicenseController;

namespace MVC_API.Controllers.License
{
    public class ProjectLicenseController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string GetProjectConsumedLicense([FromForm] ConsumedLicenseIn inputParams)
        {
            dm.TraceService("GetProjectConsumedLicense STARTED");
            dm.TraceService("======================================");

            try
            {
                dm.TraceService("begin try");
                string LicenseKey = inputParams.LicenseKey == null ? "0" : inputParams.LicenseKey;
                string ProjectLicenseKey = ConfigurationManager.AppSettings.Get("LicenseKey");

                dm.TraceService("LicenseKey inpara: " + LicenseKey);
                dm.TraceService("LicenseKey of Project in web config: " + ProjectLicenseKey);

                if (LicenseKey == ProjectLicenseKey)
                {
                    dm.TraceService("inside if , Licensekey Matches");

                    DataTable dt = dm.loadList("LicenseMasterCounts", "sp_Masters");

                    dm.TraceService("dt- " + dt);

                    List<ConsumedLicenseOut> listdata = new List<ConsumedLicenseOut>();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            listdata.Add(new ConsumedLicenseOut
                            {
                                RouteCount = dr["RouteCount"].ToString(),
                                InventoryUserCount = dr["InventoryUserCount"].ToString(),
                                BackOfficeUserCount = dr["BackOfficeUserCount"].ToString(),
                                CustomerConnectUserCount = dr["CustomerConnectUserCount"].ToString(),
                                SFA_AppUserCount = dr["SFA_AppUserCount"].ToString(),

                            });
                        }

                        
                        dm.TraceService("Returning Success Result");

                        JSONString = JsonConvert.SerializeObject(new
                        {
                            result = listdata
                        });

                        return JSONString;

                    }
                    else
                    {
                        listdata.Add(new ConsumedLicenseOut
                        {
                            RouteCount = "",
                            InventoryUserCount = "",
                            BackOfficeUserCount = "",
                            CustomerConnectUserCount = "",
                            SFA_AppUserCount = "",

                        });


                        dm.TraceService("Returning Failure Result");
                        dm.TraceService("NoDataRes - datatable returns null or nodata");

                        JSONString = JsonConvert.SerializeObject(new
                        {
                            result = listdata
                        });

                        return JSONString;

                    }
                }
                else
                {
                    dm.TraceService("The license key you entered does not match the expected key. Please check and try again.");
                    JSONString = "The license key you entered does not match the expected key. Please check and try again.";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("GetProjectConsumedLicense  " + ex.Message.ToString());
                JSONString = "Error - " + ex.Message.ToString();
            }

            dm.TraceService("GetProjectConsumedLicense ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public class ConsumedLicenseIn
        {
            public string LicenseKey { get; set; }
        }
        public class ConsumedLicenseOut
        {
            public string RouteCount { get; set; }
            public string InventoryUserCount { get; set; }
            public string BackOfficeUserCount { get; set; }
            public string CustomerConnectUserCount { get; set; }
            public string SFA_AppUserCount { get; set; }
        }
    }
}