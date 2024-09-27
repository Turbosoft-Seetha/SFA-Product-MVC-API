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
using SendGrid;
using System.Web.UI;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MVC_API.Controllers
{
    public class InventoryController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]
        public string PostInventoryReconfirmation([FromForm] InvConfirmationIn inputParams)
        {
            dm.TraceService("PostInventoryReconfirmation STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            try
            {
                List<JsonData> itemData = JsonConvert.DeserializeObject<List<JsonData>>(inputParams.Json);
                List<JsonBatchData> BatchData = JsonConvert.DeserializeObject<List<JsonBatchData>>(inputParams.JsonBatch);


                string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
                string UdpID = inputParams.UdpID == null ? "0" : inputParams.UdpID;
                string UsrID = inputParams.UsrID == null ? "0" : inputParams.UsrID;
                string RotID = inputParams.RotID == null ? "0" : inputParams.RotID;

                string CreatedDate = inputParams.CreatedDate == null ? "0" : inputParams.CreatedDate;

                string DetailXml = "";
                string BatchDetailXml = "";

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;
                        foreach (JsonData id in itemData)
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

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;
                        foreach (JsonBatchData id in BatchData)
                        {
                            string[] arrBatch = { id.PrdID.ToString(), id.BatchNum.ToString(), id.BatchQty.ToString(), id.AdjQty.ToString(), id.PhyStk.ToString() };
                            string[] arrNameBatch = { "PrdID", "BatchNum", "BatchQty", "AdjQty", "PhyStk" };
                            dm.createNode(arrBatch, arrNameBatch, writer);


                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                    BatchDetailXml = sw.ToString();


                }


                string[] ar = { RotID.ToString(), UsrID.ToString(), CreatedDate.ToString(), TransID.ToString(), DetailXml.ToString(), BatchDetailXml.ToString() };
                DataTable dt = dm.loadList("InsInventoryReconfirmation", "sp_Inventory", UdpID.ToString(), ar);

                if (dt.Rows.Count > 0)
                {
                    List<InvConfirmationOut> listoutput = new List<InvConfirmationOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listoutput.Add(new InvConfirmationOut
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
                dm.TraceService(" PostInventoryReconfirmation Exception - " + ex.Message.ToString());
                dm.TraceService(ex.Message.ToString());
            }
            dm.TraceService("PostInventoryReconfirmation ENDED - " + DateTime.Now.ToString());
            dm.TraceService("==================");
            return JSONString;
        }

        public string PostLoadInConfirmation([FromForm] LoadConfirmIn inputParams)
        {
            dm.TraceService("PostLoadInConfirmation STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            dm.TraceService("Json:" + inputParams.XMLData);
            try
            {

                List<ItemData> itemData = JsonConvert.DeserializeObject<List<ItemData>>(inputParams.XMLData);


                string lih_ID = inputParams.lih_ID == null ? "0" : inputParams.lih_ID;
                string UdpID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
                string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
                string emp_ID = inputParams.emp_ID == null ? "0" : inputParams.emp_ID;

                string Status = inputParams.Status == null ? "0" : inputParams.Status;
                string Remarks = inputParams.Remarks == null ? "0" : inputParams.Remarks;


                string JSONString = string.Empty;
                string success = "0";
                try
                {
                    string[] arr = { };
                    DataSet dtItemBatch = dm.loadListDS("SelectLoadInItemBatch", "sp_Integration_BM", lih_ID.ToString(), arr);
                    DataTable itemDatail = dtItemBatch.Tables[0];
                    DataTable batchDatail = dtItemBatch.Tables[1];
                    if (itemDatail.Rows.Count > 0)
                    {
                        List<GetLORItemHeader> listItems = new List<GetLORItemHeader>();
                        GetLORHeader ListHeader = new GetLORHeader();
                        foreach (DataRow dr in itemDatail.Rows)
                        {
                            List<GetLORBatchSerial> listBatchSerial = new List<GetLORBatchSerial>();
                            List<getTransferDetailOptionalFields> listDetailOptionalFlds = new List<getTransferDetailOptionalFields>();
                            List<getTransferDetailSerialNumbers> listSerialnumbers = new List<getTransferDetailSerialNumbers>();

                            foreach (DataRow drDetails in batchDatail.Rows)
                            {
                                //if (dr["prd_Code"].ToString() == drDetails["prd_Code"].ToString() && dr["pkd_ID"].ToString() == drDetails["pbs_pkd_ID"].ToString())
                                //{
                                listBatchSerial.Add(new GetLORBatchSerial
                                {
                                    LotNumber = drDetails["lbs_Number"].ToString(),
                                    ExpiryDate = drDetails["lbs_ExpiryDate"].ToString(),
                                    TransactionQuantity = Int32.Parse(drDetails["lbs_Qty"].ToString()),
                                    LotQuantityInStockingUOM = Int32.Parse(drDetails["lbs_Qty"].ToString()),

                                });
                                //}
                            }

                            listItems.Add(new GetLORItemHeader
                            {

                                LineNumber = dr["LineNumber"].ToString(),
                                ItemNumber = dr["prd_Code"].ToString(),
                                Description = dr["prd_Name"].ToString(),
                                FromLocation = dr["fromloc"].ToString(),
                                ToLocation = dr["toloc"].ToString(),
                                QuantityTransferred = Int32.Parse(dr["totalQty"].ToString()),
                                UnitOfMeasure = dr["uom_Name"].ToString(),
                                Comments = "DigitsIntegration",
                                QuantityRequested = Int32.Parse(dr["totalQty"].ToString()),
                                ConversionFactorQtyRequested = Int32.Parse(dr["convfactor"].ToString()),
                                TransferDetailOptionalFields = listDetailOptionalFlds,
                                TransferDetailSerialNumbers = listSerialnumbers,
                                TransferDetailLotNumbers = listBatchSerial,
                            });

                            ListHeader.Description = "Digits App batch test";
                            ListHeader.DocumentDate = dr["LORDate"].ToString();
                            ListHeader.Reference = "Test Reference";
                            ListHeader.RecordStatus = "Posted";
                            ListHeader.DocumentType = "Transfer";
                            ListHeader.PostingDate = dr["LORDate"].ToString();
                            ListHeader.TransferDetails = listItems;


                        }

                        JSONString = JsonConvert.SerializeObject(ListHeader);




                    }
                    else
                    {
                        JSONString = "NoDataRes";
                    }

                    string url = ConfigurationManager.AppSettings.Get("API_UpdateBatch");
                    string Json = WebServiceCal(url, JSONString);
                    dm.TraceService("Webservice Call result of ICTransfer - " + Json);
                    if (Json != null)
                    {
                        try
                        {


                            ICTransferData responseData = JsonConvert.DeserializeObject<ICTransferData>(Json);

                            // Access fields
                            string resCode = responseData.result.ResCode;
                            if (resCode == "200")
                            {
                                string resExceptionMessage = responseData.result.ResExceptionMessage;
                                JArray resbody = responseData.result.Body; // Assuming Body is already a JSON string
                                dm.TraceService("Body values - " + resbody);

                                // Access fields within Body (assuming Body is a JSON string)
                                //BodyData bodyData = JsonConvert.DeserializeObject<BodyData>(resbody);
                                JObject firstElement = (JObject)resbody.First;

                                try
                                {
                                    string SeqNumber = firstElement["SequenceNumber"].ToString();
                                    string TransNumber = firstElement["TransactionNumber"].ToString();
                                    string DocumentNo = firstElement["DocumentNumber"].ToString();

                                    if (SeqNumber != null)
                                    {
                                        success = "1";
                                        //Approve(SeqNumber, TransNumber, DocumentNo);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string errorJson = resbody.ToString();

                                    JArray errorArray = JArray.Parse(errorJson);

                                    string errorMessage = "";
                                    // Iterate over the array elements
                                    foreach (JObject errorObject in errorArray)
                                    {
                                        // Accessing the value field for each object
                                        errorMessage = (string)errorObject["error"]["message"]["value"];

                                    }
                                    if (errorMessage != null)
                                    {
                                        dm.TraceService("Error message" + errorMessage);
                                        JSONString = "You can't continue..There is some issue while updating in ERP";
                                    }
                                }

                            }
                            else if (resCode == "500")
                            {
                                dm.TraceService("Rescode:" + resCode);
                                JSONString = "You can't continue..There is some issue while updating in ERP";

                            }


                        }

                        catch (Exception ex)
                        {
                            dm.TraceService("Exception after api call");
                            JSONString = "You can't continue..There is some issue while updating in ERP";

                        }
                    }
                }
                catch (Exception ex)
                {
                    JSONString = "You can't continue..There is some issue while updating in ERP";
                    dm.TraceService("Exception in ERP Api call - " + ex.Message.ToString());

                }
                if (success == "1")
                {
                    var physicalPath = Server.MapPath("../../UploadFiles/LoadInSign");
                    dm.TraceService("Physical Path Generated: " + physicalPath.ToString());

                    if (!Directory.Exists(physicalPath))
                    {
                        Directory.CreateDirectory(physicalPath);
                        dm.TraceService("Directory Created");
                    }

                    string imagePath = physicalPath + "/";
                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                        dm.TraceService("Directory for Image Path Created");
                    }

                    string ImageBase64 = inputParams.Signature;

                    if (!string.IsNullOrEmpty(ImageBase64))
                    {
                        try
                        {



                            byte[] imageBytes = Convert.FromBase64String(ImageBase64);

                            // Save or process the image as needed
                            string imageFileName = DateTime.Now.ToString("HHmmss") + rot_ID + UdpID + lih_ID + ".jpg"; // Set a suitable file name
                            string imagePathWithName = Path.Combine(imagePath, imageFileName);

                            using (FileStream fs = new FileStream(imagePathWithName, FileMode.Create))
                            {
                                fs.Write(imageBytes, 0, imageBytes.Length);
                            }

                            // Set the image path or perform additional actions as needed
                            imagePath = "../UploadFiles/LoadInSign/" + imageFileName;
                        }
                        catch (Exception ex)
                        {
                            dm.TraceService("Error processing image: " + ex.Message);
                        }
                    }
                    else
                    {
                        dm.TraceService("No image parameter received.");
                    }


                    string DetailXml = "";

                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (ItemData id in itemData)
                            {
                                string[] arr = { id.prdID.ToString(), id.Adj_H_UOM.ToString(), id.Adj_H_Qty.ToString(), id.lidID.ToString(), id.Adj_L_UOM.ToString(),
                                id.Adj_L_Qty.ToString(), id.Final_H_UOM.ToString(),id.Final_H_Qty.ToString(), id.Final_L_UOM.ToString(), id.Final_L_Qty.ToString(),
                                id.LI_H_UOM.ToString(),id.LI_H_Qty.ToString(), id.LI_L_UOM.ToString(),id.LI_L_Qty.ToString() ,id.Opn_HUOM.ToString(),
                             id.Opn_HQty.ToString(),id.Opn_LUOM.ToString(), id.Opn_LQty.ToString(),id.HigherPrice.ToString() ,id.LowerPrice.ToString()};
                                string[] arrName = { "prdID", "Adj_H_UOM", "Adj_H_Qty", "lidID", "Adj_L_UOM", "Adj_L_Qty", "Final_H_UOM", "Final_H_Qty","Final_L_UOM", "Final_L_Qty",
                                "LI_H_UOM","LI_H_Qty","LI_L_UOM" ,"LI_L_Qty","Opn_HUOM","Opn_HQty","Opn_LUOM","Opn_LQty","HigherPrice","LowerPrice"};
                                dm.createNode(arr, arrName, writer);


                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        DetailXml = sw.ToString();
                    }



                    string[] ar = { DetailXml.ToString(), emp_ID.ToString(), Status.ToString(), rot_ID.ToString(), UdpID.ToString(), imagePath.ToString(),
                Remarks};
                    DataTable dt = dm.loadList("InsLoadIn", "sp_Integration_BM", lih_ID.ToString(), ar);

                    if (dt.Rows.Count > 0)
                    {
                        List<LoadConfirmOut> listoutput = new List<LoadConfirmOut>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            listoutput.Add(new LoadConfirmOut
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
                else
                {
                    JSONString = "You can't continue..There is some issue while updating in ERP";
                    dm.TraceService("Erp api call failure  and success:" + success);
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(" PostLoadInConfirmation Exception - " + ex.Message.ToString());
                dm.TraceService(ex.Message.ToString());
            }


            dm.TraceService("PostLoadInConfirmation ENDED - " + DateTime.Now.ToString());
            dm.TraceService("==================");
            return JSONString;
        }

        public string WebServiceCal(string URL, string jsonData)
        {

            try
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
                    dm.TraceService("responseFromServer:" + responseFromServer);
                    response.Close();
                    return responseFromServer;
                }



            }
            catch (Exception ex)
            {
                String innerMessage = (ex.InnerException != null) ? ex.InnerException.Message : "";
                dm.TraceService("Exception while webservice call" + ex.Message.ToString());
                return ex.Message.ToString();
            }
        }


    }
}