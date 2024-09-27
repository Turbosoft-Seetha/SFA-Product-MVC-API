using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class LoginModal
    {
    }

    public class AppSignin
    {
        public string usercode { get; set; }
        public string userPass { get; set; }
    }

    public class SigninOutParam
    {
        public string usrID { get; set; }
        public string usrName { get; set; }
        public string usrCode { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }
        public string Roles { get; set; }
        public string usrType { get; set; }
        public string userStore { get; set; }
        public string IsInstantStockCount { get; set; }
        public string InventoryOperations { get; set; }        
        public string usrNameArabic { get; set; }        
        public List<SigninOutusrlvlparam> usrleveldata { get; set; }
        
       
    }
    public class SigninOutusrlvlparam
    {
        public string usrlevel { get; set; }
        public string Workflow { get; set; }
        public string Workflowcode { get; set; }
    }
    }