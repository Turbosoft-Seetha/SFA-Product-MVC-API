using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
	public class AppServiceController : Controller
	{
		// GET: AppService


		DataModel dm = new DataModel();
		string JSONString = string.Empty;


		public string GetProducts()
		{
			dm.TraceService("GetProducts STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			DataTable dt = dm.loadList("SelProducts", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<Products> list = new List<Products>();
					foreach (DataRow dr in dt.Rows)
					{

						list.Add(new Products
						{
							prd_ID = dr["prd_ID"].ToString(),
							prd_Name = dr["prd_Name"].ToString(),
							prd_Code = dr["prd_Code"].ToString(),
							prd_Image = dr["prd_Image"].ToString(),
							prd_Description = dr["prd_Description"].ToString(),
							prd_BaseUOM = dr["prd_BaseUOM"].ToString(),
							prd_catID = dr["prd_cat_ID"].ToString(),
							prd_subcatID = dr["prd_sct_ID"].ToString(),
                            prd_ArName= dr["prd_NameArabic"].ToString(),
                            prd_ArDescription= dr["prd_ArabicItemLongDesc"].ToString(),

                        });
					}

					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetProducts  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetProducts ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		public string GetProductUOM()
		{
			dm.TraceService("GetProductUOM STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelProductUOM", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<ProductUOM> list = new List<ProductUOM>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new ProductUOM
						{
							pru_ID = dr["pru_ID"].ToString(),
							pru_uom_ID = dr["pru_uom_ID"].ToString(),
							pru_prd_ID = dr["pru_prd_ID"].ToString(),
							pru_UPC = dr["pru_UPC"].ToString()

						});
					}

					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetProductUOM  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetProductUOM ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		public string GetUOM()
		{
			dm.TraceService("GetUOM STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelUOM", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<UOM> list = new List<UOM>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new UOM
						{
							uom_ID = dr["uom_ID"].ToString(),
							uom_Name = dr["uom_Name"].ToString(),
							uom_IsDecimalAllowed = dr["uom_IsDecimalAllowed"].ToString()

						});
					}
					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetUOM  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetUOM ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}


		public string GetCategory()
		{
			dm.TraceService("GetCategory STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelCategory", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{

					List<Category> list = new List<Category>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new Category
						{
							cat_ID = dr["cat_ID"].ToString(),
							cat_Code = dr["cat_Code"].ToString(),
							cat_Name = dr["cat_Name"].ToString(),
							cat_ArName = dr["cat_NameArabic"].ToString(),
						});
					}

					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetCategory  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetCategory ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		public string GetSubCategory()
		{
			dm.TraceService("GetSubCategory STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelSubCategory", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<SubCategory> list = new List<SubCategory>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new SubCategory
						{
							sub_ID = dr["sct_ID"].ToString(),
							cat_ID = dr["sct_cat_ID"].ToString(),
							sub_Code = dr["sct_Code"].ToString(),
							sub_Name = dr["sct_Name"].ToString(),
							sub_ArName = dr["sct_NameArabic"].ToString(),

						});
					}

					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetSubCategory  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetSubCategory ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		public string GetWarehouse()
		{
			dm.TraceService("GetWarehouse STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			//string x = Session["usr_ID"].ToString();
			DataTable dt = dm.loadList("SelWarehouse", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<Warehouse> list = new List<Warehouse>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new Warehouse
						{
							war_ID = dr["war_ID"].ToString(),
							war_Name = dr["war_Name"].ToString(),
							war_Code = dr["war_Code"].ToString(),
							str_ID = dr["war_str_ID"].ToString(),
							str_Name = dr["str_Name"].ToString(),
							CreatedDate = dr["CreatedDate"].ToString(),
							CreatedBy = dr["CreatedBy"].ToString(),
                            war_ArName = dr["war_ArabicName"].ToString(),
                            str_ArName = dr["str_ArabicName"].ToString(),

                        });
					}
					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetWarehouse  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetWarehouse ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		public string GetRoute()
		{
			dm.TraceService("GetRoute STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelRoute", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<Route> list = new List<Route>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new Route
						{
							rot_ID = dr["rot_ID"].ToString(),
							rot_Code = dr["rot_Code"].ToString(),
							rot_Name = dr["rot_Name"].ToString()

						});
					}
					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetRoute  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetRoute ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		public string GetReason()
		{
			dm.TraceService("GetReason STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelReason", "sp_sfaAppServices");

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<Reason> list = new List<Reason>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new Reason
						{
							rsn_ID = dr["rsn_ID"].ToString(),
							rsn_Name = dr["rsn_Name"].ToString(),
							rsn_Type = dr["rsn_Type"].ToString(),
                            rsn_ArName = dr["rsn_NameArabic"].ToString()

                        });
					}
					JSONString = JsonConvert.SerializeObject(new
					{
						result = list
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
				dm.TraceService("GetReason  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetReason ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

        public string BadReturnImages([FromForm] BadreturnAttachments inputParams)
        {
            dm.TraceService("BadReturnImages STARTED ");
            dm.TraceService("==============================");
            try
            {

                string TrnNo = inputParams.TrnNo == null ? "0" : inputParams.TrnNo;
                string prdID = inputParams.prdID == null ? "0" : inputParams.prdID;
                string attachType = inputParams.Attachment == null ? "0" : inputParams.Attachment;

                dm.TraceService("Value for Transaction" + TrnNo.ToString());
                dm.TraceService("Value for product" + prdID.ToString());
                dm.TraceService("Value for Attachament " + attachType.ToString());
                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("file Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/ReturnImages");
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
                        string rtnImages = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started" + y.ToString());
                            imageFiles[y] = HttpReq.Files[y];
                            long fileSize = imageFiles[y].ContentLength;
                            string badrtnimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            if (y == 0 && fileSize > 0)
                            {
                                rtnImages = "../UploadFiles/ReturnImages/" + badrtnimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                rtnImages += "," + "../UploadFiles/ReturnImages/" + badrtnimage;
                            }
                            else if (fileSize == 0)
                            {
                                rtnImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = { rtnImages, prdID };
                        DataTable dtDN = dm.loadList("InsBadrtnAttachment", "sp_SFA_App_Sales", TrnNo, ar);
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

            dm.TraceService("BadReturnImages ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }

        public string GetWarehouseItems()
        {

            dm.TraceService("GetWarehouseItems STARTED ");
            dm.TraceService("====================");
            try
            {
                string[] arr = { "" };
                DataSet dtstkItemBatch = dm.loadListDS("GetWarehouseItems", "sp_StockCountingWS", "0", arr);
                DataTable itemData = dtstkItemBatch.Tables[0];
                DataTable batchData = dtstkItemBatch.Tables[1];
               
                if (itemData.Rows.Count > 0)
                {
                    List<InstantStkCntwarID> listItems = new List<InstantStkCntwarID>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<InstantStkCntwarItmID> listitemSerial = new List<InstantStkCntwarItmID>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {

                            if (dr["war_ID"].ToString() == drDetails["wim_war_ID"].ToString())
                            {
                                listitemSerial.Add(new InstantStkCntwarItmID
                                {
                                    waritm_ID = drDetails["wim_prd_ID"].ToString(),
                                    wareID = drDetails["wim_war_ID"].ToString(),
                                    prd_Spec = drDetails["prd_Spec"].ToString(),
                                    prd_Name = drDetails["prd_Name"].ToString(),
                                    prd_Code = drDetails["prd_Code"].ToString(),
                                    prd_Desc = drDetails["prd_Description"].ToString(),

                                });
                            }
                        }

                        listItems.Add(new InstantStkCntwarID
                        {
                            war_ID = dr["war_ID"].ToString(),

                            itemserial = listitemSerial

                        }); ;
                    }

                    JSONString = JsonConvert.SerializeObject(new
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
                dm.TraceService("NoDataSQL - " + ex.Message.ToString());
            }

            dm.TraceService("GetWarehouseItems ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }
        public string GetImageCapture([FromForm] ImageCaptureIn inputParams)
        {
            dm.TraceService("GetImageCapture STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
			string[] arr = { inputParams.cusID };
            DataTable dt = dm.loadList("SelectImageCapture", "sp_AppServices", rotID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ImageCaptureOut> listHeader = new List<ImageCaptureOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        string imag = "";
                        string img = dr["mei_Images"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["mei_Images"].ToString().Replace("../", "")).Split(',');

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


                        listHeader.Add(new ImageCaptureOut
                        {
                            meiID = dr["mei_ID"].ToString(),
                            Date = dr["Date"].ToString(),
                            Type = dr["Type"].ToString(),
                            Images = imag,
                            Remarks = dr["mei_Remarks"].ToString()
                            



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
                dm.TraceService("GetImageCapture  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetImageCapture ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string SelectFieldServiceCount([FromForm] FScountIn inputParams)
        {
            dm.TraceService("SelectFieldServiceCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;

            string[] arr = { cus_ID ,cse_ID};
            DataTable dt = dm.loadList("SelectFieldServiceCount", "sp_AppServices", udp_ID, arr);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<FScountOut> listHeader = new List<FScountOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new FScountOut
                        {

                            Addreq = dr["Addreq"].ToString(),
                            Remreq = dr["Remreq"].ToString(),
                            servicereq = dr["servicereq"].ToString(),
                            servicejob = dr["servicejob"].ToString(),
							AssetTrack= dr["AssetTrack"].ToString()
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
                dm.TraceService("SelectFieldServiceCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectFieldServiceCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        
        public string SelVersionDetails([FromForm] VersionDetailIn inputParams)
        {
            dm.TraceService("SelVersionDetails STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                string Type = inputParams.Type == null ? "0" : inputParams.Type;
                DataTable dtitem = dm.loadList("SelVersionDetail", "sp_SFA_App", Type.ToString());

                if (dtitem.Rows.Count > 0)
                {
                    List<VersionDetailOut> listItems = new List<VersionDetailOut>();
                    foreach (DataRow dr in dtitem.Rows)
                    {
                        listItems.Add(new VersionDetailOut
                        {
                            ver_code = dr["ver_code"].ToString(),
                            ver_name = dr["ver_name"].ToString(),
                            url = dr["redir_url"].ToString(),
                            msg = dr["msg"].ToString(),
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
                dm.TraceService(" SelVersionDetails Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelVersionDetails ENDED - " + DateTime.Now);
            dm.TraceService("==================");
            return JSONString;
        }
        public string UpdateCusConnectUserAppVersion([FromForm] CCVersionIn inputParams)
        {
            dm.TraceService("UpdateUserAppVersion STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string Version = inputParams.Version == null ? "0" : inputParams.Version;
                string[] ar = { Version.ToString() };
                DataTable dt = dm.loadList("UpdateUserAppVersion", "sp_SFA_App", UserID.ToString(), ar);
                if (dt.Rows.Count > 0)
                {
                    List<CCVersionOut> listItems = new List<CCVersionOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listItems.Add(new CCVersionOut
                        {
                            Res = dr["Res"].ToString(),
                            Title = dr["Title"].ToString(),
                            Descr = dr["Descr"].ToString()
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
                dm.TraceService(" UpdateUserAppVersion Exception - " + ex.Message.ToString());
            }
            dm.TraceService("UpdateUserAppVersion ENDED - " + DateTime.Now);
            dm.TraceService("==================");
            return JSONString;
        }
        public string GetSettings([FromForm] settingsIn inputParams)
        {
            dm.TraceService("GetSettings STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            DataTable dt = dm.loadList("AppSettings", "sp_InventoryAppLogin", inputParams.userid);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<settingsOut> list = new List<settingsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new settingsOut
                        {
                            IsInstantStockCount = dr["IsInstantStockCount"].ToString(),
                            InventoryOperations = dr["InventoryOps"].ToString()


                        });
                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = list
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
                dm.TraceService("GetSettings  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetSettings ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string Brand()
        {
            dm.TraceService("Brand STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            DataTable dt = dm.loadList("ListBrand", "sp_SFA_App");
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<Brand> list = new List<Brand>();
                    foreach (DataRow dr in dt.Rows)


                    {
                        string imag = "";
                        string img = dr["brd_Img"].ToString();
                        if (img != "")
                        {
                            string[] ar = (dr["brd_Img"].ToString().Replace("../", "")).Split(',');

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
                        
                        list.Add(new Brand
                        {
                            brd_ID = dr["brd_ID"].ToString(),
                            brd_Name = dr["brd_Name"].ToString(),
                            brd_Code = dr["brd_Code"].ToString(),
                            brd_NameArabic = dr["brd_NameArabic"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CreatedBy = dr["CreatedBy"].ToString(),
                            Img = imag,
                            Status = dr["Status"].ToString(),

                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = list
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
                dm.TraceService("Brand  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("Brand ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    }

}