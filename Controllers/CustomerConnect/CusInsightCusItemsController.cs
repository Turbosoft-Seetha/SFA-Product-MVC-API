using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVC_API.Models.CustomerConnectHelper.CusInsightHelper;

namespace MVC_API.Controllers.CustomerConnect
{
    public class CusInsightCusItemsController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string SelectCusItems([FromForm] CusPromotionHeaderIn inputParams)
        {
            dm.TraceService("SelectCusItems STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                //string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                //string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                //string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                //string Area = inputParams.Area == null ? "0" : inputParams.Area;
                //string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;



                string RouteCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";


                //if (inputParams.Route != null)
                //{
                //    RouteCondition = " and R.rot_ID in( " + inputParams.Route + ")";
                //}
                //if (inputParams.Area != null)
                //{
                //    AreaCondition = " and Y.dpa_ID in( " + inputParams.Area + ")";
                //}
                //if (inputParams.SubArea != null)
                //{
                //    SubAreaCondition = " and X.dsa_ID in( " + inputParams.SubArea + ")";
                //}


                //string dateCondition = " And (cast(P.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";



                string[] arr = { Route};


                DataTable dtLoadIn = dm.loadList("SelRouteItems", "sp_CustomerConnect", CusID,arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusItemsIn> listItems = new List<CusItemsIn>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusItemsIn
                        {
                           
                            prd_ID = dr["prd_ID"].ToString(),
                            pld_uom_ID = dr["uom_ID"].ToString(),
                            pld_Price = dr["pru_Price"].ToString(),
                            pld_ReturnPrice = dr["pru_ReturnPrice"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            uom_Name = dr["uom_Code"].ToString(),
                            prd_ArName = dr["prd_NameArabic"].ToString()


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
                dm.TraceService("SelectCusItems Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCusItems ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string CusEditProfile(CusEditProfileIn Inparams)
        {
            dm.TraceService("CusEditProfile STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] arr = { Inparams.Mob,Inparams.WhatsappNo,Inparams.CusID };
            DataTable dt = dm.loadList("UpdateCusProfiles", "sp_CustomerConnect", Inparams.Mail, arr);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string Mode = dt.Rows[0]["res"].ToString();
                    string Title = dt.Rows[0]["Title"].ToString();
                    string Descr = dt.Rows[0]["Descr"].ToString();
                    string ArTitle = dt.Rows[0]["ArTitle"].ToString();
                    dm.TraceService("Response from Sql Procedure : Mode=" + Mode + " and Title=" + Title);
                    List<CusEditProfileOut> listStatus = new List<CusEditProfileOut>();
                    listStatus.Add(new CusEditProfileOut
                    {
                        Res = Mode,
                        Title = Title,
                        Descr = Descr,
                        ArTitle = ArTitle
                    });
                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listStatus
                    });
                    return JSONString;
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("CusEditProfile  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CusEditProfile ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetCustomerDocuments([FromForm] CusDocsIn inputParams)
        {
            dm.TraceService("GetCustomerDocuments STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelCustomerDocuments", "sp_App", CusID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CusDocsOut> listHeader = new List<CusDocsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusDocsOut
                        {
                            DocName = dr["cdc_DocName"].ToString(),
                            DocUrl = url + dr["cdc_DocPath"].ToString(),
                            FromDate = dr["cdc_FromDate"].ToString(),
                            EndDate = dr["cdc_ToDate"].ToString(),
                            ArDocName = dr["cdc_DocNameArabic"].ToString(),
                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listHeader
                    });

                    return JSONString;
                }
                else
                {
                    dm.TraceService("NoDataRes");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("GetCustomerDocuments  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetCustomerDocuments ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
    }

}