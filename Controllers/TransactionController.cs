using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers
{
    public class TransactionController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        [HttpPost]
        public string GetTransaction()
        {
            dm.TraceService("GetTransaction STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                DataTable dtTrnsIn = dm.loadList("SelectTransactionName", "sp_SFA_App");

                if (dtTrnsIn.Rows.Count > 0)
                {
                    List<GetTransactionOutpara> listItems = new List<GetTransactionOutpara>();
                    foreach (DataRow dr in dtTrnsIn.Rows)
                    {

                        listItems.Add(new GetTransactionOutpara
                        {

                            trn_ID = dr["trn_ID"].ToString(),
                            trn_Name = dr["trn_Name"].ToString(),
                            trn_OrderSeq = dr["trn_OrderSeq"].ToString(),
                            trn_Enable = dr["trn_Enable"].ToString(),
                            trn_AppIndex = dr["trn_AppIndex"].ToString()
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
                dm.TraceService(" GetTransaction Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetTransaction ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string GetWebservices([FromForm] GetWSInpara inputParams)
        {
            dm.TraceService("GetTransaction STARTED -" + DateTime.Now);
            dm.TraceService("====================");
            try
            {
                DataTable dtTrnsIn = dm.loadList("SelectAppWebservices", "sp_SFA_App", inputParams.rot_Type);

                if (dtTrnsIn.Rows.Count > 0)
                {
                    List<GetWSOutpara> listItems = new List<GetWSOutpara>();
                    foreach (DataRow dr in dtTrnsIn.Rows)
                    {

                        listItems.Add(new GetWSOutpara
                        {

                            aws_ID = dr["aws_ID"].ToString(),
                            asw_Code = dr["aws_Code"].ToString(),
                            asw_Name = dr["aws_Name"].ToString(),
                            trn_AppIndex = dr["aws_rotType"].ToString(),
                            Status = dr["Status"].ToString(),
                            aws_Tag = dr["aws_Tag"].ToString()

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
                dm.TraceService(" GetTransaction Exception - " + ex.Message.ToString());
            }
            dm.TraceService("GetTransaction ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }
    }
}