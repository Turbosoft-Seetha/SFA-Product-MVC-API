using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class VantoVanDetailsBatchHelper
    {
    }


    public class GetVanToVanDetailsBatchIN
    {

        public string TransID { get; set; }
        public string userID { get; set; }
    }


    public class GetVanToVanBatch
    {
        public string vvb_Number { get; set; }
        public string vvb_ExpiryDate { get; set; }
        public string vvb_BaseUOM { get; set; }
        public string vvb_OrderedQty { get; set; }
        public string vvb_AdjustedQty { get; set; }
        public string vvb_LoadInQty { get; set; }
        public string vvb_prd_ID { get; set; }
        public string vvb_vvd_ID { get; set; }


    }

    public class GetVanToVanBatchDetails
    {

        public string ItemID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }

        public string LUOM { get; set; }
        public string LQty { get; set; }

        public string ConfirmHUOM { get; set; }
        public string ConfirmHQty { get; set; }
        public string ConfirmLUOM { get; set; }
        public string ConfirmLQty { get; set; }
        public string AdjHQty { get; set; }
        public string AdjLQty { get; set; }

        public List<GetVanToVanBatch> VanToVanBatch { get; set; }

    }
}