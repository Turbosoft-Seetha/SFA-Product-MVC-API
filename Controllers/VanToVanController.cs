using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class VanToVanController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string SelectVanToVanTransferInDetail([FromForm] VanToVanDetailIn inputParams)
        {
            dm.TraceService("SelectVanToVanTransferInDetail STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
            string userID = inputParams.userID == null ? "0" : inputParams.userID;

            string[] arr = { userID };
            DataSet dt = dm.loadListDS("SelectVantoVanTransferInDetail", "sp_SFA_App", HeaderID, arr);
            DataTable DetailData = dt.Tables[0];
            DataTable BatchData = dt.Tables[1];

            try
            {
                if (DetailData.Rows.Count > 0)
                {
                    List<VanToVanDetailOut> listDetail = new List<VanToVanDetailOut>();
                    foreach (DataRow dr in DetailData.Rows)
                    {

                        List<VanToVanBatchSerial> listBatch = new List<VanToVanBatchSerial>();
                        foreach (DataRow drs in BatchData.Rows)
                        {
                            if (dr["vvd_ID"].ToString() == drs["vvb_vvd_ID"].ToString() && dr["vvd_vvh_ID"].ToString() == drs["vvb_vvh_ID"].ToString())
                            {
                                listBatch.Add(new VanToVanBatchSerial
                                {
                                    vvb_ID = drs["vvb_ID"].ToString(),
                                    vvb_vvh_ID = drs["vvb_vvh_ID"].ToString(),
                                    vvb_vvd_ID = drs["vvb_vvd_ID"].ToString(),
                                    vvb_Number = drs["vvb_Number"].ToString(),
                                    vvb_ExpiryDate = drs["vvb_ExpiryDate"].ToString(),
                                    vvb_BaseUOM = drs["vvb_BaseUOM"].ToString(),
                                    vvb_OrderedQty = drs["vvb_OrderedQty"].ToString(),
                                    vvb_AdjustedQty = drs["vvb_AdjustedQty"].ToString(),
                                    vvb_LoadInQty = drs["vvb_LoadInQty"].ToString(),
                                });
                            }
                        }

                        listDetail.Add(new VanToVanDetailOut
                        {
                            vvd_ID = dr["vvd_ID"].ToString(),
                            vvd_vvh_ID = dr["vvd_vvh_ID"].ToString(),
                            vvd_prd_ID = dr["vvd_prd_ID"].ToString(),
                            vvd_HUOM = dr["vvd_HUOM"].ToString(),
                            vvd_LUOM = dr["vvd_LUOM"].ToString(),
                            vvd_HQty = dr["vvd_HQty"].ToString(),
                            vvd_LQty = dr["vvd_LQty"].ToString(),
                           
                            BatchDetail = listBatch,
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
                dm.TraceService("SelectVanToVanTransferInDetail - Error :   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectVanToVanTransferInDetail ENDED ");
            dm.TraceService("======================================");

            return JSONString;
        }
    }
}