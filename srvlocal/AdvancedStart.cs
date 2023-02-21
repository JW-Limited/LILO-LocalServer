using Local;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal
{
    internal class AdvancedStart
    {
        private long port;
        private string name;
        private string psw;
        private string dir;
        public static bool isRunning = false;

        private readonly string logDirectory = "C:\\LILO\\dist\\log";
        private readonly string serverUrl = "http://localhost:8080/api";
        private readonly string _apiKey = "liloDev-420";
        private static string _logFile = ".\\portmonitor";
        public static TcpListener listener;
        public static Thread listenerThread;

        public static int _port = 8080;

        public static int[] _extraPorts =
        {
            8081,
            10908
        };

        public static object redirect;

        public static bool isLoggingEnabled = true;
        public static string mediaDirectory = "C:\\LILO\\req\\media\\";
        public static bool advancedDebugg = false;

        private readonly HttpListener _listener;
        public Local.Server srv;


        public AdvancedStart(AdvancedStartValues values) 
        {
            this.port = values.Port;
            this.name = values.User;
            this.psw = values.Password;
            this.dir = values.Dir;
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://localhost:{port}/");

            srv = new Local.Server(dir,Convert.ToInt32(port));
        }
        
        public void Start()
        {
            try
            {
                var mediasvr = new MediaServer();
                try
                {
                    mediasvr.Start();

                    if (!mediasvr._isRunning)
                    {
                        var error = new Errorhandling();
                        error.ThrowError("The MediaServer is not reachable!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now} : {ex.Message}");
                }

                _listener.Start();
                if (_listener.IsListening)
                {
                    Console.WriteLine($"Local Server server started at http://localhost:{port}/");
                    Console.WriteLine();
                    Console.WriteLine("Listening for requests...");

                    var thread = new Thread(HandelRequest);
                    thread.Start();
                    thread.Join();
                }

                else if (!_listener.IsListening)
                {
                    var error = new Errorhandling();
                    error.ThrowError("The Port cant be opened");
                    return;
                }
            }
            catch 
            {
                Debugger.Break();
            }
        }

        public void HandelRequest()
        {
            try
            {
                while (true)
                {
                    var context = _listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;

                    LogRequest(request);
                    SendLog(request);

                    if (request.Url.AbsolutePath == "/api/logs")
                    {
                        var log = System.IO.File.ReadAllText(_logFile);
                        var buffer = Encoding.UTF8.GetBytes(log);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    else if (request.Url.AbsolutePath == "/api/data" && request.HttpMethod == "POST")
                    {
                        var key = request.QueryString["key"];

                        if (key == _apiKey)
                        {
                            var body = new StreamReader(request.InputStream).ReadToEnd();

                            ProcessData(body);

                            var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : Successfuly loaded up Logs.");
                            response.ContentLength64 = buffer.Length;
                            response.OutputStream.Write(buffer, 0, buffer.Length);
                        }
                        else
                        {
                            var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : The ApiKey isn´t valid. (Key {key})");
                            response.ContentLength64 = buffer.Length;
                            response.OutputStream.Write(buffer, 0, buffer.Length);
                        }


                    }
                    else if (request.Url.AbsolutePath == "/api/com")
                    {
                        var command = request.QueryString["command"];
                        if (command == "close")
                        {
                            var body = new StreamReader(request.InputStream).ReadToEnd();

                            ProcessData(body);

                            var buffer = Encoding.UTF8.GetBytes($"[{this.ToString()}] : Closing");
                            response.ContentLength64 = buffer.Length;
                            response.OutputStream.Write(buffer, 0, buffer.Length);

                            var rq = new RequestLogger.WriteWithoutServerConnection("Command from Api : ShutDown", ".\\");
                            rq.WriteLog();
                            Environment.Exit(0);
                        }
                        else
                        {
                            var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : The Command isn´t valid. (Command {command})");
                            response.ContentLength64 = buffer.Length;
                            response.OutputStream.Write(buffer, 0, buffer.Length);
                        }


                    }
                    else
                    {
                        var filePath = Path.Combine(dir, request.Url.LocalPath.TrimStart('/'));
                        if (File.Exists(filePath))
                        {
                            var content = File.ReadAllBytes(filePath);
                            response.ContentLength64 = content.Length;
                            response.OutputStream.Write(content, 0, content.Length);
                        }
                        else if (Directory.Exists(filePath))
                        {
                            var indexFilePath = Path.Combine(filePath, "index.html");
                            if (File.Exists(indexFilePath))
                            {
                                var content = File.ReadAllBytes(indexFilePath);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                            }
                            else
                            {
                                var indexHtml = GenerateIndexHtml(filePath);
                                var content = Encoding.UTF8.GetBytes(indexHtml);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                            }
                        }
                        else
                        {

                            //HandelError(context, request);


                            var indexFilePath = Path.Combine(dir + "\\error\\404\\index.html");

                            if (File.Exists(indexFilePath))
                            {
                                if (File.Exists(indexFilePath))
                                {
                                    var content = File.ReadAllBytes(indexFilePath);
                                    response.ContentLength64 = content.Length;
                                    response.OutputStream.Write(content, 0, content.Length);
                                };
                            }
                            else
                            {
                                response.StatusCode = (int)HttpStatusCode.NotFound;
                                var errorHtml = GenerateErrorHtml(HttpStatusCode.NotFound, "The File, you searching for doesn´t exist.");
                                var content = Encoding.UTF8.GetBytes(errorHtml);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                            }

                        }
                    }


                    response.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[{0}] - An Error Accured\n\n{1}\n{2}", DateTime.Now.ToString("HH:mm"), ex.Message, ex.Data.ToString());
            }

        }

        private void ProcessData(string data)
        {
            var logEntry = data;
            var logFilePath = Path.Combine(logDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "_API.log");

            if (data.Contains("psw") && data.Contains("username"))
            {
                File.AppendAllText(logFilePath, logEntry.ToString());
            }
        }

        public async void HandelError(HttpListenerContext context, HttpListenerRequest request)
        {
            lock (redirect)
            {
                var bufferD = new byte[2048];

                HttpWebRequest redirectRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/error/404/");
                redirectRequest.Method = request.HttpMethod;
                var response = context.Response;

                var filePath = "C:\\LILO\\dist\\error\\404\\";
                var indexFilePath = Path.Combine(filePath, "index.html");
                if (File.Exists(indexFilePath))
                {
                    var content = File.ReadAllBytes(indexFilePath);
                    response.ContentLength64 = content.Length;
                    response.OutputStream.Write(content, 0, content.Length);
                };
            }

        }


        public void Stop()
        {
            _listener.Stop();
        }

        private string GenerateErrorHtml(HttpStatusCode statusCode, string msg)
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append($"<title>Error {(int)statusCode}</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/rec/ico/error.png\">");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<h1>Error</h1>");
            sb.Append($"<p>{(int)statusCode} {statusCode}</p>");
            sb.Append($"<div><p>{msg}</p></div>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

        private void SendLog(HttpListenerRequest request)
        {
            var logger = new RequestLogger(logDirectory, serverUrl);
            logger.LogRequest(request);
            //logger.SendRequestToServer(request);
        }

        private void LogRequest(HttpListenerRequest request)
        {
            Console.WriteLine($"[LILO SERVER - {DateTime.UtcNow}] : {request.HttpMethod} {request.Url}");
            if (advancedDebugg)
            {
                Console.WriteLine($"User-Agent: {request.UserAgent}");
                Console.WriteLine($"Accept-Encoding: {request.Headers["Accept-Encoding"]}");
                Console.WriteLine($"Accept-Language: {request.Headers["Accept-Language"]}");
                Console.WriteLine();
            }

        }

        private string GenerateIndexHtml(string reqDirectory)
        {
            /// <example>
            /// Example of an IndexHtml
            /// </example>


            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>Index of Files</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/favlogo.png\">");
            sb.Append("<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css\">");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>Index of Directory : {reqDirectory.Replace("C:\\LILO\\", "")}</h1>");
            sb.Append("<ul>");

            var currentDirectory = new DirectoryInfo(reqDirectory);
            var parentDirectory = currentDirectory.Parent;

            if (parentDirectory != null)
            {
                sb.Append($"<li><a href='../'>../</a></li>");
            }

            foreach (var directory in currentDirectory.GetDirectories())
            {
                sb.Append($"<li><a href='{directory.Name}/'>{directory.Name}/</a></li>");
            }

            foreach (var file in currentDirectory.GetFiles())
            {
                sb.Append($"<li><a href='{reqDirectory.Replace("C:\\LILO\\dist", "") + "\\" + file.Name}'>{file.Name}</a></li>");
            }

            sb.Append("</ul>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

    }
}

