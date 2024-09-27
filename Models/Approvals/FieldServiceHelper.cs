using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.ApprovalHelper
{
    public class FieldServiceHelper
    {
    }
    public class AssetAddReqHeaderIN
    {
        public string UserID { get; set; }



    }
    public class AssetRemoveReqHeaderIn
    {
        public string UserID { get; set; }



    }
    public class InvoiceApprovalHeaderIn
    {
        public string UserID { get; set; }



    }

    public class InvoiceApprovalDetailsIn
    {
        public string ReqID { get; set; }



    }



    public class AssetAddReqHeaderOut
    {
        public string aah_ID { get; set; }
        public string aah_ast_ID { get; set; }
        public string aah_slno { get; set; }
        public string aah_Name { get; set; }
        public string aah_rsn_ID { get; set; }
        public string aah_Remarks { get; set; }
        public string aah_cus_ID { get; set; }
        public string aah_udp_ID { get; set; }
        public string ast_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string CreatedDate { get; set; }
        public string rot_Code { get; set; }
        public string Route { get; set; }
        public string rsn_Name { get; set; }
        public string ast_Code { get; set; }
        public string Image { get; set; }
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string aah_ArName { get; set; }
        public string ast_ArName { get; set; }
        public string aah_ArRemarks { get; set; }
        public string cus_ArName { get; set; }
        public string rsn_ArName { get; set; }




    }

    public class AssetRemoveReqHeaderOut
    {
        public string arq_ID { get; set; }
        public string arq_Remarks { get; set; }
        public string arq_Status { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }
        public string rsn_Name { get; set; }
        public string rsn_Type { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string atm_Code { get; set; }
        public string atm_Name { get; set; }
        public string CreatedDate { get; set; }
        public string rot_Code { get; set; }
        public string Route { get; set; }
        public string arq_ast_ID { get; set; }
        public string arq_cus_ID { get; set; }
        public string arq_asc_ID { get; set; }
        public string Image { get; set; }
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string ast_ArName { get; set; }
        public string rsn_ArName { get; set; }
        public string rsn_ArType { get; set; }
        public string cus_ArName { get; set; }
        public string atm_ArName { get; set; }




    }
    public class InvoiceApprovalHeaderOut
    {
        public string sah_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string TransTime { get; set; }
        public string usr_Name { get; set; }
        public string sjh_Number { get; set; }
        public string snr_Code { get; set; }
        public string Status { get; set; }
        public string sah_Total { get; set; }
        public string sah_Discount { get; set; }
        public string sah_SubTotal { get; set; }
        public string sah_VAT { get; set; }
        public string sah_GrandTotal { get; set; }
        public string UserID {  get; set; }
        public string rotID { get; set; }
        public string ArStatus { get; set; }

    }
    public class InvoiceApprovalDetailsOut
    {
        public string sad_ID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string sad_UOM { get; set; }
        public string sad_Qty { get; set; }
        public string sad_Price { get; set; }
        public string sad_Discount { get; set; }
        public string sad_LineTotal { get; set; }
       


    }

    public class AssetAddReqHeaderApprovalIn
    {
        public string UserID { get; set; }
        public string ReqID { get; set; }
        public string SerialNum { get; set; }



    }

    public class AssetAddReqHeaderApprovalOut
    {
        public string Status { get; set; }
        public string ArStatus { get; set; }





    }

    public class AssetAddReqHeaderRejectIn
    {
        public string UserID { get; set; }

        public string ReqID { get; set; }



    }
    public class AssetAddReqHeaderRejectOut
    {
        public string Status { get; set; }
        public string ArStatus { get; set; }





    }

    public class PostAssetRemovalReqApprovaldata
    {
        public string UserId { get; set; }

        public string JSONString { get; set; }



    }
    public class PostAssetRemovalReqRejectdata
    {
        public string UserId { get; set; }

        public string JSONString { get; set; }



    }

    public class PostAssetRemovalReqApprovaldatas
    {
        public string arq_ID { get; set; }

        public string asc_ID { get; set; }



    }
    public class PostAssetRemovalReqRejectdatas
    {
        public string arq_ID { get; set; }

        public string asc_ID { get; set; }



    }
    public class PostAssetRemovalReqApprovalStatus
    {

        public string Status { get; set; }
        public string ArStatus { get; set; }



    }
    public class PostAssetRemovalReqRejectStatus
    {

        public string Status { get; set; }
        public string ArStatus { get; set; }




    }
    public class FieldServiceInvoiceApprovalIn
    {

        public string UserID { get; set; }

        public string ReqID { get; set; }


    }
    public class FieldServiceInvoiceApprovalOut
    {


        public string Status { get; set; }
        public string ArStatus { get; set; }


    }

    public class FieldServiceInvoiceRejectIn
    {

        public string UserID { get; set; }

        public string ReqID { get; set; }


    }
    public class FieldServiceInvoiceRejectOut
    {


        public string Status { get; set; }
        public string ArStatus { get; set; }


    }


}