using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace MVC_API.Models
{
    public class VideoUploadHelper
    {
    }
    public class LargeFileUploadInputModel
    {
        public string FileID { get; set; }   
        public string ChunkOrder { get; set; }  
        public string FileName { get; set; }
        public HttpPostedFileBase FileChunk { get; set; }  // The actual chunk of the file
       // public IFormFile FileChunk { get; set; }
        public string UserId { get; set; }
    }
    public class VideoUploadStatus
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string ReturnId { get; set; }
    }
}