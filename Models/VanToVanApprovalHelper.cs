using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class VanToVanApprovalHelper
    {

        public class PostLodVantoVanApprovalStatusData
        {
            public string TransID { get; set; }
            public string UserId { get; set; }

        }


        public class PostLodVantoVanApprovalDetailStatusData
        {
            public string TransID { get; set; }
            public string UserId { get; set; }

        }
        public class GetVantovanApprovalHeaderStatus
        {
            
            public string ApprovalStatus { get; set; }
        }


        public class GetVantovanApprovalDetailStatus
        {

            public string ApprovalStatus { get; set; }
            public string ApprovalHQty { get; set; }
            public string ApprovalLQty { get; set; }
            public string Item_ID { get; set; }


        }
    }
}