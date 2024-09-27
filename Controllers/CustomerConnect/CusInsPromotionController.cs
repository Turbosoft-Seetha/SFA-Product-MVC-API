using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVC_API.Models.CustomerConnectHelper.CusInsightHelper;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.CustomerConnect
{
    public class CusInsPromotionController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectCusPromotionHeader([FromForm] CusPromotionHeaderIn inputParams)
        {
            dm.TraceService("SelectPromotionHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string Route = inputParams.Route == null ? "0" : inputParams.Route;
                string Area = inputParams.Area == null ? "0" : inputParams.Area;
                string SubArea = inputParams.SubArea == null ? "0" : inputParams.SubArea;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;
               


                string RouteCondition = "";
                string AreaCondition = "";
                string SubAreaCondition = "";


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


                string dateCondition = " And (cast(P.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";



                string[] arr = { dateCondition,RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString() };


                DataTable dtLoadIn = dm.loadList("CusPromotionHeader", "sp_CustomerConnect", CusID, arr);
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
                            ArPName = dr["prt_NameArabic"].ToString()

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
        
        public string SelectCusPromotionDetail([FromForm] PromotionCusIn inputParams)
        {
            dm.TraceService("SelectCusPromotionDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
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
                dm.TraceService(" SelectCusPromotionDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCusPromotionDetail ENDED - " + DateTime.Now);
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
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string Mode = inputParams.Mode == null ? "0" : inputParams.Mode.ToString();

                DataTable dtLoadIn = new DataTable();

                if (Mode == "A")
                {
                    dtLoadIn = dm.loadList("AssignmentGroupDetails", "sp_CustomerConnect", lih_ID.ToString());

                }
                else
                {
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
        public string CusInsightPromotionFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" CusInsightPromotionFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { ToDate.ToString(), CusID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusPromotionAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

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
                dm.TraceService("  CusInsightPromotionFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" CusInsightPromotionFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string CusInsightPromotionFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" CusInsightPromotionFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { ToDate.ToString(), lih_ID.ToString(), CusID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusPromotionSubAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);


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
                dm.TraceService("  CusInsightPromotionFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" CusInsightPromotionFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string CusInsightPromotionFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService(" CusInsightPromotionFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                string CusID = inputParams.CusID == null ? "0" : inputParams.CusID;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() , CusID };
                DataTable dtLoadIn = dm.loadList("CusPromotionRouteFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

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
                dm.TraceService(" CusInsightPromotionFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService(" CusInsightPromotionFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}