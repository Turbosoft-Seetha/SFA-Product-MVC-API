using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class KPIRouteController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
    


        public string SelDeliveryHeader([FromForm] DeliveryHeaderInKPI inputParams)
        {
            dm.TraceService("SelDeliveryHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelDeliveryHeader", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<DeliveryHeaderOut> listHeader = new List<DeliveryHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new DeliveryHeaderOut
                        {
                            ord_id = dr["ord_id"].ToString(),
                            OrdNO = dr["OrderID"].ToString(),
                            cus_ID = dr["ord_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            Date = dr["CDate"].ToString(),
                            Time = dr["CTime"].ToString(),
                            DelStatus = dr["ord_DeliveryStatus"].ToString(),
                            paymentmode= dr["ord_PayMode"].ToString(),
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
                dm.TraceService("SelDeliveryHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelDeliveryHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string SelDeliveryDetail([FromForm] DeliveryDetailIn inputParams)
        {
            dm.TraceService("SelDeliveryDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string ord_ID = inputParams.ord_ID == null ? "0" : inputParams.ord_ID;

                DataTable dtorders = dm.loadList("SelDeliveryDetail", "sp_KPIServices", ord_ID.ToString());

                if (dtorders.Rows.Count > 0)
                {
                    List<DeliveryDetailOut> listItems = new List<DeliveryDetailOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new DeliveryDetailOut
                        {
                            odd_ID = dr["odd_ID"].ToString(),
                            odd_ord_ID = dr["odd_ord_ID"].ToString(),
                            prd_ID = dr["odd_itm_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            odd_HigherUOM = dr["odd_HigherUOM"].ToString(),
                            odd_LowerUOM = dr["odd_LowerUOM"].ToString(),
                            odd_HigherQty = dr["odd_HigherQty"].ToString(),
                            odd_LowerQty = dr["odd_LowerQty"].ToString(),
                            sold_HigherQty = dr["soldhuomqty"].ToString(),
                            sold_LowerQty = dr["soldluomqty"].ToString(),
                            
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
                dm.TraceService("SelDeliveryDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelDeliveryDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string SelCusPlannedVisitHeader([FromForm] CusPlannedVisitHeaderInKPI inputParams)
        {
            dm.TraceService("SelCusPlannedVisitHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelPlannedVisitHeader", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<PlannedVisitHeaderOut> listHeader = new List<PlannedVisitHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new PlannedVisitHeaderOut
                        {
                            //ord_id = dr["ord_id"].ToString(),
                            

                            cus_ID = dr["cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["PlanSeq"].ToString(),
                            CusVisitCount = dr["visits"].ToString(),
                            Status=dr["Status"].ToString(),
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
                dm.TraceService("SelCusPlannedVisitHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelCusPlannedVisitHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string SelCusVisitDetail([FromForm] SelCusVisitDetailInKPI inputParams)
        {
     
            dm.TraceService("SelCusVisitDetail STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;

                DataTable dtorders = dm.loadList("SelCusVisitDetail", "sp_KPIServices", udp_ID.ToString());

                if (dtorders.Rows.Count > 0)
                {
                    List<CusVisitDetailOut> listItems = new List<CusVisitDetailOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new CusVisitDetailOut
                        {
                           
                            
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                           
                            cusStartdatetime = dr["cusstartdatetime"].ToString(),
                            cusExitdatetime = dr["cusexitdatetime"].ToString(),
                            visitSeqNo= dr["PlanSeq"].ToString(),
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
                dm.TraceService("SelCusVisitDetail Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelCusVisitDetail ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string SelActualVisitHeader([FromForm] ActualVisitHeaderInKPI inputParams)
        {
            dm.TraceService("SelActualVisitHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelActualVisitHeader", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ActualVisitHeaderOut> listHeader = new List<ActualVisitHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ActualVisitHeaderOut
                        {
                           
                            cus_ID = dr["cse_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["PlanSeq"].ToString(),
                            CusVisitCount = dr["Visits"].ToString(),
                            Status = dr["Status"].ToString(),
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
                dm.TraceService("SelActualVisitHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelActualVisitHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        
        public string SelProductiveVisitHeader([FromForm] ProductiveVisitHeaderInKPI inputParams)
        {
            dm.TraceService("SelProductiveVisitHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelProductiveVisitHeader", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<ProductiveVisitHeaderOut> listHeader = new List<ProductiveVisitHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new ProductiveVisitHeaderOut
                        {
                          
                           
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["PlanSeq"].ToString(),
                            CusVisitCount = dr["Visits"].ToString(),
                            Status = dr["Status"].ToString(),
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
                dm.TraceService("SelProductiveVisitHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelProductiveVisitHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        
        public string SelNonProductiveVisitHeader([FromForm] NonProductiveVisitHeaderInKPI inputParams)
        {
            dm.TraceService("SelNonProductiveVisitHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("SelNonProductiveVisitHeader", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<NonProductiveVisitHeaderOut> listHeader = new List<NonProductiveVisitHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new NonProductiveVisitHeaderOut
                        {
                            
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["PlanSeq"].ToString(),
                            CusVisitCount = dr["Visits"].ToString(),
                            Status = dr["Status"].ToString(),
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
                dm.TraceService("SelNonProductiveVisitHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelNonProductiveVisitHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }

        public string selTimeDuration([FromForm] TimeDurationInKPI inputParams)
        {

            dm.TraceService("selTimeDuration STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
            string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

            DataTable dt = dm.loadList("selTimeDuration", "sp_KPIServices", udpID, ar);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<TimeDurationOut> listHeader = new List<TimeDurationOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new TimeDurationOut
                        {
                            Duration = dr["Duration"].ToString(),
                            StartTime = dr["StartTime"].ToString(),
                            CusTime = dr["CusTime"].ToString(),
                            
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
                dm.TraceService("selTimeDuration  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("selTimeDuration ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetCusVisitDetails([FromForm] GetCusVisitDetailsIn inputParams)
        {
            dm.TraceService("GetCusVisitDetails STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string[] ar = { inputParams.rotID == null ? "0" : inputParams.rotID };
                string udpID = inputParams.udpId == null ? "0" : inputParams.udpId;

               

                DataTable dtorders = dm.loadList("GetCusVisitDetails", "sp_KPIServices", udpID, ar);

                if (dtorders.Rows.Count > 0)
                {
                    List<CustomerVisitDetailsOut> listItems = new List<CustomerVisitDetailsOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new CustomerVisitDetailsOut
                        {

                            cus_ID = dr["cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            Date = dr["CreatedDate"].ToString(),
                            StartTime = dr["StartTime"].ToString(),
                            EndTime = dr["EndTime"].ToString(),
                            Duration = dr["Duration"].ToString(),
                            

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
                dm.TraceService("GetCusVisitDetails Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetCusVisitDetails ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }


    }
}



