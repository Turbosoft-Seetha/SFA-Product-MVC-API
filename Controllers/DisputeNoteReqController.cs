using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
namespace MVC_API.Controllers

{
    public class DisputeNoteReqController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]

        public string PostDisputeNoteRequest([FromForm] DisputeNoteReqIn inputParams)
        {
            dm.TraceService("PostScheduledReturnRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                
                    
                    try
                    {
                        string Amount = inputParams.Amount == null ? "0" : inputParams.Amount;
                        string udpID = inputParams.udpID == null ? "PA" : inputParams.udpID;
                        string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                        string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
                        string type = inputParams.type == null ? "" : inputParams.type;
                        string date = inputParams.date == null ? "" : inputParams.date;
                        string Remark = inputParams.Remark == null ? "" : inputParams.Remark;
                        string OtherInfo = inputParams.OtherInfo == null ? "0" : inputParams.OtherInfo;
                        string cseID = inputParams.cseID == null ? "0" : inputParams.cseID;

                    string UserID = inputParams.usrID == null ? "" : inputParams.usrID;
                    string InputXml = "";
                    if (inputParams.JSONString != null)
                    {

                        List<InvoiceIDs> itemData = JsonConvert.DeserializeObject<List<InvoiceIDs>>(inputParams.JSONString);
                        using (var sw = new StringWriter())
                        {
                            using (var writer = XmlWriter.Create(sw))
                            {

                                writer.WriteStartDocument(true);
                                writer.WriteStartElement("r");
                                int c = 0;
                                foreach (InvoiceIDs id in itemData)
                                {
                                    string[] arr = { id.oidID.ToString(), id.Balance.ToString() };
                                    string[] arrName = { "oid_ID", "balance" };
                                    dm.createNode(arr, arrName, writer);
                                }

                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                                writer.Close();
                            }
                            InputXml = sw.ToString();
                        }
                    }
                        try
                        {
                            string[] arr = { cusID.ToString(), udpID.ToString(),  UserID.ToString(), Remark.ToString(), OtherInfo.ToString(),
                            Amount.ToString(),type.ToString(),date.ToString(), cseID.ToString(), InputXml.ToString() };

                            DataTable dtDN = dm.loadList("InsDisputeNoteRequest", "sp_DisputeNoteRequest", rotID, arr);
                            if (dtDN.Rows.Count > 0)
                            {
                                List<DisputeNoteReqOut> listDn = new List<DisputeNoteReqOut>();
                                foreach (DataRow dr in dtDN.Rows)
                                {
                                    listDn.Add(new DisputeNoteReqOut
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


        public string GetOutstandingInvoices([FromForm] OutstandingINvIn inputParams)
        {
            dm.TraceService("GetOutstandingInvoices STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string[] arr = { userID.ToString() };
            DataTable dtreturn = dm.loadList("SelOutstandingInvoiceData", "sp_DisputeNoteRequest", rotID.ToString(), arr);



            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<OutstandingINvOut> listHeader = new List<OutstandingINvOut>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {
                        listHeader.Add(new OutstandingINvOut
                        {
                          

                            oid_ID= dr["oid_ID"].ToString(),
                            InvoiceAmount= dr["InvoiceAmount"].ToString(),
                            InvoiceBalance= dr["InvoiceBalance"].ToString(),

                            InvoiceNumber = dr["InvoiceID"].ToString(),
                           
                            InvoicedDate = dr["InvoicedOn"].ToString(),


                            cus_ID = dr["oid_cus_ID"].ToString(),
                           
                            inv_ID = dr["oid_inv_ID"].ToString(),
                           

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
                JSONString = "GetOutstandingInvoices - " + ex.Message.ToString();
            }
            dm.TraceService("GetOutstandingInvoices ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetDisputeReqHeaderData([FromForm] PendingDisputeReqIn inputParams)
        {
            dm.TraceService("GetDisputeReqHeaderData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string[] arr = { userID.ToString() };
            DataTable dtreturn = dm.loadList("SelPendingDisputeReqHeaderData", "sp_DisputeNoteRequest", rotID.ToString(), arr);
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<PendingDisputeReqOut> listHeader = new List<PendingDisputeReqOut>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {
                        string imag = "";
                        string img = dr["drh_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["drh_Image"].ToString().Replace("../", "")).Split(',');

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
                        listHeader.Add(new PendingDisputeReqOut
                        {

                            RequestID = dr["drh_ID"].ToString(),
                            RequestNumber = dr["drh_TransID"].ToString(),
                            rot_ID = dr["drh_rot_ID"].ToString(),
                            Type = dr["drh_DisputeType"].ToString(),
                            Image = imag,
                            OtherInfo = dr["drh_OtherInfo"].ToString(),
                            
                            cus_ID = dr["drh_cus_ID"].ToString(),
                            Remark = dr["drh_Remarks"].ToString(),
                            Amount = dr["drh_Amount"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
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
                dm.TraceService(ex.Message.ToString());
                JSONString = "GetDisputeReqHeaderData - " + ex.Message.ToString();
            }
            dm.TraceService("GetDisputeReqHeaderData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetDisputeReqDetailData([FromForm] PendingDisputeReqDetailIn inputParams)
        {
            dm.TraceService("GetDisputeReqDetailData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.RequestID == null ? "0" : inputParams.RequestID;

            DataTable dtreturn = dm.loadList("SelPendingReturnRequestDetailData", "sp_ReturnRequest", rotID.ToString());



            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<PendingDisputeReqDetailOut> listHeader = new List<PendingDisputeReqDetailOut>();
                    foreach (DataRow drDetails in dtreturn.Rows)
                    {
                        listHeader.Add(new PendingDisputeReqDetailOut
                        {
                            RequestID = drDetails["drd_drh_ID"].ToString(),
                            InvoiceAmount = drDetails["InvoiceAmount"].ToString(),
                            InvoicedDate = drDetails["InvoicedOn"].ToString(),
                            InvoiceID = drDetails["InvoiceID"].ToString(),
                            balance = drDetails["drd_InvoiceBalance"].ToString(),
                            oid_ID = drDetails["drd_oid_ID"].ToString(),
                            


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
                JSONString = "GetDisputeReqDetailData - " + ex.Message.ToString();
            }
            dm.TraceService("GetDisputeReqDetailData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetCompletedDisputeReqHeaderData([FromForm] PendingDisputeReqIn inputParams)
        {
            dm.TraceService("GetCompletedDisputeReqHeaderData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string[] arr = { userID.ToString() };
            DataTable dtreturn = dm.loadList("SelCompletedDisputeReqHeaderData", "sp_DisputeNoteRequest", rotID.ToString(), arr);
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<CompletedDisputeReqOut> listHeader = new List<CompletedDisputeReqOut>();
                    foreach (DataRow dr in dtreturn.Rows)
                    {
                        string imag = "";
                        string img = dr["drh_Image"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["drh_Image"].ToString().Replace("../", "")).Split(',');

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
                        listHeader.Add(new CompletedDisputeReqOut
                        {

                            RequestID = dr["drh_ID"].ToString(),
                            RequestNumber = dr["drh_TransID"].ToString(),
                            rot_ID = dr["drh_rot_ID"].ToString(),
                            Type = dr["drh_DisputeType"].ToString(),
                            Image = imag,
                            OtherInfo = dr["drh_OtherInfo"].ToString(),

                            cus_ID = dr["drh_cus_ID"].ToString(),
                            Remark = dr["drh_Remarks"].ToString(),
                            Amount = dr["drh_Amount"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            ResponseRemark= dr["drh_ResponseRemark"].ToString(),
                            Status= dr["Status"].ToString(),

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
                JSONString = "GetCompletedDisputeReqHeaderData - " + ex.Message.ToString();
            }
            dm.TraceService("GetCompletedDisputeReqHeaderData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
        public string GetCompletedDisputeReqDetailData([FromForm] PendingDisputeReqDetailIn inputParams)
        {
            dm.TraceService("GetCompletedDisputeReqDetailData STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.RequestID == null ? "0" : inputParams.RequestID;

            DataTable dtreturn = dm.loadList("SelCompletedDisputeReqDetailData", "sp_DisputeNoteRequest", rotID.ToString());



            try
            {
                if (dtreturn.Rows.Count > 0)
                {
                    List<PendingDisputeReqDetailOut> listHeader = new List<PendingDisputeReqDetailOut>();
                    foreach (DataRow drDetails in dtreturn.Rows)
                    {
                        listHeader.Add(new PendingDisputeReqDetailOut
                        {
                            RequestID = drDetails["drd_drh_ID"].ToString(),
                            InvoiceAmount = drDetails["InvoiceAmount"].ToString(),
                            InvoicedDate = drDetails["InvoicedOn"].ToString(),
                            InvoiceID = drDetails["InvoiceID"].ToString(),
                            balance = drDetails["drd_InvoiceBalance"].ToString(),
                            oid_ID = drDetails["drd_oid_ID"].ToString(),



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
                JSONString = "GetCompletedDisputeReqDetailData - " + ex.Message.ToString();
            }
            dm.TraceService("GetCompletedDisputeReqDetailData ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

        public string PosDisputeImage([FromForm] DisputeImageIn inputParams)
        {
            dm.TraceService("PosDisputeImage STARTED ");
            dm.TraceService("==============================");
            try
            {

                string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
                


                dm.TraceService("Value for Transaction :" + TransID.ToString());
                

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                       

                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("file Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/DisputeReq");
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
                        string OutImages = "";
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
                                OutImages = "../UploadFiles/DisputeReq/" + REcimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                OutImages += "," + "../UploadFiles/DisputeReq/" + REcimage;
                            }
                            else if (fileSize == 0)
                            {
                                OutImages = "";
                            }
                            dm.TraceService("ImagePath" + OutImages);
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }
                        string[] ar = { OutImages };
                        DataTable dtDN = dm.loadList("InsDisputeImage", "sp_DisputeNoteRequest", TransID, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<DisputeImageOut> listDn = new List<DisputeImageOut>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new DisputeImageOut
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

            dm.TraceService("PosDisputeImage ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

    }
}