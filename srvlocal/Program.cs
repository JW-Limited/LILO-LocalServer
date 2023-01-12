using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace Local
{
    public class Server
    {
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private readonly string _directory;
        public static X509Certificate2 certificate2
        {
            get; 
            private set; 
        }
        private readonly HttpListener _listener;
        private readonly string logDirectory = "C:\\LILO\\dist\\log";
        private readonly string serverUrl = "http://localhost:8080/api";
        private readonly string _apiKey = "liloDev-420";
        private readonly string _logFile = ".\\portmonitor";

        public static int _port = 8080;

        public static int[] _extraPorts = 
        { 
            8081, 
            10908 
        };

        public static bool isLoggingEnabled = true;
        public static string mediaDirectory = "C:\\LILO\\req\\media\\";
        public static bool advancedDebugg = false;

        public Server(string directory, int port)
        {
            try { certificate2 = new X509Certificate2(new X509Certificate2(System.Security.Cryptography.X509Certificates.X509Certificate2.CreateFromSignedFile(AppDomain.CurrentDomain.BaseDirectory + "\\srvlocal.exe"))); }
            catch { }
            _port = port;
            _directory = directory;
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://localhost:{port}/");
        }

        /// <summary>
        /// Main Entry
        /// </summary>

        public static void Main(string[] args)
        {
            var distDirectory = "C:\\LILO\\dist";
            var recevieCommands = new ApiToRecevieCommands(8000, certificate2);
            var thread = new Thread(recevieCommands.Start);

            if (args.Length > 0)
            {
                
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].StartsWith("--port="))
                    {
                        int.TryParse(args[i].Substring(7), out _port);
                    }
                    else if (args[i].StartsWith("--folder="))
                    {
                        distDirectory = args[i].Substring(9);
                    }
                    else if (args[i].StartsWith("--media-folder="))
                    {
                        mediaDirectory = args[i].Substring(9);
                    }
                    else if (args[i].StartsWith("--disable-logging"))
                    {
                        isLoggingEnabled = false;
                    }
                    else if (args[i].StartsWith("--enable-debug"))
                    {
                        isLoggingEnabled = false;
                    }
                    else if (args[i] == "--help")
                    {
                        ShowHelp();
                        return;
                    }
                    else if (args[i] == "--version")
                    {
                        ShowVersion();
                        return;
                    }
                }
            }

            try
            {
                thread.Start();

                Console.Title = "LILO™ LocalServer";
                var server = new Server(distDirectory, _port);

                var threadMain = new Thread(server.Start);
                threadMain.Start();
            }
            catch (HttpListenerException httpEx)
            {
                ChangePort(_port);
            }
            catch (Exception ex)
            {
                ChangePort(_port);
            }



            Console.WriteLine("Configurations: ");
            Console.WriteLine("");

            

            Console.WriteLine("Directory    :   {0} [{1}]",distDirectory, distDirectory == "C:\\LILO\\dist" ? "DEFAULT" : "CHANGED");
            Console.WriteLine("Media        :   {0} [{1}]", mediaDirectory, mediaDirectory == "C:\\LILO\\req\\media\\" ? "DEFAULT" : "CHANGED");
            Console.WriteLine("Port         :   {0} [{1}]", _port, _port == 8080 ? "DEFAULT" : "CHANGED");
            Console.WriteLine("Logging      :   {0} [{1}]", isLoggingEnabled ? "enabled" : "disabled",isLoggingEnabled ? "DEFAULT" : "CHANGED");
            Console.WriteLine("Debugger     :   {0} [{1}]", advancedDebugg ? "enabled" : "disabled", advancedDebugg == false ? "DEFAULT" : "CHANGED");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("API          :   {0} ", recevieCommands.apiListening ? "enabled" : "disabled");
            Console.WriteLine("|-- OAuth2   :   {0} ", recevieCommands.OAuth2 ? "authenticated" : "no access");
            Console.WriteLine("|-- X509Cert :   {0} ", recevieCommands.certAcepted ? "valid" : "error");
            Console.WriteLine("");

        }

        public static void ChangePort(int port)
        {
            if(port != _extraPorts[0])
            {
                var thread = new Thread(() =>
                {
                    var proc = new Process();
                    proc.StartInfo.FileName = ".\\srvlocal.exe";
                    proc.StartInfo.Arguments = "--port=" + _extraPorts[0];
                    proc.Start();
                });
                Console.Clear();
                thread.Start();
                Environment.Exit(0);
            }
            else if (port == _extraPorts[0])
            {
                var thread = new Thread(() =>
                {
                    var proc = new Process();
                    proc.StartInfo.FileName = ".\\srvlocal.exe";
                    proc.StartInfo.Arguments = "--port=" + _extraPorts[1];

                    proc.Start();
                });
                Console.Clear();
                thread.Start();
                Environment.Exit(01);
            }
        }

        private static void ShowVersion()
        {
            Console.WriteLine("JW Lmt. LILO™ SrvLocal - [Local Server Application Host] version {0}", AssemblyVersion);
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage: srvlocal.exe [OPTIONS]");
            Console.WriteLine("Options:");
            Console.WriteLine("  --port=<port>              Specify the port to listen on (default is 8080)");
            Console.WriteLine("  --media-folder=<folder>    Specify the folder to serve data from (default is req/media)");
            Console.WriteLine("  --folder=<folder>          Specify the folder to serve data from (default is dist/)");
            Console.WriteLine("  --disable-logging          Disable request logging (default is enabled)");
            Console.WriteLine("  --logfile=<file>           Specify the file to log requests to (default is access.log)");
            Console.WriteLine("  --version                  Shows the current version");
            Console.WriteLine("  --help                     Show this help message");
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
                    Console.WriteLine($"Local Server server started at http://localhost:{_port}/");
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
            catch (Exception ex)
            {
                ChangePort(_port);
            }
            

            
        }

        public void HandelRequest()
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
                else
                {
                    var filePath = Path.Combine(_directory, request.Url.LocalPath.TrimStart('/'));
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
                        var indexFilePath = Path.Combine("C:\\LILO\\dist\\error\\404\\", "index.html");
                        if (Directory.Exists("C:\\LILO\\dist\\error\\404\\"))
                        {
                            if (File.Exists(indexFilePath))
                            {
                                var content = File.ReadAllBytes(indexFilePath);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                            }
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

        private void ProcessData(string data)
        {
            var logEntry = data;
            var logFilePath = Path.Combine(logDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "_API.log");
            
            if(data.Contains("psw") && data.Contains("username"))
            {
                File.AppendAllText(logFilePath, logEntry.ToString());
            }
        }


        public void Stop()
        {
            _listener.Stop();
        }

        private string GenerateErrorHtml(HttpStatusCode statusCode,string msg)
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
            if(advancedDebugg)
            {
                Console.WriteLine($"User-Agent: {request.UserAgent}");
                Console.WriteLine($"Accept-Encoding: {request.Headers["Accept-Encoding"]}");
                Console.WriteLine($"Accept-Language: {request.Headers["Accept-Language"]}");
                Console.WriteLine();
            }
            
        }

        private string GenerateIndexHtml(string reqDirectory)
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>Index of Files</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/favlogo.png\">");
            sb.Append("<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css\">");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>Index of Directory : {reqDirectory.Replace("C:\\LILO\\","")}</h1>");
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
    public class BatchStarter
    {
        private readonly string _batchFile;
        private Thread _thread;
        private Process _process;

        public BatchStarter(string batchFile)
        {
            _batchFile = batchFile;
        }

        public void Start()
        {
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Stop()
        {
            _process.Kill();
            _thread.Join();
        }

        private void Run()
        {
            _process = new Process();
            _process.StartInfo.FileName = _batchFile;
            _process.Start();
            _process.WaitForExit();
        }
    }
}
