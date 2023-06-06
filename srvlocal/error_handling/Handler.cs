using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal.error_handling
{
    public class Handler
    {
        public static object redirect = new object();

        public static async Task HandleError(HttpListenerContext context, HttpListenerRequest request)
        {
            var response = context.Response;
            var filePath = "C:\\LILO\\dist\\error\\404\\";
            var indexFilePath = Path.Combine(filePath, "index.html");

            if (File.Exists(indexFilePath))
            {
                try
                {
                    using (var fileStream = File.OpenRead(indexFilePath))
                    {
                        response.ContentLength64 = fileStream.Length;
                        await fileStream.CopyToAsync(response.OutputStream);
                    }
                }
                catch (Exception ex)
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusDescription = "Internal Server Error";
                    var errorBytes = Encoding.UTF8.GetBytes($"An error occurred while processing the request: {ex.Message}");
                    response.ContentLength64 = errorBytes.Length;
                    await response.OutputStream.WriteAsync(errorBytes, 0, errorBytes.Length);
                }
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.StatusDescription = "Not Found";
                var notFoundBytes = Encoding.UTF8.GetBytes("404 Not Found");
                response.ContentLength64 = notFoundBytes.Length;
                await response.OutputStream.WriteAsync(notFoundBytes, 0, notFoundBytes.Length);
            }
        }

    }
}
