using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC_API.Controllers.CustomerConnect
{
    public class ARController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string SelectARTotalCollection([FromForm] ARTotalIn inputParams)
        {
            dm.TraceService("SelectARHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
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

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString(),Mode};
                DataTable dtAR = dm.loadList("SelARTotalcollection", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<ARTotalOut> listItems = new List<ARTotalOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new ARTotalOut
                        {

                            Total_Count = dr["Total_Count"].ToString(),
                            Total_Amount = dr["Total_Amount"].ToString(),

                            HC_Count = dr["HC_Count"].ToString(),
                            HC_Amount = dr["HC_Amount"].ToString(),

                            OP_Count = dr["OP_Count"].ToString(),
                            OP_Amount = dr["OP_Amount"].ToString(),

                            POS_Count = dr["POS_Count"].ToString(),
                            POS_Amount = dr["POS_Amount"].ToString(),

                            Cheque_Count = dr["Cheque_Count"].ToString(),
                            Cheque_Amount = dr["Cheque_Amount"].ToString(),

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
                dm.TraceService("SelectARHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectARHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectARHeader([FromForm] ARHeaderIn inputParams)
        {
            dm.TraceService("SelectARHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string cus = inputParams.cus == null ? "0" : inputParams.cus;
                string outlet = inputParams.outlet == null ? "0" : inputParams.outlet;


                string MainCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string RouteCondition = "";
                string ModeCondition = "";
                string cusCondition = "";
                string outletCondition = "";

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
              
                if (inputParams.cus != null)
                {
                    cusCondition = " and arh_cus_ID in( " + inputParams.cus + ")";
                }
                if (inputParams.outlet != null)
                {
                    outletCondition = " and B.cus_csh_ID in( " + inputParams.outlet + ")";
                }


                MainCondition += AreaCondition;
                MainCondition += SubAreaCondition;
                MainCondition += RouteCondition;
              //  MainCondition += ModeCondition;
                MainCondition += cusCondition;
                MainCondition += outletCondition;

               // string fromDates = DateTime.Parse(FromDate).ToString("yyyyMMdd");
               // string toDates = DateTime.Parse(ToDate).ToString("yyyyMMdd");

                string[] arr = { FromDate.ToString(), ToDate.ToString(), MainCondition.ToString() };
                DataTable dtAR = dm.loadList("SelARHeader", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<ARHeaderOut> listItems = new List<ARHeaderOut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new ARHeaderOut
                        {


                            arh_ID = dr["arh_ID"].ToString(),
                            arh_ARNumber = dr["arh_ARNumber"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            csh_ID = dr["csh_ID"].ToString(),
                            csh_Code = dr["csh_Code"].ToString(),
                            csh_Name = dr["csh_Name"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),                         
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            arh_PayMode = dr["arh_PayMode"].ToString(),
                            arh_PayType = dr["arh_PayType"].ToString(),
                            arh_CollectedAmount = dr["arh_CollectedAmount"].ToString(),
                            arh_BalanceAmount = dr["arh_BalanceAmount"].ToString(),
                            arp_ChequeNo = dr["arp_ChequeNo"].ToString(),
                            arp_ChequeDate = dr["arp_ChequeDate"].ToString(),
                            Image = dr["arp_Image1"].ToString(),
                            bankName = dr["bnk_Name"].ToString(),
                            Arcus_Name = dr["cus_NameArabic"].ToString(),
                            Arcsh_Name = dr["csh_NameArabic"].ToString()
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
                dm.TraceService("SelectARHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectARHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectARDetail([FromForm] ARDetailIn inputParams)
        {
            dm.TraceService("SelectARDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string arh_ID = inputParams.arh_ID == null ? "0" : inputParams.arh_ID;

                DataTable dt = dm.loadList("SelARDetail", "sp_CustomerConnect", arh_ID.ToString());

                if (dt.Rows.Count > 0)
                {
                    List<ARDetailOut> listItems = new List<ARDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        listItems.Add(new ARDetailOut
                        {
                            ard_ID = dr["ard_ID"].ToString(),
                            ard_arh_ID = dr["ard_arh_ID"].ToString(),
                            ard_Amount = dr["ard_Amount"].ToString(),
                            ard_PDC_Amount = dr["ard_PDC_Amount"].ToString(),
                            InvoiceID = dr["InvoiceID"].ToString(),
                            InvoicedOn = dr["InvoicedOn"].ToString(),
                            InvoiceAmount = dr["InvoiceAmount"].ToString(),
                            AmountPaid = dr["AmountPaid"].ToString(),
                            
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
                dm.TraceService("SelectARDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectARDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        //Filter DropDown
        public string SelectAreaForAR([FromForm] AreaARIn inputParams)
        {
            dm.TraceService("SelectAreaForAR STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                 string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = {  FromDate.ToString(), ToDate.ToString() };
                DataTable dtAR = dm.loadList("SelAreaForAR", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<AreaAROut> listItems = new List<AreaAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new AreaAROut
                        {
                            AreaID = dr["AreaID"].ToString(),
                            Area = dr["Area"].ToString(),
                            AreaCode = dr["dpa_Code"].ToString()
                            

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
                dm.TraceService("SelectAreaForAR Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectAreaForAR ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectSubAreaForAR([FromForm] SubAreaARIn inputParams)
        {
            dm.TraceService("SelectSubAreaForAR STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string AreaID = inputParams.AreaID == null ? "0" : inputParams.AreaID;

                string[] arr = {  FromDate.ToString(), ToDate.ToString(), AreaID };
                DataTable dtAR = dm.loadList("SelSubAreaForAR", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<SubAreaAROut> listItems = new List<SubAreaAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new SubAreaAROut
                        {
                            SubAreaID = dr["SubAreaID"].ToString(),
                            SubArea = dr["SubArea"].ToString(),
                            SubAreaCode = dr["dsa_Code"].ToString()

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
                dm.TraceService("SelectSubAreaForAR Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectSubAreaForAR ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectRouteForAR([FromForm] RouteARIn inputParams)
        {
            dm.TraceService("SelectRouteForAR STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string SubAreaID = inputParams.SubAreaID == null ? "0" : inputParams.SubAreaID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), SubAreaID };
                DataTable dtAR = dm.loadList("SelRouteForAR", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<RouteAROut> listItems = new List<RouteAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new RouteAROut
                        {
                            RouteID = dr["RouteID"].ToString(),
                            Route = dr["Route"].ToString(),
                            RouteCode= dr["rot_Code"].ToString()
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
                dm.TraceService("SelectRouteForAR Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectRouteForAR ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectCustomerForAR([FromForm] CusARIn inputParams)
        {
            dm.TraceService("SelectCustomerForAR STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { FromDate.ToString(), ToDate.ToString() };
                DataTable dtAR = dm.loadList("SelCustomerForAR", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<CusAROut> listItems = new List<CusAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new CusAROut
                        {
                            CusID = dr["csh_ID"].ToString(),
                            CusCode = dr["csh_Code"].ToString(),
                            CusName = dr["csh_Name"].ToString(),

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
                dm.TraceService("SelectCustomerForAR Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCustomerForAR ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectOutletForAR([FromForm] OutletARIn inputParams)
        {
            dm.TraceService("SelectOutletForAR STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { FromDate.ToString(), ToDate.ToString(), CusID.ToString() };
                DataTable dtAR = dm.loadList("SelOutletForAR", "sp_CustomerConnect", UserID.ToString(), arr);

                if (dtAR.Rows.Count > 0)
                {
                    List<OutletAROut> listItems = new List<OutletAROut>();
                    foreach (DataRow dr in dtAR.Rows)
                    {

                        listItems.Add(new OutletAROut
                        {
                            OutletID = dr["cus_ID"].ToString(),
                            OutletCode = dr["cus_Code"].ToString(),
                            OutletName = dr["cus_Name"].ToString(),

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
                dm.TraceService("SelectOutletForAR Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectOutletForAR ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string ARorAdvUpdate([FromForm] ARorADVin inputParams)
        {
            dm.TraceService("ARorAdvUpdate STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {


                string[] arr = { inputParams.Type, inputParams.ID, inputParams.BankID, inputParams.Date, inputParams.ChequeNo };
                string Value = dm.SaveData("sp_CustomerConnect", "ARorADVupdate", inputParams.UsrID, arr);
                int Output = Int32.Parse(Value);
                List<ARorAdvOut> listStatus = new List<ARorAdvOut>();
                if (Output > 0)
                {
                    string url = ConfigurationManager.AppSettings.Get("DelIntURL");
                    dm.TraceService("ARorAdvUpdate Update Initial  starts- " + DateTime.Now.ToString());
                    string Json = "";
                    // WebServiceCal(url, Json);
                    dm.TraceService("ARorAdvUpdate Update Initial End - " + DateTime.Now.ToString());

                    listStatus.Add(new ARorAdvOut
                    {
                        Res = Output,
                        Mode = "1",
                        Desc = "Updated successfully"
                    });
                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listStatus
                    });
                    return JSONString;


                }
                else
                {
                    listStatus.Add(new ARorAdvOut
                    {
                        Res = Output,
                        Mode = "0",
                        Desc = " Update failed"
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
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService("ARorAdvUpdate Exception - " + ex.Message.ToString());
            }
            dm.TraceService("ARorAdvUpdate ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}