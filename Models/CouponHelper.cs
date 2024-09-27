using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CouponHelper
    {
    }

    public class CouponHeaderIn
    {
        public string rot_ID { get; set; }
    }
    public class CouponHeaderOut
    {
        public string cph_ID { get; set; }
        public string cph_Number { get; set; }
        public string cph_rot_ID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }

    }
    public class CouponDetailIn
    {
        public string cph_ID { get; set; }
        public string userID { get; set; }
    }
    public class CouponDetailOut
    {
        public string cpd_ID { get; set; }
        public string cpd_cph_ID { get; set; }
        public string cpd_cpm_ID { get; set; }
        public string cpm_Code { get; set; }
        public string cpm_Name { get; set; }
        public string cpd_HigherQty { get; set; }
        public string cpd_AdjHigherQty { get; set; }
        public string cpd_FinalHigherQty { get; set; }
        public string Status { get; set; }
        public List<CouponBookOut> BookDetail { get; set; }
        public List<CouponItemOut> ItemDetail { get; set; }
        public string cpm_Price { get; set; }
        public string cpm_NoOfLeaf { get; set; }

    }
    public class CouponBookOut
    {
        public string cpb_ID { get; set; }
        public string cpb_cph_ID { get; set; }
        public string cpb_cpd_ID { get; set; }
        public string cpb_BookNumber { get; set; }
        public string Status { get; set; }
        public string IsChecked { get; set; }
        public List<CouponBookLeafOut> LeafDetail { get; set; }
    }
    public class CouponBookLeafOut
    {
        public string cbl_ID { get; set; }
        public string cbl_cph_ID { get; set; }
        public string cbl_cpd_ID { get; set; }
        public string cbl_cpb_ID { get; set; }
        public string cbl_LeafNumber { get; set; }
        public string Status { get; set; }
        public string IsCheckedLeaf { get; set; }

    }

    public class CouponItemOut
    {
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string cpm_Price { get; set; }



	}
    public class ConfirmCouponIn
    {
        public string cpd_cph_ID { get; set; }
        public string CouponDetailXML { get; set; }
        public string CouponBookXML { get; set; }
        public string UserID { get; set; }
        public string SecurityAmount { get; set; }
	}
    public class PostCouponData
    {
        public string cpd_ID { get; set; }
        public string cpd_HigherQty { get; set; }
        public string cpd_AdjHigherQty { get; set; }
        public string cpd_FinalHigherQty { get; set; }
		public string Adj_H_UOM { get; set; }
		public string Adj_L_UOM { get; set; }
		public string Adj_L_Qty { get; set; }
		public string LI_H_UOM { get; set; }
		//public string LI_H_Qty { get; set; }
		public string LI_L_UOM { get; set; }
		public string LI_L_Qty { get; set; }
		public string Final_H_UOM { get; set; }
		public string Final_H_Qty { get; set; }
		public string Final_L_UOM { get; set; }
		public string Final_L_Qty { get; set; }
		public string lidID { get; set; }
        public string prdID { get; set; }
		public string Opn_HUOM { get; set; }
		public string Opn_HQty { get; set; }
		public string Opn_LUOM { get; set; }
		public string Opn_LQty { get; set; }
		public string HigherPrice { get; set; }
		public string LowerPrice { get; set; }

	}
    public class PostCouponBookData
    {
        public string cpb_ID { get; set; }
        public string cpd_ID { get; set; }
        public string IsChecked { get; set; }
    }
    public class ConfirmCouponOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }

    public class ConfirmReturnCouponIn
    {
        public string rot_ID { get; set; }
        public string CouponDetailXML { get; set; }
        public string CouponBookXML { get; set; }
        public string UserID { get; set; }
        public string SecurityAmount { get; set; }  
        public string CustomerId { get; set; }

	}
    public class PostReturnCouponData
    {
        public string cpm_ID { get; set; }
        public string HigherQty { get; set; }
        public string AdjHigherQty { get; set; }
        public string FinalHigherQty { get; set; }
		public string OffloadQty { get; set; }
	}
    public class PostReturnCouponBookData
    {
        public string cpm_ID { get; set; }
        public string cpb_ID { get; set; }
        public string IsChecked { get; set; }
    }
    public class ConfirmReturnCouponOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }

    public class ConfirmCouponIssueIn
    {
        public string cus_ID { get; set; }
        public string udp_ID { get; set; }
        public string UserID { get; set; }
        public string CouponBookXML { get; set; }
        public string ReceiptImg1 { get; set; }
        public string ReceiptImg2 { get; set; }

	}
    public class PostCouponIssueData
    {
        public string cpm_ID { get; set; }
        public string cpb_ID { get; set; }

    }
    public class ConfirmCouponIsueOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }

    public class CusCouponDetailIn
    {
        public string rot_ID { get; set; }
        public string userID { get; set; }
    }
    public class CusCouponDetailOut
    {
        public string cac_ID { get; set; }
        public string cac_cus_ID { get; set; }
        public string cac_cpm_ID { get; set; }
        public string cac_cpb_ID { get; set; }
        public string cac_cpl_ID { get; set; }
		public string cpm_Code { get; set; }
		public string cpm_Name { get; set; }
		public string cpb_BookNumber { get; set; }
	    public string BookStatus { get; set; }
		public string IsChecked { get; set; }
		public List<CusCouponBookLeafOut> LeafDetail { get; set; }
		//public List<CusCouponBookOut> BookDetail { get; set; }

	}
	//public class CusCouponBookOut
	//{
	//	public string cpb_ID { get; set; }
	//	public string cpb_BookNumber { get; set; }
	//	public string BookStatus { get; set; }
	//	public string IsChecked { get; set; }
	//	public List<CusCouponBookLeafOut> LeafDetail { get; set; }
	//}
	public class CusCouponBookLeafOut
	{
		public string cbl_ID { get; set; }
		public string cbl_cpb_ID { get; set; }
		public string cbl_LeafNumber { get; set; }
		public string LeafStatus { get; set; }
		public string IsCheckedLeaf { get; set; }

	}

	public class SalesInvoiceIn
    {
        public string sal_rot_ID { get; set; }
        public string sal_cus_ID { get; set; }
        public string sal_usr_ID { get; set; }
        public string sal_udp_ID { get; set; }
        public string sal_cse_ID { get; set; }
        public string sal_number { get; set; }
        public string CreatedDate { get; set; }
        public string sal_SubTotal { get; set; }
        public string sal_VAT { get; set; }
        public string sal_TotalPaidAmount { get; set; }
        public string CreationMode { get; set; }
        public string inv_Discount { get; set; }
        public string inv_SubTotal_WO_Discount { get; set; }
        public string SalesItemDetailXML { get; set; }
        public string CouponBookLeafXML { get; set; }
        public string CouponReturnXML { get; set; }
        public string CashDepositAmount { get; set; }
        public string CashDepositType { get; set; }
        public string CashDepositImage { get; set; }
	}
    public class PostSalesItemDetail
    {
        public string sld_itm_ID { get; set; }
        public string sld_HigherUOM { get; set; }
        public string sld_LowerUOM { get; set; }
        public string sld_HigherQty { get; set; }
        public string sld_LowerQty { get; set; }
        public string sld_HigherPrice { get; set; }
        public string sld_LowerPrice { get; set; }
        public string sld_LineTotal { get; set; }
        public string sld_TotalQty { get; set; }
        public string sld_VatPercent { get; set; }
        public string sld_Discount { get; set; }
        public string sld_GrandTotal { get; set; }
        public string sld_VatAmount { get; set; }

    }
    public class PostCouponBookLeaf
    {
        public string cpb_ID { get; set; }
        public string cpl_ID { get; set; }

    }
    public class PostCouponBottleReturn
    {
        public string itmID { get; set; }
        public string Qty { get; set; }

    }

	public class SalesInvoiceOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
    public class ReturnEmptyBottlesIn
    {
        public string rot_ID { get; set; }
        public string usr_ID { get; set; }
        public string udp_ID { get; set; }
        public string cse_ID { get; set; }
        public string cus_ID { get; set; }
        public string CouponReturnEmptyBottles { get; set; }
    }
    public class PostReturnEmptyBottles
    {
        public string itmID { get; set; }
        public string Qty { get; set; }

    }
    public class ReturnEmptyBottlesOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }

    public class LoadoutEmptyBottlesIn
    {
        public string rot_ID { get; set; }
        public string usr_ID { get; set; }
        public string udp_ID { get; set; }
        public string CouponLoadoutEmptyBottles { get; set; }
    }
    public class PostLoadoutEmptyBottles
    {
        public string itmID { get; set; }
        public string Qty { get; set; }

    }
    public class LoadoutEmptyBottlesOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
    public class LoadTransferEmptyBottlesIn
    {
        public string rot_ID { get; set; }
        public string usr_ID { get; set; }
        public string udp_ID { get; set; }
        public string CouponLoadTransferEmptyBottles { get; set; }
    }
    public class PostLoadTransferEmptyBottles
    {
        public string itmID { get; set; }
        public string Qty { get; set; }

    }
    public class LoadTransferEmptyBottlesOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }

    public class CouponSettlementIn
    {
        public string rot_ID { get; set; }
        public string usr_ID { get; set; }
        public string udp_ID { get; set; }
        public string CouponLeafData { get; set; }
    }
    public class PostCouponLeaf
    {
        public string cpm_ID { get; set; }
        public string cpb_ID { get; set; }
        public string cpl_ID { get; set; }

    }
    public class CouponSettlementOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
    public class CouponLoadIn
    {
		//public string cpd_cph_ID { get; set; }
	
		public string UserID { get; set; }
		public string lih_ID { get; set; }
		public string emp_ID { get; set; }
		public string Status { get; set; }
		public string  rot_ID { get; set; }
		public string udp_ID { get; set; }
		public string Signature { get; set; }
		public string Remarks { get; set; }
		public string CouponDetailXML { get; set; }
		public string CouponBookXML { get; set; }
	}
	public class CouponLoadOut
	{
		public string Res { get; set; }
		public string Title { get; set; }
		public string Descr { get; set; }
	}
    public class PostCouponLoadData
    {
        //public string cpd_ID { get; set; }
        //public string cpd_HigherQty { get; set; }
        //public string cpd_AdjHigherQty { get; set; }
        //public string cpd_FinalHigherQty { get; set; }
        public string Adj_H_Qty { get; set; }
        public string LI_H_Qty { get; set; }
        public string Final_H_Qty { get; set; }
        public string Adj_H_UOM { get; set; }
        public string Adj_L_UOM { get; set; }
        public string Adj_L_Qty { get; set; }
        public string LI_H_UOM { get; set; }

        public string LI_L_UOM { get; set; }
        public string LI_L_Qty { get; set; }
        public string Final_H_UOM { get; set; }
        public string Final_L_UOM { get; set; }
        public string Final_L_Qty { get; set; }
        public string lidID { get; set; }
        public string prdID { get; set; }
        public string Opn_HUOM { get; set; }
        public string Opn_HQty { get; set; }
        public string Opn_LUOM { get; set; }
        public string Opn_LQty { get; set; }
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }
    }
    public class ReturnInput
    {
		public string rot_ID { get; set; }
	}
	public class CouponReturnPending
	{
        public string CusId { get; set; }
        public string CusCode { get; set; }
		public string CusName { get; set;}
        public string PrdId { get; set;}
		public string PrdCode { get; set; }
		public string PrdName { get; set; }
        public string TotalSalesQty { get; set; }
		public string TotalReturnQty { get; set; }
		public string NetSalesQty { get; set; }

	}
	public class UpdateCouponIn
	{
		public string cpd_cph_ID { get; set; }
		public string CouponDetailXML { get; set; }
		public string CouponBookXML { get; set; }
		public string UserID { get; set; }
		public string emp_ID { get; set; }
		public string Status { get; set; }
	}

 public class PostReturnEmptyBottleReqData
	{

		public string UserId { get; set; }
        public string RotId { get; set; }
		public string CusId { get; set; }
		//public string Status { get; set; }
		public string JSONString { get; set; }
	}

    public class PostReturnEmptyBottleApprovalDetData
    {
		public string prdID { get; set; }
		public string RtnQty { get; set; }
		public string ColQty { get; set; }
	}
	public class GetEmptyBottleReturnApprovalStatus
	{

		public string Res { get; set; }
		public string Title { get; set; }
		public string Descr { get; set; }
        public string ReturnId { get; set; }
	}
    public class GetEmptyBottleApprHeaderStatus
    {
        public string RotId { get; set; }
		public string CusId { get; set; }
		public string ReturnId { get; set; }
	}
	public class GetHeaderStatus
	{	
		public string ApprovalStatus { get; set; }
	}
	public class GetDetBottleApprovalStatus
	{

		public string ApprovalStatus { get; set; }
		public string ProductId { get; set; }
		public string ReasonID { get; set; }


	}
    public class GetCouponMaster
    {
		public string cpm_ID { get; set; }
		public string cpm_Code { get; set; }
		public string cpm_Name { get; set; }
		public string cpm_NoOfLeaf { get; set; }
		public string cpm_Price { get; set; }
		public List<CouponItemList> ItemDet { get; set; }

	}
    public class CouponItemList
    {
		public string cpt_prd_ID { get; set; }
		public string cpt_cpm_ID { get; set; }
		public string prd_Code { get; set; }
		public string prd_Name { get; set; }
		public string pru_Price { get; set; }
	}
}