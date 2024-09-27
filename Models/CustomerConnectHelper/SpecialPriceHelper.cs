using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class SpecialPriceHelper
    {
    }
    public class SpecialPriceIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string Customer { get; set; }
        public string Outlet { get; set; }
        public string Mode { get; set; }
    }
    public class SpecialPriceOut
    {
        public string prh_ID { get; set; }
        public string prh_Code { get; set; }
        public string prh_Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string prh_PayMode { get; set; }
        

    }
    public class SPDetailIn
    {
        public string prh_ID { get; set; }
    }
    public class SPDetailOut
    {
        public string pld_ID { get; set; }
        public string pld_prh_ID { get; set; }
        public string pld_VATPerc { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_NameArabic { get; set; }
        public string prd_Description { get; set; }
        public string UOM { get; set; }
        public string StdPrice { get; set; }
        public string SpecialPrice { get; set; }
        public string pld_ReturnPrice { get; set; }
    }
    public class SpecialPriceCusIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string Customer { get; set; }
        public string Outlet { get; set; }
        public string Mode { get; set; }
        public string ID { get; set; }
    }
    public class SpecialPriceCusOut
    {
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string csh_ID { get; set; }
        public string csh_Code { get; set; }
        public string csh_Name { get; set; }
        public string Class { get; set; }
        public string Area { get; set; }
    }

    public class AreaSpecialPriceIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class AreaSpecialPriceOut
    {
        public string AreaID { get; set; }
        public string Area { get; set; }
        public string AreaCode { get; set;}

    }
    public class SubAreaSpecialPriceIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AreaID { get; set; }
        public string CusID { get; set; }

    }
    public class SubAreaSpecialPriceOut
    {
        public string SubAreaID { get; set; }
        public string SubArea { get; set; }
        public string Subareacode { get; set;}

    }
    public class RouteSpecialPriceIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SubAreaID { get; set; }
        public string CusID { get; set; }

    }
    public class RouteSpecialPriceOut
    {
        public string RouteID { get; set; }
        public string Route { get; set; }
        public string Routecode { get; set; }

    }
    public class CustSpecialPriceIn
    {
        public string prh_ID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class CustSpecialPriceOut
    {
        public string CusID { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
        public string ArCusName { get; set; }

    }
    public class OutletSpecialPriceIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class OutletSpecialPriceOut
    {
        public string OutletID { get; set; }
        public string OutletCode { get; set; }
        public string OutletName { get; set; }
    }
}