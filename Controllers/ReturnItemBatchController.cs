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

namespace MVC_API.Controllers
{
    public class ReturnItemBatchController : Controller
    {
        // GET: ReturnItemBatch
        DataModel dm = new DataModel();
        string JSONString = string.Empty;


        [System.Web.Http.HttpPost]

        public string SelectReturnwithBatch([FromForm] ReturnBatchDetailIn inputParams)
        {
            dm.TraceService("SelectReturnwithBatch STARTED ");
            dm.TraceService("====================");
            try
            {
                string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;

                string[] arr = { cusID };
                DataSet dtstkItemBatch = dm.loadListDS("SelReturnItems", "sp_SFA_App", rotID, arr);
                DataTable itemData = dtstkItemBatch.Tables[0];
                DataTable batchData = dtstkItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<ReturnBatchDetailOut> listItems = new List<ReturnBatchDetailOut>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<RTNBatchSerial> listBatchSerial = new List<RTNBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["sld_ID"].ToString() == drDetails["slb_sld_ID"].ToString() && dr["sld_itm_ID"].ToString() == drDetails["sld_itm_ID"].ToString())
                            {
                                listBatchSerial.Add(new RTNBatchSerial
                                {

                                    slb_sal_ID = drDetails["slb_sal_ID"].ToString(),
                                    slb_sld_ID = drDetails["slb_sld_ID"].ToString(),
                                    slb_Number = drDetails["slb_Number"].ToString(),
                                    slb_ExpiryDate = drDetails["slb_ExpiryDate"].ToString(),
                                    slb_BaseUOM = drDetails["slb_BaseUOM"].ToString(),
                                    slb_OrderedQty = drDetails["slb_OrderedQty"].ToString(),
                                    slb_AdjustedQty = drDetails["slb_AdjustedQty"].ToString(),
                                    slb_LoadInQty = drDetails["slb_LoadInQty"].ToString(),
                                    inv_InvoiceID = drDetails["inv_InvoiceID"].ToString(),
                                    sld_itm_ID = drDetails["sld_itm_ID"].ToString(),
                                    slb_id= drDetails["slb_id"].ToString(),

                                });
                            }
                        }

                        listItems.Add(new ReturnBatchDetailOut
                        {
                            sal_number = dr["sal_number"].ToString(),
                            sal_ID = dr["sal_ID"].ToString(),
                            sld_itm_ID = dr["sld_itm_ID"].ToString(),
                            sld_HQty = dr["sld_HQty"].ToString(),
                            sld_PieceQty = dr["sld_PieceQty"].ToString(),
                            sal_cus_ID = dr["sal_cus_ID"].ToString(),
                            inv_InvoiceID = dr["inv_InvoiceID"].ToString(),
                            sld_HigherUOM = dr["sld_HigherUOM"].ToString(),
                            sld_LowerUOM = dr["sld_LowerUOM"].ToString(),
                            sld_HUOMRtnAmount = dr["sld_HUOMRtnAmount"].ToString(),
                            sld_LUOMRtnAmount = dr["sld_LUOMRtnAmount"].ToString(),
                            ind_Discount = dr["ind_Discount"].ToString(),
                            ind_PieceDiscount = dr["ind_PieceDiscount"].ToString(),
                            BalanceAmount = dr["BalanceAmount"].ToString(),
                            slq_prm_ID = dr["slq_prm_ID"].ToString(),
                            prt_Value = dr["prt_Value"].ToString(),
                            sld_TransType = dr["sld_TransType"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            BatchSerial = listBatchSerial,
                            prd_IsBatchItem = dr["prd_IsBatchItem"].ToString()


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

            dm.TraceService("SelectReturnwithBatch ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }
    }
}