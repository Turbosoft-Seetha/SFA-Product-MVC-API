using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MVC_API.Controllers
{
    public class WarehouseTransferController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;


        public string WarAssignedPickHeader([FromForm] WarHeaderInParam InParams)
        {
            try
            {
                dm.TraceService("==========WarAssignedPickHeader Started==========");
                DataTable CI = dm.loadList("SelAssignedWarPickingHeader", "sp_WT_PickingWS", InParams.usrID);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<WarHeaderOutParam> listItems = new List<WarHeaderOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new WarHeaderOutParam
                        {
                            pkh_ID = dr["wph_ID"].ToString(),
                            pkh_Number = dr["wph_Number"].ToString(),
                            war_ID = dr["wph_war_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            mrh_Number = dr["mrh_Number"].ToString()

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
            dm.TraceService("==========WarAssignedPickHeader End==========");
            return JSONString;
        }
        public string WarUnAssignedPickHeader([FromForm] WarHeaderInParam InParams)
        {
            try
            {
                dm.TraceService("==========WarUnAssignedPickHeader Started==========");
                DataTable CI = dm.loadList("SelUnAssignedWarPickingHeader", "sp_WT_PickingWS", InParams.usrID);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<WarHeaderOutParam> listItems = new List<WarHeaderOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new WarHeaderOutParam
                        {
                            pkh_ID = dr["wph_ID"].ToString(),
                            pkh_Number = dr["wph_Number"].ToString(),
                            war_ID = dr["wph_war_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            mrh_Number= dr["mrh_Number"].ToString(),
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
            dm.TraceService("==========WarUnAssignedPickHeader End==========");
            return JSONString;
        }

        public string WTSelfAssign([FromForm] PostAssignHeader inputParams)
        {
            dm.TraceService("WTSelfAssign STARTED ");
            dm.TraceService("===================");
            try
            {
                List<PostAssignDetail> jsonValue = JsonConvert.DeserializeObject<List<PostAssignDetail>>(inputParams.jsonValue);

                try
                {
                    string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                    DataSet dsPickingHeader = new DataSet();

                    DataTable dtPickingHeader = new DataTable();
                    dtPickingHeader.Columns.Add("PickHeaderID", typeof(string));

                    foreach (var item in jsonValue)
                    {
                        dtPickingHeader.Rows.Add(item.PickHeaderID);
                    }

                    dsPickingHeader.Tables.Add(dtPickingHeader);

                    try
                    {
                        string[] keys = { "@UserID" };
                        string[] values = { UserID.ToString() };
                        string[] arr = { "@PickID" };
                        DataSet Value = dm.bulkUpdate(dsPickingHeader, arr, keys, values, "sp_SelfWTPickAssignment");
                        foreach (DataTable table in Value.Tables)
                        {
                            string Mode = table.Rows[0]["res"].ToString();
                            string Title = table.Rows[0]["Title"].ToString();
                            string Descr = table.Rows[0]["Descr"].ToString();
                            dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
                            List<GetPickingStatus> listStatus = new List<GetPickingStatus>();
                            listStatus.Add(new GetPickingStatus
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

            dm.TraceService("WTSelfAssign ENDED ");
            dm.TraceService("=================");

            return JSONString;
        }
        public string PostStartWTPicking([FromForm] PostStartWTPickHeader inputParams)
        {
            try
            {
                string PickingID = inputParams.PickHeaderID == null ? "0" : inputParams.PickHeaderID;
                string PickUserID = inputParams.PickUserID == null ? "0" : inputParams.PickUserID;
                dm.TraceService("==========PostStartWTPicking Started==========");
                string[] arr = { PickUserID.ToString() };
                DataTable CI = dm.loadList("StartWTPicking", "sp_WT_PickingWS", PickingID.ToString(), arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    string Mode = CI.Rows[0]["res"].ToString();
                    string Title = CI.Rows[0]["Title"].ToString();
                    string Descr = CI.Rows[0]["Descr"].ToString();
                    dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
                    List<GetPickingStatus> listStatus = new List<GetPickingStatus>();
                    listStatus.Add(new GetPickingStatus
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
            dm.TraceService("==========PostStartWTPicking End==========");
            return JSONString;
        }

        public string WTPickDetail([FromForm] WTDetailInParam InParams)
        {
            try
            {
                dm.TraceService("==========WTPickDetail Started==========");
                DataTable CI = dm.loadList("SelWTPickingDetail", "sp_WT_PickingWS", InParams.HeaderID);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<WTDetailOutParam> listItems = new List<WTDetailOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new WTDetailOutParam
                        {
                            pkd_ID = dr["pkd_ID"].ToString(),
                            pkd_itm_ID = dr["pkd_itm_ID"].ToString(),
                            pkd_Huom = dr["pkd_Higher_uom"].ToString(),
                            pkd_Luom = dr["pkd_Lower_uom"].ToString(),
                            pkd_RequestedHQty = dr["pkd_RequestedHQty"].ToString(),
                            pkd_RequestedLQty = dr["pkd_RequestedLQty"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_Code = dr["prd_Code"].ToString()

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
            dm.TraceService("==========WTPickDetail End==========");
            return JSONString;
        }
        public string GetWTItemBatch([FromForm] PostWTPickingData inputParams)
        {
            dm.TraceService("GetItemBatch STARTED ");
            dm.TraceService("====================");
            try
            {
                string pickingID = inputParams.PickingId == null ? "0" : inputParams.PickingId;
                string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

                string[] arr = { userID.ToString() };
                DataSet dtItemBatch = dm.loadListDS("SelWTItemBatch", "sp_WT_PickingWS", pickingID.ToString(), arr);
                DataTable itemData = dtItemBatch.Tables[0];
                DataTable batchData = dtItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<GetWTPickingItemHeader> listItems = new List<GetWTPickingItemHeader>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<GetWTPickingBatchSerial> listBatchSerial = new List<GetWTPickingBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["prd_Code"].ToString() == drDetails["prd_Code"].ToString() && dr["wpd_ID"].ToString() == drDetails["wbs_wpd_ID"].ToString())
                            {
                                listBatchSerial.Add(new GetWTPickingBatchSerial
                                {
                                    Number = drDetails["wbs_Number"].ToString(),
                                    ExpiryDate = drDetails["wbs_ExpiryDate"].ToString(),
                                    BaseUOM = drDetails["wbs_BaseUOM"].ToString(),
                                    RequestedQty = drDetails["wbs_RequestedQty"].ToString(),
                                    PickedQty = drDetails["wbs_PickQty"].ToString(),
                                    ItemCode = drDetails["prd_Code"].ToString(),
                                    ReasonId = drDetails["wbs_rsn_ID"].ToString(),
                                    UserId = drDetails["ModifedBy"].ToString(),
                                    EligibleQty = drDetails["bat_AvailbleQty"].ToString(),
                                    BatchID = drDetails["wbs_ID"].ToString(),
                                    pkd_ID = drDetails["wbs_wpd_ID"].ToString(),
                                    SalesMan = drDetails["wbs_SalesMan"].ToString()
                                });
                            }
                        }

                        listItems.Add(new GetWTPickingItemHeader
                        {
                            Id = Int32.Parse(dr["prd_ID"].ToString()),
                            Name = dr["prd_Name"].ToString(),
                            Code = dr["prd_Code"].ToString(),
                            Spec = dr["prd_Spec"].ToString(),
                            CategoryId = dr["prd_cat_ID"].ToString(),
                            SubcategoryId = dr["prd_sct_ID"].ToString(),
                            ReqHUOM = dr["wpd_ReqHUOM"].ToString(),
                            ReqLUOM = dr["wpd_ReqLUOM"].ToString(),
                            ReqHQty = dr["wpd_RequestedHQty"].ToString(),
                            ReqLQty = dr["wpd_RequestedLQty"].ToString(),
                            PickHQty = dr["wpd_PickedHQty"].ToString(),
                            PickLQty = dr["wpd_PickedLQty"].ToString(),
                            PromoType = "",
                            ReasonId = dr["wpd_rsn_ID"].ToString(),
                            Desc = dr["prd_Desc"].ToString(),
                            LineNo = dr["wpd_LineNo"].ToString(),
                            pid_ID = dr["wpd_ID"].ToString(),
                            Weighing = dr["prd_WeighingItem"].ToString(),
                            PickHUom = dr["wpd_PickedHUOM"].ToString(),
                            PickLUom = dr["wpd_PickedLUOM"].ToString(),
                            BatchSerial = listBatchSerial,
                            CatCode = dr["cat_Code"].ToString(),
                            CatName = dr["cat_Name"].ToString(),
                            SubCatCode = dr["sct_Code"].ToString(),
                            SubCatName = dr["sct_Name"].ToString(),
                            BrdID = dr["brd_ID"].ToString(),
                            BrdCode = dr["brd_Code"].ToString(),
                            BrdName = dr["brd_Name"].ToString(),
                            ArName = dr["prd_NameArabic"].ToString(),
                            ArBrdName = dr["brd_NameArabic"].ToString(),
                            ArCatName = dr["cat_NameArabic"].ToString(),
                            ArSubCatName = dr["sct_NameArabic"].ToString(),






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

            dm.TraceService("GetItemBatch ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }
        public string WTBatches()
        {
            try
            {
                dm.TraceService("==========WTBatches Started==========");
                DataTable CI = dm.loadList("SelBatchOfWTPicking", "sp_WT_PickingWS");
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<WTBatchOutParam> listItems = new List<WTBatchOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new WTBatchOutParam
                        {
                            wbs_ID = dr["wtb_ID"].ToString(),
                            wbs_Number = dr["wtb_Number"].ToString(),
                            wbs_ExpiryDate= dr["wtb_ExpiryDate"].ToString(),
                            wbs_BaseUOM = dr["wtb_BaseUOM"].ToString(),
                            wbs_PickQty = dr["wtb_PickQty"].ToString(),
                            wbs_SalesMan= dr["wtb_SalesMan"].ToString(),
                            wbs_AvailbleQty= dr["wtb_AvailbleQty"].ToString(),
                            wbs_ArSalesMan = dr["wtb_SalesmanArabic"].ToString(),


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
            dm.TraceService("==========WTBatches End==========");
            return JSONString;
        }
        public string WTPickingComplete([FromForm] WTPickCmpltInParam inputParams)
        {
            dm.TraceService("GetWTPickingComplete STARTED ");
            dm.TraceService("===========================");
            try
            {
                List<WTPickingItemData> itemData = JsonConvert.DeserializeObject<List<WTPickingItemData>>(inputParams.ItemData);
                List<WTPickingBatchData> batchData = JsonConvert.DeserializeObject<List<WTPickingBatchData>>(inputParams.BatchData);
                try
                {
                    string pickingID = inputParams.PickingId == null ? "0" : inputParams.PickingId;
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
                    dtItem.Columns.Add("UserId", typeof(string));
                    dtItem.Columns.Add("ModifiedOn", typeof(string));
                    dtItem.Columns.Add("LineNumber", typeof(string));


                    DataTable dtBatch = new DataTable();
                    dtBatch.Columns.Add("ProductId", typeof(int));
                    dtBatch.Columns.Add("Number", typeof(string));
                    dtBatch.Columns.Add("PickedQty", typeof(string));
                    dtBatch.Columns.Add("ReasonId", typeof(string));
                    dtBatch.Columns.Add("BatchMode", typeof(string));
                    dtBatch.Columns.Add("ExpiryDate", typeof(string));
                    dtBatch.Columns.Add("UserId", typeof(string));
                    dtBatch.Columns.Add("ModifiedOn", typeof(string));
                    dtBatch.Columns.Add("BatchID", typeof(string));
                    dtBatch.Columns.Add("wpd_ID", typeof(string));
                    dtBatch.Columns.Add("SalesPerson", typeof(string));
                    dtBatch.Columns.Add("EligibleQty", typeof(string));
                    dtBatch.Columns.Add("BaseUOM", typeof(string));
                    foreach (var item in itemData)
                    {
                        dtItem.Rows.Add(item.ProductId, item.ProductHUOM, item.ProductLUOM, item.ProductHQty, item.ProductLQty, item.ReasonId, item.UserId, item.ModifiedOn, item.LineNumber);
                    }

                    foreach (var batch in batchData)
                    {
                        dtBatch.Rows.Add(batch.ProductId, batch.Number, batch.PickedQty, batch.ReasonId, batch.BatchMode, batch.ExpiryDate, batch.UserId, batch.ModifiedOn, batch.BatchID, batch.wpd_ID, batch.SalesPerson, batch.EligibleQty, batch.BaseUOM);
                    }

                    dsItemBatch.Tables.Add(dtItem);
                    dsItemBatch.Tables.Add(dtBatch);

                    try
                    {
                        string[] keys = { "@PickingId", "@UserId", "@Status" };
                        string[] values = { pickingID.ToString(), userID.ToString(), status.ToString() };
                        string[] arr = { "@ItemData", "@BatchData" };
                        DataSet Value = dm.bulkUpdate(dsItemBatch, arr, keys, values, "sp_WTCompletePicking");
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

            dm.TraceService("GetPickingComplete ENDED ");
            dm.TraceService("=========================");

            return JSONString;
        }
        public string WTPickingOngoing([FromForm] PostPickUser inputParams)
        {
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========WTPickingOngoing Started==========");

                DataTable CI = dm.loadList("SelWTPickingOngoing", "sp_WT_PickingWS", UserID.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<WarHeaderOutParam> listItems = new List<WarHeaderOutParam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new WarHeaderOutParam
                        {
                            pkh_ID = dr["wph_ID"].ToString(),
                            pkh_Number = dr["wph_Number"].ToString(),
                            war_ID = dr["wph_war_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            mrh_Number = dr["mrh_Number"].ToString()

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
            dm.TraceService("==========WTPickingOngoing End==========");
            return JSONString;
        }

    }

}