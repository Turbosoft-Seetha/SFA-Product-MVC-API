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
        public string Json { get; set; }
    }

    public class JsonDataOverride
    {
        public string CrLmt { get; set; }
        public string AvlLmt { get; set; }
        public string TotLmt { get; set; }
        public string InvID { get; set; }
        public string OverDate { get; set; }
        public string CrDays { get; set; }

    }

    public class OverrideApprOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }

    }

}