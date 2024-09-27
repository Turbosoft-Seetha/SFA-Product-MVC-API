using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System.Configuration;

namespace MVC_API.Controllers
{
    public class SettlementReportController : Controller
    {
        // GET: SettlementReport
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]


        public string GetSettlementPDF([FromForm] SettlementPDFIn inputParams)
        {
            dm.TraceService("GetSettlementPDF STARTED ");
            dm.TraceService("==============================");
            try
            {

                string Udp_ID = inputParams.Udp_ID == null ? "0" : inputParams.Udp_ID;


                dm.TraceService("Value for Transaction" + Udp_ID.ToString());
                string url = ConfigurationManager.AppSettings.Get("BackendUrl");


                try
                {
                    var s = Server.MapPath("../../BO_Digits/en/Reports/license.key");
                    Stimulsoft.Base.StiLicense.LoadFromFile(s);
                    var report = new StiReport();
                    var path = Server.MapPath("../../BO_Digits/en/Reports/SettlementReport.mrt");
                    dm.TraceService("s:" + s);
                    dm.TraceService("path:" + path);


                    report.Load(path);



                    string DB = ConfigurationManager.AppSettings.Get("MyDB");
                    ((StiSqlDatabase)report.Dictionary.Databases["BMSettlementREport"]).ConnectionString = DB;
                    report["@para2"] = Udp_ID.ToString();

                    StiOptions.Export.Pdf.AllowImportSystemLibraries = true;
                    var tempPdfPath = Server.MapPath("../../Downloads/Settlement.pdf");
                    dm.TraceService("pdf path:" + tempPdfPath);

                    MemoryStream ms = new MemoryStream();
                    report.Render();
                    report.ExportDocument(StiExportFormat.Pdf, ms);
                    System.IO.File.WriteAllBytes(tempPdfPath, ms.ToArray());
                    // Send the URL of the generated PDF file to client side
                    List<SettlementPDFOut> listDns = new List<SettlementPDFOut>();

                    listDns.Add(new SettlementPDFOut
                    {
                        PDFSETNurl = url + "Downloads/Settlement.pdf"



                    });

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listDns
                    });

                    return JSONString;


                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "NoDataSQL - " + ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetSettlementPDF ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

    }
}