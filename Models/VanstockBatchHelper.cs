using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class VanstockBatchHelper
    {
    }

    public class GetVanstockBatchIN
    {

        public string vsn_udpID { get; set; }
        public string userID { get; set; }
    }


    public class GetVanstokeBatch
    {
        public string vsb_ID { get; set; }
        public string vsb_Code { get; set; }
        public string vsb_vsn_ID { get; set; }
        public string vsb_Qty { get; set; }
        public string CreatedDate { get; set; }
        public string vsb_prd_ID { get; set; }
        public string vsb_Date { get; set; }
        public string BaseUOM { get; set; }


    }

    public class GetVanstokeBatchHeader
    {

        public string vsn_ID { get; set; }
        public string vsn_udp_ID { get; set; }
        public string vsn_rot_ID { get; set; }

        public string vsn_prd_ID { get; set; }
        public string vsn_Qty { get; set; }

        public string vsn_Type { get; set; }
        public List<GetVanstokeBatch> VanstockBatch { get; set; }
        public string prd_IsBatchItem { get; set; }


    }

}