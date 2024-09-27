using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Web;

namespace MVC_API.Controllers
{
    public class VideoUploadController : Controller
    {
      

        DataModel dm = new DataModel();
        string JSONString = string.Empty;

        public async Task<string> UploadLargeFileChunk([FromForm] LargeFileUploadInputModel inputParams)
        {
            try
            {
                dm.TraceService("UploadLargeFileChunk STARTED ");
                dm.TraceService("==============================");

                string fileID = inputParams.FileID ?? "0";
                string chunkOrder = inputParams.ChunkOrder ?? "0";
                string fileName = inputParams.FileName ?? "NoName";
                string userId = inputParams.UserId ?? "0";
                dm.TraceService($"FileID: {fileID}, ChunkOrder: {chunkOrder}, FileName: {fileName}");

                var fileChunk = inputParams.FileChunk;
                if (fileChunk != null && fileChunk.ContentLength > 0)
                {
                   // string uploadDir= "E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles\\VideoUpload";
                    string uploadDir = Path.Combine(Server.MapPath("~/UploadFiles/VideoUpload"));
                    Directory.CreateDirectory(uploadDir);
                    string filePath = Path.Combine(uploadDir, fileChunk.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileChunk.InputStream.CopyToAsync(stream);
                    }

                    // Save chunk data to the database
                    object[] arr = { chunkOrder, filePath, fileName, userId };
                    DataTable dt = dm.loadList("InsVideoFileChunk", "sp_SurveyVideo", fileID, arr);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dm.TraceService("DataTable Rows: " + dt.Rows.Count);
                        List<VideoUploadStatus> listHeader = new List<VideoUploadStatus>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            listHeader.Add(new VideoUploadStatus
                            {
                                Res = dr["Res"].ToString(),
                                Title = dr["Title"].ToString(),
                                Descr = dr["Descr"].ToString(),
                                ReturnId = dr["ReturnId"].ToString(),
                            });
                        }
                        JSONString = JsonConvert.SerializeObject(new { result = listHeader });
                        return JSONString;
                    }
                    else
                    {
                        dm.TraceService("NoDataRes");
                        JSONString = "NoDataRes";
                    }
                }
                else
                {
                    JSONString = "No file data received";
                }
            }
            catch (Exception ex)
            {
                dm.TraceService(ex.Message);
                JSONString = "NoDataSQL - " + ex.Message;
            }

            dm.TraceService("UploadLargeFileChunk ENDED ");
            dm.TraceService("==========================");
            return JSONString;
        }


    }
}