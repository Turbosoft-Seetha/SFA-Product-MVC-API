using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class VoidHelper
    {
    }

    public class GetVoidInsStatus
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string TransID { get; set; }
    }

    public class PostVoid
    {
        public string TrnNumber { get; set; }
        public string UserID { get; set; }
        public string UdpID { get; set; }
        public string Type { get; set; }
        public string CusID { get; set; }
    }

    public class GetVoidStatusIn
    {
        public string TrnNumber { get; set; }
    }
    public class GetStatusOut
    {
        public string Status { get; set; }
    }

}