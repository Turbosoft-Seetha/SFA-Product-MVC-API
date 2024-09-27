using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
	public class WTReceivingOut
	{
		public string wrh_ID { get; set; }
		public string wrh_trn_number { get; set; }
		public string str_ID { get; set; }
		public string war_Name { get; set; }
		public string wrh_exp_Date { get; set; }
		public string Status { get; set; }
		public string mrh_Number { get; set; }
		public string WTPick_number { get;  set; }
		public string WTTransOut_number { get;set; }
		public string WTTransIn_number { get; set; }
        public string PickedBy { get; set; }
        public string Arwar_Name { get; set; }
        public string ArPickedBy { get; set; }


    }
	public class WTReceivingIn
	{
		public string wrh_usr_ID { get; set; }

	}

	public class WTRAssignedDetailIn
	{
		public string wrd_wrh_ID { get; set; }

	}

	public class WTRAssignedDetailOut
	{
		public string wrd_ID { get; set; }
		public string wrh_trn_number { get; set; }
		public string wrd_Picked_HQty { get; set; }
		public string wrd_Picked_LQty { get; set; }
		public string CreatedDate { get; set; }
		public string prd_Code { get; set; }
		public string prd_Name { get; set; }
		public string Higher_UOM { get; set; }
		public string Lower_UOM { get; set; }

	}

    public class StartWTReceiving
	{
		public string wrd_ID { get; set; }
		public string wrh_ID { get; set; }
		public string wrh_trn_number { get; set; }
		public string prd_Code { get; set; }
		public string prd_Name { get; set; }
		public string Higher_UOM { get; set; }
		public string Lower_UOM { get; set; }
		public string wrd_Picked_HQty { get; set; }
		public string wrd_Picked_LQty { get; set; }
		public string wrd_Received_HQty { get; set; }
		public string wrd_Received_LQty { get; set; }
		public string wrd_Status { get; set; }

	}
	public class StartWTReceivingBatchIn
	{
		public string bch_wrh_ID { get; set; }
		public string bch_wrd_ID { get; set; }

	}
	public class StartWTReceivingBatchOut
	{
		public string bch_ID { get; set; }
		public string bch_Num { get; set; }
		public string bch_Exp_Date { get; set; }
		public string uom_Name { get; set; }
		public string bch_PickedQty { get; set; }
		public string bch_ReceivedQty { get; set; }
		

	}
	public class WTReceivingHeader
	{
		public string UserID { get; set; }
		public string Status { get; set; }

        public string jsonValue { get; set; }
	}

	public class WTReceivingDetail
	{
		public string wrd_ID { get; set; }
		public string wrd_Received_LQty { get; set; }
		public string wrd_Received_HQty { get; set; }
		public string wrd_HUOM { get; set; }
		public string wrd_LUOM { get; set; }
		public string wrd_Reason_ID { get; set; }

	}

	public class WTReceivingStatus
	{
		public string Res { get; set; }
		public string Title { get; set; }
		public string Descr { get; set; }
	}
	public class WTReceivingSelfAssignHeader
	{
		public string UserID { get; set; }
		public string jsonValue { get; set; }
	}

	public class WTReceivingSelfAssignDetail
	{
		public string wrh_ID { get; set; }
	}
	public class BatchUpdateHeader
	{
		public string UserID { get; set; }
		public string jsonValue { get; set; }
	}

	public class BatchUpdateDetail
	{
		public string bch_ID { get; set; }
		public string bch_ReceivedQty { get; set; }
		public string bch_Reason_ID { get; set; }
	}
	public class PostWTReceivingData
	{
		public string wrh_ID { get; set; }
		public string UserId { get; set; }
	}
	public class GetWTReceivingItemHeader
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string HUOM { get; set; }
        public string LUOM { get; set; }
        public string PickedHQty { get; set; }
        public string PickedLQty { get; set; }
        public string ReceivedHQty { get; set; }
        public string ReceivedLQty { get; set; }
        public string wrd_ID { get; set; }
        public List<GetWTReceivingBatchSerial> BatchSerial { get; set; }
        public string LineNo { get; set; }
        public string ReasonId { get; set; }
        public string ReceivedHUOM { get; set; }
        public string ReceivedLUOM { get; set; }
        public string Weighing { get; set; }
        public string Spec { get; set; }
        public string Desc { get; set; }
        public string CatID { get; set; }
        public string CatCode { get; set; }
        public string CatName { get; set; }
        public string SubCatID { get; set; }
        public string SubCatCode { get; set; }

        public string SubCatName { get; set; }

        public string BrdID { get; set; }

        public string BrdCode { get; set; }
        public string BrdName { get; set; }
        public string ArCatName { get; set; }
        public string ArSubCatName { get; set; }
        public string ArBrdName { get; set; }
        public string ArName { get; set; }


    }
    public class GetWTReceivingBatchSerial
	{
		public string ItemCode { get; set; }
		public string Number { get; set; }
		public string ExpiryDate { get; set; }
		public string BaseUOM { get; set; }
		public string PickedQty { get; set; }
		public string ReceivedQty { get; set; }
		public string BatchID { get; set; }
		public string ReasonId { get; set; }
		public string wrd_ID { get; set; }
        public string SerialFlag { get; set; }
    }
	public class GetWTROngoingHeader
	{
		public string wrh_ID { get; set; }
		public string wrh_trn_number { get; set; }
		public string war_ID { get; set; }
		public string war_Name { get; set; }
		public string Date { get; set; }
		public string Status { get; set; }
		public string UserID { get; set; }

	}
    public class PostWTCompleteGRN
    {
        public string WRHId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string ItemData { get; set; }
        public string BatchData { get; set; }
    }
    public class PostWTGRNItemData
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

    public class PostWTGRNBatchData
    {
        public string ProductId { get; set; }
        public string Number { get; set; }
        public string receivedQty { get; set; }
        public string ReasonId { get; set; }
        public string BatchMode { get; set; }
        public string ExpiryDate { get; set; }
        //public string UserId { get; set; }
        public string ModifiedOn { get; set; }
        public int BatchLineNo { get; set; }
        public string wrd_ID { get; set; }

        public string BaseUOM { get; set; }
        public string SerialFlag { get; set; }
    }
}