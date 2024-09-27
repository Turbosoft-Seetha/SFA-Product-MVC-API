using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class PickingHelper
    {
    }

    public class PickingIn
    {
        public string UserID { get; set; }
        public string Mode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Route { get; set; }
        public string Customer { get; set; }
        public string Outlet { get; set; }
    }
    public class PickingOut
    {
        public string PickingID { get; set; }
        public string PickingNumber { get; set; }
        public string rot_ID { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string rsn_ID { get; set; }
        public string rsn_Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class PickingDetailIn
    {
        public string PickingID { get; set; }

    }
    public class PickingDetailOut
    {
        public string pkd_ID { get; set; }
        public string pkd_pkh_ID { get; set; }
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_NameArabic { get; set; }
        public string prd_Description { get; set; }
        public string pkd_Higher_uom { get; set; }
        public string pkd_Lower_uom { get; set; }
        public string pkd_PickedHQty { get; set; }
        public string pkd_PickedLQty { get; set; }
        public string pkd_RequestedHQty { get; set; }
        public string pkd_RequestedLQty { get; set; }
        public string pkd_TransType { get; set; }
        public string prd_ArabicDescription { get; set; }

    }
    public class AreaPickingIn
    {
        public string UserID { get; set; }
        public string Mode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class AreaPickingOut
    {
        public string AreaID { get; set; }
        public string Area { get; set; }
        public string AreaCode { get; set; }

    }
    public class SubAreaPickingIn
    {
        public string UserID { get; set; }
        public string Mode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AreaID { get; set; }

    }
    public class SubAreaPickingOut
    {
        public string SubAreaID { get; set; }
        public string SubArea { get; set; }
        public string Subareacode { get; set; }

    }
    public class RoutePickingIn
    {
        public string UserID { get; set; }
        public string Mode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SubAreaID { get; set; }

    }
    public class RoutePickingOut
    {
        public string RouteID { get; set; }
        public string Route { get; set; }
        public string RouteCode { get; set; }

    }
    public class CusPickingIn
    {
        public string UserID { get; set; }
        public string Mode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class CusPickingOut
    {
        public string CusID { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
    }
    public class OutletPickingIn
    {
        public string UserID { get; set; }
        public string Mode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CusID { get; set; }
    }
    public class OutletPickingOut
    {
        public string OutletID { get; set; }
        public string OutletCode { get; set; }
        public string OutletName { get; set; }
    }
    public class ItemwiseSummaryOrdersIn
    {
        public string prdID { get; set; }
        public string UserID { get; set; }
        public string JsonString { get; set; }

    }
    public class ItemwiseSummaryOrdersOut
    {
        public string pih_ID { get; set; }
        public string ord_ERP_OrderNo { get; set; }
        public string pih_Number { get; set; }
        public string prd_ID { get; set; }
        public string ord_Huom { get; set; }
        public string ord_Hqty { get; set; }
        public string pid_HigherQty { get; set; }
        public string pid_HigherUOM { get; set; }
        public string pid_LowerQty { get; set; }
        public string pid_LowerUOM { get; set; }
        public string ord_ExpectedDelDate { get; set; }
        public string prd_WeighingItem { get; set; }
        public string ord_ID { get; set; }
        public string cus_Name { get; set; }
        public string cus_Code { get; set; }
        public string csh_Name { get; set; }
        public string csh_Code { get; set; }
        public string pih_Remarks { get; set; }
        public string usr_Name { get; set; }
        public string usr_ContactNo { get; set; }
        public string ModifiedDate { get; set; }
        public string pih_Status { get; set; }
        public string pid_LineNo { get; set; }
        public string plm_Name { get; set; }
        public string ord_Luom { get;set; }
        public string ord_Lqty { get; set; }
        public string usr_ArName { get; set; }

    }
}