using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class TotalOrderHelper
    {
    }

    public class OrderIn
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
    public class OrderOut
    {
        public string ord_ID { get; set; }
        public string OrderID { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string csh_ID { get; set; }
        public string csh_Code { get; set; }
        public string csh_Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string Status { get; set; }
        public string SubTotal { get; set; }
        public string VAT { get; set; }
        public string GrandTotal { get; set; }
        public string ord_Type { get; set; }
        public string Arcus_Name { get; set; }
        public string Arcsh_Name { get; set; }

    }

    public class OrderDetailIn
    {
        public string ord_ID { get; set; }
      
    }
    public class OrderDetailOut
    {
        public string odd_ID { get; set; }
        public string odd_ord_ID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_NameArabic { get; set; }
        public string prd_Description { get; set; }
        public string odd_HigherUOM { get; set; }
        public string odd_LowerUOM { get; set; }
        public string odd_HigherQty { get; set; }
        public string odd_LowerQty { get; set; }
        public string odd_HigherPrice { get; set; }
        public string odd_LowerPrice { get; set; }
        public string odd_Price { get; set; }
        public string odd_TotalQty { get; set; }
        public string odd_VATPercent { get; set; }
        public string odd_Discount { get; set; }
        public string odd_SubTotal { get; set; }
        public string odd_VATAmount { get; set; }
        public string odd_GrandTotal { get; set; }
        public string odd_TransType { get; set; }
        public string Arprd_Name { get; set; }

    }

    public class AreaTotalOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class AreaTotalOrderOut
    {
        public string AreaID { get; set; }
        public string Area { get; set; }
        public string Areacode { get; set; }

    }
    public class SubAreaTotalOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AreaID { get; set; }

    }
    public class SubAreaTotalOrderOut
    {
        public string SubAreaID { get; set; }
        public string SubArea { get; set; }
        public string Subareacode { get; set; }  

    }
    public class RouteTotalOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SubAreaID { get; set; }

    }
    public class RouteTotalOrderOut
    {
        public string RouteID { get; set; }
        public string Route { get; set; }
        public string Routecode { get; set; }

    }
    public class CusTotalOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class CusTotalOrderOut
    {
        public string CusID { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
    }
    public class OutletTotalOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class OutletTotalOrderOut
    {
        public string OutletID { get; set; }
        public string OutletCode { get; set; }
        public string OutletName { get; set; }
    }
}