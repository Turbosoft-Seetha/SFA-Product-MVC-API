using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusInsightHelper
    {
        public class CusInvoiceIn
        {
            public string UserID { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string CusID { get; set; }
            public string Route { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            public string InvoiceType { get; set; }
            public string PaymentType { get; set; }
            public string InvoiceWith { get; set; }

        }
        public class CusInvoiceOut
        {
            public string InvoiceNo { get; set; }
            public string InvoiceType { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string ID { get; set; }
            public string Status { get; set; }
            public string GrandTotal { get; set; }
            public string PayType { get; set; }

            public string ArStatus { get; set; }

        }
        public class CusInvoiceDetailIn
        {
            public string ID { get; set; }

        }
        public class CusInvoiceDetailOut
        {
            public string prd_ID { get; set; }
            public string prd_Code { get; set; }
            public string prd_Name { get; set; }
            public string prd_Type { get; set; }
            public string LowerUOM { get; set; }
            public string HigherUOM { get; set; }
            public string LowerQty { get; set; }
            public string HigherQty { get; set; }
            public string Amount { get; set; }
            public string Arprd_Name { get; set; }
            public string Arprd_Type { get; set; }

        }
        public class CusinvoiceTypeWise
        {

            public string Type { get; set; }
            public string Value { get; set; }
            public string Discount { get; set; }
            public string VAT { get; set; }
            public string SubTotal { get; set; }
        }

        public class CusPromotionHeaderIn
        {
            public string UserID { get; set; }
            public string FromDate { get; set; }
            public string CusID { get; set; }
            public string ToDate { get; set; }
            public string Route { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            
        }
        public class CusSJCompletedIn
        {

            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string Route { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            public string Mode { get; set; }
            public string CusID { get; set; }
        }
        public class CusSJCompletedOut
        {
            public string SJCode { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Status { get; set; }
            public string PName { get; set; }
            public string sjh_ID { get; set; }
            public string snr_ID { get; set; }

        }
        public class CusSpecialPricingIn
        {
            public string UserID { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string CusID { get; set; }
            public string Route { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
        }
        public class CusSpecialPricingOUt
        {
            public string prh_ID { get; set; }
            public string prh_Code { get; set; }
            public string prh_Name { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string prh_PayMode { get; set; }
            public string Arprh_Name { get; set; }
        }
        public class CusSPDetailIn
        {
            public string ID { get; set; }

        }
        public class CusSPDetailOut
        {
            public string pld_ID { get; set; }
            public string pld_prh_ID { get; set; }
            public string pld_VATPerc { get; set; }
            public string prd_ID { get; set; }
            public string prd_Code { get; set; }
            public string prd_Name { get; set; }
            public string prd_NameArabic { get; set; }
            public string prd_Description { get; set; }
            public string UOM { get; set; }
            public string StdPrice { get; set; }
            public string SpecialPrice { get; set; }
            public string pld_ReturnPrice { get; set; }


        }
        public class CusEditProfileIn
        {
            public string Mail { get; set; }
            public string Mob { get; set; }
            public string WhatsappNo { get; set; }
            public string CusID { get; set; }
        }
        public class CusEditProfileOut
        {
            public string Res { get; set; }
            public string Title { get; set; }
            public string Descr { get; set; }
            public string ArTitle { get; set; }
        }
        public class CusDocsIn
        {
            public string CusID { get; set; }

        }
        public class CusDocsOut
        {
            public string DocName { get; set; }
            public string DocUrl { get; set; }
            public string FromDate { get; set; }
            public string EndDate { get; set; }
            public string ArDocName { get; set; }
        }
    }
}