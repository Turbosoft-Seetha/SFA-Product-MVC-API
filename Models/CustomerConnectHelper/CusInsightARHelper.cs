using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CusInsightARHelper 
    {


        public class InsCusInsightARHeader
        {
            public string UserID { get; set; }
            public string cus_ID { get; set; }

            public string From_Date { get; set; }
            public string To_Date { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            public string Route { get; set; }

        }


        public class OutCusInsightARHeader
        {
            public string arh_ID { get; set; }
            public string arh_ARNumber { get; set; }
            public string cus_ID { get; set; }
            public string cus_Code { get; set; }
            public string cus_Name { get; set; }
            public string csh_ID { get; set; }
            public string csh_Code { get; set; }
            public string csh_Name { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string rot_ID { get; set; }
            public string rot_Code { get; set; }
            public string rot_Name { get; set; }
            public string PayMode { get; set; }
            public string PayType { get; set; }
            public string CollectedAmount { get; set; }
            public string BalanceAmount { get; set; }
            public string ChequeNo { get; set; }
            public string ChequeDate { get; set; }
            public string arp_Image1 { get; set; }
            public string bank_Name { get; set; }
            public string ArPayMode { get; set; }
            public string Arbank_Name { get; set; }
            public string Arcsh_Name { get; set; }
            public string Arcus_Name { get; set; }

        }

        public class InsCusInsightARCount
        {
            public string UserID { get; set; }
            public string cus_ID { get; set; }
            public string From_Date { get; set; }
            public string To_Date { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            public string Route { get; set; }



        }

        public class OutCusInsightARCount
        {
            public string Total_Count { get; set; }
            public string HC_Count { get; set; }
            public string OP_Count { get; set; }
            public string POS_Count { get; set; }
            public string Cheque_Count { get; set; }
            public string Total_Amount { get; set; }
            public string HC_Amount { get; set; }
            public string OP_Amount { get; set; }
            public string POS_Amount { get; set; }
            public string Cheque_Amount { get; set; }





        }
    }
}