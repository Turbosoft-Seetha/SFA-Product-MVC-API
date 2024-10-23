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
        public string sal_ID { get; set; }
        public string sld_itm_ID { get; set; }
        public string spa_prm_ID { get; set; }
        public string spa_prd_ID { get; set; }
        public string ElgQty { get; set; }
        public string spi_QualifiedQty { get; set; }
        public string prd_IsBatchItem { get; set; }
        public List<PromotionBatchSerial> BatchSerial { get; set; } 

    }

    public class PromotionBatchSerial
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