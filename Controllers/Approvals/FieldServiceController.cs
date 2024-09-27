using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.ApprovalHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVC_API.Controllers.Approvals
{
    public class FieldServiceController : Controller
    {
        // GET: FieldService
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]


        public string AssetAddReqHeader([FromForm] AssetAddReqHeaderIN inputParams)
        {
            dm.TraceService("AssetAddReqHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelAssetAddRequest", "sp_Approvals", UserID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<AssetAddReqHeaderOut> listHeader = new List<AssetAddReqHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["aah_img"].ToString();


                        if (img != "")
                        {
                            string[] ar = (dr["aah_img"].ToString().Replace("../", "")).Split(',');

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

                        listHeader.Add(new AssetAddReqHeaderOut
                        {
                            aah_ID = dr["aah_ID"].ToString(),
                            aah_ast_ID = dr["aah_ast_ID"].ToString(),
                            aah_slno = dr["aah_slno"].ToString(),
                            aah_Name = dr["aah_Name"].ToString(),
                            aah_rsn_ID = dr["aah_rsn_ID"].ToString(),
                            aah_Remarks = dr["aah_Remarks"].ToString(),
                            aah_cus_ID = dr["aah_cus_ID"].ToString(),
                            aah_udp_ID = dr["aah_udp_ID"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            Route = dr["Route"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            Image = imag,
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            aah_ArName = dr["aah_ArabicName"].ToString(),
                            aah_ArRemarks = dr["aah_ArabicRemarks"].ToString(),
                            ast_ArName = dr["ast_ArabicName"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
                            rsn_ArName = dr["rsn_NameArabic"].ToString(),


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
                dm.TraceService("AssetAddReqHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("AssetAddReqHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string AssetRemoveReqHeader([FromForm] AssetRemoveReqHeaderIn inputParams)
        {
            dm.TraceService("AssetRemoveReqHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelAssetRemoveRequest", "sp_Approvals", UserID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<AssetRemoveReqHeaderOut> listHeader = new List<AssetRemoveReqHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string imag = "";
                        string img = dr["arq_img"].ToString();


                        if (img != "")
                        {
                            string[] ar = (dr["arq_img"].ToString().Replace("../", "")).Split(',');

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

                        listHeader.Add(new AssetRemoveReqHeaderOut
                        {
                            arq_ID = dr["arq_ID"].ToString(),
                            arq_Remarks = dr["arq_Remarks"].ToString(),
                            arq_Status = dr["arq_Status"].ToString(),
                            ast_Code = dr["ast_Code"].ToString(),
                            ast_Name = dr["ast_Name"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            rsn_Type = dr["rsn_Type"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            atm_Code = dr["atm_Code"].ToString(),
                            atm_Name = dr["atm_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            Route = dr["Route"].ToString(),
                            arq_ast_ID = dr["arq_ast_ID"].ToString(),
                            arq_cus_ID = dr["arq_cus_ID"].ToString(),
                            arq_asc_ID = dr["arq_asc_ID"].ToString(),
                            Image = imag,
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            ast_ArName = dr["ast_ArabicName"].ToString(),
                            rsn_ArName = dr["rsn_NameArabic"].ToString(),
                            rsn_ArType = dr["rsn_TypeArabic"].ToString(),
                            cus_ArName = dr["cus_NameArabic"].ToString(),
                            atm_ArName = dr["atm_ArabicName"].ToString(),


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
                dm.TraceService("AssetRemoveReqHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("AssetRemoveReqHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string InvoiceApprovalHeader([FromForm] InvoiceApprovalHeaderIn inputParams)
        {
            dm.TraceService("InvoiceApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("ServiceApprovalHeader", "sp_Approvals", UserID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<InvoiceApprovalHeaderOut> listHeader = new List<InvoiceApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                      

                        listHeader.Add(new InvoiceApprovalHeaderOut
                        {
                            sah_ID = dr["sah_ID"].ToString(),
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            TransTime = dr["TransTime"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            sjh_Number = dr["sjh_Number"].ToString(),
                            snr_Code = dr["snr_Code"].ToString(),
                            Status = dr["Status"].ToString(),
                            sah_Total = dr["sah_Total"].ToString(),
                            sah_Discount = dr["sah_Discount"].ToString(),
                            sah_SubTotal = dr["sah_SubTotal"].ToString(),
                            sah_VAT = dr["sah_VAT"].ToString(),
                            sah_GrandTotal = dr["sah_GrandTotal"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID= dr["rot_ID"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()

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
                dm.TraceService("InvoiceApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("InvoiceApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string InvoiceApprovalDetails([FromForm] InvoiceApprovalDetailsIn inputParams)
        {
            dm.TraceService("InvoiceApprovalDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("ServiceApprovalDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<InvoiceApprovalDetailsOut> listHeader = new List<InvoiceApprovalDetailsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new InvoiceApprovalDetailsOut
                        {
                            sad_ID = dr["sad_ID"].ToString(),
                            prd_ID = dr["prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            sad_UOM = dr["sad_UOM"].ToString(),
                            sad_Qty = dr["sad_Qty"].ToString(),
                            sad_Price = dr["sad_Price"].ToString(),
                            sad_Discount = dr["sad_Discount"].ToString(),
                            sad_LineTotal = dr["sad_LineTotal"].ToString(),
                          


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
                dm.TraceService("InvoiceApprovalDetails  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("InvoiceApprovalDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string AssetAddReqHeaderApproval([FromForm] AssetAddReqHeaderApprovalIn inputParams)
        {
            dm.TraceService("AssetAddReqHeaderApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string SerialNum = inputParams.SerialNum == null ? "0" : inputParams.SerialNum;

            string[] arr = { UserID, SerialNum };
            DataTable dt = dm.loadList("ApproveAssetAddRequest", "sp_Approvals", ReqID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<AssetAddReqHeaderApprovalOut> listHeader = new List<AssetAddReqHeaderApprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {                      

                        listHeader.Add(new AssetAddReqHeaderApprovalOut
                        {
                            Status = dr["Status"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()

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
                dm.TraceService("AssetAddReqHeaderApproval  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("AssetAddReqHeaderApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string AssetAddReqHeaderReject([FromForm] AssetAddReqHeaderRejectIn inputParams)
        {
            dm.TraceService("AssetAddReqHeaderReject STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            string[] arr = { UserID };
            DataTable dt = dm.loadList("RejectAssetAddRequest", "sp_Approvals", ReqID.ToString(),arr);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<AssetAddReqHeaderRejectOut> listHeader = new List<AssetAddReqHeaderRejectOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new AssetAddReqHeaderRejectOut
                        {
                            Status = dr["Status"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()
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
                dm.TraceService("AssetAddReqHeaderReject  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("AssetAddReqHeaderReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }



        public string PostAssetRemovalReqApproval([FromForm] PostAssetRemovalReqApprovaldata inputParams)
        {
            dm.TraceService("PostAssetRemovalReqApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostAssetRemovalReqApprovaldatas> itemData = JsonConvert.DeserializeObject<List<PostAssetRemovalReqApprovaldatas>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostAssetRemovalReqApprovaldatas id in itemData)
                            {
                                string[] arr = { id.arq_ID.ToString(), id.asc_ID.ToString() };
                                string[] arrName = { "arq_ID", "asc_ID" };
                                dm.createNode(arr, arrName, writer);
                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        InputXml = sw.ToString();
                    }

                    try
                    {
                        string[] arr = { userID.ToString()};
                        DataTable dt = dm.loadList("ApproveAssetRemoveRequest", "sp_Approvals", InputXml.ToString(), arr);

                        List<PostAssetRemovalReqApprovalStatus> listStatus = new List<PostAssetRemovalReqApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostAssetRemovalReqApprovalStatus> listHeader = new List<PostAssetRemovalReqApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostAssetRemovalReqApprovalStatus
                                {

                                    Status = dr["Status"].ToString(),
                                    ArStatus = dr["ArStatus"].ToString()


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
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "NoDataSQL - " + ex.Message.ToString();
                    }

                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "NoDataSQL - " + ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }
            dm.TraceService("PostAssetRemovalReqApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }

        public string PostAssetRemovalReqReject([FromForm] PostAssetRemovalReqRejectdata inputParams)
        {
            dm.TraceService("PostAssetRemovalReqReject STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostAssetRemovalReqRejectdatas> itemData = JsonConvert.DeserializeObject<List<PostAssetRemovalReqRejectdatas>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostAssetRemovalReqRejectdatas id in itemData)
                            {
                                string[] arr = { id.arq_ID.ToString(), id.asc_ID.ToString() };
                                string[] arrName = { "arq_ID", "asc_ID" };
                                dm.createNode(arr, arrName, writer);
                            }

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                        }
                        InputXml = sw.ToString();
                    }

                    try
                    {
                        string[] arr = { userID.ToString() };
                        DataTable dt = dm.loadList("RejectAssetRemoveRequest", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<PostAssetRemovalReqRejectStatus> listStatus = new List<PostAssetRemovalReqRejectStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostAssetRemovalReqRejectStatus> listHeader = new List<PostAssetRemovalReqRejectStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostAssetRemovalReqRejectStatus
                                {

                                    Status = dr["Status"].ToString(),
                                    ArStatus = dr["ArStatus"].ToString()


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
                        dm.TraceService(ex.Message.ToString());
                        JSONString = "NoDataSQL - " + ex.Message.ToString();
                    }

                }
                catch (Exception ex)
                {
                    dm.TraceService(ex.Message.ToString());
                    JSONString = "NoDataSQL - " + ex.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }
            dm.TraceService("PostAssetRemovalReqReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }


        public string FieldServiceInvoiceApproval([FromForm] FieldServiceInvoiceApprovalIn inputParams)
        {
            dm.TraceService("FieldServiceInvoiceApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arrName = { UserID };
            DataTable dt = dm.loadList("ApproveServiceInvoice", "sp_Approvals", ReqID.ToString(), arrName);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<FieldServiceInvoiceApprovalOut> listHeader = new List<FieldServiceInvoiceApprovalOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new FieldServiceInvoiceApprovalOut
                        {
                            Status = dr["Status"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()





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
                dm.TraceService("FieldServiceInvoiceApproval  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("FieldServiceInvoiceApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string FieldServiceInvoiceReject([FromForm] FieldServiceInvoiceRejectIn inputParams)
        {
            dm.TraceService("FieldServiceInvoiceReject STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

            string url = ConfigurationManager.AppSettings.Get("BackendUrl");
            string[] arrName = { UserID };
            DataTable dt = dm.loadList("RejectServiceInvoiceRequest", "sp_Approvals", ReqID.ToString(), arrName);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<FieldServiceInvoiceRejectOut> listHeader = new List<FieldServiceInvoiceRejectOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new FieldServiceInvoiceRejectOut
                        {
                            Status = dr["Status"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()





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
                dm.TraceService("FieldServiceInvoiceReject  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("FieldServiceInvoiceReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }
}