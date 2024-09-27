using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class KPIMerchandisingHelper
    {
    }


    public class MerchInvMonitoringIn
    {
        public string rotID { get; set; }
        public string UserId { get; set; }
        public string udpID { get; set; }

    }

    public class MerchActivityManagementIn
    {
        public string rotID { get; set; }

    }


    public class MerchActivityManagementComIn
    {
        public string rotID { get; set; }
        public string udp_Id { get; set; }

    }

    public class MerchCusServicesIn
    {
        public string rotID { get; set; }
        public string udpID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }


    }




    public class MerchCusServicesComIn
    {
        public string rotID { get; set; }
        public string udp_ID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }


    }

    public class MerchInvMonitoringOut
    {
        public string TotalOutOfStoke { get; set; }
        public string OutOfStokeItems { get; set; }

        public string OutOfStokeCustomers { get; set; }
    }


    public class MerchActivityManagementOut
    {
        public string AssignedTasks { get; set; }

        public string AssignedSurvay { get; set; }
        public string NewDisplayAgreementsCount { get; set; }
        public string OpenCustomerActivityCount { get; set; }



    }


    public class MerchActivityManagementComOut
    {
        public string CompletedTasks { get; set; }

        public string CompletedSurvay { get; set; }
        public string ActiveDisplayAgreementsCount { get; set; }
        public string CompletedCustomerActivityCount { get; set; }



    }


    public class MerchCusServicesOut
    {
        public string CusNewRequestCount { get; set; }

        public string CreditNoteReqCount { get; set; }
        public string DisputeReqCount { get; set; }
        public string ReturnReqCount { get; set; }



    }


    public class MerchCusServicesComOut
    {
        public string CusRepondedRequestCount { get; set; }

        public string ApprovedCreditNoteReq { get; set; }
        public string ApprovedDisputeReq { get; set; }
        public string ApprovedReturnReq { get; set; }



    }

    public class RetReqOut
    {
        public string Request_ID { get; set; }
        public string InvoiceNumber { get; set; }
        public string RequestNumber { get; set; }
        public string Date { get; set; }
        public string ReturnType { get; set; }
        public string InvID { get; set; }
        public string CusID { get; set; }
        public string Status { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string SubTotal { get; set; }
        public string Vat { get; set; }
        public string Total { get; set; }
        public string Signature { get; set; }
        public string Attachment { get; set; }
        public string Remark { get; set; }
        public string Time { get; set; }

    }


    public class RetReqComOut
    {
        public string Request_ID { get; set; }
        public string InvoiceNumber { get; set; }
        public string RequestNumber { get; set; }
        public string Date { get; set; }
        public string ReturnType { get; set; }
        public string InvID { get; set; }
        public string CusID { get; set; }
        public string Status { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string SubTotal { get; set; }
        public string Vat { get; set; }
        public string Total { get; set; }
        public string Signature { get; set; }
        public string Attachment { get; set; }
        public string Remark { get; set; }
        public string Time { get; set; }
    }

    public class TasksOut
    {
        public string cst_ID { get; set; }
        public string cst_cus_ID { get; set; }
        public string cst_brd_ID { get; set; }
        public string cst_Name { get; set; }
        public string CreatedDate { get; set; }
        public string DueDate { get; set; }
        public string cst_Status { get; set; }
        public string cst_cus_Name { get; set;}
        public string cst_brd_Name { get; set; }
        public string cst_Desc { get; set; }
        public string cst_ReferenceImage { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }

    }
}