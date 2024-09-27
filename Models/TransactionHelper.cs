using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class TransactionHelper
    {
    }

    public class GetTransactionOutpara
    {
        public string trn_ID { get; set; }
        public string trn_Name { get; set; }
        public string trn_OrderSeq { get; set; }
        public string trn_Enable { get; set; }
        public string trn_AppIndex { get; set; }
    }
    public class GetWSInpara
    {
        public string rot_Type { get; set; }
    }
    public class GetWSOutpara
    {
        public string aws_ID { get; set; }
        public string asw_Code { get; set; }
        public string asw_Name { get; set; }
        public string trn_AppIndex { get; set; }
        public string Status { get; set; }

        public string aws_Tag { get; set; }


    }
}