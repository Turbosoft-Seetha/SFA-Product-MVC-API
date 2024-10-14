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

namespace MVC_API.Controllers.CustomerConnect
{
    public class CusFreeSampleApprovalController : Controller
    {
        // GET: CusFreeSampleApproval
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        public string PostFreeSampleApproval([FromForm] CusPostfreeSampleData inputParams)
        {
            dm.TraceService("PostReturnFreeSampleApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<CusPostFreeSamplelDetData> itemData = JsonConvert.DeserializeObject<List<CusPostFreeSamplelDetData>>(inputParams.JSONString);
                try
                {

                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string CusId = inputParams.CusId == null ? "0" : inputParams.CusId;
                    string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
                    string UdpId = inputParams.UdpId == null ? "0" : inputParams.UdpId;
                    string OrderId = inputParams.OrderID == null ? "0" : inputParams.OrderID;

                    //string Status = inputParams.Status == null ? "" : inputParams.Status;
                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {
                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            foreach (CusPostFreeSamplelDetData id in itemData)
                            {
                                string[] arr = { id.PrdID.ToString(), id.HigherQty.ToString(), id.HigherUOM.ToString(), id.LowerQty.ToString(), id.LowerUOM.ToString() };
                                string[] arrName = { "PrdID", "HigherQty", "HigherUOM", "LowerQty", "LowerUOM" };
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
                        string[] arr = { CusId.ToString(), RotId.ToString(), UdpId.ToString(), OrderId.ToString(), InputXml.ToString() };
                        DataTable dt = dm.loadList("FreeSampleApproval", "sp_SFA_App_Sales", userID.ToString(), arr);

                        List<CusGetFreeSampleApprovalStatus> listStatus = new List<CusGetFreeSampleApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<CusGetFreeSampleApprovalStatus> listHeader = new List<CusGetFreeSampleApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new CusGetFreeSampleApprovalStatus
                                {
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    Descr = dr["Descr"].ToString(),
                                    ReturnId = dr["ReturnId"].ToString(),
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
            dm.TraceService("PostReturnFreeSampleApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetFreeSampleApprovalHeaderStatus([FromForm] CusGetFreeHeaderStatus inputParams)
        {
            dm.TraceService("GetFreeSampleApprovalheaderStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string cusId = inputParams.CusId == null ? "0" : inputParams.CusId;
            string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
            string ReturnId = inputParams.ReturnId == null ? "0" : inputParams.ReturnId;

            string[] arr = { RotId.ToString(), ReturnId.ToString() };
            DataTable dtStatus = dm.loadList("SelFreeSampleHeaderApproval", "sp_SFA_App_Sales", cusId.ToString(), arr);

            try
            {
                if (dtStatus.Rows.Count > 0)
                {
                    List<CusGetHeaderStatus> listHeader = new List<CusGetHeaderStatus>();
                    foreach (DataRow dr in dtStatus.Rows)
                    {
                        listHeader.Add(new CusGetHeaderStatus
                        {
                            ApprovalStatus = dr["Status"].ToString()

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
                dm.TraceService("GetFreeSampleApprovalheaderStatus  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("GetFreeSampleApprovalheaderStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }
        public string GetFreeSampleApprovalDetailStatus([FromForm] CusGetFreeHeaderStatus inputParams)
        {
            dm.TraceService("GetFreeSampleApprovalDetailStatus STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string cusId = inputParams.CusId == null ? "0" : inputParams.CusId;
            string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
            string ReturnId = inputParams.ReturnId == null ? "0" : inputParams.ReturnId;
            string[] arr = { RotId.ToString(), ReturnId.ToString() };
            DataTable dtReturnStatus = dm.loadList("SelFreeSampleDetApproval", "sp_SFA_App_Sales", cusId.ToString(), arr);

            try
            {
                if (dtReturnStatus.Rows.Count > 0)
                {
                    List<CusGetDetFreeSapmpleApprovalStatus> listHeader = new List<CusGetDetFreeSapmpleApprovalStatus>();
                    foreach (DataRow dr in dtReturnStatus.Rows)
                    {
                        listHeader.Add(new CusGetDetFreeSapmpleApprovalStatus
                        {
                            ApprovalStatus = dr["Status"].ToString(),
                            ProductId = dr["fsa_prd_ID"].ToString(),
                            ReasonID = dr["fsa_approvalReasonId"].ToString(),

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

            dm.TraceService("GetFreeSampleApprovalDetailStatus ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

        //--------------FOC---------------
        public string PostCustomerFOCApproval([FromForm] CusPostCustomerFOC inputParams)
        {
            dm.TraceService("PostCustomerFOCApproval STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<CusPostCustomerFOCApprovalDetData> itemData = JsonConvert.DeserializeObject<List<CusPostCustomerFOCApprovalDetData>>(inputParams.JSONString);
                try
                {

                    string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
                    string CusId = inputParams.CusId == null ? "0" : inputParams.CusId;
                    string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
                    string FromDate = inputParams.FromDate == null ? "0" : inputParams.FromDate;
                    string ToDate = inputParams.ToDate == null ? "0" : inputParams.ToDate;
                    string Commend = inputParams.Commend == null ? "" : inputParams.Commend;
                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {
                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            foreach (CusPostCustomerFOCApprovalDetData id in itemData)
                            {
                                string[] arr = { id.prdID.ToString(), id.HUOM.ToString(), id.HQty.ToString(), id.LUOM.ToString(), id.LQty.ToString(), id.totalqty.ToString() };
                                string[] arrName = { "prdID", "HUOM", "HQty", "LUOM", "LQty", "totalqty" };
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
                        string[] arr = { CusId.ToString(), FromDate.ToString(), ToDate.ToString(), userID.ToString(), Commend, InputXml.ToString() };
                        DataTable dt = dm.loadList("InsertFOCApp", "sp_Masters_UOM", RotId.ToString(), arr);

                        List<CusGetFOCApprovalStatus> listStatus = new List<CusGetFOCApprovalStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<CusGetFOCApprovalStatus> listHeader = new List<CusGetFOCApprovalStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new CusGetFOCApprovalStatus
                                {
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    Descr = dr["Descr"].ToString(),
                                    //ReturnId = dr["ReturnId"].ToString(),
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
            dm.TraceService("PostCustomerFOCApproval ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string GetFOCList([FromForm] CusFOCDetailIn inputParams)
        {
            dm.TraceService("SelectCFOCList STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");
            string CusId = inputParams.CusId == null ? "0" : inputParams.CusId;
            string userID = inputParams.UserId == null ? "0" : inputParams.UserId;
            string RotId = inputParams.RotId == null ? "0" : inputParams.RotId;
            string[] arr = { RotId, CusId };
            DataSet dt = dm.loadListDS("SelFOCList", "sp_Masters_UOM", userID, arr);
            DataTable headerData = dt.Tables[0];

            DataTable DetailData = dt.Tables[1];
            try
            {
                if (headerData.Rows.Count > 0)
                {
                    List<CusFOCList> listDetail = new List<CusFOCList>();
                    foreach (DataRow dr in headerData.Rows)
                    {
                        List<CusFOCApproveDetail> FOCDetail = new List<CusFOCApproveDetail>();
                        foreach (DataRow dts in DetailData.Rows)
                        {
                            if (dr["cfh_ID"].ToString() == dts["cfa_cfh_ID"].ToString())
                            {
                                FOCDetail.Add(new CusFOCApproveDetail
                                {
                                    prdID = dts["prdID"].ToString(),
                                    HUOM = dts["HUOM"].ToString(),
                                    HQty = dts["HQty"].ToString(),
                                    LUOM = dts["LUOM"].ToString(),
                                    LQty = dts["LQty"].ToString(),
                                    totalqty = dts["totalqty"].ToString()
                                });
                            }
                        }
                        listDetail.Add(new CusFOCList
                        {

                            HeaderId = dr["HeaderId"].ToString(),
                            FromDate = dr["FromDate"].ToString(),
                            ToDate = dr["ToDate"].ToString(),
                            Commend = dr["Commend"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            FOCListDetail = FOCDetail,
                        });

                    }
                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listDetail
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
                dm.TraceService("SelectCFOCList - Error :   " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("SelectCFOCList ENDED ");
            dm.TraceService("======================================");

            return JSONString;

        }


        //-----------------credit limit---------------
        public string CancelDelOrder([FromForm] CusCancelDelOrderInparas inputParams)
        {
            dm.TraceService("CancelDelOrder STARTED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            string Status_Value = inputParams.Status_Value == null ? "0" : inputParams.Status_Value;
            string OrdId = inputParams.OrdId == null ? "0" : inputParams.OrdId;
            string UserId = inputParams.UserId == null ? "0" : inputParams.UserId;

            string[] arr = { Status_Value, UserId };

            DataTable dt = dm.loadList("CancelDelOrders", "sp_SFA_App", OrdId, arr);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    List<CusCancelDelOrderOutparas> list = new List<CusCancelDelOrderOutparas>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new CusCancelDelOrderOutparas
                        {
                            Res = dr["Res"].ToString(),
                            Desc = dr["Desc"].ToString(),

                        });
                    }

                    JSONString = JsonConvert.SerializeObject(new
                    {
                        result = list
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
                dm.TraceService("GetUnAssigned  " + ex.Message.ToString());
                JSONString = "NoDataSQL - " + ex.Message.ToString();
            }

            dm.TraceService("CancelDelOrder ENDED " + DateTime.Now.ToString());
            dm.TraceService("======================================");

            return JSONString;
        }

    }
}