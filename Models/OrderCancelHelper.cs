using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class OrderCancelHelper
    {



    }

    public class CancelDelOrderInparas
    {
        public string Status_Value { get; set; }
        public string OrdId { get; set; }
        public string UserId { get; set; }

    }

    public class CancelDelOrderOutparas
    {
        public string Res { get; set; }
        public string Desc { get; set; }
       

    }
}