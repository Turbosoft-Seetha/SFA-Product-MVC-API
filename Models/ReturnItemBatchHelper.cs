using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class ReturnItemBatchHelper
    {
    }

    public class ReturnBatchDetailIn
    {
        public string cusID { get; set; }

        public string rotID { get; set; }


    }


    public class ReturnBatchDetailOut
    {

        public string sal_number { get; set; }
        public string sal_ID { get; set; }
        public string sld_itm_ID { get; set; }
        public string sld_HQty { get; set; }
        public string sld_PieceQty { get; set; }
        public string sal_cus_ID { get; set; }
        public string inv_InvoiceID { get; set; }
        public string sld_HigherUOM { get; set; }
        public string sld_LowerUOM { get; set; }

        public string sld_HUOMRtnAmount { get; set; }
        public string sld_LUOMRtnAmount { get; set; }
        public string ind_Discount { get; set; }
        public string ind_PieceDiscount { get; set; }
        public string BalanceAmount { get; set; }
        public string slq_prm_ID { get; set; }
        public string prt_Value { get; set; }
        public string sld_TransType { get; set; }
        public string CreatedDate { get; set; }
      

        public List<RTNBatchSerial> BatchSerial { get; set; }
        public string prd_IsBatchItem { get; set; }


    }

    public class RTNBatchSerial
    {

        public string slb_sal_ID { get; set; }
        public string slb_sld_ID { get; set; }
        public string slb_Number { get; set; }

        public string slb_ExpiryDate { get; set; }
        public string slb_BaseUOM { get; set; }
        public string slb_OrderedQty { get; set; }
        public string slb_AdjustedQty { get; set; }
        public string slb_LoadInQty { get; set; }
        public string inv_InvoiceID { get; set; }
        public string sld_itm_ID { get; set; }
        
        public string slb_id { get; set; }
    }
}