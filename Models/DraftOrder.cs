using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class DraftOrder
    {
    }
    public class draftorderout
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
    }
    public class draftorderin
    {
        public string ordid { get; set; }
    }
}