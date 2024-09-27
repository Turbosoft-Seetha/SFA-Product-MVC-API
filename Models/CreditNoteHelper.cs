using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CreditNoteHelper
    {
    }
    public class CusInvOutparam
    {
        public string InvID { get; set; }
        public string InvNo { get; set; }
        
    }
    public class CusInvInparam
    {
        public string cusid { get; set; }
        public string prdID { get; set; }
    }
    public class InvitmsOutparam
    {
        public string prdid { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }

    }
    public class InvitmsInparam
    {
        public string Invid { get; set; }
        public string cusid { get; set;}
    }
    public class InvitmsDataOut
    {
        public string HigherUOM { get; set; }
        public string HigherQty { get; set; }
        public string LowerUOM { get; set; }
        public string LowerQty { get; set; }
        public string GrandTotal { get; set; }
       


    }
    public class InvitmsDataIn
    {
        public string InvItmid { get; set; }
        public string InvId {  get; set; }
    }
    public class InsCRNHeader
    {
        public string rotid { get; set; }
        public string cusid { get; set; }
        public string subtotal { get; set; }
        public string Amount { get; set; }
        public string usrid { get; set; }
        public string Detaildata { get; set; }
        public string cseID { get; set; }
        public string udpID { get; set; }
    }
    public class InsCRNDetail
    {
        public string invid { get; set; } = "0";
        public string itmid { get; set; }
        public string huom { get; set; }
        public string hqty { get; set; }
        public string luom { get; set; }
        public string lqty { get; set; }
        public string amount { get; set; }
        public string rsnid { get; set; }
    }
    public class GetCNRInsertStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
        public string ReqID { get; set; }
    }
    public class CNRImageIn
    {


        public string prdID { get; set; }
        public string ReqID { get; set; }

    }
    public class CNRImageOut
    {
        public string Res { get; set; }

        public string Message { get; set; }


    }
    public class OpnCNRIn
    {
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }

    }
    public class OpnCNROut
    {
        public string Reqno { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string reqID { get; set; }
        public string vat { get; set; }
        public string subtotal { get; set; }


    }
    public class PrevCNRIn
    {
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }

    }
    public class PrevCNROut
    {
        public string Reqno { get; set; }
        public string Amount { get; set; }
        public string vat { get; set; }
        public string subtotal { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string reqID { get; set; }

    }

    public class CNRDetailIn
    {
        public string reqID { get; set; }
       

    }
    public class CNRDetailOut
    {
        public string invid { get; set; }
        public string itmid { get; set; }
        public string prdcode { get; set; }
        public string prdname { get; set; }
        public string huom { get; set; }
        public string hqty { get; set; }
        public string luom { get; set; }
        public string lqty { get; set; }
        public string amount { get; set; }
        public string rsnid { get; set; }
        public string cnrimage { get;  set; }
        public string invno { get; set;}


    }

}