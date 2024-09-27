using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class WarehouseHelper
    {
    }
    public class WarHeaderInParam
    {
        public string usrID { get; set; }

    }
    public class WarHeaderOutParam
    {
        public string pkh_ID { get; set; }
        public string pkh_Number { get; set; }
        public string war_ID { get; set; }
        public string Status { get; set; }
        public string mrh_Number { get; set; }
        public string PickedBy { get; set; }
        public string ArPickedBy { get; set; }



    }
    public class WTDetailInParam
    {
        public string HeaderID { get; set; }

    }
    public class WTDetailOutParam
    {
        public string pkd_ID { get; set; }
        public string pkd_itm_ID { get; set; }
        public string pkd_Huom { get; set; }
        public string pkd_Luom { get; set; }
        public string pkd_RequestedHQty { get; set; }
        public string pkd_RequestedLQty { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }

    }
    public class WTBatchOutParam
    {
        public string wbs_ID { get; set; }
        public string wbs_Number { get; set; }
        public string wbs_ExpiryDate { get; set; }
        public string wbs_BaseUOM { get; set; }
        public string wbs_PickQty { get; set; }
        public string wbs_AvailbleQty { get; set; }
        public string wbs_SalesMan { get; set; }
        public string wbs_ArSalesMan { get; set; }


    }
    public class WTPickCmpltInParam
    {
        public string PickingId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string ItemData { get; set; }
        public string BatchData { get; set; }
    }
    public class WTPickingItemData
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
    public class WTPickingBatchData
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
        public string wpd_ID { get; set; }
        public string SalesPerson { get; set; }
        public string EligibleQty { get; set; }
        public string BaseUOM { get; set; }
    }
    public class WTPickCmpltDetailParam
    {
        public string pkdid { get; set; }
        public string pkdHQty { get; set; }
        public string pkdLQty { get; set; }
        public string pkdHUOM { get; set; }
        public string pkdLUOM { get; set; }
        public string rsnID { get; set; }
    }
    public class PostStartWTPickHeader
    {
        public string PickHeaderID { get; set; }
        public string PickUserID { get; set; }
    }
    public class PostWTPickingData
    {
        public string PickingId { get; set; }
        public string UserId { get; set; }
    }
    public class GetWTPickingItemHeader
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
        public string ArName { get; set; }
        public string ArBrdName { get; set; }
        public string ArCatName { get; set; }
        public string ArSubCatName { get; set; }






        public List<GetWTPickingBatchSerial> BatchSerial { get; set; }
        public string CatCode { get; set; }
        public string CatName { get; set; }

        public string SubCatCode { get; set; }

        public string SubCatName { get; set; }

        public string BrdID { get; set; }

        public string BrdCode { get; set; }
        public string BrdName { get; set; }
    }

    public class GetWTPickingBatchSerial
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
        public string SalesMan { get; set; }
    }
    public class PostWTPickUser
    {
        public string UserID { get; set; }
        public string RouteID { get; set; }
        public string itemID { get; set; }
    }
    public class WYOngoingPick
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
        public string UserID { get; set; }
        public string str_ID { get; set; }
        public string str_Name { get; set; }
        public string str_Code { get; set; }




    }

}