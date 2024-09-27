using iTextSharp.text.pdf.parser;
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
    public class SearchController: Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        ProcessJson pj = new ProcessJson();



        public string SearchItems([FromForm] SerachIn inParams)
        {
            string SearchCode = inParams.Searchcode == null ? "" : inParams.Searchcode;
            string CatID = inParams.catID == null ? "0" : inParams.catID;
            string SctID = inParams.subID == null ? "0" : inParams.subID;
            string BrdId = inParams.brandID == null ? "0" : inParams.brandID;

            string catIDin="", SctIDin="", BrdIdIn = "",SearchCondition="";
            string maincondition = "";


            if (SearchCode != "")
            {
                SearchCondition = " and (prd_Code LIKE '%"+ SearchCode + "%' OR prd_Name LIKE '%" + SearchCode + "%')";
                maincondition = SearchCondition;
            }
            if (CatID != "0")
            {
                catIDin = " And prd_cat_ID in("+ CatID + ")";
                maincondition += catIDin;
            }
            if(SctID != "0")
            {
                SctIDin = " And prd_sct_ID in(" + SctID + ")";
                maincondition += catIDin;
            }
            if (BrdId != "0")
            {
                BrdIdIn = " And prd_brd_ID in(" + BrdId + ")";
                maincondition += BrdIdIn;
            }


            string[] arr = { maincondition };
            DataTable dtBestSellPrd = dm.loadList("SelSearchProduct", "sp_AppServices", SearchCode, arr);

            string JSONString = string.Empty;
            try
            {
                if (dtBestSellPrd.Rows.Count > 0)
                {
                    JSONString = pj.SearchItemsJson(dtBestSellPrd);
                }
                else
                {
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL";
            }

            return JSONString;
        }



        public string SelUOMByID([FromForm] SerachUOMIDIn inParams)
        {
            try
            {
                dm.TraceService("==========SelUOMByID Master Started==========");
                DataTable CI = dm.loadList("SelItemUOM", "sp_AppServices", inParams.prdID);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<ItemUOM> listUOM = new List<ItemUOM>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listUOM.Add(new ItemUOM
                        {
                            uomName = dr["uom_Name"].ToString(),
                            uomID = dr["uom_ID"].ToString(),
                            UPC = dr["pru_upc"].ToString(),
                            prdID= inParams.prdID==null?"0":inParams.prdID
                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listUOM
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
            dm.TraceService("==========SelUOMByID Master End==========");
            return JSONString;
        }

    }
}