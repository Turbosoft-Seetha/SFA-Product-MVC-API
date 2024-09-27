using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.CustomerConnectHelper
{
    public class HomeHelper
    {
        
    }
    public class LoginIn
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class GetRouteOut
    {
        public string rot_ID { get; set; }
        public string rot_Name { get; set; }

    }

    public class LoginOut
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContacInfo { get; set; }
        public string usrID { get; set; }
        public string UserName { get; set; }
        public string NewUser { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string VersionDate { get; set; }
        public string ArFirstName { get; set; }
        public string ArLastName { get; set; }
    }
    public class Counts
    {
        public string PickingTotal { get; set; }
        public string PickingNotStarted { get; set; }
        public string PickingNotStartedRoute { get; set; }
        public string PickingOngoing { get; set; }
        public string PickingOngoingRoute { get; set; }
        public string PickingCompleted { get; set; }
        public string PickingCompletedRoute { get; set; }

        public string LoadInTotal { get; set; }
        public string LoadInPending { get; set; }
        public string LoadInPendingRoute { get; set; }
        public string LoadInCompleted { get; set; }
        public string LoadInCompletedRoute { get; set; }
        public string LoadInCancelled { get; set; }
        public string LoadInCancelledRoute { get; set; }
        


    }
    public class CusTrnCounts
    {
        public string CusTrnInvoice { get; set; }
        public string CusTrnARCollection { get; set; }
        public string InvoiceAmount {  get; set; }
        public string ARAmount { get; set;}
    }
    public class SalesOrdersCount
    {
        public string TotalOrders { get; set; }
        public string TodayDel { get; set; }
        public string TodayDelTot { get; set; }
        public string TotalOrdersAmount {  get; set; }
        public string TodayDelAmount { get;set; }
    }
    public class ServiceModuleCount
    {
        public string ServiceModuleCompleted { get; set; }
        public string ServiceModuleInvoice { get; set; }
        public string ServiceModulePending { get; set; }
    }


    public class GetUsersOut
    {
        public string ID { get; set; }
        public string Name { get; set; }

    }
}