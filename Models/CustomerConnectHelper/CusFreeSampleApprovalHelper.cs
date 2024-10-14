using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusFreeSampleApprovalHelper
    {

    }
    public class PostfreeSampleData
    {
        public string OrderID { get; set; }
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string UserId { get; set; }
        public string UdpId { get; set; }
        public string JSONString { get; set; }

    }
    public class PostFreeSamplelDetData
    {
        public string PrdID { get; set; }
        public string HigherQty { get; set; }
        public string HigherUOM { get; set; }
        public string LowerQty { get; set; }
        public string LowerUOM { get; set; }
    }
    public class GetFreeSampleApprovalStatus
    {

        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string ReturnId { get; set; }
    }
    public class GetFreeHeaderStatus
    {
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string ReturnId { get; set; }
    }
    public class GetDetFreeSapmpleApprovalStatus
    {

        public string ApprovalStatus { get; set; }
        public string ProductId { get; set; }
        public string ReasonID { get; set; }


    }
}