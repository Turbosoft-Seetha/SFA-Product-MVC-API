using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusActReviewHelper
    {
    }

    public class ActReviewHeaderListIn
    {
        public string rotType { get; set; }
    }
    public class ActReviewHeaderListOut
    {
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string rot_Type { get; set; }
        public string usr_Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string udpID { get; set; }
        public string duration { get; set; }
        public string rot_ArName { get; set; }
        public string rot_ArType { get; set; }
        public string usr_ArName { get; set; }
    }   
    public class ActReviewDetailChartDataIn
    {
        public string udpID { get; set; }
    }
    public class ActReviewDetailChartDataOut
    {
        public string TotTargetAmt { get; set; }       
        public string ProRateTarget { get; set; }       
        public string SalPerDay { get; set; }
        public string MTDWrkDays { get; set; }
        public string TotWrkDays { get; set; }
        public string MTDSales { get; set; }
        public string ExcShtg { get; set; }

    }
    public class ActRevTodaysSalesIn
    {
        public string udpID { get; set; }
    }
    public class ActRevTodaysSalesOut
    {
        public string SalesAmt { get; set; }
        public string TotVisits { get; set; }
        public string ProdVisits { get; set; }        

    }
    public class ActRevVisitDataIn
    {
        public string udpID { get; set; }
    }
    public class ActRevVisitDataOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }       
       

    }
    public class ActRevTotalDataIn
    {
        public string udpID { get; set; }
    }
    public class ActRevTotalDataOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
        public string SalesCS { get; set; }
        public string SaleCR { get; set; }
        public string ReturnCS { get; set; }
        public string ReturnCR { get; set; }
        public string CollectCS { get; set; }
        public string CollectCR { get; set; }
        public string TotSalesCS { get; set; }
        public string TotSaleCR { get; set; }
        public string TotReturnCS { get; set; }
        public string TotReturnCR { get; set; }
        public string TotCollectCS { get; set; }
        public string TotCollectCR { get; set; }
        public string cus_ArName { get; set; }


    }

}