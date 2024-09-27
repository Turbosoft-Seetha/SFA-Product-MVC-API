using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class TargetHelper
    {
    }
    public class TargetIn
    {
        public string Route { get; set; }

    }
    public class TargetdetailIn
    {
        public string Route { get; set; }
        public string fromdate { get; set; }
    }
    
    public class TargetOut
    {
        public string TargetQty { get; set; }
        public string TargetAmount { get; set; }
        public string AchievedQty { get; set; }
        public string AchievedAmount { get; set; }
        public string AmountPerc { get; set; }
        public string QtyPerc { get; set; }
        public string RemQty { get; set; }
        public string RemAmount { get; set; }
        public string RemAmountPerc { get; set; }
        public string RemQtyPerc { get; set; }


      

    }

    public class TargetHeaderOut
    {
        public string month { get; set; }
        public string TotwrkDays { get; set; }
        
        public string CmpltdwrkDays { get; set; }
    }
    public class TargetDetailOut
    {
        public string targetAmnt { get; set; }
        public string AchvdAmnt { get; set; }
        public string MTDGapAmnt { get; set; }

        public string MonthlyGapAmnt { get; set; }
        public string AchvdQty { get; set; }
        public string MTDGapQty { get; set; }

        public string MonthlyGapQty { get; set; }
        public string targetQty { get; set; }
        public string AchvdAmntPer { get; set; }
        public string MonthlyGapAmntper { get; set; }

        public string AchvdQtyper { get; set; }
        public string MonthlyGapQtyper { get; set; }
        public string MTDGapAmntper { get;  set; }
        public string MTDGapQtyper { get;set; }
    }
    public class TargetPackageOut
    {
        public string packageNo { get; set; }
        public string package { get; set; }

        public string MTDGapAmnt { get; set; }

        public string MonthlyGapAmnt { get; set; }
        public string AchvdQty { get; set; }
        public string AchvdQtyper { get; set; }
        public string MTDGapQty { get; set; }

        public string MonthlyGapQty { get; set; }
        public string MonthlyGapQtyper { get; set; }
        public string targetQty { get; set; }
        public string targetAmnt { get; set; }
        public string AchvdAmnt { get; set; }
        public string AchvdAmntper { get; set; }
        public string MonthlygapAmnt { get; set; }
        public string MonthlygapAmntper { get; set; }
        public string ItemCount { get; set; }
        public string pkgId { get; set; }
        public string MTDGapAmntper { get; set; }
        public string MTDGapQtyper { get; set; }

    }
}