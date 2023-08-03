using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LABLibary.Assistant;

namespace srvlocal.data_handling
{
    internal class AddProject
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
                                string responseString = "Project created successfully!";
                                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                context.Response.ContentLength64 = buffer.Length;
                                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                            catch (Exception ex)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                string responseString = "Failed to create the Project: " + ex.Message;
                                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                context.Response.ContentLength64 = buffer.Length;
                                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            string responseString = "Project name and location are required.";
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

        
    }

}
