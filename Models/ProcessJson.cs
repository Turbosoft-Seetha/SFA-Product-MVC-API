using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class ProcessJson
    {

        DataModel dm = new DataModel();

        public string SearchItemsJson(DataTable dt)
        {
            List<GetItemSearch> listItems = new List<GetItemSearch>();
            foreach (DataRow dr in dt.Rows)
            {
                List<ItemUOM> listUOMS = new List<ItemUOM>();
                DataTable dtUOM = dm.loadList("SelItemUOM", "sp_AppServices", dr["prd_ID"].ToString());
                foreach (DataRow drDetails in dtUOM.Rows)
                {
                    listUOMS.Add(new ItemUOM
                    {

                        uomName = drDetails["uom_Name"].ToString(),
                        uomID = drDetails["uom_ID"].ToString(),
                        UPC = drDetails["pru_upc"].ToString(),
                    });
                }

                listItems.Add(new GetItemSearch
                {
                    itmID = dr["prd_ID"].ToString(),
                    itmName = dr["prd_Name"].ToString(),
                    itmCode = dr["prd_Code"].ToString(),
                    itmDesc = dr["prd_ItemLongDesc"].ToString(),
                    CatID = dr["prd_cat_ID"].ToString(),
                    sctID = dr["prd_sct_ID"].ToString(),
                    brdID = dr["prd_brd_ID"].ToString(),
                    ArItmName = dr["prd_NameArabic"].ToString(),
                    UOM = listUOMS,
                });
            }

            string JSONString = JsonConvert.SerializeObject(new
            {
                result = listItems
            });

            return JSONString;

        }


        public string MRDetailData(DataTable dt)
        {
            List<ListMRDOutParam> listItems = new List<ListMRDOutParam>();
            foreach (DataRow dr in dt.Rows)
            {
                List<ItemUOM> listUOMS = new List<ItemUOM>();
                DataTable dtUOM = dm.loadList("SelItemUOM", "sp_AppServices", dr["prd_ID"].ToString());

                foreach (DataRow drDetails in dtUOM.Rows)
                {
                    listUOMS.Add(new ItemUOM
                    {

                        uomName = drDetails["uom_Name"].ToString(),
                        uomID = drDetails["uom_ID"].ToString(),
                        UPC = drDetails["pru_upc"].ToString(),
                        prdID= dr["prd_ID"].ToString(),
                    });
                }

                listItems.Add(new ListMRDOutParam
                {
                    mrd_ID = dr["mrd_ID"].ToString(),
                    mrd_itm_ID = dr["prd_id"].ToString(),
                    mrd_itm_Code = dr["prd_Code"].ToString(),
                    mrd_itmName = dr["prd_Name"].ToString(),
                    AdjustedHQty = dr["AdjustedHQty"].ToString(),
                    AdjustedLQty = dr["AdjustedLQty"].ToString(),
                    RequestedLQty = dr["RequestedLQty"].ToString(),
                    RequestedHQty = dr["RequestedHQty"].ToString(),
                    catID = dr["prd_cat_ID"].ToString(),
                    sctID = dr["prd_sct_ID"].ToString(),
                    BrdID= dr["prd_brd_ID"].ToString(),
                    HUomId = dr["ReqHUomID"].ToString(),
                    LUomId = dr["ReqLUomID"].ToString(),
                    UOM = listUOMS,
                    mrd_itmNameAr = dr["prd_NameArabic"].ToString()
                });
            }

            string JSONString = JsonConvert.SerializeObject(new
            {
                result = listItems
            });

            return JSONString;

        }
    }
}