using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class LoadReqController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
      
        public string GetItemStock([FromForm] GetWareHouseProductsIn inputParams)
        {
            dm.TraceService("GetItemStock STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            
            string itemID = inputParams.itemID == null ? "0" : inputParams.itemID;

            // DataTable dt = dm.loadList("GetItemStock", "sp_LoadRequest", itemID);

            try
            {
                //if (dt.Rows.Count > 0)
                if (itemID.ToString() != "0")
                {

                    List<GetWareHouseProductsOut> listHeader = new List<GetWareHouseProductsOut>();
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    listHeader.Add(new GetWareHouseProductsOut
                    {
                 
                        ItemCount = "10"


                    });
                    //}

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
                dm.TraceService("GetItemStock  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetItemStock ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    
    }
}