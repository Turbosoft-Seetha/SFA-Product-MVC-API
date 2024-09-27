using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class InsightGeolocationHelper
    {


    }

    public class CusInGeolocation
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string cus_ID { get; set; }

    }


    public class CusOutGeolocation
    {

        public string cgl_ID { get; set; }
        public string cgl_CusGeoLoc { get; set; }
        public string usr_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_GeoCode { get; set; }
        public string cus_Name { get; set; }
        public string cus_ID { get; set; }
        public string CreatedDate { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string usr_Code { get; set; }

        public string geolocurl { get; set; }
        public string Status { get; set; }
        public string usr_ArName { get; set; }
        public string cus_ArName { get; set; }


    }

    public class CusInUpdateGeolocationIn
    {
        public string cus_ID { get; set; }
        public string cgl_CusGeoLoc { get; set; }
        public string cgl_ID { get; set; }
      
    }
    public class CusInUpdateGeolocationOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string ArTitle { get; set; }

    }
}