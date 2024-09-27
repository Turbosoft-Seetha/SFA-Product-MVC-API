using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusMerchHelper
    {
    }

    public class CCOutOfStockCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCOutOfStockCountOut
    {
        public string ItemCount { get; set; }
        public string CusCount { get; set; }
        public string TransCount { get; set; }

    }
    public class CCOOSItemsIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }


    }
    public class CCOOSItemsOut
    {
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string osi_ID { get; set; }
        public string cusCount { get; set; }
        public string prd_ArName { get; set; }


    }
    public class CCOOSItemsDetIn
    {
        public string osi_ID { get; set; }


    }
    public class CCOOSItemsDetOut
    {
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_ArName { get; set; }
        public string cus_ArName { get; set; }

    }
    public class CCOOSCusIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCOOSCusOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }        
        public string cus_ID { get; set; }
        public string ProdCount { get; set; }
        public string cus_ArName { get; set; }


    }
    public class CCOOSCusDetIn
    {
        public string cus_ID { get; set; }

    }
    public class CCOOSCusDetOut
    {
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_ArName { get; set; }


    }

    public class CCTasksCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCTasksCountOut
    {
        public string AssignedTasks { get; set; }
        public string CompletedTasks { get; set; }

    }
    public class CCTasksIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }

    }
    public class CCTasksOut
    {
        public string TaskName { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string DueOn { get; set; }
        public string CompOn { get; set; }
        public string Status { get; set; }
        public string TaskCode { get; set; }
        public string TaskArName { get; set; }
        public string cus_ArName { get; set; }
        public string ArStatus { get; set; }

    }
    public class CCSurveyCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCSurveyCountOut
    {
        public string AssignedSurvey { get; set; }
        public string CompletedSurvey { get; set; }

    }
    public class CCSurveyIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }


    }
    public class CCSurveyOut
    {
        public string SurveyName { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string DueOn { get; set; }
        public string CompOn { get; set; }
        public string Status { get; set; }
        public string SurveyArName { get; set; }
        public string cus_ArName { get; set; }
        public string ArStatus { get; set; }




    }
    public class CCDisplayCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCDisplayCountOut
    {
        public string New { get; set; }        
        public string Approved { get; set; }
        public string Active { get; set; }

    }
    public class CCDisplayAgreeIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }

    }
    public class CCDisplayAgreeOut
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string ArType { get; set; }
        public string cus_ArName { get; set; }
        public string ArStatus { get; set; }

    }
    public class CCCusActCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCCusActCountOut
    {
        public string Total { get; set; }
        public string ActionTaken { get; set; }      
    }
    public class CCCusActIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }

    }
    public class CCCusActOut
    {
        public string ActName { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string Act_ArName { get; set; }
        public string cus_ArName { get; set; }
        public string ArStatus { get; set; }


    }
}