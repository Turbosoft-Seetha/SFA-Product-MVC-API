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
    public class PriceUpdateController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]

        public string GetPriceUpdateApprovalHeaderStatus([FromForm] PUHeaderstatusIn inputParams)
        {
            dm.TraceService("GetPriceUpdateApprovalHeaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;

            string[] arr = { cusID.ToString(),inputParams.ReqID };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForPriceupdateApprovalHeader", "sp_PriceUpdateApproval", rotID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<PUHeaderstatusOut> listHeader = new List<PUHeaderstatusOut>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new PUHeaderstatusOut
                        {
                            ApprovalStatus = dr["pch_ApprovalStatus"].ToString()

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

            dm.TraceService("GetPriceUpdateApprovalHeaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string PostPriceUpdate([FromForm] PUIn inputParams)
        {
            dm.TraceService("PostPriceUpdate STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PUItemData> itemData = JsonConvert.DeserializeObject<List<PUItemData>>(inputParams.JSONString);
                try
                {
                    string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                    string cusID = inputParams.cusID == null ? "PA" : inputParams.cusID;
                    string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                    string usrID = inputParams.usrID == null ? "0" : inputParams.usrID;
                    string OrderNo = inputParams.OrderNo  == null ? "0" : inputParams.OrderNo;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string TotalCreditlimit = inputParams.TotalCreditlimit == null ? "0" : inputParams.TotalCreditlimit;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PUItemData id in itemData)
                            {
                                string[] arr = { id.ItemId.ToString(), id.HigherUOM.ToString(), id.HigherQty.ToString(),id.stdHprice,id.chngdHprice, id.LowerUOM.ToString(), id.LowerQty.ToString(),id.stdLprice,id.chngdLprice, id.ReasonId.ToString(),id.Flag.ToString(),id.HigherLimitPercent,id.LowerLimtPercent };
                                string[] arrName = { "ItemId", "HigherUOM", "HigherQty","stdHprice","chngdHprice", "LowerUOM", "LowerQty","stdLprice","chngdLprice", "ReasonId","Flag", "HigherLimitPercent", "LowerLimtPercent" };
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
                        string[] arr = { cusID.ToString(), udpID.ToString(), usrID.ToString(), InputXml.ToString(),ReqID.ToString(),OrderNo.ToString(), TotalCreditlimit .ToString()};
                        string Value = dm.SaveData("sp_PriceUpdateApproval", "InsPriceChangeForApproval", rotID.ToString(), arr);
                        int Output = Int32.Parse(Value);
                        List<GetPriceUpdateStatus> listStatus = new List<GetPriceUpdateStatus>();
                        if (Output > 0)
                        {
                            string url = ConfigurationManager.AppSettings.Get("DelIntURL");
                            dm.TraceService("Price Update Initial  starts- " + DateTime.Now.ToString());
                            string Json = "";
                            // WebServiceCal(url, Json);
                            dm.TraceService("Price Update Initial End - " + DateTime.Now.ToString());

                            listStatus.Add(new GetPriceUpdateStatus
                            {
                                Mode = "1",
                                Status = "Price Update for approval submitted successfully"
                            });
                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listStatus
                            });
                            return JSONString;


                        }
                        else
                        {
                            listStatus.Add(new GetPriceUpdateStatus
                            {
                                Mode = "0",
                                Status = "Price Update for approval submission failed"
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
            dm.TraceService("PostPriceUpdate ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetProductwiseApprovalStatus([FromForm] PUHeaderstatusIn inputParams)
        {
            dm.TraceService("GetProductwiseApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;

            string[] arr = { cusID.ToString(), inputParams.ReqID};
            DataTable dtDeliveryStatus = dm.loadList("SelProductWiseStatus", "sp_PriceUpdateApproval", rotID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<PUdetailStatusOut> listHeader = new List<PUdetailStatusOut>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new PUdetailStatusOut
                        {   prdid = dr["pcd_prd_ID"].ToString(),
                            ApprovalStatus = dr["Status"].ToString(),
                            ApprovedHigherPrice= dr["pcd_ApprovedHPrice"].ToString(),
                            ApprovedLowerPrice = dr["pcd_ApprovedLPrice"].ToString(),
                            HigherUOM= dr["pcd_HigherUOM"].ToString(),
                            LowerUOM = dr["pcd_LowerUOM"].ToString()

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

            dm.TraceService("GetProductwiseApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    }
}