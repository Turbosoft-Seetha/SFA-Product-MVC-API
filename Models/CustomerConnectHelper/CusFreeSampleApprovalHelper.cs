using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    #region freesample
    public class CCFreeSampleHeader
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string usr_Name { get; set; }
        public string fsh_ID { get; set; }
        public string fshReqID { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string CreatedBy { get; set; }
    }

    public class CCFreeSampleDetail
    {
        public string fsa_ID { get; set; }
        public string fsa_prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string HigherQty { get; set; }
        public string HigherUOM { get; set; }
        public string LowerQty { get; set; }
        public string LowerUOM { get; set; }
        public string ApprovalStatus { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class CCFreeSampleApprovalIn
    {
        public string UserId { get; set; }
        public string HeaderID { get; set; }
        public string JSONString { get; set; }
    }

    public class CCFreeSampleApprovalData
    {
        public string reasonId { get; set; }
        public string Status { get; set; }
        public string fsa_ID { get; set; }
    }

    public class CCFreeSampleApprovalStatus
    {
        public string Status { get; set; }
        public string Res { get; set; }
    }

    public class CusReasonIn
    {
        public string UserId { get; set; }
        public string ReasonType { get; set; }
    }

    public class CusReasonOut
    {
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }
    }
    #endregion

    #region foc
    public class CusFOCHeaderIn
    {
        public string Status_Value { get; set; }
    }

    public class CCFOCApprovalHeaderOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Name { get; set; }
        public string rot_Code { get; set; }
        public string usr_Name { get; set; }
        public string cfh_ID { get; set; }
        public string cfh_RtnId { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ApprovalStatus { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string rsn_Name { get; set; }
    }

    public class CusFOCDetlIn
    {
        public string HeaderID { get; set; }
    }

    public class CusFOCDetailOut
    {
        public string cfa_ID { get; set; }
        public string cfa_prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string cfa_TotalQty { get; set; }
        public string cfa_BalanceQty { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string rsn_Name { get; set; }
        public string ApprovalStatus { get; set; }
    }

    public class CCFOCApprovalIn
    {
        public string cfh_ID { get; set; }
        public string reasonId { get; set; }
        public string userId { get; set; }
    }
    #endregion

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

    public class CusOverrideHeader
    {
        public string Status_Value { get; set; }
    }
}




