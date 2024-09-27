using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class StockCountingController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string SelStockCountingHeader([FromForm] StkCntHeaderInParam InParams)
        {
            try
            {
                dm.TraceService("==========SelStockCounting Started==========");
                DataTable CI = dm.loadList("SelStockCountHeader", "sp_StockCountingWS", InParams.usrID);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<StkCntHeaderOutParam> listItems = new List<StkCntHeaderOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new StkCntHeaderOutParam
                        {
                            stk_ID = dr["stk_ID"].ToString(),
                            stk_trn_Number = dr["stk_trn_Number"].ToString(),
                            stk_exp_Date = dr["stk_exp_Date"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            Status = dr["Status"].ToString(),
                            stk_Type= dr["stk_Type"].ToString(),

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
            dm.TraceService("==========SelStockCounting End==========");
            return JSONString;
        }
        //public string SelStockCountingDetail([FromForm] StkCntDetailInParam InParams)
        //{
        //    try
        //    {
        //        dm.TraceService("==========SelStockCountingDetail Started==========");
        //        string[] arr = { InParams.UserID };
        //        DataSet CI = dm.loadListDS("SelStockCountDetail", "sp_StockCountingWS", InParams.stk_ID,arr);
        //        DataTable itemData = CI.Tables[0];
        //        DataTable batchData = CI.Tables[1];
        //        dm.TraceService("==========Query Executed==========");
        //        if (itemData.Rows.Count > 0)
        //        {
        //            dm.TraceService("==========Row Count Greated Than 0==========");
        //            List<StkCntDetailOutParam> listItems = new List<StkCntDetailOutParam>();
        //            foreach (DataRow dr in itemData.Rows)
        //            {

        //                listItems.Add(new StkCntDetailOutParam
        //                {
        //                    std_ID = dr["std_ID"].ToString(),
        //                    std_prd_ID = dr["std_prd_ID"].ToString(),
        //                    std_CountedHQty = dr["std_CountedHQty"].ToString(),
        //                    std_CountedLQty = dr["std_CountedHQty"].ToString(),
        //                    std_CountedHuom = dr["std_NS"].ToString(),
        //                    std_CountedLuom = dr["prd_Code"].ToString(),
        //                    std_NS = dr["std_NS"].ToString(),
        //                    prd_Code = dr["prd_Code"].ToString(),
        //                    prd_Name = dr["prd_Name"].ToString(),
        //                    prd_Desc = dr["prd_Description"].ToString(),
        //                    prd_Spec = dr["prd_Spec"].ToString()
        //                });
        //            }

        //            string JSONString = JsonConvert.SerializeObject(new
        //            {
        //                result = listItems
        //            });
        //            dm.TraceService("==========JSONString Generated " + JSONString + "==========");
        //            return JSONString;
        //        }
        //        else
        //        {
        //            dm.TraceService("==========Row Count Equal To 0==========");
        //            JSONString = "NoDataRes";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
        //        JSONString = "NoDataSQL";
        //    }
        //    dm.TraceService("==========SelStockCountingDetail End==========");
        //    return JSONString;
        //}
        public string SelStockCountingDetail([FromForm] StkCntDetailInParam inputParams)
        {
            dm.TraceService("GetGRNItemBatch STARTED ");
            dm.TraceService("====================");
            try
            {
              

                string[] arr = { inputParams.UserID };
                DataSet dtstkItemBatch = dm.loadListDS("SelStockCountDetail", "sp_StockCountingWS", inputParams.stk_ID, arr);
                DataTable itemData = dtstkItemBatch.Tables[0];
                DataTable batchData = dtstkItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<StkCntDetailOutParam> listItems = new List<StkCntDetailOutParam>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<StkBatchSerial> listBatchSerial = new List<StkBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["std_prd_ID"].ToString() == drDetails["stb_itm_ID"].ToString() && dr["stk_ID"].ToString() == drDetails["stb_stk_ID"].ToString())
                            {
                                listBatchSerial.Add(new StkBatchSerial
                                {
                                    Number = drDetails["stb_Number"].ToString(),
                                    ExpiryDate = drDetails["stb_ExpireDate"].ToString(),
                                    BaseUOM = drDetails["stb_BaseUOM"].ToString(),
                                    bch_Qty = drDetails["stb_Qty"].ToString(),
                                    //PickedQty = drDetails["bch_Picked_Qty"].ToString(),
                                    ItemCode = drDetails["prd_Code"].ToString(),
                                    ReasonId = drDetails["stb_rsn_ID"].ToString(),
                                    BatchID = drDetails["stb_ID"].ToString(),
                                    stb_std_ID = drDetails["stb_std_ID"].ToString()
                                });
                            }
                        }

                        listItems.Add(new StkCntDetailOutParam
                        {
                            std_ID = dr["std_ID"].ToString(),
                            std_prd_ID = dr["std_prd_ID"].ToString(),
                            std_CountedHQty = dr["std_CountedHQty"].ToString(),
                            std_CountedLQty = dr["std_CountedLQty"].ToString(),
                            std_CountedHuom = dr["std_CountedHuom"].ToString(),
                            std_CountedLuom = dr["std_CountedLuom"].ToString(),
                            std_NS = dr["std_NS"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_Desc = dr["prd_Description"].ToString(),
                            prd_Spec = dr["prd_Spec"].ToString(),
                            Reason_id = dr["std_rsn_ID"].ToString(),
                            BatchSerial = listBatchSerial,
                            Ar_prd_Name = dr["prd_NameArabic"].ToString(),
                            Ar_prd_Desc = dr["prd_ArabicItemLongDesc"].ToString()

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
        public string PostStockCounting([FromForm] PostStockCountingHeader inputParams)
		{
			dm.TraceService("PostStockCounting STARTED ");
			dm.TraceService("==================================");
			try
			{
				List<PostStockCountingItemDetail> ItemData = JsonConvert.DeserializeObject<List<PostStockCountingItemDetail>>(inputParams.stk_ItemData);
				List<PostStockCountingBatchDetail> BatchData = JsonConvert.DeserializeObject<List<PostStockCountingBatchDetail>>(inputParams.stk_BatchData);
				try
				{
					string StockID = inputParams.stk_HeaderID == null ? "0" : inputParams.stk_HeaderID;
					string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
					string status = inputParams.Status == null ? "0" : inputParams.Status;
					string Remarks = inputParams.Remarks == null ? "0" : inputParams.Remarks;

                    DataSet dsStockCount = new DataSet();

					DataTable dtItem = new DataTable();
					dtItem.Columns.Add("ItemId", typeof(int));
					dtItem.Columns.Add("CountedHUOM", typeof(string));
					dtItem.Columns.Add("CountedLUOM", typeof(string));
					dtItem.Columns.Add("CountedHQty", typeof(string));
					dtItem.Columns.Add("CountedLQty", typeof(string));
					dtItem.Columns.Add("warId", typeof(string));
                    dtItem.Columns.Add("std_ID", typeof(string));
                    dtItem.Columns.Add("std_Status", typeof(string));
                    dtItem.Columns.Add("std_rsn_ID", typeof(string));


                    DataTable dtBatch = new DataTable();
					dtBatch.Columns.Add("BatchNumber", typeof(string));
                    dtBatch.Columns.Add("CountedQty", typeof(string));
                    dtBatch.Columns.Add("BaseUOM", typeof(string));
                    dtBatch.Columns.Add("ProductionDate", typeof(string));
					dtBatch.Columns.Add("ExpiryDate", typeof(string));
                    dtBatch.Columns.Add("ProductId", typeof(string));
                    dtBatch.Columns.Add("ReasonId", typeof(string));
                    dtBatch.Columns.Add("StkDetailId", typeof(string));
                    dtBatch.Columns.Add("BatchLineNo", typeof(string));


                    foreach (var item in ItemData)
					{
						dtItem.Rows.Add(item.ItemId, item.CountedHUOM, item.CountedLUOM, item.CountedHQty, item.CountedLQty, item.warId,item.std_ID,item.std_Status,item.Reason_id);
					}

					foreach (var batch in BatchData)
					{
						dtBatch.Rows.Add(batch.BatchNumber,  batch.CountedQty, batch.BaseUOM, batch.ProductionDate, batch.ExpiryDate, batch.ProductId, batch.ReasonId, batch.StkDetailId, batch.BatchLineNo );
					}

					
					dsStockCount.Tables.Add(dtItem);
					dsStockCount.Tables.Add(dtBatch);

					try
					{
						string[] keys = { "@StockID", "@UserId", "@Status" , "@Remarks" };
						string[] values = { StockID.ToString(), userID.ToString(), status.ToString() ,Remarks.ToString()};
						string[] arr = { "@ItemData", "@BatchData" };
						DataSet Value = dm.bulkUpdate(dsStockCount, arr, keys, values, "sp_StockCounting");
						foreach (DataTable table in Value.Tables)
						{
							string Mode = table.Rows[0]["res"].ToString();
							string Status = table.Rows[0]["status"].ToString();
							dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Status=" + Status);
							List<CountingStatus> listStatus = new List<CountingStatus>();
							listStatus.Add(new CountingStatus
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

			dm.TraceService("PostStockCounting ENDED ");
			dm.TraceService("================================");

			return JSONString;
		}
		public string ViewItemWiseDetail([FromForm] Viewitmsin InParams)
		{
			try
			{
				dm.TraceService("==========ViewItemWiseDetail Started==========");
				DataTable CI = dm.loadList("ViewItemWiseDetail", "sp_StockCountingWS", InParams.stkheaderID);
				dm.TraceService("==========Query Executed==========");
				if (CI.Rows.Count > 0)
				{
					dm.TraceService("==========Row Count Greated Than 0==========");
					List<ViewitmsOut> listItems = new List<ViewitmsOut>();
					foreach (DataRow dr in CI.Rows)
					{

						listItems.Add(new ViewitmsOut
						{
							prdcode = dr["prd_Code"].ToString(),
							prdname = dr["prd_Name"].ToString(),
							CountedHQty = dr["std_CountedHQty"].ToString(),
							CountedLQty = dr["std_CountedLQty"].ToString(),
							CountedHuom = dr["std_CountedHuom"].ToString(),
							CountedLuom = dr["std_CountedLuom"].ToString(),
							std_NS = dr["std_NS"].ToString(),
							warcode = dr["war_Code"].ToString(),
							Warehouse = dr["war_Name"].ToString()

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
			dm.TraceService("==========ViewItemWiseDetail End==========");
			return JSONString;
		}

		public string GetStockCountingOngoing([FromForm] PostWTReceivingData inputParams)
		{
			try
			{
				string UserID = inputParams.UserId == null ? "0" : inputParams.UserId;
				dm.TraceService("==========GetStockCountingOngoing Started==========");
				string[] arr = { };
				DataTable CI = dm.loadList("SelectCountingOngoing", "sp_StockCountingWS", UserID.ToString());
				dm.TraceService("==========Query Executed==========");
				if (CI.Rows.Count > 0)
				{
					dm.TraceService("==========Row Count Greated Than 0==========");
					List<StkCntHeaderOutParam> listItems = new List<StkCntHeaderOutParam>();
					foreach (DataRow dr in CI.Rows)
					{

                        listItems.Add(new StkCntHeaderOutParam
                        {
                            stk_ID = dr["stk_ID"].ToString(),
                            stk_trn_Number = dr["stk_trn_Number"].ToString(),
                            stk_exp_Date = dr["stk_exp_Date"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            Status = dr["Status"].ToString(),
                            stk_Type = dr["stk_Type"].ToString()
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
			dm.TraceService("==========GetStockCountingOngoing End==========");
			return JSONString;
		}
        public string StockCountingAccept([FromForm] StkAcceptInpara inputParams)
        {
            try
            {
                string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========StockCountingAccept Started==========");
                string[] arr = { UserID.ToString() };
                DataTable CI = dm.loadList("StartCounting", "sp_StockCountingWS", HeaderID.ToString(), arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    string Mode = CI.Rows[0]["res"].ToString();
                    string Title = CI.Rows[0]["Title"].ToString();
                    string Descr = CI.Rows[0]["Descr"].ToString();
                    dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
                    List<GetstkStatus> listStatus = new List<GetstkStatus>();
                    listStatus.Add(new GetstkStatus
                    {
                        Res = Mode,
                        Title = Title,
                        Descr = Descr
                    });

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listStatus
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
            dm.TraceService("==========StockCountingAccept End==========");
            return JSONString;
        }

        public string SelwarehouseItem([FromForm] StkCntDetailInParam inputParams)
        {
            dm.TraceService("SelwarehouseItem STARTED ");
            dm.TraceService("====================");
            try
            {
                string[] arr = { "" };
                DataSet dtstkItemBatch = dm.loadListDS("StockCountingWarehouses", "sp_StockCountingWS", inputParams.stk_ID, arr);
                DataTable itemData = dtstkItemBatch.Tables[0];
                DataTable batchData = dtstkItemBatch.Tables[1];
                DataTable itemBatchData = dtstkItemBatch.Tables[2];
                if (itemData.Rows.Count > 0)
                {
                    List<StkCntwarID> listItems = new List<StkCntwarID>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<StkCntwarItmID> listitemSerial = new List<StkCntwarItmID>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {

                            List<StkCntwarItmBatchID> listitemBatchSerial = new List<StkCntwarItmBatchID>();
                            foreach (DataRow drBatchDetails in itemBatchData.Rows)
                            {

                                if (dr["war_ID"].ToString() == drDetails["wim_war_ID"].ToString() && dr["war_ID"].ToString() == drBatchDetails["war_ID"].ToString() && drDetails["wim_war_ID"].ToString() == drBatchDetails["wim_war_ID"].ToString() && drDetails["wim_prd_ID"].ToString() == drBatchDetails["stb_itm_ID"].ToString())
                                {
                                    listitemBatchSerial.Add(new StkCntwarItmBatchID
                                    {
                                        stb_itm_ID = drBatchDetails["stb_itm_ID"].ToString(),
                                        stb_Number = drBatchDetails["stb_Number"].ToString(),
                                        stb_BaseUOM = drBatchDetails["stb_BaseUOM"].ToString(),
                                        stb_Qty = drBatchDetails["stb_Qty"].ToString(),
                                        stb_ProductionDate = drBatchDetails["stb_ProductionDate"].ToString(),
                                        stb_ExpireDate = drBatchDetails["stb_ExpireDate"].ToString(),
                                        stb_rsn_ID = drBatchDetails["stb_rsn_ID"].ToString(),
                                        stb_stk_ID = drBatchDetails["stb_stk_ID"].ToString(),
                                        stb_std_ID = drBatchDetails["stb_std_ID"].ToString(),
                                        stb_LineNo = drBatchDetails["stb_LineNo"].ToString(),
                                        war_ID = drBatchDetails["war_ID"].ToString(),
                                        wim_war_ID = drBatchDetails["wim_war_ID"].ToString()
                                    });
                                }
                            }

                            if (dr["war_ID"].ToString() == drDetails["wim_war_ID"].ToString())
                            {
                                listitemSerial.Add(new StkCntwarItmID
                                {
                                    waritm_ID = drDetails["wim_prd_ID"].ToString(),
                                    wareID = drDetails["wim_war_ID"].ToString(),
                                    prd_Spec = drDetails["prd_Spec"].ToString(),
                                    std_CountedHQty = drDetails["std_CountedHQty"].ToString(),
                                    std_CountedLQty = drDetails["std_CountedLQty"].ToString(),
                                    std_CountedHuom = drDetails["std_CountedHuom"].ToString(),
                                    std_CountedLuom = drDetails["std_CountedLuom"].ToString(),
                                    std_ID = drDetails["std_ID"].ToString(),
                                    std_rsn_ID = drDetails["std_rsn_ID"].ToString(),
                                    BatchSerial = listitemBatchSerial
                                });
                            }
                        }

                        listItems.Add(new StkCntwarID
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

            dm.TraceService("GetGRNItemBatch ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }

        public string GetAssignedStockHeader([FromForm] StkCntHeaderInParam inputParams)
        {
            try
            {
                string UserID = inputParams.usrID == null ? "0" : inputParams.usrID;
                dm.TraceService("==========GetAssignedStockHeader Started==========");
                DataTable CI = dm.loadList("SelectStockCountAssignedHeader", "sp_StockCountingWS", UserID.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<StkCntHeaderOutParam> listItems = new List<StkCntHeaderOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new StkCntHeaderOutParam
                        {
                            stk_ID = dr["stk_ID"].ToString(),
                            stk_trn_Number = dr["stk_trn_Number"].ToString(),
                            stk_exp_Date = dr["stk_exp_Date"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            Status = dr["Status"].ToString(),
                            stk_Type = dr["stk_Type"].ToString()
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
            dm.TraceService("==========GetAssignedStockHeader End==========");
            return JSONString;
        }

        public string GetUnAssignedStockHeader([FromForm] StkCntHeaderInParam inputParams)
        {
            try
            {
                string UserID = inputParams.usrID == null ? "0" : inputParams.usrID;
                dm.TraceService("==========GetUnAssignedStockHeader Started==========");
                DataTable CI = dm.loadList("SelectStockCountUnAssignedHeader", "sp_StockCountingWS", UserID.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<StkCntHeaderOutParam> listItems = new List<StkCntHeaderOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new StkCntHeaderOutParam
                        {
                            stk_ID = dr["stk_ID"].ToString(),
                            stk_trn_Number = dr["stk_trn_Number"].ToString(),
                            stk_exp_Date = dr["stk_exp_Date"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CreatedTime = dr["CreatedTime"].ToString(),
                            Status = dr["Status"].ToString(),
                            stk_Type = dr["stk_Type"].ToString(),
                            PickedBy = dr["PickedBy"].ToString(),
                            ArPickedBy = dr["ArPickedBy"].ToString()
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
            dm.TraceService("==========GetUnAssignedStockHeader End==========");
            return JSONString;
        }

        public string PostStockCountingSelfAssign([FromForm] PostAssignStockCountingHeader inputParams)
        {
            dm.TraceService("PostStockCountingSelfAssign STARTED ");
            dm.TraceService("===================");
            try
            {
                List<PostAssignStockCountingDetail> jsonValue = JsonConvert.DeserializeObject<List<PostAssignStockCountingDetail>>(inputParams.jsonValue);

                try
                {
                    string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                    DataSet dsStockHeader = new DataSet();

                    DataTable dtStockHeader = new DataTable();
                    dtStockHeader.Columns.Add("StockHeaderID", typeof(string));

                    foreach (var item in jsonValue)
                    {
                        dtStockHeader.Rows.Add(item.StockHeaderID);
                    }

                    dsStockHeader.Tables.Add(dtStockHeader);

                    try
                    {
                        string[] keys = { "@UserID" };
                        string[] values = { UserID.ToString() };
                        string[] arr = { "@StockID" };
                        DataSet Value = dm.bulkUpdate(dsStockHeader, arr, keys, values, "sp_SelfStockAssignment");
                        foreach (DataTable table in Value.Tables)
                        {
                            string Mode = table.Rows[0]["res"].ToString();
                            string Title = table.Rows[0]["Title"].ToString();
                            string Descr = table.Rows[0]["Descr"].ToString();
                            dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
                            List<GetstkStatus> listStatus = new List<GetstkStatus>();
                            listStatus.Add(new GetstkStatus
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

            dm.TraceService("PostStockCountingSelfAssign ENDED ");
            dm.TraceService("=================");

            return JSONString;
        }

        public string SelInstantWarehouseItem([FromForm] StkCntInstantDetailInParam inputParams)
        {
            dm.TraceService("SelInstantWarehouseItem STARTED ");
            dm.TraceService("====================");
            try
            {
                string[] arr = { inputParams.war_ID };
                DataSet dtstkItemBatch = dm.loadListDS("StockCountingWarehouses", "sp_StockCountingWS", inputParams.stk_ID, arr);
                DataTable itemData = dtstkItemBatch.Tables[0];
                DataTable batchData = dtstkItemBatch.Tables[1];
                DataTable itemBatchData = dtstkItemBatch.Tables[2];
                if (itemData.Rows.Count > 0)
                {
                    List<StkCntwarID> listItems = new List<StkCntwarID>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<StkCntwarItmID> listitemSerial = new List<StkCntwarItmID>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {

                            List<StkCntwarItmBatchID> listitemBatchSerial = new List<StkCntwarItmBatchID>();
                            foreach (DataRow drBatchDetails in itemBatchData.Rows)
                            {

                                if (dr["war_ID"].ToString() == drDetails["wim_war_ID"].ToString() && dr["war_ID"].ToString() == drBatchDetails["war_ID"].ToString() && drDetails["wim_war_ID"].ToString() == drBatchDetails["wim_war_ID"].ToString() && drDetails["wim_prd_ID"].ToString() == drBatchDetails["stb_itm_ID"].ToString())
                                {
                                    listitemBatchSerial.Add(new StkCntwarItmBatchID
                                    {
                                        stb_itm_ID = drBatchDetails["stb_itm_ID"].ToString(),
                                        stb_Number = drBatchDetails["stb_Number"].ToString(),
                                        stb_BaseUOM = drBatchDetails["stb_BaseUOM"].ToString(),
                                        stb_Qty = drBatchDetails["stb_Qty"].ToString(),
                                        stb_ProductionDate = drBatchDetails["stb_ProductionDate"].ToString(),
                                        stb_ExpireDate = drBatchDetails["stb_ExpireDate"].ToString(),
                                        stb_rsn_ID = drBatchDetails["stb_rsn_ID"].ToString(),
                                        stb_stk_ID = drBatchDetails["stb_stk_ID"].ToString(),
                                        stb_std_ID = drBatchDetails["stb_std_ID"].ToString(),
                                        stb_LineNo = drBatchDetails["stb_LineNo"].ToString(),
                                        war_ID = drBatchDetails["war_ID"].ToString(),
                                        wim_war_ID = drBatchDetails["wim_war_ID"].ToString()
                                    });
                                }
                            }

                            if (dr["war_ID"].ToString() == drDetails["wim_war_ID"].ToString())
                            {
                                listitemSerial.Add(new StkCntwarItmID
                                {
                                    waritm_ID = drDetails["wim_prd_ID"].ToString(),
                                    wareID = drDetails["wim_war_ID"].ToString(),
                                    prd_Spec = drDetails["prd_Spec"].ToString(),
                                    std_CountedHQty = drDetails["std_CountedHQty"].ToString(),
                                    std_CountedLQty = drDetails["std_CountedLQty"].ToString(),
                                    std_CountedHuom = drDetails["std_CountedHuom"].ToString(),
                                    std_CountedLuom = drDetails["std_CountedLuom"].ToString(),
                                    std_ID = drDetails["std_ID"].ToString(),
                                    std_rsn_ID = drDetails["std_rsn_ID"].ToString(),
                                    BatchSerial = listitemBatchSerial
                                });
                            }
                        }

                        listItems.Add(new StkCntwarID
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

            dm.TraceService("SelInstantWarehouseItem ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }

        public string PostInstantStockCounting([FromForm] PostInstantStockCountingHeader inputParams)
        {
            dm.TraceService("PostInstantStockCounting STARTED ");
            dm.TraceService("==================================");
            try
            {
                List<PostStockCountingItemDetail> ItemData = JsonConvert.DeserializeObject<List<PostStockCountingItemDetail>>(inputParams.stk_ItemData);
                List<PostStockCountingBatchDetail> BatchData = JsonConvert.DeserializeObject<List<PostStockCountingBatchDetail>>(inputParams.stk_BatchData);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string ExpDate = inputParams.ExpDate == null ? "0" : inputParams.ExpDate;
                    string Remarks = inputParams.Remarks == null ? "0" : inputParams.Remarks;

                    DataSet dsStockCount = new DataSet();

                    DataTable dtItem = new DataTable();
                    dtItem.Columns.Add("ItemId", typeof(int));
                    dtItem.Columns.Add("CountedHUOM", typeof(string));
                    dtItem.Columns.Add("CountedLUOM", typeof(string));
                    dtItem.Columns.Add("CountedHQty", typeof(string));
                    dtItem.Columns.Add("CountedLQty", typeof(string));
                    dtItem.Columns.Add("warId", typeof(string));
                    dtItem.Columns.Add("std_ID", typeof(string));
                    dtItem.Columns.Add("std_Status", typeof(string));
                    dtItem.Columns.Add("std_rsn_ID", typeof(string));


                    DataTable dtBatch = new DataTable();
                    dtBatch.Columns.Add("BatchNumber", typeof(string));
                    dtBatch.Columns.Add("CountedQty", typeof(string));
                    dtBatch.Columns.Add("BaseUOM", typeof(string));
                    dtBatch.Columns.Add("ProductionDate", typeof(string));
                    dtBatch.Columns.Add("ExpiryDate", typeof(string));
                    dtBatch.Columns.Add("ProductId", typeof(string));
                    dtBatch.Columns.Add("ReasonId", typeof(string));
                    dtBatch.Columns.Add("StkDetailId", typeof(string));
                    dtBatch.Columns.Add("BatchLineNo", typeof(string));


                    foreach (var item in ItemData)
                    {
                        dtItem.Rows.Add(item.ItemId, item.CountedHUOM, item.CountedLUOM, item.CountedHQty, item.CountedLQty, item.warId, item.std_ID, item.std_Status, item.Reason_id);
                    }

                    foreach (var batch in BatchData)
                    {
                        dtBatch.Rows.Add(batch.BatchNumber, batch.CountedQty, batch.BaseUOM, batch.ProductionDate, batch.ExpiryDate, batch.ProductId, batch.ReasonId, batch.StkDetailId, batch.BatchLineNo);
                    }


                    dsStockCount.Tables.Add(dtItem);
                    dsStockCount.Tables.Add(dtBatch);

                    try
                    {
                        string[] keys = { "@UserId", "@Remarks", "@ExpDate" };
                        string[] values = { userID.ToString(), Remarks.ToString(), ExpDate.ToString() };
                        string[] arr = { "@ItemData", "@BatchData" };
                        DataSet Value = dm.bulkUpdate(dsStockCount, arr, keys, values, "sp_InstantStockCounting");
                        foreach (DataTable table in Value.Tables)
                        {
                            string Mode = table.Rows[0]["res"].ToString();
                            string Status = table.Rows[0]["status"].ToString();
                            dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Status=" + Status);
                            List<CountingStatus> listStatus = new List<CountingStatus>();
                            listStatus.Add(new CountingStatus
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

            dm.TraceService("PostInstantStockCounting ENDED ");
            dm.TraceService("================================");

            return JSONString;
        }
    }
}