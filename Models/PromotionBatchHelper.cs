using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class PromotionBatch
    {
    }

    public class PromotionBatchDetailIn
    {  
        public string rotID { get; set; }
        public string cus_ID { get; set; }
    }


    public class PromotionBatchDetailOut
    {
        //public string sal_number { get; set; }
        //public string sal_ID { get; set; }
        //public string sld_itm_ID { get; set; }
        //public string sld_HQty { get; set; }
        //public string sld_PieceQty { get; set; }
        //public string sal_cus_ID { get; set; }
        //public string inv_InvoiceID { get; set; }
        //public string sld_HigherUOM { get; set; }
        //public string sld_LowerUOM { get; set; }
        //public string sld_HUOMRtnAmount { get; set; }
        //public string sld_LUOMRtnAmount { get; set; }
        //public string ind_Discount { get; set; }
        //public string ind_PieceDiscount { get; set; }
        //public string BalanceAmount { get; set; }
        //public string spa_prm_ID { get; set; }
        //public string prt_Value { get; set; }
        //public string sld_TransType { get; set; }
        //public string CreatedDate { get; set; }
       
        public string spa_prd_ID { get; set; }
        public string ElgQty { get; set; }
        public string spi_QualifiedQty { get; set; }
        public string prd_IsBatchItem { get; set; }
        public List<PromotionBatchSerial> BatchSerial { get; set; }      


    }

    public class PromotionBatchSerial
    {

        public string pib_ID { get; set; }
        public string pib_Number { get; set; }
        public string pib_ExpiryDate { get; set; }
        public string pib_BaseUOM { get; set; }
        public string pib_Qty { get; set; }
        public string pib_sal_id { get; set; }
        public string pib_sld_id { get; set; }
        public string pib_prd_ID { get; set; }


    }
}