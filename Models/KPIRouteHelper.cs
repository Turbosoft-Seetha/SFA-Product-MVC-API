using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class KPIRouteHelper
    {
    }

    public class DeliveryHeaderInKPI
    {

        public string rotID { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }
        public string date { get; set; }

    }
    public class DeliveryHeaderOut
    {
        public string ord_id { get; set; }
        public string OrdNO { get; set; }
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string Arcus_name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DelStatus { get; set; }
        public string paymentmode { get; set; }
        

    }
    public class DeliveryDetailIn
    {
        public string ord_ID { get; set; }


    }
    public class DeliveryDetailOut
    {
        public string odd_ID { get; set; }
        public string odd_ord_ID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string odd_HigherUOM { get; set; }
        public string odd_LowerUOM { get; set; }
        public string odd_HigherQty { get; set; }
        public string odd_LowerQty { get; set; }
        public string sold_HigherQty { get; set; }
        public string sold_LowerQty { get; set; }

    }
    public class CusPlannedVisitHeaderInKPI
    {
        public string rotID { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }

    }
    public class PlannedVisitHeaderOut
    {
        
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string Arcus_name { get; set; }
        public string SeqNo { get; set; }
        public string CusVisitCount { get; set; }
        public string Status { get; set; }

    }
    public class SelCusVisitDetailInKPI
    {
        public string udp_ID { get; set; }

    }
    public class CusVisitDetailOut
    {
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string Arcus_name { get; set; }
        
        public string cusStartdatetime { get; set; }
        public string cusExitdatetime { get; set; }
        public string visitSeqNo { get; set; }
        
    }
    public class ActualVisitHeaderInKPI
    {
        public string rotID { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }

    }
    public class ActualVisitHeaderOut
    {
       
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string Arcus_name { get; set; }
        public string SeqNo { get; set; }
        public string CusVisitCount { get; set; }
        public string Status { get; set; }

    }
   
    public class ProductiveVisitHeaderInKPI
    {
        public string rotID { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }

    }
    public class ProductiveVisitHeaderOut
    {
       
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string Arcus_name { get; set; }
        public string SeqNo { get; set; }
        public string CusVisitCount { get; set; }
        public string Status { get; set; }

    }
   
    public class NonProductiveVisitHeaderInKPI
    {
        public string rotID { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }

    }
    public class NonProductiveVisitHeaderOut
    {
        
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string Arcus_name { get; set; }
        public string SeqNo { get; set; }
        public string CusVisitCount { get; set; }
        public string Status { get; set; }

    }
    public class TimeDurationInKPI
    {
        public string rotID { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }

    }
    public class TimeDurationOut
    {

        public string Duration { get; set; }
        public string StartTime { get; set; }
        public string CusTime { get; set; }

    }
    public class GetCusVisitDetailsIn
    {
        public string rotID { get; set; }
        public string UserID { get; set; }
        public string udpId { get; set; }

    }
    public class CustomerVisitDetailsOut
    {
        public string cus_ID { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string Arcus_name { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }

    }
}