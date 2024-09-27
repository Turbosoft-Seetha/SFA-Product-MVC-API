using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class MasterHelper
    {
    }

    public class CusDocIn
    {
        public string CusID { get; set; }
      
    }
    public class CusDocOut
    {
        public string DocName { get; set; }
        public string DocUrl { get; set; }
        public string FromDate { get; set; }
        public string EndDate { get; set; }
    }

    public class getVehicleIn
    {
        public string rotID { get; set; }

    }
    public class getVehicleOut
    {
        public string vehicleID { get; set; }
        public string vehicleNumber { get; set; }
        public string brand { get; set; }

    }

    public class getHelperIn
    {
        public string rotID { get; set; }

    }
    public class getHelperOut
    {
        public string HelperID { get; set; }
        public string HelperCode { get; set; }
        public string HelperName { get; set; }

    }
    public class getVarianceIn
    {
        public string udp_ID { get; set; }

    }
    public class getVarianceOut
    {
        public string Variance { get; set; }
        public string Date { get; set; }
      

    }
    public class CusDocExpIn
    {
        public string rot_ID { get; set; }

    }
    public class CusDocExpOut
    {
        public string cusID { get; set; }
        public string ExpiryDate { get; set; }


    }
    public class InJourneyPlan
    {
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string cusID { get; set; }
        public string udpID { get; set; }
        public string PrevSeq { get; set; }
        public string CurrentSeq { get; set; }
        public string rsnID { get; set; }



    }
    public class OutJourneyPlan
    {
        public string res { get; set; }
        public string des { get; set; }
        public string title { get; set; }


    }
    public class JPApprvlIN
    {
        public string ApprovalID { get; set; }
      


    }
    public class JPApprvlOut
    {
        public string Status { get; set; }



    }
    public class JPApprvlCancelOut
    {
        public string Res { get; set; }
        public string Message { get; set; }



    }

}