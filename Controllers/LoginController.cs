using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease;

namespace MVC_API.Controllers
{
    public class LoginController : Controller
    {
        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public string AppSignin([FromForm] AppSignin inParams)
        {
            try
            {
                dm.TraceService("==========AppSignin Started==========");
                string[] arr = { inParams.userPass };
                DataSet CI = dm.loadListDS("AppLogin", "sp_InventoryAppLogin", inParams.usercode, arr);
                DataTable UserData = CI.Tables[0];
                DataTable UsrLvlData = CI.Tables[1];
                dm.TraceService("==========Query Executed==========");
                if (UserData.Rows.Count > 0)
                {
                    dm.TraceService("==========Row Count Greated Than 0==========");
                    List<SigninOutParam> listItems = new List<SigninOutParam>();
                    foreach (DataRow dr in UserData.Rows)
                    {
                        List<SigninOutusrlvlparam> userlevelworkflow = new List<SigninOutusrlvlparam>();
                        foreach (DataRow drdetail in UsrLvlData.Rows)
                        {
                            userlevelworkflow.Add(new SigninOutusrlvlparam
                            {
                                usrlevel = drdetail["uwl_Level"].ToString(),
                                Workflow = drdetail["wfm_Name"].ToString(),
                                Workflowcode = drdetail["wfm_Code"].ToString()
                            });
                        }
                        listItems.Add(new SigninOutParam
                        {
                            usrID = dr["usrID"].ToString(),
                            usrName = dr["usr_Name"].ToString(),                           
                            usrCode = dr["usr_Code"].ToString(),
                            Desc = dr["Descr"].ToString(),
                            Title = dr["Title"].ToString(),
                            Roles = dr["Roles"].ToString(),
                            IsInstantStockCount = dr["IsInstantStockCount"].ToString(),
                            usrleveldata = userlevelworkflow,
                            InventoryOperations = dr["InventoryOps"].ToString(),
                            usrNameArabic = dr["usr_ArabicName"].ToString()


                        }); ;;
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
            dm.TraceService("==========App Signin End==========");
            return JSONString;
        }
    }
}