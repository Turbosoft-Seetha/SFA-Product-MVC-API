using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class MRHelper
    {


       
    }
    public class ListMRHinParam
    {
        public string User { get; set; }

    }
    public class PostMR
    {
        public string MrhID { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        public string jsonValue { get; set; }
    }

    public class PostMRDetail
    {
        public int prd_ID { get; set; }
        public string HUOM { get; set; }
        public string LUOM { get; set; }
        public string HRQuantity { get; set; }
        public string LRQuantity { get; set; }
    }
    public class ListMRHOutParam
    {
        public string mrhID { get; set; }
        public string mrhnumber { get; set; }
        public string ExpDate { get; set; }
        public string CreatedDate { get; set; }
        public string status { get; set; }
        public string StoreID { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string WarID { get; set; }
        public string WarCode {  get; set; }
        public string WarName { get; set;}
        public string Platform {  get; set; }
        public string Arabic_status {  get; set; }
        public string Arabic_StoreName {  get; set; }
        public string Arabic_WarName {  get; set; }
    }
    public class ListMRDinParam
    {
        public string mrhID { get; set; }

    }
    public class ListMRDOutParam
    {
        public string mrd_ID { get; set; }
        public string mrd_itm_ID { get; set; }
        public string mrd_itm_Code { get; set; }
        public string mrd_itmName { get; set; }
        public string mrd_itm_uom { get; set; }
        public string RequestedHQty { get; set; }
        public string AdjustedHQty { get; set; }
        public string RequestedLQty { get; set; }
        public string AdjustedLQty { get; set; }
        public string catID { get; set; }
        public string sctID { get; set; }
        public string BrdID {  get; set; }
        public string HUomId {  get; set; }
        public string LUomId {  get; set; }
        public List<ItemUOM> UOM { get; set; }
        public string mrd_itmNameAr { get; set; }

    }

    public class MrdItmUOM
    {
        public string uomID { get; set; }
        public string uomName { get; set; }
        public string RequestedQty { get; set; }
        public string AdjustedQty { get; set;}

    }

    public class GetStatus
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string mrhID { get; set; }
    }

    public class PostDraftCancel
    {
        public string MrhID { get; set; }
        public string UserID { get; set; }
    }
}