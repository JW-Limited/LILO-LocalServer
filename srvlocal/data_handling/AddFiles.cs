using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Web;

namespace srvlocal.data_handling
{
    public class AddFiles
    {
        public class JSONDATAHANDLER
        {
            public static void ProcessRequest(HttpListenerContext context)
            {
                string requestMethod = context.Request.HttpMethod;

                if (requestMethod == "POST")
                {

                    using (StreamReader reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                    {
                        string requestBody = reader.ReadToEnd();

                        FileData fileData = Newtonsoft.Json.JsonConvert.DeserializeObject<FileData>(requestBody);

                        if (!string.IsNullOrEmpty(fileData.FileName) && !string.IsNullOrEmpty(fileData.Location))
                        {
                            try
                            {
                                string filePath = Path.Combine(fileData.Location, fileData.FileName);
                                File.WriteAllText(filePath, string.Empty);

                                context.Response.StatusCode = (int)HttpStatusCode.OK;
                                string responseString = "File added successfully!";
                                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                context.Response.ContentLength64 = buffer.Length;
                                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                            catch (Exception ex)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                string responseString = "Failed to add file: " + ex.Message;
                                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                context.Response.ContentLength64 = buffer.Length;
                                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            string responseString = "File name and location are required.";
                            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                            context.Response.ContentLength64 = buffer.Length;
                            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Response.Close();
                }
            }

            public class FileData
            {
                public string FileName { get; set; }
                public string Location { get; set; }
            }
        }

        public bool IsReusable => false;
    }

    public class DirectoryController
    {
        public static void GetSubdirectories(HttpListenerContext context)
        {
            string directoryParam = context.Request.QueryString["directory"];
            string decodedDirectory = HttpUtility.UrlDecode(directoryParam);

            try
            {
                string[] subdirectories = Directory.GetDirectories(decodedDirectory);
                string responseJson = GetSubdirectoriesJson(subdirectories);

                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "application/json";
                byte[] buffer = Encoding.UTF8.GetBytes(responseJson);
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                string errorJson = GetErrorJson(ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                byte[] buffer = Encoding.UTF8.GetBytes(errorJson);
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
            }
        }

        private static string GetSubdirectoriesJson(string[] subdirectories)
        {
            return $"{{ \"subdirectories\": {Newtonsoft.Json.JsonConvert.SerializeObject(subdirectories)} }}";
        }

        private static string GetErrorJson(string errorMessage)
        {
            return $"{{ \"error\": \"{errorMessage}\" }}";
        }
    }
}

