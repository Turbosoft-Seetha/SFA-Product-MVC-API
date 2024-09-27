using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class PriceUpdateHelper
    {
    }
    public class PUHeaderstatusIn
    {
        public string rotID { get; set; }
        public string cusID { get; set; }
        public string ReqID { get; set;}
    }
    public class PUHeaderstatusOut
    {
      
        public string ApprovalStatus { get; set; }
        
    }
    public class PUdetailStatusOut
    {
        public string prdid { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovedHigherPrice { get; set; }
        public string ApprovedLowerPrice { get; set; }
        public string HigherUOM { get; set; }
        public string LowerUOM { get; set; }



    }
    public class PUIn
    {
        public string rotID { get; set; }
        public string cusID { get; set; }
        public string udpID { get; set; }
        public string usrID { get; set; }
        public string ReqID { get; set; }
        public string OrderNo { get; set; }
        public string JSONString { get; set; }
        public string TotalCreditlimit { get; set; }
    }
    public class PUItemData
    {
        public string ItemId { get; set; }
        public string HigherUOM { get; set; }
        public string HigherQty { get; set; }
        public string stdHprice { get; set; }
        public string chngdHprice { get; set; }
        public string LowerUOM { get; set; }
        public string LowerQty { get; set; }
        public string stdLprice { get; set; }
        public string chngdLprice { get; set; }
        public string ReasonId { get; set; }
        public string Flag { get; set; }
        public string HigherLimitPercent { get; set; }
        public string LowerLimtPercent { get; set; }

        
    }
    public class GetPriceUpdateStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }
    public class PostApprovalStatusData
    {
        public string rotID { get; set; }
        public string cusID { get; set; }
        public string udpID { get; set; }
        public string usrID { get; set; }
        public string JSONString { get; set; }
    }
}