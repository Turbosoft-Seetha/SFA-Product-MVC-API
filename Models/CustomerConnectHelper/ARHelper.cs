using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class ARHelper
    {
    }
    public class ARTotalIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string Mode { get; set; }
    }
    public class ARTotalOut
    {
        public string Total_Count { get; set; }
        public string Total_Amount { get; set; }
        public string HC_Count { get; set; }
        public string HC_Amount { get; set; }
        public string OP_Count { get; set; }
        public string OP_Amount { get; set; }
        public string POS_Count { get; set; }
        public string POS_Amount { get; set; }
        public string Cheque_Count { get; set; }
        public string Cheque_Amount { get; set; }

    }
    public class ARHeaderIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string Mode { get; set; }
        public string cus { get; set;}
        public string outlet { get;set; }
    }
    public class ARHeaderOut
    {
        public string arh_ID { get; set; }
        public string arh_ARNumber { get; set; }
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string csh_ID { get; set; }
        public string csh_Code { get; set; }
        public string csh_Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string arh_PayMode { get; set; }
        public string arh_PayType { get; set; }
        public string arh_CollectedAmount { get; set; }
        public string arh_BalanceAmount { get; set; }
        public string arp_ChequeNo { get; set; }
        public string arp_ChequeDate { get; set; }
        public string Image { get; set; }
        public string bankName { get; set; }
        public string Arcus_Name { get; set; }
        public string Arcsh_Name { get; set; }

    }
    public class ARDetailIn
    {
        public string arh_ID { get; set; }
    }
    public class ARDetailOut
    {
        public string ard_ID { get; set; }
        public string ard_arh_ID { get; set; }
        public string ard_Amount { get; set; }
        public string ard_PDC_Amount { get; set; }
        public string InvoiceID { get; set; }
        public string InvoicedOn { get; set; }
        public string InvoiceAmount { get; set; }
        public string AmountPaid { get; set; }
      
    }

    public class AreaARIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class AreaAROut
    {
        public string AreaID { get; set; }
        public string Area { get; set; }
        public string AreaCode { get; set;}

    }
    public class SubAreaARIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AreaID { get; set; }
        public string CusID { get; set; }

    }
    public class SubAreaAROut
    {
        public string SubAreaID { get; set; }
        public string SubArea { get; set; }
        public string SubAreaCode { get; set; }

    }
    public class RouteARIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SubAreaID { get; set; }
        public string CusID { get; set; }

    }
    public class RouteAROut
    {
        public string RouteID { get; set; }
        public string Route { get; set; }
        public string RouteCode { get; set; }


    }
    public class CusARIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class CusAROut
    {
        public string CusID { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
    }
    public class OutletARIn
    {
        public string UserID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class OutletAROut
    {
        public string OutletID { get; set; }
        public string OutletCode { get; set; }
        public string OutletName { get; set; }
    }

    public class ARorADVin
    {
        public string Type { get; set; }
        public string ID { get; set; }
        public string Date { get; set; }
        public string BankID { get; set; }
        public string ChequeNo { get; set; }
        public string UsrID { get; set; }
    }
    public class ARorAdvOut
    {
        public int Res { get; set; }
        public string Mode { get; set; }
        public string Desc { get; set; }
    }
}