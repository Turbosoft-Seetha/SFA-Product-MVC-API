using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class OutOfStockController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
      
        public string GetOutOfStockCount([FromForm] GetOutOfStockCountIn inputParams)
        {
            dm.TraceService("GetOutOfStockCount STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
           
            DataTable dt = dm.loadList("GetOutOfStockCount", "sp_MerchandisingWebServices", rotID);

            try
            {
                if (dt.Rows.Count > 0)
                {

                    List<OutOfStockOut> listHeader = new List<OutOfStockOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new OutOfStockOut
                        { 
                            
                            ItemCount = dr["OutOfStockItems"].ToString(),
                            CusCount = dr["OutOfStockCustomers"].ToString()
                            
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
                dm.TraceService("GetOutOfStockCount  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockCount ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetOutOfStockCustomers([FromForm] GetOOSCusIn inputParams)
        {
            dm.TraceService("GetOutOfStockCustomers STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            DataTable dt = dm.loadList("GetOutOfStockCustomers", "sp_MerchandisingWebServices", rotID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSCusOut> listHeader = new List<GetOOSCusOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetOOSCusOut
                        {
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            brd_Name = dr["brd_Name"].ToString(),
                            brd_Img = dr["brd_Img"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            brd_ID = dr["brd_ID"].ToString(),
                            transID = dr["osh_dph_ID"].ToString()

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
                dm.TraceService("GetOutOfStockCustomers  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockCustomers ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetOutOfStockItems([FromForm] GetOOSItemsIn inputParams)
        {
            dm.TraceService("GetOutOfStockItems STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string[] ar = { udpID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockItems", "sp_MerchandisingWebServices", rotID.ToString(),ar);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSItemsOut> listHeader = new List<GetOOSItemsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetOOSItemsOut
                        {
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_ID = dr["prd_ID"].ToString()

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
                dm.TraceService("GetOutOfStockItems  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockItems ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOutOfStockCustomerByItem([FromForm] GetOOSCusByItemIn inputParams)
        {
            dm.TraceService("GetOutOfStockCustomerByItem STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string ItemID = inputParams.ItemID == null ? "0" : inputParams.ItemID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;

            string[] ar = { rotID.ToString(),udpID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockCustomerByItem", "sp_MerchandisingWebServices",ItemID.ToString(),ar);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSCusByItemOut> listHeader = new List<GetOOSCusByItemOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetOOSCusByItemOut
                        {
                            Cus_Code = dr["cus_Code"].ToString(),
                            Cus_Name = dr["cus_Name"].ToString(),
                            Cus_ID = dr["cus_ID"].ToString(),
                            cse_ID= dr["cse_ID"].ToString(),
                            cse_Start = dr["cse_StartTime"].ToString(),
                            cse_End = dr["cse_EndTime"].ToString()

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
                dm.TraceService("GetOutOfStockCustomerByItem  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockCustomerByItem ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOutOfStockBrandByCustomer([FromForm] GetOOSBrandByItemIn inputParams)
        {
            dm.TraceService("GetOutOfStockBrandByCustomer STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
            string ItemID = inputParams.ItemID == null ? "0" : inputParams.ItemID;
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string cusID = inputParams.cseID == null ? "0" : inputParams.cseID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = { rotID.ToString(), udpID.ToString(), cusID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockBrandByCustomer", "sp_MerchandisingWebServices", ItemID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSBrandByItemOut> listHeader = new List<GetOOSBrandByItemOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["brd_Img"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["brd_Img"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                                else
                                {
                                    imag = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new GetOOSBrandByItemOut
                        {
                            brd_Code = dr["brd_Code"].ToString(),
                            brd_Name = dr["brd_Name"].ToString(),
                            brd_ID = dr["brd_ID"].ToString(),
                            brd_Img = imag,
                            HeaderID = dr["osh_ID"].ToString(),

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
                dm.TraceService("GetOutOfStockBrandByCustomer  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockBrandByCustomer ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOutOfStockAccessPointsByItem([FromForm] GetOOSAccessPointByItemIn inputParams)
        {
            dm.TraceService("GetOutOfStockAccessPointsByItem STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
            //string ItemID = inputParams.ItemID == null ? "0" : inputParams.ItemID;
            //string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            //string cusID = inputParams.cseID == null ? "0" : inputParams.cseID;
            //string brdID = inputParams.brdID == null ? "0" : inputParams.brdID;

           // string[] ar = { rotID.ToString(), udpID.ToString(), cusID.ToString(),brdID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockAccessPointsByCustomer", "sp_MerchandisingWebServices", HeaderID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSAccessPointByItemOut> listHeader = new List<GetOOSAccessPointByItemOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetOOSAccessPointByItemOut
                        {
                            LocationID = dr["inl_ID"].ToString(),
                            LocationCode = dr["inl_Code"].ToString(),
                            LocationName = dr["inl_Name"].ToString(),
                            Type = dr["inl_Type"].ToString()

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
                dm.TraceService("GetOutOfStockAccessPointsByItem  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockAccessPointsByItem ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetOutOfStockInitialAndFinalImages([FromForm] GetOOSImagesIn inputParams)
        {
            dm.TraceService("GetOutOfStockInitialAndFinalImages STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
            string ItemID = inputParams.LocationId == null ? "0" : inputParams.LocationId;
            //string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            //string cusID = inputParams.cseID == null ? "0" : inputParams.cseID;
            //string brdID = inputParams.brdID == null ? "0" : inputParams.brdID;

            string[] arr = { ItemID.ToString() };
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            DataTable dt = dm.loadList("GetOutOfStockInitialAndFinalImages", "sp_MerchandisingWebServices", HeaderID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSImagesOut> listHeader = new List<GetOOSImagesOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["osd_InitailImage"].ToString();

                        string imags = "";
                        string imgs = dr["osd_FinalImage"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["osd_InitailImage"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                                else
                                {
                                    imag = url + ar[i];
                                }
                            }

                        }

                        if (imgs != "")
                        {
                            string[] ar = (dr["osd_FinalImage"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imags = imags + "," + url + ar[i];
                                }
                                else
                                {
                                    imags = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new GetOOSImagesOut
                        {
                            InitialImage = imag,
                            FinalImage = imags,
                            InitialRemark= dr["osd_InitialRemarks"].ToString(),
                            FinalRemark= dr["osd_FinalRemarks"].ToString(),


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
                dm.TraceService("GetOutOfStockInitialAndFinalImages  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockInitialAndFinalImages" +
                " ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOutOfStockItemsIN([FromForm] GetOOSCustomerItemIn inputParams)
        {
            dm.TraceService("GetOutOfStockItems STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
            string ItemID = inputParams.LocationId == null ? "0" : inputParams.LocationId;
            //string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            //string cusID = inputParams.cseID == null ? "0" : inputParams.cseID;
            //string brdID = inputParams.brdID == null ? "0" : inputParams.brdID;

            string[] ar = { ItemID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockItemsIn", "sp_MerchandisingWebServices", HeaderID.ToString(),ar);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSCustomerItemOut> listHeader = new List<GetOOSCustomerItemOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetOOSCustomerItemOut
                        {
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_ID= dr["prd_ID"].ToString(),
                            status= dr["osi_status"].ToString(),

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
                dm.TraceService("GetOutOfStockItems  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockItems" +
                " ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOutOfStockCustomer([FromForm] GetOOSCustomerIn inputParams)
        {
            dm.TraceService("GetOutOfStockCustomer STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
           
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;

            string[] ar = {  udpID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockCustomers", "sp_MerchandisingWebServices", rotID.ToString(), ar);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSCustomerOut> listHeader = new List<GetOOSCustomerOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetOOSCustomerOut
                        {
                            Cus_Code = dr["cus_Code"].ToString(),
                            Cus_Name = dr["cus_Name"].ToString(),
                            Cus_ID = dr["cus_ID"].ToString(),
                            cse_ID = dr["cse_ID"].ToString(),
                            cse_Start = dr["cse_StartTime"].ToString(),
                            cse_End = dr["cse_EndTime"].ToString()

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
                dm.TraceService("GetOutOfStockCustomerByItem  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockCustomer ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOutOfStockBrand([FromForm] GetOOSBrandIn inputParams)
        {
            dm.TraceService("GetOutOfStockBrandByCustomer STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;
           
            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
            string cseID = inputParams.cseID == null ? "0" : inputParams.cseID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            string[] arr = {  udpID.ToString(), cseID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockBrands", "sp_MerchandisingWebServices", rotID.ToString(), arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSBrandOut> listHeader = new List<GetOOSBrandOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["brd_Img"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["brd_Img"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                                else
                                {
                                    imag = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new GetOOSBrandOut
                        {
                            brd_Code = dr["brd_Code"].ToString(),
                            brd_Name = dr["brd_Name"].ToString(),
                            brd_ID = dr["brd_ID"].ToString(),
                            brd_Img = imag,
                            HeaderID = dr["osh_ID"].ToString()

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
                dm.TraceService("GetOutOfStockBrandByCustomer  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockBrandByCustomer ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string GetOutOfStockHeader([FromForm] GetOOSIn inputParams)
        {
            dm.TraceService("GetOutOfStockHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;
           

            string[] ar = { udpID.ToString() };
            DataTable dt = dm.loadList("GetOutOfStockHeader", "sp_MerchandisingWebServices", rotID.ToString(), ar);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSOut> listHeader = new List<GetOOSOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new GetOOSOut
                        {
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_ID = dr["cus_ID"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            DateTime = dr["CreatedDate"].ToString()
                            //,HeaderID = dr["osh_ID"].ToString()

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
                dm.TraceService("GetOutOfStockHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetOutOfStockBrandbyHeader([FromForm] GetOOSBrandbyHeaderIn inputParams)
        {
            dm.TraceService("GetOutOfStockBrandbyHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");


            DataTable dt = dm.loadList("GetOutOfStockBrandByHeader", "sp_MerchandisingWebServices", HeaderID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<GetOOSBrandbyHeaderOut> listHeader = new List<GetOOSBrandbyHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["brd_Img"].ToString();

                        if (img != "")
                        {
                            string[] ar = (dr["brd_Img"].ToString().Replace("../", "")).Split(',');

                            for (int i = 0; i < ar.Length; i++)
                            {
                                if (i > 0)
                                {
                                    imag = imag + "," + url + ar[i];
                                }
                                else
                                {
                                    imag = url + ar[i];
                                }
                            }

                        }
                        listHeader.Add(new GetOOSBrandbyHeaderOut
                        {
                            brd_Code = dr["brd_Code"].ToString(),
                            brd_Name = dr["brd_Name"].ToString(),
                            brd_ID = dr["brd_ID"].ToString(),
                            brd_Img = imag,
                           

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
                dm.TraceService("GetOutOfStockBrandbyHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetOutOfStockBrandbyHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


    }
}