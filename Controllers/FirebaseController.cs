using MVC_API.Models;
using FirebaseAdmin.Messaging;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Threading.Tasks;
using MVC_API.Models.CustomerConnectHelper;
using static Stimulsoft.Base.StiDataLoaderHelper;
using System.IO;

namespace MVC_API.Controllers
{
    [RoutePrefix("api/Firebase")]
    public class FirebaseController : ApiController
    {
        DataModel dm = new DataModel();

        [Route("PushMsgToToken")]
        [HttpPost]
        public async Task<HttpResponseMessage> PushSingleMessage()
        {

            string rawContent = string.Empty;
            rawContent = await Request.Content.ReadAsStringAsync();
            string rtnID = "";

            if (string.IsNullOrEmpty(rawContent))
            {
                rtnID = "";

            }
            else
            {
                RtnID Input = JsonConvert.DeserializeObject<RtnID>(rawContent);
                rtnID = Input.rnt_ID.ToString();
            }
            string Jsonstring = "";

            DataTable dt = dm.loadList("GetPendingPush", "sp_PushNotification", rtnID);
            foreach (DataRow row in dt.Rows)
            {
                string Mode = row["rnt_Mode"].ToString();
                string DeviceToken = "";
                string jsonPath = "";

                if (Mode == "C")
                {

                    jsonPath = AppDomain.CurrentDomain.BaseDirectory + "Settings\\google-services.json";
                    DeviceToken = row["user_Token"].ToString();

                }
                else if (Mode == "S")
                {
                    jsonPath = AppDomain.CurrentDomain.BaseDirectory + "Settings\\sfa-product_Firebase.json";
                    DeviceToken = row["rot_Token"].ToString();
                }
                try
                {



                    if (FirebaseApp.DefaultInstance == null)
                    {
                        FirebaseApp.Create(new AppOptions
                        {
                            Credential = GoogleCredential.FromFile(jsonPath) // Path to your service account key file
                        });
                    }


                    string title = row["rnt_Header"].ToString();
                    string body = row["rnt_Desc"].ToString();

                    var notificationMessage = new NotificationMessage
                    {
                        Token = DeviceToken,
                        Notification = new Notification
                        {
                            Body = body,
                            Title = title
                        },
                        Android = new Android
                        {
                            Notification = new AndroidNotification
                            {
                                ClickAction = "com.example.app.OPEN_NOTIFICATION_ACTIVITY"
                            }
                        },
                        Data = new Data
                        {
                            Key = "val1",
                            Key2 = "val2"
                        }
                    };
                    var message = ConvertToFirebaseMessage(notificationMessage);

                    string res = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                    Console.WriteLine("Successfully sent message: " + res);
                    string rntID = row["rnt_ID"].ToString();
                    dm.loadList("UpdateSendStats", "sp_PushNotification", rntID);


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending message: " + ex.Message);
                }
            }

            string JSONString = JsonConvert.SerializeObject(new
            {
                result = ""
            }, Formatting.None, new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            });
            dm.TraceService("Final JSON string-Firebase" + JSONString);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JSONString, Encoding.UTF8, "application/json");
            dm.TraceService("Ending Time For Pasrsing Call" + DateTime.Now.ToString());
            return response;
        }
        static FirebaseAdmin.Messaging.Message ConvertToFirebaseMessage(NotificationMessage notificationMessage)
        {
            return new FirebaseAdmin.Messaging.Message()
            {
                Token = notificationMessage.Token,
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Body = notificationMessage.Notification.Body,
                    Title = notificationMessage.Notification.Title
                },
                Android = new AndroidConfig()
                {
                    Notification = new FirebaseAdmin.Messaging.AndroidNotification()
                    {
                        ClickAction = notificationMessage.Android.Notification.ClickAction
                    }
                },
                Data = new Dictionary<string, string>()
                {
                    { "Key", notificationMessage.Data.Key },
                    { "Key2", notificationMessage.Data.Key2 }
                }
            };
        }


        public class NotificationMessage
        {
            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("notification")]
            public Notification Notification { get; set; }

            [JsonProperty("android")]
            public Android Android { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public class Notification
        {
            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }
        }

        public class Android
        {
            [JsonProperty("notification")]
            public AndroidNotification Notification { get; set; }
        }

        public class AndroidNotification
        {
            [JsonProperty("click_action")]
            public string ClickAction { get; set; }
        }

        public class Data
        {
            [JsonProperty("Key")]
            public string Key { get; set; }

            [JsonProperty("Key2")]
            public string Key2 { get; set; }
        }

        public class RtnID
        {
            public string rnt_ID { get; set; }


        }
    }
}