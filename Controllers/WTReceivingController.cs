using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class WTReceivingController : Controller
    {
		// GET: WTReceiving
		DataModel dm = new DataModel();
		string JSONString = string.Empty;

		public string GetUnAssigned(WTReceivingIn wr)
		{
			dm.TraceService("GetUnAssigned STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelUnAssigned", "sp_WT_ReceivingWS", wr.wrh_usr_ID);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<WTReceivingOut> list = new List<WTReceivingOut>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new WTReceivingOut
						{
							wrh_ID = dr["wrh_ID"].ToString(),
							wrh_trn_number = dr["wrh_trn_number"].ToString(),
							war_Name = dr["war_Name"].ToString(),
                            wrh_exp_Date = dr["wrh_exp_Date"].ToString(),
                            Status = dr["Status"].ToString(),
                            mrh_Number = dr["mrh_Number"].ToString(),
                            WTPick_number=dr["wph_number"].ToString(),
                            WTTransOut_number=dr["wtt_number"].ToString(),
                            WTTransIn_number= dr["wti_number"].ToString(),
                            PickedBy = dr["PickedBy"].ToString(),
                            Arwar_Name = dr["war_ArabicName"].ToString(),
                            ArPickedBy = dr["ArPickedBy"].ToString()

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
		public string GetAssigned(WTReceivingIn wr)
		{
			dm.TraceService("GetAssigned STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelAssigned", "sp_WT_ReceivingWS", wr.wrh_usr_ID);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<WTReceivingOut> list = new List<WTReceivingOut>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new WTReceivingOut
						{
							wrh_ID = dr["wrh_ID"].ToString(),
							wrh_trn_number = dr["wrh_trn_number"].ToString(),
							war_Name = dr["war_Name"].ToString(),
							wrh_exp_Date = dr["wrh_exp_Date"].ToString(),
                            Status = dr["Status"].ToString(),
                            mrh_Number= dr["mrh_Number"].ToString(),
                            WTPick_number = dr["wph_number"].ToString(),
                            WTTransOut_number = dr["wtt_number"].ToString(),
                            WTTransIn_number = dr["wti_number"].ToString(),
							Arwar_Name = dr["war_ArabicName"].ToString(),

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
		public string GetAssignedDetail(WTRAssignedDetailIn ai)
		{
			dm.TraceService("GetAssignedDetail STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelAssignedDetail", "sp_WT_ReceivingWS", ai.wrd_wrh_ID);

			try
			{
				if (dt.Rows.Count > 0)
				{
					List<WTRAssignedDetailOut> list = new List<WTRAssignedDetailOut>();
					foreach (DataRow dr in dt.Rows)
					{
						list.Add(new WTRAssignedDetailOut
						{
							wrd_ID = dr["wrd_ID"].ToString(),
							wrh_trn_number = dr["wrh_trn_number"].ToString(),
							prd_Code = dr["prd_Code"].ToString(),
							prd_Name = dr["prd_Name"].ToString(),
							wrd_Picked_HQty = dr["wrd_Picked_HQty"].ToString(),
							wrd_Picked_LQty = dr["wrd_Picked_LQty"].ToString(),
							Higher_UOM = dr["Higher_UOM"].ToString(),
							Lower_UOM = dr["Lower_UOM"].ToString()

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
				dm.TraceService("GetAssignedDetail  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("GetAssignedDetail ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}
		public string StartWTReceiving(StartWTReceiving swr)
		{
			dm.TraceService("StartWTReceiving STARTED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			DataTable dt = dm.loadList("SelStartWTReceiving", "sp_WT_ReceivingWS", swr.wrh_ID);
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
				dm.TraceService("StartWTReceiving  " + ex.Message.ToString());
				JSONString = "NoDataSQL - " + ex.Message.ToString();
			}

			dm.TraceService("StartWTReceiving ENDED " + DateTime.Now.ToString());
			dm.TraceService("======================================");

			return JSONString;
		}
        public string CompleteWTReceiving([FromForm] PostWTCompleteGRN inputParams)
        {
            dm.TraceService("CompleteGrnReceiving STARTED ");
            dm.TraceService("===================");
            try
            {
                List<PostWTGRNItemData> itemData = JsonConvert.DeserializeObject<List<PostWTGRNItemData>>(inputParams.ItemData);
                List<PostWTGRNBatchData> batchData = JsonConvert.DeserializeObject<List<PostWTGRNBatchData>>(inputParams.BatchData);

                try
                {
                    string WRHId = inputParams.WRHId == null ? "0" : inputParams.WRHId;
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
                    dtBatch.Columns.Add("wrd_ID", typeof(string));
                    dtBatch.Columns.Add("BaseUOM", typeof(string));
                    dtBatch.Columns.Add("SerialFlag", typeof(string));

                    foreach (var item in itemData)
                    {
                        dtItem.Rows.Add(item.ProductId, item.ProductHUOM, item.ProductLUOM, item.ProductHQty, item.ProductLQty, item.ReasonId, item.LineNumber);
                    }

                    foreach (var batch in batchData)
                    {
                        dtBatch.Rows.Add(batch.ProductId, batch.Number, batch.receivedQty, batch.ReasonId, batch.BatchMode, batch.ExpiryDate, batch.BatchLineNo, batch.wrd_ID, batch.BaseUOM, batch.SerialFlag);
                    }

                    dsItemBatch.Tables.Add(dtItem);
                    dsItemBatch.Tables.Add(dtBatch);

                    try
                    {
                        string[] keys = { "@WRHId", "@UserId", "@Status" };
                        string[] values = { WRHId.ToString(), userID.ToString(), status.ToString() };
                        string[] arr = { "@ItemData", "@BatchData" };
                        DataSet Value = dm.bulkUpdate(dsItemBatch, arr, keys, values, "sp_WTReceivingComplete");
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
      
		public string WTReceivingSelfAssign([FromForm] WTReceivingSelfAssignHeader inputParams)
		{
			dm.TraceService("WTReceivingSelfAssign STARTED ");
			dm.TraceService("===================");
			try
			{
				List<WTReceivingSelfAssignDetail> jsonValue = JsonConvert.DeserializeObject<List<WTReceivingSelfAssignDetail>>(inputParams.jsonValue);

				try
				{
					string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

					DataSet dsWTReceivingSelfAssignDetail = new DataSet();

					DataTable dtWTReceivingSelfAssignDetail = new DataTable();
					dtWTReceivingSelfAssignDetail.Columns.Add("wrh_ID", typeof(string));

					foreach (var item in jsonValue)
					{
						dtWTReceivingSelfAssignDetail.Rows.Add(item.wrh_ID);
					}

					dsWTReceivingSelfAssignDetail.Tables.Add(dtWTReceivingSelfAssignDetail);

					try
					{
						string[] keys = { "@UserID" };
						string[] values = { UserID.ToString() };
						string[] arr = { "@WrhID" };
						DataSet Value = dm.bulkUpdate(dsWTReceivingSelfAssignDetail, arr, keys, values, "sp_WTReceivingSelfAssign");
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

			dm.TraceService("WTReceivingSelfAssign ENDED ");
			dm.TraceService("=================");

			return JSONString;
		}
        public string GetWTReceivingItemBatch([FromForm] PostWTReceivingData inputParams)
        {
            dm.TraceService("GetWTReceivingItemBatch STARTED ");
            dm.TraceService("====================");
            try
            {
                string wrh_ID = inputParams.wrh_ID == null ? "0" : inputParams.wrh_ID;
                string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

                string[] arr = { userID.ToString() };
                DataSet dtWTRItemBatch = dm.loadListDS("SelWTReceivingItemBatch", "sp_WT_ReceivingWS", wrh_ID.ToString(), arr);
                DataTable itemData = dtWTRItemBatch.Tables[0];
                DataTable batchData = dtWTRItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<GetWTReceivingItemHeader> listItems = new List<GetWTReceivingItemHeader>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<GetWTReceivingBatchSerial> listBatchSerial = new List<GetWTReceivingBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["prd_Code"].ToString() == drDetails["prd_Code"].ToString() && dr["wrd_ID"].ToString() == drDetails["bch_wrd_ID"].ToString())
                            {
                                listBatchSerial.Add(new GetWTReceivingBatchSerial
                                {
                                    Number = drDetails["bch_Num"].ToString(),
                                    ExpiryDate = drDetails["bch_Exp_Date"].ToString(),
                                    BaseUOM = drDetails["bch_BaseUOM"].ToString(),
                                    ReceivedQty = drDetails["bch_ReceivedQty"].ToString(),
                                    PickedQty = drDetails["bch_PickedQty"].ToString(),
                                    ItemCode = drDetails["prd_Code"].ToString(),
                                    ReasonId = drDetails["bch_Reason_ID"].ToString(),
                                    BatchID = drDetails["bch_ID"].ToString(),
                                    wrd_ID = drDetails["bch_wrd_ID"].ToString(),
                                    SerialFlag = drDetails["bch_SerialFlag"].ToString()
                                });
                            }
                        }

                        listItems.Add(new GetWTReceivingItemHeader
                        {
                            Id = Int32.Parse(dr["prd_ID"].ToString()),
                            Name = dr["prd_Name"].ToString(),
                            Code = dr["prd_Code"].ToString(),
                            HUOM = dr["wrd_HUOM"].ToString(),
                            LUOM = dr["wrd_LUOM"].ToString(),
                            PickedHQty = dr["wrd_Picked_HQty"].ToString(),
                            PickedLQty = dr["wrd_Picked_LQty"].ToString(),
                            ReceivedHQty = dr["wrd_Received_HQty"].ToString(),
                            ReceivedLQty = dr["wrd_Received_LQty"].ToString(),

                            wrd_ID = dr["wrd_ID"].ToString(),
                            LineNo = dr["wrd_LineNo"].ToString(),
                            ReasonId = dr["wrd_Reason_ID"].ToString(),
                            ReceivedHUOM = dr["wrd_Received_HUOM"].ToString(),
                            ReceivedLUOM = dr["wrd_Received_LUOM"].ToString(),
                            Weighing = dr["prd_WeighingItem"].ToString(),
                            Spec = dr["prd_Spec"].ToString(),
                            Desc = dr["prd_Description"].ToString(),
                            BatchSerial = listBatchSerial,
                            CatID = dr["cat_ID"].ToString(),
                            CatCode = dr["cat_Code"].ToString(),
                            CatName = dr["cat_Name"].ToString(),
                            SubCatID = dr["sct_ID"].ToString(),
                            SubCatCode = dr["sct_Code"].ToString(),
                            SubCatName = dr["sct_Name"].ToString(),
                            BrdID = dr["brd_ID"].ToString(),
                            BrdCode = dr["brd_Code"].ToString(),
                            BrdName = dr["brd_Name"].ToString(),
							ArCatName=dr["cat_NameArabic"].ToString(),
							ArSubCatName=dr["sct_NameArabic"].ToString(),
							ArBrdName=dr["brd_NameArabic"].ToString(),
                            ArName = dr["prd_NameArabic"].ToString(),

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

            dm.TraceService("GetWTReceivingItemBatch ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }

        public string WTReceivingBatchUpdate([FromForm] BatchUpdateHeader inputParams)
		{
			dm.TraceService("WTReceivingBatchUpdate STARTED ");
			dm.TraceService("===================");
			try
			{
				List<BatchUpdateDetail> jsonValue = JsonConvert.DeserializeObject<List<BatchUpdateDetail>>(inputParams.jsonValue);

				try
				{
					string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

					DataSet dsBatchUpdateHeader = new DataSet();

					DataTable dtBatchUpdateHeader = new DataTable();
					dtBatchUpdateHeader.Columns.Add("bch_ID", typeof(string));
					dtBatchUpdateHeader.Columns.Add("bch_ReceivedQty", typeof(string));
					dtBatchUpdateHeader.Columns.Add("bch_Reason_ID", typeof(string));


					foreach (var item in jsonValue)
					{
						dtBatchUpdateHeader.Rows.Add(item.bch_ID, item.bch_ReceivedQty, item.bch_Reason_ID);

					}

					dsBatchUpdateHeader.Tables.Add(dtBatchUpdateHeader);

					try
					{
						string[] keys = { "@UserID" };
						string[] values = { UserID.ToString() };
						string[] arr = { "@WTRBatchId" };
						DataSet Value = dm.bulkUpdate(dsBatchUpdateHeader, arr, keys, values, "sp_WTReceivingBatchUpdate");
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

			dm.TraceService("WTReceivingBatchUpdate ENDED ");
			dm.TraceService("=================");

			return JSONString;
		}
		public string GetWTROngoing([FromForm] PostWTReceivingData inputParams)
		{
			try
			{
				string UserID = inputParams.UserId == null ? "0" : inputParams.UserId;
				dm.TraceService("==========GetWTROngoing Started==========");
				string[] arr = { };
				DataTable CI = dm.loadList("SelectReceiveOngoing", "sp_WT_ReceivingWS", UserID.ToString());
				dm.TraceService("==========Query Executed==========");
				if (CI.Rows.Count > 0)
				{
					dm.TraceService("==========Row Count Greated Than 0==========");
					List<WTReceivingOut> listItems = new List<WTReceivingOut>();
					foreach (DataRow dr in CI.Rows)
					{

						listItems.Add(new WTReceivingOut
                        {
                            wrh_ID = dr["wrh_ID"].ToString(),
                            wrh_trn_number = dr["wrh_trn_number"].ToString(),
                            war_Name = dr["war_Name"].ToString(),
                            wrh_exp_Date = dr["wrh_Exp_Date"].ToString(),
                            Status = dr["Status"].ToString(),
                            mrh_Number = dr["mrh_Number"].ToString(),
                            WTPick_number = dr["wph_number"].ToString(),
                            WTTransOut_number = dr["wtt_number"].ToString(),
                            WTTransIn_number = dr["wti_number"].ToString()


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
			dm.TraceService("==========GetWTROngoing End==========");
			return JSONString;
		}

	}
}