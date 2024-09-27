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
    public class InventoryApprovalController : Controller
    {
        // GET: InventoryApproval
        // GET: FieldService
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]


        public string VantoVanApprovalHeader([FromForm] VantoVanApprovalHeaderIn inputParams)
        {
            dm.TraceService("VantoVanApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("SelVanToVanHeaderapproval", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<VantoVanApprovalHeaderOut> listHeader = new List<VantoVanApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                       

                        listHeader.Add(new VantoVanApprovalHeaderOut
                        {
                            vvh_ID = dr["vvh_ID"].ToString(),
                            vvh_TransID = dr["vvh_TransID"].ToString(),
                            vvh_FromRot = dr["vvh_FromRot"].ToString(),
                            vvh_ToRot = dr["vvh_ToRot"].ToString(),
                            Status = dr["Status"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Approval_Status = dr["Approval_Status"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            ArStatus = dr["ArStatus"].ToString(),
                            Approval_ArStatus = dr["Approval_ArStatus"].ToString()



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
                dm.TraceService("VantoVanApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("VantoVanApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string VantoVanApprovalDetails([FromForm] VantoVanApprovalDetailsIn inputParams)
        {
            dm.TraceService("VantoVanApprovalDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("SelectVanToVanDetailapproval", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<VantoVanApprovalDetailsOut> listHeader = new List<VantoVanApprovalDetailsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new VantoVanApprovalDetailsOut
                        {
                            vvd_ID = dr["vvd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            vvd_HUOM = dr["vvd_HUOM"].ToString(),
                            vvd_LUOM = dr["vvd_LUOM"].ToString(),
                            vvd_HQty = dr["vvd_HQty"].ToString(),
                            vvd_LQty = dr["vvd_LQty"].ToString(),
                            vvd_ConfirmHQty = dr["vvd_ConfirmHQty"].ToString(),
                            vvd_ConfirmLQty = dr["vvd_ConfirmLQty"].ToString(),
                            vvd_ConfirmHUOM = dr["vvd_ConfirmHUOM"].ToString(),
                            vvd_ConfirmLUOM = dr["vvd_ConfirmLUOM"].ToString(),
                            AdjHQty = dr["AdjHQty"].ToString(),
                            AdjLQty = dr["AdjLQty"].ToString(),
                            Status = dr["Status"].ToString(),
                            prd_ArName = dr["prd_NameArabic"].ToString(),
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
                dm.TraceService("VantoVanApprovalDetails  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("VantoVanApprovalDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string MaterialReqHeader([FromForm] MaterialReqHeaderIN inputParams)
        {
            dm.TraceService("MaterialReqHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListMRApprovalHeader", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<MaterialReqHeaderOut> listHeader = new List<MaterialReqHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new MaterialReqHeaderOut
                        {
                            mrh_ID = dr["mrh_ID"].ToString(),
                            mrh_Number = dr["mrh_Number"].ToString(),
                            mrh_str_ID = dr["mrh_str_ID"].ToString(),
                            str_Name = dr["str_Name"].ToString(),
                            mrh_war_ID = dr["mrh_war_ID"].ToString(),
                            war_Name = dr["war_Name"].ToString(),
                            mrh_ExpDate = dr["mrh_ExpDate"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            mrh_Remarks = dr["mrh_Remarks"].ToString(),
                            mrh_Status = dr["mrh_Status"].ToString(),
                            Status = dr["Status"].ToString(),
                            mrh_IsReOrder = dr["mrh_IsReOrder"].ToString(),
                            mrh_IntegrationStatus = dr["mrh_IntegrationStatus"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            str_ArName = dr["str_ArabicName"].ToString(),
                            war_ArName = dr["war_ArabicName"].ToString(),
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
                dm.TraceService("MaterialReqHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("MaterialReqHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string MaterialReqDetails([FromForm] MaterialReqDetailsIn inputParams)
        {
            dm.TraceService("MaterialReqDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            DataTable dt = dm.loadList("ListMRApprovalDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<MaterialReqDetailsOut> listHeader = new List<MaterialReqDetailsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new MaterialReqDetailsOut
                        {
                            mrd_ID = dr["mrd_ID"].ToString(),
                            mrd_mrh_ID = dr["mrd_mrh_ID"].ToString(),
                            prd_ID = dr["prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            ReqHUOM = dr["ReqHUOM"].ToString(),
                            ReqLUOM = dr["ReqLUOM"].ToString(),
                            RequestedHQty = dr["RequestedHQty"].ToString(),
                            RequestedLQty = dr["RequestedLQty"].ToString(),
                            AdjustedHQty = dr["AdjustedHQty"].ToString(),
                            AdjustedLQty = dr["AdjustedLQty"].ToString(),
                            Arprd_Name = dr["prd_NameArabic"].ToString(),
                            ArReqHUOM = dr["ArReqHUOM"].ToString(),
                            ArReqLUOM = dr["ArReqLUOM"].ToString(),




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
                dm.TraceService("MaterialReqDetails  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("MaterialReqDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string PostVanToVanApproval([FromForm] PostVanToVanApprovalData inputParams)
        {
            dm.TraceService("PostAssetRemovalReqApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostVanToVanApprovalDatas> itemData = JsonConvert.DeserializeObject<List<PostVanToVanApprovalDatas>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostVanToVanApprovalDatas id in itemData)
                            {
                                string[] arr = { id.vvd_ID.ToString(), id.HQTY.ToString(), id.LQTY.ToString(),id.Status.ToString() };
                                string[] arrName = { "vvd_ID", "HQTY", "LQTY", "Status" };
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
                        string[] arr = { userID.ToString(), ReqID.ToString() };
                        DataTable dt = dm.loadList("VantoToVanReqApproval", "sp_Approvals", InputXml.ToString(), arr);

                        List<PostVanToVanApprovalStatus> listStatus = new List<PostVanToVanApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostVanToVanApprovalStatus> listHeader = new List<PostVanToVanApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostVanToVanApprovalStatus
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



        public string LoadTranferApprovalHeader([FromForm] LoadTranferApprovalHeaderIn inputParams)
        {
            dm.TraceService("LoadTranferApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("ListLoadTransferApprovalHeader", "sp_Approvals", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<LoadTranferApprovalHeaderOut> listHeader = new List<LoadTranferApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new LoadTranferApprovalHeaderOut
                        {
                            ltr_ID = dr["ltr_ID"].ToString(),
                            ltr_reqNo = dr["ltr_reqNo"].ToString(),
                            ltr_usr_ID = dr["ltr_usr_ID"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            ltr_rot_ID = dr["ltr_rot_ID"].ToString(),
                            ltr_Type = dr["ltr_Type"].ToString(),
                            ltr_Remarks = dr["ltr_Remarks"].ToString(),
                            ltr_ApprovalStatus = dr["ltr_ApprovalStatus"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            usr_ArName = dr["usr_ArabicName"].ToString(),
                            ltr_ArApprovalStatus = dr["ltr_ArApprovalStatus"].ToString()



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
                dm.TraceService("LoadTranferApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("LoadTranferApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        public string LoadTranferApprovalDetails([FromForm] LoadTranferApprovalDetailsIn inputParams)
        {
            dm.TraceService("LoadTranferApprovalDetails STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
            string url = ConfigurationManager.AppSettings.Get("BackendUrl");

            DataTable dt = dm.loadList("LisLoadTransferReqApprovalDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<LoadTranferApprovalDetailsOut> listHeader = new List<LoadTranferApprovalDetailsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new LoadTranferApprovalDetailsOut
                        {
                            ldr_ID = dr["ldr_ID"].ToString(),
                            ldr_prd_ID = dr["ldr_prd_ID"].ToString(),
                            ldr_CurrentStockHQty = dr["ldr_CurrentStockHQty"].ToString(),
                            ldr_CurrentStockLQty = dr["ldr_CurrentStockLQty"].ToString(),
                            ldr_BalanceHQty = dr["ldr_BalanceHQty"].ToString(),
                            ldr_BalanceLQty = dr["ldr_BalanceLQty"].ToString(),
                            ldr_OffloadHQty = dr["ldr_OffloadHQty"].ToString(),
                            ldr_OffloadLQty = dr["ldr_OffloadLQty"].ToString(),
                            ldr_HigherPrice = dr["ldr_HigherPrice"].ToString(),
                            ldr_LowerPrice = dr["ldr_LowerPrice"].ToString(),
                            ldr_CurrentStockHUOM = dr["ldr_CurrentStockHUOM"].ToString(),
                            ldr_CurrentStockLUOM = dr["ldr_CurrentStockLUOM"].ToString(),
                            ldr_BalanceHUOM = dr["ldr_BalanceHUOM"].ToString(),
                            ldr_OffloadHUOM = dr["ldr_OffloadHUOM"].ToString(),
                            ldr_OffloadLUOM = dr["ldr_OffloadLUOM"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            prd_ArName = dr["prd_NameArabic"].ToString(),
                            Status = dr["ldr_ApprovalStatus"].ToString(),




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
                dm.TraceService("LoadTranferApprovalDetails  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("LoadTranferApprovalDetails ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }


        public string PostLoadTranferApproval([FromForm] PostLoadTranferApprovalData inputParams)
        {
            dm.TraceService("PostLoadTranferApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostLoadTranferApprovalDataS> itemData = JsonConvert.DeserializeObject<List<PostLoadTranferApprovalDataS>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostLoadTranferApprovalDataS id in itemData)
                            {
                                string[] arr = {  id.ldr_ID.ToString(), id.Status.ToString() };
                                string[] arrName = { "ldr_ID", "Status" };
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
                        string[] arr = { userID.ToString(), ReqID.ToString() };
                        DataTable dt = dm.loadList("LoadTransferReqApproval", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<PostLoadTranferApprovalStatus> listStatus = new List<PostLoadTranferApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostLoadTranferApprovalStatus> listHeader = new List<PostLoadTranferApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostLoadTranferApprovalStatus
                                {
                                    Status = dr["Status"].ToString(),
                                    Res = dr["Res"].ToString(),
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
            dm.TraceService("PostLoadTranferApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }



        public string LoadRequestApprovalHeader([FromForm] LoadRequestApprovalHeaderIN inputParams)
        {
            dm.TraceService("LoadRequestApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            //  string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;


            DataTable dt = dm.loadList("SelLoadRequestsHeader", "sp_MerchandisingWebServices", Status_Value.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<LoadRequestApprovalHeaderOut> listHeader = new List<LoadRequestApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new LoadRequestApprovalHeaderOut
                        {
                            lrh_ID = dr["lrh_ID"].ToString(),
                            lrh_Number = dr["lrh_Number"].ToString(),
                            lrh_usr_ID = dr["lrh_usr_ID"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            usr_ArabicName = dr["usr_ArabicName"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            lrh_LoadReqDate = dr["lrh_LoadReqDate"].ToString(),
                            lrh_udp_ID = dr["lrh_udp_ID"].ToString(),
                            Status = dr["Status"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            rot_ArabicName = dr["rot_ArabicName"].ToString(),
                            lrh_Remarks = dr["lrh_Remarks"].ToString(),
                            StagingIntegStatus = dr["StagingIntegStatus"].ToString(),
                            StagingIntegRemarks = dr["StagingIntegRemarks"].ToString(),
                            StagingIntegTime = dr["StagingIntegTime"].ToString(),
                            UserID = dr["UserID"].ToString(),
                            rotID = dr["rot_ID"].ToString(),
                            ArStatus = dr["ArStatus"].ToString(),


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
                dm.TraceService("LoadRequestApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("LoadRequestApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }




        public string LoadRequestApprovalDetails([FromForm] LoadRequestApprovalDetailsIN inputParams)
        {
            dm.TraceService("LoadRequestApprovalHeader STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;

            DataTable dt = dm.loadList("selLoadRequestDetail", "sp_Approvals", ReqID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<LoadRequestApprovalDetailsOut> listHeader = new List<LoadRequestApprovalDetailsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new LoadRequestApprovalDetailsOut
                        {
                            lrd_ID = dr["lrd_ID"].ToString(),
                            lrd_prd_ID = dr["lrd_prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            lrd_HQty = dr["lrd_HQty"].ToString(),
                            lrd_LQty = dr["lrd_LQty"].ToString(),
                            prd_NameArabic = dr["prd_NameArabic"].ToString(),
                            lrd_LUOM = dr["lrd_LUOM"].ToString(),
                            lrd_HUOM = dr["lrd_HUOM"].ToString(),
                            lrd_totalQty = dr["lrd_totalQty"].ToString(),
                            lrd_apv_HQty = dr["lrd_apv_HQty"].ToString(),
                            lrd_apv_LQty = dr["lrd_apv_LQty"].ToString(),
                            lrd_apv_HUOM = dr["lrd_apv_HUOM"].ToString(),
                            lrd_apv_LUOM = dr["lrd_apv_LUOM"].ToString(),
                            lrd_apv_totalQty = dr["lrd_apv_totalQty"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString()



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
                dm.TraceService("LoadRequestApprovalHeader  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("LoadRequestApprovalHeader ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }



        public string PostLoadReqApproval([FromForm] PostLoadReqApprovalData inputParams)
        {
            dm.TraceService("PostAssetRemovalReqApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostLoadReqApprovalDatas> itemData = JsonConvert.DeserializeObject<List<PostLoadReqApprovalDatas>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string RotID = inputParams.RotID == null ? "0" : inputParams.RotID;
                    string Status = inputParams.Status == null ? "0" : inputParams.Status;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostLoadReqApprovalDatas id in itemData)
                            {
                                string[] arr = { id.lrd_prd_ID.ToString(), id.lrd_HQty.ToString(), id.lrd_LQty.ToString(), id.lrd_LUOM.ToString() , id.lrd_HUOM.ToString(), id.lrd_totalQty.ToString() , id.txt_apv_HQty.ToString(), id.txt_apv_LQty.ToString() , id.lrd_ID.ToString() };
                                string[] arrName = { "lrd_prd_ID", "lrd_HQty", "lrd_LQty", "lrd_LUOM", "lrd_HUOM", "lrd_totalQty", "txt_apv_HQty", "txt_apv_LQty", "lrd_ID" };
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
                        string[] arr = { ReqID.ToString(), userID.ToString(), RotID.ToString(), Status.ToString() };
                        DataTable dt = dm.loadList("UpdateLoadReqDetail", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<PostLoadReqApprovalStatus> listStatus = new List<PostLoadReqApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostLoadReqApprovalStatus> listHeader = new List<PostLoadReqApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostLoadReqApprovalStatus
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


        public string PostMaterialReqApproval([FromForm] PostMaterialReqApprovalData inputParams)
        {
            dm.TraceService("PostMaterialReqApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostMaterialReqApprovalDatas> itemData = JsonConvert.DeserializeObject<List<PostMaterialReqApprovalDatas>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string Mode = inputParams.Mode == null ? "0" : inputParams.Mode;
                    string Warehouse = inputParams.Warehouse == null ? "0" : inputParams.Warehouse;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostMaterialReqApprovalDatas id in itemData)
                            {
                                string[] arr = { id.mrd_ID.ToString(), id.prd_ID.ToString(), id.ReqHUOM.ToString(), id.ReqLUOM.ToString(), id.RequestedHQty.ToString(), id.RequestedLQty.ToString(), id.HQTY.ToString(), id.LQTY.ToString() };
                                string[] arrName = { "mrd_ID", "prd_ID", "ReqHUOM", "ReqLUOM", "RequestedHQty", "RequestedLQty", "HQTY", "LQTY" };
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
                        string[] arr = { userID.ToString(), ReqID.ToString(), Mode.ToString(),Warehouse.ToString() };
                        DataTable dt = dm.loadList("MRApproval", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<PostMaterialReqApprovalStatus> listStatus = new List<PostMaterialReqApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostMaterialReqApprovalStatus> listHeader = new List<PostMaterialReqApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostMaterialReqApprovalStatus
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
            dm.TraceService("PostMaterialReqApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }


        public string PostMaterialReqReject([FromForm] PostMaterialReqRejectData inputParams)
        {
            dm.TraceService("PostMaterialReqReject STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<PostMaterialReqRejectDatas> itemData = JsonConvert.DeserializeObject<List<PostMaterialReqRejectDatas>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string ReqID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                    string Remark = inputParams.Remark == null ? "0" : inputParams.Remark;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (PostMaterialReqRejectDatas id in itemData)
                            {
                                string[] arr = { id.mrd_ID.ToString(), id.prd_ID.ToString(), id.ReqHUOM.ToString(), id.ReqLUOM.ToString(), id.RequestedHQty.ToString(), id.RequestedLQty.ToString(), id.HQTY.ToString(), id.LQTY.ToString() };
                                string[] arrName = { "mrd_ID", "prd_ID", "ReqHUOM", "ReqLUOM", "RequestedHQty", "RequestedLQty", "HQTY", "LQTY" };
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
                        string[] arr = {  ReqID.ToString(),userID.ToString(), Remark.ToString() };
                        DataTable dt = dm.loadList("RejectMR", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<PostMaterialReqRejectStatus> listStatus = new List<PostMaterialReqRejectStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<PostMaterialReqRejectStatus> listHeader = new List<PostMaterialReqRejectStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new PostMaterialReqRejectStatus
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
            dm.TraceService("PostMaterialReqReject ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }




        public string Warehouse([FromForm] WarehouseIn inputParams)
        {
            dm.TraceService("Warehouse STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string mrh_str_ID = inputParams.mrh_str_ID == null ? "0" : inputParams.mrh_str_ID;

            DataTable dt = dm.loadList("SelectWareHouse", "sp_Approvals", mrh_str_ID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<WarehouseOut> listHeader = new List<WarehouseOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new WarehouseOut
                        {
                            war_ID = dr["war_ID"].ToString(),
                            war_Name = dr["war_Name"].ToString()
                          





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
                dm.TraceService("Warehouse  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("Warehouse ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }



      




        public string SelectPendingStatusCounts([FromForm] SelectPendingStatusCountsIN inputParams)
        {
            dm.TraceService("SelectPendingStatusCounts STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

            DataTable dt = dm.loadList("SelectPendingStatus", "sp_Approvals", UserID.ToString());

            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<SelectPendingStatusCountsOut> listHeader = new List<SelectPendingStatusCountsOut>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new SelectPendingStatusCountsOut
                        {
                            PendingReturnHeader = dr["PendingReturnHeader"].ToString(),
                            PendingPriceChangeApproval = dr["PendingPriceChangeApproval"].ToString(),
                            PendingJurneyPlanSeqApprvl = dr["PendingJurneyPlanSeqApprvl"].ToString(),
                            PendingVanToVanHeader = dr["PendingVanToVanHeader"].ToString(),
                            PendingMaterialReqApproval = dr["PendingMaterialReqApproval"].ToString(),
                            PendingLodTransRequest = dr["PendingLodTransRequest"].ToString(),
                            PendingLoadRequestHeader = dr["PendingLoadRequestHeader"].ToString(),
                            PendingAssetAddReqHeader = dr["PendingAssetAddReqHeader"].ToString(),
                            PendingAssetRemovalReqHeader = dr["PendingAssetRemovalReqHeader"].ToString(),
                            PendingInvoiceApprovalHeader = dr["PendingInvoiceApprovalHeader"].ToString(),
                            PendingDisputeNoteReqHeader = dr["PendingDisputeNoteReqHeader"].ToString(),
                            PendingCreditNoteReqHeader = dr["PendingCreditNoteReqHeader"].ToString(),
                            PendingPartialDeliveryHeader = dr["PendingPartialDeliveryHeader"].ToString(),
                            PendingReturnRequestSC = dr["PendingReturnRequestSC"].ToString(),
                            PendingInvReconfirm = dr["PendingInvReconfirm"].ToString(),
                            SettlementApprovalHeader = dr["PendingSettlement"].ToString(),
                            VoidTransactionHeader = dr["PendingVoidTransaction"].ToString(),
                            MustSellHeader = dr["PendingMustSell"].ToString(),
                            UnschVisit = dr["PendingUnschVisit"].ToString()


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
                dm.TraceService("SelectPendingStatusCounts  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectPendingStatusCounts ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }
}