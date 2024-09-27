using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusChartDashboardHelper
    {
    }

    public class CCRouteCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCRouteCountOut
    {
        public string Active { get; set; }
        public string DaysStarted { get; set; }
        public string DaysNotStarted { get; set; }

    }
    public class CCPlanVisitCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCPlanVisitCountOut
    {
        public string Planned { get; set; }
        public string Visited { get; set; }
        public string Pending { get; set; }

    }
    public class CCActualVisitCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCActualVisitCountOut
    {
        public string Planned { get; set; }
        public string Unplanned { get; set; }
        public string Total { get; set; }

    }
    public class CCProdVisitCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCProdVisitCountOut
    {
        public string Planned { get; set; }
        public string Unplanned { get; set; }
        public string Total { get; set; }

    }
    public class CCNonProdVisitCountIn
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
    public class CCNonProdVisitCountOut
    {
        public string Planned { get; set; }
        public string Unplanned { get; set; }
        public string Total { get; set; }

    }

}