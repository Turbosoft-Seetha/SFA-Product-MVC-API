using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Mvc;
using MVC_API.FE_NAV_Service;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using static Stimulsoft.Report.Func;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MVC_API.Controllers
{
    public class LoadPickingController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string GetRouteForPicking([FromForm] PostPickUser inputParams)
        {
            dm.TraceService("GetRouteForPicking STARTED ");
            dm.TraceService("===================");
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetRouteForPicking Started==========");
                string[] arr = { };
                DataTable CI = dm.loadList("SelectRouteForPicking", "sp_PickingWebServices", UserID.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<GetPickingRoute> listItems = new List<GetPickingRoute>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new GetPickingRoute
                        {
                            RouteID = dr["rot_ID"].ToString(),
                            RouteUserID = dr["rot_usr_ID"].ToString(),
                            StartTime = dr["ros_StartTime"].ToString(),
                            EndTime = dr["ros_EndTime"].ToString(),
                            PickCount = dr["PickingHeaderCount"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            User_Name = dr["usr_Name"].ToString(),
                            User_ArName = dr["usr_ArabicName"].ToString(),
                            rot_ArName = dr["rot_ArabicName"].ToString()
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
            dm.TraceService("==========GetRouteForPicking End==========");
            return JSONString;
        }

        public string GetAssignedPickHeader([FromForm] PostPickUser inputParams)
        {
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetAssignedPickHeader Started==========");
                string[] arr = { inputParams.RouteID };
                DataTable CI = dm.loadList("SelectPickingAssignedHeader", "sp_PickingWebServices", UserID.ToString(), arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<GetPickingHeader> listItems = new List<GetPickingHeader>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new GetPickingHeader
                        {
                            PickingID = dr["pkh_ID"].ToString(),
                            Number = dr["pkh_Number"].ToString(),
                            UserID = dr["pkh_usr_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            Reason = dr["pkh_Reason"].ToString(),
                            StoreID = dr["pkh_str_ID"].ToString(),
                            Date = dr["Date"].ToString(),
                           // Username = dr["usr_Name"].ToString(),
                            store = dr["str_Name"].ToString(),
                            User_ArName = dr["usr_ArabicName"].ToString(),
                            Arstore = dr["str_ArabicName"].ToString(),
                            ArPickedBy = dr["ArPickedBy"].ToString(),
                            PickedBy = dr["PickedBy"].ToString()


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
            dm.TraceService("==========GetAssignedPickHeader End==========");
            return JSONString;
        }

        public string GetUnAssignedPickHeader([FromForm] PostPickUser inputParams)
        {
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetAssignedPickHeader Started==========");
                string[] arr = { inputParams.RouteID };
                DataTable CI = dm.loadList("SelectPickingUnAssignedHeader", "sp_PickingWebServices", UserID.ToString(), arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<GetPickingHeader> listItems = new List<GetPickingHeader>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new GetPickingHeader
                        {
                            PickingID = dr["pkh_ID"].ToString(),
                            Number = dr["pkh_Number"].ToString(),
                            UserID = dr["pkh_usr_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            Reason = dr["pkh_Reason"].ToString(),
                            StoreID = dr["pkh_str_ID"].ToString(),
                            Date = dr["Date"].ToString(),
                           // Username = dr["usr_Name"].ToString(),
                            store = dr["str_Name"].ToString(),
                            PickedBy = dr["PickedBy"].ToString(),
                            User_ArName = dr["usrArabicName"].ToString(),
                            ArPickedBy = dr["ArPickedBy"].ToString(),
                            Arstore = dr["str_ArabicName"].ToString()
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
            dm.TraceService("==========GetUnAssignedPickHeader End==========");
            return JSONString;
        }

        public string PostStartPicking([FromForm] PostStartPickHeader inputParams)
        {
            try
            {
                string PickingID = inputParams.PickHeaderID == null ? "0" : inputParams.PickHeaderID;
                string PickUserID = inputParams.PickUserID == null ? "0" : inputParams.PickUserID;
                dm.TraceService("==========PostStartPicking Started==========");
                string[] arr = { PickUserID.ToString() };
                DataTable CI = dm.loadList("StartPicking", "sp_PickingWebServices", PickingID.ToString(), arr);
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
            dm.TraceService("==========PostStartPicking End==========");
            return JSONString;
        }

        public string PostSelfAssign([FromForm] PostAssignHeader inputParams)
        {
            dm.TraceService("PostSelfAssign STARTED ");
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
                        DataSet Value = dm.bulkUpdate(dsPickingHeader, arr, keys, values, "sp_SelfPickAssignment");
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

            dm.TraceService("PostSelfAssign ENDED ");
            dm.TraceService("=================");

            return JSONString;
        }

        public string GetItemBatch([FromForm] PostPickingData inputParams)
        {
            dm.TraceService("GetItemBatch STARTED ");
            dm.TraceService("====================");
            try
            {
                string pickingID = inputParams.PickingId == null ? "0" : inputParams.PickingId;
                string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

                string[] arr = { userID.ToString() };
                DataSet dtItemBatch = dm.loadListDS("SelItemBatch", "sp_PickingWebServices", pickingID.ToString(), arr);
                DataTable itemData = dtItemBatch.Tables[0];
                DataTable batchData = dtItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<GetPickingItemHeader> listItems = new List<GetPickingItemHeader>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<GetPickingBatchSerial> listBatchSerial = new List<GetPickingBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["prd_Code"].ToString() == drDetails["prd_Code"].ToString() && dr["pkd_ID"].ToString() == drDetails["pbs_pkd_ID"].ToString())
                            {
                                listBatchSerial.Add(new GetPickingBatchSerial
                                {
                                    Number = drDetails["pbs_Number"].ToString(),
                                    ExpiryDate = drDetails["pbs_ExpiryDate"].ToString(),
                                    BaseUOM = drDetails["pbs_BaseUOM"].ToString(),
                                    RequestedQty = drDetails["pbs_RequestedQty"].ToString(),
                                    PickedQty = drDetails["pbs_PickQty"].ToString(),
                                    ItemCode = drDetails["prd_Code"].ToString(),
                                    ReasonId = drDetails["pbs_rsn_ID"].ToString(),
                                    UserId = drDetails["ModifedBy"].ToString(),
                                    EligibleQty = drDetails["bat_AvailbleQty"].ToString(),
                                    BatchID = drDetails["pbs_ID"].ToString(),
                                    pkd_ID = drDetails["pbs_pkd_ID"].ToString(),
                                    LineNo = drDetails["pkd_LineNo"].ToString(),
                                    Id = drDetails["prd_ID"].ToString(),
                                    Spec = drDetails["prd_Spec"].ToString(),
                                    adj_qty = drDetails["pkd_adjQty"].ToString(),
                                    ReservationNo = drDetails["Reservation"].ToString(),
                                    SalesMan = drDetails["pbs_SalesMan"].ToString()
                                  
                                   

                                });
                            }
                        }

                        listItems.Add(new GetPickingItemHeader
                        {
                            Id = Int32.Parse(dr["prd_ID"].ToString()),
                            Name = dr["prd_Name"].ToString(),
                            Code = dr["prd_Code"].ToString(),
                            Spec = dr["prd_Spec"].ToString(),
                            CategoryId = dr["prd_cat_ID"].ToString(),
                            SubcategoryId = dr["prd_sct_ID"].ToString(),
                            ReqHUOM = dr["pkd_RequestedHuom"].ToString(),
                            ReqLUOM = dr["pkd_RequestedLuom"].ToString(),
                            ReqHQty = dr["pkd_RequestedHQty"].ToString(),
                            ReqLQty = dr["pkd_RequestedLQty"].ToString(),
                            PickHQty = dr["pkd_PickedHQty"].ToString(),
                            PickLQty = dr["pkd_PickedLQty"].ToString(),
                            PromoType = dr["pkd_TransType"].ToString(),
                            ReasonId = dr["pkd_rsn_ID"].ToString(),
                            Desc = dr["prd_Desc"].ToString(),
                            LineNo = dr["pkd_LineNo"].ToString(),
                            pid_ID = dr["pkd_ID"].ToString(),
                            Weighing = dr["prd_WeighingItem"].ToString(),
                            PickHUom = dr["pkd_PickedHuom"].ToString(),
                            PickLUom = dr["pkd_PickedLuom"].ToString(),
                            EnableExcess = dr["pkd_excessQty"].ToString(),
                            LocationId = dr["pkh_str_ID"].ToString(),
                            LocationName = dr["str_Name"].ToString(),
                            Remarks = dr["pkh_Reason"].ToString(),
                            BatchSerial = listBatchSerial,
                            CatCode = dr["cat_Code"].ToString(),
                            CatName = dr["cat_Name"].ToString(),
                            SubCatCode = dr["sct_Code"].ToString(),
                            SubCatName = dr["sct_Name"].ToString(),
                            BrdID = dr["brd_ID"].ToString(),
                            BrdCode = dr["brd_Code"].ToString(),
                            BrdName = dr["brd_Name"].ToString(),
                            ArName =dr["prd_NameArabic"].ToString(),
                            ArDesc = dr["prd_ArabicItemLongDesc"].ToString(),
                            ArBrdName = dr["brd_NameArabic"].ToString(),
                            ArCatName= dr["cat_NameArabic"].ToString(),
                            ArSubCatName = dr["sct_NameArabic"].ToString()
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

        public string GetNewBatch([FromForm] PostPickUser inputParams)
        {
            dm.TraceService("GetNewBatch STARTED ");
            dm.TraceService("====================");
            string userID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string itemID = inputParams.itemID == null ? "0" : inputParams.itemID;

            string[] arr = { itemID };
            DataTable dtNewBatch = dm.loadList("SelectBatch", "sp_PickingWebServices", userID.ToString());
            try
            {
                if (dtNewBatch.Rows.Count > 0)
                {
                    List<GetNewBatch> listNewBatch = new List<GetNewBatch>();
                    foreach (DataRow dr in dtNewBatch.Rows)
                    {
                        listNewBatch.Add(new GetNewBatch
                        {
                            Id = Int32.Parse(dr["bat_ID"].ToString()),
                            Number = dr["bat_Number"].ToString(),
                            ExpiryDate = dr["bat_ExpiryDate"].ToString(),
                            AvailableQty = dr["bat_AvailbleQty"].ToString(),
                            SalesPerson = dr["bat_SalesPerson"].ToString(),
                            ArSalesPerson = dr["bat_Sales_ArPerson"].ToString()
                        });
                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listNewBatch
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
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(ex.Message.ToString());
            }
            dm.TraceService("GetNewBatch ENDED ");
            dm.TraceService("==================");
            return JSONString;
        }

        public string SelItemwiseSummary([FromForm] ItemwiseSummaryIn inputParams)
        {
            dm.TraceService("SelItemwiseSummary STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                List<PickingIds> PickingData = JsonConvert.DeserializeObject<List<PickingIds>>(inputParams.JsonString);
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                string InputXml = "";

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;
                        foreach (PickingIds id in PickingData)
                        {
                            string[] arr = { id.pkh_ID.ToString() };
                            string[] arrName = { "pkh_ID" };
                            dm.createNode(arr, arrName, writer);
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                    InputXml = sw.ToString();
                }

                string[] ar = { InputXml.ToString() };

                DataTable dtOrders = dm.loadList("SelItemwiseSummary", "sp_PickingWebServices", UserID.ToString(), ar);

                if (dtOrders.Rows.Count > 0)
                {
                    List<ItemwiseSummaryOut> listItems = new List<ItemwiseSummaryOut>();
                    foreach (DataRow dr in dtOrders.Rows)
                    {

                        listItems.Add(new ItemwiseSummaryOut
                        {
                         
                            prd_ID = dr["prd_ID"].ToString(),
                            TotalRequestedLQty = dr["TotalRequestedLQty"].ToString(),
                            TotalRequestedHQty = dr["TotalRequestedHQty"].ToString(),
                            pkd_RequestedHuom = dr["pkd_RequestedHuom"].ToString(),
                            pkd_RequestedLuom = dr["pkd_RequestedLuom"].ToString()

                        }); ;
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
                dm.TraceService(" SelItemwiseSummary Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelItemwiseSummary ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string GetPickParkAndParkRelease([FromForm] PostParkAndParkRelease inputParams)
        {
            dm.TraceService("GetPickParkAndParkRelease STARTED ");
            dm.TraceService("==================================");
            try
            {
                List<PostPickingItemData> itemData = JsonConvert.DeserializeObject<List<PostPickingItemData>>(inputParams.ItemData);
                List<PostPickingBatchData> batchData = JsonConvert.DeserializeObject<List<PostPickingBatchData>>(inputParams.BatchData);
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
                    dtBatch.Columns.Add("pkd_ID", typeof(string));
                    dtBatch.Columns.Add("SalesPerson", typeof(string));
                    dtBatch.Columns.Add("EligibleQty", typeof(string));
                    dtBatch.Columns.Add("BaseUOM", typeof(string));
                    foreach (var item in itemData)
                    {
                        dtItem.Rows.Add(item.ProductId, item.ProductHUOM, item.ProductLUOM, item.ProductHQty, item.ProductLQty, item.ReasonId, item.UserId, item.ModifiedOn, item.LineNumber);
                    }

                    foreach (var batch in batchData)
                    {
                        dtBatch.Rows.Add(batch.ProductId, batch.Number, batch.PickedQty, batch.ReasonId, batch.BatchMode, batch.ExpiryDate, batch.UserId, batch.ModifiedOn, batch.BatchID, batch.pkd_ID, batch.SalesPerson, batch.EligibleQty, batch.BaseUOM);
                    }

                    dsItemBatch.Tables.Add(dtItem);
                    dsItemBatch.Tables.Add(dtBatch);

                    try
                    {
                        string[] keys = { "@PickingId", "@UserId", "@Status" };
                        string[] values = { pickingID.ToString(), userID.ToString(), status.ToString() };
                        string[] arr = { "@ItemData", "@BatchData" };
                        DataSet Value = dm.bulkUpdate(dsItemBatch, arr, keys, values, "sp_CompletePicking");
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

            dm.TraceService("GetPickParkAndParkRelease ENDED ");
            dm.TraceService("================================");

            return JSONString;
        }

        public string GetPickingComplete([FromForm] PostCompletePicking inputParams)
        {
            dm.TraceService("GetPickingComplete STARTED ");
            dm.TraceService("===========================");
            try
            {
                List<PostPickingItemData> itemData = JsonConvert.DeserializeObject<List<PostPickingItemData>>(inputParams.ItemData);
                List<PostPickingBatchData> batchData = JsonConvert.DeserializeObject<List<PostPickingBatchData>>(inputParams.BatchData);
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
                    dtBatch.Columns.Add("pkd_ID", typeof(string));
                    dtBatch.Columns.Add("SalesPerson", typeof(string));
                    dtBatch.Columns.Add("EligibleQty", typeof(string));
                    dtBatch.Columns.Add("BaseUOM", typeof(string));
                    foreach (var item in itemData)
                    {
                        dtItem.Rows.Add(item.ProductId, item.ProductHUOM, item.ProductLUOM, item.ProductHQty, item.ProductLQty, item.ReasonId, item.UserId, item.ModifiedOn, item.LineNumber);
                    }

                    foreach (var batch in batchData)
                    {
                        dtBatch.Rows.Add(batch.ProductId, batch.Number, batch.PickedQty, batch.ReasonId, batch.BatchMode, batch.ExpiryDate, batch.UserId, batch.ModifiedOn, batch.BatchID, batch.pkd_ID, batch.SalesPerson, batch.EligibleQty, batch.BaseUOM);
                    }

                    dsItemBatch.Tables.Add(dtItem);
                    dsItemBatch.Tables.Add(dtBatch);

                    try
                    {
                        string[] keys = { "@PickingId", "@UserId", "@Status" };
                        string[] values = { pickingID.ToString(), userID.ToString(), status.ToString() };
                        string[] arr = { "@ItemData", "@BatchData" };
                        DataSet Value = dm.bulkUpdate(dsItemBatch, arr, keys, values, "sp_CompletePicking");
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

        public string GetPickHeaders([FromForm] PostPickUser inputParams)
        {
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetPickHeaders Started==========");
                string[] arr = { inputParams.RouteID };
                DataTable CI = dm.loadList("SelectAllPickHeader", "sp_PickingWebServices", UserID.ToString(), arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<GetAllPickingHeader> listItems = new List<GetAllPickingHeader>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new GetAllPickingHeader
                        {
                            PickingID = dr["pkh_ID"].ToString(),
                            Number = dr["pkh_Number"].ToString(),
                            UserID = dr["pkh_usr_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            Reason = dr["pkh_Reason"].ToString(),
                            StoreID = dr["pkh_str_ID"].ToString(),
                            Date = dr["Date"].ToString(),
                            store = dr["str_Name"].ToString(),
                            Mode = dr["mode"].ToString(),
                            User_ArName = dr["usr_ArabicName"].ToString(),
                            Arstore = dr["str_ArabicName"].ToString()

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
            dm.TraceService("==========GetPickHeaders End==========");
            return JSONString;
        }
        public string SelItemwiseSummaryOrders([FromForm] ItemwiseSummaryOrdersIn inputParams)
        {
            dm.TraceService("SelItemwiseSummaryOrders STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                List<PickingIds> PickingData = JsonConvert.DeserializeObject<List<PickingIds>>(inputParams.JsonString);
                string prdID = inputParams.prdID == null ? "0" : inputParams.prdID;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                string InputXml = "";

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;
                        foreach (PickingIds id in PickingData)
                        {
                            string[] arr = { id.pkh_ID.ToString() };
                            string[] arrName = { "pkh_ID" };
                            dm.createNode(arr, arrName, writer);
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                    InputXml = sw.ToString();
                }

                string[] ar = { UserID.ToString(), InputXml.ToString() };

                DataTable dtOrders = dm.loadList("SelItemwiseSummaryOrders", "sp_PickingWebServices", prdID.ToString(), ar);

                if (dtOrders.Rows.Count > 0)
                {
                    List<ItemwiseSummaryOrdersOut> listItems = new List<ItemwiseSummaryOrdersOut>();
                    foreach (DataRow dr in dtOrders.Rows)
                    {

                        listItems.Add(new ItemwiseSummaryOrdersOut
                        {
                            pih_ID = dr["pkh_ID"].ToString(),
                            ord_ERP_OrderNo = dr["OrderID"].ToString(),
                            pih_Number = dr["pkh_Number"].ToString(),
                            prd_ID = dr["prd_ID"].ToString(),
                            ord_Huom = dr["ord_Huom"].ToString(),
                            ord_Hqty = dr["ord_Hqty"].ToString(),
                            pid_HigherQty = dr["pkd_PickedHQty"].ToString(),
                            pid_HigherUOM = dr["pkd_PickedHuom"].ToString(),
                            pid_LowerQty = dr["pkd_PickedLQty"].ToString(),
                            pid_LowerUOM= dr["pkd_PickedLuom"].ToString(),
                            ord_ExpectedDelDate = dr["ord_ExpectedDelDate"].ToString(),
                            prd_WeighingItem = dr["prd_WeighingItem"].ToString(),
                            ord_ID = dr["ord_ID"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            csh_Name = dr["csh_Name"].ToString(),
                            csh_Code = dr["csh_Code"].ToString(),
                            pih_Remarks = dr["pkh_Reason"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            usr_ContactNo = dr["usr_ContactNo"].ToString(),
                            ModifiedDate = dr["ModifiedDate"].ToString(),
                            pih_Status = dr["Status"].ToString(),
                            pid_LineNo = dr["pkd_LineNo"].ToString(),
                            plm_Name = dr["str_Name"].ToString(),
                            ord_Luom = dr["ord_Luom"].ToString(),
                            ord_Lqty = dr["ord_Luom"].ToString(),
                            usr_ArName=dr["usr_ArabicName"].ToString()
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
                dm.TraceService(" SelItemwiseSummaryOrders Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelItemwiseSummaryOrders ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelOrderPickingOngoing([FromForm] PostPickUser inputParams)
        {
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========SelOrderPickingOngoing Started==========");
               
                DataTable CI = dm.loadList("SelOrderPickingOngoing", "sp_PickingWebServices", UserID.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<OngoingOrderPick> listItems = new List<OngoingOrderPick>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new OngoingOrderPick
                        {
                            PickingID = dr["pkh_ID"].ToString(),
                            PickListNumber = dr["pkh_Number"].ToString(),
                            UserID = dr["pkh_usr_ID"].ToString(),
                            pih_Status = dr["Status"].ToString(),
                            pih_Remarks = dr["pkh_Reason"].ToString(),
                            ord_ID = dr["pkh_ord_ID"].ToString(),
                            ExpectedDelDate = dr["ord_ExpectedDelDate"].ToString(),
                            Picker = dr["usr_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            CusHeaderCode = dr["csh_Code"].ToString(),
                            CusHeaderName = dr["csh_Name"].ToString(),
                            str_ID= dr["str_ID"].ToString(),
                            str_Name= dr["str_Name"].ToString(),
                            str_Code= dr["str_Code"].ToString(),



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
            dm.TraceService("==========SelOrderPickingOngoing End==========");
            return JSONString;
        }

    }
}