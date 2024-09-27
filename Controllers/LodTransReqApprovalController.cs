using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using static Stimulsoft.Report.Func;

namespace MVC_API.Controllers
{
    public class LodTransReqApprovalController: Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]
        public string PostLodtransRequestApproval([FromForm] PostLodTransReqData inputParams)
        {
            dm.TraceService("PostLodtransRequestApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostLodTransreqItemData> itemData = JsonConvert.DeserializeObject<List<PostLodTransreqItemData>>(inputParams.JSONString);
                try
                {
                    string usr_ID = inputParams.usr_ID == null ? "0" : inputParams.usr_ID;
                    string udp_ID = inputParams.udp_ID == null ? "PA" : inputParams.udp_ID;
                    string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string Type = inputParams.Type == null ? "0" : inputParams.Type;
                    string Signature = inputParams.Signature == null ? "0" : inputParams.Signature;
                   
                    string Remarks = inputParams.Remarks == null ? "" : inputParams.Remarks;
                  

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostLodTransreqItemData id in itemData)
                            {
                                string[] arr = { id.prd_ID.ToString(), id.CurrentStockHQty.ToString(), id.CurrentStockLQty.ToString(), id.CurrentStockHUOM.ToString(), id.CurrentStockLUOM.ToString(), id.BalanceHQty.ToString(), id.BalanceLQty.ToString(),
                                                 id.BalanceHUOM.ToString(),id.BalanceLUOM.ToString(),id.OffloadHQty.ToString(),id.OffloadLQty,id.OffloadHUOM,id.OffloadLUOM,id.HigherPrice,id.LowerPrice};
                                string[] arrName = { "prd_ID", "CurrentStockHQty", "CurrentStockLQty", "CurrentStockHUOM", "CurrentStockLUOM", "BalanceHQty", "BalanceLQty" ,
                                                      "BalanceHUOM"  ,"BalanceLUOM", "OffloadHQty","OffloadLQty","OffloadHUOM","OffloadLUOM","HigherPrice","LowerPrice"};
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
                        string[] arr = { udp_ID.ToString(), rot_ID.ToString(), InputXml.ToString(), Type.ToString(), Signature.ToString(), Remarks.ToString() , ReqID.ToString() };
                        DataTable dt = dm.loadList("InsLodTransferRequest", "sp_LoadTransferRequest", usr_ID.ToString(), arr);

                        List<GetLodReqInsertStatus> listStatus = new List<GetLodReqInsertStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetLodReqInsertStatus> listHeader = new List<GetLodReqInsertStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetLodReqInsertStatus
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
            dm.TraceService("PostLodtransRequestApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string PostLodtransSignandRemark([FromForm] PostLodTransSignandRemark inputParams)
        {
            dm.TraceService("PostLodtransSignannRemark STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Remarks = inputParams.Remarks == null ? "" : inputParams.Remarks;

            dm.TraceService("TransID:" + TransID);
            try
            {
                var HttpReq = HttpContext.Request;
                dm.TraceService("HttpReq : " + HttpReq);

                try
                {
                    string img = "";

                    HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                    dm.TraceService("HttpReq Count: " + HttpReq.Files.Count);
                    dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                    var folderName = DateTime.Now.ToString("ddMMyyyy");
                    //  string newServerBasePath = ConfigurationManager.AppSettings["NewServerBasePath"];
                    var physicalPath = Server.MapPath("../../UploadFiles/Sign");
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
                    img = "";
                    for (int y = 0; y < HttpReq.Files.Count; y++)
                    {

                        dm.TraceService("Loop Started" + y.ToString());
                        imageFiles[y] = HttpReq.Files[y];
                        string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                        image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                        imageFiles[y].SaveAs(image);
                        if (y == 0)
                        {
                            img = "../UploadFiles/Sign/" + REcimage.ToString();

                        }
                        else
                        {
                            img += "," + "../UploadFiles/Sign/" + REcimage.ToString();
                        }
                        dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                        dm.TraceService("Loop Ended" + y.ToString());

                    }
                    string[] arr = { userID.ToString(), img, Remarks };
                    DataTable dt = dm.loadList("InsLoadTransSignandRemark", "sp_LoadTransferRequest", TransID.ToString(), arr);

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

            dm.TraceService("PostLodtransSignannRemark ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }
        public string GetLodtransRequestApprovalStatus([FromForm] PostLodTransApprovalStatusData inputParams)
        {
            dm.TraceService("GetLodtransRequestApprovalStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


            string[] arr = { userID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelStatusForLoadTransReqApproval", "sp_LoadTransferRequest", TransID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<GetReturnApprovalStatus> listHeader = new List<GetReturnApprovalStatus>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new GetReturnApprovalStatus
                        {
                            ApprovalStatus = dr["ldr_ApprovalStatus"].ToString(),

                            Products = dr["ldr_prd_ID"].ToString(),
                            ReasonID = dr["ldr_rsn_ID"].ToString(),
                            
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

            dm.TraceService("GetLodtransRequestApprovalStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetLodTransReqApprovalHeaderStatus([FromForm] PostLodTransApprovalStatusData inputParams)
        {
            dm.TraceService("GetLodTransReqApprovalHeaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { userID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForLoadTransReqApprovalHeader", "sp_LoadTransferRequest", TransID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetlortransreqApprovalHeaderStatus> listHeader = new List<GetlortransreqApprovalHeaderStatus>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetlortransreqApprovalHeaderStatus
                        {
                            ApprovalStatus = dr["ltr_ApprovalStatus"].ToString()

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
                dm.TraceService("GetLodTransReqApprovalHeaderStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetLodTransReqApprovalHeaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }



        public string GetLoadTranferPDF([FromForm] LoadPDFIn inputParams)
        {
            dm.TraceService("GetLoadTranferPDF STARTED ");
            dm.TraceService("==============================");
            try
            {

                string LoadID = inputParams.LoadID == null ? "0" : inputParams.LoadID;


                dm.TraceService("Value for Transaction" + LoadID.ToString());
                string url = ConfigurationManager.AppSettings.Get("BackendUrl");


                try
                {
                    var s = Server.MapPath("../../BO_Digits/en/Reports/license.key");
                    Stimulsoft.Base.StiLicense.LoadFromFile(s);
                    var report = new StiReport();
                    var path = Server.MapPath("../../BO_Digits/en/Reports/LoadRequests.mrt");
                    dm.TraceService("s:" + s);
                    dm.TraceService("path:" + path);


                    report.Load(path);



                    string DB = ConfigurationManager.AppSettings.Get("MyDB");
                    ((StiSqlDatabase)report.Dictionary.Databases["SFA Reports"]).ConnectionString = DB;

                    DataTable dtDeliveryStatus = dm.loadList("selectLoadRequest", "sp_LoadTransferRequest", LoadID.ToString());
                    string pdfpath = "";
                    string Number = "0";
                    string status = "";

                    if (dtDeliveryStatus.Rows.Count > 0)
                    {
                        if (dtDeliveryStatus.Rows[0]["status"].ToString() == "success")
                        {
                            pdfpath = url + "Downloads/LoadReqst.pdf";
                            Number = dtDeliveryStatus.Rows[0]["lrh_ID"].ToString();
                        }
                        status = dtDeliveryStatus.Rows[0]["status"].ToString();
                    }

                    report["@para1"] = Number.ToString();
                    dm.TraceService("LoadrequestID:" + Number);
                    StiOptions.Export.Pdf.AllowImportSystemLibraries = true;
                    var tempPdfPath = Server.MapPath("../../Downloads/LoadReqst.pdf");
                    dm.TraceService("pdf path:" + tempPdfPath);

                    MemoryStream ms = new MemoryStream();
                    report.Render();
                    report.ExportDocument(StiExportFormat.Pdf, ms);
                    System.IO.File.WriteAllBytes(tempPdfPath, ms.ToArray());
                    // Send the URL of the generated PDF file to client side
                    List<LoadRequestPDFOut> listDns = new List<LoadRequestPDFOut>();

                    listDns.Add(new LoadRequestPDFOut
                    {
                        PDFurl = pdfpath,
                        Status = status
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

            dm.TraceService("GetLoadTranferPDF ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

    }

}