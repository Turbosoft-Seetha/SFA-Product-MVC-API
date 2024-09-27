using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class NotificationHelper
    {
    }

    
    public class NotificationIn
    {
        public string UserID { get; set; }

    }
    public class NotificationOut
    {
        public string rnt_ID { get; set; }
        public string rnt_Header { get; set; }
        public string rnt_Desc { get; set; }
        public string rnt_ReadFlag { get; set; }
        public string rnt_ReplyMessage { get; set; }
        public string rnt_ReplyUserID { get; set; }
        public string rnt_ReplyTime { get; set; }
        public string CreatedDate { get; set; }
        public string Status { get; set; }
        public string rnt_usr_ID { get; set; }
        public string rnt_ArHeader { get; set; }
        public string rnt_ArDesc { get; set; }
        public string ArStatus { get; set; }

    }
    public class InsNotificationIn
    {
        public string rnt_ReplyMessage { get; set; }
        public string rnt_ReplyUserID { get; set; }
        public string rnt_ID { get; set; }

    }
    public class InsNotificationOut
    {
        public string Title { get; set; }
        public string Res { get; set; }
        public string Descr { get; set; }

    }
    public class UpdateNotificationIn
    {
        public string rnt_ID { get; set; }

    }
    public class UpdateNotificationOut
    {
        public string Title { get; set; }
        public string Res { get; set; }
        public string Descr { get; set; }

    }

}