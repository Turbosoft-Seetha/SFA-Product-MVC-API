using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class DisputeNoteHelper
    {
    }


    public class DisputeNoteReqIn
    {
        public string rotID { get; set; }
        
        public string cusID { get; set; }
        public string udpID { get; set; }
        public string type { get; set; }

        public string date { get; set; }

        public string Remark { get; set; }

        public string JSONString { get; set; }
        public string OtherInfo { get; set; }
        public string Amount { get; set; }
        public string usrID { get; set; }
        public string cseID { get; set; }


    }
    public class InvoiceIDs
    {


        public string oidID { get; set; }
      
        public string Balance { get; set; }

    }
    public class DisputeNoteReqOut
    {
        public string Res { get; set; }

        public string Message { get; set; }
        public string TransID { get; set; }

    }

    public class OutstandingINvIn
    {


        public string rot_ID { get; set; }
        public string UserId { get; set; }



    }

    public class OutstandingINvOut
    {

      
        public string oid_ID { get; set; }
        public string cus_ID { get; set; }

        public string inv_ID { get; set; }
        public string InvoiceNumber { get; set; }

        public string InvoicedDate { get; set; }
        public string InvoiceAmount { get; set; }
        public string InvoiceBalance { get; set; }



    }

    public class PendingDisputeReqIn
    {


        public string rot_ID { get; set; }
        public string UserId { get; set; }



    }

    public class PendingDisputeReqOut
    {
        public string RequestID { get; set; }
        public string RequestNumber { get; set; }
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }

        public string OtherInfo { get; set; }

        public string Remark { get; set; }
        public string Image { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }



    }

    public class CompletedDisputeReqOut
    {
        public string RequestID { get; set; }
        public string RequestNumber { get; set; }
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }

        public string OtherInfo { get; set; }

        public string Remark { get; set; }
        public string Image { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string CreatedDate { get; set; }
        public string ResponseRemark { get; set; }
        public string Status { get; set; }



    }

    public class PendingDisputeReqDetailIn
    {


               public string RequestID { get; set; }



    }

    public class PendingDisputeReqDetailOut
    {
        public string RequestID { get; set; }
        
        public string oid_ID { get; set; }
        public string balance { get; set; }

        public string InvoicedDate { get; set; }

        public string InvoiceID { get; set; }
        public string InvoiceAmount { get; set; }
       

      

    }
    public class DisputeImageIn
    {


        
        public string TransID { get; set; }

    }
    public class DisputeImageOut
    {
        public string Res { get; set; }

        public string Message { get; set; }


    }
}