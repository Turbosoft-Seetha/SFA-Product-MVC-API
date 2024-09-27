using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CusServiceHelper
    {
    }

    public class SelectCusServiceCountIN
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
       

    }

    public class SelectCusServiceCountOUT
    {
        public string ReqCreditNoteReq { get; set; }
        public string ApprovedCreditNoteReq { get; set; }

        public string ReqDisputeNoteReq { get; set; }
        public string ApprovedDisputeNoteReq { get; set; }
        public string ReqReturnRequest { get; set; }
        public string ApprovedReturnRequest { get; set; }
        public string NewRequest { get; set; }
        public string RespondedReq { get; set; }


    }
    public class SelectReqCreditNoteReqIN
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }


    }   

    public class SelectReqDisputeNoteReqIN
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }

    }

    public class SelectReqReturnReqReqIN
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }


    }

    public class SelectReqNewRequestIN
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }


    }
    public class SelectReqCreditNoteReqOUT
    {
        public string cnh_ID { get; set; }
        public string cnh_Number { get; set; }

        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string Date { get; set; }
        public string status { get; set; }
        public string Arcus_Name { get; set; }
        public string Arstatus { get; set; }

    }

    public class SelectReqDisputeNoteReqout
    {
        public string drh_ID { get; set; }
        public string drh_TransID { get; set; }

        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string Date { get; set; }
        public string status { get; set; }
        public string Arcus_Name { get; set; }
        public string Arstatus { get; set; }
    }

    public class SelectReqReturnReqReqout
    {
        public string rrh_ID { get; set; }
        public string rrh_RequestNumber { get; set; }

        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string Date { get; set; }
        public string status { get; set; }
        public string Arcus_Name { get; set; }
        public string Arstatus { get; set; }
    }
    public class SelectReqNewRequestOUT
    {
        public string req_ID { get; set; }
        public string req_Code { get; set; }

        public string req_TransID { get; set; }
        public string rot_Code { get; set; }

        public string rot_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string Date { get; set; }
        public string status { get; set; }
        public string Arcus_Name { get; set; }
        public string Arstatus { get; set; }
    }


}