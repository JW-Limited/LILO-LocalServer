using System;
using System.IO;
using System.Net;
using System.Text;

namespace Local
{
    public class RequestLogger
    {
        private readonly string _logDirectory;
        private readonly string _serverUrl;

        public RequestLogger(string logDirectory, string serverUrl)
        {
            _logDirectory = logDirectory;
            _serverUrl = serverUrl;
        }

        public void LogRequest(HttpListenerRequest request)
        {
            var logEntry = new StringBuilder();
            logEntry.AppendLine($"{request.HttpMethod} {request.Url}");
            logEntry.AppendLine($"User-Agent: {request.UserAgent}");
            logEntry.AppendLine($"Accept-Encoding: {request.Headers["Accept-Encoding"]}");
            logEntry.AppendLine($"Accept-Language: {request.Headers["Accept-Language"]}");
            logEntry.AppendLine();

            var logFilePath = Path.Combine(_logDirectory, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            File.AppendAllText(logFilePath, logEntry.ToString());
        }

        public void SendRequestToServer(HttpListenerRequest request)
        {
            var serverRequest = (HttpWebRequest)WebRequest.Create(_serverUrl);
            serverRequest.Method = request.HttpMethod;
            serverRequest.UserAgent = request.UserAgent;
            serverRequest.Accept = request.Headers["Accept"];
            serverRequest.ContentType = request.ContentType;
            serverRequest.ContentLength = request.ContentLength64;

            try
            {
                using (var requestStream = serverRequest.GetRequestStream())
                {
                    request.InputStream.CopyTo(requestStream);
                }
            }
            catch (Exception ex) { Console.WriteLine($"{DateTime.UtcNow} : {ex.ToString()}"); }

            using (var serverResponse = (HttpWebResponse)serverRequest.GetResponse())
            {
                // Do something with the server response here, if necessary
            }
        }
    }
}
