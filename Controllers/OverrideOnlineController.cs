using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using System.Xml;

namespace MVC_API.Controllers
{
    public class OverrideOnlineController : Controller
    {
        // GET: OrderCancel
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]

        public string InsOverrideOnlineApproval([FromForm] OverrideApprIn inputParams)
        {
            dm.TraceService("InsOverrideOnlineApproval STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            try
            {            

                string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;
                string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
                string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string Type = inputParams.Type == null ? "" : inputParams.Type;
                string ff1 = inputParams.ff1 == null ? "" : inputParams.ff1;
                string ff2 = inputParams.ff2 == null ? "" : inputParams.ff2;
                string ff3 = inputParams.ff3 == null ? "" : inputParams.ff3;
                string ff4 = inputParams.ff4 == null ? "" : inputParams.ff4;
                string ff5 = inputParams.ff5 == null ? "" : inputParams.ff5;

                string[] ar = {udp_ID.ToString(), rot_ID.ToString(), cus_ID.ToString(), Type.ToString(),ff1.ToString() , ff2.ToString(), ff3.ToString(), ff4.ToString(), ff5.ToString()};
                DataTable dt = dm.loadList("InsOverrideApproval", "sp_OverrideOnline", cse_ID.ToString(), ar);


                if (dt.Rows.Count > 0)
                {
                    List<OverrideApprOut> listoutput = new List<OverrideApprOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listoutput.Add(new OverrideApprOut
                        {
                            Res = dr["Res"].ToString(),
                            Title = dr["Title"].ToString(),
                            Descr = dr["Descr"].ToString(),
                            TransID = dr["TransID"].ToString()


                        });
                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listoutput
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
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(" InsOverrideOnlineApproval Exception - " + ex.Message.ToString());
                dm.TraceService(ex.Message.ToString());
            }
            dm.TraceService("InsOverrideOnlineApproval ENDED - " + DateTime.Now.ToString());
            dm.TraceService("==================");
            return JSONString;
        }       
        public string GeStatusForOverrideApproval([FromForm] GetOverrideApprDetailStatusIn inputParams)
        {
            dm.TraceService("GeStatusForOverrideApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            string[] arr = { rotID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelStatusForOverrideApproval", "sp_OverrideOnline", TransID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<GetOverrideApprDetailStatusOut> listHeader = new List<GetOverrideApprDetailStatusOut>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new GetOverrideApprDetailStatusOut
                        {
                            Status = dr["ooa_ApprovalStatus"].ToString()

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
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GeStatusForOverrideApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            return JSONString;
        }
    }

}