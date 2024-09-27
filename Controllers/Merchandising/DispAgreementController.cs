using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.MerchandisingHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers.Merchandising
{
    public class DispAgreementController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]
        public string GetDispAgreements([FromForm] DispAgreementIn inputParams)
        {
            dm.TraceService("GetDispAgreements STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string CusID = inputParams.rotID == null ? "0" : inputParams.rotID;

            DataTable dt = dm.loadList("SelDispAgreements", "sp_MerchandisingWebServices", CusID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<DispAgreementsOut> listHeader = new List<DispAgreementsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new DispAgreementsOut
                        {
                            dag_ID = dr["dag_ID"].ToString(),
                            dag_Number = dr["dag_Number"].ToString(),
                            dag_StartDay = dr["dag_StartDate"].ToString(),
                            dag_EndDay = dr["dag_EndDate"].ToString(),
                            dag_Type = dr["agt_Name"].ToString(),
                            dag_Status = dr["Status"].ToString(),
                            Date= dr["CreatedDate"].ToString(),

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
                dm.TraceService("GetDispAgreements  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetDispAgreements ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }



        public string GetActiveDispAgreements([FromForm] DispAgreementActIn inputParams)
        {
            dm.TraceService("GetDispAgreements STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string CusID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

            string[] arr = { udp_ID.ToString() };
            DataTable dt = dm.loadList("SelActiveDispAgreements", "sp_MerchandisingWebServices", CusID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<DispAgreementsActOut> listHeader = new List<DispAgreementsActOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new DispAgreementsActOut
                        {
                            dag_ID = dr["dag_ID"].ToString(),
                            dag_Number = dr["dag_Number"].ToString(),
                            dag_StartDay = dr["dag_StartDate"].ToString(),
                            dag_EndDay = dr["dag_EndDate"].ToString(),
                            dag_Type = dr["agt_Name"].ToString(),
                            dag_Status = dr["Status"].ToString(),
                            Date= dr["CreatedDate"].ToString(),

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
                dm.TraceService("GetDispAgreements  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetDispAgreements ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    }
}