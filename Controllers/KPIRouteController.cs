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
                            cse_ID = dr["cse_ID"].ToString(),

                            cus_ID = dr["ord_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["CDate"].ToString(),
                            CusVisitCount = dr["CTime"].ToString(),
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

                string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;

                DataTable dtorders = dm.loadList("SelCusVisitDetail", "sp_KPIServices", cse_ID.ToString());

                if (dtorders.Rows.Count > 0)
                {
                    List<CusVisitDetailOut> listItems = new List<CusVisitDetailOut>();
                    foreach (DataRow dr in dtorders.Rows)
                    {

                        listItems.Add(new CusVisitDetailOut
                        {
                            //ord_id = dr["ord_id"].ToString(),
                            
                            cus_ID = dr["ord_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                           
                            cusStartdatetime = dr["CTime"].ToString(),
                            cusExitdatetime = dr["CTime"].ToString(),
                            visitSeqNo= dr["CTime"].ToString(),
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
                            //ord_id = dr["ord_id"].ToString(),
                            cse_ID = dr["cse_ID"].ToString(),
                            cus_ID = dr["ord_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["CDate"].ToString(),
                            CusVisitCount = dr["CTime"].ToString(),
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
                            //ord_id = dr["ord_id"].ToString(),
                            cse_ID = dr["cse_ID"].ToString(),
                            cus_ID = dr["ord_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["CDate"].ToString(),
                            CusVisitCount = dr["CTime"].ToString(),
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
                            //ord_id = dr["ord_id"].ToString(),
                            cse_ID = dr["cse_ID"].ToString(),
                            cus_ID = dr["ord_cus_ID"].ToString(),
                            cus_code = dr["cus_Code"].ToString(),
                            cus_name = dr["cus_Name"].ToString(),
                            Arcus_name = dr["cus_NameArabic"].ToString(),
                            SeqNo = dr["CDate"].ToString(),
                            CusVisitCount = dr["CTime"].ToString(),
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


       
    }
}



