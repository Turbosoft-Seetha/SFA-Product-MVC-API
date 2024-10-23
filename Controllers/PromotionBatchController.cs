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
    public class PromotionBatchController : Controller
    {
        // GET: PromotionBatch
        DataModel dm = new DataModel();
        string JSONString = string.Empty;


        [System.Web.Http.HttpPost]

        public string SelPromoAssignItem([FromForm] PromotionBatchDetailIn inputParams)
        {
            dm.TraceService("SelPromoAssignItem STARTED ");
            dm.TraceService("====================");
            try
            {
                string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;

                string[] arr = { cus_ID };
                DataSet dtstkItemBatch = dm.loadListDS("SelPromoItemBatch", "sp_SFA_App_Sales", rotID, arr);
                DataTable itemData = dtstkItemBatch.Tables[0];
                DataTable batchData = dtstkItemBatch.Tables[1];
                if (itemData.Rows.Count > 0)
                {
                    List<PromotionBatchDetailOut> listItems = new List<PromotionBatchDetailOut>();
                    foreach (DataRow dr in itemData.Rows)
                    {
                        List<PromotionBatchSerial> listBatchSerial = new List<PromotionBatchSerial>();
                        foreach (DataRow drDetails in batchData.Rows)
                        {
                            if (dr["sld_ID"].ToString() == drDetails["pib_sld_id"].ToString() && dr["sld_itm_ID"].ToString() == drDetails["pib_prd_ID"].ToString())
                            {
                                listBatchSerial.Add(new PromotionBatchSerial
                                {                                    
                                    pib_ID = drDetails["pib_ID"].ToString(),
                                    pib_Number = drDetails["pib_Number"].ToString(),
                                    pib_ExpiryDate = drDetails["pib_ExpiryDate"].ToString(),
                                    pib_BaseUOM = drDetails["pib_BaseUOM"].ToString(),
                                    pib_Qty = drDetails["pib_Qty"].ToString(),
                                    pib_sal_id = drDetails["pib_sal_id"].ToString(),
                                    pib_sld_id = drDetails["pib_sld_id"].ToString(),
                                    pib_prd_ID = drDetails["pib_prd_ID"].ToString(),


                                });
                            }
                        }

                        listItems.Add(new PromotionBatchDetailOut
                        {
                            spa_prd_ID = dr["spa_prd_ID"].ToString(),
                            ElgQty = dr["ElgQty"].ToString(),
                            spi_QualifiedQty = dr["spi_QualifiedQty"].ToString(),
                            prd_IsBatchItem = dr["prd_IsBatchItem"].ToString(),
                            BatchSerial = listBatchSerial,

                            //sal_number = dr["sal_number"].ToString(),
                            //sal_ID = dr["sal_ID"].ToString(),
                            //sld_itm_ID = dr["sld_itm_ID"].ToString(),
                            //sld_HQty = dr["sld_HQty"].ToString(),
                            //sld_PieceQty = dr["sld_PieceQty"].ToString(),
                            //sal_cus_ID = dr["sal_cus_ID"].ToString(),
                            //inv_InvoiceID = dr["inv_InvoiceID"].ToString(),
                            //sld_HigherUOM = dr["sld_HigherUOM"].ToString(),
                            //sld_LowerUOM = dr["sld_LowerUOM"].ToString(),
                            //sld_HUOMRtnAmount = dr["sld_HUOMRtnAmount"].ToString(),
                            //sld_LUOMRtnAmount = dr["sld_LUOMRtnAmount"].ToString(),
                            //ind_Discount = dr["ind_Discount"].ToString(),
                            //ind_PieceDiscount = dr["ind_PieceDiscount"].ToString(),
                            //BalanceAmount = dr["BalanceAmount"].ToString(),
                            //spa_prm_ID = dr["spa_prm_ID"].ToString(),
                            //prt_Value = dr["prt_Value"].ToString(),
                            //sld_TransType = dr["sld_TransType"].ToString(),
                            //CreatedDate = dr["CreatedDate"].ToString(),

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

            dm.TraceService("SelPromoAssignItem ENDED ");
            dm.TraceService("====================");

            return JSONString;
        }
    }
}