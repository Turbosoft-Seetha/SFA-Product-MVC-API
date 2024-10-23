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
using System.Drawing.Drawing2D;
using static Stimulsoft.Report.Func;
using Org.BouncyCastle.Asn1.Ocsp;
using Stimulsoft.Blockly.Blocks.Maths;

namespace MVC_API.Controllers
{
    public class ReturnController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]

        public string GetReturnRequest([FromForm] ReturnRequestIn inputParams)
        {
            dm.TraceService("GetReturnRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string[] arr = { userID.ToString() };
            DataSet dtreturn = dm.loadListDS("SelReturnRequestData", "sp_ReturnRequest", rotID.ToString(), arr);
            DataTable HeaderData = dtreturn.Tables[0];
            DataTable DetailData = dtreturn.Tables[1];
            DataTable BatchData = dtreturn.Tables[2];

            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<GetRtnRequestHeader> listHeader = new List<GetRtnRequestHeader>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<GetRtnRequestDetail> listDetail = new List<GetRtnRequestDetail>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {

                            List<GetRtnRequestBatch> listBatch = new List<GetRtnRequestBatch>();
                            foreach (DataRow drBatch in BatchData.Rows)
                            {

                                if (drDetails["rrd_rrh_ID"].ToString() == drBatch["rrb_rrh_ID"].ToString() && drDetails["rrd_ID"].ToString() == drBatch["rrb_rrd_ID"].ToString())
                                {
                                    listBatch.Add(new GetRtnRequestBatch
                                    {
                                        rrb_ID = drBatch["rrb_ID"].ToString(),
                                        rrb_rrh_ID = drBatch["rrb_rrh_ID"].ToString(),
                                        rrb_rrd_ID = drBatch["rrb_rrd_ID"].ToString(),
                                        rrb_Number = drBatch["rrb_Number"].ToString(),
                                        rrb_ExpiryDate = drBatch["rrb_ExpiryDate"].ToString(),
                                        rrb_BaseUOM = drBatch["rrb_BaseUOM"].ToString(),
                                        rrb_Qty = drBatch["rrb_Qty"].ToString(),
                                        ind_inv_ID = drBatch["rrb_inv_id"].ToString(),
                                    });
                                }

                            }

                            if (drDetails["rrd_rrh_ID"].ToString() == dr["rrh_ID"].ToString())
                            {


                                listDetail.Add(new GetRtnRequestDetail
                                {
                                    prd_ID = drDetails["rrd_prd_ID"].ToString(),
                                    HUOM = drDetails["rrd_HUOM"].ToString(),
                                    HQty = drDetails["rrd_HQty"].ToString(),
                                    LUOM = drDetails["rrd_LUOM"].ToString(),
                                    LQty = drDetails["rrd_LQty"].ToString(),
                                    prd_Name = drDetails["prd_Name"].ToString(),
                                    prd_LongDesc = drDetails["prd_ItemLongDesc"].ToString(),
                                    prd_cat_id = drDetails["prd_cat_ID"].ToString(),
                                    prd_sub_ID = drDetails["prd_sct_ID"].ToString(),
                                    prd_brd_ID = drDetails["prd_brd_ID"].ToString(),
                                    prd_NameArabic = drDetails["prd_NameArabic"].ToString(),
                                    prd_LongDescArabic = drDetails["prd_ArabicItemLongDesc"].ToString(),
                                    prd_Image = drDetails["prd_Image"].ToString(),
                                    InvoiceNumber = drDetails["inv_InvoiceID"].ToString(),
                                    inv_ID = drDetails["rrh_inv_ID"].ToString(),
                                    prd_code = drDetails["prd_Code"].ToString(),
                                    rrd_ID = drDetails["rrd_ID"].ToString(),
                                    rrd_rrh_ID = drDetails["rrd_rrh_ID"].ToString(),
                                    prd_IsBatchItem = drDetails["prd_IsBatchItem"].ToString(),
                                    RequestBatch = listBatch,

                                });
                            }
                        }

                        listHeader.Add(new GetRtnRequestHeader
                        {

                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            date = dr["CreatedDate"].ToString(),
                            RequestDetail = listDetail,
                            cus_ID = dr["rrh_cus_ID"].ToString(),
                            Request_ID = dr["rrh_ID"].ToString(),
                            inv_ID = dr["rrh_inv_ID"].ToString(),
                            ReturnType = dr["rrh_ReturnType"].ToString(),
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
                JSONString = "GetReturnRequest - " + ex.Message.ToString();
            }
            dm.TraceService("GetReturnRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string PostReturnRequestApproval([FromForm] PostReturnData inputParams)
        {
            dm.TraceService("PostReturnRequestApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostReturnItemData> itemData = JsonConvert.DeserializeObject<List<PostReturnItemData>>(inputParams.JSONString);
                List<PostReturnBatchData> BatchData = JsonConvert.DeserializeObject<List<PostReturnBatchData>>(inputParams.JsonBatch);
                try
                {
                    string ReturnID = inputParams.ReturnID == null ? "0" : inputParams.ReturnID;
                    string status = inputParams.Status == null ? "PA" : inputParams.Status;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                    string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string ReturnMode = inputParams.ReturnMode == null ? "" : inputParams.ReturnMode;
                    string ReturnType = inputParams.ReturnType == null ? "" : inputParams.ReturnType;
                    string cus_ID = inputParams.cus_ID == null ? "" : inputParams.cus_ID;

                    string InputXml = "";
                    string BatchDetailXml = "";

                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostReturnItemData id in itemData)
                            {
                                string[] arr = { id.ItemId.ToString(), id.HigherUOM.ToString(), id.HigherQty.ToString(), id.LowerUOM.ToString(), id.LowerQty.ToString(), id.ReasonId.ToString(),id.invid.ToString(), id.Type.ToString(),id.rad_VAT.ToString(),id.rad_GrandTotal.ToString()};
                                string[] arrName = { "ItemId", "HigherUOM", "HigherQty", "LowerUOM", "LowerQty", "ReasonId", "invId" ,"Type", "rad_VAT", "rad_GrandTotal"};
                                dm.createNode(arr, arrName, writer);
                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        InputXml = sw.ToString();
                    }

                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostReturnBatchData id in BatchData)
                            {
                                string[] arrBatch = { id.PrdID.ToString(), id.BatchNum.ToString(), id.BatchExpiry.ToString(), id.BatchQty.ToString() };
                                string[] arrNameBatch = { "PrdID", "BatchNum", "BatchExpiry", "BatchQty" };
                                dm.createNode(arrBatch, arrNameBatch, writer);
                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        BatchDetailXml = sw.ToString();
                    }

                    try
                    {
                        string[] arr = { userID.ToString(), status.ToString(), InputXml.ToString(), udpID.ToString(), rotID.ToString(),ReqID.ToString(),
                            ReturnMode.ToString(),ReturnType.ToString() ,cus_ID.ToString(), BatchDetailXml.ToString()};
                        DataTable dt = dm.loadList("InsReturnForApproval","sp_ReturnRequest",  ReturnID.ToString(), arr);
                       
                        List<GetReturnInsertStatus> listStatus = new List<GetReturnInsertStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetReturnInsertStatus> listHeader = new List<GetReturnInsertStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetReturnInsertStatus
                                {
                                    Mode = dr["Res"].ToString(),
                                    Status = dr["Status"].ToString(),
                                    TransID = dr["TransID"].ToString()

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
            dm.TraceService("PostReturnRequestApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetRetrunApprovalStatus([FromForm] PostReturnApprovalStatusData inputParams)
        {
            dm.TraceService("GetRetrunApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReturnID = inputParams.ReturnID == null ? "0" : inputParams.ReturnID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


            string[] arr = { userID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelStatusForReturnApproval", "sp_ReturnRequest", ReturnID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<GetReturnApprovalStatus> listHeader = new List<GetReturnApprovalStatus>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new GetReturnApprovalStatus
                        {
                            ApprovalStatus = dr["rad_ApprovalStatus"].ToString(),
                            
                            Products = dr["rad_prd_ID"].ToString(),
                            ReasonID= dr["rsn_ID"].ToString(),
                            InvoiceID = dr["inv_InvoiceID"].ToString()
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

            dm.TraceService("GetRetrunApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetReturnApprovalHeaderStatus([FromForm] PostReturnApprovalHeaderStatusData inputParams)
        {
            dm.TraceService("GetReturnApprovalHeaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReturnID = inputParams.ReturnID == null ? "0" : inputParams.ReturnID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { userID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForReturnApprovalHeader", "sp_ReturnRequest", ReturnID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetReturnApprovalHeaderStatus> listHeader = new List<GetReturnApprovalHeaderStatus>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetReturnApprovalHeaderStatus
                        {
                            ApprovalStatus = dr["rah_ApprovalStatus"].ToString()

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
                dm.TraceService("GetReturnApprovalHeaderStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetReturnApprovalHeaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string PostOpenReturnApproval([FromForm] PostOpenReturnData inputParams)
        {
            dm.TraceService("PostOpenReturnApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostOpenReturnItemData> itemData = JsonConvert.DeserializeObject<List<PostOpenReturnItemData>>(inputParams.JSONString);
                try
                {


                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                    string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                    string Type = inputParams.Type == null ? "0" : inputParams.Type;
                    string InvNumber = inputParams.InvoiceNumber == null ? "0" : inputParams.InvoiceNumber;
                    string ReturnType = inputParams.ReturnType == null ? "0" : inputParams.ReturnType;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostOpenReturnItemData id in itemData)
                            {
                                string[] arr = { id.ItemId.ToString(), id.HigherUOM.ToString(), id.HigherQty.ToString(), id.LowerUOM.ToString(), id.LowerQty.ToString() };
                                string[] arrName = { "ItemId", "HigherUOM", "HigherQty", "LowerUOM", "LowerQty" };
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
                        string[] arr = { InvNumber, userID.ToString(), Type.ToString(), udpID.ToString(), rotID.ToString(), ReturnType.ToString() };
                        string Value = dm.SaveData("sp_ReturnRequest", "InsOpenReturnForApproval", InputXml.ToString(), arr);
                        int Output = Int32.Parse(Value);
                        List<GetOpenReturnInsertStatus> listStatus = new List<GetOpenReturnInsertStatus>();
                        if (Output > 0)
                        {

                            listStatus.Add(new GetOpenReturnInsertStatus
                            {
                                Mode = "1",
                                Status = "Open Return Request for approval submitted successfully"
                            });
                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listStatus
                            });
                            return JSONString;
                        }
                        else
                        {
                            listStatus.Add(new GetOpenReturnInsertStatus
                            {
                                Mode = "0",
                                Status = "Open Return Request for approval submission failed"
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
            dm.TraceService("PostOpenReturnApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetOpenReturnApprovalStatus([FromForm] GetOpenReturnApprovalStatusIn inputParams)
        {
            dm.TraceService("GetOpenReturnApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string InvNumber = inputParams.InvoiceNumber == null ? "0" : inputParams.InvoiceNumber;


            DataTable dtDeliveryStatus = dm.loadList("SelStatusForOpenReturnApproval", "sp_ReturnRequest", InvNumber.ToString());

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetOpenReturnApprovalStatusOut> listHeader = new List<GetOpenReturnApprovalStatusOut>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetOpenReturnApprovalStatusOut
                        {
                            ApprovalStatus = dr["oah_ApprovalStatus"].ToString()

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
                dm.TraceService("GetOpenReturnApprovalStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOpenReturnApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string PostScheduledReturnRequest([FromForm] ScheduledReturnIn inputParams)
        {
            dm.TraceService("PostScheduledReturnRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");

            dm.TraceService("PostScheduledReturnRequest json:" + inputParams.JSONString);
            try
            {
                List<SRItemIDs> itemData = JsonConvert.DeserializeObject<List<SRItemIDs>>(inputParams.JSONString);
                List<SRBatchData> BatchData = JsonConvert.DeserializeObject<List<SRBatchData>>(inputParams.BatchJSONString);
                try
                {
                    string cseID = inputParams.cseID == null ? "0" : inputParams.cseID;
                    string udpID = inputParams.udpID == null ? "PA" : inputParams.udpID;
                    string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                    string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
                    string type = inputParams.type == null ? "" : inputParams.type;
                    string date = inputParams.date == null ? "" : inputParams.date;
                    string Remark = inputParams.Remark == null ? "" : inputParams.Remark;
                    string InvoiceID = inputParams.InvoiceID == null ? "0" : inputParams.InvoiceID;

                    string UserID = inputParams.usrID == null ? "" : inputParams.usrID;
                    string SubTotal = inputParams.SubTotal == null ? "0" : inputParams.SubTotal;

                    string Vat = inputParams.Vat == null ? "" : inputParams.Vat;
                    string Total = inputParams.Total == null ? "" : inputParams.Total;
                    string RetReqSeq= inputParams.RetReqSeq == null ? "" : inputParams.RetReqSeq;

                    string InputXml = "";
                    string InputBatchXml = "";
                    string img = "";

                    dm.TraceService("PostScheduledReturnRequest InputXml:" + InputXml);
                    try
                    {
                        using (var sw = new StringWriter())
                        {
                            using (var writer = XmlWriter.Create(sw))
                            {

                                writer.WriteStartDocument(true);
                                writer.WriteStartElement("r");
                                int c = 0;
                                foreach (SRItemIDs id in itemData)
                                {
                                    string[] arr = { id.prdID.ToString(), id.HigherUOM.ToString(), id.HigherQty.ToString(), id.LowerUOM.ToString(), id.LowerQty.ToString(), id.reason.ToString() ,id.HigherPrice.ToString(),
                                id.LowerPrice.ToString(),id.LineTotal.ToString(),id.Vat.ToString(),id.GrandTotal.ToString()};
                                    string[] arrName = { "ItemId", "HigherUOM", "HigherQty", "LowerUOM", "LowerQty", "ReasonId", "HigherPrice", "LowerPrice", "LineTotal", "Vat", "GrandTotal" };
                                    dm.createNode(arr, arrName, writer);
                                }

                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                                writer.Close();
                            }
                            InputXml = sw.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "Issue while creating Xml - " + ex.Message.ToString();
                    }

                    try
                    {
                        using (var sw = new StringWriter())
                        {
                            using (var writer = XmlWriter.Create(sw))
                            {

                                writer.WriteStartDocument(true);
                                writer.WriteStartElement("r");
                                int c = 0;
                                foreach (SRBatchData id in BatchData)
                                {
                                    string[] arr = { id.BatchNumber.ToString(), id.ExpiryDate.ToString(), id.BaseUOM.ToString(), id.OrderedQty.ToString(), id.AdjustedQty.ToString(), id.LoadInQty.ToString(), id.itm_ID.ToString() };
                                    string[] arrName = { "BatchNumber", "ExpiryDate", "BaseUOM", "OrderedQty", "AdjustedQty", "LoadInQty", "itm_ID" };
                                    dm.createNode(arr, arrName, writer);
                                }
                                
                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                                writer.Close();
                            }
                            InputBatchXml = sw.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "Issue while creating Xml - " + ex.Message.ToString();
                    }



                    var physicalPath = Server.MapPath("../../UploadFiles/ReturnSign");
                    dm.TraceService("Physical Path Generated: " + physicalPath.ToString());

                    if (!Directory.Exists(physicalPath))
                    {
                        Directory.CreateDirectory(physicalPath);
                        dm.TraceService("Directory Created");
                    }

                    string imagePath = physicalPath + "/";
                    string Signpath = "";
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



                            byte[] imageBytes = System.Convert.FromBase64String(ImageBase64);

                            // Save or process the image as needed
                            string imageFileName = DateTime.Now.ToString("HHmmss") + InvoiceID + "_Uploaded.jpg"; // Set a suitable file name
                            string imagePathWithName = Path.Combine(imagePath, imageFileName);

                            using (FileStream fs = new FileStream(imagePathWithName, FileMode.Create))
                            {
                                fs.Write(imageBytes, 0, imageBytes.Length);
                            }

                            // Set the image path or perform additional actions as needed
                            Signpath = "../UploadFiles/ReturnSign/" + imageFileName;
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


                    try
                    {
                        string[] arr = { rotID.ToString(), cusID.ToString(), cseID.ToString(), type.ToString(), date.ToString(), Remark.ToString(), InputXml.ToString(), 
                            InvoiceID.ToString(), UserID.ToString(), SubTotal.ToString(), Vat.ToString(), Total.ToString(), Signpath ,RetReqSeq , InputBatchXml.ToString()};

                        DataTable dtDN = dm.loadList("InsScheduledReturn", "sp_ReturnRequest", udpID, arr);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<ScheduledReturnout> listDn = new List<ScheduledReturnout>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new ScheduledReturnout
                                {
                                    Res = dr["Res"].ToString(),
                                    Message = dr["Message"].ToString(),
                                    TransID = dr["TransID"].ToString()


                                });
                            }
                            JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listDn
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
            dm.TraceService("PostScheduledReturnRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }

        public string PostScheduleRtnImage([FromForm] SRImageIn inputParams)
        {
            dm.TraceService("PostScheduleRtnImage STARTED ");
            dm.TraceService("==============================");
            try
            {

                string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
                string prdID = inputParams.prdID == null ? "0" : inputParams.prdID;


                dm.TraceService("Value for Transaction :" + TransID.ToString());
                dm.TraceService("Value for Prd:" + prdID.ToString());

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("file Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/SRRequest");
                        dm.TraceService("Physical Path Generated" + physicalPath.ToString());
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                            dm.TraceService("Directory Created");
                        }
                        string image = "";
                        var imagePath = physicalPath + "/";
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                            dm.TraceService("Directory for Image Path Created");
                        }
                        string ReceiptImages = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started" + y.ToString());
                            imageFiles[y] = HttpReq.Files[y];
                            long fileSize = imageFiles[y].ContentLength;
                            string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            if (y == 0 && fileSize > 0)
                            {
                                ReceiptImages = "../../UploadFiles/SRRequest/" + REcimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                ReceiptImages += "," + "../../UploadFiles/SRRequest/" + REcimage;
                            }
                            else if (fileSize == 0)
                            {
                                ReceiptImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = { ReceiptImages, prdID };
                        DataTable dtDN = dm.loadList("InsSheduleRtnImage", "sp_ReturnRequest", TransID, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<SRImageOut> listDn = new List<SRImageOut>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new SRImageOut
                                {
                                    Res = dr["Res"].ToString(),
                                    Message = dr["Message"].ToString(),



                                });
                            }
                            JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listDn
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

            dm.TraceService("PostScheduleRtnImage ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

        public string GetScheduleRtnHeaderData([FromForm] SRRequestHeaderIn inputParams)
        {
            dm.TraceService("GetScheduleRtnHeaderData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arr = { userID.ToString() };
            DataTable dtreturn = dm.loadList("SelPendingReturnRequestHeaderData", "sp_ReturnRequest", rotID.ToString(), arr);



            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetPendingRtnRequestHeader> listHeader = new List<GetPendingRtnRequestHeader>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {

                        string imag = "";
                        string img = dr["rrh_Signature"].ToString();

                        string imags = "";
                        string imgs = dr["rrh_Attachment"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["rrh_Signature"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                                else
                                {
                                    imag = url + ar[i];
                                }
                            }

                        }

                        if (imgs != "")
                        {
                            string[] ar = (dr["rrh_Attachment"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imags = imags + "," + url + ar[i];
                                }
                                else
                                {
                                    imags = url + ar[i];
                                }
                            }

                        }


                        listHeader.Add(new GetPendingRtnRequestHeader
                        {

                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            date = dr["CreatedDate"].ToString(),


                            cus_ID = dr["rrh_cus_ID"].ToString(),
                            Request_ID = dr["rrh_ID"].ToString(),
                            inv_ID = dr["rrh_inv_ID"].ToString(),
                            ReturnType = dr["rrh_ReturnType"].ToString(),
                            SubTotal= dr["rrh_SubTotal"].ToString(),
                            Vat= dr["rrh_VatPerc"].ToString(),
                            Total= dr["rrh_Total"].ToString(),
                            Status= dr["Status"].ToString(),
                            cus_Code = dr["cus_code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            Signature = imag,
                            Attachment = imags,
                            Remark = dr["rrh_Remarks"].ToString(),
                            Time = dr["CreatedTime"].ToString(),


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
                JSONString = "GetScheduleRtnHeaderData - " + ex.Message.ToString();
            }
            dm.TraceService("GetScheduleRtnHeaderData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetScheduleRtnDetailData([FromForm] SRRequestDetailIn inputParams)
        {
            dm.TraceService("GetScheduleRtnHeaderData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.RequestID == null ? "0" : inputParams.RequestID;
           
            DataTable dtreturn = dm.loadList("SelPendingReturnRequestDetailData", "sp_ReturnRequest", rotID.ToString());



            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetPendingRtnRequestDetail> listHeader = new List<GetPendingRtnRequestDetail>();
                    foreach (DataRow drDetails in dtreturn.Rows)
                    {
                        listHeader.Add(new GetPendingRtnRequestDetail
                        {
                            prd_ID = drDetails["rrd_prd_ID"].ToString(),
                            HUOM = drDetails["rrd_HUOM"].ToString(),
                            HQty = drDetails["rrd_HQty"].ToString(),
                            LUOM = drDetails["rrd_LUOM"].ToString(),
                            LQty = drDetails["rrd_LQty"].ToString(),

                            prd_Name = drDetails["prd_Name"].ToString(),

                            prd_LongDesc = drDetails["prd_ItemLongDesc"].ToString(),
                            prd_cat_id = drDetails["prd_cat_ID"].ToString(),
                            prd_sub_ID = drDetails["prd_sct_ID"].ToString(),
                            prd_brd_ID = drDetails["prd_brd_ID"].ToString(),
                            prd_NameArabic = drDetails["prd_NameArabic"].ToString(),
                            prd_LongDescArabic = drDetails["prd_ArabicItemLongDesc"].ToString(),
                            prd_Image = drDetails["prd_Image"].ToString(),

                            InvoiceNumber = drDetails["inv_InvoiceID"].ToString(),
                            inv_ID = drDetails["rrh_inv_ID"].ToString(),
                            prd_code = drDetails["prd_Code"].ToString(),
                            Image = drDetails["Image"].ToString(),
                            Reason = drDetails["rsn_ID"].ToString(),
                            Vat= drDetails["rrd_Vat"].ToString(),
                            GrandTotal = drDetails["rrd_GrandTotal"].ToString(),
                            HigherPrice= drDetails["rrd_HigherPrice"].ToString(),
                            LowerPrice= drDetails["rrd_LowerPrice"].ToString(), 




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
                JSONString = "GetScheduleRtnHeaderData - " + ex.Message.ToString();
            }
            dm.TraceService("GetScheduleRtnHeaderData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

        public string GetScheduleRtnInvoiceHeaderData([FromForm] SRRequestInvoicesIn inputParams)
        {
            dm.TraceService("GetScheduleRtnInvoiceHeaderData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string[] arr = { userID.ToString() };
            DataTable dtreturn = dm.loadList("SelReturnRequestInvoiceData", "sp_ReturnRequest", rotID.ToString(), arr);

            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetRtnRequestInvoiceHeader> listHeader = new List<GetRtnRequestInvoiceHeader>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {
                        listHeader.Add(new GetRtnRequestInvoiceHeader
                        {

                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            date = dr["CreatedDate"].ToString(),
                            cus_ID = dr["inv_cus_ID"].ToString(),
                            inv_ID = dr["inv_ID"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),

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
                JSONString = "GetScheduleRtnInvoiceHeaderData - " + ex.Message.ToString();
            }
            dm.TraceService("GetScheduleRtnInvoiceHeaderData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetScheduleRtnInvoiceDetailData([FromForm] SRRequestInvoicesDetailIn inputParams)
        {
            dm.TraceService("GetScheduleRtnInvoiceHeaderData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.inv_ID == null ? "0" : inputParams.inv_ID;
            string[] arr = {  };

            DataSet dtreturn = dm.loadListDS("SelReturnRequestInvoiceDetailData", "sp_ReturnRequest", rotID.ToString(), arr);  
            DataTable itemData = dtreturn.Tables[0];
            DataTable batchData = dtreturn.Tables[1];

            try
            {
                if (itemData.Rows.Count > 0)
                {
                    List<GetRtnRequestInvoiceDetail> listHeader = new List<GetRtnRequestInvoiceDetail>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<RTNInvoiceBatchSerial> listBatchSerial = new List<RTNInvoiceBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["ind_itm_ID"].ToString() == drDetails["ind_itm_ID"].ToString())
                            {
                                listBatchSerial.Add(new RTNInvoiceBatchSerial
                                {
                                    BatchNumber = drDetails["slb_Number"].ToString(),
                                    ExpiryDate = drDetails["slb_ExpiryDate"].ToString(),
                                    BaseUOM = drDetails["slb_BaseUOM"].ToString(),
                                    OrderedQty = drDetails["slb_OrderedQty"].ToString(),
                                    AdjustedQty = drDetails["slb_AdjustedQty"].ToString(),
                                    LoadInQty = drDetails["slb_LoadInQty"].ToString(),
                                    ind_itm_ID = drDetails["ind_itm_ID"].ToString(),
                                    inv_ID = drDetails["inv_ID"].ToString(),
                                  
                                });
                            }
                        }

                        listHeader.Add(new GetRtnRequestInvoiceDetail
                        {

                            prd_ID = dr["ind_itm_ID"].ToString(),
                            HUOM = dr["HUOM"].ToString(),
                            HQty = dr["HQty"].ToString(),
                            LUOM = dr["LUOM"].ToString(),
                            LQty = dr["LQty"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_LongDesc = dr["prd_ItemLongDesc"].ToString(),
                            prd_cat_id = dr["prd_cat_ID"].ToString(),
                            prd_sub_ID = dr["prd_sct_ID"].ToString(),
                            prd_brd_ID = dr["prd_brd_ID"].ToString(),
                            prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            prd_LongDescArabic = dr["prd_ArabicItemLongDesc"].ToString(),
                            prd_Image = dr["prd_Image"].ToString(),
                            HigherPrice = dr["ind_HigherPrice"].ToString(),
                            LowerPrice = dr["ind_LowerPrice"].ToString(),
                            VatPerc = dr["ind_VATPerc"].ToString(),
                            prd_code = dr["prd_Code"].ToString(),                          
                            prd_IsBatchItem = dr["prd_IsBatchItem"].ToString(),
                            BatchSerial = listBatchSerial,
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
                JSONString = "GetScheduleRtnInvoiceHeaderData - " + ex.Message.ToString();
            }
            dm.TraceService("GetScheduleRtnInvoiceHeaderData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

        public string GetActionTakenScheduleRtnData([FromForm] SRRequestHeaderIn inputParams)
        {
            dm.TraceService("GetActionTakenScheduleRtnData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string[] arr = { userID.ToString() };
           
            DataTable dtreturn = dm.loadList("SelActionTakenReturnRequestData", "sp_ReturnRequest", rotID.ToString(), arr);

            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetPendingRtnRequestHeader> listHeader = new List<GetPendingRtnRequestHeader>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {
                        listHeader.Add(new GetPendingRtnRequestHeader
                        {

                            RequestID= dr["rrh_ID"].ToString(),
                            InvoiceNumber = dr["inv_InvoiceID"].ToString(),
                            RequestNumber = dr["rrh_RequestNumber"].ToString(),
                            date = dr["CreatedDate"].ToString(),
                            cus_ID = dr["rrh_cus_ID"].ToString(),
                            Request_ID = dr["rrh_ID"].ToString(),
                            inv_ID = dr["rrh_inv_ID"].ToString(),
                            ReturnType = dr["rrh_ReturnType"].ToString(),
                            SubTotal = dr["rrh_SubTotal"].ToString(),
                            Vat = dr["rrh_VatPerc"].ToString(),
                            Total = dr["rrh_Total"].ToString(),
                            Status = dr["Status"].ToString()

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
                JSONString = "GetActionTakenScheduleRtnData - " + ex.Message.ToString();
            }
            dm.TraceService("GetActionTakenScheduleRtnData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetActionTakenScheduleRtnDetail([FromForm] SRRequestDetailIn inputParams)
        {
            dm.TraceService("GetActionTakenScheduleRtnDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string RequestID = inputParams.RequestID == null ? "0" : inputParams.RequestID;
           
           

            DataTable dtreturn = dm.loadList("SelActionTakenReturnRequestDetail", "sp_ReturnRequest", RequestID.ToString());

            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetPendingRtnRequestDetail> listHeader = new List<GetPendingRtnRequestDetail>();
                    foreach (DataRow drDetails in dtreturn.Rows)
                    {
                        listHeader.Add(new GetPendingRtnRequestDetail
                        {

                            prd_ID = drDetails["rrd_prd_ID"].ToString(),
                            HUOM = drDetails["rrd_HUOM"].ToString(),
                            HQty = drDetails["rrd_HQty"].ToString(),
                            LUOM = drDetails["rrd_LUOM"].ToString(),
                            LQty = drDetails["rrd_LQty"].ToString(),

                            prd_Name = drDetails["prd_Name"].ToString(),

                            prd_LongDesc = drDetails["prd_ItemLongDesc"].ToString(),
                            prd_cat_id = drDetails["prd_cat_ID"].ToString(),
                            prd_sub_ID = drDetails["prd_sct_ID"].ToString(),
                            prd_brd_ID = drDetails["prd_brd_ID"].ToString(),
                            prd_NameArabic = drDetails["prd_NameArabic"].ToString(),
                            prd_LongDescArabic = drDetails["prd_ArabicItemLongDesc"].ToString(),
                            prd_Image = drDetails["prd_Image"].ToString(),

                            InvoiceNumber = drDetails["inv_InvoiceID"].ToString(),
                            inv_ID = drDetails["rrh_inv_ID"].ToString(),
                            prd_code = drDetails["prd_Code"].ToString(),
                            Image = drDetails["Image"].ToString(),
                            Reason = drDetails["rsn_ID"].ToString(),
                            Status = drDetails["Status"].ToString(),
                            HigherPrice = drDetails["rrd_HigherPrice"].ToString(),
                            LowerPrice = drDetails["rrd_LowerPrice"].ToString(),

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
                JSONString = "GetActionTakenScheduleRtnDetail - " + ex.Message.ToString();
            }
            dm.TraceService("GetActionTakenScheduleRtnDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

        public string PostScheduledRetReqAttachment([FromForm] PostAttachment inputParams)
        {
            dm.TraceService("PostScheduledRetReqAttachment STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserID == null ? "0" : inputParams.UserID;

            dm.TraceService("TransID:" + TransID);
            

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("file Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/Attachment" );
                        dm.TraceService("Physical Path Generated" + physicalPath.ToString());
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                            dm.TraceService("Directory Created");
                        }
                        string image = "";
                        var imagePath = physicalPath + "/";
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                            dm.TraceService("Directory for Image Path Created");
                        }
                        string ReceiptImages = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started" + y.ToString());
                            imageFiles[y] = HttpReq.Files[y];
                            long fileSize = imageFiles[y].ContentLength;
                            string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            if (y == 0 && fileSize > 0)
                            {
                                ReceiptImages = "../UploadFiles/Attachment/" + REcimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                ReceiptImages += "," + "../UploadFiles/Attachment/" + REcimage;
                            }
                            else if (fileSize == 0)
                            {
                                ReceiptImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                    string[] arr = { userID.ToString(), ReceiptImages };
                    DataTable dt = dm.loadList("InsScheduledReturnAttachment", "sp_ReturnRequest", TransID.ToString(), arr);

                    List<GetUpdateStatus> listStatus = new List<GetUpdateStatus>();
                    if (dt.Rows.Count > 0)
                    {
                        List<GetUpdateStatus> listHeader = new List<GetUpdateStatus>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            listHeader.Add(new GetUpdateStatus
                            {
                                Mode = dr["Res"].ToString(),
                                Status = dr["Status"].ToString()
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
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PostScheduledRetReqAttachment ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }

        public string GetReturnPDF([FromForm] ReturnPDFIn inputParams)
        {
            dm.TraceService("GetOrderPDF STARTED ");
            dm.TraceService("==============================");
            try
            {

                string OrderID = inputParams.rtnID == null ? "0" : inputParams.rtnID;


                dm.TraceService("Value for Transaction" + OrderID.ToString());
                string url = ConfigurationManager.AppSettings.Get("BackendUrl");


                try
                {
                    var s = Server.MapPath("../../BO_Digits/en/Reports/license.key");
                    Stimulsoft.Base.StiLicense.LoadFromFile(s);
                    var report = new StiReport();
                    var path = Server.MapPath("../../BO_Digits/en/Reports/ReturnRequest.mrt");
                    dm.TraceService("s:" + s);
                    dm.TraceService("path:" + path);


                    report.Load(path);



                    string DB = ConfigurationManager.AppSettings.Get("MyDB");
                    ((StiSqlDatabase)report.Dictionary.Databases["BMReport"]).ConnectionString = DB;
                    report["@para2"] = OrderID.ToString();

                    StiOptions.Export.Pdf.AllowImportSystemLibraries = true;
                    var tempPdfPath = Server.MapPath("../../Downloads/Return.pdf");
                    dm.TraceService("pdf path:" + tempPdfPath);

                    MemoryStream ms = new MemoryStream();
                    report.Render();
                    report.ExportDocument(StiExportFormat.Pdf, ms);
                    System.IO.File.WriteAllBytes(tempPdfPath, ms.ToArray());
                    // Send the URL of the generated PDF file to client side
                    List<RtnPDFOut> listDns = new List<RtnPDFOut>();

                    listDns.Add(new RtnPDFOut
                    {
                        PDFRTNurl = url + "Downloads/Return.pdf"



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

            dm.TraceService("GetOrderPDF ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

        public string GetMultipleInvoiceItem([FromForm] GetMultipleInvoiceItemiN inputParams)
        {
            dm.TraceService("GetMultipleInvoiceItem STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string Rot_ID = inputParams.Rot_ID == null ? "0" : inputParams.Rot_ID;
            string Cus_ID = inputParams.Cus_ID == null ? "0" : inputParams.Cus_ID;


            string[] arr = { Cus_ID.ToString() };
            DataTable dtreturn = dm.loadList("SelectItemFromMultipleInv", "sp_ReturnRequest", Rot_ID.ToString(), arr);
           

            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetMultipleInvoiceItemOut> listHeader = new List<GetMultipleInvoiceItemOut>();
                    foreach (DataRow drDetails in dtreturn.Rows)
                    {
                        listHeader.Add(new GetMultipleInvoiceItemOut
                        {

                            prd_ID = drDetails["prd_ID"].ToString(),
                            prd_Code = drDetails["prd_Code"].ToString(),
                            prd_Name = drDetails["prd_Name"].ToString(),
                            rrd_HUOM = drDetails["rrd_HUOM"].ToString(),
                            rrd_HQty = drDetails["rrd_HQty"].ToString(),
                            rrd_LUOM = drDetails["rrd_LUOM"].ToString(),
                            rrd_LQty = drDetails["rrd_LQty"].ToString(),
                            rrd_HigherPrice = drDetails["rrd_HigherPrice"].ToString(),
                            rrd_LowerPrice = drDetails["rrd_LowerPrice"].ToString(),
                            rrd_LineTotal = drDetails["rrd_LineTotal"].ToString(),
                            rrd_Vat = drDetails["rrd_Vat"].ToString(),
                            rrd_GrandTotal = drDetails["rrd_GrandTotal"].ToString(),
                            prd_IsBatchItem = drDetails["prd_IsBatchItem"].ToString(),

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
                JSONString = "GetMultipleInvoiceItem - " + ex.Message.ToString();
            }
            dm.TraceService("GetMultipleInvoiceItem ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

        public string GetReturnItemInvoice([FromForm] GetReturnItemInvoiceIn inputParams)
        {
            dm.TraceService("GetReturnItemInvoice STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string prd_ID = inputParams.prd_ID == null ? "0" : inputParams.prd_ID;

            string[] arr = { };
            DataSet dtreturn = dm.loadListDS("SelectReturnItemInv", "sp_ReturnRequest", prd_ID.ToString(), arr);
            DataTable itemData = dtreturn.Tables[0];
            DataTable batchData = dtreturn.Tables[1];

            try
            {
                if (itemData.Rows.Count > 0)
                {
                    List<GetReturnItemInvoiceOut> listHeader = new List<GetReturnItemInvoiceOut>();
                    foreach (DataRow dr in itemData.Rows)
                    {

                        List<GetReturnItemInvoiceBatch> listBatchSerial = new List<GetReturnItemInvoiceBatch>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["rrh_inv_ID"].ToString() == drDetails["inv_id"].ToString())
                            {
                                listBatchSerial.Add(new GetReturnItemInvoiceBatch
                                {
                                    BatchNumber = drDetails["BatchNumber"].ToString(),
                                    ExpiryDate = drDetails["ExpiryDate"].ToString(),
                                    BaseUOM = drDetails["BaseUOM"].ToString(),
                                    OrderedQty = drDetails["OrderedQty"].ToString(),
                                    AdjustedQty = drDetails["AdjustedQty"].ToString(),
                                    LoadInQty = drDetails["LoadInQty"].ToString(),
                                    itm_ID = drDetails["rrd_prd_ID"].ToString(),
                                    inv_ID = drDetails["inv_ID"].ToString(),

                                });
                            }
                        }
                       
                        listHeader.Add(new GetReturnItemInvoiceOut
                        {

                            rrh_inv_ID = dr["rrh_inv_ID"].ToString(),
                            inv_InvoiceID = dr["inv_InvoiceID"].ToString(),
                            BatchSerial = listBatchSerial,

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
                JSONString = "GetReturnItemInvoice - " + ex.Message.ToString();
            }
            dm.TraceService("GetReturnItemInvoice ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

        public string GetMultipleInvoiceItemDetail([FromForm] GetMultipleInvoiceItemDetIn inputParams)
        {
            dm.TraceService("GetMultipleInvoiceItemDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string invID = inputParams.invID == null ? "0" : inputParams.invID;
            string prdID = inputParams.prdID == null ? "0" : inputParams.prdID;


            string[] arr = { prdID.ToString() };
            DataTable dtreturn = dm.loadList("SelectItemFromMultipleInvDetail", "sp_ReturnRequest", invID.ToString(), arr);

            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<GetMultipleInvoiceItemOut> listHeader = new List<GetMultipleInvoiceItemOut>();
                    foreach (DataRow drDetails in dtreturn.Rows)
                    {
                        listHeader.Add(new GetMultipleInvoiceItemOut
                        {

                            prd_ID = drDetails["prd_ID"].ToString(),
                            prd_Code = drDetails["prd_Code"].ToString(),
                            prd_Name = drDetails["prd_Name"].ToString(),
                            rrd_HUOM = drDetails["rrd_HUOM"].ToString(),
                            rrd_HQty = drDetails["rrd_HQty"].ToString(),
                            rrd_LUOM = drDetails["rrd_LUOM"].ToString(),
                            rrd_LQty = drDetails["rrd_LQty"].ToString(),
                            rrd_HigherPrice = drDetails["rrd_HigherPrice"].ToString(),
                            rrd_LowerPrice = drDetails["rrd_LowerPrice"].ToString(),
                            rrd_LineTotal = drDetails["rrd_LineTotal"].ToString(),
                            rrd_Vat = drDetails["rrd_Vat"].ToString(),
                            rrd_GrandTotal = drDetails["rrd_GrandTotal"].ToString()


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
                JSONString = "GetMultipleInvoiceItemDetail - " + ex.Message.ToString();
            }
            dm.TraceService("GetMultipleInvoiceItemDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

        public string InsMultipleInvReturnReq([FromForm] InsMultipleInvReturnReqHeader inputParams)
        {
            dm.TraceService("InsMultipleInvReturnReq STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<InsMultipleInvReturnReqDetails> itemData = JsonConvert.DeserializeObject<List<InsMultipleInvReturnReqDetails>>(inputParams.Detaildata);
                List<InsMultipleInvReturnReqBatch> BatchData = JsonConvert.DeserializeObject<List<InsMultipleInvReturnReqBatch>>(inputParams.BatchData);
                try
                {
                    string rotid = inputParams.rotid == null ? "0" : inputParams.rotid;
                    string cusid = inputParams.cusid == null ? "PA" : inputParams.cusid;
                    string subtotal = inputParams.subtotal == null ? "0" : inputParams.subtotal;
                    string Amount = inputParams.Amount == null ? "0" : inputParams.Amount;
                    string usrid = inputParams.usrid == null ? "0" : inputParams.usrid;
                    string cseID = inputParams.cseID == null ? "0" : inputParams.cseID;
                    string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                   string Type = inputParams.Type == null ? "0" : inputParams.Type;
                   string InvId = inputParams.InvId == null ? "0" : inputParams.InvId;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (InsMultipleInvReturnReqDetails id in itemData)
                            {
                                string[] arr = { id.itmid.ToString(), id.huom.ToString(), id.hqty.ToString(), id.luom.ToString(), id.lqty.ToString(),  id.amount.ToString(), id.rsnid.ToString() };
                                string[] arrName = { "ItemId", "HigherUOM", "HigherQty", "LowerUOM", "LowerQty", "Amount", "ReasonId" };
                                dm.createNode(arr, arrName, writer);
                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        InputXml = sw.ToString();
                    }

                    string InputBatchXml = "";

                    try
                    {
                        using (var sw = new StringWriter())
                        {
                            using (var writer = XmlWriter.Create(sw))
                            {

                                writer.WriteStartDocument(true);
                                writer.WriteStartElement("r");
                                int c = 0;
                                foreach (InsMultipleInvReturnReqBatch id in BatchData)
                                {
                                    string[] arr = { id.BatchNumber.ToString(), id.ExpiryDate.ToString(), id.BaseUOM.ToString(), id.OrderedQty.ToString(), id.AdjustedQty.ToString(), id.LoadInQty.ToString(), id.itm_ID.ToString(), id.inv_ID.ToString() };
                                    string[] arrName = { "BatchNumber", "ExpiryDate", "BaseUOM", "OrderedQty", "AdjustedQty", "LoadInQty", "itm_ID" , "inv_ID" };
                                    dm.createNode(arr, arrName, writer);
                                }

                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                                writer.Close();
                            }
                            InputBatchXml = sw.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "Issue while creating Xml - " + ex.Message.ToString();
                    }

                    try
                    {
                        string[] arr = { rotid.ToString(), cusid.ToString(), cseID.ToString(), Type.ToString(), InvId.ToString(), InputXml.ToString(), subtotal, Amount, usrid , InputBatchXml.ToString() };
                        DataTable dt = dm.loadList("InsMutipleInvReturnReq", "sp_AppServices", udpID.ToString(), arr);

                        List<InsMultipleInvReturnReqStatus> listStatus = new List<InsMultipleInvReturnReqStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<InsMultipleInvReturnReqStatus> listHeader = new List<InsMultipleInvReturnReqStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new InsMultipleInvReturnReqStatus
                                {
                                    Mode = dr["Res"].ToString(),
                                    Status = dr["Status"].ToString(),
                                    ReqID = dr["ReqID"].ToString()

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
            dm.TraceService("InsMultipleInvReturnReq ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
    }
}