using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class OrderHelper
    {
    }
    public class DraftOrderIn
    {

        public string UserId { get; set; }
        public string rot_ID { get; set; }
    }
    public class DraftOrderHeader
    {

        public string ord_ID { get; set; }
        public string OrderID { get; set; }
        public string date { get; set; }

        public List<DraftOrderDetail> OrderDetail { get; set; }
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }
        public string SubTotal { get; set; }

        public string VAT { get; set; }
        public string GrandTotal { get; set; }
        public string ExpectedDelDate { get; set; }

        public string PayMode { get; set; }
        public string Discount { get; set; }
        public string SubTotalWODiscount { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }

    }
    public class DraftOrderDetail
    {

        public string prd_ID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }


        public string prd_Name { get; set; }

        public string prd_code { get; set; }
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }
        public string Price { get; set; }
        public string TotalQty { get; set; }

        public string SubTotal { get; set; }
        public string VatPercent { get; set; }
        public string VatAmount { get; set; }

        public string Discount { get; set; }
        public string GrandTotal { get; set; }

        public string TransType { get; set; }

        public string StdHighPrice { get; set; }

        public string StdLowPrice { get; set; }
        public string SellingHighPrice { get; set; }

        public string SellingLowPrice { get; set; }
        public string HigherUPC { get; set; }
        public string LowerUPC { get; set; }



    }
    public class quotationOrderIn
    {

        public string cus_ID { get; set; }
        public string ord_OrderRemarks { get; set; }
        public string ord_rot_ID { get; set; }
        public string ord_usr_ID { get; set; }
        public string ord_Platform { get; set; }
        public string XMLdata { get; set; }
        public string CreatedDate { get; set; }
        public string GeoCode { get; set; }
        public string GeoCodeName { get; set; }
        public string CreationMode { get; set; }

        public string ord_cse_ID { get; set; }
        public string ord_udp_ID { get; set; }
        public string ord_AppOrderID { get; set; }
        public string ord_SubTotal { get; set; }
        public string ord_VAT { get; set; }
        public string ord_GrandTotal { get; set; }
        public string ord_ExpectedDelDate { get; set; }
        public string XMLdataQlftn { get; set; }
        public string XMLdataAssgn { get; set; }
        public string PayMode { get; set; }

        public string VoidMode { get; set; }
        public string VoidTime { get; set; }
        public string Void { get; set; }
        public string CreditAmntOverrideKey { get; set; }
        public string CreditAmntOverridePass { get; set; }
        public string CreditDayOverrideKey { get; set; }
        public string CreditDayOverridePass { get; set; }
        public string VoidOverrideKey { get; set; }
        public string VoidOverridePass { get; set; }
        public string VoidUser { get; set; }

        public string VoidPlatform { get; set; }
        public string Discount { get; set; }
        public string ord_SubTotal_WODiscount { get; set; }
        public string ord_Type { get; set; }
        public string Image { get; set; }





    }
    public class quotationProducts
    {

        public string itmID { get; set; }
        public string HigherUOM { get; set; }
        public string LowerUOM { get; set; }
        public string HigherQty { get; set; }
        public string LowerQty { get; set; }
        public string LowerPrice { get; set; }

        public string HigherPrice { get; set; }
        public string Price { get; set; }
        public string TotalQty { get; set; }
        public string odd_SubTotal { get; set; }
        public string odd_VATPercent { get; set; }
        public string odd_VATAmount { get; set; }
        public string odd_Discount { get; set; }
        public string odd_GrandTotal { get; set; }
        public string odd_TransType { get; set; }
        public string odd_StdHigherPrice { get; set; }
        public string odd_StdLowerPrice { get; set; }
        public string odd_SellingHigherPrice { get; set; }
        public string odd_SellingLowerPrice { get; set; }



       
                       
    }
    public class quotationQualification
    {
        public string prd_ID { get; set; }
        public string prm_ID { get; set; }
        public string HigherQty { get; set; }
        public string LowerQty { get; set; }
        public string HigherUOM { get; set; }
        public string LowerUOM { get; set; }
    }
    public class quotationAssignment
    {
        public string prd_ID { get; set; }
        public string prm_ID { get; set; }
        public string HigherQty { get; set; }
        public string LowerQty { get; set; }
        public string HigherUOM { get; set; }
        public string LowerUOM { get; set; }
        public string TotalQty { get; set; }
    }
    public class quotationOrderOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        
    }
    public class OrderStatusHeaderIN
    {
        public string Date { get; set; }
        public string rotID { get; set; }

    }
    public class OrderStatusHeaderOut
    {
        public string ord_ID { get; set; }
        public string OrderID { get; set; }
        public string date { get; set; }

        public string rot_ID { get; set; }
        public string cus_ID { get; set; }
        public string SubTotal { get; set; }

        public string VAT { get; set; }
        public string GrandTotal { get; set; }
        public string ExpectedDelDate { get; set; }

        public string PayMode { get; set; }
        public string Discount { get; set; }
        public string SubTotalWODiscount { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }

    }
    public class OrderDetailIN
    {
      
        public string ordID { get; set; }

    }
    public class OrderStatusDetailOut
    {

        public string prd_ID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }


        public string prd_Name { get; set; }

        public string prd_code { get; set; }
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }
        public string Price { get; set; }
        public string TotalQty { get; set; }

        public string SubTotal { get; set; }
        public string VatPercent { get; set; }
        public string VatAmount { get; set; }

        public string Discount { get; set; }
        public string GrandTotal { get; set; }

        public string TransType { get; set; }

        public string StdHighPrice { get; set; }

        public string StdLowPrice { get; set; }
        public string SellingHighPrice { get; set; }

        public string SellingLowPrice { get; set; }
        public string HigherUPC { get; set; }
        public string LowerUPC { get; set; }


    }
    public class PostLPOAttachments
    {
        public string OrderNo { get; set; }
        public string UserID { get; set; }
        public string AttachType { get; set; }

    }
    public class PostLPOAttachmentsOut
    {
        public string Mode { get; set; }
        public string Status { get; set; }

    }
    public class PostTransAttachmentsIN
    {
        public string TransNo { get; set; }
        public string UserID { get; set; }
        public string CusOperation { get; set; }


    }
    public class PostTransAttachmentsOut
    {
        public string Mode { get; set; }
        public string Status { get; set; }

    }

    public class orderPDFIn
    {
        public string OrderID { get; set; }
      

    }
    public class orderPDFOut
    {
        public string PDFurl { get; set; }


    }
    public class PostfreeSampleData
    {
        //public string OrderID { get; set; }
        //public string RotId { get; set; }
        //public string CusId { get; set; }
        //public string UserId { get; set; }
        //public string UdpId { get; set; }

        //public string JSONString { get; set; }
        public string OrderID { get; set; }
        public string cus_ID { get; set; }
        public string ord_rot_ID { get; set; }
        public string ord_usr_ID { get; set; }
        public string ord_Platform { get; set; }
        public string JSONString { get; set; }
        public string ord_cse_ID { get; set; }
        public string GeoCode { get; set; }
        public string GeoCodeName { get; set; }
        public string CreationMode { get; set; }
        public string ord_udp_ID { get; set; }
        public string ord_AppOrderID { get; set; }
        public string ord_SubTotal { get; set; }
        public string ord_VAT { get; set; }
        public string ord_GrandTotal { get; set; }
        public string VoidMode { get; set; }
        public string VoidTime { get; set; }
        public string Void { get; set; }
        public string VoidUser { get; set; }
        public string VoidPlatform { get; set; }
        public string Discount { get; set; }
        public string ord_SubTotal_WODiscount { get; set; }
        public string ord_Type { get; set; }

    }
    public class PostFreeSamplelDetData
    {
        public string itmID { get; set; }
        public string HigherQty { get; set; }
        public string HigherUOM { get; set; }
        public string LowerQty { get; set; }
        public string LowerUOM { get; set; }
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }
        public string Price { get; set; }
        public string TotalQty { get; set; }
        public string odd_VATPercent { get; set; }
        public string odd_Discount { get; set; }
        public string odd_TransType { get; set; }
        public string odd_SubTotal { get; set; }
        public string odd_VATAmount { get; set; }
        public string odd_GrandTotal { get; set; }
        public string odd_StdHigherPrice { get; set; }
        public string odd_StdLowerPrice { get; set; }
        public string odd_SellingHigherPrice { get; set; }
        public string odd_SellingLowerPrice { get; set; }
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