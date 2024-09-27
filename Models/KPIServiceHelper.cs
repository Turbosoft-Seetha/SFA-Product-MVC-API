using System;
using System.Collections.Generic;
using System.Linq;
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

}