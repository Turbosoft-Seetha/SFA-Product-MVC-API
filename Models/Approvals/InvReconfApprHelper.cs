using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class InvReconfApprHelper
    {
    }
    public class InvReconfApprIn
    {
        public string TransID { get; set; }
        public string CreatedDate { get; set; }
        public string RotID { get; set; }
        public string UsrID { get; set; }
        public string UdpID { get; set; }

        public string Json { get; set; }
    }
    public class JsonDataInvReconf
    {
        public string PrdID { get; set; }
        public string HUOM { get; set; }
        public string HQTY { get; set; }
        public string LUOM { get; set; }

        public string LQTY { get; set; }
        public string PhyHUOM { get; set; }

        public string PhyHQTY { get; set; }
        public string PhyLUOM { get; set; }

        public string PhyLQTY { get; set; }

        public string DescHUOM { get; set; }

        public string DescHQTY { get; set; }
        public string DescLUOM { get; set; }

        public string DescLQTY { get; set; }

        public string Isvanstockitms { get; set; }

        public string IsExcessOrShortage { get; set; }


    }

    public class InvReconfApprOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        
    }
    public class GetInvReconfApprHeaderStatus
    {
        public string TransID { get; set; }
        public string UserId { get; set; }

    }
    public class GetApprovalStatus
    {

        public string ApprovalStatus { get; set; }

        public string Products { get; set; }
        public string ReasonID { get; set; }
        //public string InvoiceID { get; set; }

    }
}