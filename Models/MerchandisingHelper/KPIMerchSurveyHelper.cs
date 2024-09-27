//using Stimulsoft.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class KPIMerchSurveyHelper
    {
    }


    public class KPIMerchSurveyin
    {
        public string rotID { get; set; }
        public string UserId { get; set; }

    }
    public class KPIMerchSurveyCusin
    {
        public string rotID { get; set; }
        public string srm_ID { get; set; }

    }
    public class KPIMerchCreditNoteComin
    {
        public string rotID { get; set; }

        public string udp_ID { get; set; }
    }


    public class KPIMerchCreditNotein
    {
        public string rotID { get; set; }


    }
    public class KPIMerchDisputeNotein
    {
        public string rotID { get; set; }


    }

    public class KPIMerchDisputeNoteComin
    {
        public string rotID { get; set; }
        public string udp_ID { get; set; }


    }


    public class KPIMerchSurveyOut
    {
        public string srm_Name { get; set; }
        public string TotalCustomers { get; set; }
        public string srm_ID { get; set; }


    }



    public class KPIMerchSurveyCusOut
    {
        public string srm_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string CreatedDate { get; set; }
        public string srm_Number { get; set; }
        public string Status { get; set; }



    }

    public class KPIMerchCreditNoteOut
    {
        
        public string cnh_Number { get; set; }
        public string cnh_Amount { get; set; }

        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string cnh_cus_ID { get; set; }
        public string cnh_SubTotal { get; set; }
        public string cnh_VAT { get; set; }

        public string cnh_ID { get; set; }



    }



    public class KPIMerchCreditNoteComOut
    {
        
        public string cnh_Number { get; set; }
        public string cnh_Amount { get; set; }

        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string cnh_cus_ID { get; set; }
        public string cnh_SubTotal { get; set; }
        public string cnh_VAT { get; set; }

        public string cnh_ID { get; set; }


    }

    public class KPIMerchDisputeNoteOut
    {
        public string drh_TransID { get; set; }
        public string drh_Amount { get; set; }

        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string drh_OtherInfo { get; set; }
        public string drh_Remarks { get; set; }
        public string drh_Image { get; set; }
        public string DisputeType { get; set; }
        public string drh_cus_ID { get; set; }
        public string drh_ID { get; set; }





    }


    public class KPIMerchDisputeNoteComOut
    {
        public string drh_TransID { get; set; }
        public string drh_Amount { get; set; }

        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string drh_OtherInfo { get; set; }
        public string drh_Remarks { get; set; }
        public string drh_Image { get; set; }
        public string DisputeType { get; set; }
        public string drh_cus_ID { get; set; }
        public string drh_ID { get; set; }






    }

    public class KPIMerchCompSurveyin
    {
        public string udpID { get; set; }
        public string UserId { get; set; }
        public string rotID { get; set; }



    }
    public class KPIMerchCompSurveyCusin
    {
        public string udpID { get; set; }
        public string srm_ID { get; set; }
        public string rotID { get; set; }

    }

    public class KPIMerchCompSurveyOut
    {
        public string srm_Name { get; set; }
        public string TotalCustomers { get; set; }
        public string srm_ID { get; set; }
        public string Date { get; set; }


    }



    public class KPIMerchCompSurveyCusOut
    {
        public string srm_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string CreatedDate { get; set; }
        public string srm_Number { get; set; }
        public string Status { get; set; }
        public string srh_ID {  get; set; }

    }

    public class KPIMerchCusReqin
    {
        public string rotID { get; set; }


    }

    public class KPIMerchCusReqResin
    {
        public string rotID { get; set; }

        public string udp_ID { get; set; }

    }

    public class KPIMerchCusReqOut
    {
        public string req_TransID { get; set; }
        public string req_Code { get; set; }
        public string rqt_Name { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string req_ID { get; set; }
        public string cus_ID { get; set; }

    }


    public class KPIMerchCusReqResOut
    {
        public string req_TransID { get; set; }
        public string req_Code { get; set; }
        public string rqt_Name { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string req_ID { get; set; }
        public string cus_ID { get; set; }

    }
    public class KPIMerchCusReqDetin
    {
        public string req_ID { get; set; }

    }
    public class KPIMerchCusReqDetOut
    {
        public string req_Type { get; set; }
        public string req_Remark { get; set; }
        public string req_Image { get; set; }
        public string req_Desc { get; set; }
        public string resp_Image { get; set; }
        public string res_Type { get; set; }

    }

    public class CompCusActin
    {
        public string rot_ID { get; set; }

        public string udpID { get; set; }

    }
    public class CompCusActOut
    {
        public string cah_Code { get; set; }
        public string cah_Name { get; set; }
        public string cah_Description { get; set; }
        public string cah_StartDate { get; set; }
        public string cah_EndDate { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string Status { get; set; }
        public string TransDate { get; set; }
        public string cah_ID { get; set; }
        public string DetailCount { get; set; }





    }

    public class OpenCusActin
    {
        public string rot_ID { get; set; }

    }

    public class OpenCusActDetailin
    {
        public string cad_cah_ID { get; set; }

    }
    public class OpenCusActOut
    {
        public string cah_Code { get; set; }
        public string cah_Name { get; set; }
        public string cah_Description { get; set; }
        public string cah_StartDate { get; set; }
        public string cah_EndDate { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string Status { get; set; }
        public string TransDate { get; set; }
        public string cah_ID { get; set; }
        public string DetailCount { get; set; }
        public string CompletedDetailCount { get; set; }


    }

    public class OpenCusActDetailOut
    {
        public string cad_ID { get; set; }
        public string cad_Code { get; set; }
        public string cad_Name { get; set; }
        public string cad_Description { get; set; }
        public string cad_Type { get; set; }
        public string cad_DueDate { get; set; }
        public string cad_ReferenceImage { get; set; }
        public string cad_CaptureImage { get; set; }
        public string cad_Remarks { get; set; }
        public string cad_SortOrder { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

    }

    
}