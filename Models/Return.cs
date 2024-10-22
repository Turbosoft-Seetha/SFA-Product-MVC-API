using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class Return
    {
    }
    public class ReturnRequestIn
    {

        public string UserId { get; set; }
        public string rot_ID { get; set; }
    }

    public class RtnPDFOut
    {
        public string PDFRTNurl { get; set; }


    }

    public class ReturnPDFIn
    {
        public string rtnID { get; set; }


    }
    public class GetRtnRequestHeader
    {

        public string InvoiceNumber{ get; set; }
        public string RequestNumber { get; set; }
        public string date { get; set; }

        public List<GetRtnRequestDetail> RequestDetail { get; set; }
        public string cus_ID { get; set; }
        public string Request_ID { get; set; }

        public string inv_ID { get; set; }
        public string ReturnType { get; set; }
    }
    public class GetRtnRequestDetail
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
        public string rrd_ID { get; set; }
        public string rrd_rrh_ID { get; set; }
        public string prd_IsBatchItem { get; set; }
        public List<GetRtnRequestBatch> RequestBatch { get; set; }
    }

    public class GetRtnRequestBatch
    {
        public string rrb_ID { get; set; }
        public string rrb_rrh_ID { get; set; }
        public string rrb_rrd_ID { get; set; }
        public string rrb_Number { get; set; }
        public string rrb_ExpiryDate { get; set; }
        public string rrb_BaseUOM { get; set; }
        public string rrb_Qty { get; set; }
        public string ind_inv_ID { get; set; }

    }

    public class ReturnIn
    {
        public string cseID { get; set; }
        public string cusID { get; set; }
        public string udpID { get; set; }
        public string type { get; set; }

        public string date { get; set; }
        public string usrID { get; set; }

        public string ItemID { get; set; }

        public string BatchData { get; set; }
        public string Request_ID { get; set; }

    }
    public class ItemIDs
    {
        public string reason { get; set; }
        public string invoiceID { get; set; }
        public string prdID { get; set; }
        public string HigherUOM { get; set; }

        public string HigherQty { get; set; }
        public string LowerUOM { get; set; }

        public string LowerQty { get; set; }

    }
    public class BatchSerial
    {
        public string prdID { get; set; }
        public string ExpiryDate { get; set; }
        public string UOM { get; set; }
        public string ReturnQty { get; set; }

        public string Mode { get; set; }

        public string BatSerialNo { get; set; }
    }
    public class ReturnOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }

    }

    public class PostReturnItemData
    {
        public string ItemId { get; set; }
        public string HigherUOM { get; set; }
        public string HigherQty { get; set; }
        public string LowerUOM { get; set; }
        public string LowerQty { get; set; }
        public string ReasonId { get; set; }
        public string invid { get; set;}
        public string Type { get; set; } = "";
		public string rad_VAT { get; set; }
		public string rad_GrandTotal { get; set; }

	}
    public class PostReturnData
    {
        public string ReturnID { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string JSONString { get; set; }
        public string udpID { get; set; }
        public string rotID { get; set; }
        public string ReqID { get; set; }
        public string ReturnType { get; set; }
        public string ReturnMode { get; set; }
        public string cus_ID { get; set; }


    }
    public class GetReturnInsertStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
        public string TransID { get; set; }
    }
    public class PostReturnApprovalStatusData
    {
        public string ReturnID { get; set; }
        public string UserId { get; set; }

    }
    public class GetReturnApprovalStatus
    {
       
        public string ApprovalStatus { get; set; }

        public string Products { get; set; }
        public string ReasonID { get; set; }
        public string InvoiceID { get; set; }

    }
    public class PostReturnApprovalHeaderStatusData
    {
        public string ReturnID { get; set; }
        public string UserId { get; set; }
    }
    public class GetReturnApprovalHeaderStatus
    {
        public string ApprovalReason { get; set; }
        public string ApprovalStatus { get; set; }
    }
    public class PostOpenReturnItemData
    {
        public string ItemId { get; set; }
        public string HigherUOM { get; set; }
        public string HigherQty { get; set; }
        public string LowerUOM { get; set; }
        public string LowerQty { get; set; }

    }
    public class PostOpenReturnData
    {
        public string InvoiceNumber { get; set; }
        public string UserId { get; set; }
        public string udpID { get; set; }
        public string rotID { get; set; }
        public string Type { get; set; }
        public string ReturnType { get; set; }
        public string JSONString { get; set; }


    }

    public class GetOpenReturnInsertStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }

    public class GetOpenReturnApprovalStatusIn
    {
        public string InvoiceNumber { get; set; }


    }
    public class GetOpenReturnApprovalStatusOut
    {
        public string ApprovalStatus { get; set; }

    }
   
   
    public class ScheduledReturnIn
    {
        public string rotID { get; set; }
        public string cseID { get; set; }
        public string cusID { get; set; }
        public string udpID { get; set; }
        public string type { get; set; }

        public string date { get; set; }

        public string Remark { get; set; }

        public string JSONString { get; set; }
        public string InvoiceID { get; set; }
        public string usrID { get; set; }
        public string SubTotal { get; set; }
        public string Vat { get; set; }
        public string Total { get; set; }
        public string Signature { get; set; }
        public string RetReqSeq { get; set; }
        public string BatchJSONString { get; set; }


    }
    public class SRItemIDs
    {


        public string prdID { get; set; }
        public string HigherUOM { get; set; }

        public string HigherQty { get; set; }
        public string LowerUOM { get; set; }

        public string LowerQty { get; set; }
        public string reason { get; set; } = "0";
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }
        public string LineTotal { get; set; }
        public string Vat { get; set; }
        public string GrandTotal { get; set; }


    }
    public class SRBatchData
    {
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string BaseUOM { get; set; }
        public string OrderedQty { get; set; }
        public string AdjustedQty { get; set; }
        public string LoadInQty { get; set; }
        public string itm_ID { get; set; }
    }
    public class ScheduledReturnout
    {
        public string Res { get; set; }

        public string Message { get; set; }
        public string TransID { get; set; }

    }

    public class SRImageIn
    {


        public string prdID { get; set; }
        public string TransID { get; set; }

    }
    public class SRImageOut
    {
        public string Res { get; set; }

        public string Message { get; set; }


    }
    public class SRRequestHeaderIn
    {


        public string rot_ID { get; set; }
        public string UserId { get; set; }

    }
    public class SRRequestDetailIn
    {


        public string RequestID { get; set; }
        

    }
    public class GetPendingRtnRequestHeader
    {

        public string RequestID { get; set; }
        public string InvoiceNumber { get; set; }
        public string RequestNumber { get; set; }
        public string date { get; set; }

       
        public string cus_ID { get; set; }
        public string Request_ID { get; set; }

        public string inv_ID { get; set; }
        public string ReturnType { get; set; }
        public string SubTotal { get; set; }

        public string Vat { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string Signature { get; set; }
        public string Attachment { get; set; }
        public string Remark { get; set; }
        public string Time { get; set; }

    }
    public class GetPendingRtnRequestDetail
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
        public string Image { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string Vat { get; set; }
        public string GrandTotal { get; set; }
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }

    }

    public class SRRequestInvoicesIn
    {


        public string rot_ID { get; set; }
        public string UserId { get; set; }

    }
    public class SRRequestInvoicesDetailIn
    {


        public string inv_ID { get; set; }
        

    }
    public class GetRtnRequestInvoiceHeader
    {

        public string InvoiceNumber { get; set; }

        public string date { get; set; }
        public string rot_ID { get; set; }
       
        public string cus_ID { get; set; }


        public string inv_ID { get; set; }

    }
    public class GetRtnRequestInvoiceDetail
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
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }
        public string VatPerc { get; set; }
        public string prd_IsBatchItem { get; set; }
        public List<RTNInvoiceBatchSerial> BatchSerial { get; set; }


    }
    public class RTNInvoiceBatchSerial
    {
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string BaseUOM { get; set; }
        public string OrderedQty { get; set; }
        public string AdjustedQty { get; set; }
        public string LoadInQty { get; set; }
        public string ind_itm_ID { get; set; }
        public string inv_ID { get; set; }
    }

    public class PostAttachment
    {
        public string TransID { get; set; }
        public string UserID { get; set; }
    }


    public class GetMultipleInvoiceItemiN
    {
        public string Rot_ID { get; set; }
        public string Cus_ID { get; set; }
    }

    public class GetMultipleInvoiceItemOut
    {
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string rrd_HUOM { get; set; }
        public string rrd_HQty { get; set; }
        public string rrd_LUOM { get; set; }
        public string rrd_LQty { get; set; }
        public string rrd_HigherPrice { get; set; }
        public string rrd_LowerPrice { get; set; }
        public string rrd_LineTotal { get; set; }
        public string rrd_Vat { get; set; }
        public string rrd_GrandTotal { get; set; }
        public string prd_IsBatchItem { get; set; }

    }

    public class GetReturnItemInvoiceIn
    {
        public string prd_ID { get; set; }
    }


    public class GetReturnItemInvoiceOut
    {
        public string rrh_inv_ID { get; set; }
        public string inv_InvoiceID { get; set; }
        public List<GetReturnItemInvoiceBatch> BatchSerial { get; set; }
    }
    public class GetReturnItemInvoiceBatch
    {
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string BaseUOM { get; set; }
        public string OrderedQty { get; set; }
        public string AdjustedQty { get; set; }
        public string LoadInQty { get; set; }
        public string itm_ID { get; set; }
        public string inv_ID { get; set; }
    }


    public class GetMultipleInvoiceItemDetIn
    {
        public string invID { get; set; }
        public string prdID { get; set; }
    }

    public class InsMultipleInvReturnReqHeader
    {
        public string rotid { get; set; }
        public string cusid { get; set; }
        public string subtotal { get; set; }
        public string Amount { get; set; }
        public string usrid { get; set; }
        public string Detaildata { get; set; }
        public string cseID { get; set; }
        public string udpID { get; set; }
        public string Type { get; set; }
        public string InvId { get; set; }
        public string BatchData { get; set; }


    }
    public class InsMultipleInvReturnReqDetails
    {
        public string itmid { get; set; }
        public string huom { get; set; }
        public string hqty { get; set; }
        public string luom { get; set; }
        public string lqty { get; set; }

        public string amount { get; set; }
        public string rsnid { get; set; }
    } 
    public class InsMultipleInvReturnReqBatch
    {
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string BaseUOM { get; set; }
        public string OrderedQty { get; set; }
        public string AdjustedQty { get; set; }
        public string LoadInQty { get; set; }
        public string itm_ID { get; set; }
        public string inv_ID { get; set; }
    }
    public class InsMultipleInvReturnReqStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
        public string ReqID { get; set; }
    }


}