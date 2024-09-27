using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_API.Controllers
{
	public class GoodsReceivingController : Controller
	{
		// GET: GRN 


		DataModel dm = new DataModel();
		string JSONString = string.Empty;

		public string GetUnAssigned(GoodsReceivingIn Gr)
		{
			dm.TraceService("GetUnAssigned STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelUnAssigned", "sp_GoodsReceivingWS", Gr.grh_usr_ID);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<GoodsReceivingOut> list = new List<GoodsReceivingOut>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new GoodsReceivingOut
						{
							grh_ID = dr["grh_ID"].ToString(),
							grh_trn_number = dr["grh_trn_number"].ToString(),
							str_Name = dr["str_Name"].ToString(),
							grh_exp_Date = dr["grh_exp_Date"].ToString(),
							Status = dr["Status"].ToString(),
                            ReceivedBy = dr["ReceivedBy"].ToString(),
                            ArReceivedBy = dr["ArReceivedBy"].ToString(),
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
				dm.TraceService("GetUnAssigned  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetUnAssigned ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}
		public string GetAssigned(GoodsReceivingIn Gr)
		{
			dm.TraceService("GetAssigned STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelAssigned", "sp_GoodsReceivingWS", Gr.grh_usr_ID);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<GoodsReceivingOut> list = new List<GoodsReceivingOut>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new GoodsReceivingOut
						{
							grh_ID = dr["grh_ID"].ToString(),
							grh_trn_number = dr["grh_trn_number"].ToString(),
							str_Name = dr["str_Name"].ToString(),
							grh_exp_Date = dr["grh_exp_Date"].ToString(),
							Status = dr["Status"].ToString(),
                            ReceivedBy = dr["usr_Name"].ToString(),
                            ArReceivedBy = dr["usr_ArabicName"].ToString(),
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
				dm.TraceService("GetAssigned  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetAssigned ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}

		//public string GetAssignedDetail(AssignedDetailIn ai)
		//{
		//	dm.TraceService("GetAssignedDetail STARTED " + DateTime.Now.ToString());
		//	dm.TraceService("======================================");

		//	DataTable dt = dm.loadList("SelAssignedDetail", "sp_GoodsReceivingWS", ai.grd_grh_ID);

		//	try
		//	{
		//		if (dt.Rows.Count > 0)
		//		{
		//			List<AssignedDetailOut> list = new List<AssignedDetailOut>();
		//			foreach (DataRow dr in dt.Rows)
		//			{
		//				list.Add(new AssignedDetailOut
		//				{
		//					grd_ID = dr["grd_ID"].ToString(),
		//					grh_trn_number = dr["grh_trn_number"].ToString(),
		//					prd_Code = dr["prd_Code"].ToString(),
		//					prd_Name = dr["prd_Name"].ToString(),
		//					grd_Exp_HQty = dr["grd_Exp_HQty"].ToString(),
		//					grd_Exp_LQty = dr["grd_Exp_LQty"].ToString(),
		//					grd_prd_HUom = dr["Higher_UOM"].ToString(),
		//					grd_prd_LUom = dr["Lower_UOM"].ToString(),

		//				});
		//			}
		//			JSONString = JsonConvert.SerializeObject(new
		//			{
		//				result = list
		//			});

		//			return JSONString;
		//		}
		//		else
		//		{
		//			dm.TraceService("NoDataRes");
		//			JSONString = "NoDataRes";
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		dm.TraceService("GetAssignedDetail  " + ex.Message.ToString());
		//		JSONString = "NoDataSQL - " + ex.Message.ToString();
		//	}

		//	dm.TraceService("GetAssignedDetail ENDED " + DateTime.Now.ToString());
		//	dm.TraceService("======================================");

		//	return JSONString;
		//}
		public string StartGrnReceiving(StartGrnReceiving sgr)
		{
			dm.TraceService("StartGrnReceiving STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");
			string[] arr = { sgr.usrid };
			DataTable dt = dm.loadList("SelStartGrnReceiving", "sp_GoodsReceivingWS", sgr.grh_ID,arr);
			try
			{
				if (dt.Rows.Count > 0)
				{
					string Mode = dt.Rows[0]["res"].ToString();
					string Title = dt.Rows[0]["Title"].ToString();
					string Descr = dt.Rows[0]["Descr"].ToString();
					dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
					List<GrnReceivingStatus> listStatus = new List<GrnReceivingStatus>();
					listStatus.Add(new GrnReceivingStatus
					{
						Res = Mode,
						Title = Title,
						Descr = Descr
					});
					string JSONString = JsonConvert.SerializeObject(new
					{
						result = listStatus
					});
					return JSONString;
				}
			}
			catch (Exception ex)
			{
				dm.TraceService("StartGrnReceiving  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("StartGrnReceiving ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}
        public string GetAssignedDetail([FromForm] PostGRNData inputParams)
        {
            dm.TraceService("GetGRNItemBatch STARTED ");
            dm.TraceService("====================");
            try
            {
                string grh_ID = inputParams.grh_ID == null ? "0" : inputParams.grh_ID;
                string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

                string[] arr = { userID.ToString() };
                DataSet dtGrnItemBatch = dm.loadListDS("SelGrnItemBatch", "sp_GoodsReceivingWS", grh_ID.ToString(), arr);
                DataTable itemData = dtGrnItemBatch.Tables[0];
                DataTable batchData = dtGrnItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<GetGrnItemHeader> listItems = new List<GetGrnItemHeader>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<GetGrnBatchSerial> listBatchSerial = new List<GetGrnBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["prd_Code"].ToString() == drDetails["prd_Code"].ToString() && dr["grd_ID"].ToString() == drDetails["bch_grd_ID"].ToString())
                            {
                                listBatchSerial.Add(new GetGrnBatchSerial
                                {
                                    Number = drDetails["bch_Num"].ToString(),
                                    ExpiryDate = drDetails["bch_Exp_Date"].ToString(),
                                    BaseUOM = drDetails["bch_BaseUOM"].ToString(),
                                    bch_Qty = drDetails["bch_Qty"].ToString(),
                                    //PickedQty = drDetails["bch_Picked_Qty"].ToString(),
                                    ItemCode = drDetails["prd_Code"].ToString(),
                                    ReasonId = drDetails["bch_ReasonID"].ToString(),
                                    BatchID = drDetails["bch_ID"].ToString(),
                                    grd_ID = drDetails["bch_grd_ID"].ToString()
                                });
                            }
                        }

                        listItems.Add(new GetGrnItemHeader
                        {
                            Id = Int32.Parse(dr["prd_ID"].ToString()),
                            Name = dr["prd_Name"].ToString(),
                            Code = dr["prd_Code"].ToString(),
                            Spec = dr["prd_Spec"].ToString(),
                            Desc = dr["prd_Description"].ToString(),
                            CategoryId = dr["prd_cat_ID"].ToString(),
                            SubcategoryId = dr["prd_sct_ID"].ToString(),
                            Weighing = dr["prd_WeighingItem"].ToString(),
                            Exp_HUom = dr["grd_Exp_HUom"].ToString(),
                            Exp_LUom = dr["grd_Exp_LUom"].ToString(),
                            ExpHQty = dr["grd_Exp_HQty"].ToString(),
                            ExpLQty = dr["grd_Exp_LQty"].ToString(),
                            ReceivedHQty = dr["grd_Received_HQty"].ToString(),
                            ReceivedLQty = dr["grd_Received_LQty"].ToString(),
                            ReceivedHUom = dr["grd_Received_HUom"].ToString(),
                            ReceivedLUom = dr["grd_Received_LUom"].ToString(),
                            ReasonID = dr["grd_rsn_ID"].ToString(),
                            grd_ID = dr["grd_ID"].ToString(),
                            LineNo = dr["grd_LineNo"].ToString(),
                            BatchSerial = listBatchSerial,
                            CatCode = dr["cat_Code"].ToString(),
                            CatName = dr["cat_Name"].ToString(),
                            SubCatCode = dr["sct_Code"].ToString(),
                            SubCatName = dr["sct_Name"].ToString(),
                            BrdID = dr["brd_ID"].ToString(),
                            BrdCode = dr["brd_Code"].ToString(),
                            BrdName = dr["brd_Name"].ToString(),
                            ArName = dr["prd_NameArabic"].ToString(),
                            ArDesc = dr["prd_ArabicItemLongDesc"].ToString(),
                            ArCatName = dr["cat_NameArabic"].ToString(),
                            ArSubCatName = dr["sct_NameArabic"].ToString(),
                            ArBrdName = dr["brd_NameArabic"].ToString()






                            //dr["grd_Received_LUom"].ToString(),

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

            dm.TraceService("GetGRNItemBatch ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }

        public string CompleteGrnReceiving([FromForm] PostCompleteGRN inputParams)
        {
            dm.TraceService("CompleteGrnReceiving STARTED ");
            dm.TraceService("===================");
            try
            {
                List<PostGRNItemData> itemData = JsonConvert.DeserializeObject<List<PostGRNItemData>>(inputParams.ItemData);
                List<PostGRNBatchData> batchData = JsonConvert.DeserializeObject<List<PostGRNBatchData>>(inputParams.BatchData);

                try
                {
                    string GrnId = inputParams.GrnId == null ? "0" : inputParams.GrnId;
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string status = inputParams.Status == null ? "0" : inputParams.Status;

                    DataSet dsItemBatch = new DataSet();

                    DataTable dtItem = new DataTable();
                    dtItem.Columns.Add("ProductId", typeof(int));
                    dtItem.Columns.Add("ProductHUOM", typeof(string));
                    dtItem.Columns.Add("ProductLUOM", typeof(string));
                    dtItem.Columns.Add("ProductHQty", typeof(string));
                    dtItem.Columns.Add("ProductLQty", typeof(string));
                    dtItem.Columns.Add("ReasonId", typeof(string));
                    //dtItem.Columns.Add("UserId", typeof(string));
                    //dtItem.Columns.Add("ModifiedOn", typeof(string));
                    dtItem.Columns.Add("LineNumber", typeof(string));


                    DataTable dtBatch = new DataTable();
                    dtBatch.Columns.Add("ProductId", typeof(int));
                    dtBatch.Columns.Add("Number", typeof(string));
                    dtBatch.Columns.Add("ReceivedQty", typeof(string));
                    dtBatch.Columns.Add("ReasonId", typeof(string));
                    dtBatch.Columns.Add("BatchMode", typeof(string));
                    dtBatch.Columns.Add("ExpiryDate", typeof(string));
                    //dtBatch.Columns.Add("UserId", typeof(string));
                    //dtBatch.Columns.Add("ModifiedOn", typeof(string));
                    dtBatch.Columns.Add("BatchLineNo", typeof(string));
                    dtBatch.Columns.Add("grd_ID", typeof(string));
                    dtBatch.Columns.Add("BaseUOM", typeof(string));

                    foreach (var item in itemData)
                    {
                        dtItem.Rows.Add(item.ProductId, item.ProductHUOM, item.ProductLUOM, item.ProductHQty, item.ProductLQty, item.ReasonId, item.LineNumber);
                    }

                    foreach (var batch in batchData)
                    {
                        dtBatch.Rows.Add(batch.ProductId, batch.Number, batch.receivedQty, batch.ReasonId, batch.BatchMode, batch.ExpiryDate, batch.BatchLineNo, batch.grd_ID, batch.BaseUOM);
                    }

                    dsItemBatch.Tables.Add(dtItem);
                    dsItemBatch.Tables.Add(dtBatch);

                    try
                    {
                        string[] keys = { "@GRNId", "@UserId", "@Status" };
                        string[] values = { GrnId.ToString(), userID.ToString(), status.ToString() };
                        string[] arr = { "@ItemData", "@BatchData" };
                        DataSet Value = dm.bulkUpdate(dsItemBatch, arr, keys, values, "sp_CompleteGrnReceiving");
                        foreach (DataTable table in Value.Tables)
                        {
                            string Mode = table.Rows[0]["res"].ToString();
                            string Status = table.Rows[0]["status"].ToString();
                            dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Status=" + Status);
                            List<GetInsertStatus> listStatus = new List<GetInsertStatus>();
                            listStatus.Add(new GetInsertStatus
                            {
                                Mode = Mode,
                                Status = Status
                            });
                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listStatus
                            });
                            return JSONString;
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

            dm.TraceService("CompleteGrnReceiving ENDED ");
            dm.TraceService("=================");

            return JSONString;
        }
        public string GRNSelfAssign([FromForm] GRNSelfAssignHeader inputParams)
		{
			dm.TraceService("GRNSelfAssign STARTED ");
			dm.TraceService("===================");
			try
			{
				List<GRNSelfAssignDetail> jsonValue = JsonConvert.DeserializeObject<List<GRNSelfAssignDetail>>(inputParams.jsonValue);

				try
				{
					string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

					DataSet dsGRNSelfAssignDetail = new DataSet();

					DataTable dtGRNSelfAssignHeader = new DataTable();
					dtGRNSelfAssignHeader.Columns.Add("grh_ID", typeof(string));

					foreach (var item in jsonValue)
					{
						dtGRNSelfAssignHeader.Rows.Add(item.grh_ID);
					}

					dsGRNSelfAssignDetail.Tables.Add(dtGRNSelfAssignHeader);

					try
					{
						string[] keys = { "@UserID" };
						string[] values = { UserID.ToString() };
						string[] arr = { "@GrhID" };
						DataSet Value = dm.bulkUpdate(dsGRNSelfAssignDetail, arr, keys, values, "sp_GRNSelfAssign");
						foreach (DataTable table in Value.Tables)
						{
							string Mode = table.Rows[0]["res"].ToString();
							string Title = table.Rows[0]["Title"].ToString();
							string Descr = table.Rows[0]["Descr"].ToString();
							dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
							List<GrnReceivingStatus> listStatus = new List<GrnReceivingStatus>();
							listStatus.Add(new GrnReceivingStatus
							{
								Res = Mode,
								Title = Title,
								Descr = Descr
							});
							string JSONString = JsonConvert.SerializeObject(new
							{
								result = listStatus
							});
							return JSONString;
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

			dm.TraceService("GRNSelfAssign ENDED ");
			dm.TraceService("=================");

			return JSONString;
		}
		public string GRNBatchUpdate([FromForm] GRNBatchUpdateHeader inputParams)
		{
			dm.TraceService("GRNBatchUpdate STARTED ");
			dm.TraceService("===================");
			try
			{
				List<GRNBatchUpdateDetail> jsonValue = JsonConvert.DeserializeObject<List<GRNBatchUpdateDetail>>(inputParams.jsonValue);

				try
				{
					string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

					DataSet dsBatchUpdateHeader = new DataSet();

					DataTable dtBatchUpdateHeader = new DataTable();
					dtBatchUpdateHeader.Columns.Add("bch_ID", typeof(string));
					dtBatchUpdateHeader.Columns.Add("bch_Received_Qty", typeof(string));
					dtBatchUpdateHeader.Columns.Add("bch_ReasonID", typeof(string));


					foreach (var item in jsonValue)
					{
						dtBatchUpdateHeader.Rows.Add(item.bch_ID, item.bch_Received_Qty, item.bch_ReasonID);

					}

					dsBatchUpdateHeader.Tables.Add(dtBatchUpdateHeader);

					try
					{
						string[] keys = { "@UserID" };
						string[] values = { UserID.ToString() };
						string[] arr = { "@GRNBatchId" };
						DataSet Value = dm.bulkUpdate(dsBatchUpdateHeader, arr, keys, values, "sp_GRNBatchUpdate");
						foreach (DataTable table in Value.Tables)
						{
							string Mode = table.Rows[0]["res"].ToString();
							string Title = table.Rows[0]["Title"].ToString();
							string Descr = table.Rows[0]["Descr"].ToString();
							dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
							List<WTReceivingStatus> listStatus = new List<WTReceivingStatus>();
							listStatus.Add(new WTReceivingStatus
							{
								Res = Mode,
								Title = Title,
								Descr = Descr
							});
							string JSONString = JsonConvert.SerializeObject(new
							{
								result = listStatus
							});
							return JSONString;
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

			dm.TraceService("GRNBatchUpdate ENDED ");
			dm.TraceService("=================");

			return JSONString;
		}
		public string GetGRNOngoing([FromForm] PostGRNData inputParams)
		{
			try
			{
				string UserID = inputParams.UserId == null ? "0" : inputParams.UserId;
				dm.TraceService("==========GetGRNOngoing Started==========");
				string[] arr = { };
				DataTable CI = dm.loadList("SelectReceiveOngoing", "sp_GoodsReceivingWS", UserID.ToString());
				dm.TraceService("==========Query Executed==========");
				if (CI.Rows.Count > 0)
				{
					dm.TraceService("==========Row Count Greated Than 0==========");
					List<GetGRNOngoingHeader> listItems = new List<GetGRNOngoingHeader>();
					foreach (DataRow dr in CI.Rows)
					{

						listItems.Add(new GetGRNOngoingHeader
						{
							grh_ID = dr["grh_ID"].ToString(),
							grh_trn_number = dr["grh_trn_number"].ToString(),
							UserID = dr["grh_usr_ID"].ToString(),
							Status = dr["Status"].ToString(),
							str_ID = dr["grh_str_ID"].ToString(),
							str_Name = dr["str_Name"].ToString(),
							Date = dr["Date"].ToString()
						});
					}

					string JSONString = JsonConvert.SerializeObject(new
					{
						result = listItems
					});
					dm.TraceService("==========JSONString Generated " + JSONString + "==========");
					return JSONString;
				}
				else
				{
					dm.TraceService("==========Row Count Equal To 0==========");
					JSONString = "NoDataRes";
				}
			}
			catch (Exception ex)
			{
				dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
				JSONString = "NoDataSQL";
			}
			dm.TraceService("==========GetGRNOngoing End==========");
			return JSONString;
		}
	}
	  
}