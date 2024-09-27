using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class PriceChangeHelper
    {
    }


    public class PriceChangeIn
    {
        public string Status_Value { get; set; }
    }

    public class PriceChangeDetailIn
    {
        public string pch_ID { get; set; }
    }

    public class ReasonPCIn
    {
        public string rsn_Type { get; set; }


    }


    public class ReasonPCOut
    {
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }

        public string rsn_Type { get; set; }
        public string rsn_ArName { get; set; }






    }

    public class PostSpecialPriceItemData
    {
        public string pcd_ID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string aprvdHprice { get; set; }
        public string LowerQty { get; set; }
        public string aprvdLprice { get; set; }


    }

    public class PostSpecialPriceData
    {
        public string PriceID { get; set; }
        public string UserId { get; set; }
        public string JSONString { get; set; }
      

    }

    public class PriceChangeStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
        public string TransID { get; set; }
        public string ArStatus { get; set; }
    }

    public class PriceChangeOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string pch_rot_ID { get; set; }
        public string usr_Name { get; set; }

        public string pch_ID { get; set; }
        public string csh_Code { get; set; }
        public string csh_Name { get; set; }
        public string pch_ReqID { get; set; }
        public string CreatedDate { get; set; }
        public string Type { get; set; }
        public string pch_ApprovalStatus { get; set; }

        public string UserID { get; set; }
        public string rotID { get; set; }
        public string Arcus_Name { get; set; }
        public string Arusr_Name { get; set; }
        public string Arcsh_Name { get; set; }
        public string Arpch_ApprovalStatus { get; set; }
        public string ArType { get; set; }
    }


    public class PriceChangeDetailOut
    {
        public string pcd_ID { get; set; }
        public string pcd_pch_ID { get; set; }
        public string pcd_prd_ID { get; set; }
        public string prd_Name { get; set; }
        public string prd_Code { get; set; }
        public string pcd_HigherQty { get; set; }

        public string pcd_HigherUOM { get; set; }
        public string pcd_LowerQty { get; set; }
        public string pcd_LowerUOM { get; set; }
        public string pcd_stdHPrice { get; set; }
        public string pcd_changedHPrice { get; set; }
        public string pcd_stdLPrice { get; set; }
        public string pcd_changedLprice { get; set; }

        public string pcd_HigherLimitPercent { get; set; }


        public string pcd_LowerLimtPercent { get; set; }
        public string maxHigherlimit { get; set; }
        public string MinHigherLimit { get; set; }
        public string MinLowerLimit { get; set; }
        public string maxLowerlimit { get; set; }

        public string pcd_ApprovalStatus { get; set; }

        public string Arprd_Name { get; set; }

        public string Arpcd_ApprovalStatus { get; set; }
        public string Reason { get; set; }
        public string ArReason { get; set; }
        public string pcd_ApprovedHPrice { get; set; }
        public string pcd_ApprovedLPrice { get; set; }

    }
}