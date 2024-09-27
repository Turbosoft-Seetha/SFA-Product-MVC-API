using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusTrackingHelper
    {
    }

    public class TrackingIn
    {
        public string rotID { get; set; }
        public string Date { get; set; }
    }
    public class TrackingOut
    {
        public string Customer { get; set; }
        public string Duration { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string MoveStatus { get; set; }
        public string Geocode { get; set; }
        public string CustomerAr { get; set; }

    }

    public class CurLocIn
    {
        public string rotID { get; set; }
        public string Date { get; set; }
    }
    public class CurLocOut
    {
        public string User { get; set; }
        public string Duration { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Geocode { get; set; }
        public string UserAr { get; set; }

    }
}