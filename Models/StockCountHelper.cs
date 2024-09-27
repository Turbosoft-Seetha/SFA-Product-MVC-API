using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class StockCountHelper
    {
    }
    public class StkCntHeaderInParam
    {
        public string usrID { get; set; }

    }
    public class StkCntHeaderOutParam
    {
        public string stk_ID { get; set; }
        public string stk_trn_Number { get; set; }
        public string stk_exp_Date { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string Status { get; set; }
        public string stk_Type { get; set; }
        public string PickedBy { get; set; }
        public string ArPickedBy { get; set; }


    }
    public class StkCntDetailInParam
    {
        public string stk_ID { get; set; }
		public string UserID { get;set; }

    }

    public class StkCntInstantDetailInParam
    {
        public string stk_ID { get; set; }
        public string war_ID { get; set; }

    }

    public class StkCntDetailOutParam
    {
        public string std_ID { get; set; }
        public string std_prd_ID { get; set; }
        public string std_CountedHQty { get; set; }
		public string std_CountedLQty { get; set; }
		public string std_CountedHuom { get; set; }
		public string std_CountedLuom { get; set; }
		public string std_NS { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
		public string prd_Desc { get;set; }
		public string prd_Spec { get;set; }

        public string Reason_id { get; set; }
        public List<StkBatchSerial> BatchSerial { get; set; }
        public string Ar_prd_Name { get; set; }
        public string Ar_prd_Desc { get; set; }


    }
    public class StkBatchSerial
    {
        public string ItemCode { get; set; }
        public string Number { get; set; }
        public string ExpiryDate { get; set; }
        public string BaseUOM { get; set; }
        public string bch_Qty { get; set; }
        public string stb_std_ID { get; set; }
        public string BatchID { get; set; }
        public string ReasonId { get; set; }
        public string grd_ID { get; set; }
        
    }
    public class StkCntwarID
    {
        public string war_ID { get; set; }
        
        public List<StkCntwarItmID> itemserial { get; set; }

    }
    public class StkCntwarItmID
    {
        public string waritm_ID { get; set; }
        public string wareID { get; set; }
        public string prd_Spec { get;set; }
        public string std_CountedHQty { get; set; } 
        public string std_CountedLQty { get; set; } 
        public string std_CountedHuom { get; set; } 
        public string std_CountedLuom { get; set; }
        public string std_ID { get; set; } 
        public string std_rsn_ID { get; set; }
        public List<StkCntwarItmBatchID> BatchSerial { get; set; }
    }

    public class StkCntwarItmBatchID
    {
        public string stb_itm_ID { get; set; }
        public string stb_Number { get; set; }
        public string stb_BaseUOM { get; set; }
        public string stb_Qty { get; set; }
        public string stb_ProductionDate { get; set; }
        public string stb_ExpireDate { get; set; }
        public string stb_rsn_ID { get; set; }
        public string stb_stk_ID { get; set; }
        public string stb_std_ID { get; set; }
        public string stb_LineNo { get; set; }
        public string war_ID { get; set; }
        public string wim_war_ID { get; set; }
    }

    public class PostStockCountingHeader
    { 
        public string stk_HeaderID { get; set; }
		public string stk_WarData { get; set; }
		public string stk_ItemData { get; set; }
		public string stk_BatchData { get; set; }
		public string UserId { get; set; }
		public string Status { get; set; }
		public string Remarks { get; set; }
	}

    public class PostInstantStockCountingHeader
    {
        public string UserId { get; set; }
        public string ExpDate { get; set; }
        public string Remarks { get; set; }
        public string stk_ItemData { get; set; }
        public string stk_BatchData { get; set; }
    }

    public class PostStockCountingItemDetail
	{
		public int ItemId { get; set; }
		public string CountedHQty { get; set; }
		public string CountedLQty { get; set; }
		public string CountedHUOM { get; set; }
		public string CountedLUOM { get; set; }
		public string warId { get; set; }
		public string std_ID { get; set;}
		public string std_Status { get;set; }
		public string Reason_id { get; set;}
        
    }
	public class PostStockCountingBatchDetail
	{
		public string BatchNumber { get; set; }
		public string ProductionDate { get; set; }
		public string ExpiryDate { get; set; }
		public string BaseUOM { get; set; }
		public string CountedQty { get; set; }
        public string ProductId { get; set; }
        public string ReasonId { get; set; }
        public string StkDetailId { get; set; }
        public string BatchLineNo { get; set; }

    }
	public class CountingStatus
	{
		public string Mode { get; set; }
		public string Status { get; set; }
	}
	public class Viewitmsin
	{
		public string stkheaderID { get; set; }
	}
	public class ViewitmsOut
	{
		public string prdcode { get; set; }
		public string prdname { get; set; }
		public string CountedHQty { get; set; }
		public string CountedLQty { get; set; }
		public string CountedHuom { get; set; }
		public string CountedLuom { get; set; }
		public string std_NS { get; set; }
		public string warcode { get; set; }
		public string Warehouse { get; set; }


	}
	public class PostStockCountingData
	{
		public string wrh_ID { get; set; }
		public string UserId { get; set; }
	}
	public class GetStockCountingOngoingHeader
	{
		public string stk_ID { get; set; }
		public string stk_trn_Number { get; set; }
		public string Date { get; set; }
		public string Status { get; set; }
		public string UserID { get; set; }

	}
    public class StkAcceptInpara
    {
        public string HeaderID { get; set; }
        public string UserID { get; set; }
    }
    public class GetstkStatus
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }

    public class PostAssignStockCountingHeader
    {
        public string UserID { get; set; }
        public string jsonValue { get; set; }
    }

    public class PostAssignStockCountingDetail
    {
        public string StockHeaderID { get; set; }
    }
}
