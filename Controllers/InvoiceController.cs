using System;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;

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
using EllipticCurve.Utils;
using System.Web.UI.WebControls;

namespace MVC_API.Controllers
{
    public class InvoiceController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]
        public string PostTransactionalImage([FromForm] PostAttachments inputParams)
        {
            dm.TraceService("PostTransactionalImage STARTED ");
            dm.TraceService("==============================");
            try
            {
                string mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string invoiceID = inputParams.InvoiceID == null ? "0" : inputParams.InvoiceID;
                string userID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string attachType = inputParams.AttachType == null ? "0" : inputParams.AttachType;

                dm.TraceService("Value for Mode" + mode.ToString());
                dm.TraceService("Value for Transaction" + invoiceID.ToString());
                dm.TraceService("Value for User" + userID.ToString());
                dm.TraceService("Value for Attachament Type" + attachType.ToString());
                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");
                        string newServerBasePath = ConfigurationManager.AppSettings["NewServerBasePath"];
                        var physicalPath = Server.MapPath("../../TransactionalDocuments/" + attachType + "/Images");
                        dm.TraceService("Physical Path Generated" + physicalPath.ToString());
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                            dm.TraceService("Directory Created");
                        }
                        string image = "";
                        var imagePath = physicalPath + "/" + invoiceID;
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                            dm.TraceService("Directory for Image Path Created");
                        }

                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started" + y.ToString());
                            imageFiles[y] = HttpReq.Files[y];
                            image = imagePath + "/" + imageFiles[y].FileName + (DateTime.Now.ToString("HHmmss") + ".jpg");
                            imageFiles[y].SaveAs(image);
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }


                        List<GetInsertAttachmentStatus> listStatus = new List<GetInsertAttachmentStatus>();
                        listStatus.Add(new GetInsertAttachmentStatus
                        {
                            Mode = "1",
                            Status = "Success"
                        });
                        string JSONString = JsonConvert.SerializeObject(new
                        {
                            result = listStatus
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
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PostTransactionalImage ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }
        public string PostStampedCopyBackend([FromForm] PostStampedBackndIn inputParams)
        {
            dm.TraceService("PostStampedCopyBackend STARTED ");
            dm.TraceService("==============================");
            try
            {
                //string dln_ID = inputParams.dln_ID == null ? "0" : inputParams.dln_ID;
                string INV_ID = HttpContext.Request.Form["INV_ID"];
                dm.TraceService("Value for INV_ID -" + INV_ID.ToString());

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] PDFFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("pdf Received in Httpreq -" + PDFFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");
                       
                        var physicalPath = Server.MapPath("../../TransactionalDocuments/Stamped/PDF");
                        dm.TraceService("Physical Path Generated -" + physicalPath.ToString());
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                            dm.TraceService("Directory Created");
                        }
                        string pdf = "";
                        var pdfPath = physicalPath;

                        string pdfFile = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started -" + y.ToString());
                            PDFFiles[y] = HttpReq.Files[y];
                            string pdfattch = (DateTime.Now.ToString("HHmmss") + PDFFiles[y].FileName);
                            pdf = pdfPath + "/" + (DateTime.Now.ToString("HHmmss") + PDFFiles[y].FileName);
                            PDFFiles[y].SaveAs(pdf);
                            if (y == 0)
                            {
                                pdfFile = "../../TransactionalDocuments/Stamped/PDF/" + pdfattch;

                            }
                            else
                            {
                                pdfFile += "," + "../../TransactionalDocuments/Stamped/PDF/" + pdfattch;
                            }
                            dm.TraceService("pdfFile -" + PDFFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended -" + y.ToString());
                        }

                        string[] ar = { pdfFile.ToString() };
                        DataTable dtDN = dm.loadList("UpdateStampedCopy", "sp_Transaction", INV_ID.ToString(), ar);

                        if (dtDN.Rows.Count > 0)
                        {
                            List<GetDeliNoteInsertStatus> listDn = new List<GetDeliNoteInsertStatus>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new GetDeliNoteInsertStatus
                                {
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    Descr = dr["Descr"].ToString()


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

            dm.TraceService("PostStampedCopyBackend ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }
        public string GenerateDN_StampedPDF()

        {
            dm.TraceService("GenerateDN_StampedPDF Started");
            dm.TraceService("================================");

            var ImagesPath = Server.MapPath("../../TransactionalDocuments/" + "Stamped" + "/Images");
            dm.TraceService("ImagesPath" + ImagesPath);
            var FinalPath = Server.MapPath("../../TransactionalDocuments/" + "Stamped" + "/PDF");
            dm.TraceService("FinalPath" + FinalPath);
            string[] allFiles = Directory.GetDirectories(ImagesPath, "*.*", SearchOption.AllDirectories);

            foreach (string dir in allFiles)
            {
                dm.TraceService("FIlename" + dir);
                string lastDirName = Path.GetFileName(dir);
                string finalFileName = lastDirName + ".pdf";
                string res = dm.CombineImagesToPdf(dir, FinalPath + "/" + finalFileName);
                dm.TraceService("Value for Res" + res.ToString());
                if (res.Equals("1"))
                {


                    try
                    {
                        DataSet dsTransAttachment = new DataSet();

                        DataTable dtTransAttachment = new DataTable();
                        dtTransAttachment.Columns.Add("AttachmentPath", typeof(string));
                        dtTransAttachment.Columns.Add("AttachmentType", typeof(string));

                        dtTransAttachment.Rows.Add("/TransactionalDocuments/Stamped/PDF/" + finalFileName, "STAMPED");
                        dsTransAttachment.Tables.Add(dtTransAttachment);

                        try
                        {
                            string[] keys = { "@Mode", "@TransactionID", "@UserID" };
                            string[] values = { "DN", lastDirName, "" };
                            string[] arr = { "@TransAttachment" };
                            DataSet Value = dm.bulkUpdate(dsTransAttachment, arr, keys, values, "sp_TransactionalAttachment");

                            //try
                            //{
                            //    if (Directory.Exists(dir))
                            //    {
                            //        Directory.Delete(dir, true);
                            //        dm.TraceService("Image Directory Deleted");
                            //    }
                            //    else
                            //    {
                            //        dm.TraceService("The folder does not exist.");
                            //    }
                            //}
                            //catch (Exception ex)
                            //{
                            //    Console.WriteLine($"Error while deleting folder: {ex.Message}");
                            //}
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
                else
                {

                    JSONString = "NoDataImage - " + "Image Upload failed";

                }
               
            }
            return JSONString;
        }
        public string InsSettlementImg([FromForm] InsSettlementRequestIn inputParams)
        {
            dm.TraceService("InsSettlementImg STARTED ");
            dm.TraceService("==============================");
            try
            {
                string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                string usrID = inputParams.usrID == null ? "0" : inputParams.usrID;
                string Remarks = inputParams.Remarks == null ? "0" : inputParams.Remarks;
                dm.TraceService("Value for udpID" + udpID.ToString());
                dm.TraceService("Value for Remarks" + Remarks.ToString());

                try
                {
                    string jsonArray = inputParams.XMLPettyCashDesc;
                    string PettyCashXml = "";
                    if (jsonArray != "[]")
                    {
                        List<PettyCash> PettyAmount = JsonConvert.DeserializeObject<List<PettyCash>>(inputParams.XMLPettyCashDesc);


                        using (var sw = new StringWriter())
                        {
                            using (var writer = XmlWriter.Create(sw))
                            {

                                writer.WriteStartDocument(true);
                                writer.WriteStartElement("r");
                                int c = 0;

                                foreach (PettyCash id in PettyAmount)
                                {
                                    string[] arr = { id.Desc.ToString(), id.Amount.ToString()};
                                    string[] arrName = { "Desc", "Amount" };
                                    dm.createNode(arr, arrName, writer);

                                }







                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                                writer.Close();
                            }
                            PettyCashXml = sw.ToString();
                        }
                    }



                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");
                       
                        var physicalPath = Server.MapPath("../../UploadFiles/SettlementReq");
                        dm.TraceService("Physical Path Generated" + physicalPath.ToString());
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                            dm.TraceService("Directory Created");
                        }
                        string image = "";
                        var imagePath = physicalPath + "/" ;
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
                            if (y == 0 && fileSize>0)
                            {
                                ReceiptImages = "../UploadFiles/SettlementReq/" + REcimage;

                            }
                            else if(y !=0 && fileSize > 0)
                            {
                                ReceiptImages += "," + "../UploadFiles/SettlementReq/" +   REcimage;
                            }
                            else if (fileSize==0)
                            {
                                ReceiptImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = { usrID,rotID, ReceiptImages.ToString(), Remarks,PettyCashXml.ToString()  };
                        DataTable dtDN = dm.loadList("InsSettlementImg", "sp_SFA_App", udpID, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<InsSettlementRequestOut> listDn = new List<InsSettlementRequestOut>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new InsSettlementRequestOut
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

            dm.TraceService("InsSettlementImg ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

        public string GetCustomerRouteWiseAR([FromForm] CusRouteARIn inputParams)
        {
            dm.TraceService("GetCustomerRouteWiseAR STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string[] arr = { cus_ID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelCusRouteWiseAR", "sp_SFA_App", rot_ID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<GetCusRotAR> listHeader = new List<GetCusRotAR>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new GetCusRotAR
                        {
                            inv_ID = dr["inv_ID"].ToString(),
                            inv_InvoiceID = dr["inv_InvoiceID"].ToString(),
                            Date = dr["Date"].ToString(),
                            inv_GrandTotal = dr["inv_GrandTotal"].ToString(),
                            InvBal = dr["InvBal"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            ard_PDC_Amount = dr["ard_PDC_Amount"].ToString(),
                            DateSortColumn = dr["DateSortColumn"].ToString()
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

            dm.TraceService("GetCustomerRouteWiseAR ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetDeliveryHeader([FromForm] GetDeliveryInpara inputParams)
        {
            dm.TraceService("GetDeliveryHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
                string userID = inputParams.userID == null ? "0" : inputParams.userID;

                string[] arr = { userID.ToString() };

                DataTable dtTrnsIn = dm.loadList("SelDeliveryHeaderForKPI", "sp_SFA_App", rot_ID.ToString(), arr);

                if (dtTrnsIn.Rows.Count > 0)
                {
                    List<GetDeliveryOutpara> listItems = new List<GetDeliveryOutpara>();
                    foreach (DataRow dr in dtTrnsIn.Rows)
                    {

                        listItems.Add(new GetDeliveryOutpara
                        {

                            inv_ID = dr["inv_ID"].ToString(),
                            inv_InvoiceID = dr["inv_InvoiceID"].ToString(),

                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
                            CustomerID = dr["cus_ID"].ToString(),
                            CustomerCode = dr["cus_Code"].ToString(),
                            CustomerName = dr["cus_Name"].ToString(),
                            CusHeaderID = dr["csh_ID"].ToString(),
                            CusHeaderCode = dr["csh_Code"].ToString(),
                            CusHeaderName = dr["csh_Name"].ToString(),
                            Type = dr["Type"].ToString(),
                            PayType = dr["inv_PayType"].ToString(),
                            PayMode = dr["inv_PayMode"].ToString(),

                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(" GetDeliveryHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetDeliveryHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }



        public string InvoiceStampedCopyBackend([FromForm] PostINVStampedBackndIn inputParams)
        {
            dm.TraceService("PostStampedCopyBackend STARTED ");
            dm.TraceService("==============================");
            try
            {
                string INV_ID = inputParams.INV_ID == null ? "0" : inputParams.INV_ID;
                //string INV_ID = HttpContext.Request.Form["INV_ID"];
               // dm.TraceService("Value for INV_ID -" + INV_ID.ToString());

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] PDFFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("pdf Received in Httpreq -" + PDFFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../TransactionalDocuments/Stamped/PDF");
                        dm.TraceService("Physical Path Generated -" + physicalPath.ToString());
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                            dm.TraceService("Directory Created");
                        }
                        string pdf = "";
                        var pdfPath = physicalPath;

                        string pdfFile = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started -" + y.ToString());
                            PDFFiles[y] = HttpReq.Files[y];
                            string pdfattch = PDFFiles[y].FileName;
                            pdf = pdfPath + "/" + PDFFiles[y].FileName;
                            PDFFiles[y].SaveAs(pdf);
                            pdfFile = "../../TransactionalDocuments/Stamped/PDF/" + pdfattch;

                            dm.TraceService("pdfFile -" + PDFFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended -" + y.ToString());
                        }

                        string[] ar = { pdfFile.ToString() };
                        DataTable dtDN = dm.loadList("UpdateStampedCopy", "sp_Transaction", INV_ID.ToString(), ar);

                        if (dtDN.Rows.Count > 0)
                        {
                            List<GetINVInsertStatus> listDn = new List<GetINVInsertStatus>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new GetINVInsertStatus
                                {
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    Descr = dr["Descr"].ToString()


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

            dm.TraceService("PostStampedCopyBackend ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }


        public string InsSettlementPettyCashImg([FromForm] InsSettlementPettyCashIn inputParams)
        {
            dm.TraceService("InsSettlementPettyCash STARTED ");
            dm.TraceService("==============================");
            try
            {
                string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                string Desc = inputParams.Desc == null ? "0" : inputParams.Desc;
               
                string PettyCash = inputParams.PettyCash == null ? "0" : inputParams.PettyCash;
                dm.TraceService("Value for udpID" + udpID.ToString());
                dm.TraceService("Value for PettyCash" + PettyCash.ToString());
                dm.TraceService("Value for Desc" + Desc.ToString());

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/SettlementPetty");
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
                                ReceiptImages = "../UploadFiles/SettlementPetty/" + REcimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                ReceiptImages += "," + "../UploadFiles/SettlementPetty/" + REcimage;
                            }
                            else if (fileSize == 0)
                            {
                                ReceiptImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = {  Desc, ReceiptImages.ToString(), PettyCash };
                        DataTable dtDN = dm.loadList("InsSettlementPettyCash", "sp_Settlement", udpID, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<InsSettlementPettyCashOut> listDn = new List<InsSettlementPettyCashOut>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new InsSettlementPettyCashOut
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

            dm.TraceService("InsSettlementPettyCash ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

    }
}