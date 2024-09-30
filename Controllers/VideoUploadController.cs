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

        //public async Task<string> UploadLargeFileChunk([FromForm] LargeFileUploadInputModel inputParams)
        //{
        //    try
        //    {
        //        dm.TraceService("UploadLargeFileChunk STARTED ");
        //        dm.TraceService("==============================");

        //        string fileID = inputParams.FileID ?? "0";
        //        string chunkOrder = inputParams.ChunkOrder ?? "0";
        //        string fileName = inputParams.FileName ?? "NoName";
        //        string userId = inputParams.UserId ?? "0";
        //        string totalChunks = inputParams.TotalChunks ?? "0";
        //        dm.TraceService($"FileID: {fileID}, ChunkOrder: {chunkOrder}, FileName: {fileName}");

        //        var fileChunk = inputParams.FileChunk;
        //        if (fileChunk != null && fileChunk.ContentLength > 0)
        //        {
        //            string uploadDir = "E:\\TURBOSOFT\\SFAMVCAPI\\UploadFiles\\VideoUpload";
        //            // string uploadDir = Path.Combine(Server.MapPath("~/UploadFiles/VideoUpload"));

        //            Directory.CreateDirectory(uploadDir);
        //            // string filePath = Path.Combine(uploadDir, fileChunk.FileName);
        //            string chunkPath = Path.Combine(uploadDir, $"{fileName}_chunk_{chunkOrder}");
        //            using (var stream = new FileStream(chunkPath, FileMode.Create))
        //            {
        //                await fileChunk.InputStream.CopyToAsync(stream);
        //            }
        //            dm.TraceService($"Chunk {chunkOrder} saved successfully.");

        //            // Save chunk data to the database
        //            if (chunkOrder == totalChunks)
        //            {
        //                dm.TraceService($"All {totalChunks} chunks uploaded. Starting merge process.");
        //                string fileExtension = Path.GetExtension(fileName);
        //                string baseFileName = Path.GetFileNameWithoutExtension(fileName);

        //                string outputFilePath = Path.Combine(uploadDir, $"{baseFileName}{fileExtension}");
        //                MergeChunks(fileName, int.Parse(totalChunks), outputFilePath, fileExtension);

        //                //object[] arr = { chunkOrder, filePath, fileName, userId };
        //                object[] arr = { outputFilePath, fileName, userId };
        //                DataTable dt = dm.loadList("InsVideoFileChunk", "sp_SurveyVideo", fileID, arr);

        //                if (dt != null && dt.Rows.Count > 0)
        //                {
        //                    dm.TraceService("Final file saved in the database successfully.");

        //                    List<VideoUploadStatus> listHeader = new List<VideoUploadStatus>();
        //                    foreach (DataRow dr in dt.Rows)
        //                    {
        //                        listHeader.Add(new VideoUploadStatus
        //                        {
        //                            Res = dr["Res"].ToString(),
        //                            Title = dr["Title"].ToString(),
        //                            Descr = dr["Descr"].ToString(),
        //                            ReturnId = dr["ReturnId"].ToString(),
        //                        });
        //                    }
        //                    JSONString = JsonConvert.SerializeObject(new { result = listHeader });
        //                    return JSONString;
        //                }
        //                else
        //                {
        //                    dm.TraceService("No data response from the database.");
        //                    JSONString = "NoDataRes";
        //                }
        //            }
        //            else
        //            {
        //                JSONString = "Chunk uploaded successfully. Waiting for more chunks.";
        //            }
        //        }
        //        else
        //        {
        //            JSONString = "No file data received";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dm.TraceService(ex.Message);
        //        JSONString = "NoDataSQL - " + ex.Message;
        //    }

        //    dm.TraceService("UploadLargeFileChunk ENDED ");
        //    dm.TraceService("==========================");
        //    return JSONString;
        //}


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
                string totalChunks = inputParams.TotalChunks ?? "0";
                dm.TraceService($"FileID: {fileID}, ChunkOrder: {chunkOrder}, FileName: {fileName}");

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
                    dm.TraceService($"Chunk {chunkOrder} saved successfully.");

                    // Merge all chunks if this is the last one
                    if (chunkOrder == totalChunks)
                    {
                        dm.TraceService($"All {totalChunks} chunks uploaded. Starting merge process.");

                        // Final output file path with the correct extension
                        string outputFilePath = Path.Combine(uploadDir, $"{baseFileName}{fileExtension}");

                        // Merge all the chunks into the final file
                        MergeChunks(baseFileName, int.Parse(totalChunks), outputFilePath, fileExtension);

                        // Save file details to the database
                        object[] arr = { outputFilePath, originalFileName, userId };
                        DataTable dt = dm.loadList("InsVideoFileChunk", "sp_SurveyVideo", fileID, arr);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dm.TraceService("Final file saved in the database successfully.");

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
                            dm.TraceService("No data response from the database.");
                            JSONString = "NoDataRes";
                        }
                    }
                    else
                    {
                        JSONString = "Chunk uploaded successfully. Waiting for more chunks.";
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

        public void MergeChunks(string baseFileName, int totalChunks, string outputFilePath, string fileExtension)
        {
            using (var outputStream = new FileStream(outputFilePath, FileMode.Append))
            {
                for (int i = 1; i <= totalChunks; i++)
                {
                    string chunkPath = Path.Combine(Server.MapPath("~/UploadFiles/VideoUpload"),$"{baseFileName}_chunk_{i}");
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

    }
}