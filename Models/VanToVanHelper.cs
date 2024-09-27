using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class VanToVanHelper
    {
    }

    public class VanToVanDetailIn
    {
        public string HeaderID { get; set; }
        public string userID { get; set; }
    }
    public class VanToVanDetailOut
    {
        public string vvd_ID { get; set; }
        public string vvd_vvh_ID { get; set; }
        public string vvd_prd_ID { get; set; }
        public string vvd_HUOM { get; set; }
        public string vvd_LUOM { get; set; }
        public string vvd_HQty { get; set; }
        public string vvd_LQty { get; set; }
       
        public List<VanToVanBatchSerial> BatchDetail { get; set; }

    }
    public class VanToVanBatchSerial
    {
        public string vvb_ID { get; set; }
        public string vvb_vvh_ID { get; set; }
        public string vvb_vvd_ID { get; set; }
        public string vvb_Number { get; set; }
        public string vvb_ExpiryDate { get; set; }
        public string vvb_BaseUOM { get; set; }
        public string vvb_OrderedQty { get; set; }
        public string vvb_AdjustedQty { get; set; }
        public string vvb_LoadInQty { get; set; }

    }
}