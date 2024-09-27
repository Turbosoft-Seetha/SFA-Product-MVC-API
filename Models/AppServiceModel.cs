using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
	public class Products
	{
		public string prd_ID { get; set; }
		public string prd_Code { get; set; }
		public string prd_Name { get; set; }
		public string prd_Image { get; set; }
		public string prd_Description { get;  set; }
		public string prd_BaseUOM { get; set; }
		public string prd_catID { get; set; }
		public string prd_subcatID { get; set; }
        public string prd_ArName { get; set; }
        public string prd_ArDescription { get; set; }

    }

	public class ProductUOM 
	{
		public string pru_ID { get; set; }
		public string pru_prd_ID { get; set; }
		public string pru_uom_ID { get; set; }
		public string pru_UPC { get; set; }


	}
	

	public class Category
	{
		public string cat_ID { get; set; }
		public string cat_Name { get; set; }
		public string cat_Code { get; set; }
		public string cat_ArName { get; set; }
		

	}


    public class Brand
    {
        public string brd_ID { get; set; }
        public string brd_Name { get; set; }
        public string brd_Code { get; set; }
        public string brd_NameArabic { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Img { get; set; }
        public string Status { get; set; }

    }
    public class SubCategory
	{
		
		public string sub_ID { get; set; }
		public string cat_ID { get; set; }
		public string sub_Code { get; set; }
		public string sub_Name { get; set; }
		public string sub_ArName { get; set; }
		


	}
	public class Warehouse
	{
		public string war_ID { get; set; }
		public string war_Name { get; set; }
		public string war_Code { get; set; }
		public string str_ID { get; set; }
		public string str_Name { get; set; }
		public string CreatedDate { get; set; }
		public string CreatedBy { get; set; }
        public string war_ArName { get; set; }
        public string str_ArName { get; set; }

    }
	
	public class Route
	{
		public string rot_ID { get; set; }
		public string rot_Name { get; set; }
		public string rot_Code { get; set; }
	
	}
	public class Reason
	{
		public string rsn_ID { get; set; }
		public string rsn_Name { get; set; }
		public string rsn_Type { get; set; }
        public string rsn_ArName { get; set; }

    }
    public class settingsIn
    {
        public string userid { get; set; }
        

    }

    public class settingsOut
    {
        
        public string IsInstantStockCount { get; set; }
        public string InventoryOperations { get; set; }

    }

    public class UOM
	{
		public string uom_ID { get; set; }
		public string uom_Name { get; set; }
		public string uom_IsDecimalAllowed { get; set; }

	}
    public class BadreturnAttachments
    {
        public string TrnNo { get; set; }
        public string prdID { get; set; }
        public string Attachment { get; set; }

    }
    public class BadreturnAttachmentsOut
    {
        public string Mode { get; set; }
        public string Status { get; set; }

    }
    public class InstantStkCntwarID
    {
        public string war_ID { get; set; }

        public List<InstantStkCntwarItmID> itemserial { get; set; }

    }
    public class InstantStkCntwarItmID
    {
        public string waritm_ID { get; set; }
        public string wareID { get; set; }
        public string prd_Spec { get; set; }
		public string prd_Code {  get; set; }
		public string prd_Name { get; set; }
		public string prd_Desc { get; set; }

    }
    public class ImageCaptureIn
    {
		public string rotID { get; set; }
        public string cusID { get; set; }
       
    }
    public class ImageCaptureOut
    {
        public string meiID { get; set; }
        public string Images { get; set; }
        public string Remarks { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
       

    }
    public class FScountIn
    {
        public string udp_ID { get; set; }
        public string cus_ID { get; set; }
        public string cse_ID { get; set; }
    }
    public class FScountOut
    {
        public string Addreq { get; set; }
        public string Remreq { get; set; }
        public string servicereq { get; set; }
        public string servicejob { get; set; }
        public string AssetTrack { get; set; }

    }

    public class VersionDetailIn
    {
        public string Type { get; set; }

    }
    public class VersionDetailOut
    {

        public string ver_code { get; set; }
        public string ver_name { get; set; }
        public string url { get; set; }
        public string msg { get; set; }

    }
    public class CCVersionIn
    {
        public string UserID { get; set; }
        public string Version { get; set; }
    }
    public class CCVersionOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
}