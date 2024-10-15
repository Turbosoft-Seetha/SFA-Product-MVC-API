using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVC_API.Controllers
{
    public class OverrideOnlineController : Controller
    {
        // GET: OrderCancel
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]

        public string InsOverrideOnlineApproval([FromForm] OverrideApprIn inputParams)
        {
            dm.TraceService("InsOverrideOnlineApproval STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            try
            {               
                string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;
                string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
                string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string Type = inputParams.Type == null ? "" : inputParams.Type;

                List<JsonDataOverride> itemData = JsonConvert.DeserializeObject<List<JsonDataOverride>>(inputParams.Json);

                string DetailXml = "";

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;
                        foreach (JsonDataOverride id in itemData)
                        {
                           string[] arr = { id.CrLmt.ToString(), id.AvlLmt.ToString(), id.TotLmt.ToString(), id.InvID.ToString(), id.OverDate.ToString(), id.CrDays.ToString()};
                            string[] arrName = { "CrLmt", "AvlLmt", "TotLmt", "InvID", "OverDate", "CrDays"};
                            dm.createNode(arr, arrName, writer);
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                    DetailXml = sw.ToString();
                }


                string[] ar = { udp_ID.ToString(), rot_ID.ToString(), cus_ID.ToString(), Type.ToString(), DetailXml.ToString() };
                DataTable dt = dm.loadList("InsOverrideApproval", "sp_OverrideOnline", cse_ID.ToString(), ar);


                if (dt.Rows.Count > 0)
                {
                    List<OverrideApprOut> listoutput = new List<OverrideApprOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listoutput.Add(new OverrideApprOut
                        {
                            Res = dr["Res"].ToString(),
                            Title = dr["Title"].ToString(),
                            Descr = dr["Descr"].ToString()


                        });
                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listoutput
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
                dm.TraceService(" InsOverrideOnlineApproval Exception - " + ex.Message.ToString());
                dm.TraceService(ex.Message.ToString());
            }
            dm.TraceService("InsOverrideOnlineApproval ENDED - " + DateTime.Now.ToString());
            dm.TraceService("==================");
            return JSONString;
        }
        public string GetOverrideApprHeaderStatus([FromForm] GetOverrideApprHeaderStatusIn inputParams)
        {
            dm.TraceService("GetOverrideApprHeaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            string[] arr = { rotID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForOverrideApprHeader", "sp_OverrideOnline", TransID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetOverrideApprHeaderStatusOut> listHeader = new List<GetOverrideApprHeaderStatusOut>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetOverrideApprHeaderStatusOut
                        {
                            ApprovalStatus = dr["ooh_ApprovalStatus"].ToString()

                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listHeader
                    });

                    return JSONString;
                }
                else
                {
                    dm.TraceService("NoDataRes");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("GetOverrideApprHeaderStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOverrideApprHeaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOverrideApprDetailStatus([FromForm] GetOverrideApprDetailStatusIn inputParams)
        {
            dm.TraceService("GetOverrideApprDetailStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;


            string[] arr = { rotID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelStatusForOverrideApprDetail", "sp_OverrideOnline", TransID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<GetOverrideApprDetailStatusOut> listHeader = new List<GetOverrideApprDetailStatusOut>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new GetOverrideApprDetailStatusOut
                        {
                            ApprovalStatus = dr["ood_ApprovalStatus"].ToString()

                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listHeader
                    });

                    return JSONString;
                }
                else
                {
                    dm.TraceService("NoDataRes");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOverrideApprDetailStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }

}