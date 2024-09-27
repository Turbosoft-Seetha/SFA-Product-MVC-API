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
    public class OrderController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]
        public string GetDraftOrder([FromForm] DraftOrderIn inputParams)
        {
            dm.TraceService("GetDraftOrder STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string[] arr = { userID.ToString() };
            DataSet dt = dm.loadListDS("SelDraftOrders", "sp_SFA_App_Sales", rotID.ToString(), arr);
            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<DraftOrderHeader> listHeader = new List<DraftOrderHeader>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<DraftOrderDetail> listDetail = new List<DraftOrderDetail>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {

                            if (drDetails["odd_ord_ID"].ToString() == dr["ord_ID"].ToString())
                            {


                                listDetail.Add(new DraftOrderDetail
                                {

                                    prd_ID = drDetails["odd_itm_ID"].ToString(),
                                    HUOM = drDetails["odd_HigherUOM"].ToString(),
                                    HQty = drDetails["odd_HigherQty"].ToString(),
                                    LUOM = drDetails["odd_LowerUOM"].ToString(),
                                    LQty = drDetails["odd_LowerQty"].ToString(),

                                    prd_Name = drDetails["prd_Name"].ToString(),
                                    prd_code = drDetails["prd_Code"].ToString(),
                                    HigherPrice = drDetails["odd_HigherPrice"].ToString(),
                                    LowerPrice = drDetails["odd_LowerPrice"].ToString(),
                                    Price = drDetails["odd_Price"].ToString(),
                                    TotalQty = drDetails["odd_TotalQty"].ToString(),
                                    SubTotal = drDetails["odd_SubTotal"].ToString(),
                                    VatPercent = drDetails["odd_VATPercent"].ToString(),
                                    VatAmount = drDetails["odd_VATAmount"].ToString(),
                                    Discount = drDetails["odd_Discount"].ToString(),
                                    GrandTotal = drDetails["odd_GrandTotal"].ToString(),
                                    TransType = drDetails["odd_TransType"].ToString(),
                                    StdHighPrice = drDetails["odd_StdHigherPrice"].ToString(),
                                    StdLowPrice = drDetails["odd_StdLowerPrice"].ToString(),
                                    SellingHighPrice = drDetails["odd_SellingHigherPrice"].ToString(),
                                    SellingLowPrice = drDetails["odd_SellingLowerPrice"].ToString(),
                                    HigherUPC = drDetails["HigherUPC"].ToString(),
                                    LowerUPC = drDetails["LowerUPC"].ToString()

                                });
                            }
                        }

                        listHeader.Add(new DraftOrderHeader
                        {

                            ord_ID = dr["ord_ID"].ToString(),
                            OrderID = dr["OrderID"].ToString(),
                            date = dr["CreatedDate"].ToString(),
                            Time= dr["CreatedTime"].ToString(),
                            OrderDetail = listDetail,

                            cus_ID = dr["ord_cus_ID"].ToString(),
                            rot_ID = dr["ord_rot_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                              SubTotal = dr["ord_SubTotal"].ToString(),
                            VAT = dr["ord_VAT"].ToString(),
                            GrandTotal = dr["ord_GrandTotal"].ToString(),
                            ExpectedDelDate = dr["ord_ExpectedDelDate"].ToString(),
                            PayMode = dr["ord_PayMode"].ToString(),
                            Discount = dr["ord_Discount"].ToString(),
                            SubTotalWODiscount = dr["ord_SubTotal_WODiscount"].ToString(),
                          
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
                JSONString = "GetDraftOrder - " + ex.Message.ToString();
            }
            dm.TraceService("GetDraftOrder ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string PostQuotationConfirmation([FromForm] quotationOrderIn inputParams)
        {
            dm.TraceService("PostQuotationConfirmation STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            try
            {
                List<quotationProducts> itemData = JsonConvert.DeserializeObject<List<quotationProducts>>(inputParams.XMLdata);


                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string ord_OrderRemarks = inputParams.ord_OrderRemarks == null ? "" : inputParams.ord_OrderRemarks;
                string ord_rot_ID = inputParams.ord_rot_ID == null ? "0" : inputParams.ord_rot_ID;
                string ord_usr_ID = inputParams.ord_usr_ID == null ? "0" : inputParams.ord_usr_ID;

                string ord_Platform = inputParams.ord_Platform == null ? "" : inputParams.ord_Platform;
                string CreatedDate = inputParams.CreatedDate == null ? "" : inputParams.CreatedDate;
                string GeoCode = inputParams.GeoCode == null ? "" : inputParams.GeoCode;
                string GeoCodeName = inputParams.GeoCodeName == null ? "" : inputParams.GeoCodeName;
                string CreationMode = inputParams.CreationMode == null ? "" : inputParams.CreationMode;
                string ord_cse_ID = inputParams.ord_cse_ID == null ? "0" : inputParams.ord_cse_ID;
                string ord_udp_ID = inputParams.ord_udp_ID == null ? "0" : inputParams.ord_udp_ID;
                string ord_AppOrderID = inputParams.ord_AppOrderID == null ? "" : inputParams.ord_AppOrderID;
                string ord_SubTotal = inputParams.ord_SubTotal == null ? "0" : inputParams.ord_SubTotal;
                string ord_VAT = inputParams.ord_VAT == null ? "0" : inputParams.ord_VAT;
                string ord_GrandTotal = inputParams.ord_GrandTotal == null ? "0" : inputParams.ord_GrandTotal;
                string ord_ExpectedDelDate = inputParams.ord_ExpectedDelDate == null ? "" : inputParams.ord_ExpectedDelDate;

                string PayMode = inputParams.PayMode == null ? "" : inputParams.PayMode;

                string VoidMode = inputParams.VoidMode == null ? "" : inputParams.VoidMode;

                string VoidTime = inputParams.VoidTime == null ? "" : inputParams.VoidTime;

                string Void = inputParams.Void == null ? "" : inputParams.Void;
                string CreditAmntOverrideKey = inputParams.CreditAmntOverrideKey == null ? "" : inputParams.CreditAmntOverrideKey;
                string CreditAmntOverridePass = inputParams.CreditAmntOverridePass == null ? "" : inputParams.CreditAmntOverridePass;
                string CreditDayOverrideKey = inputParams.CreditDayOverrideKey == null ? "" : inputParams.CreditDayOverrideKey;
                string CreditDayOverridePass = inputParams.CreditDayOverridePass == null ? "" : inputParams.CreditDayOverridePass;
                string VoidOverrideKey = inputParams.VoidOverrideKey == null ? "" : inputParams.VoidOverrideKey;
                string VoidOverridePass = inputParams.VoidOverridePass == null ? "" : inputParams.VoidOverridePass;
                string VoidUser = inputParams.VoidUser == null ? "" : inputParams.VoidUser;
                string VoidPlatform = inputParams.VoidPlatform == null ? "" : inputParams.VoidPlatform;
                string Discount = inputParams.Discount == null ? "0" : inputParams.Discount;
                string ord_SubTotal_WODiscount = inputParams.ord_SubTotal_WODiscount == null ? "0" : inputParams.ord_SubTotal_WODiscount;
                string ord_Type = inputParams.ord_Type == null ? "" : inputParams.ord_Type;

                string ProductXml = "";

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;

                        foreach (quotationProducts id in itemData)
                        {
                            string[] arr = { id.itmID.ToString(), id.HigherUOM.ToString(), id.LowerUOM.ToString(), id.HigherQty.ToString(), id.LowerQty.ToString(),
                                id.LowerPrice.ToString(), id.HigherPrice.ToString(),id.Price.ToString(), id.TotalQty.ToString(), id.odd_SubTotal.ToString(),
                                id.odd_VATPercent.ToString(),id.odd_VATAmount.ToString(), id.odd_Discount.ToString(),
                            id.odd_GrandTotal.ToString(), id.odd_TransType.ToString(), id.odd_StdHigherPrice.ToString(), id.odd_StdLowerPrice.ToString(), id.odd_SellingHigherPrice.ToString(),
                                id.odd_SellingLowerPrice.ToString()};
                            string[] arrName = { "itmID", "HigherUOM", "LowerUOM", "HigherQty", "LowerQty", "LowerPrice", "HigherPrice", "Price","TotalQty", "odd_SubTotal", "odd_VATPercent",
                                "odd_VATAmount","odd_Discount","odd_GrandTotal", "odd_TransType", "odd_StdHigherPrice", "odd_StdLowerPrice","odd_SellingHigherPrice", "odd_SellingLowerPrice"};
                            dm.createNode(arr, arrName, writer);

                        }


                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                    ProductXml = sw.ToString();
                }
                string jsonArrayQulf = inputParams.XMLdataQlftn;
                string QualificationXml = "";
                if (jsonArrayQulf != "[]")
                {
                    List<quotationQualification> Qualification = JsonConvert.DeserializeObject<List<quotationQualification>>(inputParams.XMLdataQlftn);


                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;

                            foreach (quotationQualification id in Qualification)
                            {
                                string[] arr = { id.prd_ID.ToString(), id.prm_ID.ToString(), id.HigherQty.ToString(), id.LowerQty.ToString(), id.HigherUOM.ToString(),
                                id.LowerUOM.ToString()};
                                string[] arrName = { "prd_ID", "prm_ID", "HigherQty", "LowerQty", "HigherUOM", "LowerUOM" };
                                dm.createNode(arr, arrName, writer);

                            }







                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        QualificationXml = sw.ToString();
                    }
                }

                string jsonArrayAssgn = inputParams.XMLdataAssgn;
                string AssignmentXml = "";
                if (jsonArrayAssgn != "[]")
                {
                    List<quotationAssignment> Assignment = JsonConvert.DeserializeObject<List<quotationAssignment>>(inputParams.XMLdataAssgn);


                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;

                            foreach (quotationAssignment id in Assignment)
                            {
                                string[] arr = { id.prd_ID.ToString(), id.prm_ID.ToString(), id.HigherQty.ToString(), id.LowerQty.ToString(), id.HigherUOM.ToString(),
                                id.LowerUOM.ToString(),id.TotalQty.ToString()};
                                string[] arrName = { "prd_ID", "prm_ID", "HigherQty", "LowerQty", "HigherUOM", "LowerUOM", "TotalQty" };
                                dm.createNode(arr, arrName, writer);

                            }




                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        AssignmentXml = sw.ToString();
                    }

                }
                var physicalPath = Server.MapPath("../../UploadFiles/OrderSign");
                dm.TraceService("Physical Path Generated: " + physicalPath.ToString());

                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                    dm.TraceService("Directory Created");
                }

                string imagePath = physicalPath + "/";
                string signpath = "";
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                    dm.TraceService("Directory for Image Path Created");
                }

                string ImageBase64 = inputParams.Image;

                if (!string.IsNullOrEmpty(ImageBase64))
                {
                    try
                    {



                        byte[] imageBytes = Convert.FromBase64String(ImageBase64);

                        // Save or process the image as needed
                        string imageFileName = DateTime.Now.ToString("HHmmss") + ord_rot_ID + ord_udp_ID + ord_usr_ID + "_Uploaded.jpg"; // Set a suitable file name
                        string imagePathWithName = Path.Combine(imagePath, imageFileName);

                        using (FileStream fs = new FileStream(imagePathWithName, FileMode.Create))
                        {
                            fs.Write(imageBytes, 0, imageBytes.Length);
                        }

                        // Set the image path or perform additional actions as needed
                        signpath = "../UploadFiles/OrderSign/" + imageFileName;
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






                string[] ar = { ord_OrderRemarks.ToString(), ord_rot_ID.ToString(), ord_usr_ID.ToString(), ord_Platform.ToString(), ProductXml.ToString(),
                CreatedDate,GeoCode,GeoCodeName,CreationMode,ord_cse_ID,ord_udp_ID,ord_AppOrderID,ord_SubTotal,ord_VAT,ord_GrandTotal,ord_ExpectedDelDate,
                QualificationXml,AssignmentXml,PayMode,VoidMode,VoidTime,Void,CreditAmntOverrideKey,CreditAmntOverridePass,CreditDayOverrideKey,CreditDayOverridePass,
                VoidOverrideKey,VoidOverridePass,VoidUser,VoidPlatform,Discount,ord_SubTotal_WODiscount,ord_Type,signpath};
                DataTable dt = dm.loadList("UpdateQuotationUpdates", "sp_SFA_APP_Sales", cus_ID.ToString(), ar);






                if (dt.Rows.Count > 0)
                {
                    List<quotationOrderOut> listoutput = new List<quotationOrderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listoutput.Add(new quotationOrderOut
                        {
                            Res = dr["Res"].ToString(),
                            Title = dr["Title"].ToString()



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
                dm.TraceService(" PostQuotationConfirmation Exception - " + ex.Message.ToString());
                dm.TraceService(ex.Message.ToString());
            }
            dm.TraceService("PostQuotationConfirmation ENDED - " + DateTime.Now.ToString());
            dm.TraceService("==================");
            return JSONString;
        }
        public string GetOrderHeader([FromForm] OrderStatusHeaderIN inputParams)
        {
            dm.TraceService("GetOrderHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string Date = inputParams.Date == null ? "0" : inputParams.Date;
            string[] arr = { Date.ToString() };
            DataTable  dt = dm.loadList("SelOrderHeader", "sp_SFA_App_Sales", rotID.ToString(), arr);
          



            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<OrderStatusHeaderOut> listHeader = new List<OrderStatusHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                       

                        listHeader.Add(new OrderStatusHeaderOut
                        {

                            ord_ID = dr["ord_ID"].ToString(),
                            OrderID = dr["OrderID"].ToString(),
                            date = dr["CreatedDate"].ToString(),
                            Time = dr["CreatedTime"].ToString(),
                           cus_ID = dr["ord_cus_ID"].ToString(),
                            rot_ID = dr["ord_rot_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            SubTotal = dr["ord_SubTotal"].ToString(),
                            VAT = dr["ord_VAT"].ToString(),
                            GrandTotal = dr["ord_GrandTotal"].ToString(),
                            ExpectedDelDate = dr["ord_ExpectedDelDate"].ToString(),
                            PayMode = dr["ord_PayMode"].ToString(),
                            Discount = dr["ord_Discount"].ToString(),
                            SubTotalWODiscount = dr["ord_SubTotal_WODiscount"].ToString(),

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
                JSONString = "GetOrderHeader - " + ex.Message.ToString();
            }
            dm.TraceService("GetOrderHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetOrderDetail([FromForm] OrderDetailIN inputParams)
        {
            dm.TraceService("GetOrderDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ordID = inputParams.ordID == null ? "0" : inputParams.ordID;
           
            DataTable dt = dm.loadList("SelOrderDetail", "sp_SFA_App_Sales", ordID.ToString());




            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<OrderStatusDetailOut> listHeader = new List<OrderStatusDetailOut>();
                    foreach (DataRow drDetails in dt.Rows)
                    {



                        listHeader.Add(new OrderStatusDetailOut
                        {

                                prd_ID = drDetails["odd_itm_ID"].ToString(),
                                HUOM = drDetails["odd_HigherUOM"].ToString(),
                                HQty = drDetails["odd_HigherQty"].ToString(),
                                LUOM = drDetails["odd_LowerUOM"].ToString(),
                                LQty = drDetails["odd_LowerQty"].ToString(),

                                prd_Name = drDetails["prd_Name"].ToString(),
                                prd_code = drDetails["prd_Code"].ToString(),
                                HigherPrice = drDetails["odd_HigherPrice"].ToString(),
                                LowerPrice = drDetails["odd_LowerPrice"].ToString(),
                                Price = drDetails["odd_Price"].ToString(),
                                TotalQty = drDetails["odd_TotalQty"].ToString(),
                                SubTotal = drDetails["odd_SubTotal"].ToString(),
                                VatPercent = drDetails["odd_VATPercent"].ToString(),
                                VatAmount = drDetails["odd_VATAmount"].ToString(),
                                Discount = drDetails["odd_Discount"].ToString(),
                                GrandTotal = drDetails["odd_GrandTotal"].ToString(),
                                TransType = drDetails["odd_TransType"].ToString(),
                                StdHighPrice = drDetails["odd_StdHigherPrice"].ToString(),
                                StdLowPrice = drDetails["odd_StdLowerPrice"].ToString(),
                                SellingHighPrice = drDetails["odd_SellingHigherPrice"].ToString(),
                                SellingLowPrice = drDetails["odd_SellingLowerPrice"].ToString(),
                                HigherUPC = drDetails["HigherUPC"].ToString(),
                                LowerUPC = drDetails["LowerUPC"].ToString()

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
                JSONString = "GetOrderDetail - " + ex.Message.ToString();
            }
            dm.TraceService("GetOrderDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string PostOrderLPO([FromForm] PostLPOAttachments inputParams)
        {
            dm.TraceService("PostOrderLPO STARTED ");
            dm.TraceService("==============================");
            try
            {

                string OrderNo = inputParams.OrderNo == null ? "0" : inputParams.OrderNo;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string attachType = inputParams.AttachType == null ? "0" : inputParams.AttachType;

                dm.TraceService("Value for Transaction" + OrderNo.ToString());
                dm.TraceService("Value for User" + UserID.ToString());
                dm.TraceService("Value for Attachament Type" + attachType.ToString());
                string ReceiptImages = "";
                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("file Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/OrderLPO");
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
                                ReceiptImages = "../UploadFiles/OrderLPO/" + REcimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                ReceiptImages += "," + "../UploadFiles/OrderLPO/" + REcimage;
                            }
                            else if (fileSize == 0)
                            {
                                ReceiptImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = { ReceiptImages, UserID };
                        DataTable dtDN = dm.loadList("InsOrderLPOAttachment", "sp_SFA_App_Sales", OrderNo, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<PostLPOAttachmentsOut> listDn = new List<PostLPOAttachmentsOut>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new PostLPOAttachmentsOut
                                {
                                    Mode = dr["Mode"].ToString(),
                                    Status = dr["Status"].ToString(),



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
            List<PostLPOAttachmentsOut> listDns = new List<PostLPOAttachmentsOut>();

            listDns.Add(new PostLPOAttachmentsOut
                {
                    Mode = "1",
                    Status = "Success",



                });
            
            JSONString = JsonConvert.SerializeObject(new
            {
                result = listDns
            });

            return JSONString;

            dm.TraceService("PostOrderLPO ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }
        public string PostCusTransAttachment([FromForm] PostTransAttachmentsIN inputParams)
        {
            dm.TraceService("PostCusTransAttachment STARTED ");
            dm.TraceService("==============================");
            try
            {

                string TransNo = inputParams.TransNo == null ? "0" : inputParams.TransNo;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string cusOperation = inputParams.CusOperation == null ? "0" : inputParams.CusOperation;


                dm.TraceService("Value for Transaction" + TransNo.ToString());
                dm.TraceService("Value for User" + UserID.ToString());

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("file Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/" + cusOperation);
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
                                ReceiptImages = "../UploadFiles/" + cusOperation + "/" + REcimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                ReceiptImages += "," + "../UploadFiles/" + cusOperation + "/" + REcimage;
                            }
                            else if (fileSize == 0)
                            {
                                ReceiptImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = { ReceiptImages, UserID, cusOperation };
                        DataTable dtDN = dm.loadList("InsCusTransAttachment", "sp_SFA_App_Sales", TransNo, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<PostTransAttachmentsOut> listDn = new List<PostTransAttachmentsOut>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new PostTransAttachmentsOut
                                {
                                    Mode = dr["Mode"].ToString(),
                                    Status = dr["Status"].ToString(),



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

            dm.TraceService("PostCusTransAttachment ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

        public string GetOrderPDF([FromForm] orderPDFIn inputParams)
        {
            dm.TraceService("GetOrderPDF STARTED ");
            dm.TraceService("==============================");
            try
            {

                string OrderID = inputParams.OrderID == null ? "0" : inputParams.OrderID;
              

                dm.TraceService("Value for Transaction" + OrderID.ToString());
                string url = ConfigurationManager.AppSettings.Get("BackendUrl");


                try
                {
                    var s = Server.MapPath("../../BO_Digits/en/Reports/license.key");
                    Stimulsoft.Base.StiLicense.LoadFromFile(s);
                    var report = new StiReport();
                    var path = Server.MapPath("../../BO_Digits/en/Reports/Orders.mrt");
                    dm.TraceService("s:" + s);
                    dm.TraceService("path:" + path);


                    report.Load(path);



                    string DB = ConfigurationManager.AppSettings.Get("MyDB");
                    ((StiSqlDatabase)report.Dictionary.Databases["BMReport"]).ConnectionString = DB;
                   
                    report["@para2"] = OrderID.ToString();

                    StiOptions.Export.Pdf.AllowImportSystemLibraries = true;
                    var tempPdfPath = Server.MapPath("../../Downloads/Orders.pdf");
                    dm.TraceService("pdf path:" + tempPdfPath);

                    MemoryStream ms = new MemoryStream();
                    report.Render();
                    report.ExportDocument(StiExportFormat.Pdf, ms);
                   System.IO.File.WriteAllBytes(tempPdfPath, ms.ToArray());
                    // Send the URL of the generated PDF file to client side
                    List<orderPDFOut> listDns = new List<orderPDFOut>();

                    listDns.Add(new orderPDFOut
                    {
                        PDFurl = url + "Downloads/Orders.pdf"



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
		public string PostFreeSampleApproval([FromForm] PostfreeSampleData inputParams)
		{
			dm.TraceService("PostReturnFreeSampleApproval STARTED " + DateTime.Now.ToString());
			dm.TraceService("============================================");
			try
			{
				List<PostFreeSamplelDetData> itemData = JsonConvert.DeserializeObject<List<PostFreeSamplelDetData>>(inputParams.JSONString);
				try
				{

					string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
					string CusId = inputParams.CusId == null ? "0" : inputParams.CusId;
					string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
					string UdpId = inputParams.UdpId == null ? "0" : inputParams.UdpId;
					string OrderId = inputParams.OrderID == null ? "0" : inputParams.OrderID;

					//string Status = inputParams.Status == null ? "" : inputParams.Status;
					string InputXml = "";
					using (var sw = new StringWriter())
					{
						using (var writer = XmlWriter.Create(sw))
						{
							writer.WriteStartDocument(true);
							writer.WriteStartElement("r");
							foreach (PostFreeSamplelDetData id in itemData)
							{
								string[] arr = { id.PrdID.ToString(), id.HigherQty.ToString(), id.HigherUOM.ToString(),id.LowerQty.ToString(), id.LowerUOM.ToString() };
								string[] arrName = { "PrdID", "HigherQty", "HigherUOM", "LowerQty", "LowerUOM" };
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
						string[] arr = { CusId.ToString(), RotId.ToString(),UdpId.ToString(),OrderId.ToString(), InputXml.ToString() };
						DataTable dt = dm.loadList("FreeSampleApproval", "sp_SFA_App_Sales", userID.ToString(), arr);

						List<GetFreeSampleApprovalStatus> listStatus = new List<GetFreeSampleApprovalStatus>();
						if (dt.Rows.Count > 0)
						{
							List<GetFreeSampleApprovalStatus> listHeader = new List<GetFreeSampleApprovalStatus>();
							foreach (DataRow dr in dt.Rows)
							{
								listHeader.Add(new GetFreeSampleApprovalStatus
								{
									Res = dr["Res"].ToString(),
									Title = dr["Title"].ToString(),
									Descr = dr["Descr"].ToString(),
									ReturnId = dr["ReturnId"].ToString(),
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
			dm.TraceService("PostReturnFreeSampleApproval ENDED " + DateTime.Now.ToString());
			dm.TraceService("========================================");
			return JSONString;
		}
		public string GetFreeSampleApprovalHeaderStatus([FromForm] GetFreeHeaderStatus inputParams)
		{
			dm.TraceService("GetFreeSampleApprovalheaderStatus STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			string cusId = inputParams.CusId == null ? "0" : inputParams.CusId;
			string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
			string ReturnId = inputParams.ReturnId == null ? "0" : inputParams.ReturnId;

			string[] arr = { RotId.ToString(), ReturnId.ToString() };
			DataTable dtStatus = dm.loadList("SelFreeSampleHeaderApproval", "sp_SFA_App_Sales", cusId.ToString(), arr);

			try
			{
				if (dtStatus.Rows.Count > 0)
				{
					List<GetHeaderStatus> listHeader = new List<GetHeaderStatus>();
					foreach (DataRow dr in dtStatus.Rows)
					{
						listHeader.Add(new GetHeaderStatus
						{
							ApprovalStatus = dr["Status"].ToString()

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
				dm.TraceService("GetFreeSampleApprovalheaderStatus  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetFreeSampleApprovalheaderStatus ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}
		public string GetFreeSampleApprovalDetailStatus([FromForm] GetFreeHeaderStatus inputParams)
		{
			dm.TraceService("GetFreeSampleApprovalDetailStatus STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			string cusId = inputParams.CusId == null ? "0" : inputParams.CusId;
			string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
			string ReturnId = inputParams.ReturnId == null ? "0" : inputParams.ReturnId;
			string[] arr = { RotId.ToString(), ReturnId.ToString() };
			DataTable dtReturnStatus = dm.loadList("SelFreeSampleDetApproval", "sp_SFA_App_Sales", cusId.ToString(), arr);

			try
			{
				if (dtReturnStatus.Rows.Count > 0)
				{
					List<GetDetFreeSapmpleApprovalStatus> listHeader = new List<GetDetFreeSapmpleApprovalStatus>();
					foreach (DataRow dr in dtReturnStatus.Rows)
					{
						listHeader.Add(new GetDetFreeSapmpleApprovalStatus
						{
							ApprovalStatus = dr["Status"].ToString(),
							ProductId = dr["fsa_prd_ID"].ToString(),
							ReasonID = dr["fsa_approvalReasonId"].ToString(),

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

			dm.TraceService("GetFreeSampleApprovalDetailStatus ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}
	}
}