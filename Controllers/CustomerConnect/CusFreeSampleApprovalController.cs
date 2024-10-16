using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using System.Xml;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using MVC_API.Models.ApprovalHelper;
using System.Net.NetworkInformation;

namespace MVC_API.Controllers.CustomerConnect
{
    public class CusFreeSampleApprovalController : Controller
    {
        // GET: CusFreeSampleApproval
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string GetFreeSampleApprovalHeader(CusFOCHeaderIn inputParams)

        {
            dm.TraceService("SelectFreeSampleHeaderList STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;
            DataTable dt = dm.loadList("ListCustomerFreeSampleHeader", "sp_CustomerConnect", Status_Value.ToString());
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCFreeSampleHeader> listHeader = new List<CCFreeSampleHeader>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new CCFreeSampleHeader
                        {
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            fsh_ID = dr["fsh_ID"].ToString(),
                            fshReqID = dr["fshReqID"].ToString(),
                            ModifiedBy = dr["ModifiedBy"].ToString(),
                            ModifiedDate = dr["ModifiedDate"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            ApprovalStatus = dr["ApprovalStatus"].ToString(),
                            CreatedBy = dr["CreatedBy"].ToString(),
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
                dm.TraceService("SelectFreeSampleHeaderList   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectFreeSampleHeaderList  ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string getFreeSampleDetailList(CusFOCDetlIn inputParams)
        {
            dm.TraceService("SelectCFOCList STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;

            DataTable dt = dm.loadList("ListCustomerFreeSampleDet", "sp_CustomerConnect", HeaderID.ToString());
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCFreeSampleDetail> listHeader = new List<CCFreeSampleDetail>();
                    foreach (DataRow dr in dt.Rows)
                    {


                        listHeader.Add(new CCFreeSampleDetail
                        {
                            fsa_ID = dr["fsa_ID"].ToString(),
                            fsa_prd_ID = dr["fsa_prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            HigherQty = dr["HigherQty"].ToString(),
                            HigherUOM = dr["HigherUOM"].ToString(),
                            LowerQty = dr["LowerQty"].ToString(),
                            LowerUOM = dr["LowerUOM"].ToString(),
                            ApprovalStatus = dr["ApprovalStatus"].ToString(),
                            CreatedBy = dr["CreatedBy"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            ModifiedBy = dr["ModifiedBy"].ToString(),
                            ModifiedDate = dr["ModifiedDate"].ToString(),
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
                dm.TraceService("SelectFreeSampleHeaderList   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectFreeSampleHeaderList  ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;

        }
        public string PostFreeSamplApproval([FromForm] CCFreeSampleApprovalIn inputParams)
        {
            dm.TraceService("PostFreeSamplApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {

                List<CCFreeSampleApprovalData> itemData = JsonConvert.DeserializeObject<List<CCFreeSampleApprovalData>>(inputParams.JSONString);
                try
                {
                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string HeaderID = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;


                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (CCFreeSampleApprovalData id in itemData)
                            {
                                string[] arr = { id.reasonId.ToString(), id.Status.ToString(), id.fsa_ID.ToString() };
                                string[] arrName = { "reasonId", "Status", "fsa_ID" };
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
                        string[] arr = { userID.ToString(), HeaderID.ToString() };
                        DataTable dt = dm.loadList("PostFreeSampleApproval", "sp_CustomerConnect", InputXml.ToString(), arr);

                        List<CCFreeSampleApprovalStatus> listStatus = new List<CCFreeSampleApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<CCFreeSampleApprovalStatus> listHeader = new List<CCFreeSampleApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new CCFreeSampleApprovalStatus
                                {
                                    Status = dr["Status"].ToString(),
                                    Res = dr["Res"].ToString(),

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
            dm.TraceService("PostFreeSamplApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetFreeSampleReason(CusReasonIn inputParams)
        {
            dm.TraceService("GetFreeSampleReason STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string ReasonType = inputParams.ReasonType == null ? "0" : inputParams.ReasonType;
            DataTable dt = dm.loadList("SelectReasonforApprovalReq", "sp_CustomerConnect", ReasonType.ToString());
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CusReasonOut> listHeader = new List<CusReasonOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusReasonOut
                        {
                            rsn_ID = dr["rsn_ID"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString()

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
                dm.TraceService("GetFreeSampleReason  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetFreeSampleReason ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        //--------------FOC---------------

        public string getFOCHeaderList(CusFOCHeaderIn inputParams)
        {
            dm.TraceService("SelectCFOCList STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;

            DataTable dt = dm.loadList("ListCustomerFOCApprovalHeaderCC", "sp_CustomerConnect", Status_Value.ToString());
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CCFOCApprovalHeaderOut> listHeader = new List<CCFOCApprovalHeaderOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCFOCApprovalHeaderOut
                        {
                            cus_Code = dr["cus_Code"].ToString(),
                            cus_Name = dr["cus_Name"].ToString(),
                            rot_Name = dr["rot_Name"].ToString(),
                            rot_Code = dr["rot_Code"].ToString(),
                            usr_Name = dr["usr_Name"].ToString(),
                            cfh_ID = dr["cfh_ID"].ToString(),
                            cfh_RtnId = dr["cfh_RtnId"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            CreatedBy = dr["CreatedBy"].ToString(),
                            ApprovalStatus = dr["ApprovalStatus"].ToString(),
                            ModifiedDate = dr["ModifiedDate"].ToString(),
                            ModifiedBy = dr["ModifiedBy"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),

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
                dm.TraceService("SelectCFOCList   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectCFOCList  ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string getFOCDetailList(CusFOCDetlIn inputParams)
        {
            dm.TraceService("SelectCFOCList STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string HeaderId = inputParams.HeaderID == null ? "0" : inputParams.HeaderID;
            DataTable dt = dm.loadList("ListCustomerFOCDet", "sp_CustomerConnect", HeaderId.ToString());
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CusFOCDetailOut> listHeader = new List<CusFOCDetailOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CusFOCDetailOut
                        {
                            cfa_ID = dr["cfa_ID"].ToString(),
                            cfa_prd_ID = dr["cfa_prd_ID"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString(),
                            cfa_TotalQty = dr["cfa_TotalQty"].ToString(),
                            cfa_BalanceQty = dr["cfa_BalanceQty"].ToString(),
                            CreatedBy = dr["CreatedBy"].ToString(),
                            ModifiedBy = dr["ModifiedBy"].ToString(),
                            ModifiedDate = dr["ModifiedDate"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            rsn_Name = dr["rsn_Name"].ToString(),
                            ApprovalStatus = dr["ApprovalStatus"].ToString(),
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
                dm.TraceService("SelectFreeSampleHeaderList   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectFreeSampleHeaderList  ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;




        }
        public string PostFOCApproval([FromForm] CCFOCApprovalIn inputParams)
        {
            dm.TraceService("PostFOCApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");

            try
            {
                string reasonId = inputParams.reasonId == null ? "0" : inputParams.reasonId;
                string cfh_ID = inputParams.cfh_ID == null ? "0" : inputParams.cfh_ID;
                string userId = inputParams.userId == null ? "0" : inputParams.userId;
                string[] arr = { cfh_ID.ToString(), userId.ToString() };
                DataTable dt = dm.loadList("PostFOCApproval", "sp_CustomerConnect", reasonId, arr);

                List<CCFreeSampleApprovalStatus> listStatus = new List<CCFreeSampleApprovalStatus>();
                if (dt.Rows.Count > 0)
                {
                    List<CCFreeSampleApprovalStatus> listHeader = new List<CCFreeSampleApprovalStatus>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCFreeSampleApprovalStatus
                        {
                            Status = dr["Status"].ToString(),
                            Res = dr["Res"].ToString(),

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

            dm.TraceService("PostFOCApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string PostFOCRejection([FromForm] CCFOCApprovalIn inputParams)
        {
            dm.TraceService("PostFOCRejection STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");

            try
            {
                string reasonId = inputParams.reasonId == null ? "0" : inputParams.reasonId;
                string cfh_ID = inputParams.cfh_ID == null ? "0" : inputParams.cfh_ID;
                string userId = inputParams.userId == null ? "0" : inputParams.userId;
                string[] arr = { cfh_ID.ToString(), userId.ToString() };
                DataTable dt = dm.loadList("PostFOCRejection", "sp_CustomerConnect", reasonId, arr);

                List<CCFreeSampleApprovalStatus> listStatus = new List<CCFreeSampleApprovalStatus>();
                if (dt.Rows.Count > 0)
                {
                    List<CCFreeSampleApprovalStatus> listHeader = new List<CCFreeSampleApprovalStatus>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listHeader.Add(new CCFreeSampleApprovalStatus
                        {
                            Status = dr["Status"].ToString(),
                            Res = dr["Res"].ToString(),

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

            dm.TraceService("PostFOCRejection ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;

        }

        //-----------------credit limit---------------
        public string InsOverrideOnlineApproval([FromForm] CusOverrideApprIn inputParams)
        {
            dm.TraceService("InsOverrideOnlineApproval STARTED -" + DateTime.Now.ToString());
            dm.TraceService("====================");
            try
            {
                string cse_ID = inputParams.cse_ID == null ? "0" : inputParams.cse_ID;
                string udp_ID = inputParams.udp_ID == null ? "0" : inputParams.udp_ID;
                string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;
                string Type = inputParams.Type == null ? "" : inputParams.Type;

                List<CusJsonDataOverride> itemData = JsonConvert.DeserializeObject<List<CusJsonDataOverride>>(inputParams.Json);

                string DetailXml = "";

                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {

                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("r");
                        int c = 0;
                        foreach (CusJsonDataOverride id in itemData)
                        {
                            string[] arr = { id.CrLmt.ToString(), id.AvlLmt.ToString(), id.TotLmt.ToString(), id.InvID.ToString(), id.OverDate.ToString(), id.CrDays.ToString() };
                            string[] arrName = { "CrLmt", "AvlLmt", "TotLmt", "InvID", "OverDate", "CrDays" };
                            dm.createNode(arr, arrName, writer);
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                    DetailXml = sw.ToString();
                }


                string[] ar = { udp_ID.ToString(), rot_ID.ToString(), cus_ID.ToString(), Type.ToString(), DetailXml.ToString() };
                DataTable dt = dm.loadList("InsOverrideApproval", "sp_OverrideOnline", cse_ID.ToString(), ar);


                if (dt.Rows.Count > 0)
                {
                    List<CusOverrideApprOut> listoutput = new List<CusOverrideApprOut>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        listoutput.Add(new CusOverrideApprOut
                        {
                            Res = dr["Res"].ToString(),
                            Title = dr["Title"].ToString(),
                            Descr = dr["Descr"].ToString(),
                            TransID = dr["TransID"].ToString()


                        });
                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listoutput
                    });

                    return JSONString;
                }
                else
                {
                    JSONString = "NoDataRes";
                    dm.TraceService("NoDataRes");
                }
            }
            catch (Exception ex)
            {
                JSONString = "NoDataSQL - " + ex.Message.ToString();
                dm.TraceService(" InsOverrideOnlineApproval Exception - " + ex.Message.ToString());
                dm.TraceService(ex.Message.ToString());
            }
            dm.TraceService("InsOverrideOnlineApproval ENDED - " + DateTime.Now.ToString());
            dm.TraceService("==================");
            return JSONString;
        }
        public string GetOverrideApprDetailStatus([FromForm] CusGetOverrideApprDetailStatusIn inputParams)
        {
            dm.TraceService("GetOverrideApprDetailStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string TransID = inputParams.TransID == null ? "0" : inputParams.TransID;
            string rotID = inputParams.rotID == null ? "0" : inputParams.rotID;

            string[] arr = { rotID.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelStatusForOverrideApprDetail", "sp_OverrideOnline", TransID.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<CusGetOverrideApprDetailStatusOut> listHeader = new List<CusGetOverrideApprDetailStatusOut>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new CusGetOverrideApprDetailStatusOut
                        {
                            HeaderStatus = dr["ooh_ApprovalStatus"].ToString(),
                            DetailStatus = dr["ood_ApprovalStatus"].ToString()

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

            dm.TraceService("GetOverrideApprDetailStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        //public string GetOverRideHeader(CusOverrideHeader inputParams)
        //{

        //    dm.TraceService("SelectCFOCList STARTED " + DateTime.Now.ToString());
        //    dm.TraceService("======================================");
        //    string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;

        //    DataTable dt = dm.loadList("ListOverRideCC", "sp_CustomerConnect", Status_Value.ToString());
        //    try
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            List<CCFOCApprovalHeaderOut> listHeader = new List<CCFOCApprovalHeaderOut>();
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                listHeader.Add(new CCFOCApprovalHeaderOut
        //                {
        //                    cus_Code = dr["cus_Code"].ToString(),
        //                    cus_Name = dr["cus_Name"].ToString(),
        //                    rot_Name = dr["rot_Name"].ToString(),
        //                    rot_Code = dr["rot_Code"].ToString(),
        //                    usr_Name = dr["usr_Name"].ToString(),
        //                    cfh_ID = dr["cfh_ID"].ToString(),
        //                    cfh_RtnId = dr["cfh_RtnId"].ToString(),
        //                    CreatedDate = dr["CreatedDate"].ToString(),
        //                    CreatedBy = dr["CreatedBy"].ToString(),
        //                    ApprovalStatus = dr["ApprovalStatus"].ToString(),
        //                    ModifiedDate = dr["ModifiedDate"].ToString(),
        //                    ModifiedBy = dr["ModifiedBy"].ToString(),
        //                    rsn_Name = dr["rsn_Name"].ToString(),

        //                });
        //            }

        //            JSONString = JsonConvert.SerializeObject(new
        //            {
        //                result = listHeader
        //            });

        //            return JSONString;
        //        }
        //        else
        //        {
        //            dm.TraceService("NoDataRes");
        //            JSONString = "NoDataRes";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dm.TraceService("SelectCFOCList   " + ex.Message.ToString());
        //        JSONString = "NoDataSQL - " + ex.Message.ToString();
        //    }

        //    dm.TraceService("SelectCFOCList  ENDED " + DateTime.Now.ToString());
        //    dm.TraceService("======================================");

        //    return JSONString;
        //}


    }




}
