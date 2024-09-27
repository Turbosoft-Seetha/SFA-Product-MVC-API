using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class OutStandingHelper
    {
    }

    public class OutStandingIn
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
        public string Pagenum { get; set; }
        public string SearchString { get; set; }
    }
    public class OutStandingOut
    {
        public string InvoiceID { get; set; }
        public string InvoicedOn { get; set; }
        public string InvoiceAmount { get; set; }
        public string AmountPaid { get; set; }
        public string InvoiceBalance { get; set; }
        public string PDC_Amount { get; set; }
        public string CreatedDate { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string csh_ID { get; set; }
        public string csh_Code { get; set; }
        public string csh_Name { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string Status { get; set; }
        public string ID { get; set; } 
        public string inv_PayType { get; set; }
        public string cus_ArName { get; set; }
        public string csh_ArName { get; set; }
        public string rot_ArName { get; set; }
        public string ArStatus { get; set; }

    }

    public class OutStandingCountIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string Customer { get; set; }
        public string Outlet { get; set; }
    }
    public class OutStandingCountOut
    {
        public string DueCount { get; set; }
        public string DueAmount { get; set; }
        public string OverDueCount { get; set; }
        public string OverDueAmount { get; set; }
        public string TotCount { get; set; }
        public string TotAmount { get; set; }

    }

    public class AreaOutStandingIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class AreaOutStandingOut
    {
        public string AreaID { get; set; }
        public string Area { get; set; }
        public string Areacode { get; set; }

    }
    public class SubAreaOutStandingIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AreaID { get; set; }
        public string CusID { get; set; }

    }
    public class SubAreaOutStandingOut
    {
        public string SubAreaID { get; set; }
        public string SubArea { get; set; }
        public string Subareacode { get; set; }

    }
    public class RouteOutStandingIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SubAreaID { get; set; }
        public string CusID { get; set; } 

    }
    public class RouteOutStandingOut
    {
        public string RouteID { get; set; }
        public string Route { get; set; }
        public string RouteCode { get; set;}

    }
    public class CustOutStandingIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class CustOutStandingOut
    {
        public string CusID { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
    }
    public class OutletOutStandingIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class OutletOutStandingOut
    {
        public string OutletID { get; set; }
        public string OutletCode { get; set; }
        public string OutletName { get; set; }
    }
}