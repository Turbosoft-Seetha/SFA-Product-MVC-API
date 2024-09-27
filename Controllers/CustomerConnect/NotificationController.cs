using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using MVC_API.Models.CustomerConnectHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MVC_API.Controllers.CustomerConnect
{
    public class NotificationController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        [HttpPost]

        public string SelectUserNotifications([FromForm] NotificationIn inputParams)
        {
            dm.TraceService("SelectUserNotifications STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string UserID = inputParams.UserID == null ? "0" : inputParams.UserID;

                DataTable dtNotification = dm.loadList("SelUserNotifications", "sp_CustomerConnect", UserID.ToString());

                if (dtNotification.Rows.Count > 0)
                {
                    List<NotificationOut> listItems = new List<NotificationOut>();
                    foreach (DataRow dr in dtNotification.Rows)
                    {

                        listItems.Add(new NotificationOut
                        {
                            rnt_ID = dr["rnt_ID"].ToString(),
                            rnt_Header = dr["rnt_Header"].ToString(),
                            rnt_Desc = dr["rnt_Desc"].ToString(),
                            rnt_ReadFlag = dr["rnt_ReadFlag"].ToString(),
                            rnt_ReplyMessage = dr["rnt_ReplyMessage"].ToString(),
                            rnt_ReplyUserID = dr["rnt_ReplyUserID"].ToString(),
                            rnt_ReplyTime = dr["rnt_ReplyTime"].ToString(),
                            CreatedDate = dr["CreatedDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            rnt_usr_ID = dr["rnt_usr_ID"].ToString(),
                            rnt_ArHeader = dr["rnt_HeaderArabic"].ToString(),
                            rnt_ArDesc = dr["rnt_DescArabic"].ToString(),
                            ArStatus = dr["ArStatus"].ToString()

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
                dm.TraceService(" SelectUserNotifications Exception - " + ex.Message.ToString());
            }
            dm.TraceService("SelectUserNotifications ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string InsNotificationReply([FromForm] InsNotificationIn inputParams)
        {
            dm.TraceService("InsNotificationReply STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {
                string rnt_ReplyMessage = inputParams.rnt_ReplyMessage == null ? "0" : inputParams.rnt_ReplyMessage;
                string rnt_ReplyUserID = inputParams.rnt_ReplyUserID == null ? "0" : inputParams.rnt_ReplyUserID;
                string rnt_ID = inputParams.rnt_ID == null ? "0" : inputParams.rnt_ID;

                string[] arr = { rnt_ReplyUserID.ToString(), rnt_ID.ToString() };
                DataTable dtNotification = dm.loadList("InsNotificationReply", "sp_CustomerConnect", rnt_ReplyMessage.ToString(), arr);

                if (dtNotification.Rows.Count > 0)
                {
                    List<InsNotificationOut> listItems = new List<InsNotificationOut>();
                    foreach (DataRow dr in dtNotification.Rows)
                    {

                        listItems.Add(new InsNotificationOut
                        {
                            Title = dr["Title"].ToString(),
                            Res = dr["Res"].ToString(),
                            Descr = dr["Descr"].ToString(),

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
                dm.TraceService(" InsNotificationReply Exception - " + ex.Message.ToString());
            }
            dm.TraceService("InsNotificationReply ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

        public string UpdateNotificationReadFlag([FromForm] UpdateNotificationIn inputParams)
        {
            dm.TraceService("UpdateNotificationReadFlag STARTED -" + DateTime.Now);
            dm.TraceService("====================");

            try
            {

                string rnt_ID = inputParams.rnt_ID == null ? "0" : inputParams.rnt_ID;

                DataTable dtNotification = dm.loadList("UpdateNotificationReadFlag", "sp_CustomerConnect", rnt_ID.ToString());

                if (dtNotification.Rows.Count > 0)
                {
                    List<UpdateNotificationOut> listItems = new List<UpdateNotificationOut>();
                    foreach (DataRow dr in dtNotification.Rows)
                    {

                        listItems.Add(new UpdateNotificationOut
                        {
                            Title = dr["Title"].ToString(),
                            Res = dr["Res"].ToString(),
                            Descr = dr["Descr"].ToString(),

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
                dm.TraceService(" UpdateNotificationReadFlag Exception - " + ex.Message.ToString());
            }
            dm.TraceService("UpdateNotificationReadFlag ENDED - " + DateTime.Now);
            dm.TraceService("==================");


            return JSONString;
        }

    }
}