using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MVC_API.FE_NAV_Service;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.CustomerConnect
{
    public class InvController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectInvoiceHeader([FromForm] InvoiceIn inputParams)
        {
            dm.TraceService("SelectInvoiceHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string InvoiceType = inputParams.InvoiceType == null ? "0" : inputParams.InvoiceType;
                string PaymentType = inputParams.PaymentType == null ? "0" : inputParams.PaymentType;
                string Customer = inputParams.Customer == null ? "0" : inputParams.Customer;
                string CustomerOutlet = inputParams.CustomerOutlet == null ? "0" : inputParams.CustomerOutlet;
                string InvoiceWith= inputParams.InvoiceWith == null ? "0" : inputParams.InvoiceWith;

                string RouteCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string InvoiceTypeCondition = "";
                string PaymentTypeCondition = "";
                string CustomerCondition = "";
                string CustomerOutletCondition = "";
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
                if (inputParams.Customer != null)
                {
                    CustomerCondition = " and C.cus_ID in( " + inputParams.Customer + ")";
                }
                if (inputParams.CustomerOutlet != null)
                {
                    CustomerOutletCondition = " and CH.csh_ID in( " + inputParams.CustomerOutlet + ")";
                }
                if (inputParams.InvoiceType != null)
                {
                    if(InvoiceType=="DI")
                    {
                        InvoiceTypeCondition = " and sal_ord_ID = 0 ";
                    }
                    else if(InvoiceType=="OBI")
                    {
                        InvoiceTypeCondition = " and sal_ord_ID <> 0 ";
                    }
                    else
                    {
                        InvoiceTypeCondition = "";
                    }
                    //InvoiceTypeCondition = " and inv_PayType in( " + inputParams.InvoiceType + ")";
                }


                string dateCondition = "  Where (cast(I.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date)) " +
                    "and isnull(I.Void,'N')='N'";



                string[] arr = { RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString(), CustomerOutletCondition.ToString(), CustomerCondition.ToString(), PaymentTypeCondition.ToString(), InvoiceTypeCondition.ToString(), InvoiceWithCondition.ToString() };
                

                DataTable dtLoadIn = dm.loadList("InvoiceHeader", "sp_CustomerConnect", dateCondition.ToString(), arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<InvoiceOut> listItems = new List<InvoiceOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new InvoiceOut
                        {

                            InvoiceNo = dr["inv_InvoiceID"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            cusName = dr["csh_Name"].ToString(),
                            cusCode = dr["csh_Code"].ToString(),
                            cusOutName = dr["cus_Name"].ToString(),
                            cusOutCode = dr["cus_Code"].ToString(),
                            PayType = dr["inv_PayType"].ToString(),
                            PayMode= dr["inv_PayMode"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            ID = dr["inv_ID"].ToString(),
                            GrandTotal = dr["inv_GrandTotal"].ToString(),
                            InvoiceType= dr["inv_Type"].ToString(),
                            ArcusName = dr["csh_NameArabic"].ToString(),
                            ArStatus = dr["ArabicStatus"].ToString(),
                            ArcusOutName = dr["cus_NameArabic"].ToString()

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
                dm.TraceService(" SelectInvoiceHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectInvoiceHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectInvoiceDetail([FromForm] InvoiceDetailIn inputParams)
        {
            dm.TraceService("SelectInvoiceDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                DataTable dtLoadIn = dm.loadList("InvoiceDetail", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<InvoiceDetailOut> listItems = new List<InvoiceDetailOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new InvoiceDetailOut
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
                dm.TraceService(" SelectInvoiceDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectInvoiceDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectInvoiceDetailTypeWise([FromForm] InvoiceDetailIn inputParams)
        {
            dm.TraceService("SelectInvoiceDetailTypeWise STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                DataTable dtLoadIn = dm.loadList("InvoiceDetailFooter", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<invoiceTypeWise> listItems = new List<invoiceTypeWise>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new invoiceTypeWise
                        {
                            Type= dr["ind_TransType"].ToString(),
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
                dm.TraceService(" SelectInvoiceDetailTypeWise Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectInvoiceDetailTypeWise ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string InvoiceFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("InvoiceFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = {  ToDate.ToString() };
                DataTable dtLoadIn = dm.loadList("InvoiceAreaFilter", "sp_CustomerConnect",  FromDate.ToString() , arr);

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
                dm.TraceService("InvoiceFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("InvoiceFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string InvoiceFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("InvoiceFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                
                string[] arr = {  ToDate.ToString() , lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("InvoiceSubAreaFilter", "sp_CustomerConnect",  FromDate.ToString() , arr);


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
                dm.TraceService("InvoiceFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("InvoiceFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string InvoiceFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("InvoiceFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = {  ToDate.ToString()  ,lih_ID.ToString()};
                DataTable dtLoadIn = dm.loadList("InvoiceRouteFilter", "sp_CustomerConnect",  FromDate.ToString() , arr);

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
                dm.TraceService("InvoiceFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService("InvoiceFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string InvoiceFilterCustomer([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("InvoiceFilterCustomer STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = {  ToDate.ToString()  };
                DataTable dtLoadIn = dm.loadList("InvoiceCustomerFilter", "sp_CustomerConnect",  FromDate.ToString() ,arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusFilterOutPut> listItems = new List<CusFilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusFilterOutPut
                        {
                            ID = dr["csh_ID"].ToString(),
                            Name = dr["csh_Name"].ToString(),
                            Code = dr["csh_Code"].ToString(),

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
                dm.TraceService("InvoiceFilterCustomer Exception - " + ex.Message.ToString());
            }
            dm.TraceService("InvoiceFilterCustomer ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string InvoiceFilterCustomerOutlet([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("InvoiceFilterCustomerOutlet STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = {  ToDate.ToString() , lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("InvoiceCustomerOutletFilter", "sp_CustomerConnect",  FromDate.ToString() , arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusFilterOutPut> listItems = new List<CusFilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusFilterOutPut
                        {
                            ID = dr["cus_ID"].ToString(),
                            Name = dr["cus_Name"].ToString(),
                            Code = dr["cus_Code"].ToString(),


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
                dm.TraceService("InvoiceFilterCustomer Exception - " + ex.Message.ToString());
            }
            dm.TraceService("InvoiceFilterCustomer ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}