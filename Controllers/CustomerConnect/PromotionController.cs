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

namespace MVC_API.Controllers
{
    public class PromotionController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectPromotionHeader([FromForm] PromotionHeaderIn inputParams)
        {
            dm.TraceService("SelectPromotionHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                string UserID=inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Customer = inputParams.Customer== null ? "0" : inputParams.Customer;
                string CusOutlet = inputParams.CusOutlet == null ? "0" : inputParams.CusOutlet;


                string RouteCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string CusCondition = "";
                string CusOutCondition = "";
               

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
                if (inputParams.Customer != null)
                {
                    CusCondition = " and C.cus_ID in( " + inputParams.Customer + ")";
                }
                if (inputParams.CusOutlet != null)
                {
                    CusOutCondition = " and CH.csh_ID in( " + inputParams.CusOutlet + ")";
                }


                string dateCondition = " Where (cast(P.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";



                string[] arr = { RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString(),CusCondition.ToString(),CusOutCondition.ToString() };
                

                DataTable dtLoadIn = dm.loadList("PromotionHeader", "sp_CustomerConnect", dateCondition, arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<PromotionHeaderOut> listItems = new List<PromotionHeaderOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new PromotionHeaderOut
                        {
                            ID = dr["prm_ID"].ToString(),
                            PName = dr["prt_Name"].ToString(),
                            DateRange = dr["DateRange"].ToString(),
                            PCode = dr["prm_Number"].ToString(),
                            QCode = dr["qlh_Number"].ToString(),
                            ACode = dr["ash_Number"].ToString(),
                            QID = dr["qlh_ID"].ToString(),
                            AID = dr["ash_ID"].ToString(),
                            PrmName= dr["prm_Name"].ToString(),
                            ArPName = dr["prt_NameArabic"].ToString(),
                            ArPrmName = dr["prm_ArabicName"].ToString()


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
                dm.TraceService("SelectPromotionHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectPromotionHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectPromotionCustomer([FromForm] PromotionCusIn inputParams)
        {
            dm.TraceService("SelectPromotionCustomer STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtLoadIn = dm.loadList("PromotionCustomers", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<PromotionCusOut> listItems = new List<PromotionCusOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new PromotionCusOut
                        {
                            CusCode = dr["cus_Code"].ToString(),
                            CusName = dr["cus_Name"].ToString(),
                            CusType = dr["cus_Type"].ToString(),
                            AreaName = dr["are_Name"].ToString(),
                            Class = dr["Class"].ToString(),
                            ID = dr["prm_ID"].ToString(),
                            ArCusName = dr["cus_NameArabic"].ToString(),
                            ArAreaName = dr["are_NameArabic"].ToString()
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
                dm.TraceService(" SelectPromotionCustomer Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectPromotionCustomer ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string SelectPromotionDetail([FromForm] PromotionCusIn inputParams)
        {
            dm.TraceService("SelectPromotionDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtLoadIn = dm.loadList("PromotionDetails", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<PromotionDetailOut> listItems = new List<PromotionDetailOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new PromotionDetailOut
                        {
                            
                            minQty = dr["prr_MinValue"].ToString(),
                            maxQty = dr["prr_MaxValue"].ToString(),
                            Qty = dr["prr_Value"].ToString(),
                            

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
                dm.TraceService(" SelectPromotionDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectPromotionDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        //GroupItemDetailsIn
        public string SelectGroupItems([FromForm] GroupItemDetailsIn inputParams)
        {
            dm.TraceService("SelectGroupItems STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string Mode=inputParams.Mode== null ? "0" : inputParams.Mode.ToString();

                DataTable dtLoadIn =new DataTable();

                if (Mode == "A")
                {
                    dtLoadIn = dm.loadList("AssignmentGroupDetails", "sp_CustomerConnect", lih_ID.ToString());

                }
                else {
                     dtLoadIn = dm.loadList("QualGroupDetails", "sp_CustomerConnect", lih_ID.ToString());
                }
                

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<GroupItemDetailsOut> listItems = new List<GroupItemDetailsOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new GroupItemDetailsOut
                        {
                            prdCode = dr["prd_Code"].ToString(),
                            prdName = dr["prd_Name"].ToString(),
                            ArprdName = dr["prd_NameArabic"].ToString()

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
                dm.TraceService(" SelectGroupItems Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectGroupItems ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string PromotionFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" PromotionFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString() };
                DataTable dtLoadIn = dm.loadList("PromotionAreaFilter", "sp_CustomerConnect",  FromDate.ToString() , arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dpa_ID"].ToString(),
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
                dm.TraceService("  PromotionFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" PromotionFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string PromotionFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" PromotionFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                string[] arr = {ToDate.ToString() , lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("PromotionSubAreaFilter", "sp_CustomerConnect", FromDate.ToString() , arr);


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
                dm.TraceService("  PromotionFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" PromotionFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string PromotionFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" PromotionFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = {  ToDate.ToString() , lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("PromotionRouteFilter", "sp_CustomerConnect",  FromDate.ToString() , arr);

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
                dm.TraceService("  PromotionFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" PromotionFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string PromotionFilterCustomer([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" PromotionFilterCustomer STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString() };
                DataTable dtLoadIn = dm.loadList("PromotionCustomerHeaderFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

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
                dm.TraceService("  PromotionFilterCustomer Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" PromotionFilterCustomer ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string PromotionFilterCustomerOutlet([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" PromotionFilterCustomerOutlet STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("PromotionCustomerOutletFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

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
                dm.TraceService("  PromotionFilterCustomer Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" PromotionFilterCustomer ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }

}