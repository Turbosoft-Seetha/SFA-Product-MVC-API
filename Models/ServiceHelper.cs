using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class ServiceHelper
    {
    }
    public class ServiceRequestIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }
        public string AssetID { get; set; }
    }
    public class ServiceRequestOut
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
        public string AssetCode { get; set; }



    }
    public class ComplaintTypeIn
    {

        public string UserId { get; set; }
    }
    public class ComplaintTypeOut
    {
        public string CTypeID { get; set; }
        public string CTypeCode { get; set; }
        public string CTypeName { get; set; }
    }
    public class TroubleShootIn
    {

        public string UserId { get; set; }
    }
    public class TroubleShootOut
    {
        public string TroubleShootID { get; set; }
        public string TroubleShootName { get; set; }

    }
    public class InsServiceRqstIn
    {
        public string RequestCode { get; set; }

        public string AssetID { get; set; }
        public string ComplaintID { get; set; }
        public string Remarks { get; set; }


        public string cusID { get; set; }

        public string udpID { get; set; }
        public string cseID { get; set; }
        public string ComplaintTitle { get; set; }
        public string AssetMasterID { get; set; }



    }
    public class InsServiceRqstOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
    public class ServiceJobIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }
    }
    public class ServiceJobOut
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


        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string ComplaintTitle { get; set; }
        public string jobID { get; set; }
        public string jobNumber { get; set; }
        public string ScheduledDate { get; set; }

        public string EstimateStartTime { get; set; }
        public string EstimateEndTime { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }
        public string ExpectedDuration { get; set; }

        public string ActualDuration { get; set; }
        public string BackendInstruction { get; set; }

    }

    public class ServiceQuestionsIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }
    }
    public class ServiceQuestionsOut
    {

        public string cus_ID { get; set; }
        public string AssetID { get; set; }

        public string AssetName { get; set; }
        public string QID { get; set; }
        public string Question { get; set; }
        public string Comments { get; set; }

        public string QOrder { get; set; }
        public string QType { get; set; }

        public string IsMandatory { get; set; }
        public string Answer { get; set; }

        public string AOrder { get; set; }

        public string IsAnswer { get; set; }
        public string AID { get; set; }





    }
    public class AssetTypeIn
    {

        public string UserId { get; set; }
    }
    public class AssetTypeOut
    {
        public string AssetTypeID { get; set; }
        public string AssetTypeCode { get; set; }
        public string AssetTypeName { get; set; }
        public string cusID { get; set; }
        public string cusCode { get; set; }
        public string cusName { get; set; }
    }

    public class ServiceApprovalIn
    {

        public string usrID { get; set; }
        public string udpID { get; set; }
        public string rotID { get; set; }
        public string ReqID { get; set; }
        public string Date { get; set; }
        public string ApprovalDetail { get; set; }
        public string cusID { get; set; }
        public string JobID { get; set; }
        public string Total { get; set; }
        public string Discount { get; set; }
        public string SubTotal { get; set; }
        public string VAT { get; set; }
        public string GrandTotal { get; set; }

    }
    public class ServiceApprovalDetail
    {
        public string prdID { get; set; }
        public string UOM { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string LineTotal { get; set; }

    }
    public class ServiceApprovalOut
    {
        public string Res { get; set; }
        public string status { get; set; }

    }
    public class ServiceApprovalStatusIn
    {

        public string ReqID { get; set; }
        public string usrID { get; set; }

        public string cusID { get; set; }
        public string udpID { get; set; }
        public string JobID { get; set; }

    }
    public class ServiceApprovalStatusOut
    {

        public string ApprovalStatus { get; set; }



    }

    public class ServiceRequestImgIn
    {

        public string ReqCode { get; set; }
        public string ImageType { get; set; }


    }
    public class ServiceJobImageIn
    {

        public string JobID { get; set; }
        public string udpID { get; set; }
        public string ImageType { get; set; }


    }

    public class ServiceJobATin
    {


        public string cusID { get; set; }
        public string userID { get; set; }
        public string udpID { get; set; }
        public string reqID { get; set; }
        public string cse_ID { get; set; }
        public string CreatedDate { get; set; }

        public string JsonValue { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string RequiredParts { get; set; }
        public string jobID { get; set; }
        public string ActionType { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }



    }
    public class RequiredPartsJson
    {

        public string prdID { get; set; }
        public string UOM { get; set; }
        public string Qty { get; set; }

    }


    public class ServiceJobJson
    {

        public string question { get; set; }
        public string answer { get; set; }
        public string type { get; set; }

        public string remarks { get; set; }



    }
    public class ServiceJobATOut
    {

        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }




    }
    public class ServiceFieldsIn
    {
        public string ServiceReqID { get; set; }

    }
    public class ServiceFieldsOut
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
        public string ScheduledDate { get; set; }
        public string ReqstCode { get; set; }
        public string CompletedOn { get; set; }

        public List<ServiceJobHeader> JobHeader { get; set; }


    }
    public class ServiceJobHeader
    {
        internal string ActualEndtime;

        public string JobID { get; set; }
        public string JobNumber { get; set; }
        public string Asset { get; set; }
        public string Date { get; set; }
        public string JobStatus { get; set; }
        public string JobType { get; set; }
        
        public string Duration { get; set; }
        public string EstimateStartTime { get; set; }
        public string EstimateEndTime { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }
        public string ScheduledDate { get; set;}
        public string ActualDuration { get; set; }
        public string SerialNum { get; set; }
        public string cusCode { get; set; }

        public string cusName { get; set; }
        public string BackndRemark { get; set; }



    }
    public class ServiceReqstDetailIN
    {
        public string ReqCode { get; set; }
        public string Status { get; set; }

    }

    public class ServiceReqstDetailOUT
    {
        public string RespondedDate { get; set; }
        public string AssignedRotCode { get; set; }
        public string AssignedRotName { get; set; }
        public string AssignedDate { get; set; }
        public string AssignedToDate { get; set; }
        public string snr_TroubleShoots { get; set; }


    }

    public class ServiceReqDetailIN
    {
        public string ReqCode { get; set; }
        public string Status { get; set; }

    }
    public class ServiceReqDetailOUT
    {
        public string RespondedDate { get; set; }
        public string AssignedRotCode { get; set; }
        public string AssignedRotName { get; set; }
        public string AssignedDate { get; set; }
        public string AssignedToDate { get; set; }
        public string snr_TroubleShoots { get; set; }
        public string ActionTakeDate { get; set; }
        public string sjd_Question { get; set; }
        public string sjd_Answer { get; set; }
        public string sdj_Type { get; set; }
        public string sjd_Remarks { get; set; }

    }

    public class RepairPartsIn
    {
        public string ReqID { get; set; }

    }
    public class RepairPartsOut
    {
        public string srp_ID { get; set; }
        public string RequestID { get; set; }
        public string ServiceJobID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_Description { get; set; }
        public string UOM { get; set; }
        public string Qty { get; set; }
        public string Date { get; set; }

    }
    public class ServiceJobDetailIN
    {
        public string JobID { get; set; }

    }
    public class ServiceJobDetailOut
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
        public string EstimateStartTime { get; set; }
        public string EstimateEndTime { get; set; }
        public List<ServiceJobDetailData> JobDetails { get; set; }
        public string Duration { get; set; }
        public string ActualDuration { get; set; }

    }
    public class ServiceJobDetailData
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public string Remarks { get; set; }

    }
    public class ReqPartsIn
    {
        public string JobID { get; set; }
    }
    public class ReqPartsOut
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

    public class ServiceJobInvoiceIN
    {


        public string JobID { get; set; }

    }
    public class ServiceJobInvoiceOUT
    {


        public string VAT { get; set; }
        public string GrandTotal { get; set; }
        public string SubTotal { get; set; }
        public string PayType { get; set; }
        public string PayMode { get; set; }
        public List<ServiceJobInvoiceItems> ItemData { get; set; }
        public string Discount { get; set; }


    }
    public class ServiceJobInvoiceItems
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

    public class ServiceReqResovedIn
    {
        public string rotID { get; set; }
        public string AssetID { get; set; }
        public string AssetSerialNum { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string cusID { get; set; }
    }
    public class ServiceReqResovedOut
    {
        public string AssetID { get; set; }
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
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
        public string ResolvedDate { get; set; }
        public string ResolvedTime { get; set; }

        public string cus_Code { get; set; }
        public string cus_Name { get; set; }

    }
    public class ResolvedAsssetIn
    {
        public string rotID { get; set; }

    }
    public class ResolvedAsssetOut
    {
        public string AssetTypeID { get; set; }
        public string AssetTypeCode { get; set; }
        public string AssetTypeName { get; set; }

    }
    public class ResolvedAsssetSerialIn
    {
        public string rotID { get; set; }

        public string AssetTypeID { get; set; }
    }
    public class ResolvedAsssetSerialOut
    {
        public string AssetSerialID { get; set; }
        public string AssetSerialCode { get; set; }
        public string AssetSerialName { get; set; }

    }
    public class AssetTypeAllOut
    {
        public string AssetTypeID { get; set; }
        public string AssetTypeCode { get; set; }
        public string AssetTypeName { get; set; }

    }
    public class AssetTypeAllIn
    {

        public string UserId { get; set; }
    }
    public class JobInventoryIn
    {
        public string sjhID { get; set; }
    }
    public class JobInventoryOut
    {
        public string IntID { get; set; }
        public string prdID { get; set; }
        public string prdName { get; set; }
        public string prdCode { get; set;}
        public string prdDesc { get; set;}
        public string uom {  get; set; }
        public string qty { get; set; }
        public string Date {  get; set; }
        public string Status { get; set; }
    }
    public class JobAccIn
    {
        public string sjhID { get; set; }
    }
    public class JobAccOut
    {
        public string JobAccID { get; set; }
        public string AccID { get; set; }
        public string AccCode { get; set; }
        public string AccName { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }

}