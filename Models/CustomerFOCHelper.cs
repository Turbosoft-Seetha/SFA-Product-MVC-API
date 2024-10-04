using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class CustomerFOCHelper
    {
    }
    public class PostCustomerFOC
    {     
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UserId { get; set; }
        public string Commend { get; set; }
        public string JSONString { get; set; }
    }
    public class PostCustomerFOCApprovalDetData
    {
        public string prdID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }
        public string totalqty { get; set; }
    }
    public class GetFOCApprovalStatus
    {

        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
       // public string ReturnId { get; set; }
    }
    public class FOCDetailIn
    {
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string UserId { get; set; }

    }
    public class FOCList
    {
        public string HeaderId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Commend { get; set; }
        public string CreatedDate { get; set; }
        public List<FOCApproveDetail> FOCListDetail { get; set; }
    }
    public class FOCApproveDetail
    {
        public string prdID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }
        public string totalqty { get; set; }
    }
}