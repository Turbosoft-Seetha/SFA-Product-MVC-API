using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.BatchHelper
{
    public class LoadInBatchHelper
    {
    }
    public class LoadInBatchDetailIn
    {
        public string lid_lih_ID { get; set; }

        public string rotID { get; set; }


    }
    public class LoadInBatchDetailOut
    {

        public string lid_prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_NameArabic { get; set; }
        public string lid_ID { get; set; }
        public string EndStock_H_UOM { get; set; }
        public string lod_EndStock_H_Qty { get; set; }
        public string EndStock_L_UOM { get; set; }
        public string lod_EndStock_L_Qty { get; set; }
        public string Fresh_H_UOM { get; set; }
        public string lid_HigherQty { get; set; }

        public string Fresh_L_UOM { get; set; }
        public string lid_LowerQty { get; set; }
        public string Final_H_UOM { get; set; }
        public string Final_H_Qty { get; set; }
        public string Final_L_UOM { get; set; }
        public string Final_L_Qty { get; set; }
        public string Adj_H_UOM { get; set; }
        public string Adj_L_UOM { get; set; }
        public string lid_AdjHigherQty { get; set; }
        public string lid_AdjLowerQty { get; set; }
        public string LI_H_UOM { get; set; }
        public string LI_H_Qty { get; set; }
        public string LI_L_UOM { get; set; }
        public string LI_L_Qty { get; set; }
        public string prd_cat_ID { get; set; }
        public string prd_sct_ID { get; set; }

        public List<LIDBatchSerial> BatchSerial { get; set; }


        public string prd_IsBatchItem { get; set; }
    }

    public class LIDBatchSerial
    {

        public string Lid { get; set; }
        public string LIDetailID { get; set; }
        public string prdid { get; set; }

        public string Batch { get; set; }
        public string ExpiryDate { get; set; }
        public string BaseUOM { get; set; }
        public string orderedQty { get; set; }
        public string AdjQty { get; set; }
        public string LIQty { get; set; }
        public string BatchID { get; set; }

    }
    public class GetOpenStocksIn
    {
        public string udpID { get; set; }
        public string rot_ID { get; set; }
    }
    public class GetOpenStocksHeader
    {

        public string HeaderID { get; set; }
        public string TransID { get; set; }
        public string TransDate { get; set; }
        public List<GetOpenStocksDetail> RequestDetail { get; set; }

    }
    public class GetOpenStocksDetail
    {

        public string prd_ID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }


        public List<GetOpenStocksBatch> RequestBatch { get; set; }
        public string prd_IsBatchItem { get; set; }

    }

    public class GetOpenStocksBatch
    {
        public string lis_ID { get; set; }
        public string lis_lih_ID { get; set; }
        public string lis_lid_ID { get; set; }
        public string lis_Number { get; set; }
        public string lis_ExpiryDate { get; set; }
        public string lis_BaseUOM { get; set; }
        public string lis_OrderedQty { get; set; }
        public string lis_AdjustedQty { get; set; }
        public string lis_LoadInQty { get; set; }

    }
}