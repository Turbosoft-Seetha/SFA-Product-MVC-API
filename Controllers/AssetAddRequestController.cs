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
using MVC_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace MVC_API.Controllers
{
    public class AssetAddRequestController : Controller 
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //[HttpPost]
        public string InsAssetAddRequest([FromForm] InsAssetAddReq inputParams)
        {
            {
                dm.TraceService("InsAssetAddReq STARTED ");
                dm.TraceService("==============================");
                string AssetTypeID = inputParams.AssetTypeID == null ? "0" : inputParams.AssetTypeID;
                string ReasonID = inputParams.ReasonID == null ? "0" : inputParams.ReasonID;
                string Remarks = inputParams.Remarks == null ? "0" : inputParams.Remarks;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;
                string SerialNo = inputParams.SerialNo == null ? "0" : inputParams.SerialNo;
                string AssetName = inputParams.AssetName == null ? "0" : inputParams.AssetName;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string UdpID=inputParams.UdpID == null ? "0" : inputParams.UdpID;
                string rotId=inputParams.rotID == null ? "0" : inputParams.rotID;
                string AssetUniqueID = inputParams.AssetUniqueID == null ? "0" : inputParams.AssetUniqueID;
                string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;


                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("Image Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");
                        //  string newServerBasePath = ConfigurationManager.AppSettings["NewServerBasePath"];
                        var physicalPath = Server.MapPath("../../UploadFiles/AssetAddRequest");
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
                        string img = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started" + y.ToString());
                            imageFiles[y] = HttpReq.Files[y];
                            string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            if (y == 0)
                            {
                                img = "../UploadFiles/AssetAddRequest/" + REcimage.ToString();

                            }
                            else
                            {
                                img += "," + "../UploadFiles/AssetAddRequest/" + REcimage.ToString();
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = {SerialNo,AssetName, ReasonID, Remarks, img, CusID,UdpID, UserID, rotId,AssetUniqueID ,cse_ID};
                        DataTable dtDN = dm.loadList("InsAddReq", "sp_AssetRemovalReq", AssetTypeID, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<OutAssetAddReq> listDn = new List<OutAssetAddReq>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new OutAssetAddReq
                                {
                                    res = dr["res"].ToString(),
                                    des = dr["Des"].ToString(),
                                    TransID = dr["TransID"].ToString()


                                }) ;
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

            dm.TraceService("InsAssetAddReq ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }
    }
}