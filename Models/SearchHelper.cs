using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class SearchHelper
    {
       

    }
    public class SerachIn
    {
        public string Searchcode { get; set; }
        public string subID { get; set; }
        public string catID { get; set; }
        public string brandID { get; set; }

    }
    public class ItemUOM
    {
        public string uomID { get; set; }
        public string uomName { get; set; }
        public string UPC { get; set; }
        public string prdID {  get; set; }

    }
    public class InParams
    {
        public string PrdId { get; set; }
    }



    public class GetItemSearch
    {

        public string itmID { get; set; }
        public string itmName { get; set; }
        public string itmCode { get; set; }
        public string itmDesc { get; set; }
        public string CatID { get; set; }
        public string sctID { get; set; }
        public string brdID { get; set; }
        public string ArItmName { get; set; }
        public List<ItemUOM> UOM { get; set; }

    }
    public class BarcodeSerachIn
    {
        public string Searchcode { get; set; }

    }
    public class GetBarcodeSearch
    {

        public string itmID { get; set; }
        public string itmName { get; set; }
        public string itmCode { get; set; }
        public string itmDesc { get; set; }
        public string CatID { get; set; }
        public string sctID { get; set; }
        public string brdID { get; set; }
        public string itmBarcode { get; set; }
        public string warID { get; set; }
        public string rakID { get; set; }
        public string basID { get; set; }
        public string prd_AlternateName { get; set; }
        public string uom_ID { get; set; }
        public string uom_Name { get; set; }
    }
    public class SerachIDIn
    {
        public string SearchID { get; set; }

    }


    public class SerachcatIDIn
    {
        public string SearchcatID { get; set; }

    }
    public class GetCategorySearch
    {
        public string catID { get; set; }
        public string catName { get; set; }
        public string catCode { get; set; }
        public string status { get; set; }
        public string cat_AlternateName { get; set; }
    }
    public class SerachSubcatIDIn
    {
        public string SearchSubcatID { get; set; }

    }
    public class GetSubcategorySearch
    {
        public string subID { get; set; }
        public string catID { get; set; }
        public string subName { get; set; }
        public string subCode { get; set; }
        public string status { get; set; }
        public string sub_AlternateName { get; set; }
    }
    public class SerachUOMIDIn
    {
        public string prdID { get; set; }

    }
    public class GetUOMSearch
    {
        public string uomID { get; set; }
        public string uomName { get; set; }
        public string uomArabicName { get; set; }
        public string status { get; set; }
    }
    public class SerachStoreIDIn
    {
        public string SearchStoreID { get; set; }

    }
    public class GetStoreSearch
    {
        public string strID { get; set; }
        public string strName { get; set; }
        public string strCode { get; set; }
        public string strType { get; set; }
        public string status { get; set; }
        public string str_AlternateName { get; set; }
    }
    public class SerachItemUOMIn
    {
        public string SearchID { get; set; }

    }
    public class ItemUOMSearch
    {
        public string pruID { get; set; }
        public string uomID { get; set; }
        public string prdID { get; set; }
        public string StandardPrice { get; set; }
        public string UPC { get; set; }
        public string IsDefault { get; set; }
        public string ReturnPrice { get; set; }
    }
}