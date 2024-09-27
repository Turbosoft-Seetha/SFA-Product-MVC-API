using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class PromotionHelper
    {
    }
    public class PromotionHeaderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Route { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Customer {  get; set; }
        public string CusOutlet {  get; set; }
    }
    public class PromotionHeaderOut
    {
        public string ID { get; set; }
        public string PName { get; set; }
        public string DateRange { get; set; }
        public string PCode { get; set; }
        public string QCode { get; set; }
        public string ACode { get; set; }
        public string QID { get; set; }
        public string AID { get; set; }
        public string PrmName {  get; set; }
        public string ArPName { get; set; }
        public string ArPrmName { get; set; }


    }

    public class PromotionCusIn
    {
        public string UserID {  set; get; }
        public string ID { get; set; }
    }
    public class PromotionCusOut
    {
        public string CusCode {  get; set; }
        public string CusName { get; set; }
        public string CusType { get; set; }
        public string AreaName { get; set; }
        public string Class {  get; set; }
        public string ID { get; set; }
        public string ArCusName { get; set; }
        public string ArAreaName { get; set; }
    }
    public class PromotionDetailOut
    {
       
        public string minQty { get; set; }
        public string maxQty { get; set; }
        public string Qty { get; set; }
       
    }
    public class GroupItemDetailsIn
    { 
        public string UserID {  get; set; }
        public string Mode { get; set; }
        public string ID { get; set; }

    }
    public class GroupItemDetailsOut 
    {
        public string prdCode { get; set; }
        public string prdName { get; set; }
        public string ArprdName { get; set; }
    }

}
