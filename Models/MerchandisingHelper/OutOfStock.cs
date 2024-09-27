using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class OutOfStock
    {
    }
    public class GetOutOfStockCountIn
    {
        public string rotID { get; set; }     

    }
    public class OutOfStockOut
    {
        public string ItemCount { get; set; }
        public string CusCount { get; set; }
        
    }
    public class GetOOSCusIn
    {
        public string rotID { get; set; }
      
    }
    public class GetOOSCusOut
    {
        public string cus_Code { get; set; }
        public string cus_Name { get; set; }
        public string rot_Code { get; set; }
        public string rot_Name { get; set; }
        public string brd_Name { get; set; }
        public string brd_Img { get; set; }
        public string cus_ID { get; set; }
        public string brd_ID { get; set; }
        public string transID { get; set; }

    }
    public class GetOOSItemsIn
    {
        public string rotID { get; set; }
        public string udpID { get; set; }


    }
    public class GetOOSItemsOut
    {
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string prd_ID { get; set; }
       
    }

    public class GetOOSCusByItemIn
    {
        public string rotID { get; set; }
        public string udpID { get; set; }

        public string ItemID { get; set; }


    }
    public class GetOOSCusByItemOut
    {
        public string Cus_ID { get; set; }
        public string Cus_Code { get; set; }
        public string Cus_Name { get; set; }
        public string cse_ID { get; set; }
        public string cse_Start { get; set; }
        public string cse_End { get; set; }

    }

    public class GetOOSBrandByItemIn
    {
        public string rotID { get; set; }
        public string udpID { get; set; }
        public string cseID { get; set; }
        public string ItemID { get; set; }


    }
    public class GetOOSBrandByItemOut
    {
        public string brd_ID { get; set; }
        public string brd_Name { get; set; }
        public string brd_Code { get; set; }
        public string brd_Img { get; set; }
        public string HeaderID { get; set; }

    }

    public class GetOOSAccessPointByItemIn
    {
        public string HeaderID { get; set; }


    }
    public class GetOOSAccessPointByItemOut
    {
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
        public string Type { get; set; }

    }
    public class GetOOSImagesIn
    {
        public string HeaderID { get; set; }
        public string LocationId { get; set; }


    }
    public class GetOOSImagesOut
    {
        public string InitialImage { get; set; }
        public string FinalImage { get; set; }
        public string InitialRemark { get; set; }
        public string FinalRemark{ get; set; }
       

    }
    public class GetOOSCustomerItemIn
    {
        public string HeaderID { get; set; }
        public string LocationId {  get; set; }

    }
    public class GetOOSCustomerItemOut
    {
        public string prd_ID { get; set; }
        public string prd_Code { get; set; }
        public string prd_Name { get; set; }
        public string status {  get; set; }

    }

    public class GetOOSCustomerIn
    {
        public string rotID { get; set; }
        public string udpID { get; set; }

      


    }
    public class GetOOSCustomerOut
    {
        public string Cus_ID { get; set; }
        public string Cus_Code { get; set; }
        public string Cus_Name { get; set; }
        public string cse_ID { get; set; }
        public string cse_Start { get; set; }
        public string cse_End { get; set; }

    }
    public class GetOOSBrandIn
    {
        public string rotID { get; set; }
        public string udpID { get; set; }
        public string cseID { get; set; }
       


    }
    public class GetOOSBrandOut
    {
        public string brd_ID { get; set; }
        public string brd_Name { get; set; }
        public string brd_Code { get; set; }
        public string brd_Img { get; set; }
        public string HeaderID { get; set; }

    }
    public class GetOOSIn
    {
        public string rotID { get; set; }
        public string udpID { get; set; }
       



    }
    public class GetOOSOut
    {
        public string cus_ID { get; set; }
        public string cus_Name { get; set; }
        public string cus_Code { get; set; }
        public string DateTime { get; set; }
        public string HeaderID { get; set; }

    }

    public class GetOOSBrandbyHeaderIn
    {
        public string HeaderID { get; set; }
      



    }
    public class GetOOSBrandbyHeaderOut
    {
        public string brd_ID { get; set; }
        public string brd_Name { get; set; }
        public string brd_Code { get; set; }
        public string brd_Img { get; set; }

    }

}