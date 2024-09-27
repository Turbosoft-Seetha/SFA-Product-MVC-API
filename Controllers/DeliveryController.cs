using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVC_API.Controllers
{
    public class DeliveryController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]

        public string GetDeliveryApprovalHeaderStatus([FromForm] PostApprovalHeaderStatusData inputParams)
        {
            dm.TraceService("GetDeliveryApprovalHeaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string orderID = inputParams.OrderId == null ? "0" : inputParams.OrderId;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { userID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForDeliveryApprovalHeader", "sp_DeliveryApproval", orderID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetDeliveryApprovalHeaderStatus> listHeader = new List<GetDeliveryApprovalHeaderStatus>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetDeliveryApprovalHeaderStatus
                        {
                            ApprovalStatus = dr["dah_ApprovalStatus"].ToString()

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

            dm.TraceService("GetDeliveryApprovalHeaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string PostPartialDelivery([FromForm] PostDeliveryData inputParams)
        {
            dm.TraceService("PostPartialDelivery STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostDeliveryItemData> itemData = JsonConvert.DeserializeObject<List<PostDeliveryItemData>>(inputParams.JSONString);
                try
                {
                    string OrderID = inputParams.OrderId == null ? "0" : inputParams.OrderId;
                    string status = inputParams.Status == null ? "PA" : inputParams.Status;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string finalAmount = inputParams.FinalAmount == null ? "0" : inputParams.FinalAmount;
                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostDeliveryItemData id in itemData)
                            {
                                string[] arr = { id.ItemId.ToString(), id.HigherUOM.ToString(), id.HigherQty.ToString(), id.LowerUOM.ToString(), id.LowerQty.ToString(), id.ReasonId.ToString() };
                                string[] arrName = { "ItemId", "HigherUOM", "HigherQty", "LowerUOM", "LowerQty", "ReasonId" };
                                dm.createNode(arr, arrName, writer);
                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        InputXml = sw.ToString();
                    }

                    try
                    {
                        string[] arr = { userID.ToString(), finalAmount.ToString(), status.ToString(), InputXml.ToString() };
                        string Value = dm.SaveData("sp_DeliveryApproval", "InsPartialDeliveryForApproval", OrderID.ToString(), arr);
                        int Output = Int32.Parse(Value);
                        List<GetDeliveryInsertStatus> listStatus = new List<GetDeliveryInsertStatus>();
                        if (Output > 0)
                        {
                            string url = ConfigurationManager.AppSettings.Get("DelIntURL");
                            dm.TraceService(" Partial Delivery Initial  starts- " + DateTime.Now.ToString());
                            string Json = "";
                           // WebServiceCal(url, Json);
                            dm.TraceService("Partial Delivery Initial End - " + DateTime.Now.ToString());

                            listStatus.Add(new GetDeliveryInsertStatus
                            {
                                Mode = "1",
                                Status = "Delivery for approval submitted successfully"
                            });
                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listStatus
                            });
                            return JSONString;


                        }
                        else
                        {
                            listStatus.Add(new GetDeliveryInsertStatus
                            {
                                Mode = "0",
                                Status = "Delivery for approval submission failed"
                            });
                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listStatus
                            });
                            return JSONString;
                        }
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
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }
            dm.TraceService("PostPartialDelivery ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetProductwisePDApprovalStatus([FromForm] PostApprovalHeaderStatusData inputParams)
        {
            dm.TraceService("GetProductwisePDApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ordID = inputParams.OrderId == null ? "0" : inputParams.OrderId;
            string cusID = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { cusID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelProductWisePDApprovalStatus", "sp_DeliveryApproval", ordID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<PDdetailStatusOut> listHeader = new List<PDdetailStatusOut>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new PDdetailStatusOut
                        {
                            prdid = dr["dad_prd_ID"].ToString(),
                            ApprovalStatus = dr["dad_ApprovalStatus"].ToString()

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

            dm.TraceService("GetProductwisePDApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    }
}