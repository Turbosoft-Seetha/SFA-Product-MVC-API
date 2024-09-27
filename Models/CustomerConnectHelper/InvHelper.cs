using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class InvHelper
    {
    }
    public class InvoiceIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Route { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string InvoiceType { get; set; }
        public string PaymentType { get; set; }
        public string Customer {  get; set; }
        public string CustomerOutlet { get; set; }
        public string InvoiceWith { get; set; }

    }
    public class InvoiceOut
    {
        public string InvoiceNo { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cusName { get; set; }
        public string cusCode { get; set; }
        public string cusOutName { get; set; }
        public string cusOutCode { get; set; }
        public string PayType { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ID { get; set; }
        public string PayMode { get; set; }
        public string Status { get; set; }
        public string GrandTotal { get; set; }
        public string InvoiceType { get; set; }
        public string ArcusName { get; set; }
        public string ArStatus { get; set; }
        public string ArcusOutName { get; set; }



    }
    public class InvoiceDetailIn
    {
        public string UserID { get; set; }
        public string ID { get; set; }

    }
    public class InvoiceDetailOut
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
        public string prd_ArName { get; set; }



    }
    public class invoiceTypeWise
    {
        
        public string Type { get; set; }
        public string Value { get; set; }
        public string Discount { get; set; }
        public string VAT { get; set; }
        public string SubTotal { get; set; }
    }
    public class FilterInputs
    {
        public string UserID { get; set; }
        public string ID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class FilterOutPut
    {
        public string ID { get; set; }
        public string Name { get; set; }   
        public string Code { get; set; }
       
    }
    public class CusFilterOutPut
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }
}