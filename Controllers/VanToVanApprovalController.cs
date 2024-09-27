using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using static MVC_API.Models.VanToVanApprovalHelper;

namespace MVC_API.Controllers
{
    public class VanToVanApprovalController : Controller
    {
        // GET: VanToVanApproval
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]

        public string GetVanToVanApprovalHeaderStatus([FromForm] PostLodVantoVanApprovalStatusData inputParams)
        {
            dm.TraceService("GetVanToVanApprovalHeaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { userID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForLoadTransReqApprovalHeader", "sp_SFA_App", TransID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetVantovanApprovalHeaderStatus> listHeader = new List<GetVantovanApprovalHeaderStatus>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetVantovanApprovalHeaderStatus
                        {
                            ApprovalStatus = dr["Approval_Status"].ToString()

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
                dm.TraceService("GetVanToVanApprovalHeaderStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetVanToVanApprovalHeaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string GetVanToVanApprovalDetailStatus([FromForm] PostLodVantoVanApprovalDetailStatusData inputParams)
        {
            dm.TraceService("GetVanToVanApprovalDetailStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { userID.ToString() };
            DataTable dtDeliveryStatus = dm.loadList("SelStatusForVantovanApprovalDetail", "sp_SFA_App", TransID.ToString(), arr);

            try
            {
                if (dtDeliveryStatus.Rows.Count > 0)
                {
                    List<GetVantovanApprovalDetailStatus> listHeader = new List<GetVantovanApprovalDetailStatus>();
                    foreach (DataRow dr in dtDeliveryStatus.Rows)
                    {
                        listHeader.Add(new GetVantovanApprovalDetailStatus
                        {
                            ApprovalStatus = dr["Status"].ToString(),
                            ApprovalHQty = dr["vvd_Approval_HQty"].ToString(),
                            ApprovalLQty = dr["vvd_Approval_LQty"].ToString(),
                            Item_ID = dr["vvd_prd_ID"].ToString()


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
                dm.TraceService("GetVanToVanApprovalDetailStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetVanToVanApprovalDetailStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    }
}