using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class AssetAddReqHelper
    {
    }
    public class InsAssetAddReq
    {
        public string AssetTypeID { get; set; }
        public string SerialNo { get; set; }
        public string AssetName { get; set; }
        public string ReasonID { get; set; }
        public string Remarks { get; set; }
        public string UdpID { get; set; }
        public string CusID { get; set; }
        public string UserID { get; set; }

        public string rotID { get; set; }
        public string AssetUniqueID { get; set; }
        public string cse_ID { get; set; }

    }
    public class OutAssetAddReq
    {
        public string res { get; set; }
        public string des { get; set; }
        public string title { get; set; }
        public string TransID { get; set; }


    }
}