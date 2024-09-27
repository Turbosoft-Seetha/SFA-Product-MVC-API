using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.MerchandisingHelper
{
    public class PlanogramHelper
    {
    }
    public class PlanogramInPara
    {
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }
    }
    public class PlanogramMasterOut
    {
        public string plg_ID { get; set; }
        public string plg_Code { get; set; }
        public string plg_Name { get; set; }
        public string plg_Image { get; set; }
        public string plg_Remarks { get; set; }

    }
    public class PostPlanogramImageIn
    {
        public string UserID { get; set; }
        public string Remarks { get; set; }
        public string ResponseId { get; set; }
        public string UdpId { get; set; }
        public string CusId { get; set; }
        public string CseId { get; set; }
        public string RouteId { get; set; }
    }
    public class PanogramStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }
}