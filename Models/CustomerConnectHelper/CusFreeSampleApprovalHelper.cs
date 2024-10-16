using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class CusFreeSampleApprovalHelper
    {

    }
    #region free sample
    public class CusPostfreeSampleData
    {
        public string OrderID { get; set; }
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string UserId { get; set; }
        public string UdpId { get; set; }
        public string JSONString { get; set; }

    }
    public class CusPostFreeSamplelDetData
    {
        public string PrdID { get; set; }
        public string HigherQty { get; set; }
        public string HigherUOM { get; set; }
        public string LowerQty { get; set; }
        public string LowerUOM { get; set; }
    }
    public class CusGetFreeSampleApprovalStatus
    {

        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string ReturnId { get; set; }
    }
    public class CusGetFreeHeaderStatus
    {
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string ReturnId { get; set; }
    }
    public class CusGetDetFreeSapmpleApprovalStatus
    {

        public string ApprovalStatus { get; set; }
        public string ProductId { get; set; }
        public string ReasonID { get; set; }


    }
    public class CusGetHeaderStatus
    {
        public string ApprovalStatus { get; set; }
    }
    #endregion
    #region foc
    public class CusPostCustomerFOC
    {
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UserId { get; set; }
        public string Commend { get; set; }
        public string JSONString { get; set; }
    }
    public class CusPostCustomerFOCApprovalDetData
    {
        public string prdID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }
        public string totalqty { get; set; }
    }
    public class CusGetFOCApprovalStatus
    {

        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        // public string ReturnId { get; set; }
    }
    public class CusFOCDetailIn
    {
        public string RotId { get; set; }
        public string CusId { get; set; }
        public string UserId { get; set; }

    }
    public class CusFOCList
    {
        public string HeaderId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Commend { get; set; }
        public string CreatedDate { get; set; }
        public List<CusFOCApproveDetail> FOCListDetail { get; set; }
       
    }
    public class CusFOCApproveDetail
    {
        public string prdID { get; set; }
        public string HUOM { get; set; }
        public string HQty { get; set; }
        public string LUOM { get; set; }
        public string LQty { get; set; }
        public string totalqty { get; set; }
    }
    #endregion
    #region override
    public class CusOverrideApprIn
    {
        public string cse_ID { get; set; }
        public string udp_ID { get; set; }
        public string rot_ID { get; set; }
        public string cus_ID { get; set; }
        public string Type { get; set; }
        public string Json { get; set; }
    }

    public class CusJsonDataOverride
    {
        public string CrLmt { get; set; }
        public string AvlLmt { get; set; }
        public string TotLmt { get; set; }
        public string InvID { get; set; }
        public string OverDate { get; set; }
        public string CrDays { get; set; }

    }

    public class CusOverrideApprOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string TransID { get; set; }

    }
    public class CusGetOverrideApprDetailStatusIn
    {
        public string TransID { get; set; }
        public string rotID { get; set; }

    }
    public class CusGetOverrideApprDetailStatusOut
    {
        public string HeaderStatus { get; set; }
        public string DetailStatus { get; set; }

    }
    #endregion

}
    

