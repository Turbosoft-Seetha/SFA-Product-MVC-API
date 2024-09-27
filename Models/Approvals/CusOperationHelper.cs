using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.ApprovalHelper
{
    public class CusOperationHelper
    {
    }

    public class disputeNoteapprovalIN
    {
        public string Status_Value { get; set; }



    }

    public class InventoryReconfirmin
    {
        public string Status_Value { get; set; }



    }

    public class InventoryReconfirmDetailin
    {
        public string ReqID { get; set; }



    }
    public class InventoryReconfirmDetailOut
    {
        public string iad_ID { get; set; }
        public string iad_prd_ID { get; set; }
        public string iad_HigherQty { get; set; }
        public string iad_LowerQty { get; set; }
        public string iad_PhysicalHQty { get; set; }
        public string iad_PhysicalLQty { get; set; }
        public string iad_DescHQty { get; set; }
        public string iad_DescLQty { get; set; }
        public string iad_HigherUOM { get; set; }
        public string iad_LowerUOM { get; set; }
        public string iad_PhysicalHUOM { get; set; }
        public string iad_DescHUOM { get; set; }
        public string iad_DescLUOM { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string Arprd_Name { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }


    }

    public class InventoryReconfirmOut
    {
        public string iah_ID { get; set; }
        public string iah_TransID { get; set; }
        public string iah_usr_ID { get; set; }
        public string usr_Name { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string CreatedDate { get; set; }
        public string iah_rot_ID { get; set; }
        public string iah_Status { get; set; }
        public string Arusr_Name { get; set; }
        public string Ariah_Status { get; set; }



    }
    public class GetRouteForReturnIn
    {
        public string Rot_Id { get; set; }



    }
    public class GetRouteForReturnOut
    {
        public string rot_ID { get; set; }

        public string rot_Name { get; set; }


    }

    public class SelectRouteForReturnSCOut
    {
        public string rot_ID { get; set; }

        public string rot_Name { get; set; }


    }

    public class SelectRouteForReturnSCIN
    {
        public string UserId { get; set; }



    }

    public class CreditNoteApprovalIn
    {
        public string ReqID { get; set; }
        public string Remark { get; set; }
        public string NextLevel { get; set; }
        public string UserId { get; set; }




    }

    public class PartialDeliveryIN
    {
        public string Status_Value { get; set; }



    }

    public class creditNoteDetailIN
    {
        public string ReqID { get; set; }



    }

    public class PartialDeliveryDetailIN
    {
        public string ReqID { get; set; }



    }

    public class DisputeNoteApprovalIn
    {
        public string ReqID { get; set; }
        public string Remark { get; set; }
        public string NextLevel { get; set; }
        public string UserId { get; set; }




    }

    public class GetCraditApprovalLevelStatusIn
    {
        public string UserId { get; set; }
       



    }
    public class GetCreditApprovalLevelStatusOut
    {
        public string Status { get; set; }
        public string CurrentLevel { get; set; }
        public string NextLevel { get; set; }
        public string ArStatus { get; set; }



    }

    public class DisputeNoteApprovalOut
    {
        public string Status { get; set; }
      



    }
    public class CreditNoteApprovalOut
    {
        public string Status { get; set; }

        public string ArStatus { get; set; }


    }

    public class DisputeNoteRejectIn
    {
        public string ReqID { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }


    }
    public class CreditNoteRejectIn
    {
        public string ReqID { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }


    }
    public class DisputeNoteRejectOut
    {
        public string Status { get; set; }




    }
    public class CreditNoteRejectOut
    {
        public string Status { get; set; }

        public string ArStatus { get; set; }


    }

    public class ReturnReqSCHeaderIN
    {
        public string Status_Value { get; set; }



    }

    public class ReturnReqSCDetailIN
    {
        public string ReqID { get; set; }



    }

    public class ReasonRtnScIn
    {
        public string rsn_Type { get; set; }



    }
    public class GetDisputeApprovalLevelStatusIn
    {
        public string UserId { get; set; }
     }
    public class GetDisputeApprovalLevelStatusOut
    {
        public string Status { get; set; }
        public string CurrentLevel { get; set; }
        public string NextLevel { get; set; }

    }

    public class ReasonRtnScOut
    {
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }
        public string rsn_Type { get; set; }



    }



    public class ReturnReqSCDetailOut
    {
        public string rrd_ID { get; set; }
        public string rrd_rrh_ID { get; set; }
        public string rrd_prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string HQty { get; set; }
        public string rrd_HUOM { get; set; }
        public string LQty { get; set; }
        public string rrd_LUOM { get; set; }
        public string rrd_LineNo { get; set; }
        public string rsn_Name { get; set; }
        public string Status { get; set; }
        public string rsn_ID { get; set; }
        public string Image { get; set; }
        public string rsn_Type { get; set; }
        public string Arprd_Name { get; set; }
        public string Arrsn_Name { get; set; }
        public string ArStatus { get; set; }
        public string Arrsn_Type { get; set; }
        public string Reason { get; set; }

        public string ArReason { get; set; }

    }
    public class ReturnReqSCHeaderOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rrh_inv_ID { get; set; }
        public string rrh_RequestNumber { get; set; }
        public string usr_Name { get; set; }
        public string rrh_ID { get; set; }
        public string rrh_Type { get; set; }
        public string rrh_ReturnType { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string UserID { get; set; }
        public string Arcus_Name { get; set; }
        public string Arusr_Name { get; set; }
        public string Arrrh_ReturnType { get; set; }
        public string Arrrh_Type { get; set; }
        public string ArStatus { get; set; }
    }

    public class creditNoteDetailOut
    {
        public string cnd_ID { get; set; }
        public string inv_InvoiceID { get; set; }
        public string TransTime { get; set; }
        public string prd_Name { get; set; }
        public string HUOM { get; set; }
        public string crd_HQty { get; set; }
        public string LUOM { get; set; }
        public string crd_LQty { get; set; }
        public string cnd_crd_Amount { get; set; }
        public string Status { get; set; }
        public string Arprd_Name { get; set; }
        public string ArStatus { get; set; }
    }

    public class PartialDeliveryDetailOut
    {
        public string dad_ID { get; set; }
        public string dad_prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string OrderedHQty { get; set; }
        public string OrderedLQty { get; set; }
        public string deliveringHQty { get; set; }
        public string DeliveringLQty { get; set; }
        public string rsn_Name { get; set; }
        public string rsn_ID { get; set; }
        public string rsn_Type { get; set; }
        public string prd_Description { get; set; }
        public string Arprd_Name { get; set; }
        public string Arrsn_Name { get; set; }
        public string Arprd_Description { get; set; }
        public string Arrsn_Type { get; set; }
        public string Status { get; set; }
        public string DetStatus { get; set; }
        public string Reason { get; set; }
        public string ArReason { get; set; }

    }

    public class creditNoteapprovalIN
    {
        public string Status_Value { get; set; }



    }
    public class disputeNoteDetailIN
    {
        public string ReqID { get; set; }



    }

    public class disputeNoteapprovalOut
    {
        public string drh_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string drh_rot_ID { get; set; }
        public string drh_TransID { get; set; }
        public string usr_Name { get; set; }
        public string drh_Amount { get; set; }
        public string drh_DisputeType { get; set; }
        public string TransTime { get; set; }
        public string drh_OtherInfo { get; set; }
        public string DisputeType { get; set; }
        public string drh_Remarks { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }

        public string UserID { get; set; }
        public string rotID { get; set; }
        public string Arcus_Name { get; set; }
        public string Arusr_Name { get; set; }
        public string Ardrh_OtherInfo { get; set; }
        public string ArDisputeType { get; set; }
        public string ArStatus { get; set; }
    }

    public class disputeNoteDetailOut
    {
        public string drd_ID { get; set; }
        public string drd_InvoiceBalance { get; set; }
        public string InvoiceID { get; set; }
        public string TransTime { get; set; }
        public string InvoiceAmount { get; set; }
       



    }


    public class creditNoteapprovalOut
    {
        public string cnh_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string usr_Name { get; set; }
        public string cnh_Number { get; set; }
        public string CreatedDate { get; set; }
        public string cnh_Amount { get; set; }
        public string cnh_SubTotal { get; set; }
        public string cnh_VAT { get; set; }
        public string cnh_CreditType { get; set; }
        public string Status { get; set; }


        public string UserID { get; set; }
        public string rotID { get; set; }
        public string Arcus_Name { get; set; }
        public string Arusr_Name { get; set; }
        public string Arcnh_CreditType { get; set; }
        public string ArStatus { get; set; }
    }

    public class PartialDeliveryOut
    {
        public string dah_ID { get; set; }
        public string OrderID { get; set; }
        public string ExpectedDelDate { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Name { get; set; }
        public string Type { get; set; }
        public string CreatedDate { get; set; }
        public string dah_ApprovalStatus { get; set; }
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string Arcus_Name { get; set; }
        public string Ardah_ApprovalStatus { get; set; }
        public string Status { get; set; }

	}

    public class PostReturnreqSCData
    {
        public string ReturnID { get; set; }
        public string UserId { get; set; }
        public string JSONString { get; set; }
        public string RouteId { get; set; }


    }

    public class PostReturnSCApprovalData
    {
        public string rrd_ID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }


    }

    public class GetOpenReturnSCApprovalStatus
    {
       
        public string Status { get; set; }
        public string ArStatus { get; set; }

    }

    public class ResonForPartialDeliveryIn
    {
        public string rsn_Type { get; set; }



    }

    public class ResonForPartialDeliveryOut
    {
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }
        public string rsn_ArName { get; set; }





    }

    public class PostPartialDelData
    {
        public string ReturnID { get; set; }
        public string UserId { get; set; }
        public string JSONString { get; set; }

     }

    public class PostPartialDelDatas
    {
        public string dad_ID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

    }


    public class PostPartialDelStatus
    {
      
        public string Status { get; set; }
        public string ArStatus { get; set; }
    }

    public class Reasons
    {

        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }
        public string rsn_ArName { get; set; }


    }

    public class InventoryReconfirmApprovalData
    {

        public string ReqID { get; set; }
        public string UserId { get; set; }
        public string JSONString { get; set; }

    }

    public class InventoryReconfirmApprovalDatas
    {

        public string iad_ID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

    }
    public class PostInvRencofirmApprovalStatusOut
    {
        public string Status { get; set; }
        public string ArStatus { get; set; }
    }
}