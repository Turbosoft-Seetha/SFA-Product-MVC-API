using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace MVC_API.Models
{
    public class KPIServiceHelper
    {
    }
    public class PlannedSJIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }

    }
    public class PlannedSJOut
    {
        public string totalPlanned { get; set; }
        public string completed { get; set; }

        public string Pending { get; set; }
    }
    public class ActualSJOut
    {
        public string Actual { get; set; }
        public string Planned { get; set; }
        public string UnPlanned { get; set; }
    }
    public class InvoiceSJOut
    {
        public string InvoicedAmount { get; set; }
        public string Credit { get; set; }
        public string HardCash { get; set; }
        public string OnlinePayment { get; set; }
        public string POS { get; set; }

    }
    public class InvCountsSJOut
    {

        public string CRcount { get; set; }
        public string CScount { get; set; }
        public string OPcount { get; set; }
        public string POScount { get; set; }

    }
    public class AssetCountsSJOut
    {
        public string Tracked { get; set; }
        public string NotTracked { get; set; }
        public string TotalVisited { get; set; }

    }
    public class AssetAddRemvReqCountsSJOut
    {
        public string AddreqCount { get; set; }
        public string RemReqCount { get; set; }
        public string TotalServiceRequest { get; set; }
        public string OpenServiceRequest { get; set; }
        public string ResolvedServiceRequest { get; set; }


    }
    public class KPISJDetailIN
    {
        public string JobID { get; set; }

    }
    public class KPISJDetailOut
    {
        public string AssignedRotCode { get; set; }
        public string AssignedRotName { get; set; }
        public string AssignedDate { get; set; }
        public string AssignedToDate { get; set; }
        public string sjh_ActionType { get; set; }
        public string ActionTakenDate { get; set; }

        public string Status { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }

        public List<KPISJDetailData> JobDetails { get; set; }

    }
    public class KPISJDetailData
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }

    }
    public class KPIServiceReqstDetailIN
    {
        public string ReqCode { get; set; }
        public string Status { get; set; }

    }

    public class KPIServiceReqstDetailOUT
    {
        public string RespondedDate { get; set; }
        public string AssignedRotCode { get; set; }
        public string AssignedRotName { get; set; }
        public string AssignedDate { get; set; }
        public string AssignedToDate { get; set; }
        public string snr_TroubleShoots { get; set; }


    }
    public class KPIServiceFieldsIn
    {
        public string ServiceReqID { get; set; }

    }
    public class KPIServiceFieldsOut
    {
        public string Asset { get; set; }
        public string Date { get; set; }
        public string Complaint { get; set; }
        public string ServiceReqRemarks { get; set; }
        public string ServiceReqImages { get; set; }
        public string TroubleShoots { get; set; }
        public string RespondedDate { get; set; }
        public string Status { get; set; }
        public string SerialNum { get; set; }
        public string ComplaintType { get; set; }

        public List<KPIServiceJobHeader> JobHeader { get; set; }
    }
    public class KPIServiceJobHeader
    {
        public string JobID { get; set; }
        public string JobNumber { get; set; }
        public string Asset { get; set; }
        public string Date { get; set; }
        public string JobStatus { get; set; }
        public string ScheduledDate { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndtime { get; set; }
        public string Duration { get; set; }
        public string EstimateStartTime { get; set; }
        public string EstimateEndTime { get; set; }

        public string ActualEndTime { get; set; }
        public string ActualDuration { get; set; }

    }

    public class KPIReqPartsIn
    {
        public string JobID { get; set; }
    }
    public class KPIReqPartsOut
    {

        public string ServiceJobID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }

        public string UOM { get; set; }
        public string Qty { get; set; }
        public string CreatedDate { get; set; }
        public string Remarks { get; set; }
        public string CategoryID { get; set; }
        public string BrandID { get; set; }
    }
    public class KPIServiceJobInvoiceIN
    {


        public string JobID { get; set; }

    }
    public class KPIServiceJobInvoiceOUT
    {


        public string VAT { get; set; }
        public string GrandTotal { get; set; }
        public string SubTotal { get; set; }
        public List<KPIServiceJobInvoiceItems> ItemData { get; set; }


    }
    public class KPIServiceJobInvoiceItems
    {
        public string prdCode { get; set; }
        public string prdName { get; set; }
        public string prdID { get; set; }
        public string categoryID { get; set; }
        public string BrandID { get; set; }
        public string IsChargable { get; set; }
        public string UOM { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string LineTotal { get; set; }
        public string Discount { get; set; }

    }
    public class KPITroubleShootIn
    {

        public string UserId { get; set; }
    }
    public class KPITroubleShootOut
    {
        public string TroubleShootID { get; set; }
        public string TroubleShootName { get; set; }

    }
    public class KPIServiceApprovalStatusIn
    {

        public string ReqID { get; set; }
        public string usrID { get; set; }

        public string rotID { get; set; }
        public string udpID { get; set; }
        public string JobID { get; set; }

    }
    public class KPIServiceApprovalStatusOut
    {
        public string ApprovalStatus { get; set; }

    }
    public class KPIServiceJobIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }
    }
    public class KPIServiceJobOut
    {

        public string ReqID { get; set; }
        public string RequestID { get; set; }
        public string AssetID { get; set; }
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string SerialNo { get; set; }

        public string ComplaintTypeID { get; set; }
        public string ComplaintType { get; set; }

        public string Remarks { get; set; }

        public string cus_ID { get; set; }

        public string Images { get; set; }

        public string jobID { get; set; }

        public string jobNumber { get; set; }
        public string ScheduledDate { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string ComplaintTitle { get; set; }

        public string cuscode { get; set; }
        public string cusname { get; set; }

        public string JobStatus { get; set; }
        public string Duration { get; set; }
        public string ActualDuration { get; set; }

        public string ExpectedStartTime { get; set; }
        public string ActualStartTime { get; set; }

    }
    public class KPICusAssetTrackingIn
    {
        public string udp_ID { get; set; }

    }
    public class KPICusAssetTrackingOut
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
    public class KPICusAssetTrackingDetailIn
    {
        public string AssetTrackingID { get; set; }
    }
    public class KPICusAssetTrackingDetailOut
    {
        public string AssetTrackingID { get; set; }
        public string AssetTrackDetailID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }
        public string qst_Name { get; set; }
        public string Options { get; set; }

    }
    public class KPICusAssetAddReqIn
    {
        public string udp_ID { get; set; }

    }
    public class KPICusAssetAddReqOut
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
    public class KPICusAssetRemoveReqIn
    {
        public string udp_ID { get; set; }

    }
    public class KPICusAssetRemoveReqOut
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
    public class KPIServiceRequestIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }
        public string AssetID { get; set; }
    }
    public class KPIServiceRequestOut
    {

        public string AssetID { get; set; }
        public string AssetRefName { get; set; }
        public string SerialNo { get; set; }

        public string Complaint { get; set; }

        public string Remarks { get; set; }

        public string cus_ID { get; set; }

        public string Images { get; set; }
        public string AssetMandColumns { get; set; }

        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string RespondedOn { get; set; }
        public string RequestCode { get; set; }
        public string AssetType { get; set; }
        public string TroubleShoots { get; set; }
        public string AssignedRotID { get; set; }
        public string AssignedRotCode { get; set; }
        public string AssignedRotName { get; set; }
        public string AssignedDate { get; set; }
        public string CreatedTime { get; set; }
        public string AssetTypeID { get; set; }
        public string ComplaintID { get; set; }
        public string AssetTypeCode { get; set; }
        public string RequestID { get; set; }
        public string SerialNum { get; set; }
        public string ComplaintType { get; set; }
        public string cuscode { get; set; }
        public string cusname { get; set; }
        public string CompletedOn { get; set; }


    }
    public class SRAssetTypeIN
    {
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }

    }


    public class SRAssetTypeOut
    {
        public string AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public string AssetTypeCode { get; set; }
        public string Planogram { get; set; }
        public string Count { get; set; }


    }
    public class SRByAssetTypeIN
    {
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }
        public string AssetTypeID { get; set; }


    }


    public class SRByAssetTypeOut
    {

        public string AssetID { get; set; }
        public string AssetRefName { get; set; }
        public string Complaint { get; set; }

        public string Remarks { get; set; }

        public string cus_ID { get; set; }

        public string Images { get; set; }


        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string RespondedOn { get; set; }
        public string RequestCode { get; set; }
        public string AssetType { get; set; }
        public string TroubleShoots { get; set; }

        public string CreatedTime { get; set; }
        public string AssetTypeID { get; set; }
        public string ComplaintID { get; set; }
        public string AssetTypeCode { get; set; }
        public string RequestID { get; set; }
        public string SerialNum { get; set; }
        public string ComplaintType { get; set; }

        public string JobCount { get; set; }

    }
    public class KPIPlannedServiceRequestOut
    {

        public string AssetID { get; set; }
        public string AssetRefName { get; set; }
        public string SerialNo { get; set; }

        public string Complaint { get; set; }

        public string Remarks { get; set; }

        public string cus_ID { get; set; }

        public string Images { get; set; }

        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string RespondedOn { get; set; }
        public string RequestCode { get; set; }
        public string AssetType { get; set; }

        public string CreatedTime { get; set; }
        public string AssetTypeID { get; set; }
        public string ComplaintID { get; set; }
        public string AssetTypeCode { get; set; }
        public string RequestID { get; set; }

        public string ComplaintType { get; set; }
        public string cuscode { get; set; }
        public string cusname { get; set; }

        public string Type { get; set; }
        public string JobID { get; set; }
        public string JobNumber { get; set; }

        public string ScheduledDate { get; set; }
        public string Duration { get; set; }
        public string EstimateStartTime { get; set; }
        public string EstimateEndTime { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }
        public string ActualDuration { get; set; }


    }
    public class KPIVisitNotTrackingOut
    {

        public string atm_ID { get; set; }
        public string atm_Code { get; set; }
        public string atm_Name { get; set; }

        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string cus_NameArabic { get; set; }

        public string ast_ID { get; set; }
        public string ast_Code { get; set; }
        public string ast_Name { get; set; }

        public string Type { get; set; }
        public string aah_Name { get; set; }
        public string aah_Remarks { get; set; }
        public string aah_img { get; set; }
        public string aah_rsn_ID { get; set; }
        public string Planogram { get; set; }

    }
    public class AllCountSJIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }

    }
    public class AllCountSJOut
    {
        public string All { get; set; }
        public string Open { get; set; }
        public string Resolved { get; set; }
        public string ActionTaken { get; set; }

    }
    public class KPISurveyDetailIn
    {
        public string SurveyHeaderID { get; set; }
    }
    public class KPISurveyDetailOut
    {
        public string SurveyHeaderID { get; set; }
        public string SurveyDetailID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }
        public string qst_Name { get; set; }
        public string Options { get; set; }

    }

    //---------------Sales Order------------------------
    public class SalesOrderInKPI
    {
        public string rotID { get; set; }
        public string type { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }

    }
    public class SalesOrderOut
    {
        public string ord_id { get; set; }
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string cusArName { get; set; }
        public string OrdNO { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string LPO { get; set; }
        public string Total { get; set; }
        public string ord_Discount { get; set; }
        public string ord_SubTotal { get; set; }
        public string ord_VATAmount { get; set; }
        public string ord_GrandTotal { get; set; }
        public string Void { get; set; }

    }
    
    public class SalesOrderDetailIn
    {
        public string ord_ID { get; set; }

    }
    public class SalesOrderDetailOut
    {
        public string odd_ID { get; set; }
        public string odd_ord_ID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string odd_HigherUOM { get; set; }
        public string odd_LowerUOM { get; set; }
        public string odd_HigherQty { get; set; }
        public string odd_LowerQty { get; set; }
        public string odd_HigherPrice { get; set; }
        public string odd_LowerPrice { get; set; }
        public string odd_Price { get; set; }
        public string odd_TotalQty { get; set; }

    }

    //-------------------Invoice

    public class SelInvoiceIn
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class SelInvoiceOut
    {

        public string ID { get; set; }
        public string InvoiceNo { get; set; }
        public string cusName { get; set; }
        public string cusArName { get; set; }
        public string cusCode { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string Attachment { get; set; }
        public string PaidAmount { get; set; }
        public string InvAmount { get; set; }
        public string Balance { get; set; }
        public string Signature { get; set; }
        public string transType { get; set; }
    }
    public class InvoiceDetailInKPI
    {
        public string UserID { get; set; }
        public string ID { get; set; }

    }
    public class InvoiceDetailOutKPI
    {
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string LowerUOM { get; set; }
        public string HigherUOM { get; set; }
        public string LowerQty { get; set; }
        public string HigherQty { get; set; }
        public string Amount { get; set; }
        public string transcationtype { get; set; }
        public string returnType { get; set; }
        public string huomPrice { get; set; }
        public string luomPrice { get; set; }


    }

    public class InvoiceFooterInKPI
    {
        public string UserID { get; set; }
        public string ID { get; set; }

    }
    public class invoiceTypeFooter
    {

        public string SalesValue { get; set; }
        public string SalesDiscount { get; set; }
        public string SalesVAT { get; set; }
        public string SalesTotal { get; set; }
        public string BRValue { get; set; }
        public string BRDiscount { get; set; }
        public string BRVAT { get; set; }
        public string BRTotal { get; set; }
        public string GRValue { get; set; }
        public string GRDiscount { get; set; }
        public string GRVAT { get; set; }
        public string GRTotal { get; set; }
        public string FCValue { get; set; }
        public string FCDiscount { get; set; }
        public string FCVAT { get; set; }
        public string FCTotal { get; set; }
    }

    //----------inv Reconfirm

    public class InvRecheaderIn
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class InvRecheaderOut
    {

        public string ID { get; set; }
        public string TransID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }

    public class InvRecDetIn
    {
        public string ID { get; set; }

    }
    public class InvRecDetOutKPI
    {

        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string SysLowerUOM { get; set; }
        public string SysHigherUOM { get; set; }
        public string SysLowerQty { get; set; }
        public string SysHigherQty { get; set; }
        public string PhyLowerUOM { get; set; }
        public string PhyHigherUOM { get; set; }
        public string PhyLowerQty { get; set; }
        public string PhyHigherQty { get; set; }
        public string ExLowerUOM { get; set; }
        public string ExHigherUOM { get; set; }
        public string ExLowerQty { get; set; }
        public string ExHigherQty { get; set; }

        public string CatID { get; set; }
        public string SubCatID { get; set; }
        public string IsNEwlyAdded { get; set; }

    }
    //-----AR---------------------------------
    public class ARHeaderInKPI
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }
        public string PayType {  get; set; }
    }
    public class ARHeaderOutKPI
    {
        public string arh_ID { get; set; }
        public string arh_ARNumber { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string cusArName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string arh_PayMode { get; set; }
        public string arh_PayType { get; set; }
        public string arh_CollectedAmount { get; set; }
        public string arh_BalanceAmount { get; set; }
        public string arp_ChequeNo { get; set; }
        public string arp_ChequeDate { get; set; }
        public string RecImage { get; set; }
        public string Attachment { get; set; }
        public string Sign { get; set; }
        public string bankName { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }

    }
    public class ARDetailInKPI
    {
        public string arh_ID { get; set; }
    }
    public class ARDetailOutKPI
    {
        public string ard_ID { get; set; }
        public string ard_arh_ID { get; set; }
        public string ard_Amount { get; set; }
        public string ard_PDC_Amount { get; set; }
        public string InvoiceID { get; set; }
        public string InvoicedOn { get; set; }
        public string InvoiceAmount { get; set; }
        public string AmountPaid { get; set; }
        public String Balance {  get; set; }

    }

    public class SelAdvInKPI
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class SelAdvOutKPI
    {

        public string ID { get; set; }
        public string TransID { get; set; }
        public string cusName { get; set; }
        public string cusArName { get; set; }
        public string cusCode { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMode { get; set; }
        public string adp_ChequeNo { get; set; }
        public string adp_ChequeDate { get; set; }
        public string RecImage { get; set; }
        public string Attachment { get; set; }
        public string Sign { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public string BankName { get; set; }
        public string CollectedAmount { get; set; }

    }
    public class SelInvoiceCountIN
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class SelINvCountOut
    {

        public string TotInvoice { get; set; }
        public string TotInvAmt {  get; set; }
        public string SalesInvoice { get; set; }
        public string GD { get; set; }
        public string BD { get; set; }
        public string FOC { get; set; }
        public string NoOfInvHC { get; set; }
        public string NoOfInvPOS { get; set; }
        public string NoOfInvOP { get; set; }
        public string NoOfInvCR { get; set; }
        public string HCAmt { get; set; }
        public string POSAmount { get; set; }
        public string OPAmt { get; set; }
        public string CRAmt { get; set; }


    }

    public class SelOutstandingeCountIN
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class SelOutstandingOut
    {

        public string Due { get; set; }
        public string TotalDue { get; set; }
        public string OverDue { get; set; }
        public string TotalOverDue { get; set; }
        public string OutStandingAmt { get; set; }
        public string TotalOutstanding { get; set; }


    }
    public class SelVisitIN
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class SelVisitOut
    {

        public string totplannedvisit { get; set; }
        public string visited { get; set; }
        public string pending { get; set; }
        public string Totalactualvisits { get; set; }
        public string planned { get; set; }
        public string unplanned { get; set; }
        public string TotProductive { get; set; }
        public string ProductivePlanned { get; set; }
        public string ProductiveUnplanned { get; set; }
        public string totNonProductive { get; set; }
        public string NonProdPlanned { get; set; }
        public string NonProdUnplanned { get; set; }


    }
    public class ARCOuntIn
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class ARCOuntOut
    {

        public string HCAmt { get; set; }
        public string POSAmount { get; set; }
        public string OPAmt { get; set; }
        public string CHAmt { get; set; }
        public string TotCollection { get; set; }
        public string HCCount { get; set; }
        public string OPCount { get; set; }
        public string POSCount { get; set; }
        public string CHCount { get; set; }
        public string totCount { get; set; }




    }
    public class AdvCountIn
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class AdvCountOut
    {
        public string TotalAdvPayCount { get; set; }
        public string TotAmt { get; set; }
        public string NoOfHC { get; set; }
        public string NoOfPOS { get; set; }
        public string NoOfOP { get; set; }
        public string NoOfCH { get; set; }
        public string HCAmt { get; set; }
        public string POSAmount { get; set; }
        public string OPAmt { get; set; }
        public string CHAmt { get; set; }


    }
    public class InvRecandV2VIN
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }

    }
    public class InvRecandV2VOut
    {

        public string IvnRecCount { get; set; }
        public string LodTransferIn { get; set; }
        public string LoadTransferOut { get; set; }


    }
    public class DelCountIn
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string udpId { get; set; }
        public string date { get; set; }

    }
    public class DelCountOut
    {

        public string plannedDel { get; set; }
        public string TotalDel { get; set; }
        public string TotalPD { get; set; }
        public string NotDel { get; set; }


    }


    public class SelTransferOut
    {
        public string ID { get; set; }
        public string TransID { get; set; }
        public string RouteCode { get; set; }
        public string RouteName { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }
    public class SelTransDetailIn
    {

        public string ID { get; set; }

    }
    public class SelTransferDetailOut
    {
        
        public string Prd_Name { get; set; }
        public string prd_Code { get; set; }
        public string turnouthuom { get; set; }
        public string turnoutluom { get; set; }
        public string turnouthqty { get; set; }
        public string turnoutlqty { get; set; }
        public string Confhqty { get; set; }
        public string conflqty { get; set; }
        public string udjhqty { get; set; }
        public string udjlqty { get; set; }
        public string CatId { get; set; }
        public string SubCatId { get; set; }

    }
    public class OrderCountOut
    {

        
        public string SalesOrderCount { get; set; }
        public string QuotationCount { get; set; }




    }
}