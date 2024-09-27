
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using System.Web;
using Org.BouncyCastle.Asn1.Ocsp;
using static MVC_API.Models.AssetRemReq;
using MVC_API.Models.CustomerConnectHelper;
using MultipartDataMediaFormatter.Infrastructure;

namespace MVC_API.Controllers.Customer_Connect
{
    public class CusInsightshomeController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]




        public string CusTransactioCount([FromForm] InsCusInsightHome inputParams)
        {

            dm.TraceService("CusTransactioCount STARTED ");
            dm.TraceService("==============================");
            string USRID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
            string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
            string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

            string[] arr = { cus_ID,FromDate.ToString(), ToDate.ToString() };
            DataTable dtDN = dm.loadList("SelCusInsightCount", "sp_CustomerConnect", USRID, arr);
            if (dtDN.Rows.Count > 0)
            {
                List<OutCusInsightHome> listDn = new List<OutCusInsightHome>();
                foreach (DataRow dr in dtDN.Rows)
                {
                    listDn.Add(new OutCusInsightHome
                    {
                        Invoice = dr["CusTrnInvoiceCount"].ToString(),
                        AR = dr["CusTrnARCollectionCount"].ToString(),
                        SaleOrder = dr["CusTrnOrderCollectionCount"].ToString(),
                        SarviceJob = dr["CusTrnServiceJobCount"].ToString(),




                    });
                }
                JSONString = JsonConvert.SerializeObject(new
                {
                    result = listDn
                });

                return JSONString;
            }
            else
            {
                JSONString = "NoDataRes";
                dm.TraceService("NoDataRes");
            }


            dm.TraceService("CusTransactioCount ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }


        public string SelectAllCustomerInsight([FromForm] InsSelectAllCustomerInsight inputParams)
        {

            dm.TraceService("SelectAllCustomerInsight STARTED ");
            dm.TraceService("==============================");
            string USRID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Area= inputParams.Area == null ? "0" : inputParams.Area;
            string SubArea= inputParams.SubArea == null ? "0" : inputParams.SubArea;
            string Route= inputParams.Route == null ? "0" : inputParams.Route;
            string SearchString = inputParams.SearchString == null ? "0" : inputParams.SearchString;

            string MainCondition = "";
            string AreaCondition = "";
            string SubAreaCondition = "";
            string RouteCondition = "";

            if (Area == "0")
            {
                AreaCondition = "";
            }
            else
            {
                AreaCondition = " and dpa_ID in ( " + Area + " )";
            }
            if (SubArea == "0")
            {
                SubAreaCondition = "";
            }
            else
            {
                SubAreaCondition = " and dsa_ID in ( " + SubArea + " )";
            }
            if (Route == "0")
            {
                RouteCondition = "";
            }
            else
            {
                RouteCondition = " and rot_ID in ( " + Route + " )";
            }

            MainCondition += AreaCondition;
            MainCondition += SubAreaCondition;
            MainCondition += RouteCondition;

            string[] arry = { MainCondition.ToString(), SearchString.ToString() };
            DataTable dtDN = dm.loadList("SelectAllCusInsight", "sp_CustomerConnect",USRID,arry);
            if (dtDN.Rows.Count > 0)
            {
                List<OutSelectAllCustomerInsight> listDn = new List<OutSelectAllCustomerInsight>();
                foreach (DataRow dr in dtDN.Rows)
                {
                    listDn.Add(new OutSelectAllCustomerInsight
                    {
                        cus_ID = dr["cus_ID"].ToString(),
                        cus_Code = dr["cus_Code"].ToString(),
                        cus_Name = dr["cus_Name"].ToString(),
                        Header_Code = dr["csh_Code"].ToString(),
                        Header_Name = dr["csh_Name"].ToString(),
                        Area_Name = dr["are_Name"].ToString(),
                        Class_Name = dr["cls_Name"].ToString(),
                        Cus_Type = dr["cus_Type"].ToString(),
                        rot_ID = dr["rcs_rot_ID"].ToString(),
                        rot_Code = dr["rot_Code"].ToString(),
                        rot_Name = dr["rot_Name"].ToString(),
                        Arcus_Name = dr["cus_NameArabic"].ToString(),
                        ArHeader_Name = dr["csh_NameArabic"].ToString(),
                        Arrot_Name = dr["rot_ArabicName"].ToString(),
                        ArArea_Name = dr["are_NameArabic"].ToString()
                    });
                }
                JSONString = JsonConvert.SerializeObject(new
                {
                    result = listDn
                });

                return JSONString;
            }
            else
            {
                JSONString = "NoDataRes";
                dm.TraceService("NoDataRes");
            }


            dm.TraceService("SelectAllCustomerInsight ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }


        public string CusInsightProfileDetail([FromForm] InCusInsightProfile inputParams)
        {

            dm.TraceService("CusInsightProfileDetail STARTED ");
            dm.TraceService("==============================");
            string USRID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;



            DataTable dtDN = dm.loadList("SelCusInsightProfiles", "sp_CustomerConnect", cus_ID);
            if (dtDN.Rows.Count > 0)
            {
                List<OutCusInsightProfile> listDn = new List<OutCusInsightProfile>();
                foreach (DataRow dr in dtDN.Rows)
                {
                    listDn.Add(new OutCusInsightProfile
                    {
                        cus_ID = dr["cus_ID"].ToString(),
                        cus_Code = dr["cus_Code"].ToString(),
                        cus_Name = dr["cus_Name"].ToString(),
                        cus_Address = dr["cus_Address"].ToString(),
                        cus_AddressArabic = dr["cus_AddressArabic"].ToString(),
                        cus_Email = dr["cus_Email"].ToString(),
                        cus_GeoCode = dr["cus_GeoCode"].ToString(),
                        cus_NameArabic = dr["cus_NameArabic"].ToString(),
                        cus_Phone = dr["cus_Phone"].ToString(),
                        cus_WhatsappNumber = dr["cus_WhatsappNumber"].ToString(),





                    });
                }
                JSONString = JsonConvert.SerializeObject(new
                {
                    result = listDn
                });

                return JSONString;
            }
            else
            {
                JSONString = "NoDataRes";
                dm.TraceService("NoDataRes");
            }


            dm.TraceService("CusInsightProfileDetail ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }
        public string SelectAreaForCusInsHome([FromForm] AreaOutStandingIn inputParams)
        {
            dm.TraceService("SelectAreaForCusInsHome STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { CusID };
                DataTable dt = dm.loadList("SelectAreaForCusInsHome", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<AreaOutStandingOut> listItems = new List<AreaOutStandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new AreaOutStandingOut
                        {
                            AreaID = dr["AreaID"].ToString(),
                            Area = dr["Area"].ToString(),
                            Areacode = dr["dpa_Code"].ToString()

                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService("SelectAreaForCusInsHome Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForCusInsHome ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForCusInsHome([FromForm] SubAreaOutStandingIn inputParams)
        {
            dm.TraceService("SelectSubAreaForCusInsHome STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = {AreaID, CusID };
                DataTable dt = dm.loadList("SelectSubAreaForCusInsHome", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<SubAreaOutStandingOut> listItems = new List<SubAreaOutStandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new SubAreaOutStandingOut
                        {
                            SubAreaID = dr["SubAreaID"].ToString(),
                            SubArea = dr["SubArea"].ToString(),
                            Subareacode = dr["dsa_Code"].ToString()

                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService("SelectSubAreaForCusInsHome Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForCusInsHome ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForCusInsHome([FromForm] RouteOutStandingIn inputParams)
        {
            dm.TraceService("SelectRouteForCusInsHome STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { SubAreaID, CusID };
                DataTable dt = dm.loadList("SelectRouteForCusInsHome", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dt.Rows.Count > 0)
                {
                    List<RouteOutStandingOut> listItems = new List<RouteOutStandingOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new RouteOutStandingOut
                        {
                            RouteID = dr["RouteID"].ToString(),
                            Route = dr["Route"].ToString(),
                            RouteCode = dr["rot_Code"].ToString()

                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService("SelectRouteForCusInsHome Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForCusInsHome ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

    }
}