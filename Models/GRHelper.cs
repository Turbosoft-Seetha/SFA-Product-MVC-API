using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class GRHelper
    {
    }
    public class GRAssignedInParam
    {
        public string usrID { get; set; }
       
    }
    public class GRAssignedOutParam
    {
        public string TranNo { get; set; }
        public string TransDate { get; set; }
        public string Store { get; set; }

    }
}