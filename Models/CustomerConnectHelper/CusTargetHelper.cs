using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusTargetHelper
    {
    }

    public class CusHeaderChartIn
    {
        public string FromDate { get; set; }
    }
    public class CusHeaderChartOut
    {
        public string TotalTargetAmt { get; set; }
        public string TotalAchAmt { get; set; }
        public string TotalGapAmt { get; set; }
        public string TotalTargetQty { get; set; }
        public string TotalAchQty { get; set; }
        public string TotalGapQty { get; set; }

    }
    public class HeaderRotCountIn
    {
        public string FromDate { get; set; }

    }
    public class HeaderRotCountOut   {
       
        public string Rotcount { get; set; }

    }
    public class CusTargetHeaderIn
    {       
        public string FromDate { get; set; }
     
    }
    public class CusTargetHeaderOut
    {
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string TargetAmt { get; set; }
        public string TargetQty { get; set; }
        public string AchAmt { get; set; }
        public string AchQty { get; set; }
        public string Arrot_Name { get; set; }

    }
    public class DaysCountIn
    {
        public string rotID { get; set; }
        public string FromDate { get; set; }

    }
    public class DaysCountOut
    {
        public string Month { get; set; }
        public string TotWorkingDays { get; set; }
        public string CompletedDays { get; set; }
        public string ArMonth { get; set; }

    }
    public class CusDetailAmtChartIn
    {
        public string FromDate { get; set; }
        public string rotID { get; set; }
    }
    public class CusDetailAmtChartOut
    {
        public string TotalAmt { get; set; }
        public string AchAmt { get; set; }
        public string MTDGapAmt { get; set; }
        public string MonthGapAmt { get; set; }      

    }
    public class CusDetailQtyChartIn
    {
        public string FromDate { get; set; }
        public string rotID { get; set; }
    }
    public class CusDetailQtyChartOut
    {       
        public string TotalQty { get; set; }
        public string AchQty { get; set; }
        public string MTDGapQty { get; set; }
        public string MonthGapQty { get; set; }

    }
    public class CusTargetDetailIn
    {
        public string FromDate { get; set; }
        public string rotID { get; set; }

    }
    public class CusTargetDetailOut
    {
        public string pkgID { get; set; }
        public string pkgName { get; set; }       
        public string TargetAmt { get; set; }
        public string AchAmt { get; set; }
        public string TargetQty { get; set; }     
        public string AchQty { get; set; }
        public string AchAmtPerc { get; set; }
        public string AchQtyPerc { get; set; }
        public string MTDGapAmt { get; set; }
        public string MTDGapQty { get; set; }
        public string MonthGapAmt { get; set; }
        public string MonthGapQty { get; set; }
        public string MonthGapAmtPerc { get; set; }
        public string MonthGapQtyPerc { get; set; }
        public string ArpkgName { get; set; }

    }
    public class CusTargetPkgDetailIn
    {
        public string pkgID { get; set; }
        public string FromDate { get; set; }
        public string rotID { get; set; }

    }
    public class CusTargetPkgDetailOut
    {
        public string prdID { get; set; }
        public string prdCode { get; set; }
        public string prdName { get; set; }        
        public string AchAmt { get; set; }
        public string AchQty { get; set; }
        public string ArprdName { get; set; }

    }

}