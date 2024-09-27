using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class TodayDeliveryHelper
    {

    }
    public class TodayDelIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Route { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
    }
    public class TodayDelOut
    {
        public string OrderID { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cusName { get; set; }
        public string cusCode { get; set; }
        public string cusOutName { get; set; }
        public string cusOutCode { get; set; }
        public string salesman { get; set; }
        public string Date {  get; set; }
        public string Time { get; set; }
        public string ID { get; set; }
        public string Status { get; set; }
        public string SubTotal { get; set; }
        public string VAT { get; set; }
        public string GrandTotal { get; set; }
        public string ArcusName { get; set; }
        public string ArStatus { get; set; }
        public string ArcusOutName { get; set; }
        public string Arsalesman { get; set; }
    }
    public class TodayDelDetailIn
    {
        public string ID { get; set; }

    }
    public class TodayDelDetailOut
    {
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string LowerUOM { get; set; }
        public string HigherUOM { get; set; }
        public string LowerQty { get; set; }
        public string HigherQty { get; set; }
        public string Total { get; set; }
        public string Arprd_Name { get; set; }

    }
}