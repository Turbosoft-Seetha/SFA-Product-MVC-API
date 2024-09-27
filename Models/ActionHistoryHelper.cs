using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class ActionHistoryHelper
    {
    }
    public class CusAssetTrackingIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
        public string cse_ID { get; set; }

    }
    public class CusAssetTrackingOut
    {
        public string AssetTrackingID { get; set; }
        public string udp_ID { get; set; }
        public string CreatedDate { get; set; }
        public string atm_ID { get; set; }
        public string atm_Code { get; set; }
        public string atm_Name { get; set; }
        public string usr_ID { get; set; }
        public string usr_Code { get; set; }
        public string usr_Name { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string cus_NameArabic { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string rot_ArabicName { get; set; }
        public string ast_ID { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }
        public string Image { get; set; }
        public string Temp { get; set; }
        public string Remarks { get; set; }
        public string Images { get; set; }
      
        public string cas_asn_ID { get; set; }
        public string Status { get; set; }
    }
    public class CusAssetTrackingDetailIn
    {
        public string AssetTrackingID { get; set; }
    }
    public class CusAssetTrackingDetailOut
    {
        public string AssetTrackingID { get; set; }
        public string AssetTrackDetailID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }       
        public string qst_Name { get; set; }
    }
    public class CusAssetAddReqIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
    }
    public class CusAssetAddReqOut
    {

        public string AssetAddReqID { get; set; }
        public string aah_slno { get; set; }
        public string aah_Name { get; set; }
        public string aah_rsn_ID { get; set; }
        public string aah_Remarks { get; set; }
        public string aah_img { get; set; }
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string ast_ID { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }
        public string CreatedDate { get; set; }
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }
        public string Status { get; set; }
    }
    public class CusAssetRemoveReqIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
    }
    public class CusAssetRemoveReqOut
    {

        public string AssetRemoveReqID { get; set; }
        public string arq_asc_ID { get; set; }
        public string arq_Remarks { get; set; }
        public string arq_img { get; set; }
        public string atm_Code { get; set; }
        public string atm_Name { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string ast_ID { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }
        public string CreatedDate { get; set; }
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }
        public string rsn_Type { get; set; }
        public string Status { get; set; }
    }
   
    public class ServiceReqIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
    }
    public class ServiceReqOut
    {

        public string ServiceReqID { get; set; }
        public string snr_Code { get; set; }
        public string ast_ID { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }
        public string atm_ID { get; set; }
        public string atm_Code { get; set; }
        public string atm_Name { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
    }
    public class ServiceJobHeadIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
    }
    public class ServiceJobHeadOut
    {
        public string ServiceJobID { get; set; }
        public string sjh_Number { get; set; }
        public string ServiceReqID { get; set; }
        public string snr_Code { get; set; }
        public string ast_ID { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }
        public string atm_ID { get; set; }
        public string atm_Code { get; set; }
        public string atm_Name { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string CusName { get; set; }
        public string CusCode { get; set; }
        public string ComplaintTitle { get; set; }
        public string ComplaintType { get; set; }
        public string ComplaintTypeID { get; set; }
        public string ReqComments { get; set; }
        public string ReqImages { get; set; }
    }
    public class ServiceReqDetailIn
    {
        public string ServiceReqID { get; set; }
    }
    public class ServiceReqDetailOut
    {     
        public string ServiceReqID { get; set; }
        public string snr_Code { get; set; }
        public string snr_Complaint { get; set; }
        public string snr_Remarks { get; set; }
        public string ast_ID { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }
        public string atm_ID { get; set; }
        public string atm_Code { get; set; }
        public string atm_Name { get; set; }
        public string cst_Name { get; set; }
        public string TroubleShoots { get; set; }
        public string snr_Image { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
    }
    public class ServiceJobDetIn
    {
        public string ServiceJobID { get; set; }
    }
    public class ServiceJobDetOut
    {
        public string AssignedRotCode { get; set; }
        public string AssignedRotName { get; set; }
        public string AssignedDate { get; set; }
        public string AssignedToDate { get; set; }
        public string sjh_ActionType { get; set; }
        public string ActionTakenDate { get; set; }

        public string Status { get; set; }

        public List<ServiceJobDetData> JobDetails { get; set; }

    }
    public class ServiceJobDetData
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }

    }
    public class ReturnRequestHeaderIn
    {

        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
        public string cse_ID { get; set; }
    }
    public class GetRtnRequestHeaderOut
    {

        public string InvoiceNumber { get; set; }
        public string RequestNumber { get; set; }
        public string date { get; set; }
        public string cus_ID { get; set; }
        public string Request_ID { get; set; }
        public string inv_ID { get; set; }
        public string ReturnType { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string SubTotal { get; set; }
        public string Vat { get; set; }
        public string Total { get; set; }
        public string Signature { get; set; }
        public string Attachment { get; set; }
        public string Remark { get; set; }
        public string Time { get; set; }
        


    }
    public class ReturnRequestDetailIn
    {
        public string RequestID { get; set; }
    }
    public class GetRtnRequestDetailOut
    {

        public string prd_ID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }
        public string prd_Name { get; set; }
        public string prd_code { get; set; }
        public string prd_LongDesc { get; set; }
        public string prd_cat_id { get; set; }
        public string prd_sub_ID { get; set; }
        public string prd_brd_ID { get; set; }
        public string prd_NameArabic { get; set; }
        public string prd_LongDescArabic { get; set; }
        public string prd_Image { get; set; }
        public string InvoiceNumber { get; set; }
        public string inv_ID { get; set; }
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }
      
    }

    public class DisputeNoteHeaderIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
        public string cse_ID { get; set; }
    }

    public class DisputeNoteHeaderOut
    {
        public string RequestID { get; set; }
        public string RequestNumber { get; set; }
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }

        public string OtherInfo { get; set; }

        public string Remark { get; set; }
        public string Image { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }


    }

    public class DisputeNoteDetailIn
    {
        public string RequestID { get; set; }
    }

    public class DisputeNoteDetailOut
    {
        public string RequestID { get; set; }
        public string oid_ID { get; set; }
        public string balance { get; set; }
        public string InvoicedDate { get; set; }
        public string InvoiceID { get; set; }
        public string InvoiceAmount { get; set; }

    }


    public class CreditNoteHeaderIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
        public string cse_ID { get; set; }
    }

    public class CreditNoteHeaderOut
    {
        public string Reqno { get; set; }
        public string Amount { get; set; }
        public string vat { get; set; }
        public string subtotal { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string reqID { get; set; }



    }
    public class CreditNoteDetailIn
    {
        public string reqID { get; set; }


    }
    public class CrditNoteDetailOut
    {
        public string invid { get; set; }
        public string itmid { get; set; }
        public string prdcode { get; set; }
        public string prdname { get; set; }
        public string huom { get; set; }
        public string hqty { get; set; }
        public string luom { get; set; }
        public string lqty { get; set; }
        public string amount { get; set; }
        public string rsnid { get; set; }
        public string cnrimage { get; set; }
        public string invno { get; set; }


    }

}