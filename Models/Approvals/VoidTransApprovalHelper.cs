using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class VoidTransApprovalHelper
    {
    }
    public class VoidTransApprovalHeaderIn
    {
        public string Status_Value { get; set; }

    }
    public class VoidTransApprovalHeaderOut
    {
        public string vta_ID { get; set; }
        public string type { get; set; }
        public string trn_Number { get; set; }        
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string CreatedDate { get; set; }
        public string udpID { get; set; }
        public string Status { get; set; }
        public string Artype { get; set; }
        public string rot_ArName { get; set; }




    }

    public class VoidTransApprovalDetailsIn
    {
        public string HeaderID { get; set; }

    }
    public class VoidTransApprovalDetailsOut
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
       

    }
    public class PostVoidTransApprovalIn
    {
        public string UserId { get; set; }
        public string TransID { get; set; }
        public string JSONString { get; set; }
        public string type { get; set; }
        public string trn_Number { get; set; }
        public string udpID { get; set; }



    }
   
    public class PostVoidTransApprovalData
    {
        public string vta_ID { get; set; }
        public string Status { get; set; }
        public string type { get; set; }
        public string trn_Number { get; set; }
        public string udpID { get; set; }
        public string userID { get; set; }


    }
    public class PostVoidTranferApprovalStatusOut
    {
        public string Descr { get; set; }
        public string Res { get; set; }
        public string Title { get; set; }



    }
}