using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class Invoice
    {

    }
    public class PostStampedBackndIn
    {
        public string INV_ID { get; set; }


    }
    public class GetDeliNoteInsertStatus
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
    public class PostAttachments
    {
        public string Mode { get; set; }
        public string InvoiceID { get; set; }
        public string UserID { get; set; }
        public string AttachType { get; set; }
    }
    public class GetInsertAttachmentStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }
    public class InsSettlementRequestIn
    {
        public string udpID { get; set; }
        public string usrID { get; set; }
        public string rotID { get; set; }
       
        public string Remarks { get; set; }
        public string XMLPettyCashDesc { get; set; }
    }
    public class InsSettlementRequestOut
    {
        public string Mode { get; set; }
        public string Status { get; set; }
      
      
    }

    public class CusRouteARIn
    {
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }
    }

    public class GetCusRotAR
    {
        public string inv_ID { get; set; }
        public string inv_InvoiceID { get; set; }
        public string Date { get; set; }
        public string inv_GrandTotal { get; set; }
        public string InvBal { get; set; }
        public string cus_ID { get; set; }
        public string rot_ID { get; set; }
        public string ard_PDC_Amount { get; set; }
        public string DateSortColumn { get; set; }
    }
    public class GetDeliveryInpara
    {
        public string rot_ID { get; set; }
        public string userID { get; set; }

    }
    public class GetDeliveryOutpara
    {
        public string inv_ID { get; set; }
        public string inv_InvoiceID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CusHeaderCode { get; set; }
        public string CusHeaderName { get; set; }
        public string Type { get; set; }
        public string CustomerID { get; set; }
        public string CusHeaderID { get; set; }
        public string PayType { get; set; }
        public string PayMode { get; set; }

    }


    public class PostINVStampedBackndIn
    {
        public string INV_ID { get; set; }


    }

    public class GetINVInsertStatus
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
    public class InsSettlementPettyCashIn
    {
        public string udpID { get; set; }
        public string Desc { get; set; }
        
        public string PettyCash { get; set; }
    }
    public class InsSettlementPettyCashOut
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }
    public class PettyCash
    {
        public string Desc { get; set; }
        public string Amount { get; set; }
       
    }
}