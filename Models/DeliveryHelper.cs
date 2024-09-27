using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class DeliveryHelper
    {

       
    }
    public class PostApprovalHeaderStatusData
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
    }
    public class GetDeliveryApprovalHeaderStatus
    {
        public string ApprovalReason { get; set; }
        public string ApprovalStatus { get; set; }
    }
    public class PostDeliveryItemData
    {
        public string ItemId { get; set; }
        public string HigherUOM { get; set; }
        public string HigherQty { get; set; }
        public string LowerUOM { get; set; }
        public string LowerQty { get; set; }
        public string ReasonId { get; set; }
        //public string LineNo { get; set; }
    }
    public class PostDeliveryData
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string FinalAmount { get; set; }
        public string Status { get; set; }
        public string JSONString { get; set; }
    }
    public class GetDeliveryInsertStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }
    public class PDdetailStatusOut
    {
        public string prdid { get; set; }
        public string ApprovalStatus { get; set; }



    }
}