using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
        public string HeaderId { get; set; }
        public string userId { get; set; }
        public string remarks { get; set; }
        public string JSONString { get; set; }
    }
    public class CCFOCApprovalDet
    {
        public string cfh_ID { get; set; }
    }
    #endregion
    #region override
    public class CCOverRideOut
    {
        public string ooa_ID { get; set; }
        public string ooa_cse_ID { get; set; }
        public string ooa_udp_ID { get; set; }
        public string ooa_rot_ID { get; set; }
        public string ooa_cus_ID { get; set; }
        public string ooa_TransID { get; set; }
        public string ooa_Type { get; set; }       
        public string FlexiField1 { get; set; }
        public string FlexiField2 { get; set; }
        public string FlexiField3 { get; set; }
        public string FlexiField4 { get; set; }
        public string ooa_ApprovalStatus { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Status { get; set; }
        public string ooa_CurrentLevel { get; set; }
        public string ooa_wfm_ID { get; set; }
    }
    public class CCOverRideApproveIn
    {
        public string ooa_ID { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }

    }
    #endregion
}




