using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class MustSellHelper
    {
    }

    public class PostMustSellData
    {
        public string ReturnID { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string JSONString { get; set; }
        public string udpID { get; set; }
        public string rotID { get; set; }
        public string ReqID { get; set; }
        public string Type { get; set; }
        public string cus_ID { get; set; }


    }

    public class PostMustSellItemData
    {
        public string ItemId { get; set; }
        public string HigherUOM { get; set; }
        public string HigherQty { get; set; }
        public string LowerUOM { get; set; }
        public string LowerQty { get; set; }
        public string IsMustSell { get; set; }
    }

    public class GetMSStatusIn
    {
        public string TransID { get; set; }
    }
    public class GetStatusOutMs
    {
        public string Status { get; set; }
    }

    public class GetMSInsertStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
        public string TransID { get; set; }
    }
}