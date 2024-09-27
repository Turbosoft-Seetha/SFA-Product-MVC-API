using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVC_API.Models.AssetRemReq;

namespace MVC_API.Controllers
{
    public class JourneyPlanController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string InsJourneyPlanSeqRequest([FromForm] InJourneyPlan inputParams)
        {
            {
                dm.TraceService("InsJourneyPlanSeqRequest STARTED ");
                dm.TraceService("==============================");

                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string rotId = inputParams.rotID == null ? "0" : inputParams.rotID;
                string cusID = inputParams.cusID == null ? "0" : inputParams.cusID;
                string udpId = inputParams.udpID == null ? "0" : inputParams.udpID;
                string PrevSeq = inputParams.PrevSeq == null ? "0" : inputParams.PrevSeq;
                string CurrentSeq = inputParams.CurrentSeq == null ? "0" : inputParams.CurrentSeq;
                string rsnID= inputParams.rsnID == null ? "0" : inputParams.rsnID;



                try
                {
                    var HttpReq = HttpContext.Request;
                    dm.TraceService("HttpReq : " + HttpReq);
                    try
                    {
                        
                        string[] ar = { cusID,udpId, PrevSeq, CurrentSeq, rsnID };
                        DataTable dtDN = dm.loadList("InsJourneyReq", "sp_SFA_APP", rotId, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<OutJourneyPlan> listDn = new List<OutJourneyPlan>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new OutJourneyPlan
                                {
                                    res = dr["res"].ToString(),
                                    des = dr["Des"].ToString(),


                                });
                            }
                            JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listDn
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

            dm.TraceService("InsJourneyPlanSeqRequest ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }
    }
}