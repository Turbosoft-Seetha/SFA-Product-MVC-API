using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class LoadInHelper
    {
    }
    public class LoadInIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Mode { get; set; }
        public string Route {  get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Customer { get; set; }
        public string CusOutlet { get; set; }

    }
    public class LoadInOut
    {
        public string LoadinHeaderID { get; set; }
        public string TransactionCode { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string ID { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
    public class LoadInDetailIn
    {
        public string ID { get; set; }

    }
    public class LoadInDetailOut
    {
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string LowerUOM { get; set; }
        public string HigherUOM { get; set; }
        public string LowerQty { get; set; }
        public string HigherQty { get; set; }
        public string  LiHigherQty { get; set; }
        public string LiLowerQty { get;set; }
        public string LiHigherUom { get; set;}
        public string LiLowerUom { get; set; }
        public string Arprd_name { get; set; }
        public string Arprd_desc { get; set; }

    }
}