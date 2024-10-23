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
                            if (dr["sld_ID"].ToString() == drDetails["slb_sld_ID"].ToString() && dr["sld_itm_ID"].ToString() == drDetails["sld_itm_ID"].ToString())
                            {
                                listBatchSerial.Add(new PromotionBatchSerial
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
                                    slb_id = drDetails["slb_id"].ToString(),

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