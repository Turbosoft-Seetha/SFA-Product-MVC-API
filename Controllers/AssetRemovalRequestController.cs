using System;
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
using static MVC_API.Models.AssetRemReq;

namespace MVC_API.Controllers
{
    public class AssetRemovalRequestController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //[HttpPost]
        public string InsAssetRemovalReq([FromForm] InsAssetRemReq inputParams) 
        {
            {
                dm.TraceService("InsAssetRemovalReq STARTED ");
                dm.TraceService("==============================");
                string AssetTypeID = inputParams.AssetTypeID == null ? "0" : inputParams.AssetTypeID;
                string ReasonID = inputParams.ReasonID == null ? "0" : inputParams.ReasonID;
                string Remarks = inputParams.Remarks == null ? "0" : inputParams.Remarks;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;
                string AssetID = inputParams.AssetID == null ? "0" : inputParams.AssetID;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string rotId = inputParams.rotID == null ? "0" : inputParams.rotID;
                string AssetUniqueID = inputParams.AssetUniqueID == null ? "0" : inputParams.AssetUniqueID;
                string AssetMasterID = inputParams.AssetMasterID == null ? "0" : inputParams.AssetMasterID;
                string udpId=inputParams.udpID == null ? "0" :inputParams.udpID;
                string IsImage = inputParams.IsImage == null ? "0" : inputParams.IsImage;
                string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;

                dm.TraceService("AssetMasterID:"+AssetMasterID);

                try
                {
                    string[] arr = { CusID };
                    DataTable dt = dm.loadList("CheckAssetRemRequest", "sp_AssetRemovalReq", AssetID, arr);
                    if (dt.Rows.Count > 0)
                    {
                        List<OutAssetRemReq> listDn = new List<OutAssetRemReq>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            listDn.Add(new OutAssetRemReq
                            {
                                res = "Failure",
                                des = "Request Already Added",


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
                        var HttpReq = HttpContext.Request;
                        dm.TraceService("HttpReq : " + HttpReq);
                        try
                        {



                            string img = "";
                            if (IsImage == "Y")
                            {

                                HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                                dm.TraceService("HttpReq Count: " + HttpReq.Files.Count);
                                dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                                var folderName = DateTime.Now.ToString("ddMMyyyy");
                                //  string newServerBasePath = ConfigurationManager.AppSettings["NewServerBasePath"];
                                var physicalPath = Server.MapPath("../../UploadFiles/AssetRemovalRequest");
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
                                        img = "../UploadFiles/AssetRemovalRequest/" + REcimage.ToString();

                                    }
                                    else
                                    {
                                        img += "," + "../UploadFiles/AssetRemovalRequest/" + REcimage.ToString();
                                    }
                                    dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                                    dm.TraceService("Loop Ended" + y.ToString());
                                }
                            }
                            else
                            {
                                img = "";
                            }
                            string[] ar = { ReasonID, Remarks, img, CusID, AssetID, UserID, rotId, AssetUniqueID, AssetMasterID, udpId, cse_ID };
                            DataTable dtDN = dm.loadList("InsRemReq", "sp_AssetRemovalReq", AssetTypeID, ar);
                            if (dtDN.Rows.Count > 0)
                            {
                                List<OutAssetRemReq> listDn = new List<OutAssetRemReq>();
                                foreach (DataRow dr in dtDN.Rows)
                                {
                                    listDn.Add(new OutAssetRemReq
                                    {
                                        res = dr["res"].ToString(),
                                        des = dr["Des"].ToString(),

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
                    


                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "NoDataSQL - " + ex.Message.ToString();
                }

                
            }
            
            dm.TraceService("InsAssetRemovalReq ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }
    }
}