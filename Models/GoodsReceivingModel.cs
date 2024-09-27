using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
	public class GoodsReceivingIn
	{
		public string grh_usr_ID { get; set; }

	}
	public class GoodsReceivingOut
	{
		public string grh_ID { get; set; }
		public string grh_trn_number { get; set; }
		public string str_ID { get; set; }
		public string str_Name { get; set; }
		public string grh_exp_Date { get; set; }
		//public string prd_ID { get; set; }
		//public string prd_Name { get; set; }
		//public string prd_BaseUOM { get; set; }
		public string Status { get; set; }
        public string ReceivedBy { get; set; }
        public string ArReceivedBy { get; set; }
        public string str_ArName { get; set; }



    }
    public class AssignedDetailIn
	{
		public string grd_grh_ID { get; set; }

	}
	public class AssignedDetailOut
	{
		public string grd_ID { get; set; }
		public string grh_trn_number { get; set; }
		public string grd_Exp_HQty { get; set; }
		public string grd_Exp_LQty { get; set; }
		public string CreatedDate { get; set; }
		public string prd_Code { get; set; }
		public string prd_Name { get; set; }
		public string grd_prd_HUom { get; set; }
		public string grd_prd_LUom { get; set; }

	}
	public class StartGrnReceiving
	{
		public string grh_ID { get; set; }
		public string usrid { get; set; }

	}

	public class PostGRNData
	{
		public string grh_ID { get; set; }
		public string UserId { get; set; }
	}

	public class GrnReceivingHeader
	{
		public string UserID { get; set; }
		public string jsonValue { get; set; }
	}

	public class GrnReceivingDetail
	{
		public string grd_ID { get; set; }
		public string grd_Received_LQty { get; set; }
		public string grd_Received_HQty { get; set; }
		public string grd_prd_HUom { get; set; }
		public string grd_prd_LUom { get; set; }
	}


	public class GRNSelfAssignHeader
	{
		public string UserID { get; set; }
		public string jsonValue { get; set; }
	}

	public class GRNSelfAssignDetail
	{
		public string grh_ID { get; set; }
	}

	public class GetGrnItemHeader
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Spec { get; set; }
		public string Desc { get; set; }
		public string CategoryId { get; set; }
		public string SubcategoryId { get; set; }
		public string Weighing { get; set; }
		public string Exp_HUom { get; set; }
		public string Exp_LUom { get; set; }
		public string ExpHQty { get; set; }
		public string ExpLQty { get; set; }
		public string ReceivedHQty { get; set; }
		public string ReceivedLQty { get; set; }
		public string ReceivedHUom { get; set; }
		public string ReceivedLUom { get; set; }
		public string ReasonID { get; set; }
		public string grd_ID { get; set; }
		public List<GetGrnBatchSerial> BatchSerial { get; set; }
		public string LineNo { get; set; }
        public string CatCode { get; set; }
        public string CatName { get; set; }

        public string SubCatCode { get; set; }

        public string SubCatName { get; set; }

        public string BrdID { get; set; }

        public string BrdCode { get; set; }
        public string BrdName { get; set; }
        public string ArName { get; set; }
        public string ArDesc { get; set; }

        public string ArCatName { get; set; }
        public string ArSubCatName { get; set; }
        public string ArBrdName { get; set; }



    }
    public class GetGrnBatchSerial
	{
		public string ItemCode { get; set; }
		public string Number { get; set; }
		public string ExpiryDate { get; set; }
		public string BaseUOM { get; set; }
		public string bch_Qty { get; set; }
		//public string ReceivedQty { get; set; }
		public string BatchID { get; set; }
		public string ReasonId { get; set; }
		public string grd_ID { get; set; }
	}
	public class GrnReceivingStatus
	{
		public string Res { get; set; }
		public string Title { get; set; }
		public string Descr { get; set; }
	}
	public class GRNBatchUpdateHeader
	{
		public string UserID { get; set; }
		public string jsonValue { get; set; }
	}

	public class GRNBatchUpdateDetail
	{
		public string bch_ID { get; set; }
		public string bch_Received_Qty { get; set; }
		public string bch_ReasonID { get; set; }
	}
	public class GetGRNOngoingHeader
	{
		public string grh_ID { get; set; }
		public string grh_trn_number { get; set; }
		public string str_ID { get; set; }
		public string str_Name { get; set; }
		public string Date { get; set; }
		public string Status { get; set; }
		public string UserID { get; set; }

	}
	public class PostCompleteGRN
	{
		public string GrnId { get; set; }
		public string UserId { get; set; }
		public string Status { get; set; }
		public string ItemData { get; set; }
		public string BatchData { get; set; }
	}
	public class PostGRNItemData
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

    public class PostGRNBatchData
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
        public string grd_ID { get; set; }

        public string BaseUOM { get; set; }
    }
}