using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web;
using static Stimulsoft.Base.Drawing.Win32;

namespace MVC_API.Controllers
{
    public class VideoUploadController : Controller
    {     

        DataModel dm = new DataModel();
        string JSONString = string.Empty;
        private static readonly object lockObject = new object();

        public async Task<string> UploadLargeFileChunk([FromForm] LargeFileUploadInputModel inputParams)
        {
            try
            {   
                string methodName = nameof(UploadLargeFileChunk);
                LogTrace($"{methodName} STARTED");
                LogTrace("==============================");
                string fileID = inputParams.FileID == null ? "0":inputParams.FileID;
                string chunkOrder = inputParams.ChunkOrder == null ? "0":inputParams.ChunkOrder;
                string fileName = inputParams.FileName == null ? "NoName": inputParams.FileName;
                string userId = inputParams.UserId == null ? "0":inputParams.UserId;
                string totalChunks = inputParams.TotalChunks == null ? "0":inputParams.TotalChunks;
                LogTrace($"FileID: {fileID}, ChunkOrder: {chunkOrder}, FileName: {fileName}, TotalChunks:{totalChunks}");

                var fileChunk = inputParams.FileChunk;
                if (fileChunk != null && fileChunk.ContentLength > 0)
                {

                    string uploadDir = Path.Combine(Server.MapPath("~/UploadFiles/VideoUpload"));
                    //string uploadDir = "E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles\\VideoUpload";
                    Directory.CreateDirectory(uploadDir);

                    // Get the original file extension from FileChunk
                    string originalFileName = Path.GetFileName(fileChunk.FileName);
                    string fileExtension = Path.GetExtension(originalFileName);
                    string baseFileName = Path.GetFileNameWithoutExtension(originalFileName);

                    // Save the chunk with a unique chunk identifier
                    string chunkPath = Path.Combine(uploadDir, $"{baseFileName}_chunk_{chunkOrder}");
                    using (var stream = new FileStream(chunkPath, FileMode.Create))
                    {
                        await fileChunk.InputStream.CopyToAsync(stream);
                    }
                    LogTrace($"Chunk {chunkOrder} saved successfully.");

                    // Merge all chunks if this is the last one
                    if (chunkOrder == totalChunks)
                    {
                        LogTrace($"All {totalChunks} chunks uploaded. Starting merge process.");

                        // Final output file path with the correct extension
                        string outputFilePath = Path.Combine(uploadDir, $"{baseFileName}{fileExtension}");

                        // Merge all the chunks into the final file
                        MergeChunks(baseFileName, int.Parse(totalChunks), outputFilePath, fileExtension);

                        // Save file details to the database
                        object[] arr = { outputFilePath, originalFileName, userId, totalChunks };
                        DataTable dt = dm.loadList("InsVideoFileChunk", "sp_SurveyVideo", fileID, arr);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            LogTrace("Final file saved in the database successfully.");

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
                            LogTrace("No data response from the database.");
                            JSONString = "NoDataRes";
                        }
                    }
                    else
                    {
                        //JSONString = "Chunk uploaded successfully. Waiting for more chunks.";
                        List<VideoUploadStatus> listHeader = new List<VideoUploadStatus>
                        {
                    new VideoUploadStatus
                              {
                              Res = "1",
                              Title = "Upload Successfully",
                              Descr = "Waiting for more chunks",
                              ReturnId = "0"
                               }
                                };

                        // Serialize the list to JSON format and set it as the response
                        JSONString = JsonConvert.SerializeObject(new { result = listHeader });
                        return JSONString;
                    }
                }
                else
                {
                    JSONString = "No file data received";
                }
            }
            catch (Exception ex)
            {
                LogTrace(ex.Message);
                JSONString = "NoDataSQL - " + ex.Message;
            }

            LogTrace("UploadLargeFileChunk ENDED ");
            LogTrace("==========================");
            return JSONString;
        }

        public void MergeChunks(string baseFileName, int totalChunks, string outputFilePath, string fileExtension)
        {
            using (var outputStream = new FileStream(outputFilePath, FileMode.Append))
            {
                for (int i = 1; i <= totalChunks; i++)
                {
                    string chunkPath = Path.Combine(Server.MapPath("~/UploadFiles/VideoUpload"), $"{baseFileName}_chunk_{i}");
                    // string chunkPath = Path.Combine("E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles\\VideoUpload", $"{baseFileName}_chunk_{i}");
                    if (System.IO.File.Exists(chunkPath))
                    {
                        using (var inputStream = new FileStream(chunkPath, FileMode.Open))
                        {
                            inputStream.CopyTo(outputStream);
                        }
                        // Optionally delete the chunk after merging
                        System.IO.File.Delete(chunkPath);
                    }
                    else
                    {
                        throw new Exception($"Chunk {i} is missing or could not be found.");
                    }
                }
            }
        }
        public void LogTrace(string content)
        {
            try
            {
                string logPath = Path.Combine(HttpRuntime.AppDomainAppPath, "LogFile", "VideoUploadController");
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                string logFileName = Path.Combine(logPath, $"log_{DateTime.Now:dd-MMM-yyyy}.txt");

                lock (lockObject)
                {
                    using (StreamWriter sw = new StreamWriter(logFileName, true))
                    {
                        sw.WriteLine($"{DateTime.Now:dd-MMM-yyyy HH:mm:ss} - {content}");
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        //public void LogTrace(string content)
        //{
        //    try
        //    {
        //        string LogPath = HttpRuntime.AppDomainAppPath;
        //        if (!Directory.Exists(LogPath + "/LogFile/" + "/VideoUploadController/"))
        //        {
        //            Directory.CreateDirectory(LogPath + "/LogFile/" + "/VideoUploadController/");
        //        }

        //        //FileStream fs = new FileStream(LogPath + "/LogFile/log_" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", FileMode.OpenOrCreate, FileAccess.Write);

        //        string logFileName = Path.Combine(LogPath + "/LogFile/" + "/VideoUploadController/" + "/log_" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt");

        //        // Use a lock to handle concurrent access
        //        lock (lockObject)
        //        {
        //            using (StreamWriter sw = new StreamWriter(logFileName, true))
        //            {
        //                sw.WriteLine(DateTimeOffset.Now.ToString("dd-MMM-yyyy HH:mm:ss") + "-" + content);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
}