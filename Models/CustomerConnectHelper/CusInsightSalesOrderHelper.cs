using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CusInsightSalesOrderHelper
    {

       
    }
    public class CusInsightOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string Cus_ID { get; set; }
    }
    public class CusInsightOrderOut
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
        public string Arcus_Name { get; set; }
        public string ArStatus { get; set; }
        public string Arcsh_Name { get; set; }

    }
    public class AreaSalesOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Cus_ID { get; set; }
    }
    public class AreaSalesOrderOut
    {
        public string AreaID { get; set; }
        public string Area { get; set; }
        public string Areacode { get;  set; }

    }
    public class SubAreaSalesOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Cus_ID { get; set; }
        public string AreaID { get; set; }

    }
    public class SubAreaSalesOrderOut
    {
        public string SubAreaID { get; set; }
        public string SubArea { get; set; }
        public string Subareacode { get;  set; }

    }
    public class RouteSalesOrderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Cus_ID { get; set; }
        public string SubAreaID { get; set; }

    }
    public class RouteSalesOrderOut
    {
        public string RouteID { get; set; }
        public string Route { get; set; }
        public string RouteCode { get; set; }

    }
}