using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.ApprovalHelper
{
    public class ReturnApprovalHelper
    {
    }

    public class ReturnReqIn
    {
        public string Status_Value { get; set; }
     }
    public class ReasonIn
    {
        public string rsn_Type { get; set; }



    }

    public class PostReturnreqData
    {
        public string ReturnID { get; set; }
        public string UserId { get; set; }
        public string JSONString { get; set; }



    }

    public class PostReturnApprovalData
    {
        public string rad_ID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
      

    }

    public class GetOpenReturnApprovalStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
        public string TransID { get; set; }
        public string ArStatus { get; set; }
    }

    public class ReasonOut
    {
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }

        public string rsn_Type { get; set; }
        public string rsn_ArName { get; set; }






    }

    public class ReturnReqDetailIn
    {
        public string Req_ID { get; set; }
        public string Mode { get; set; }




    }



    public class ReturnReqDetailOut
    {
        public string rad_ID { get; set; }
        public string rad_prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string RequestedHQty { get; set; }
        public string HUOM { get; set; }

        public string RequestedLQty { get; set; }
        public string RLUOM { get; set; }
        public string ReturnHQty { get; set; }
        public string ReturnedHUOM { get; set; }
        public string ReturnLQty { get; set; }
        public string LUOM { get; set; }
        public string AdjustedHQty { get; set; }
        public string AdjustedLQty { get; set; }
        public string ExcessHQty { get; set; }
        public string ExcessLQty { get; set; }
        public string rsn_Name { get; set; }
        public string inv_InvoiceID { get; set; }
        public string rad_ApprovalStatus { get; set; }
        public string Arprd_Name { get; set; }

        public string Arrsn_Name { get; set; }

    }


    public class ReturnReqOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string rrh_RequestNumber { get; set; }
        public string usr_Name { get; set; }

        public string rah_ID { get; set; }
        public string csh_Code { get; set; }
        public string csh_Name { get; set; }
        public string Mode { get; set; }
        public string CreatedDate { get; set; }
        public string rah_ApprovalStatus { get; set; }

        public string UserID { get; set; }
        public string rotID { get; set; }
        public string Arcus_Name { get; set; }
        public string Arusr_Name { get; set; }
        public string Arcsh_Name { get; set; }
        public string Arrah_ApprovalStatus { get; set; }

    }
}