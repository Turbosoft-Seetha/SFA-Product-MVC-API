using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MVC_API.Models
{
    public class AssetRemReq
    {
        public class InsAssetRemReq
        {
            public string AssetTypeID { get; set; }
            public string ReasonID { get; set; }
            public string Remarks { get; set; }
            public string AssetID { get; set; }
            public string CusID { get; set; }
            public string UserID { get; set;}

            public string rotID { get; set; }
            public string AssetUniqueID { get; set; }
            public string AssetMasterID { get; set; }
            public string udpID { get; set; }
            public string IsImage { get; set; }
            public string cse_ID { get; set; }



        }
        public class OutAssetRemReq
        {
            public string res { get; set; }
            public string des { get; set; }
            public string title { get; set; }


        }
    }
}