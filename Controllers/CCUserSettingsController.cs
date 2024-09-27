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
    public class CCUserSettingsController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]

        public string GetCCUserSettings([FromForm] GetCCUserSettingsIn inputParams)
        {
            dm.TraceService("GetCCUserSettings STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                try
                {
                    string usrID = inputParams.usrID == null ? "0" : inputParams.usrID;
                    try
                    {
                        DataTable dt = dm.loadList("SelCCUserSettings", "sp_CustomerConnect", usrID.ToString());
                        if (dt.Rows.Count > 0)
                        {
                            List<GetCCUserSettingsOut> listHeader = new List<GetCCUserSettingsOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetCCUserSettingsOut
                                {
                                    ParentNode = dr["ccs_ParentNode"].ToString(),
                                    ChildNode = dr["ccs_ChildNode"].ToString(),
                                });
                            }

                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listHeader
                            });

                            dm.TraceService("==========JSONString Generated " + JSONString + "==========");
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
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }

            dm.TraceService("GetCCUserSettings ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
    }
}