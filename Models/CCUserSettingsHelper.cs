using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CCUserSettingsHelper
    {
    }
       

    public class GetCCUserSettingsIn
    {
        public string usrID { get; set; }
    }
    public class GetCCUserSettingsOut
    {

        public string ParentNode { get; set; }
        public string ChildNode { get; set; }

    }


}