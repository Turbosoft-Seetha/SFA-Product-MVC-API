using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
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
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using System.Web;
using Org.BouncyCastle.Asn1.Ocsp;
namespace MVC_API.Controllers
{
    public class InvReconfApprController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]
        public string PostInvReconfApproval([FromForm] InvReconfApprIn inputParams)
        {
            dm.TraceService("PostInvReconfApproval STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            try
            {
                
             

                string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
                string UdpID = inputParams.UdpID == null ? "0" : inputParams.UdpID;
                string UsrID = inputParams.UsrID == null ? "0" : inputParams.UsrID;
                string RotID = inputParams.RotID == null ? "0" : inputParams.RotID;

                string CreatedDate = inputParams.CreatedDate == null ? "0" : inputParams.CreatedDate;

                List<JsonDataInvReconf> itemData = JsonConvert.DeserializeObject<List<JsonDataInvReconf>>(inputParams.Json);

                string DetailXml = "";

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;
                        foreach (JsonDataInvReconf id in itemData)
                        {
                            string[] arr = { id.PrdID.ToString(), id.HUOM.ToString(), id.HQTY.ToString(), id.LUOM.ToString(), id.LQTY.ToString(),
                                id.PhyHUOM.ToString(), id.PhyHQTY.ToString(),id.PhyLUOM.ToString(), id.PhyLQTY.ToString(), id.DescHUOM.ToString(),
                                id.DescHQTY.ToString(),id.DescLUOM.ToString(), id.DescLQTY.ToString(),id.Isvanstockitms.ToString() ,id.IsExcessOrShortage.ToString()};
                            string[] arrName = { "PrdID", "HUOM", "HQTY", "LUOM", "LQTY", "PhyHUOM", "PhyHQTY", "PhyLUOM","PhyLQTY", "DescHUOM", "DescHQTY",
                                "DescLUOM","DescLQTY" ,"Isvanstockitms","IsExcessOrShortage"};
                            dm.createNode(arr, arrName, writer);                           
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                    DetailXml = sw.ToString();
                }
                
             

                string[] ar = { RotID.ToString(), UsrID.ToString(), CreatedDate.ToString(), TransID.ToString(), DetailXml.ToString() };
                DataTable dt = dm.loadList("InsInvReconfApproval", "sp_InventoryReconfirmWS", UdpID.ToString(), ar);


                if (dt.Rows.Count > 0)
                {
                    List<InvReconfApprOut> listoutput = new List<InvReconfApprOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listoutput.Add(new InvReconfApprOut
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
                dm.TraceService(" PostInvReconfApproval Exception - " + ex.Message.ToString());
                dm.TraceService(ex.Message.ToString());
            }
            dm.TraceService("PostInvReconfApproval ENDED - " + DateTime.Now.ToString());
            dm.TraceService("==================");
            return JSONString;
        }

        public string GetInvReconfApprovalStatus([FromForm] GetInvReconfApprHeaderStatus inputParams)
        {
            dm.TraceService("GetInvReconfApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


            string[] arr = { userID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelStatusForInvReconfApproval", "sp_InventoryReconfirmWS", TransID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<GetApprovalStatus> listHeader = new List<GetApprovalStatus>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new GetApprovalStatus
                        {
                            ApprovalStatus = dr["iad_Status"].ToString(),

                            Products = dr["iad_prd_ID"].ToString(),
                            ReasonID = dr["iad_rsn_ID"].ToString(),

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

            dm.TraceService("GetInvReconfApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetInvReconfApprHeaderStatus([FromForm] GetInvReconfApprHeaderStatus inputParams)
        {
            dm.TraceService("GetInvReconfApprHeaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { userID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForInvReconfApprovalHeader", "sp_InventoryReconfirmWS", TransID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetlortransreqApprovalHeaderStatus> listHeader = new List<GetlortransreqApprovalHeaderStatus>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetlortransreqApprovalHeaderStatus
                        {
                            ApprovalStatus = dr["iah_Status"].ToString()

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
                dm.TraceService("GetInvReconfApprHeaderStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetInvReconfApprHeaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }
}