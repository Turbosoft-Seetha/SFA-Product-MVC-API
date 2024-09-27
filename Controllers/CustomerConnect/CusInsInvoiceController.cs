using Microsoft.AspNetCore.Mvc;
using MVC_API.Models.CustomerConnectHelper;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using static MVC_API.Models.CustomerConnectHelper.CusInsightHelper;

namespace MVC_API.Controllers.CustomerConnect
{
    public class CusInsInvoiceController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectCusInvoiceHeader([FromForm] CusInvoiceIn inputParams)
        {
            dm.TraceService("SelectCusInvoiceHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {

                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID= inputParams.CusID == null ? "0" : inputParams.CusID;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string InvoiceType = inputParams.InvoiceType == null ? "0" : inputParams.InvoiceType;
                string PaymentType = inputParams.PaymentType == null ? "0" : inputParams.PaymentType;
                string InvoiceWith = inputParams.InvoiceWith == null ? "0" : inputParams.InvoiceWith;

                string RouteCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string InvoiceTypeCondition = "";
                string PaymentTypeCondition = "";
                string InvoiceWithCondition = "";

                if (inputParams.Route != null)
                {
                    RouteCondition = " and R.rot_ID in( " + inputParams.Route + ")";
                }
                if (inputParams.Area != null)
                {
                    AreaCondition = " and Y.dpa_ID in( " + inputParams.Area + ")";
                }
                if (inputParams.SubArea != null)
                {
                    SubAreaCondition = " and X.dsa_ID in( " + inputParams.SubArea + ")";
                }
                if (inputParams.PaymentType != null)
                {
                    PaymentTypeCondition = " and inv_PayMode in( " + inputParams.PaymentType + ")";
                }
                
                if (inputParams.InvoiceWith != null)
                {
                    InvoiceWithCondition = " and ind_TransType in( " + inputParams.InvoiceWith + ")";
                }

                if (inputParams.InvoiceType != null)
                {
                    if (InvoiceType == "DI")
                    {
                        InvoiceTypeCondition = " and sal_ord_ID = 0 ";
                    }
                    else if (InvoiceType == "OBI")
                    {
                        InvoiceTypeCondition = " and sal_ord_ID <> 0 ";
                    }
                    else
                    {
                        InvoiceTypeCondition = "";
                    }
                    //InvoiceTypeCondition = " and inv_PayType in( " + inputParams.InvoiceType + ")";
                }

                string dateCondition = " And (cast(I.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";

                string[] arr = { dateCondition.ToString(), RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString(), PaymentTypeCondition.ToString(), InvoiceTypeCondition.ToString(), InvoiceWithCondition.ToString() };

                DataTable dtLoadIn = dm.loadList("CusInvoiceHeader", "sp_CustomerConnect", CusID.ToString(), arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusInvoiceOut> listItems = new List<CusInvoiceOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusInvoiceOut
                        {

                            InvoiceNo = dr["inv_InvoiceID"].ToString(),
                            Status = dr["Status"].ToString(),
                            InvoiceType = dr["inv_Type"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            ID = dr["inv_ID"].ToString(),
                            GrandTotal = dr["inv_GrandTotal"].ToString(),
                            PayType = dr["inv_PayType"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()
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
                dm.TraceService(" SelectCusInvoiceHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCusInvoiceHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectCusInvoiceDetail([FromForm] CusInvoiceDetailIn inputParams)
        {
            dm.TraceService("SelectCusInvoiceDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtLoadIn = dm.loadList("InvoiceDetail", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusInvoiceDetailOut> listItems = new List<CusInvoiceDetailOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusInvoiceDetailOut
                        {
                            prd_ID = dr["ind_itm_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_Type = dr["ind_TransType"].ToString(),
                            LowerUOM = dr["LowerUOM"].ToString(),
                            HigherUOM = dr["HigherUOM"].ToString(),
                            LowerQty = dr["ind_LowerQty"].ToString(),
                            HigherQty = dr["ind_HigherQty"].ToString(),
                            Amount = dr["ind_GrandTotal"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
                            Arprd_Type = dr["Arind_TransType"].ToString()
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
                dm.TraceService(" SelectCusInvoiceDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCusInvoiceDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectCusInvoiceDetailTypeWise([FromForm] CusInvoiceDetailIn inputParams)
        {
            dm.TraceService("SelectCusInvoiceDetailTypeWise STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtLoadIn = dm.loadList("InvoiceDetailFooter", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<invoiceTypeWise> listItems = new List<invoiceTypeWise>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new invoiceTypeWise
                        {
                            Type = dr["ind_TransType"].ToString(),
                            Discount = dr["Discount"].ToString(),
                            VAT = dr["VAT"].ToString(),
                            Value = dr["Value"].ToString(),
                            SubTotal = dr["SubTotal"].ToString(),
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
                dm.TraceService(" SelectCusInvoiceDetailTypeWise Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCusInvoiceDetailTypeWise ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string CusInvoiceFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("CusInvoiceFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { ToDate.ToString(),CusID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusInvoiceAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dpa_id"].ToString(),
                            Name = dr["dpa_Name"].ToString(),
                            Code = dr["dpa_Code"].ToString()


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
                dm.TraceService("CusInvoiceFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusInvoiceFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string CusInvoiceFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("CusInvoiceFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID= inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { ToDate.ToString(), lih_ID.ToString(),CusID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusInvoiceSubAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);


                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dsa_ID"].ToString(),
                            Name = dr["dsa_Name"].ToString(),
                            Code = dr["dsa_Code"].ToString()


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
                dm.TraceService("CusInvoiceFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusInvoiceFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string CusInvoiceFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("CusInvoiceFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { ToDate.ToString(), lih_ID.ToString(), CusID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusInvoiceRouteFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["rot_ID"].ToString(),
                            Name = dr["rot_Name"].ToString(),
                            Code = dr["rot_Code"].ToString()


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
                dm.TraceService("CusInvoiceFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusInvoiceFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        
    }
}