using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CusInsightOutStandingHelper
    {
    }


    public class CusOutStandingIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string cus_ID { get; set; }

    }
    public class CusOutStandingOut
    {
        public string InvoiceID { get; set; }
        public string InvoicedOn { get; set; }
        public string InvoiceAmount { get; set; }
        public string AmountPaid { get; set; }
        public string InvoiceBalance { get; set; }
        public string PDC_Amount { get; set; }
        public string CreatedDate { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string csh_ID { get; set; }
        public string csh_Code { get; set; }
        public string csh_Name { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string Status { get; set; }
        public string ID { get; set; }

    }

    public class CusOutStandingCountIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string cus_ID { get; set; }

    }
    public class CusOutStandingCountOut
    {
        public string DueCount { get; set; }
        public string DueAmount { get; set; }
        public string OverDueCount { get; set; }
        public string OverDueAmount { get; set; }
        public string totCount { get; set; }
        public string totAmount { get; set; }

    }
}