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
    public class VanstockBatchController : Controller
    {
        // GET: VanstockBatch
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]

        public string GetVanstockBatch([FromForm] GetVanstockBatchIN inputParams)
        {
            dm.TraceService("GetReturnRequest STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string userID = inputParams.userID == null ? "0" : inputParams.userID;

            string vsn_udpID = inputParams.vsn_udpID == null ? "0" : inputParams.vsn_udpID;
            string[] arr = { userID.ToString() };
            DataSet dtreturn = dm.loadListDS("SelVanstock", "sp_SFA_App", vsn_udpID.ToString(), arr);
            DataTable HeaderData = dtreturn.Tables[0];
            DataTable BatchData = dtreturn.Tables[1];

            try
            {
                if (HeaderData.Rows.Count > 0)
                {
                    List<GetVanstokeBatchHeader> listHeader = new List<GetVanstokeBatchHeader>();
                    foreach (DataRow dr in HeaderData.Rows)
                    {
                       
                            List<GetVanstokeBatch> listBatch = new List<GetVanstokeBatch>();
                            foreach (DataRow drBatch in BatchData.Rows)
                            {

                                if (dr["vsn_ID"].ToString() == drBatch["vsb_vsn_ID"].ToString())
                                {
                                    listBatch.Add(new GetVanstokeBatch
                                    {
                                        vsb_ID = drBatch["vsb_ID"].ToString(),
                                        vsb_Code = drBatch["vsb_Code"].ToString(),
                                        vsb_vsn_ID = drBatch["vsb_vsn_ID"].ToString(),
                                        vsb_Qty = drBatch["vsb_Qty"].ToString(),
                                        CreatedDate = drBatch["CreatedDate"].ToString(),
                                        vsb_prd_ID = drBatch["vsb_prd_ID"].ToString(),
                                        vsb_Date = drBatch["vsb_Date"].ToString(),
                                        BaseUOM = drBatch["baseUom"].ToString()
                                    });
                                }

                            }

                         
                        

                        listHeader.Add(new GetVanstokeBatchHeader
                        {

                            vsn_ID = dr["vsn_ID"].ToString(),
                            vsn_udp_ID = dr["vsn_udp_ID"].ToString(),
                            vsn_rot_ID = dr["vsn_rot_ID"].ToString(),
                            vsn_prd_ID = dr["vsn_prd_ID"].ToString(),
                            vsn_Qty = dr["vsn_Qty"].ToString(),
                            vsn_Type = dr["vsn_Type"].ToString(),
                            VanstockBatch = listBatch,
                            prd_IsBatchItem = dr["prd_IsBatchItem"].ToString()
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
                JSONString = "GetReturnRequest - " + ex.Message.ToString();
            }
            dm.TraceService("GetReturnRequest ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }

    }
}