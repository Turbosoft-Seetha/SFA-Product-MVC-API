using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class DraftOrderController : Controller
    {

        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string VoidDraft([FromForm] draftorderin inputParams)
        {
            dm.TraceService("VoidDraft STARTED ");
            dm.TraceService("===================");
            try
            {
               
                DataTable CI = dm.loadList("VoidDraft", "sp_App", inputParams.ordid);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<draftorderout> listItems = new List<draftorderout>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new draftorderout
                        {
                            Res = dr["Res"].ToString(),
                            Title = dr["Title"].ToString(),
                            Descr = dr["Descr"].ToString()

                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }

            dm.TraceService("VoidDraft ENDED ");
            dm.TraceService("=================");

            return JSONString;
        }
    }
}