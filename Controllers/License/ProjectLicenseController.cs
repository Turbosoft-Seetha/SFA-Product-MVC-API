using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;
using static MVC_API.Controllers.License.ProjectLicenseController;

namespace MVC_API.Controllers.License
{
    public class ProjectLicenseController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string GetProjectConsumedLicense()
        {
            dm.TraceService("GetProjectConsumedLicense STARTED");
            dm.TraceService("======================================");

            try
            {
                dm.TraceService("begin try");
                //string LicenseKey = inputParams.LicenseKey == null ? "0" : inputParams.LicenseKey;
                string ProjectLicenseKey = ConfigurationManager.AppSettings.Get("LicenseKey");

                //dm.TraceService("LicenseKey inpara: " + LicenseKey);
                dm.TraceService("LicenseKey of Project in web config: " + ProjectLicenseKey);

                //if (LicenseKey == ProjectLicenseKey)
                //{
                    dm.TraceService("inside if , Licensekey Matches");

                    DataTable dt = dm.loadList("LicenseMasterCounts", "sp_LicenseManagement");

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


                        try
                        {
                            LicenseInpara LicenseIn = new LicenseInpara();
                            LicenseIn = new LicenseInpara
                            {
                                LicenseKey = ProjectLicenseKey.ToString(),
                                RouteCount = listdata[0].RouteCount,
                                InventoryUserCount = listdata[0].InventoryUserCount,
                                BackOfficeUserCount = listdata[0].BackOfficeUserCount,
                                CustomerConnectUserCount = listdata[0].CustomerConnectUserCount,
                                SFA_AppUserCount = listdata[0].SFA_AppUserCount

                            };

                            string JSONStr = JsonConvert.SerializeObject(LicenseIn);
                            string url = ConfigurationManager.AppSettings.Get("LicenseUpdateURL");
                            string Json = WebServiceCall(url, JSONStr);

                            dm.TraceService("GetProjectConsumedLicense() , " + "JSONStr : " + JSONStr);
                            dm.TraceService("GetProjectConsumedLicense(), " + "url : " + url);
                            dm.TraceService("GetProjectConsumedLicense() , " + "Json : " + Json);

                            if (Json != null)
                            {
                                // Deserialize and re-serialize for formatting
                                //var jsonObject = JsonConvert.DeserializeObject<JObject>(Json);
                                //string formattedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                                //ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(formattedJson);
                                //JObject result = (JObject)responseData.result[0];

                                ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(Json);

                                string res = responseData.Result.Res;
                                string title = responseData.Result.Title;
                                string descr = responseData.Result.Descr;

                                dm.TraceService($"WebService Response - Res: {res}, Title: {title}, Description: {descr}");


                                if (res == "1")
                                {
                                    listdata.Add(new ConsumedLicenseOut
                                    {
                                        RouteCount = listdata[0].RouteCount.ToString(),
                                        InventoryUserCount = listdata[0].InventoryUserCount.ToString(),
                                        BackOfficeUserCount = listdata[0].BackOfficeUserCount.ToString(),
                                        CustomerConnectUserCount = listdata[0].CustomerConnectUserCount.ToString(),
                                        SFA_AppUserCount = listdata[0].SFA_AppUserCount.ToString(),
                                    });

                                }
                                else
                                {
                                    dm.TraceService("GetProjectConsumedLicense() License API Returns Failure Response.");
                                    JSONString = "Error - License API Returns Failure Response";
                                }


                               

                                
                            }
                            else
                            {
                                dm.TraceService("GetProjectConsumedLicense() - Error - Json returns null value ");
                                JSONString = "Error - Json returns null value";
                            }
                        }
                        catch (Exception ex)
                        {
                            dm.TraceService("GetProjectConsumedLicense()  " + ex.Message.ToString());
                            JSONString = "Error - " + ex.Message.ToString();
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
                //}
                //else
                //{
                //    dm.TraceService("The license key you entered does not match the expected key. Please check and try again.");
                //    JSONString = "The license key you entered does not match the expected key. Please check and try again.";
                //}
            }
            catch (Exception ex)
            {
                dm.TraceService("GetProjectConsumedLicense()  " + ex.Message.ToString());
                JSONString = "Error - " + ex.Message.ToString();
            }

            dm.TraceService("GetProjectConsumedLicense() ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string WebServiceCall(string URL, string jsonData)
        {

            try
            {

                if (jsonData != null)
                {
                    // Create a request using a URL that can receive a post.
                    WebRequest request = WebRequest.Create(URL);
                    // Set the Method property of the request to POST.
                    request.Method = "POST";
                    request.ContentType = "application/json";

                    byte[] postData = Encoding.UTF8.GetBytes(jsonData);

                    // Set the ContentLength property of the request to the length of the data
                    request.ContentLength = postData.Length;

                    // Get the request stream and write the data to it
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(postData, 0, postData.Length);
                    }

                    WebResponse response = request.GetResponse();
                    // Display the status.
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                    // Get the stream containing content returned by the server.
                    // The using block ensures the stream is automatically closed.
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.
                        // dm.TraceService("[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "] @ " + " DataLake_Service WebServiceCall Success => " + responseFromServer);
                        response.Close();
                        return responseFromServer;
                    }
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                String innerMessage = (ex.InnerException != null) ? ex.InnerException.Message : "";
                dm.TraceService("ProjectLicenseController - GetProjectConsumedLicense() - WebServiceCall()  , " + "Error : " + ex.Message.ToString() + " - " + innerMessage);
                return ex.Message.ToString();
            }
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

        private class LicenseInpara
        {
            public string LicenseKey { get; set; }
            public string RouteCount { get; set; }
            public string InventoryUserCount { get; set; }
            public string BackOfficeUserCount { get; set; }
            public string CustomerConnectUserCount { get; set; }
            public string SFA_AppUserCount { get; set; }
        }
        public class Result
        {
            public string Res { get; set; }
            public string Title { get; set; }
            public string Descr { get; set; }
          
        }
        public class ResponseData
        {
            public Result Result { get; set; }
           // public JArray result { get; set; }
        }
    }
}