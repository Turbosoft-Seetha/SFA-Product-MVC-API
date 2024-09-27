using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers
{
    public class LoadInController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectLoadInHeader([FromForm] LoadInIn inputParams)
        {
            dm.TraceService("SelectLoadInHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {

                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string Customer = inputParams.Customer == null ? "0" : inputParams.Customer;
                string CusOutlet = inputParams.CusOutlet == null ? "0" : inputParams.CusOutlet;
                string RouteCondition ="";
                string AreaCondition = "";
                string SubAreaCondition = "";
                string CusCondition = "";
                string CusOutCondition = "";


                if (inputParams.Route != null)
                {
                     RouteCondition = " and R.rot_ID in( "+ inputParams.Route+")";
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



                string dateCondition = " And (cast(A.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";
                
                    

                string[] arr = { dateCondition.ToString(), RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString(), CusCondition, CusOutCondition };

                DataTable dtLoadIn = dm.loadList("LoadInHeader", "sp_CustomerConnect", "'"+Mode.ToString()+"'",arr);
                    if (dtLoadIn.Rows.Count > 0)
                {
                    List<LoadInOut> listItems = new List<LoadInOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new LoadInOut
                        {
                            
                            TransactionCode= dr["lih_TransID"].ToString(),
                            rot_ID = dr["rot_ID"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            Status = dr["Status"].ToString(),
                            ID = dr["lih_ID"].ToString(),
                            Date = dr["Date"].ToString(),

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
            catch(Exception ex) {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(" SelectLoadInHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectLoadInHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string SelectLoadInDetail([FromForm] LoadInDetailIn inputParams)
        {
            dm.TraceService("SelectLoadInDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;

                DataTable dtLoadIn = dm.loadList("LoadInDetail", "sp_CustomerConnect", lih_ID.ToString());

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<LoadInDetailOut> listItems = new List<LoadInDetailOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new LoadInDetailOut
                        {
                            prd_ID = dr["prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            LowerUOM = dr["LowerUOM"].ToString(),
                            HigherUOM = dr["HigherUOM"].ToString(),
                            LowerQty = dr["lid_LowerQty"].ToString(),
                            HigherQty = dr["lid_HigherQty"].ToString(),
                            LiHigherQty = dr["lid_FinalHigherQty"].ToString(),
                            LiLowerQty = dr["lid_FinalLowerQty"].ToString(),
                            LiHigherUom = dr["lid_FinalHigherUom"].ToString(),
                            LiLowerUom = dr["lid_FinalLowerUom"].ToString(),
                            Arprd_name = dr["prd_NameArabic"].ToString(),
                            Arprd_desc = dr["prd_ArabicDescription"].ToString()

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
                dm.TraceService(" SelectLoadInDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectLoadInDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string LoadInFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" LoadInFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("LoadInAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

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
                dm.TraceService("  LoadInFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" LoadInFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string LoadInFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" LoadInFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("LoadInSubAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);


                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dsa_ID"].ToString(),
                            Name = dr["dsa_Name"].ToString(),
                            Code= dr["dsa_Code"].ToString()

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
                dm.TraceService("  LoadInFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" LoadInFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string LoadInFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("LoadInFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("LoadInRouteFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

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
                dm.TraceService("  LoadInFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService("LoadInFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

    }
}