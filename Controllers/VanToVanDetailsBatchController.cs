using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System.Configuration;

namespace MVC_API.Controllers
{
    public class VanToVanDetailsBatchController : Controller
    {
        // GET: VanToVanDetailsBatch
        // GET: VanstockBatch
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]


        public string GetVanToVanDetailsBatch([FromForm] GetVanToVanDetailsBatchIN inputParams)
        {
            dm.TraceService("GetVanToVanDetailsBatch STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string userID = inputParams.userID == null ? "0" : inputParams.userID;

            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string[] arr = { userID.ToString() };
            DataSet dtVantovan = dm.loadListDS("SelVantoVanTransferConfirmDetail", "sp_SFA_App", TransID.ToString(), arr);
            DataTable DetailData = dtVantovan.Tables[0];
            DataTable BatchData = dtVantovan.Tables[1];

            try
            {
                if (DetailData.Rows.Count > 0)
                {
                    List<GetVanToVanBatchDetails> listHeader = new List<GetVanToVanBatchDetails>();
                    foreach (DataRow dr in DetailData.Rows)
                    {

                        List<GetVanToVanBatch> listBatch = new List<GetVanToVanBatch>();
                        foreach (DataRow drBatch in BatchData.Rows)
                        {

                            if (dr["vvd_ID"].ToString() == drBatch["vvb_vvd_ID"].ToString())
                            {
                                listBatch.Add(new GetVanToVanBatch
                                {
                                    vvb_Number = drBatch["vvb_Number"].ToString(),
                                    vvb_ExpiryDate = drBatch["vvb_ExpiryDate"].ToString(),
                                    vvb_BaseUOM = drBatch["vvb_BaseUOM"].ToString(),
                                    vvb_OrderedQty = drBatch["vvb_OrderedQty"].ToString(),
                                    vvb_AdjustedQty = drBatch["vvb_AdjustedQty"].ToString(),
                                    vvb_LoadInQty = drBatch["vvb_LoadInQty"].ToString(),
                                    vvb_prd_ID = drBatch["vvb_prd_ID"].ToString(),
                                    vvb_vvd_ID = drBatch["vvb_vvd_ID"].ToString()
                                });
                            }

                        }




                        listHeader.Add(new GetVanToVanBatchDetails
                        {

                            ItemID = dr["vvd_prd_ID"].ToString(),
                            HUOM = dr["vvd_HUOM"].ToString(),
                            HQty = dr["vvd_HQty"].ToString(),
                            LUOM = dr["vvd_LUOM"].ToString(),
                            LQty = dr["vvd_LQty"].ToString(),
                            ConfirmHUOM = dr["vvd_ConfirmHUOM"].ToString(),
                            ConfirmHQty = dr["vvd_ConfirmHQty"].ToString(),
                            ConfirmLUOM = dr["vvd_ConfirmLUOM"].ToString(),
                            ConfirmLQty = dr["vvd_ConfirmLQty"].ToString(),
                            AdjHQty = dr["AdjHQty"].ToString(),
                            AdjLQty = dr["AdjLQty"].ToString(),
                            VanToVanBatch = listBatch,
                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listHeader
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
                dm.TraceService(ex.Message.ToString());
                JSONString = "GetVanToVanDetailsBatch - " + ex.Message.ToString();
            }
            dm.TraceService("GetVanToVanDetailsBatch ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

    }
}