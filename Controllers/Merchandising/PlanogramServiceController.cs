using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using Stimulsoft.Report.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using MVC_API.Models.MerchandisingHelper;
using iTextSharp.text.pdf;

namespace MVC_API.Controllers.Merchandising
{
    public class PlanogramServiceController : Controller
    {
        // GET: PlanogramService
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public string SelectPlanogramMasterView([FromForm] PlanogramInPara inputParams)
        {
            dm.TraceService("SelectPlanogramMaster STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string cusId = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string[] arr = { cusId.ToString() };

            DataTable dt = dm.loadList("SelPlanogramMaster", "sp_MerchandisingWebServices", rot_ID,arr);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<PlanogramMasterOut> listHeader = new List<PlanogramMasterOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new PlanogramMasterOut
                        {
                            plg_ID = dr["plg_ID"].ToString(),
                            plg_Code = dr["plg_Code"].ToString(),
                            plg_Name = dr["plg_Name"].ToString(),
                            plg_Image = dr["plg_Image"].ToString(),
                            plg_Remarks = dr["plg_Remarks"].ToString(),
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
                dm.TraceService("SelectPlanogramMaster - Error :   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectPlanogramMaster ENDED ");
            dm.TraceService("======================================");

            return JSONString;
        }
        //public string PostPlanogramImage([FromForm] PostPlanogramImageIn inputParams)
        //{
        //    dm.TraceService("PostPlanogramImage STARTED " + DateTime.Now.ToString());
        //    dm.TraceService("======================================");
        //    string PlgCode = inputParams.PlgCode ?? "0";
        //    string UserID = inputParams.UserID ?? "0";
        //    string Remarks = inputParams.Remarks ?? "";
        //    string ResponseId = inputParams.ResponseId ?? "0";
        //    try
        //    {
        //        var HttpReq = HttpContext.Request;
        //        dm.TraceService("HttpReq : " + HttpReq);
        //        try
        //        {

        //            HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
        //            dm.TraceService("HttpReq Count: " + HttpReq.Files.Count);
        //            List<string> imagePaths = new List<string>();
        //            if (HttpReq.Files.Count > 0)
        //            {
        //                dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
        //                var folderName = DateTime.Now.ToString("ddMMyyyy");
        //               var physicalPath = "E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles/MerchInsPlanogram";
        //                //var physicalPath = Server.MapPath("../../UploadFiles/MerchInsPlanogram");
        //                dm.TraceService("Physical Path Generated" + physicalPath.ToString());
        //                if (!Directory.Exists(physicalPath))
        //                {
        //                    Directory.CreateDirectory(physicalPath);
        //                    dm.TraceService("Directory Created");
        //                }

        //                for (int y = 0; y < HttpReq.Files.Count; y++)
        //                {
        //                    dm.TraceService("Loop Started" + y.ToString());
        //                    imageFiles[y] = HttpReq.Files[y];
        //                    var file = HttpReq.Files[y];
        //                    if (file != null && file.ContentLength > 0)
        //                    {
        //                        string fileName = DateTime.Now.ToString("HHmmss") + Path.GetFileName(file.FileName);
        //                        string fullPath = Path.Combine(physicalPath, fileName);
        //                        file.SaveAs(fullPath);
        //                        imagePaths.Add("../UploadFiles/MerchInsPlanogram/" + fileName);

        //                        dm.TraceService("ImageFile: " + file.FileName);
        //                    }
        //                    dm.TraceService("Loop Ended" + y.ToString());
        //                }
        //            }
        //            string img = imagePaths.Count > 0 ? string.Join(",", imagePaths) : "";
        //            string[] arr = { img, Remarks, PlgCode, UserID, ResponseId };
        //            dm.TraceService("Params: " + string.Join(", ", arr));
        //            DataTable dt = dm.loadList("InsPanogramImg", "sp_MerchandisingWebServices", ResponseId.ToString(), arr);
        //            List<PanogramStatus> listStatus = new List<PanogramStatus>();
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                dm.TraceService("DataTable Rows: " + dt.Rows.Count);
        //                List<PanogramStatus> listHeader = new List<PanogramStatus>();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    listHeader.Add(new PanogramStatus
        //                    {
        //                        Mode = dr["Res"].ToString(),
        //                        Status = dr["Status"].ToString()
        //                    });
        //                }
        //                JSONString = JsonConvert.SerializeObject(new
        //                {
        //                    result = listHeader
        //                });
        //                return JSONString;
        //            }
        //            else
        //            {
        //                dm.TraceService("NoDataRes");
        //                JSONString = "NoDataRes";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            dm.TraceService(ex.Message.ToString());
        //            JSONString = "NoDataSQL - " + ex.Message.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dm.TraceService(ex.Message.ToString());
        //        JSONString = "NoDataSQL - " + ex.Message.ToString();
        //    }
        //    dm.TraceService("PostPlanogramImage ENDED ");
        //    dm.TraceService("==========================");
        //    return JSONString;

        //}



        public string PostPlanogramImage([FromForm] PostPlanogramImageIn inputParams)
        {
            dm.TraceService("PostPlanogramImage STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            try
            {
            string UserID = inputParams.UserID ?? "0";
            string Remarks = inputParams.Remarks ?? "";
            string ResponseId = inputParams.ResponseId ?? "0";
            string UdpId = inputParams.UdpId ?? "0";
            string CusId = inputParams.CusId?? "0";
            string CseId = inputParams.CseId ?? "0";
            string RouteId = inputParams.RouteId ?? "0";

                var HttpReq = HttpContext.Request;
                dm.TraceService("HttpReq : " + HttpReq);
                try
                {

                    HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                    dm.TraceService("HttpReq Count: " + HttpReq.Files.Count);
                    dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                    var folderName = DateTime.Now.ToString("ddMMyyyy");
                    //var physicalPath = "E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles/MerchInsPlanogram";
                    var physicalPath = Server.MapPath("../../UploadFiles/MerchInsPlanogram");
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
                            ReceiptImages = "../UploadFiles/MerchInsPlanogram/" + REcimage;

                        }
                        else if (y != 0 && fileSize > 0)
                        {
                            ReceiptImages += "," + "../UploadFiles/MerchInsPlanogram/" + REcimage;
                        }
                        else if (fileSize == 0)
                        {
                            ReceiptImages = "";
                        }
                        dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                        dm.TraceService("Loop Ended" + y.ToString());
                    }
                    string[] arr = { ReceiptImages.ToString(), Remarks,UserID,UdpId,CusId,CseId,RouteId };
                    dm.TraceService("Params: " + string.Join(",", arr));
                    DataTable dt = dm.loadList("InsPlanogramImg", "sp_MerchandisingWebServices", ResponseId.ToString(), arr);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dm.TraceService("DataTable Rows: " + dt.Rows.Count);
                        List<PanogramStatus> listHeader = new List<PanogramStatus>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            listHeader.Add(new PanogramStatus
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
            dm.TraceService("PostPlanogramImage ENDED ");
            dm.TraceService("==========================");
            return JSONString;

        }

    }
}