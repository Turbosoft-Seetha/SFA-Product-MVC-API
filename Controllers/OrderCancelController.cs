using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class OrderCancelController : Controller
    {
        // GET: OrderCancel
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]

        public string CancelDelOrder([FromForm] CancelDelOrderInparas inputParams)
        {
            dm.TraceService("CancelDelOrder STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;
            string OrdId = inputParams.OrdId == null ? "0" : inputParams.OrdId;
            string UserId= inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { Status_Value, UserId };

            DataTable dt = dm.loadList("CancelDelOrders", "sp_SFA_App", OrdId,arr);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CancelDelOrderOutparas> list = new List<CancelDelOrderOutparas>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new CancelDelOrderOutparas
                        {
                            Res = dr["Res"].ToString(),
                            Desc = dr["Desc"].ToString(),                          

                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = list
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
                dm.TraceService("GetUnAssigned  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CancelDelOrder ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }

}