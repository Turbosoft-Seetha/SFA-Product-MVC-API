using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class ServiceJobHelper
    {
    }
    public class SJCompletedIn
    {

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Route { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Mode { get; set; }
        public string Customer { get; set; }
        public string CusOutlet { get; set; } 
    }
    public class SJCompletedOut
    {
        public string SJCode { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cusName { get; set; }
        public string cusCode { get; set; }
        public string cusOutName { get; set; }
        public string cusOutCode { get; set; }
        public string salesman { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string PName { get; set; }
        public string sjh_ID { get; set; }
        public string snr_ID { get; set; }
        
    }
    public class SJCompletedInDetail
    {
        public string ID { get; set; }

    }
}