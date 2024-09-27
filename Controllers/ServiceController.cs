using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Configuration;
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


namespace MVC_API.Controllers
{
    public class ServiceController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]

        public string GetServiceRequests([FromForm] ServiceRequestIn inputParams)
        {
            dm.TraceService("GetServiceRequests STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelServiceRequests", "sp_SFA_App", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceRequestOut> listHeader = new List<ServiceRequestOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new ServiceRequestOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetRefName = dr["asc_Name"].ToString(),
                            SerialNo = dr["asc_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            AssetMandColumns = dr["asc_MandColumns"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,



                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            AssignedRotID = dr["rot_ID"].ToString(),
                            AssignedRotCode = dr["rot_Code"].ToString(),
                            AssignedRotName = dr["rot_Name"].ToString(),
                            AssignedDate = "",
                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            AssetCode = dr["atm_Code"].ToString(),

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
                dm.TraceService("GetServiceRequests  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceRequests ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetComplaintType([FromForm] ComplaintTypeIn inputParams)
        {
            dm.TraceService("GetComplaintType STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            DataTable dt = dm.loadList("SelServiceComplaintType", "sp_SFA_App", UserId.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ComplaintTypeOut> listHeader = new List<ComplaintTypeOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ComplaintTypeOut
                        {

                            CTypeID = dr["cst_ID"].ToString(),
                            CTypeCode = dr["cst_Code"].ToString(),
                            CTypeName = dr["cst_Name"].ToString()


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
                dm.TraceService("GetComplaintType  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetComplaintType ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetServiceTroubleShoots([FromForm] TroubleShootIn inputParams)
        {
            dm.TraceService("GetServiceTroubleShoots STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            DataTable dt = dm.loadList("SelServiceTroubleShoots", "sp_SFA_App", UserId.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<TroubleShootOut> listHeader = new List<TroubleShootOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new TroubleShootOut
                        {

                            TroubleShootID = dr["sts_ID"].ToString(),
                            TroubleShootName = dr["sts_Name"].ToString(),



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
                dm.TraceService("GetServiceTroubleShoots  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceTroubleShoots ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string InsServiceRequest([FromForm] InsServiceRqstIn inputParams)
        {

            dm.TraceService("InsServiceRequest STARTED ");
            dm.TraceService("==============================");
            try
            {
                string AssetID = inputParams.AssetID == null ? "0" : inputParams.AssetID;
                string ComplaintID = inputParams.ComplaintID == null ? "0" : inputParams.ComplaintID;
                string Remarks = inputParams.Remarks == null ? "" : inputParams.Remarks;
                string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
                string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                string cseID = inputParams.cseID == null ? "0" : inputParams.cseID;
                string RequestCode = inputParams.RequestCode == null ? "0" : inputParams.RequestCode;
                string ComplaintTitle = inputParams.ComplaintTitle == null ? "" : inputParams.ComplaintTitle;
                string AssetMasterID = inputParams.AssetMasterID == null ? "0" : inputParams.AssetMasterID;

                dm.TraceService("InsServiceRequest-inparas= " + AssetID + "," + ComplaintID + "," + Remarks + "," + cusID + "," + udpID + "," + cseID + "," + RequestCode + "," + ComplaintTitle);




                try
                {


                    string[] ar = { ComplaintID, Remarks, cusID, udpID, cseID, RequestCode, ComplaintTitle ,AssetMasterID};
                    DataTable dtDN = dm.loadList("InsServiceRequest", "sp_SFA_App", AssetID, ar);

                    if (dtDN.Rows.Count > 0)
                    {
                        List<InsServiceRqstOut> listDn = new List<InsServiceRqstOut>();
                        foreach (DataRow dr in dtDN.Rows)
                        {
                            listDn.Add(new InsServiceRqstOut
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

            dm.TraceService("InsServiceRequest ENDED ");
            dm.TraceService("==========================");

            return JSONString;

        }

        public string GetServiceJobs([FromForm] ServiceJobIn inputParams)
        {
            dm.TraceService("GetServiceJobs STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelServiceJob", "sp_SFA_App", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceJobOut> listHeader = new List<ServiceJobOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

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


                        listHeader.Add(new ServiceJobOut
                        {
                            ReqID = dr["snr_ID"].ToString(),
                            AssetID = dr["asc_ID"].ToString(),
                            AssetName = dr["asc_Name"].ToString(),
                            AssetCode = dr["ast_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            ComplaintTypeID = dr["cst_ID"].ToString(),

                            RequestID = dr["snr_Code"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,
                            Remarks = dr["snr_Remarks"].ToString(),
                            ComplaintTitle = dr["snr_Complaint"].ToString(),
                            jobID = dr["sjh_ID"].ToString(),
                            jobNumber = dr["sjh_Number"].ToString(),
                            SerialNo = dr["atm_Code"].ToString(),
                            ScheduledDate = dr["sjh_ScheduledDate"].ToString(),
                            EstimateStartTime= dr["sjh_ScheduledStartTime"].ToString(),
                            EstimateEndTime= dr["sjh_EstimatedEndTime"].ToString(),
                            ActualStartTime= dr["sjh_ActualStartTime"].ToString(),
                            ActualEndTime= dr["sjh_ActualEndTime"].ToString(),
                            ExpectedDuration = dr["sjh_Duration"].ToString(),
                            ActualDuration = dr["sjh_ActualDuration"].ToString(),
                            BackendInstruction= dr["sjh_RemarksFromBacknd"].ToString(),




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
                dm.TraceService("GetServiceJobs  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceJobs ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetServiceQuestions([FromForm] ServiceQuestionsIn inputParams)
        {
            dm.TraceService("GetServiceQuestions STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelServiceAssetQuestions", "sp_SFA_App", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceQuestionsOut> listHeader = new List<ServiceQuestionsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {



                        listHeader.Add(new ServiceQuestionsOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetName = dr["asc_Name"].ToString(),

                            cus_ID = dr["cus_ID"].ToString(),
                            QID = dr["sqm_ID"].ToString(),
                            Question = dr["sqm_Questions"].ToString(),
                            Comments = dr["sqm_IsCommentsNeeded"].ToString(),
                            QOrder = dr["asq_Order"].ToString(),
                            QType = dr["qst_Type"].ToString(),
                            IsMandatory = dr["asq_IsMandatory"].ToString(),
                            Answer = dr["sqd_Answer"].ToString(),
                            AOrder = dr["sqd_Order"].ToString(),
                            IsAnswer = dr["qst_IsAnswer"].ToString(),
                            AID = dr["ans_ID"].ToString(),



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
                dm.TraceService("GetServiceQuestions  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceQuestions ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string GetAssetType([FromForm] AssetTypeIn inputParams)
        {
            dm.TraceService("GetAssetType STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            DataTable dt = dm.loadList("SelAssetTypes", "sp_SFA_App", UserId.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<AssetTypeOut> listHeader = new List<AssetTypeOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new AssetTypeOut
                        {

                            AssetTypeID = dr["ast_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            AssetTypeName = dr["ast_Name"].ToString(),
                            cusID = dr["cus_ID"].ToString(),
                            cusCode = dr["cus_Code"].ToString(),
                            cusName = dr["cus_Name"].ToString()


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
                dm.TraceService("GetAssetType  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAssetType ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string InsServiceForApproval([FromForm] ServiceApprovalIn inputParams)
        {
            dm.TraceService("InsServiceForApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<ServiceApprovalDetail> itemData = JsonConvert.DeserializeObject<List<ServiceApprovalDetail>>(inputParams.ApprovalDetail);
                try
                {
                    string usrID = inputParams.usrID == null ? "0" : inputParams.usrID;
                    string udpID = inputParams.udpID == null ? "PA" : inputParams.udpID;
                    string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string Date = inputParams.Date == null ? "0" : inputParams.Date;
                    string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
                    string jobID = inputParams.JobID == null ? "0" : inputParams.JobID;

                    string Total = inputParams.Total == null ? "0" : inputParams.Total;
                    string Discount = inputParams.Discount == null ? "0" : inputParams.Discount;
                    string SubTotal = inputParams.SubTotal == null ? "0" : inputParams.SubTotal;
                    string VAT = inputParams.VAT == null ? "0" : inputParams.VAT;
                    string GrandTotal = inputParams.GrandTotal == null ? "0" : inputParams.GrandTotal;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (ServiceApprovalDetail id in itemData)
                            {
                                string[] arr = { id.prdID.ToString(), id.UOM.ToString(), id.Qty.ToString(), id.Price.ToString(), id.Discount.ToString(), id.LineTotal.ToString() };
                                string[] arrName = { "prdID", "UOM", "Qty", "Price", "Discount", "LineTotal" };
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
                        string[] arr = { udpID.ToString(), rotID.ToString(), ReqID.ToString(), InputXml.ToString(),Date.ToString(),cusID.ToString(), jobID ,Total.ToString(),Discount.ToString(),SubTotal.ToString(),
                        VAT.ToString(),GrandTotal.ToString()};
                        DataTable dt = dm.loadList("InsServiceRequestForApproval", "sp_ServiceRequest", usrID.ToString(), arr);

                        if (dt.Rows.Count > 0)
                        {
                            List<ServiceApprovalOut> listDn = new List<ServiceApprovalOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listDn.Add(new ServiceApprovalOut
                                {
                                    Res = dr["Res"].ToString(),
                                    status = dr["Title"].ToString(),



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
            dm.TraceService("InsServiceForApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetServiceApprovalStatus([FromForm] ServiceApprovalStatusIn inputParams)
        {
            dm.TraceService("GetServiceApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string RequestID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string userID = inputParams.usrID == null ? "0" : inputParams.usrID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
            string jobID = inputParams.JobID == null ? "0" : inputParams.JobID;

            string[] arr = { userID.ToString(), udpID, cusID, jobID };
            DataTable dt = dm.loadList("SelStatusForServiceApprovalHeader", "sp_ServiceRequest", RequestID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<ServiceApprovalStatusOut> listHeader = new List<ServiceApprovalStatusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ServiceApprovalStatusOut
                        {
                            ApprovalStatus = dr["sah_ApprovalStatus"].ToString()

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
                dm.TraceService("GetServiceApprovalStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string PostServiceRequestImage([FromForm] ServiceRequestImgIn inputParams)
        {
            dm.TraceService("PostServiceRequestImage STARTED ");
            dm.TraceService("==============================");
            try
            {


                string ReqCode = inputParams.ReqCode == null ? "0" : inputParams.ReqCode;
                string attachType = inputParams.ImageType == null ? "0" : inputParams.ImageType;

                dm.TraceService("Value for Transaction" + ReqCode.ToString());

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
                        var physicalPath = Server.MapPath("../../UploadFiles/" + attachType);
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
                            string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            if (y == 0)
                            {
                                ReceiptImages = "../UploadFiles/" + attachType + "/" + REcimage.ToString();

                            }
                            else
                            {
                                ReceiptImages += "," + "../UploadFiles/" + attachType + "/" + REcimage.ToString();
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }
                        try
                        {


                            string[] ar = { ReceiptImages, attachType };
                            dm.TraceService("ReceiptImages values" + ReceiptImages.ToString());

                            DataTable dtDN = dm.loadList("InsServiceRequestImg", "sp_SFA_App", ReqCode, ar);

                            if (dtDN.Rows.Count > 0)
                            {
                                List<InsServiceRqstOut> listDn = new List<InsServiceRqstOut>();
                                foreach (DataRow dr in dtDN.Rows)
                                {
                                    listDn.Add(new InsServiceRqstOut
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
                            JSONString = "PostServiceRequestImage-NoDataSQL - " + ex.Message.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "PostServiceRequestImage-NoDataSQL - " + ex.Message.ToString();
                    }


                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "PostServiceRequestImage-NoDataSQL - " + ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "PostServiceRequestImage -NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PostServiceRequestImage ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }
        public string PostServiceJobImage([FromForm] ServiceJobImageIn inputParams)
        {
            dm.TraceService("PostServiceJobImage STARTED ");
            dm.TraceService("==============================");
            try
            {


                string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                string JobID = inputParams.JobID == null ? "0" : inputParams.JobID;
                string attachType = inputParams.ImageType == null ? "0" : inputParams.ImageType;

                dm.TraceService("Value for Transaction" + JobID.ToString());

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
                        var physicalPath = Server.MapPath("../../UploadFiles/" + attachType);
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
                            string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            if (y == 0)
                            {
                                ReceiptImages = "../UploadFiles/" + attachType + "/" + REcimage.ToString();

                            }
                            else
                            {
                                ReceiptImages += "," + "../UploadFiles/" + attachType + "/" + REcimage.ToString();
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }
                        try
                        {


                            string[] ar = { ReceiptImages, attachType, udpID };
                            dm.TraceService("ReceiptImages values" + ReceiptImages.ToString());

                            DataTable dtDN = dm.loadList("InsServiceJobImg", "sp_SFA_App", JobID, ar);

                            if (dtDN.Rows.Count > 0)
                            {
                                List<InsServiceRqstOut> listDn = new List<InsServiceRqstOut>();
                                foreach (DataRow dr in dtDN.Rows)
                                {
                                    listDn.Add(new InsServiceRqstOut
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
                            JSONString = "PostServiceJobImage-NoDataSQL - " + ex.Message.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "PostServiceJobImage-NoDataSQL - " + ex.Message.ToString();
                    }


                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "PostServiceJobImage-NoDataSQL - " + ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "PostServiceJobImage -NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("PostServiceJobImage ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

        public string InsServiceReqstActionTaken([FromForm] ServiceJobATin inputParams)
        {
            dm.TraceService("InsServiceReqstActionTaken STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<ServiceJobJson> itemData = JsonConvert.DeserializeObject<List<ServiceJobJson>>(inputParams.JsonValue);
                try
                {
                    string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
                    string userID = inputParams.userID == null ? "0" : inputParams.userID;
                    string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
                    string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;
                    string Date = inputParams.CreatedDate == null ? "" : inputParams.CreatedDate;
                    string reqID = inputParams.reqID == null ? "0" : inputParams.reqID;
                    string Status = inputParams.Status == null ? "0" : inputParams.Status;
                    string Remarks = inputParams.Remarks == null ? "0" : inputParams.Remarks;
                    string jobID = inputParams.jobID == null ? "0" : inputParams.jobID;
                    string ActionType = inputParams.ActionType == null ? "0" : inputParams.ActionType;
                    string ActualStartTime = inputParams.ActualStartTime == null ? "0" : inputParams.ActualStartTime;
                    string ActualEndTime = inputParams.ActualEndTime == null ? "0" : inputParams.ActualEndTime;

                    dm.TraceService("InsServiceReqstActionTaken actual s & E Time: " + ActualStartTime.ToString()+","+ ActualEndTime.ToString());
                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (ServiceJobJson id in itemData)
                            {
                                string[] arr = { id.question.ToString(), id.answer.ToString(), id.remarks.ToString(), id.type.ToString() };
                                string[] arrName = { "question", "answer", "remarks", "type" };
                                dm.createNode(arr, arrName, writer);
                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        InputXml = sw.ToString();
                    }

                    string requiredpartXml = "";
                    string RequiredParts = inputParams.RequiredParts == null ? "0" : inputParams.RequiredParts;
                    if (RequiredParts == "[]")
                    {
                        requiredpartXml = "";
                    }
                    else
                    {

                        List<RequiredPartsJson> partsData = JsonConvert.DeserializeObject<List<RequiredPartsJson>>(inputParams.RequiredParts);
                        using (var sw = new StringWriter())
                        {
                            using (var writer = XmlWriter.Create(sw))
                            {

                                writer.WriteStartDocument(true);
                                writer.WriteStartElement("r");
                                int c = 0;
                                foreach (RequiredPartsJson id in partsData)
                                {
                                    string[] arr = { id.prdID.ToString(), id.UOM.ToString(), id.Qty.ToString() };
                                    string[] arrName = { "prdID", "UOM", "Qty" };
                                    dm.createNode(arr, arrName, writer);
                                }

                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                                writer.Close();
                            }
                            requiredpartXml = sw.ToString();
                        }
                    }

                    var HttpReq = HttpContext.Request;
                    try
                    {

                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");
                        string newServerBasePath = ConfigurationManager.AppSettings["NewServerBasePath"];
                        var physicalPath = Path.Combine(newServerBasePath, "UploadFiles/FieldServiceSign"); //Server.MapPath("../../UploadFiles/FieldServiceSign");
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
                        string SignImages = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started" + y.ToString());
                            imageFiles[y] = HttpReq.Files[y];
                            string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            dm.TraceService("Byte array size of image file " + y.ToString() + ": " + imageFiles[y].InputStream.Length.ToString() + " bytes");
                            if (y == 0)
                            {
                                SignImages = "../UploadFiles/FieldServiceSign/" + REcimage.ToString();

                            }
                            else
                            {
                                SignImages += "," + "../UploadFiles/FieldServiceSign/" + REcimage.ToString();
                            }

                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }


                        try
                        {
                            string[] arr = { userID.ToString(), udpID.ToString(), reqID.ToString(), cse_ID.ToString(), Date.ToString() , InputXml.ToString(),Status.ToString(),jobID.ToString(),
                        Remarks.ToString(),requiredpartXml.ToString(),ActionType.ToString(),ActualStartTime.ToString(),ActualEndTime.ToString(),SignImages.ToString()};
                            DataTable dt = dm.loadList("InsServiceJobActionTaken", "sp_ServiceRequest", cusID.ToString(), arr);

                            List<ServiceJobATOut> listStatus = new List<ServiceJobATOut>();
                            if (dt.Rows.Count > 0)
                            {
                                List<ServiceJobATOut> listDn = new List<ServiceJobATOut>();
                                foreach (DataRow dr in dt.Rows)
                                {
                                    listDn.Add(new ServiceJobATOut
                                    {
                                        Res = dr["Res"].ToString(),
                                        Title = dr["Title"].ToString(),
                                        Descr = dr["Descr"].ToString(),



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
                        JSONString = "InsServiceReqstActionTaken-NoDataSQL - " + ex.Message.ToString();
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
            dm.TraceService("InsServiceReqstActionTaken ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetServiceFields([FromForm] ServiceFieldsIn inputParams)
        {
            dm.TraceService("GetServiceFields STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ServiceReqID = inputParams.ServiceReqID == null ? "0" : inputParams.ServiceReqID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceFields", "sp_ServiceRequest", ServiceReqID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<ServiceFieldsOut> listHeader = new List<ServiceFieldsOut>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<ServiceJobHeader> listDetail = new List<ServiceJobHeader>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {




                            listDetail.Add(new ServiceJobHeader
                            {
                                JobID = drDetails["sjh_ID"].ToString(),
                                JobNumber = drDetails["sjh_Number"].ToString(),
                                Asset = drDetails["ast_Name"].ToString(),
                                Date = drDetails["CreatedDate"].ToString(),
                                JobStatus = drDetails["JobStatus"].ToString(),
                                ActualStartTime = drDetails["sjh_ActualStartTime"].ToString(),
                                ActualEndtime = drDetails["sjh_ActualEndTime"].ToString(),
                                ScheduledDate = drDetails["sjh_ScheduledDate"].ToString(),
                                Duration = drDetails["sjh_Duration"].ToString(),
                                EstimateStartTime = drDetails["sjh_ScheduledStartTime"].ToString(),
                                EstimateEndTime = drDetails["sjh_EstimatedEndTime"].ToString(),
                                ActualDuration = drDetails["sjh_ActualDuration"].ToString(),
                                SerialNum = drDetails["atm_Code"].ToString(),
                                cusCode = drDetails["cus_Code"].ToString(),
                                cusName = drDetails["cus_Name"].ToString(),
                                BackndRemark = drDetails["sjh_RemarksFromBacknd"].ToString()


                            });

                        }

                        listHeader.Add(new ServiceFieldsOut
                        {

                            Asset = dr["ast_Name"].ToString(),
                            Date = dr["Date"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            ServiceReqRemarks = dr["snr_Remarks"].ToString(),
                            ServiceReqImages = dr["snr_Image"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            Status = dr["Status"].ToString(),

                            JobHeader = listDetail,
                            RespondedDate = dr["ModifiedDate"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            
                            ReqstCode= dr["snr_Code"].ToString()
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
                JSONString = "GetServiceFields - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceFields ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceRequestsDetail([FromForm] ServiceReqstDetailIN inputParams)
        {
            dm.TraceService("GetServiceRequestsDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status = inputParams.Status == null ? "0" : inputParams.Status;
            string reqCode = inputParams.ReqCode == null ? "0" : inputParams.ReqCode;
            string[] ar = { reqCode };
            DataTable dt = dm.loadList("SelServiceRequestsDetail", "sp_ServiceRequest", Status.ToString(), ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceReqstDetailOUT> listHeader = new List<ServiceReqstDetailOUT>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new ServiceReqstDetailOUT
                        {
                            RespondedDate = dr["RespondedDate"].ToString(),
                            snr_TroubleShoots = dr["snr_TroubleShoots"].ToString(),
                            AssignedToDate = dr["AssignedToDate"].ToString(),
                            AssignedRotCode = dr["AssignedRotCode"].ToString(),
                            AssignedRotName = dr["AssignedRotName"].ToString(),
                            AssignedDate = dr["AssignedDate"].ToString(),



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
                dm.TraceService("GetServiceRequestsDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceRequestsDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetServiceReqDetailForActionTaken([FromForm] ServiceReqDetailIN inputParams)
        {
            dm.TraceService("GetServiceRequestsDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string reqCode = inputParams.ReqCode == null ? "0" : inputParams.ReqCode;
            string Status = inputParams.Status == null ? "0" : inputParams.Status;

            string[] ar = { Status };
            DataTable dt = dm.loadList("SelServiceRequestsDetail", "sp_ServiceRequest", reqCode.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceReqDetailOUT> listHeader = new List<ServiceReqDetailOUT>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new ServiceReqDetailOUT
                        {
                            RespondedDate = dr["RespondedDate"].ToString(),
                            snr_TroubleShoots = dr["snr_TroubleShoots"].ToString(),
                            AssignedToDate = dr["AssignedToDate"].ToString(),
                            AssignedRotCode = dr["AssignedRotCode"].ToString(),
                            AssignedRotName = dr["AssignedRotName"].ToString(),
                            AssignedDate = dr["AssignedDate"].ToString(),
                            ActionTakeDate = dr["ActionTakeDate"].ToString(),
                            sjd_Question = dr["sjd_Question"].ToString(),
                            sjd_Answer = dr["sjd_Answer"].ToString(),
                            sdj_Type = dr["sdj_Type"].ToString(),
                            sjd_Remarks = dr["sjd_Remarks"].ToString(),
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
                dm.TraceService("GetServiceRequestsDetail  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceRequestsDetail ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceRequestsResolved([FromForm] ServiceReqResovedIn inputParams)
        {
            dm.TraceService("GetServiceRequests STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string AssetID = inputParams.AssetID == null ? "0" : inputParams.AssetID;
            string AssetSerialNum = inputParams.AssetSerialNum == null ? "0" : inputParams.AssetSerialNum;
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
            string CusID = inputParams.cusID == null ? "0" : inputParams.cusID;


            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string Asset = "";
            string AssetSlNum = "";
            if (inputParams.AssetID != null)
            {
                Asset = " and ast_ID  = " + AssetID;
            }
            if (inputParams.AssetSerialNum != null)
            {
                AssetSlNum = " and atm_Code  =  '" + AssetSerialNum +"'";
            }
            string[] arr = { Asset, AssetSerialNum , FromDate, ToDate ,CusID};
            DataTable dt = dm.loadList("SelServiceReqResolved", "sp_ServiceRequest", rotID.ToString(), arr);
            
            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ServiceReqResovedOut> listHeader = new List<ServiceReqResovedOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["snr_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["snr_Image"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                imag = url + ar[i];
                            }

                        }

                        listHeader.Add(new ServiceReqResovedOut
                        {
                            AssetID = dr["asc_ID"].ToString(),
                            AssetName = dr["asc_Name"].ToString(),
                            AssetCode = dr["asc_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            AssetMandColumns = dr["asc_MandColumns"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Images = imag,

                            Remarks = dr["snr_Remarks"].ToString(),
                            RespondedOn = dr["ModifiedDate"].ToString(),
                            RequestCode = dr["snr_Code"].ToString(),
                            AssetType = dr["ast_Name"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            AssignedRotID = dr["rot_ID"].ToString(),
                            AssignedRotCode = dr["rot_Code"].ToString(),
                            AssignedRotName = dr["rot_Name"].ToString(),
                            AssignedDate = dr["snr_ScheduledDate"].ToString(),
                            AssetTypeID = dr["ast_ID"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            ComplaintID = dr["snr_cst_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            RequestID = dr["snr_ID"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            ResolvedDate= dr["ResolvedDate"].ToString(),
                            ResolvedTime = dr["ResolvedTime"].ToString(),
                            cus_Code= dr["cus_Code"].ToString(),
                            cus_Name= dr["cus_Name"].ToString()

                        });;
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
                dm.TraceService("GetServiceRequests  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceRequests ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetAssetTypeForResolved([FromForm] ResolvedAsssetIn inputParams)
        {
            dm.TraceService("GetAssetTypeForResolved STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;


            DataTable dt = dm.loadList("SelAssetTypeForResolved", "sp_ServiceRequest", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ResolvedAsssetOut> listHeader = new List<ResolvedAsssetOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ResolvedAsssetOut
                        {

                            AssetTypeID = dr["ast_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            AssetTypeName = dr["ast_Name"].ToString()
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
                dm.TraceService("GetAssetTypeForResolved  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAssetTypeForResolved ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetAssetSerialNumForResolved([FromForm] ResolvedAsssetSerialIn inputParams)
        {
            dm.TraceService("GetAssetSerialNumForResolved STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            string AssetTypeID = inputParams.AssetTypeID == null ? "0" : inputParams.AssetTypeID;

            string[] arr = { AssetTypeID };
            DataTable dt = dm.loadList("SelAssetSerialNumForResolved", "sp_ServiceRequest", rotID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ResolvedAsssetSerialOut> listHeader = new List<ResolvedAsssetSerialOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ResolvedAsssetSerialOut
                        {

                            AssetSerialID = dr["atm_ID"].ToString(),
                            AssetSerialCode = dr["atm_Code"].ToString(),
                            AssetSerialName = dr["atm_Name"].ToString()
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
                dm.TraceService("GetAssetSerialNumForResolved  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAssetSerialNumForResolved ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetRepairParts([FromForm] RepairPartsIn inputParams)
        {
            dm.TraceService("GetServiceRequests STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            DataTable dt = dm.loadList("SelectRepairParts", "sp_ServiceRequest", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<RepairPartsOut> listHeader = new List<RepairPartsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new RepairPartsOut
                        {

                            srp_ID = dr["srp_ID"].ToString(),
                            RequestID = dr["srp_snr_ID"].ToString(),
                            ServiceJobID = dr["srp_sjh_ID"].ToString(),
                            prd_ID = dr["srp_prd_ID"].ToString(),
                            UOM = dr["srp_UOM"].ToString(),
                            Qty = dr["srp_Qty"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_Description = dr["prd_Description"].ToString(),
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
                dm.TraceService("GetServiceRequests  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceRequests ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        
        public string GetServiceJobDetails([FromForm] ServiceJobDetailIN inputParams)
        {
            dm.TraceService("GetServiceJobDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string JobID = inputParams.JobID == null ? "0" : inputParams.JobID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceJobDetails", "sp_ServiceRequest", JobID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<ServiceJobDetailOut> listHeader = new List<ServiceJobDetailOut>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<ServiceJobDetailData> listDetail = new List<ServiceJobDetailData>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {




                            listDetail.Add(new ServiceJobDetailData
                            {
                                Question = drDetails["sjd_Question"].ToString(),
                                Answer = drDetails["sjd_Answer"].ToString(),
                                Type = drDetails["sjd_Type"].ToString(),
                                Remarks = drDetails["sjd_Remarks"].ToString(),

                            });

                        }

                        listHeader.Add(new ServiceJobDetailOut
                        {

                            AssignedRotCode = dr["AssignedRotCode"].ToString(),
                            AssignedRotName = dr["AssignedRotName"].ToString(),
                            AssignedDate = dr["AssignedDate"].ToString(),
                            AssignedToDate = dr["AssignedToDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            sjh_ActionType = dr["sjh_ActionType"].ToString(),

                            JobDetails = listDetail,
                            ActionTakenDate = dr["ModifiedDate"].ToString(),
                            ActualStartTime = dr["sjh_ActualStartTime"].ToString(),
                            ActualEndTime = dr["sjh_ActualEndTime"].ToString(),
                            EstimateStartTime = dr["sjh_ScheduledStartTime"].ToString(),
                            EstimateEndTime = dr["sjh_EstimatedEndTime"].ToString(),
                            Duration = dr["sjh_Duration"].ToString(),
                            ActualDuration = dr["sjh_ActualDuration"].ToString(),

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
                JSONString = "GetServiceJobDetails - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceJobDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetRequiredParts([FromForm] ReqPartsIn inputParams)
        {
            dm.TraceService("GetRequiredParts STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string JobID = inputParams.JobID == null ? "0" : inputParams.JobID;

            DataTable dt = dm.loadList("SelectRequiredParts", "sp_ServiceRequest", JobID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ReqPartsOut> listHeader = new List<ReqPartsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ReqPartsOut
                        {


                            ServiceJobID = dr["srp_sjh_ID"].ToString(),
                            prd_ID = dr["srp_prd_ID"].ToString(),
                            UOM = dr["srp_UOM"].ToString(),
                            Qty = dr["srp_Qty"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            Remarks = dr["sjh_ReqPartsRemarks"].ToString(),
                            CategoryID = dr["cat_ID"].ToString(),
                            BrandID = dr["brd_ID"].ToString(),
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
                dm.TraceService("GetRequiredParts  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetRequiredParts ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceJobInvoice([FromForm] ServiceJobInvoiceIN inputParams)
        {
            dm.TraceService("GetServiceJobInvoice STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string JobID = inputParams.JobID == null ? "0" : inputParams.JobID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceJobInvoiceDetails", "sp_ServiceRequest", JobID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];



            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<ServiceJobInvoiceOUT> listHeader = new List<ServiceJobInvoiceOUT>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<ServiceJobInvoiceItems> listDetail = new List<ServiceJobInvoiceItems>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {

                            if (drDetails["sld_sal_ID"].ToString() == dr["sal_ID"].ToString())
                            {



                                listDetail.Add(new ServiceJobInvoiceItems
                                {
                                    prdID = drDetails["prd_ID"].ToString(),
                                    prdCode = drDetails["prd_Code"].ToString(),
                                    prdName = drDetails["prd_Name"].ToString(),
                                    categoryID = drDetails["cat_ID"].ToString(),
                                    BrandID = drDetails["brd_ID"].ToString(),
                                    IsChargable = drDetails["prd_Chargable"].ToString(),
                                    UOM = drDetails["UOM"].ToString(),
                                    Qty = drDetails["Qty"].ToString(),
                                    Price = drDetails["Price"].ToString(),
                                    LineTotal = drDetails["LineTotal"].ToString(),
                                    Discount = drDetails["Discount"].ToString(),

                                });

                            }
                        }

                        listHeader.Add(new ServiceJobInvoiceOUT
                        {

                            VAT = dr["VAT"].ToString(),
                            GrandTotal = dr["inv_GrandTotal"].ToString(),
                            SubTotal = dr["SubTotal"].ToString(),
                            PayType= dr["inv_PayType"].ToString(),
                            PayMode= dr["inv_PayMode"].ToString(),
                            ItemData = listDetail,
                            Discount= dr["inv_Discount"].ToString(),
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
                JSONString = "GetServiceJobInvoice - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceJobInvoice ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetServiceJobHeader([FromForm] ServiceFieldsIn inputParams)
        {
            dm.TraceService("GetServiceJobHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string ServiceReqID = inputParams.ServiceReqID == null ? "0" : inputParams.ServiceReqID;

            string[] ar = { };
            DataSet dt = dm.loadListDS("SelServiceJobHeader", "sp_ServiceRequest", ServiceReqID.ToString(), ar);

            DataTable HeaderData = dt.Tables[0];
            DataTable DetailData = dt.Tables[1];

            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<ServiceFieldsOut> listHeader = new List<ServiceFieldsOut>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                        List<ServiceJobHeader> listDetail = new List<ServiceJobHeader>();
                        foreach (DataRow drDetails in DetailData.Rows)
                        {




                            listDetail.Add(new ServiceJobHeader
                            {
                                JobID = drDetails["sjh_ID"].ToString(),
                                JobNumber = drDetails["sjh_Number"].ToString(),
                                Asset = drDetails["ast_Name"].ToString(),
                                Date = drDetails["CreatedDate"].ToString(),
                                JobStatus = drDetails["JobStatus"].ToString(),
                                Duration = drDetails["sjh_Duration"].ToString(),
                                EstimateStartTime = drDetails["sjh_ScheduledStartTime"].ToString(),
                                EstimateEndTime = drDetails["sjh_EstimatedEndTime"].ToString(),
                                ActualStartTime = drDetails["sjh_ActualStartTime"].ToString(),
                                ActualEndTime = drDetails["sjh_ActualEndTime"].ToString(),
                                ActualDuration = drDetails["sjh_ActualDuration"].ToString(),
                                SerialNum = drDetails["atm_Code"].ToString(),
                                cusCode= drDetails["cus_Code"].ToString(),
                                cusName= drDetails["cus_Name"].ToString()
                            });

                        }

                        listHeader.Add(new ServiceFieldsOut
                        {

                            Asset = dr["ast_Name"].ToString(),
                            Date = dr["Date"].ToString(),
                            Complaint = dr["snr_Complaint"].ToString(),
                            ServiceReqRemarks = dr["snr_Remarks"].ToString(),
                            ServiceReqImages = dr["snr_Image"].ToString(),
                            TroubleShoots = dr["TroubleShoots"].ToString(),
                            Status = dr["Status"].ToString(),

                            JobHeader = listDetail,
                            RespondedDate = dr["ModifiedDate"].ToString(),
                            SerialNum = dr["atm_Code"].ToString(),
                            ComplaintType = dr["cst_Name"].ToString(),
                            ScheduledDate = dr["snr_scheduleDate"].ToString(),
                            CompletedOn= dr["CompletedOn"].ToString(),
                            ReqstCode= dr["snr_Code"].ToString()
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
                JSONString = "GetServiceJobHeader - " + ex.Message.ToString();
            }

            dm.TraceService("GetServiceJobHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetAllAssetType([FromForm] AssetTypeAllIn inputParams)
        {
            dm.TraceService("GetAllAssetType STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;


            DataTable dt = dm.loadList("SelAllAssetTypes", "sp_SFA_App", UserId.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<AssetTypeAllOut> listHeader = new List<AssetTypeAllOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new AssetTypeAllOut
                        {

                            AssetTypeID = dr["ast_ID"].ToString(),
                            AssetTypeCode = dr["ast_Code"].ToString(),
                            AssetTypeName = dr["ast_Name"].ToString(),


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
                dm.TraceService("GetAllAssetType  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAllAssetType ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetJobInventory([FromForm] JobInventoryIn inputParams)
        {
            dm.TraceService("GetJobInventory STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string sjhID = inputParams.sjhID == null ? "0" : inputParams.sjhID;

            DataTable dt = dm.loadList("SelJobInventory", "sp_ServiceRequest", sjhID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<JobInventoryOut> listHeader = new List<JobInventoryOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new JobInventoryOut
                        {

                            IntID= dr["fji_id"].ToString(),
                            prdID = dr["fji_prd_ID"].ToString(),
                            Date = dr["Date"].ToString(),
                            prdCode = dr["prd_Code"].ToString(),
                            prdName = dr["prd_Name"].ToString(),
                            prdDesc = dr["prd_Description"].ToString(),
                            uom= dr["uom_Name"].ToString(),
                            qty= dr["fji_qty"].ToString(),
                            Status = dr["Status"].ToString(),
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
                dm.TraceService("GetJobInventory  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetJobInventory ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetAccessories([FromForm] JobAccIn inputParams)
        {
            dm.TraceService("GetAccessories STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.sjhID == null ? "0" : inputParams.sjhID;

            DataTable dt = dm.loadList("SelJobAccessory", "sp_ServiceRequest", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<JobAccOut> listHeader = new List<JobAccOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new JobAccOut
                        {

                            JobAccID = dr["fja_ID"].ToString(),
                            AccID = dr["fja_fsa_ID"].ToString(),
                            AccName = dr["fsa_Name"].ToString(),
                            AccCode = dr["fsa_Code"].ToString(),
                            Status = dr["Status"].ToString(),
                            Date = dr["Date"].ToString(),
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
                dm.TraceService("GetAccessories  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetAccessories ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    }
}