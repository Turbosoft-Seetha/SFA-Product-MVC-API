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
    public class CusInsServiceJobController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        //Items and Batch based on one picklist - 2 Dataset and send as single JSON - INPUT - PicklistID, UserID
        [HttpPost]
        public string SelectCusServiceJobCompletedHeader([FromForm] CusSJCompletedIn inputParams)
        {
            dm.TraceService("SelectCusServiceJobCompletedHeader STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {

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
               

                string dateCondition = " And (cast(S.CreatedDate as date) between cast('" + FromDate + "' as date) and cast('" + ToDate + "' as date))";



                string[] arr = { dateCondition.ToString(), RouteCondition.ToString(), AreaCondition.ToString(), SubAreaCondition.ToString() };

                DataTable dtLoadIn = dm.loadList("CusServiceJobCompleted", "sp_CustomerConnect", CusID.ToString(), arr);
                if (dtLoadIn.Rows.Count > 0)
                {
                    List<CusSJCompletedOut> listItems = new List<CusSJCompletedOut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new CusSJCompletedOut
                        {

                            SJCode = dr["snr_Code"].ToString(),
                            Status = dr["Status"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            sjh_ID = dr["sjh_ID"].ToString(),
                            snr_ID = dr["snr_ID"].ToString(),
                            PName = dr["prd_Name"].ToString(),




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
                dm.TraceService(" SelectCusServiceJobCompletedHeader Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectCusServiceJobCompletedHeader ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;

        }
        public string CusSJFilterArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("CusSJFilterArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusSJAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dpa_ID"].ToString(),
                            Name = dr["dpa_Name"].ToString(),


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
                dm.TraceService("CusSJFilterArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusSJFilterArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string CusSJFilterSubArea([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("CusSJFilterSubArea STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;


                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusSJSubAreaFilter", "sp_CustomerConnect", FromDate.ToString(), arr);


                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["dsa_ID"].ToString(),
                            Name = dr["dsa_Name"].ToString(),


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
                dm.TraceService("CusSJFilterSubArea Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusSJFilterSubArea ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
        public string CusSJFilterRoute([FromForm] FilterInputs inputParams)
        {
            dm.TraceService("CusSJFilterRoute STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string lih_ID = inputParams.ID == null ? "0" : inputParams.ID;
                string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;

                string[] arr = { ToDate.ToString(), lih_ID.ToString() };
                DataTable dtLoadIn = dm.loadList("CusSJRouteFilter", "sp_CustomerConnect", FromDate.ToString(), arr);

                if (dtLoadIn.Rows.Count > 0)
                {
                    List<FilterOutPut> listItems = new List<FilterOutPut>();
                    foreach (DataRow dr in dtLoadIn.Rows)
                    {

                        listItems.Add(new FilterOutPut
                        {
                            ID = dr["rot_ID"].ToString(),
                            Name = dr["rot_Name"].ToString(),


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
                dm.TraceService("CusSJFilterRoute Exception - " + ex.Message.ToString());
            }
            dm.TraceService("CusSJFilterRoute ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}