using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.BatchHelper;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers.Batch
{
    public class LoadInBatchController: Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

       
        [System.Web.Http.HttpPost]

        public string SelectLIDetailwithBatch([FromForm] LoadInBatchDetailIn inputParams)
        {
            dm.TraceService("GetGRNItemBatch STARTED ");
            dm.TraceService("====================");
            try
            {


                string[] arr = { inputParams.rotID };
                DataSet dtstkItemBatch = dm.loadListDS("SelLoadInDetail", "sp_SFAUOM_Loadin", inputParams.lid_lih_ID, arr);
                DataTable itemData = dtstkItemBatch.Tables[0];
                DataTable batchData = dtstkItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<LoadInBatchDetailOut> listItems = new List<LoadInBatchDetailOut>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<LIDBatchSerial> listBatchSerial = new List<LIDBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["lid_id"].ToString() == drDetails["lis_lid_ID"].ToString() && dr["lid_prd_ID"].ToString() == drDetails["lid_prd_ID"].ToString())
                            {
                                listBatchSerial.Add(new LIDBatchSerial
                                {

                                    Lid = drDetails["lis_lih_ID"].ToString(),
                                    LIDetailID = drDetails["lis_lid_ID"].ToString(),
                                    Batch = drDetails["lis_Number"].ToString(),
                                    ExpiryDate = drDetails["lis_ExpiryDate"].ToString(),
                                    BaseUOM = drDetails["lis_BaseUOM"].ToString(),
                                    orderedQty = drDetails["lis_OrderedQty"].ToString(),
                                    AdjQty = drDetails["lis_AdjustedQty"].ToString(),
                                    LIQty = drDetails["lis_LoadInQty"].ToString(),
                                    prdid = drDetails["lid_prd_ID"].ToString(),
                                    BatchID = drDetails["lis_ID"].ToString()

                                });
                            }
                        }

                        listItems.Add(new LoadInBatchDetailOut
                        {
                            lid_prd_ID = dr["lid_prd_ID"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            lid_ID = dr["lid_ID"].ToString(),
                            EndStock_H_UOM = dr["EndStock_H_UOM"].ToString(),
                            lod_EndStock_H_Qty = dr["lod_EndStock_H_Qty"].ToString(),
                            EndStock_L_UOM = dr["EndStock_L_UOM"].ToString(),
                            lod_EndStock_L_Qty = dr["lod_EndStock_L_Qty"].ToString(),
                            Fresh_H_UOM = dr["Fresh_H_UOM"].ToString(),
                            lid_HigherQty = dr["lid_HigherQty"].ToString(),
                            Fresh_L_UOM = dr["Fresh_L_UOM"].ToString(),
                            lid_LowerQty = dr["lid_LowerQty"].ToString(),
                            Final_H_UOM = dr["Final_H_UOM"].ToString(),
                            Final_H_Qty = dr["Final_H_Qty"].ToString(),
                            Final_L_UOM = dr["Final_L_UOM"].ToString(),
                            Final_L_Qty = dr["Final_L_Qty"].ToString(),
                            Adj_H_UOM = dr["Adj_H_UOM"].ToString(),
                            Adj_L_UOM = dr["Adj_L_UOM"].ToString(),
                            lid_AdjHigherQty = dr["lid_AdjHigherQty"].ToString(),
                            lid_AdjLowerQty = dr["lid_AdjLowerQty"].ToString(),
                            LI_H_UOM = dr["LI_H_UOM"].ToString(),
                            LI_H_Qty = dr["LI_H_Qty"].ToString(),
                            LI_L_UOM = dr["LI_L_UOM"].ToString(),
                            LI_L_Qty = dr["LI_L_Qty"].ToString(),
                            prd_cat_ID = dr["prd_cat_ID"].ToString(),
                            prd_sct_ID = dr["prd_sct_ID"].ToString(),
                            BatchSerial = listBatchSerial,
                            prd_IsBatchItem = dr["prd_IsBatchItem"].ToString(),


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

        public string GetOpenStocks([FromForm] GetOpenStocksIn inputParams)
        {
            dm.TraceService("GetOpenStocks STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string rotID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string[] arr = { udpID.ToString() };
            DataSet dtreturn = dm.loadListDS("SelOpeningStock", "sp_SFAUOM_Loadin", rotID.ToString(), arr);

            if (dtreturn.Tables.Count < 3)
            {
                dm.TraceService("NoDataRes - Not enough tables in DataSet");
                return "NoDataRes";
            }

            DataTable HeaderData = dtreturn.Tables[0];
            DataTable DetailData = dtreturn.Tables[1];
            DataTable BatchData = dtreturn.Tables[2];

            if (HeaderData == null || HeaderData.Rows.Count == 0)
            {
                dm.TraceService("NoDataRes - HeaderData is empty");
                return "NoDataRes";
            }

            try
            {
                List<GetOpenStocksHeader> listHeader = new List<GetOpenStocksHeader>();
                foreach (DataRow dr in HeaderData.Rows)
                {
                    List<GetOpenStocksDetail> listDetail = new List<GetOpenStocksDetail>();
                    foreach (DataRow drDetails in DetailData.Rows)
                    {
                        List<GetOpenStocksBatch> listBatch = new List<GetOpenStocksBatch>();
                        foreach (DataRow drBatch in BatchData.Rows)
                        {
                            if (drDetails["lid_lih_ID"].ToString() == drBatch["lis_lih_ID"].ToString() && drDetails["lid_ID"].ToString() == drBatch["lis_lid_ID"].ToString())
                            {
                                listBatch.Add(new GetOpenStocksBatch
                                {
                                    lis_ID = drBatch["lis_ID"].ToString(),
                                    lis_lih_ID = drBatch["lis_lih_ID"].ToString(),
                                    lis_lid_ID = drBatch["lis_lid_ID"].ToString(),
                                    lis_Number = drBatch["lis_Number"].ToString(),
                                    lis_ExpiryDate = drBatch["lis_ExpiryDate"].ToString(),
                                    lis_BaseUOM = drBatch["lis_BaseUOM"].ToString(),
                                    lis_OrderedQty = drBatch["lis_OrderedQty"].ToString(),
                                    lis_AdjustedQty = drBatch["lis_AdjustedQty"].ToString(),
                                    lis_LoadInQty = drBatch["lis_LoadInQty"].ToString()
                                });
                            }
                        }

                        if (drDetails["lid_lih_ID"].ToString() == dr["lih_ID"].ToString())
                        {
                            listDetail.Add(new GetOpenStocksDetail
                            {
                                prd_ID = drDetails["lid_prd_ID"].ToString(),
                                HUOM = drDetails["lid_OpenHigherUom"].ToString(),
                                HQty = drDetails["lid_OpenHigherQty"].ToString(),
                                LUOM = drDetails["lid_OpenLowerUom"].ToString(),
                                LQty = drDetails["lid_OpenLowerQty"].ToString(),
                                RequestBatch = listBatch,
                                prd_IsBatchItem = drDetails["prd_IsBatchItem"].ToString(),


                            });
                        }
                    }

                    listHeader.Add(new GetOpenStocksHeader
                    {
                        HeaderID = dr["lih_ID"].ToString(),
                        TransID = dr["lih_TransID"].ToString(),
                        TransDate = dr["TransDate"].ToString(),
                        RequestDetail = listDetail
                    });
                }

                string JSONString = JsonConvert.SerializeObject(new
                {
                    result = listHeader
                });

                return JSONString;
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message);
                return "GetOpenStocks - " + ex.Message;
            }
            finally
            {
                dm.TraceService("GetOpenStocks ENDED " + DateTime.Now.ToString());
                dm.TraceService("======================================");
            }
        }
    }
}