using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class UnshceduledCusVisitApprovalHelper
    {
    }
    
    public class InsUnshceduledCusVisitApprovalIn
    {
        public string rotID { get; set; }
        public string usrID { get; set; }
        public string cusID { get; set; }



    }
   
    public class InsUnshceduledCusVisitApprovalStatusOut
    {
        public string Status { get; set; }
        public string Res { get; set; }


    }
    public class GetUnscheduledVisitApprovalStatus
    {
        public string Status { get; set; }
    }
    public class UnSchCusVisitApprovalHeaderIn
    {
        public string Status_Value { get; set; }

    }
    public class UnSchCusVisitApprovalHeaderOut
    {
        public string uva_ID { get; set; }        
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string rot_Type { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string CreatedDate { get; set; }       
        public string Status { get; set; }
        public string rot_ArName { get; set; }
        public string cus_ArName { get; set; }


    }
    public class UnSchCusVisitApprovalData
    {
        public string uva_ID { get; set; }       

    }
    public class ApproveUnSchCusVisitIn
    {      
        public string JSONString { get; set; }
      
    }
    public class ApproveUnSchCusVisitOut
    {
        public string Descr { get; set; }
        public string Res { get; set; }
        public string Title { get; set; }
        public string ArDescr { get; set; }



    }
    public class UnSchCusVisitRejectData
    {
        public string uva_ID { get; set; }

    }
    public class RejectUnSchCusVisitIn
    {
        public string JSONString { get; set; }

    }
    public class RejectUnSchCusVisitOut
    {
        public string Descr { get; set; }
        public string Res { get; set; }
        public string Title { get; set; }
        public string ArDescr { get; set; }



    }
}