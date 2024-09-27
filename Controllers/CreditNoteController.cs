using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MVC_API.Controllers
{
    public class CreditNoteController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [System.Web.Http.HttpPost]
        public string GetCustomerInvoice([FromForm] CusInvInparam inputParams)
        {
            try
            {
                string cusid = inputParams.cusid == null ? "0" : inputParams.cusid;
                dm.TraceService("==========GetCustomerInvoice Started==========");
                string[] arr = { inputParams.prdID };
                DataTable CI = dm.loadList("SelCuswiseInvoices", "sp_AppServices", cusid.ToString(),arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<CusInvOutparam> listItems = new List<CusInvOutparam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new CusInvOutparam
                        {
                            InvID = dr["InvID"].ToString(),
                            InvNo = dr["InvNo"].ToString()
                            
                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========GetCustomerInvoice End==========");
            return JSONString;
        }
        public string GetInvoicewiseItems([FromForm] InvitmsInparam inputParams)
        {
            try
            {
                string Invid = inputParams.Invid == null ? "0" : inputParams.Invid;
                string cusid= inputParams.cusid == null ? "0" : inputParams.cusid;
                dm.TraceService("==========GetInvoicewiseItems Started==========");
                DataTable CI = dm.loadList("SelInvwiseItems", "sp_AppServices", cusid.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<InvitmsOutparam> listItems = new List<InvitmsOutparam>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new InvitmsOutparam
                        {
                            prdid = dr["prdid"].ToString(),
                            prd_Code = dr["prd_Code"].ToString(),
                            prd_Name = dr["prd_Name"].ToString()

                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========GetInvoicewiseItems End==========");
            return JSONString;
        }
        public string GetInvItemsData([FromForm] InvitmsDataIn inputParams)
        {
            try
            {
                string InvItmid = inputParams.InvItmid == null ? "0" : inputParams.InvItmid;
                string InvId = inputParams.InvId == null ? "0" : inputParams.InvId;

                dm.TraceService("==========GetInvItemsData Started==========");
                string[] arr = { inputParams.InvId };
                DataTable CI = dm.loadList("SeItemswiseData", "sp_AppServices", InvItmid.ToString(),arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<InvitmsDataOut> listItems = new List<InvitmsDataOut>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new InvitmsDataOut
                        {
                            HigherUOM = dr["sld_HigherUOM"].ToString(),
                            HigherQty = dr["sld_HigherQty"].ToString(),
                            LowerUOM = dr["sld_LowerUOM"].ToString(),
                            LowerQty = dr["sld_LowerQty"].ToString(),
                            GrandTotal = dr["sld_GrandTotal"].ToString()
                           


                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========GetInvItemsData End==========");
            return JSONString;
        }
       
        public string InsCreditNoteReq([FromForm] InsCRNHeader inputParams)
        {
            dm.TraceService("InsCreditNoteReq STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                List<InsCRNDetail> itemData = JsonConvert.DeserializeObject<List<InsCRNDetail>>(inputParams.Detaildata);
                try
                {
                    string rotid = inputParams.rotid == null ? "0" : inputParams.rotid;
                    string cusid = inputParams.cusid == null ? "PA" : inputParams.cusid;
                    string subtotal = inputParams.subtotal == null ? "0" : inputParams.subtotal;
                    string Amount = inputParams.Amount == null ? "0" : inputParams.Amount;
                    string usrid = inputParams.usrid == null ? "0" : inputParams.usrid;
                    string cseID = inputParams.cseID == null ? "0" : inputParams.cseID;
                    string udpID = inputParams.udpID == null ? "0" : inputParams.udpID;

                    string InputXml = "";
                    using (var sw = new StringWriter())
                    {
                        using (var writer = XmlWriter.Create(sw))
                        {

                            writer.WriteStartDocument(true);
                            writer.WriteStartElement("r");
                            int c = 0;
                            foreach (InsCRNDetail id in itemData)
                            {
                                string[] arr = {id.invid.ToString(), id.itmid.ToString(), id.huom.ToString(), id.hqty.ToString(), id.luom.ToString(), id.lqty.ToString(), id.amount.ToString(),id.rsnid.ToString() };
                                string[] arrName = {"InvoiceId", "ItemId", "HigherUOM", "HigherQty", "LowerUOM", "LowerQty","Amount", "ReasonId" };
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
                        string[] arr = { cusid.ToString(), subtotal.ToString(),  Amount.ToString(), usrid.ToString(), cseID.ToString(), udpID.ToString(), InputXml.ToString()};
                        DataTable dt = dm.loadList("InsCreditNoteRequest", "sp_AppServices", rotid.ToString(), arr);

                        List<GetCNRInsertStatus> listStatus = new List<GetCNRInsertStatus>();
                        if (dt.Rows.Count > 0)
                        {
                            List<GetCNRInsertStatus> listHeader = new List<GetCNRInsertStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetCNRInsertStatus
                                {
                                    Mode = dr["Res"].ToString(),
                                    Status = dr["Status"].ToString(),
                                    ReqID = dr["ReqID"].ToString()

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
            dm.TraceService("InsCreditNoteReq ENDED " + DateTime.Now.ToString());
            dm.TraceService("========================================");
            return JSONString;
        }
        public string PostCreditNoteReqImage([FromForm] CNRImageIn inputParams)
        {
            dm.TraceService("PostCreditNoteReqImage STARTED ");
            dm.TraceService("==============================");
            try
            {

                string TransID = inputParams.ReqID == null ? "0" : inputParams.ReqID;
                string prdID = inputParams.prdID == null ? "0" : inputParams.prdID;


                dm.TraceService("Value for Transaction :" + TransID.ToString());
                dm.TraceService("Value for Prd:" + prdID.ToString());

                try
                {
                    var HttpReq = HttpContext.Request;
                    try
                    {
                        HttpPostedFileBase[] imageFiles = new HttpPostedFileBase[HttpReq.Files.Count];
                        dm.TraceService("file Received in Httpreq" + imageFiles.Length.ToString());
                        var folderName = DateTime.Now.ToString("ddMMyyyy");

                        var physicalPath = Server.MapPath("../../UploadFiles/CreditNoteReqImages");
                        dm.TraceService("Physical Path Generated" + physicalPath.ToString());
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                            dm.TraceService("Directory Created");
                        }
                        string image = "";
                        var imagePath = physicalPath + "/";
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                            dm.TraceService("Directory for Image Path Created");
                        }
                        string ReceiptImages = "";
                        for (int y = 0; y < HttpReq.Files.Count; y++)
                        {

                            dm.TraceService("Loop Started" + y.ToString());
                            imageFiles[y] = HttpReq.Files[y];
                            long fileSize = imageFiles[y].ContentLength;
                            string REcimage = (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            image = imagePath + "/" + (DateTime.Now.ToString("HHmmss") + imageFiles[y].FileName);
                            imageFiles[y].SaveAs(image);
                            if (y == 0 && fileSize > 0)
                            {
                                ReceiptImages = "../../UploadFiles/CreditNoteReqImages/" + REcimage;

                            }
                            else if (y != 0 && fileSize > 0)
                            {
                                ReceiptImages += "," + "../../UploadFiles/CreditNoteReqImages/" + REcimage;
                            }
                            else if (fileSize == 0)
                            {
                                ReceiptImages = "";
                            }
                            dm.TraceService("ImageFile" + imageFiles[y].FileName.ToString());
                            dm.TraceService("Loop Ended" + y.ToString());
                        }

                        string[] ar = { ReceiptImages, prdID };
                        DataTable dtDN = dm.loadList("InsCNRImage", "sp_AppServices", TransID, ar);
                        if (dtDN.Rows.Count > 0)
                        {
                            List<SRImageOut> listDn = new List<SRImageOut>();
                            foreach (DataRow dr in dtDN.Rows)
                            {
                                listDn.Add(new SRImageOut
                                {
                                    Res = dr["Res"].ToString(),
                                    Message = dr["Message"].ToString(),



                                });
                            }
                            JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listDn
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

            dm.TraceService("PostCreditNoteReqImage ENDED ");
            dm.TraceService("==========================");

            return JSONString;
        }
        public string GetOpenCNR([FromForm] OpnCNRIn inputParams)
        {
            try
            {
               // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetOpenCNR Started==========");
                string[] arr = { inputParams.cus_ID };
                DataTable CI = dm.loadList("SelOpenCrediNoteReq", "sp_AppServices", inputParams.rot_ID.ToString(), arr);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<OpnCNROut> listItems = new List<OpnCNROut>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new OpnCNROut
                        {
                            Reqno = dr["cnh_Number"].ToString(),
                            Amount = dr["cnh_Amount"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
                            reqID = dr["cnh_ID"].ToString(),
                            vat = dr["cnh_VAT"].ToString(),
                            subtotal = dr["cnh_SubTotal"].ToString()
                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========GetOpenCNR End==========");
            return JSONString;
        }
        public string GetPreviousCNR([FromForm] PrevCNRIn inputParams)
        {
            try
            {
                // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetPreviousCNR Started==========");


                string rot_ID = inputParams.rot_ID == null ? "0" : inputParams.rot_ID;
                string cus_ID = inputParams.cus_ID == null ? "0" : inputParams.cus_ID;


                string MainCondition = "";
                string RouteCondition = "";
                string CusCondition = "";

                if (rot_ID == "0")
                {
                    RouteCondition = "";
                }
                else
                {
                    RouteCondition = " and cnh_rot_ID in ( " + rot_ID + " )";
                }
                if (cus_ID == "0")
                {
                    CusCondition = "";
                }
                else
                {
                    CusCondition = " and cnh_cus_ID in ( " + cus_ID + " )";
                }


                MainCondition += RouteCondition;
                MainCondition += CusCondition;
                //string[] arr = { inputParams.cus_ID };
                DataTable CI = dm.loadList("SelPrevCrediNoteReq", "sp_AppServices", MainCondition);
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<PrevCNROut> listItems = new List<PrevCNROut>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new PrevCNROut
                        {
                            Reqno = dr["cnh_Number"].ToString(),
                            Amount = dr["cnh_Amount"].ToString(),
                            Date = dr["Date"].ToString(),
                            Time = dr["Time"].ToString(),
                            Status = dr["Status"].ToString(),
                            vat = dr["cnh_VAT"].ToString(),
                            subtotal= dr["cnh_SubTotal"].ToString(),
                            reqID = dr["cnh_ID"].ToString()
                        });  
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========GetPreviousCNR End==========");
            return JSONString;
        }
        public string GetCNRDetail([FromForm] CNRDetailIn inputParams)
        {
            try
            {
                // string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                dm.TraceService("==========GetCNRDetail Started==========");
               
                DataTable CI = dm.loadList("SelCrediNoteReqDetail", "sp_AppServices", inputParams.reqID.ToString());
                dm.TraceService("==========Query Executed==========");
                if (CI.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<CNRDetailOut> listItems = new List<CNRDetailOut>();
                    foreach (DataRow dr in CI.Rows)
                    {

                        listItems.Add(new CNRDetailOut
                        {
                            invid = dr["cnd_inv_ID"].ToString(),
                            itmid = dr["crd_itm_ID"].ToString(),
                            prdcode = dr["prd_Code"].ToString(),
                            prdname = dr["prd_Name"].ToString(),
                            hqty = dr["crd_HQty"].ToString(),
                            huom = dr["crd_HUOM"].ToString(),
                            lqty = dr["crd_LQty"].ToString(),
                            luom = dr["crd_LUOM"].ToString(),
                            amount = dr["cnd_crd_Amount"].ToString(),
                            cnrimage = dr["crd_Image"].ToString(),
                            rsnid = dr["crd_rsn_ID"].ToString(),
                            invno = dr["sal_number"].ToString()
                        });
                    }

                    string JSONString = JsonConvert.SerializeObject(new
                    {
                        result = listItems
                    });
                    dm.TraceService("==========JSONString Generated " + JSONString + "==========");
                    return JSONString;
                }
                else
                {
                    dm.TraceService("==========Row Count Equal To 0==========");
                    JSONString = "NoDataRes";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService("==========Exception Caught " + ex.ToString() + "==========");
                JSONString = "NoDataSQL";
            }
            dm.TraceService("==========GetCNRDetail End==========");
            return JSONString;
        }

    }
}