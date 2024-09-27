using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class MustSellApprovalHelper
    {
    }
    public class MustSellApprovalHeaderIn
    {
        public string Status_Value { get; set; }

    }
    public class MustSellApprovalHeaderOut
    {
        public string msa_id { get; set; }
        public string msa_TransID { get; set; }
        public string msa_usr_id { get; set; }
        public string userName { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string CreatedDate { get; set; }
        public string msa_rot_id { get; set; }
        public string OrdNumber { get; set; }
        public string salNumber { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string type { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string Artype { get; set; }
        public string rot_ArName { get; set; }
        public string cus_ArName { get; set; }
        public string ArStatus { get; set; }




    }

    public class MustSellApprovalDetailsIn
    {
        public string HeaderID { get; set; }

    }
    public class MustSellApprovalDetailsOut
    {
        public string msd_id { get; set; }
        public string msd_msa_id { get; set; }        
        public string msd_prd_id { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string msd_HQty { get; set; }
        public string HUOM { get; set; }
        public string msd_LQty { get; set; }
        public string LUOM { get; set; }
        public string Status { get; set; }
        public string prd_ArName { get; set; }
        public string ArHUOM { get; set; }
        public string ArLUOM { get; set; }



    }
    public class PostMustSellApprovalIn
    {
        public string UserId { get; set; }
        public string TransID { get; set; }
        public string JSONString { get; set; }



    }

    public class PostMustSellApprovalData
    {
        public string msa_id { get; set; }
        public string Status { get; set; }



    }
    public class PostMustSellApprovalStatus
    {
        public string Status { get; set; }
        public string Res { get; set; }
        public string ArStatus { get; set; }



    }
}