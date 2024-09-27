using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.ApprovalHelper;
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

namespace MVC_API.Controllers
{
	public class CouponController : Controller
	{
		DataModel dm = new DataModel();
		string JSONString = string.Empty;

		public string SelectCouponCollectionHeader([FromForm] CouponHeaderIn inputParams)
		{
			dm.TraceService("SelectCouponCollectionHeader STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;

			DataTable dt = dm.loadList("SelCouponCollectionHeader", "sp_CouponCollection", rot_ID);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<CouponHeaderOut> listHeader = new List<CouponHeaderOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new CouponHeaderOut
						{
							cph_ID = dr["cph_ID"].ToString(),
							cph_Number = dr["cph_Number"].ToString(),
							cph_rot_ID = dr["cph_rot_ID"].ToString(),
							Date = dr["Date"].ToString(),
							Time = dr["Time"].ToString(),
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
				dm.TraceService("SelectCouponCollectionHeader - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("SelectCouponCollectionHeader ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string SelectCouponCollectionDetail([FromForm] CouponDetailIn inputParams)
		{
			dm.TraceService("SelectCouponCollectionDetail STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			string cph_ID = inputParams.cph_ID == null ? "0" : inputParams.cph_ID;
			string userID = inputParams.userID == null ? "0" : inputParams.userID;

			string[] arr = { userID };
			DataSet dt = dm.loadListDS("SelCouponCollectionDetail", "sp_CouponCollection", cph_ID, arr);
			DataTable DetailData = dt.Tables[0];
			DataTable BookData = dt.Tables[1];
			DataTable ItemData = dt.Tables[2];
			DataTable BookLeafData = dt.Tables[3];

			try
			{
				if (DetailData.Rows.Count > 0)
				{
					List<CouponDetailOut> listDetail = new List<CouponDetailOut>();
					foreach (DataRow dr in DetailData.Rows)
					{

						List<CouponBookOut> listBook = new List<CouponBookOut>();
						foreach (DataRow drs in BookData.Rows)
						{

							List<CouponBookLeafOut> listBookLeaf = new List<CouponBookLeafOut>();
							foreach (DataRow dts in BookLeafData.Rows)
							{
								if (drs["cpb_cph_ID"].ToString() == dts["cbl_cph_ID"].ToString() && drs["cpb_cpd_ID"].ToString() == dts["cbl_cpd_ID"].ToString() && drs["cpb_ID"].ToString() == dts["cbl_cpb_ID"].ToString())
								{
									listBookLeaf.Add(new CouponBookLeafOut
									{
										cbl_ID = dts["cbl_ID"].ToString(),
										cbl_cph_ID = dts["cbl_cph_ID"].ToString(),
										cbl_cpd_ID = dts["cbl_cpd_ID"].ToString(),
										cbl_cpb_ID = dts["cbl_cpb_ID"].ToString(),
										cbl_LeafNumber = dts["cbl_LeafNumber"].ToString(),
										Status = dts["Status"].ToString(),
										IsCheckedLeaf = dts["cbl_IsChecked"].ToString(),
									});
								}
							}

							if (dr["cpd_cph_ID"].ToString() == drs["cpb_cph_ID"].ToString() && dr["cpd_ID"].ToString() == drs["cpb_cpd_ID"].ToString())
							{
								listBook.Add(new CouponBookOut
								{
									cpb_ID = drs["cpb_ID"].ToString(),
									cpb_cph_ID = drs["cpb_cph_ID"].ToString(),
									cpb_cpd_ID = drs["cpb_cpd_ID"].ToString(),
									cpb_BookNumber = drs["cpb_BookNumber"].ToString(),
									Status = drs["Status"].ToString(),
									IsChecked = drs["cpb_IsChecked"].ToString(),
									LeafDetail = listBookLeaf,
								});
							}
						}

						List<CouponItemOut> listItems = new List<CouponItemOut>();
						foreach (DataRow dts in ItemData.Rows)
						{
							if (dr["cpd_cpm_ID"].ToString() == dts["cpt_cpm_ID"].ToString())
							{
								listItems.Add(new CouponItemOut
								{
									prd_ID = dts["cpt_prd_ID"].ToString(),
									prd_Code = dts["prd_Code"].ToString(),
									prd_Name = dts["prd_Name"].ToString(),
									cpm_Price = dts["prd_Name"].ToString(),

								});
							}
						}

						listDetail.Add(new CouponDetailOut
						{
							cpd_ID = dr["cpd_ID"].ToString(),
							cpd_cph_ID = dr["cpd_cph_ID"].ToString(),
							cpd_cpm_ID = dr["cpd_cpm_ID"].ToString(),
							cpm_Code = dr["cpm_Code"].ToString(),
							cpm_Name = dr["cpm_Name"].ToString(),
							cpd_HigherQty = dr["cpd_HigherQty"].ToString(),
							cpd_AdjHigherQty = dr["cpd_AdjHigherQty"].ToString(),
							cpd_FinalHigherQty = dr["cpd_FinalHigherQty"].ToString(),
							Status = dr["Status"].ToString(),
							BookDetail = listBook,
							ItemDetail = listItems,
							cpm_Price = dr["cpm_Price"].ToString(),
							cpm_NoOfLeaf = dr["cpm_NoOfLeaf"].ToString(),
						});
					}

					JSONString = JsonConvert.SerializeObject(new
					{
						result = listDetail
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
				dm.TraceService("SelectCouponCollectionDetail - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("SelectCouponCollectionDetail ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string ConfirmCouponCollection([FromForm] ConfirmCouponIn inputParams)
		{
			dm.TraceService("ConfirmCouponCollection STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostCouponData> DetailData = JsonConvert.DeserializeObject<List<PostCouponData>>(inputParams.CouponDetailXML);
			List<PostCouponBookData> BookData = JsonConvert.DeserializeObject<List<PostCouponBookData>>(inputParams.CouponBookXML);

			string InputXmlDetail = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponData id in DetailData)
					{
						string[] arr = { id.cpd_ID.ToString(), id.cpd_HigherQty.ToString(), id.cpd_AdjHigherQty.ToString(), id.cpd_FinalHigherQty.ToString() };
						string[] arrName = { "cpd_ID", "cpd_HigherQty", "cpd_AdjHigherQty", "cpd_FinalHigherQty" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlDetail = sw.ToString();
			}

			string InputXmlBook = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponBookData id in BookData)
					{
						string[] arr = { id.cpb_ID.ToString(), id.cpd_ID.ToString(), id.IsChecked.ToString() };
						string[] arrName = { "cpb_ID", "cpd_ID", "IsChecked" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlBook = sw.ToString();
			}

			string cpd_cph_ID = inputParams.cpd_cph_ID == null ? "0" : inputParams.cpd_cph_ID;
			string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
			string SecurityAmount= inputParams.SecurityAmount == null ? "0" : inputParams.SecurityAmount;
			string[] ar = { InputXmlDetail, InputXmlBook, UserID, SecurityAmount };
			DataTable dt = dm.loadList("UpdateCouponConfirm", "sp_CouponCollection", cpd_cph_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<ConfirmCouponOut> listHeader = new List<ConfirmCouponOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new ConfirmCouponOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),

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
				dm.TraceService("ConfirmCouponCollection - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("ConfirmCouponCollection ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string ConfirmReturnCouponCollection([FromForm] ConfirmReturnCouponIn inputParams)
		{
			dm.TraceService("ConfirmReturnCouponCollection STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostReturnCouponData> DetailData = JsonConvert.DeserializeObject<List<PostReturnCouponData>>(inputParams.CouponDetailXML);
			List<PostReturnCouponBookData> BookData = JsonConvert.DeserializeObject<List<PostReturnCouponBookData>>(inputParams.CouponBookXML);

			string InputXmlDetail = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostReturnCouponData id in DetailData)
					{
						string[] arr = { id.cpm_ID.ToString(), id.HigherQty.ToString(), id.AdjHigherQty.ToString(), id.FinalHigherQty.ToString(), id.OffloadQty.ToString() };
						string[] arrName = { "cpm_ID", "HigherQty", "AdjHigherQty", "FinalHigherQty", "OffloadQty" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlDetail = sw.ToString();
			}

			string InputXmlBook = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostReturnCouponBookData id in BookData)
					{
						string[] arr = { id.cpm_ID.ToString(), id.cpb_ID.ToString(), id.IsChecked.ToString() };
						string[] arrName = { "cpm_ID", "cpb_ID", "IsChecked" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlBook = sw.ToString();
			}

			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
			string SecurityAmount = inputParams.SecurityAmount == null ? "0" : inputParams.SecurityAmount;
			string CustomerId = inputParams.CustomerId == null ? "0" : inputParams.CustomerId;

			string[] ar = { InputXmlDetail, InputXmlBook, UserID, SecurityAmount, CustomerId };
			DataTable dt = dm.loadList("InsReturnCouponConfirm", "sp_CouponCollection", rot_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<ConfirmReturnCouponOut> listHeader = new List<ConfirmReturnCouponOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new ConfirmReturnCouponOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),

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
				dm.TraceService("ConfirmReturnCouponCollection - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("ConfirmReturnCouponCollection ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string ConfirmCouponIssue([FromForm] ConfirmCouponIssueIn inputParams)
		{
			dm.TraceService("ConfirmCouponIssue STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostCouponIssueData> BookData = JsonConvert.DeserializeObject<List<PostCouponIssueData>>(inputParams.CouponBookXML);

			string InputXmlBook = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponIssueData id in BookData)
					{
						string[] arr = { id.cpm_ID.ToString(), id.cpb_ID.ToString() };
						string[] arrName = { "cpm_ID", "cpb_ID" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlBook = sw.ToString();
			}

			string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
			string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
			string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;


			var imagePath1 = string.Empty;
			var imagePath2 = string.Empty;
			dm.TraceService("ReceiptImg1:" + inputParams.ReceiptImg1);
			dm.TraceService("ReceiptImg2:" + inputParams.ReceiptImg2);
			// Process ReceiptImg1
			if (!string.IsNullOrEmpty(inputParams.ReceiptImg1))
			{
				imagePath1 = SaveImage(inputParams.ReceiptImg1, inputParams.udp_ID, "1");
				dm.TraceService("imagePath1:" + imagePath1);
			}

			// Process ReceiptImg2
			if (!string.IsNullOrEmpty(inputParams.ReceiptImg2))
			{
				imagePath2 = SaveImage(inputParams.ReceiptImg2, inputParams.udp_ID, "2");
				dm.TraceService("imagePath2:" + imagePath2);
			}

			// Method to save the image and return the path
			string SaveImage(string imageBase64, string udpID, string suffix)
			{
				var physicalPath = Server.MapPath("../../UploadFiles/Coupon/Receipt");
				dm.TraceService("physicalPath:" + physicalPath);
				if (!Directory.Exists(physicalPath))
				{
					Directory.CreateDirectory(physicalPath);
					dm.TraceService("Directory Created");
				}
				var imageDirectoryPath = physicalPath + "/";
				if (!Directory.Exists(imageDirectoryPath))
				{
					Directory.CreateDirectory(imageDirectoryPath);
					dm.TraceService("Directory for Image Path Created");
				}

				try
				{
					byte[] imageBytes = Convert.FromBase64String(imageBase64);
					string dateTimeStamp = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_fff");
					string ext = ".jpg";
					string imageFileName = $"{udp_ID}_{suffix}_{dateTimeStamp}{ext}";
					dm.TraceService("imageFileName:" + imageFileName);
					string imagePathWithName = Path.Combine(imageDirectoryPath, imageFileName);
					dm.TraceService("imagePathWithName:" + imagePathWithName);
					using (FileStream fs = new FileStream(imagePathWithName, FileMode.Create))
					{
						fs.Write(imageBytes, 0, imageBytes.Length);
					}
					return "../UploadFiles/Coupon/Receipt" + imageFileName;
				}
				catch (Exception ex)
				{
					dm.TraceService("Error processing image: " + ex.Message);
					return string.Empty;
				}
			}
			string combinedImagePath = string.Join(",", new[] { imagePath1, imagePath2 }.Where(p => !string.IsNullOrEmpty(p)));
			dm.TraceService("combinedImagePath:" + combinedImagePath);
			string[] ar = { udp_ID, UserID, InputXmlBook, combinedImagePath };
			//string[] ar = { udp_ID, UserID, InputXmlBook, imagePath1, imagePath2 };
			dm.TraceService("values:" + ar);
			DataTable dt = dm.loadList("InsCouponIssuing", "sp_CouponCollection", cus_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<ConfirmCouponIsueOut> listHeader = new List<ConfirmCouponIsueOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new ConfirmCouponIsueOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),

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
				dm.TraceService("ConfirmCouponIssue - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("ConfirmCouponIssue ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}
		public string SelectCustomerCouponDetail([FromForm] CusCouponDetailIn inputParams)
		{
			dm.TraceService("SelectCustomerCouponDetail STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			string userID = inputParams.userID == null ? "0" : inputParams.userID;

			string[] arr = { userID };
			DataSet dt = dm.loadListDS("SelCustomerCouponDetail", "sp_CouponCollection", rot_ID, arr);
			DataTable DetailData = dt.Tables[0];
			DataTable leafData = dt.Tables[1];


			try
			{
				if (DetailData.Rows.Count > 0)
				{
					List<CusCouponDetailOut> listDetail = new List<CusCouponDetailOut>();
					foreach (DataRow dr in DetailData.Rows)
					{
						List<CusCouponBookLeafOut> listBookLeaf = new List<CusCouponBookLeafOut>();
						foreach (DataRow dts in leafData.Rows)
						{
							if (dr["cac_cpb_ID"].ToString() == dts["cac_cpb_ID"].ToString())
							{
								listBookLeaf.Add(new CusCouponBookLeafOut
								{
									cbl_ID = dts["cbl_ID"].ToString(),
									cbl_cpb_ID = dr["cac_cpb_ID"].ToString(),
									cbl_LeafNumber = dts["cbl_LeafNumber"].ToString(),
									LeafStatus = dts["LeafStatus"].ToString(),
									IsCheckedLeaf = dts["cbl_IsChecked"].ToString(),

								});
							}
						}

						listDetail.Add(new CusCouponDetailOut
						{
							cac_ID = dr["cac_ID"].ToString(),
							cac_cus_ID = dr["cac_cus_ID"].ToString(),
							cac_cpm_ID = dr["cac_cpm_ID"].ToString(),
							cac_cpb_ID = dr["cac_cpb_ID"].ToString(),
							cpm_Code = dr["cpm_Code"].ToString(),
							cpm_Name = dr["cpm_Name"].ToString(),
							cpb_BookNumber = dr["cpb_BookNumber"].ToString(),
							BookStatus = dr["BookStatus"].ToString(),
							IsChecked = dr["cpb_IsChecked"].ToString(),
							LeafDetail = listBookLeaf,
						});
					}

					JSONString = JsonConvert.SerializeObject(new
					{
						result = listDetail
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
				dm.TraceService("SelectCustomerCouponDetail - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("SelectCustomerCouponDetail ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string InsSalesInvoice([FromForm] SalesInvoiceIn inputParams)
		{
			dm.TraceService("InsSalesInvoice STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostSalesItemDetail> ItemDetailData = JsonConvert.DeserializeObject<List<PostSalesItemDetail>>(inputParams.SalesItemDetailXML);
			List<PostCouponBookLeaf> BookLeafData = JsonConvert.DeserializeObject<List<PostCouponBookLeaf>>(inputParams.CouponBookLeafXML);
			List<PostCouponBottleReturn> BottleReturnData = JsonConvert.DeserializeObject<List<PostCouponBottleReturn>>(inputParams.CouponReturnXML);

			string InputXmlDetail = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostSalesItemDetail id in ItemDetailData)
					{
						string[] arr = { id.sld_itm_ID.ToString(), id.sld_HigherUOM.ToString(), id.sld_LowerUOM.ToString(), id.sld_HigherQty.ToString(),
						id.sld_LowerQty.ToString(), id.sld_HigherPrice.ToString(), id.sld_LowerPrice.ToString() , id.sld_LineTotal.ToString() ,
						id.sld_TotalQty.ToString(),id.sld_VatPercent.ToString(),id.sld_Discount.ToString(),id.sld_GrandTotal.ToString(),id.sld_VatAmount.ToString() };

						string[] arrName = { "sld_itm_ID", "sld_HigherUOM", "sld_LowerUOM", "sld_HigherQty" , "sld_LowerQty" , "sld_HigherPrice" , "sld_LowerPrice",
						"sld_LineTotal" , "sld_TotalQty","sld_VatPercent","sld_Discount", "sld_GrandTotal","sld_VatAmount"};
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlDetail = sw.ToString();
			}

			string InputXmlBook = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponBookLeaf id in BookLeafData)
					{
						string[] arr = { id.cpb_ID.ToString(), id.cpl_ID.ToString() };
						string[] arrName = { "cpb_ID", "cpl_ID" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlBook = sw.ToString();
			}

			string InputXmlReturn = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponBottleReturn id in BottleReturnData)
					{
						string[] arr = { id.itmID.ToString(), id.Qty.ToString() };
						string[] arrName = { "itmID", "Qty" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlReturn = sw.ToString();
			}

			string sal_rot_ID = inputParams.sal_rot_ID == null ? "0" : inputParams.sal_rot_ID;
			string sal_cus_ID = inputParams.sal_cus_ID == null ? "0" : inputParams.sal_cus_ID;
			string sal_usr_ID = inputParams.sal_usr_ID == null ? "0" : inputParams.sal_usr_ID;
			string sal_udp_ID = inputParams.sal_udp_ID == null ? "0" : inputParams.sal_udp_ID;
			string sal_cse_ID = inputParams.sal_cse_ID == null ? "0" : inputParams.sal_cse_ID;
			string sal_number = inputParams.sal_number == null ? "0" : inputParams.sal_number;
			string CreatedDate = inputParams.CreatedDate == null ? "0" : inputParams.CreatedDate;
			string sal_SubTotal = inputParams.sal_SubTotal == null ? "0" : inputParams.sal_SubTotal;
			string sal_VAT = inputParams.sal_VAT == null ? "0" : inputParams.sal_VAT;
			string sal_TotalPaidAmount = inputParams.sal_TotalPaidAmount == null ? "0" : inputParams.sal_TotalPaidAmount;
			string CreationMode = inputParams.CreationMode == null ? "0" : inputParams.CreationMode;
			string inv_Discount = inputParams.inv_Discount == null ? "0" : inputParams.inv_Discount;
			string inv_SubTotal_WO_Discount = inputParams.inv_SubTotal_WO_Discount == null ? "0" : inputParams.inv_SubTotal_WO_Discount;
			string CashDepositAmount = inputParams.CashDepositAmount == null ? "0" : inputParams.CashDepositAmount;
			string CashDepositType = inputParams.CashDepositType == null ? "0" : inputParams.CashDepositType;

			var imagePath = string.Empty;
			if (!string.IsNullOrEmpty(inputParams.CashDepositImage))
			{
				//var physicalPath = "E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles";
				var physicalPath = Server.MapPath("../../UploadFiles/Coupon/SalesInvoice");
				if (!Directory.Exists(physicalPath))
				{
					Directory.CreateDirectory(physicalPath);
					dm.TraceService("Directory Created");
				}
				var imageDirectoryPath = physicalPath + "/";
				if (!Directory.Exists(imageDirectoryPath))
				{
					Directory.CreateDirectory(imageDirectoryPath);
					dm.TraceService("Directory for Image Path Created");
				}
				string ImageBase64 = inputParams.CashDepositImage;
				if (!string.IsNullOrEmpty(ImageBase64))
				{
					try
					{
						byte[] imageBytes = Convert.FromBase64String(ImageBase64);
						string dateTimeStamp = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_fff");
						string ext = ".jpg";
						//string imageFileName = DateTime.Now.ToString("HHmmss") + "_Uploaded.jpg";
						string imageFileName = $"{inputParams.sal_rot_ID}_{inputParams.CashDepositType}_{dateTimeStamp}{ext}";

						string imagePathWithName = Path.Combine(imageDirectoryPath, imageFileName);

						using (FileStream fs = new FileStream(imagePathWithName, FileMode.Create))
						{
							fs.Write(imageBytes, 0, imageBytes.Length);
						}
						imagePath = "../UploadFiles/Coupon/SalesInvoice" + imageFileName;
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
			}

			string[] ar = { sal_cus_ID, sal_usr_ID, sal_udp_ID, sal_cse_ID, sal_number, CreatedDate, sal_SubTotal, sal_VAT, sal_TotalPaidAmount ,CreationMode,
				inv_Discount,inv_SubTotal_WO_Discount, InputXmlDetail, InputXmlBook , InputXmlReturn ,CashDepositAmount,CashDepositType,imagePath};
			DataTable dt = dm.loadList("InsSalesInvoice", "sp_CouponCollection", sal_rot_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<SalesInvoiceOut> listHeader = new List<SalesInvoiceOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new SalesInvoiceOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),
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
				dm.TraceService("InsSalesInvoice - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("InsSalesInvoice ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string InsCouponReturnEmptyBottles([FromForm] ReturnEmptyBottlesIn inputParams)
		{
			dm.TraceService("InsCouponReturnEmptyBottles STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostReturnEmptyBottles> CouponReturnData = JsonConvert.DeserializeObject<List<PostReturnEmptyBottles>>(inputParams.CouponReturnEmptyBottles);

			string InputXmlReturn = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostReturnEmptyBottles id in CouponReturnData)
					{
						string[] arr = { id.itmID.ToString(), id.Qty.ToString() };
						string[] arrName = { "itmID", "Qty" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlReturn = sw.ToString();
			}

			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			string usr_ID = inputParams.usr_ID == null ? "0" : inputParams.usr_ID;
			string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
			string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;
			string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

			string[] ar = { udp_ID, usr_ID, cse_ID, cus_ID, InputXmlReturn };
			DataTable dt = dm.loadList("InsCouponReturnEmptyBottles", "sp_CouponCollection", rot_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<ReturnEmptyBottlesOut> listHeader = new List<ReturnEmptyBottlesOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new ReturnEmptyBottlesOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),

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
				dm.TraceService("InsCouponReturnEmptyBottles - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("InsCouponReturnEmptyBottles ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string InsLoadoutEmptyBottles([FromForm] LoadoutEmptyBottlesIn inputParams)
		{
			dm.TraceService("InsLoadoutEmptyBottles STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostLoadoutEmptyBottles> CouponLoadoutData = JsonConvert.DeserializeObject<List<PostLoadoutEmptyBottles>>(inputParams.CouponLoadoutEmptyBottles);

			string InputXmlLoadout = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostLoadoutEmptyBottles id in CouponLoadoutData)
					{
						string[] arr = { id.itmID.ToString(), id.Qty.ToString() };
						string[] arrName = { "itmID", "Qty" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlLoadout = sw.ToString();
			}

			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			string usr_ID = inputParams.usr_ID == null ? "0" : inputParams.usr_ID;
			string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

			string[] ar = { usr_ID, udp_ID, InputXmlLoadout };
			DataTable dt = dm.loadList("InsCouponLoadoutEmptyBottles", "sp_CouponCollection", rot_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<LoadoutEmptyBottlesOut> listHeader = new List<LoadoutEmptyBottlesOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new LoadoutEmptyBottlesOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),
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
				dm.TraceService("InsLoadoutEmptyBottles - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("InsLoadoutEmptyBottles ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string InsLoadTransferEmptyBottles([FromForm] LoadTransferEmptyBottlesIn inputParams)
		{
			dm.TraceService("InsLoadTransferEmptyBottles STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostLoadTransferEmptyBottles> CouponLoadTransferData = JsonConvert.DeserializeObject<List<PostLoadTransferEmptyBottles>>(inputParams.CouponLoadTransferEmptyBottles);

			string InputXmlLoadTransfer = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostLoadTransferEmptyBottles id in CouponLoadTransferData)
					{
						string[] arr = { id.itmID.ToString(), id.Qty.ToString() };
						string[] arrName = { "itmID", "Qty" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlLoadTransfer = sw.ToString();
			}

			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			string usr_ID = inputParams.usr_ID == null ? "0" : inputParams.usr_ID;
			string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

			string[] ar = { usr_ID, udp_ID, InputXmlLoadTransfer };
			DataTable dt = dm.loadList("InsCouponLoadTransferEmptyBottles", "sp_CouponCollection", rot_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<LoadTransferEmptyBottlesOut> listHeader = new List<LoadTransferEmptyBottlesOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new LoadTransferEmptyBottlesOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),
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
				dm.TraceService("InsLoadTransferEmptyBottles - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("InsLoadTransferEmptyBottles ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}

		public string InsCouponSettlement([FromForm] CouponSettlementIn inputParams)
		{
			dm.TraceService("InsCouponSettlement STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostCouponLeaf> CouponLeaf = JsonConvert.DeserializeObject<List<PostCouponLeaf>>(inputParams.CouponLeafData);

			string InputXmlCouponLeaf = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponLeaf id in CouponLeaf)
					{
						string[] arr = { id.cpm_ID.ToString(), id.cpb_ID.ToString(), id.cpl_ID.ToString() };
						string[] arrName = { "cpm_ID", "cpb_ID", "cpl_ID" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlCouponLeaf = sw.ToString();
			}

			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			string usr_ID = inputParams.usr_ID == null ? "0" : inputParams.usr_ID;
			string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

			string[] ar = { usr_ID, udp_ID, InputXmlCouponLeaf };
			DataTable dt = dm.loadList("InsCouponSettlement", "sp_CouponCollection", rot_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<CouponSettlementOut> listHeader = new List<CouponSettlementOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new CouponSettlementOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),
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
				dm.TraceService("InsCouponSettlement - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("InsCouponSettlement ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}
		public string InsCouponLoadIn([FromForm] CouponLoadIn inputParams)

		{
			dm.TraceService("InsCouponLoadIn STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			List<PostCouponLoadData> DetailData = JsonConvert.DeserializeObject<List<PostCouponLoadData>>(inputParams.CouponDetailXML);
			List<PostCouponBookData> BookData = JsonConvert.DeserializeObject<List<PostCouponBookData>>(inputParams.CouponBookXML);
			string InputXmlDetail = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{
					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					foreach (PostCouponLoadData id in DetailData)
					{
						string[] arr = {
							 id.prdID==null?"0":id.prdID,
							 id.Adj_H_UOM==null?"":id.Adj_H_UOM,
							 id.Adj_H_Qty.ToString(),
							 id.Adj_L_UOM==null?"":id.Adj_L_UOM,
							 id.Adj_L_Qty==null?"0":id.Adj_L_Qty,
							 id.LI_H_UOM ==null?"":id.LI_H_UOM,
							 id.LI_H_Qty.ToString(),
							 id.LI_L_UOM ==null?"":id.LI_L_UOM,
							 id.LI_L_Qty ==null?"0":id.LI_L_Qty,
							 id.Final_H_UOM ==null?"":id.Final_H_UOM,
							  id.Final_L_UOM ==null?"":id.Final_L_UOM,
							 id.Final_H_Qty.ToString(),
							 id.Final_L_Qty ==null?"":id.Final_L_Qty,
							 id.lidID==null?"":id.lidID,
							 id.Opn_HUOM==null?"":id.Opn_HUOM,
							 id.Opn_HQty ==null?"":id.Opn_HQty,
							 id.Opn_LUOM ==null?"":id.Opn_LUOM,
							 id.Opn_LQty ==null?"0":id.Opn_LQty,
							 id.HigherPrice ==null?"0":id.HigherPrice,
							 id.LowerPrice ==null?"0":id.LowerPrice
						};
						string[] arrName = {
						"prdID","Adj_H_UOM","Adj_H_Qty","Adj_L_UOM","Adj_L_Qty", "LI_H_UOM","LI_H_Qty","LI_L_UOM","LI_L_Qty","Final_H_UOM","Final_L_UOM","Final_H_Qty","Final_L_Qty","lidID","Opn_HUOM","Opn_HQty","Opn_LUOM","Opn_LQty","HigherPrice","LowerPrice"};
						dm.createNode(arr, arrName, writer);
					}
					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlDetail = sw.ToString();
			}
			string InputXmlBook = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{
					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");

					foreach (PostCouponBookData id in BookData)
					{
						string[] arr = { id.cpb_ID.ToString(), id.cpd_ID.ToString(), id.IsChecked.ToString() };
						string[] arrName = { "cpb_ID", "cpd_ID", "IsChecked" };
						dm.createNode(arr, arrName, writer);
					}
					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlBook = sw.ToString();
			}
			var signPath = string.Empty;
			if (!string.IsNullOrEmpty(inputParams.Signature))
			{
				var physicalPath = "E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles";
				//var physicalPath = Server.MapPath("../../UploadFiles/LoadInSign");
				if (!Directory.Exists(physicalPath))
				{
					Directory.CreateDirectory(physicalPath);
					dm.TraceService("Directory Created");
				}
				var imageDirectoryPath = physicalPath + "/";
				if (!Directory.Exists(imageDirectoryPath))
				{
					Directory.CreateDirectory(imageDirectoryPath);
					dm.TraceService("Directory for Image Path Created");
				}
				string ImageBase64 = inputParams.Signature;
				if (!string.IsNullOrEmpty(ImageBase64))
				{
					try
					{
						byte[] imageBytes = Convert.FromBase64String(ImageBase64);
						string dateTimeStamp = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_fff");
						string ext = ".jpg";
						//string imageFileName = DateTime.Now.ToString("HHmmss") + "_Uploaded.jpg";
						string imageFileName = $"{inputParams.udp_ID}_{inputParams.lih_ID}_{dateTimeStamp}{ext}";

						string imagePathWithName = Path.Combine(imageDirectoryPath, imageFileName);

						using (FileStream fs = new FileStream(imagePathWithName, FileMode.Create))
						{
							fs.Write(imageBytes, 0, imageBytes.Length);
						}
						signPath = "../UploadFiles/LoadInSign/" + imageFileName;
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
			}
			string user_Id = inputParams.UserID == null ? "" : inputParams.UserID;
			//string lih_ID = inputParams.lih_ID == null ? "0" : inputParams.lih_ID;
			string lih_ID = inputParams.lih_ID == null ? "0" : inputParams.lih_ID;
			string emp_ID = inputParams.emp_ID == null ? "0" : inputParams.emp_ID;
			string Status = inputParams.Status == null ? "" : inputParams.Status;
			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
			string Remarks = inputParams.Remarks == null ? "" : inputParams.Remarks;

			string[] param = { lih_ID.ToString(), emp_ID.ToString(), Status , rot_ID.ToString() , udp_ID.ToString() , Remarks,
							 InputXmlDetail , InputXmlBook,signPath};
			DataTable dt = dm.loadList("InsCouponLoadIn", "sp_CouponCollection", user_Id, param);
			string JSONString;
			try
			{
				if (dt.Rows.Count > 0)
				{
					List<CouponLoadOut> listHeader = new List<CouponLoadOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new CouponLoadOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString()
						});
					}
					JSONString = JsonConvert.SerializeObject(new
					{
						result = listHeader
					});
				}
				else
				{
					dm.TraceService("NoDataRes");
					JSONString = "NoDataRes";
				}
			}
			catch (Exception ex)
			{
				dm.TraceService("InsLoadIn - Error: " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}
			dm.TraceService("InsCouponLoadIn ENDED");
			dm.TraceService("======================================");
			return JSONString;
		}
		public string GetReturnPendingData([FromForm] ReturnInput inputParams)
		{

			dm.TraceService("SelectCouponCollectionHeader STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
			DataTable dt = dm.loadList("SelCouponReturnPending", "sp_CouponCollection", rot_ID);
			try
			{
				if (dt.Rows.Count > 0)
				{
					List<CouponReturnPending> listDetails = new List<CouponReturnPending>();
					foreach (DataRow dr in dt.Rows)
					{
						listDetails.Add(new CouponReturnPending
						{
							CusId = dr["cus_ID"].ToString(),
							CusCode = dr["cus_Code"].ToString(),
							CusName = dr["cus_Name"].ToString(),
							PrdId = dr["prd_ID"].ToString(),
							PrdCode = dr["prd_Code"].ToString(),
							PrdName = dr["prd_Name"].ToString(),
							TotalSalesQty = dr["TotalSalesQty"].ToString(),
							TotalReturnQty = dr["TotalReturnQty"].ToString(),
							NetSalesQty = dr["NetSalesQty"].ToString(),
						});
					}
					JSONString = JsonConvert.SerializeObject(new
					{
						result = listDetails
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
				dm.TraceService("SelectCouponCollectionHeader - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}
			dm.TraceService("SelectCouponCollectionHeader ENDED ");
			dm.TraceService("======================================");
			return JSONString;
		}
		public string UpdateCouponCollection([FromForm] UpdateCouponIn inputParams)
		{
			dm.TraceService("ConfirmCouponCollection STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			List<PostCouponData> DetailData = JsonConvert.DeserializeObject<List<PostCouponData>>(inputParams.CouponDetailXML);
			List<PostCouponBookData> BookData = JsonConvert.DeserializeObject<List<PostCouponBookData>>(inputParams.CouponBookXML);

			string InputXmlDetail = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponData id in DetailData)
					{
						string[] arr = { id.cpd_ID.ToString(), id.cpd_HigherQty.ToString(), id.cpd_AdjHigherQty.ToString(), id.cpd_FinalHigherQty.ToString() };
						string[] arrName = { "cpd_ID", "cpd_HigherQty", "cpd_AdjHigherQty", "cpd_FinalHigherQty" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlDetail = sw.ToString();
			}

			string InputXmlBook = "";
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw))
				{

					writer.WriteStartDocument(true);
					writer.WriteStartElement("r");
					int c = 0;
					foreach (PostCouponBookData id in BookData)
					{
						string[] arr = { id.cpb_ID.ToString(), id.cpd_ID.ToString(), id.IsChecked.ToString() };
						string[] arrName = { "cpb_ID", "cpd_ID", "IsChecked" };
						dm.createNode(arr, arrName, writer);
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
				InputXmlBook = sw.ToString();
			}

			string cpd_cph_ID = inputParams.cpd_cph_ID == null ? "0" : inputParams.cpd_cph_ID;
			string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
			string emp_ID = inputParams.emp_ID == null ? "0" : inputParams.emp_ID;
			string Status = inputParams.Status == null ? "" : inputParams.Status;

			string[] ar = { InputXmlDetail, InputXmlBook, UserID, emp_ID, Status };
			DataTable dt = dm.loadList("UpdateCouponAppoval", "sp_CouponCollection", cpd_cph_ID, ar);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<ConfirmCouponOut> listHeader = new List<ConfirmCouponOut>();
					foreach (DataRow dr in dt.Rows)
					{
						listHeader.Add(new ConfirmCouponOut
						{
							Res = dr["Res"].ToString(),
							Title = dr["Title"].ToString(),
							Descr = dr["Descr"].ToString(),

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
				dm.TraceService("ConfirmCouponCollection - Error :   " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("ConfirmCouponCollection ENDED ");
			dm.TraceService("======================================");

			return JSONString;
		}
		public string PostEmptyBottleApproval([FromForm] PostReturnEmptyBottleReqData inputParams)
		{
			dm.TraceService("PostReturnEmptyBottleRequestApproval STARTED " + DateTime.Now.ToString());
			dm.TraceService("============================================");
			try
			{
				List<PostReturnEmptyBottleApprovalDetData> itemData = JsonConvert.DeserializeObject<List<PostReturnEmptyBottleApprovalDetData>>(inputParams.JSONString);
				try
				{

					string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
					string CusId = inputParams.CusId == null ? "0" : inputParams.CusId;
					string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
					//string Status = inputParams.Status == null ? "" : inputParams.Status;
					string InputXml = "";
					using (var sw = new StringWriter())
					{
						using (var writer = XmlWriter.Create(sw))
						{
							writer.WriteStartDocument(true);
							writer.WriteStartElement("r");
							foreach (PostReturnEmptyBottleApprovalDetData id in itemData)
							{
								string[] arr = { id.prdID.ToString(), id.RtnQty.ToString(), id.ColQty.ToString() };
								string[] arrName = { "prdID", "RtnQty", "ColQty" };
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
						string[] arr = { CusId.ToString(), RotId.ToString(), InputXml.ToString() };
						DataTable dt = dm.loadList("ReturnEmptyBottleApproval", "sp_CouponCollection", userID.ToString(), arr);

						List<GetEmptyBottleReturnApprovalStatus> listStatus = new List<GetEmptyBottleReturnApprovalStatus>();
						if (dt.Rows.Count > 0)
						{
							List<GetEmptyBottleReturnApprovalStatus> listHeader = new List<GetEmptyBottleReturnApprovalStatus>();
							foreach (DataRow dr in dt.Rows)
							{
								listHeader.Add(new GetEmptyBottleReturnApprovalStatus
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
			dm.TraceService("PostReturnEmptyBottleRequestApproval ENDED " + DateTime.Now.ToString());
			dm.TraceService("========================================");
			return JSONString;
		}
		public string GetEmptyBottleApproveHeaderStatus([FromForm] GetEmptyBottleApprHeaderStatus inputParams)
		{
			dm.TraceService("GetCouponApprovalheaderStatus STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			string cusId = inputParams.CusId == null ? "0" : inputParams.CusId;
			string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
			string ReturnId = inputParams.ReturnId == null ? "0" : inputParams.ReturnId;

			string[] arr = { RotId.ToString(), ReturnId.ToString() };
			DataTable dtStatus = dm.loadList("SelStatusForEmptyBottleHeaderApproval", "sp_CouponCollection", cusId.ToString(), arr);

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
				dm.TraceService("GetCouponApprovalheaderStatus  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetCouponApprovalheaderStatus ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}
		public string GetEmptyBottleDetApprovalStatus([FromForm] GetEmptyBottleApprHeaderStatus inputParams)
		{
			dm.TraceService("GetCouponApprovalDetStatus STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			string cusId = inputParams.CusId == null ? "0" : inputParams.CusId;
			string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
			string ReturnId = inputParams.ReturnId == null ? "0" : inputParams.ReturnId;
			string[] arr = { RotId.ToString(), ReturnId.ToString() };
			DataTable dtReturnStatus = dm.loadList("SelStatusForEmptyBottleDetApproval", "sp_CouponCollection", cusId.ToString(), arr);

			try
			{
				if (dtReturnStatus.Rows.Count > 0)
				{
					List<GetDetBottleApprovalStatus> listHeader = new List<GetDetBottleApprovalStatus>();
					foreach (DataRow dr in dtReturnStatus.Rows)
					{
						listHeader.Add(new GetDetBottleApprovalStatus
						{
							ApprovalStatus = dr["Status"].ToString(),
							ProductId = dr["cda_prd_ID"].ToString(),
							ReasonID = dr["cda_rsn_ID"].ToString(),

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

			dm.TraceService("GetCouponApprovalDetStatus ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		public string CouponMasterDetails()
		{
			dm.TraceService("GetCouponMasterSelect STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			// Load the result sets from the stored procedure
			DataSet ds = dm.loadListDS("CouponMasterDetails", "sp_CouponCollection");
		
			try
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					List<GetCouponMaster> listDetail = new List<GetCouponMaster>();
					DataTable dtMasterDet = ds.Tables[0];  // First result set (Master data)
					DataTable dtItemDetails = ds.Tables[1];  // Second result set (Item details)

					foreach (DataRow dr in dtMasterDet.Rows)
					{
						string cpmID = dr["cpm_ID"].ToString();

						// Filter item details based on cpm_ID
						var itemDetails = dtItemDetails.AsEnumerable()
							.Where(row => row.Field<int>("cpt_cpm_ID").ToString() == cpmID)
							.Select(row => new CouponItemList
							{
								cpt_prd_ID = row["cpt_prd_ID"].ToString(),
								cpt_cpm_ID = row["cpt_cpm_ID"].ToString(),
								prd_Code = row["prd_Code"].ToString(),
								prd_Name = row["prd_Name"].ToString(),
								pru_Price = row["pru_Price"].ToString()
							}).ToList();

						// Add the master record along with the filtered item details
						listDetail.Add(new GetCouponMaster
						{
							cpm_ID = dr["cpm_ID"].ToString(),
							cpm_Code = dr["cpm_Code"].ToString(),
							cpm_Name = dr["cpm_Name"].ToString(),
							cpm_NoOfLeaf = dr["cpm_NoOfLeaf"].ToString(),
							cpm_Price= dr["cpm_Price"].ToString(),
							ItemDet = itemDetails,
						});
					}

					JSONString = JsonConvert.SerializeObject(new
					{
						result = listDetail
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

			dm.TraceService("GetCouponMasterSelect ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

	}

}

