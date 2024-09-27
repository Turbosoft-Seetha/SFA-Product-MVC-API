using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.MerchandisingHelper
{
    public class DispHelper
    {
    }

    public class DispAgreementIn
    {
        public string rotID { get; set; }



    }


    public class DispAgreementActIn
    {
        public string rotID { get; set; }
        public string udp_ID { get; set; }



    }
    public class DispAgreementsOut
    {
        public string dag_ID { get; set; }
        public string dag_Number { get; set; }
        public string dag_Type { get; set; }
        public string dag_StartDay { get; set; }
        public string dag_EndDay { get; set; }
        public string dag_Status { get; set; }

        public string Date { get; set; }


    }


    public class DispAgreementsActOut
    {
        public string dag_ID { get; set; }
        public string dag_Number { get; set; }
        public string dag_Type { get; set; }
        public string dag_StartDay { get; set; }
        public string dag_EndDay { get; set; }
        public string dag_Status { get; set; }
        public string Date { get; set; }



    }
}