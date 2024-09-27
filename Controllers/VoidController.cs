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
    public class VoidController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        ProcessJson pj = new ProcessJson();
        public string InsVoidTransaction([FromForm] PostVoid inputParams)
        {
            dm.TraceService("InsVoidTransaction STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {
                
                try
                {
                    string TrnNumber = inputParams.TrnNumber == null ? "0" : inputParams.TrnNumber;
                    string UdpID = inputParams.UdpID == null ? "0" : inputParams.UdpID;
                    string Type = inputParams.Type == null ? "0" : inputParams.Type;
                    string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;
                    string CusID= inputParams.CusID == null ? "0" : inputParams.CusID;



                    try
                    {
                        string[] arr = { UserID.ToString(), UdpID.ToString(), Type, CusID };
                        DataTable dt = dm.loadList("InsVoidTransaction", "sp_AppServices", TrnNumber.ToString(), arr);

                        
                        if (dt.Rows.Count > 0)
                        {
                            List<GetVoidInsStatus> listHeader = new List<GetVoidInsStatus>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetVoidInsStatus
                                {
                                    Res = dr["Res"].ToString(),
                                    Title = dr["Status"].ToString(),
                                    TransID = dr["TransID"].ToString()

                                });
                            }



                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listHeader
                            });

                            dm.TraceService("==========JSONString Generated " + JSONString + "==========");
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

                }

            }
            catch (Exception ex)
            {

            }

            return JSONString;
        }

        public string VoidStatus([FromForm] GetVoidStatusIn inputParams)
        {
            dm.TraceService("InsVoidTransaction STARTED " + DateTime.Now.ToString());
            dm.TraceService("============================================");
            try
            {

                try
                {
                    string TrnNumber = inputParams.TrnNumber == null ? "0" : inputParams.TrnNumber;



                    try
                    {
                        string[] arr = {  };
                        DataTable dt = dm.loadList("SelStatusforVoidApproval", "sp_AppServices", TrnNumber.ToString(), arr);


                        if (dt.Rows.Count > 0)
                        {
                            List<GetStatusOut> listHeader = new List<GetStatusOut>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                listHeader.Add(new GetStatusOut
                                {
                                    Status = dr["Status"].ToString()

                                });
                            }

                            string JSONString = JsonConvert.SerializeObject(new
                            {
                                result = listHeader
                            });

                            dm.TraceService("==========JSONString Generated " + JSONString + "==========");
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

                }

            }
            catch (Exception ex)
            {

            }

            return JSONString;
        }
    }
}