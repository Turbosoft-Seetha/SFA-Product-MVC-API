using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class PickModel
    {
    }

    public class PostPickingHeader
    {
        public string PickingID { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string jsonValue { get; set; }
    }

    public class PostPickingDetail
    {
        public int PickDetailId { get; set; }
        public string PickedQty { get; set; }
        public string Status { get; set; }
    }

    public class GetPickingStatus
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }

    public class PostPickUser
    {
        public string UserID { get; set; }
        public string RouteID { get; set; }
        public string itemID { get; set; }
    }
    public class GetAllPickingHeader
    {
        public string PickingID { get; set; }
        public string Number { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string StoreID { get; set; }
        public string Date { get; set; }
        public string Username { get; set; }
        public string store { get; set; }
        public string Mode { get; set; }
        public string User_ArName { get; set; }
        public string Arstore { get; set; }
        
    }
    public class GetPickingHeader
    {
        public string PickingID { get; set; }
        public string Number { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string StoreID { get; set; }
        public string Date { get; set; }
        public string Username { get; set; }
        public string store { get; set; }
        public string PickedBy { get; set; }
        public string User_ArName { get; set; }
        public string  ArPickedBy { get; set; }
        public string Arstore { get; set; }
  
        

    }

    public class GetPickingDetail
    {
        public string PickDetailID { get; set; }
        public string ItemID { get; set; }
        public string HigherUomID { get; set; }
        public string LowerUomID { get; set; }
        public string RequestedHQty { get; set; }
        public string RequestedLQty { get; set; }
        public string PickedHQty { get; set; }
        public string PickedLQty { get; set; }
        public string IsBatchItem { get; set; }
    }

    public class PostPickHeaderID
    {
        public string PickHeaderID { get; set; }
    }

    public class PostAssignHeader
    {
        public string UserID { get; set; }
        public string jsonValue { get; set; }
    }

    public class PostAssignDetail
    {
        public string PickHeaderID { get; set; }
    }

    public class PostStartPickHeader
    {
        public string PickHeaderID { get; set; }
        public string PickUserID { get; set; }
    }

    public class GetPickingRoute
    {
        public string RouteID { get; set; }
        public string RouteUserID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PickCount { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string User_Name { get; set; }
        public string User_ArName { get; set; }
        public string rot_ArName { get; set; }
    }

    public class PostPickingData
    {
        public string PickingId { get; set; }
        public string UserId { get; set; }
    }

    public class GetPickingItemHeader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Spec { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
        public string ReqHUOM { get; set; }
        public string ReqLUOM { get; set; }
        public string ReqHQty { get; set; }
        public string ReqLQty { get; set; }
        public string PickHQty { get; set; }
        public string PickLQty { get; set; }
        public string PromoType { get; set; }
        public string ReasonId { get; set; }
        public string Desc { get; set; }
        public string LineNo { get; set; }
        public string pid_ID { get; set; }
        public string Weighing { get; set; }
        public string PickHUom { get; set; }
        public string PickLUom { get; set; }
        public string EnableExcess { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string Remarks { get; set; }
        public List<GetPickingBatchSerial> BatchSerial { get; set; }
        public string CatCode { get; set; }
        public string CatName { get; set; }

        public string SubCatCode { get; set; }

        public string SubCatName { get; set; }

        public string BrdID { get; set; }

        public string BrdCode { get; set; }
        public string BrdName { get; set; }
        public string ArName { get; set; }
        public string ArDesc { get; set; }
        public string ArBrdName { get; set; }
        public string ArCatName { get; set;}
        public string ArSubCatName { get; set; }
    }

    public class GetPickingBatchSerial
    {
        public string ItemCode { get; set; }
        public string Number { get; set; }
        public string ExpiryDate { get; set; }
        public string BaseUOM { get; set; }
        public string RequestedQty { get; set; }
        public string PickedQty { get; set; }
        public string ReasonId { get; set; }
        public string UserId { get; set; }
        public string Mode { get; set; }
        public string EligibleQty { get; set; }
        public string BatchID { get; set; }
        public string pkd_ID { get; set; }
        public string LineNo { get; set; }
        public string Id { get; set; }
        public string Spec { get; set; }
        public string adj_qty { get; set; }
        public string ReservationNo { get; set; }
        public string SalesMan { get; set; }
      
    }

    public class GetNewBatch
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string ExpiryDate { get; set; }
        public string AvailableQty { get; set; }
        public string SalesPerson { get; set; }
        public string ArSalesPerson { get; set; }
        
    }

    public class PostCompletePicking
    {
        public string PickingId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string ItemData { get; set; }
        public string BatchData { get; set; }
    }

    public class PostParkAndParkRelease
    {
        public string PickingId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string ItemData { get; set; }
        public string BatchData { get; set; }
    }

    public class ItemwiseSummaryIn
    {
   //     public string prdID { get; set; }
        public string UserID { get; set; }
        public string JsonString { get; set; }
    }

    public class ItemwiseSummaryOut
    {
      
        public string prd_ID { get; set; }
        public string TotalRequestedLQty { get; set; }
        public string TotalRequestedHQty { get; set; }
        public string pkd_RequestedHuom { get; set; }
        public string pkd_RequestedLuom { get; set; }
     
    }

    public class PickingIds
    {
        public string pkh_ID { get; set; }
    }

    public class PostPickingItemData
    {
        public string ProductId { get; set; }
        public string ProductHUOM { get; set; }
        public string ProductLUOM { get; set; }
        public string ProductHQty { get; set; }
        public string ProductLQty { get; set; }
        public string ReasonId { get; set; }
        public string UserId { get; set; }
        public string ModifiedOn { get; set; }
        public string LineNumber { get; set; }
    }

    public class PostPickingBatchData
    {
        public string ProductId { get; set; }
        public string Number { get; set; }
        public string PickedQty { get; set; }
        public string ReasonId { get; set; }
        public string BatchMode { get; set; }
        public string ExpiryDate { get; set; }
        public string UserId { get; set; }
        public string ModifiedOn { get; set; }
        public int BatchID { get; set; }
        public string pkd_ID { get; set; }
        public string SalesPerson { get; set; }
        public string EligibleQty { get; set; }
        public string BaseUOM { get; set; }
    }

    public class GetInsertStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }
    public class OngoingOrderPick
    {
        public string PickingID { get; set; }
        public string ord_ID { get; set; }
        public string CusHeaderCode { get; set; }
        public string CusHeaderName { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string ExpectedDelDate { get; set; }
        public string PickListNumber { get; set; }
        public string Picker { get; set; }
        public string pih_Status { get; set; }
        public string pih_Remarks { get; set; }
        public string UserID { get; set;}
        public string str_ID { get; set;}
        public string str_Name { get; set;}
        public string str_Code { get; set;}
        



    }
}