using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class LoadReq
    {
    }
    public class GetWareHouseProductsIn
    {
        public string itemID { get; set; }     

    }
    public class GetWareHouseProductsOut
    {
        public string ItemCount { get; set; }      
        
    }
  
  
}