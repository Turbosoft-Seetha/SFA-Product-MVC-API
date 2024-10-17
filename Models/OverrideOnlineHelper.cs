using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class OverrideOnlineHelper
    {

    }

    public class OverrideApprIn
    {
        public string cse_ID { get; set; }
        public string udp_ID { get; set; }
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }
        public string Type { get; set; }
        public string ff1 { get; set; }
        public string ff2 { get; set; }
        public string ff3 { get; set; }
        public string ff4 { get; set; }
    }
    public class OverrideApprOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string TransID { get; set; }

    }   

    public class GetOverrideApprDetailStatusIn
    {
        public string TransID { get; set; }
        public string rotID { get; set; }

    }
    public class GetOverrideApprDetailStatusOut
    {
        public string Status { get; set; }  

    }

}