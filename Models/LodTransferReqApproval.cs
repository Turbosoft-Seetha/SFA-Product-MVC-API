using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class LodTransferReqApproval
    {
    }
    public class PostLodTransreqItemData
    {
        public string prd_ID { get; set; }
        public string CurrentStockHQty { get; set; }
        public string CurrentStockLQty { get; set; }
        public string CurrentStockHUOM { get; set; }
        public string CurrentStockLUOM { get; set; }
        public string BalanceHQty { get; set; }
        public string BalanceLQty { get; set; }
        public string BalanceHUOM { get; set; }
        public string BalanceLUOM { get; set; }
        public string OffloadHQty { get; set; }
        public string OffloadLQty { get; set; }
        public string OffloadHUOM { get; set; }
        public string OffloadLUOM { get; set; }
        public string HigherPrice { get; set; }
        public string LowerPrice { get; set; }

        
    }
    public class PostLodTransReqData
    {
        public string usr_ID { get; set; }
        public string udp_ID { get; set; }
        public string rot_ID { get; set; }
        public string JSONString { get; set; }
        public string ReqID { get; set; }
        public string Type { get; set; }
        public string Signature { get; set; }
        public string Remarks { get; set; }
      


    }
    public class GetLodReqInsertStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
        public string TransID { get; set; }
    }
    public class GetUpdateStatus
    {
        public string Mode { get; set; }
        public string Status { get; set; }
    }
    public class PostLodTransApprovalStatusData
    {
        public string TransID { get; set; }
        public string UserId { get; set; }

    }
    public class PostLodTransSignandRemark
    {
        public string TransID { get; set; }
        public string UserID { get; set; }

        public string Signature { get; set; }
        public string Remarks { get; set; }
    }
    public class GetlortransreqApprovalHeaderStatus
    {
        public string ApprovalReason { get; set; }
        public string ApprovalStatus { get; set; }
    }


    public class LoadRequestPDFOut
    {
        public string PDFurl { get; set; }
        public string Status { get; set; }
    }

    public class LoadPDFIn
    {
        public string LoadID { get; set; }
    }

}