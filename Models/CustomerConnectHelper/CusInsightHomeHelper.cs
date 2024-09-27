using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CusInsightHomeHelper
    {

    }
    public class InsCusInsightHome
    {
        public string UserID { get; set; }
        public string cus_ID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }



    }
    public class OutCusInsightHome
    {
        public string Invoice { get; set; }
        public string AR { get; set; }
        public string SaleOrder { get; set; }
        public string SarviceJob { get; set; }



    }

    public class InsSelectAllCustomerInsight
    {
        public string UserID { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string SearchString { get; set; }


    }

    public class OutSelectAllCustomerInsight
    {
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string Header_Code { get; set; }
        public string Header_Name { get; set; }
        public string Area_Name { get; set; }

        public string Class_Name { get; set; }
        public string Cus_Type { get; set; }
        public string rot_ID { get;  set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set;}
        public string Arcus_Name { get; set; }
        public string ArHeader_Name { get; set; }
        public string Arrot_Name { get; set; }
        public string ArArea_Name { get; set; }
    }

    public class OutCusInsightProfile
    {
        public string cus_ID { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string cus_NameArabic { get; set; }
        public string cus_Address { get; set; }
        public string cus_AddressArabic { get; set; }

        public string cus_Email { get; set; }
        public string cus_Phone { get; set; }
        public string cus_GeoCode { get; set; }

        public string cus_WhatsappNumber { get; set; }

      




    }

    public class InCusInsightProfile
    {
        public string UserID { get; set; }
        public string cus_ID { get; set; }
    }

    }