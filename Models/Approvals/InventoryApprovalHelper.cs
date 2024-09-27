using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.ApprovalHelper
{
    public class InventoryApprovalHelper
    {
    }

    public class VantoVanApprovalHeaderIn
    {
        public string Status_Value { get; set; }



    }

    public class SelectPendingStatusCountsIN
    {
        public string UserID { get; set; }



    }


    public class LoadRequestApprovalHeaderIN
    {
        public string Status_Value { get; set; }



    }
    public class VantoVanApprovalDetailsIn
    {
        public string ReqID { get; set; }



    }

    public class LoadRequestApprovalDetailsIN
    {
        public string ReqID { get; set; }



    }
    public class LoadTranferApprovalDetailsIn
    {
        public string ReqID { get; set; }



    }
    public class MaterialReqDetailsIn
    {
        public string ReqID { get; set; }



    }

    public class PostVanToVanApprovalData
    {
        public string UserId { get; set; }
        public string ReqID { get; set; }
        public string JSONString { get; set; }



    }

    public class PostVanToVanApprovalDatas
    {
        public string vvd_ID { get; set; }
        public string HQTY { get; set; }
        public string LQTY { get; set; }

        public string Status { get; set; }


    }
    public class MaterialReqHeaderIN
    {
        public string Status_Value { get; set; }



    }

    public class LoadTranferApprovalHeaderIn
    {
        public string Status_Value { get; set; }



    }

    public class PostVanToVanApprovalStatus
    {
        public string Status { get; set; }
        public string ArStatus { get; set; }


    }

    public class MaterialReqHeaderOut
    {
        public string mrh_ID { get; set; }
        public string mrh_Number { get; set; }
        public string mrh_str_ID { get; set; }
        public string str_Name { get; set; }
        public string mrh_war_ID { get; set; }
        public string war_Name { get; set; }
        public string mrh_ExpDate { get; set; }
        public string CreatedDate { get; set; }
        public string mrh_Remarks { get; set; }
        public string mrh_Status { get; set; }
        public string Status { get; set; }
        public string mrh_IsReOrder { get; set; }
        public string mrh_IntegrationStatus { get; set; }
        public string UserID { get; set; }
        public string str_ArName { get; set; }
        public string war_ArName { get; set; }
        public string ArStatus { get; set; }


    }

    public class VantoVanApprovalHeaderOut
    {
        public string vvh_ID { get; set; }
        public string vvh_TransID { get; set; }
        public string vvh_FromRot { get; set; }
        public string vvh_ToRot { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string Approval_Status { get; set; }

        public string UserID { get; set; }
        public string rotID { get; set; }
        public string Approval_ArStatus { get; set; }
        public string ArStatus { get; set; }

    }


    public class MaterialReqDetailsOut
    {
        public string mrd_ID { get; set; }
        public string mrd_mrh_ID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string ReqHUOM { get; set; }
        public string ReqLUOM { get; set; }

        public string RequestedHQty { get; set; }
        public string RequestedLQty { get; set; }
        public string AdjustedHQty { get; set; }
        public string AdjustedLQty { get; set; }
        public string Arprd_Name { get; set; }
        public string ArReqHUOM { get; set; }
        public string ArReqLUOM { get; set; }



    }

    public class VantoVanApprovalDetailsOut
    {
        public string vvd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string vvd_HUOM { get; set; }
        public string vvd_LUOM { get; set; }
        public string vvd_HQty { get; set; }
        public string vvd_LQty { get; set; }
        public string vvd_ConfirmHQty { get; set; }
        public string vvd_ConfirmLQty { get; set; }
        public string vvd_ConfirmHUOM { get; set; }
        public string vvd_ConfirmLUOM { get; set; }
        public string AdjHQty { get; set; }
        public string AdjLQty { get; set; }
        public string Status { get; set; }
        public string prd_ArName { get; set; }
        public string ArStatus { get; set; }
     


    }

    public class LoadTranferApprovalHeaderOut
    {
        public string ltr_ID { get; set; }
        public string ltr_reqNo { get; set; }
        public string ltr_usr_ID { get; set; }
        public string usr_Name { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string CreatedDate { get; set; }

        public string ltr_rot_ID { get; set; }
        public string ltr_Type { get; set; }
        public string ltr_Remarks { get; set; }
        public string ltr_ApprovalStatus { get; set; }

        public string UserID { get; set; }
        public string rotID { get; set; }
        public string usr_ArName { get; set; }
        public string ltr_ArApprovalStatus { get; set; }


    }

    public class LoadTranferApprovalDetailsOut
    {
        public string ldr_ID { get; set; }
        public string ldr_prd_ID { get; set; }
        public string ldr_CurrentStockHQty { get; set; }
        public string ldr_CurrentStockLQty { get; set; }
        public string ldr_BalanceHQty { get; set; }
        public string ldr_BalanceLQty { get; set; }
        public string ldr_OffloadHQty { get; set; }
        public string ldr_OffloadLQty { get; set; }
        public string ldr_HigherPrice { get; set; }
        public string ldr_LowerPrice { get; set; }
        public string ldr_CurrentStockHUOM { get; set; }
        public string ldr_CurrentStockLUOM { get; set; }
        public string ldr_BalanceHUOM { get; set; }

        public string ldr_OffloadHUOM { get; set; }
        public string ldr_OffloadLUOM { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_ArName { get; set; }
        public string Status { get; set; }

    }

    public class PostLoadTranferApprovalData
    {
        public string UserId { get; set; }
        public string ReqID { get; set; }
        public string JSONString { get; set; }



    }

    public class PostLoadTranferApprovalDataS
    {
        public string ldr_ID { get; set; }
        public string Status { get; set; }



    }

    public class PostLoadTranferApprovalStatus
    {
        public string Status { get; set; }
        public string Res { get; set; }
        public string ArStatus { get; set; }



    }


    public class LoadRequestApprovalHeaderOut
    {
        public string lrh_ID { get; set; }
        public string lrh_Number { get; set; }
        public string lrh_usr_ID { get; set; }
        public string usr_Name { get; set; }
        public string usr_ArabicName { get; set; }
        public string CreatedDate { get; set; }
        public string lrh_LoadReqDate { get; set; }
        public string lrh_udp_ID { get; set; }
        public string Status { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string rot_ArabicName { get; set; }
        public string lrh_Remarks { get; set; }
        public string StagingIntegStatus { get; set; }
        public string StagingIntegRemarks { get; set; }
        public string StagingIntegTime { get; set; }
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string ArStatus { get; set; }

    }


    public class LoadRequestApprovalDetailsOut
    {
        public string lrd_ID { get; set; }
        public string lrd_prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string lrd_HQty { get; set; }
        public string lrd_LQty { get; set; }
        public string prd_NameArabic { get; set; }
        public string lrd_LUOM { get; set; }
        public string lrd_HUOM { get; set; }
        public string lrd_totalQty { get; set; }
        public string lrd_apv_HQty { get; set; }
        public string lrd_apv_LQty { get; set; }
        public string lrd_apv_HUOM { get; set; }
        public string lrd_apv_LUOM { get; set; }
        public string lrd_apv_totalQty { get; set; }

        public string CreatedDate { get; set; }
        public string Status { get; set; }



    }


    public class PostLoadReqApprovalData
    {
        public string JSONString { get; set; }
        public string ReqID { get; set; }

        public string UserId { get; set; }
        public string RotID { get; set; }
        public string Status { get; set; }


    }

    public class PostLoadReqApprovalDatas
    {
        public string lrd_prd_ID { get; set; }
        public string lrd_HQty { get; set; }

        public string lrd_LQty { get; set; }
        public string lrd_LUOM { get; set; }
        public string lrd_HUOM { get; set; }
        public string lrd_totalQty { get; set; }

        public string txt_apv_HQty { get; set; }
        public string txt_apv_LQty { get; set; }

        public string lrd_ID { get; set; }

    }


    public class PostLoadReqApprovalStatus
    {
        public string Status { get; set; }
        public string ArStatus { get; set; }




    }

    public class PostMaterialReqApprovalData
    {
        public string JSONString { get; set; }
        public string UserId { get; set; }
        public string ReqID { get; set; }
        public string Mode { get; set; }

        public string Warehouse { get; set; }



    }

    public class PostMaterialReqApprovalDatas
    {
        public string mrd_ID { get; set; }
        public string prd_ID { get; set; }
        public string ReqHUOM { get; set; }
        public string ReqLUOM { get; set; }

        public string RequestedHQty { get; set; }
        public string RequestedLQty { get; set; }
        public string HQTY { get; set; }
        public string LQTY { get; set; }



    }

    public class PostMaterialReqApprovalStatus
    {
        public string Status { get; set; }
        public string ArStatus { get; set; }




    }


    public class WarehouseOut
    {
        public string war_ID { get; set; }
        public string war_Name { get; set; }




    }



    public class WarehouseIn
    {
        public string mrh_str_ID { get; set; }




    }

    public class PostMaterialReqRejectStatus
    {
        public string Status { get; set; }
        public string ArStatus { get; set; }




    }

    public class PostMaterialReqRejectData
    {
        public string JSONString { get; set; }
        public string ReqID { get; set; }
        public string UserId { get; set; }
        public string Remark { get; set; }




    }


    public class PostMaterialReqRejectDatas
    {
        public string mrd_ID { get; set; }
        public string prd_ID { get; set; }
        public string ReqHUOM { get; set; }
        public string ReqLUOM { get; set; }

        public string RequestedHQty { get; set; }
        public string RequestedLQty { get; set; }
        public string HQTY { get; set; }
        public string LQTY { get; set; }



    }


    public class SelectPendingStatusCountsOut
    {
        public string PendingReturnHeader { get; set; }
        public string PendingPriceChangeApproval { get; set; }
        public string PendingJurneyPlanSeqApprvl { get; set; }
        public string PendingVanToVanHeader { get; set; }

        public string PendingMaterialReqApproval { get; set; }
        public string PendingLodTransRequest { get; set; }
        public string PendingLoadRequestHeader { get; set; }
        public string PendingAssetAddReqHeader { get; set; }
        public string PendingAssetRemovalReqHeader { get; set; }
        public string PendingInvoiceApprovalHeader { get; set; }
        public string PendingDisputeNoteReqHeader { get; set; }
        public string PendingCreditNoteReqHeader { get; set; }

        public string PendingPartialDeliveryHeader { get; set; }
        public string PendingReturnRequestSC { get; set; }
        public string PendingInvReconfirm { get; set; }
        public string SettlementApprovalHeader { get; set; }
        public string VoidTransactionHeader { get; set; }
        public string MustSellHeader { get; set; }
        public string UnschVisit { get; set; }

    }


}