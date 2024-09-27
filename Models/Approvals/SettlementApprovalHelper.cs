using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class SettlementApprovalHelper
    {
    }
    public class SettlementApprovalHeaderIn
    {
        public string Status_Value { get; set; }

    }
    public class SettlementApprovalHeaderOut
    {
        public string sta_ID { get; set; }
        public string udp_ID { get; set; }
        public string rot_Type { get; set; }      
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string CreatedDate { get; set; }       
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string usr_Name { get; set; }
        public string StartTime { get; set; }
        public string Arrot_Name { get; set; }
        public string Arusr_Name { get; set; }
        public string Arrot_Type { get; set; }
    }

    public class SettlementApprovalCashDetailIn
    {
        public string udpID { get; set; }

    }
    public class SettlementApprovalCashDetailOut
    {
        public string CashInv { get; set; }
        public string CashAR { get; set; }        
        public string debitNote { get; set; }
        public string CashTotal { get; set; }
        public string CashAdv { get; set; }
        public string PendingBalance { get; set; }
        public string PettyCash { get; set; }
       



    }
    public class SettlementApprovalPaymodeDetailIn
    {
        public string udpID { get; set; }

    }
    public class SettlementApprovalPaymodeDetailOut
    {
        public string Mode { get; set; }
        public string ExpectedAmount { get; set; }
        public string CollectedAmount { get; set; }
        public string Variance { get; set; }
        public string ExpectedAmountTotal { get; set; }
        public string CollectedAmountTotal { get; set; }
        public string VarianceTotal { get; set; }
        public string VarianceLimit { get; set; }
        public string ArMode { get; set; }


    }
    public class SettlementApprovalPaymentDetailOut
    {
        public string cus_Code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string chequeNo { get; set; }
        public string chequeDate { get; set; }
        public string bnk_Name { get; set; }
        public string amount { get; set; }
        public string Arbnk_Name { get; set; }
        public string Arname { get; set; }
        public string Artype { get; set; }
    }

    public class PostSettlementApprovalIn
    {
        public string UserId { get; set; }
        public string TransID { get; set; }
        public string JSONString { get; set; }



    }

    public class PostSettlementApprovalData
    {
        public string udp_id { get; set; }
        public string Status { get; set; }



    }
    public class PostSettlementApprovalOut
    {
        public string Status { get; set; }
        public string Res { get; set; }
        public string ArStatus { get; set; }



    }
}