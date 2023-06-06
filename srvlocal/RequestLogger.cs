using System;
using System.IO;
using System.Net;
using System.Text;

namespace Local
{
    public class RequestLogger
    {
        public class WriteWithoutServerConnection 
        {
            private string _connectionString;
            private string _error;

            public WriteWithoutServerConnection(string Error, string OutputPath) 
            { 
                this._connectionString = OutputPath;
                this._error = Error;
            }

            public async void WriteLog()
            {
                File.AppendAllText(_connectionString, _error);
            }
        }
        //var logger = new RequestLogger("logDirectory", "serverUrl");
        //logger.LogRequestIf(request, req => req.HttpMethod == "GET");

        public void LogRequestIf(HttpListenerRequest request, Func<HttpListenerRequest, bool> predicate)
        {
            if (predicate(request))
            {
                LogRequest(request);
            }
        }
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
