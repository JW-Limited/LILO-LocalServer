using Server;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using srvlocal;
using LABLibary.Interface;
using LABLibary.Assistant;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection.Metadata;
using ConsoleTables;

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
        private static string _logFile = ".\\portmonitor";
        public static bool isRunning = false;
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

        public Server(string directory, int port)
        {
            try { certificate2 = new X509Certificate2(new X509Certificate2(System.Security.Cryptography.X509Certificates.X509Certificate2.CreateFromSignedFile(AppDomain.CurrentDomain.BaseDirectory + "\\srvlocal.exe"))); }
            catch { }
            _port = port;
            _directory = directory;
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://localhost:{port}/");
        }


        public static CommunicationInterface ci = new CommunicationInterface();

        /// <summary>
        ///     <para name="colors"/>
        /// </summary>

        public static ConsoleColor[] colors = new ConsoleColor[]
        {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkGray,
            ConsoleColor.White
        };


        public static bool menu = true;

        public static void SetColor(ConsoleColor fore, ConsoleColor back = ConsoleColor.Black)
        {
            /*
            Color screenTextColor = Color.Orange;
            Color screenBackgroundColor = Color.Black;
            int irc = SetScreenColorsApp.SetScreenColors(screenTextColor, screenBackgroundColor);
            Debug.Assert(irc == 0, "SetScreenColors failed, Win32Error code = " + irc + " = 0x" + irc.ToString("x"));
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;*/
        }

        /// <summary>
        ///     Einstiegspunkt der Application
        ///     <paramref name="args"/>
        ///     <see cref="Start()"/>
        /// </summary>
        ///  b

        public static void Main(string[] args)
        {

            if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") == "enabled") advancedDebugg = true;

            if (Process.GetProcessesByName("srvlocal_gui").Length > 0) menu = false;
            if (Process.GetProcessesByName("LILO").Length > 0) menu = false;

            if (!menu)
            {
                redirect = new object();
                var srmng = new StartupManager();
                srmng.AddApplicationToStartup("srvlocal", AppDomain.CurrentDomain.BaseDirectory + @"\srvlocal.exe");
                srmng.AddApplicationToStartup("srvlocal_local", @"C:\Users\joeva\Documents\GitHub\LILO-LocalServer\srvlocal\bin\Debug\net7.0-windows\srvlocal.exe");
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
                            _port = CheckPort(_port);
                        }
                        else if (args[i].StartsWith("--folder="))
                        {
                            distDirectory = args[i].Substring(9);
                        }
                        else if (args[i].StartsWith("--media-folder="))
                        {
                            mediaDirectory = args[i].Substring(9);
                        }
                        else if (args[i].StartsWith("--log-file="))
                        {
                            _logFile = args[i].Substring(9);
                        }
                        else if (args[i].StartsWith("--disable-logging"))
                        {
                            isLoggingEnabled = false;
                        }
                        else if (args[i].StartsWith("--enable-debug"))
                        {
                            advancedDebugg = true;
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

                    Console.WriteLine("Configurations: ");
                    Console.WriteLine("");

                    listener = new TcpListener(IPAddress.Any, _port + 1);
                    listener.Start();
                    isRunning = true;
                    listenerThread = new Thread(AcceptConnections);
                    listenerThread.Start();

                    var externalIP = "";

                    try { externalIP = Convert.ToString(GetExternalIPAddress()); }
                    catch (Exception e) { externalIP = $"Something went wrong! ({e.Message.Replace(" (icanhazip.com:80)", "")})"; }

                    var table = new ConsoleTable("Parameter", "Status");

                    table.AddRow("Directory", $"{distDirectory} [{(distDirectory == "C:\\LILO\\dist" ? "DEFAULT" : "CHANGED")}]");
                    table.AddRow("Media", $"{mediaDirectory} [{(mediaDirectory == "C:\\LILO\\req\\media\\" ? "DEFAULT" : "CHANGED")}]");
                    table.AddRow("Port", $"{_port} [{(_port == 8080 ? "DEFAULT" : "CHANGED")}]");
                    table.AddRow("Logging", $"{(isLoggingEnabled ? "enabled" : "disabled")} [{(isLoggingEnabled ? "DEFAULT" : "CHANGED")}]");
                    table.AddRow("Debugger", $"{(advancedDebugg ? "enabled" : "disabled")} [{(advancedDebugg == false ? "DEFAULT" : "CHANGED")}]");
                    table.AddRow("API", $"{(recevieCommands.apiListening ? "enabled" : "disabled")}");
                    table.AddRow("OAuth2", $"{(recevieCommands.OAuth2 ? "authenticated" : "no access")}");
                    table.AddRow("X509Cert", $"{(recevieCommands.certAcepted ? "valid" : "error")}");

                    table.AddRow("Internal IP", GetInternalIPAddress());
                    table.AddRow("External IP", externalIP);

                    table.AddRow("LILO Shell", $"{(ci.IsConnected() ? "connected" : "error")}");

                    Console.WriteLine(table);

                    //ci.IsConnected()

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
                    try
                    {
                        ChangePort(_port);
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine(ex2.Message);
                    }
                }
            }
            else
            {
                var menu1 = new Menu();
                menu1.Show();
            }

        }

        public static void AcceptConnections()
        {
            while (isRunning)
            {
                if (listener.Pending() == false)
                {
                    Thread.Sleep(100);
                    continue;
                }

                TcpClient client = listener.AcceptTcpClient();
                Thread session = new Thread(new ParameterizedThreadStart(HandleNewSession));
                session.Start(client);
            }
        }

        public static void HandleNewSession(object data)
        {
            TcpClient client = (TcpClient)data;
            NetworkWatcher networkWatcher = new NetworkWatcher(client);
            networkWatcher.ConnectionLost += NetworkWatcher_ConnectionLost;
            networkWatcher.DataReceived += NetworkWatcher_DataReceived; ;
            networkWatcher.Start();
        }

        private static List<User> users;

        private static void NetworkWatcher_ConnectionLost(object? sender, ConnectionLostEventArgs args)
        {
            try
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (((IPEndPoint)users[i].NetworkWatcher.Client.Client.RemoteEndPoint).Address == ((IPEndPoint)args.Client.Client.RemoteEndPoint).Address)
                    {
                        if (((IPEndPoint)users[i].NetworkWatcher.Client.Client.RemoteEndPoint).Port == ((IPEndPoint)args.Client.Client.RemoteEndPoint).Port)
                        {
                            //RemoveUser(users[i].Username, users[i].SessionKey);
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        public static void NetworkWatcher_DataReceived(object? sender, global::Server.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static IPAddress GetExternalIPAddress()
        {
            string externalIPString = new WebClient().DownloadString("http://icanhazip.com");

            return IPAddress.Parse(externalIPString.Trim());
        }

        public static IPAddress GetInternalIPAddress()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress ip in localIPs)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }

            return IPAddress.Parse("0.0.0.0");
        }

        public static int CheckPort(int port)
        {

            if (port >= 3000 && port <= 9000)
            {
                return port;
            }

            return 0;
        }

        public static void ChangePort(int port)
        {
            var thread = new Thread(() =>
            {
                var proc = new Process();
                proc.StartInfo.FileName = ".\\srvlocal.exe";
                proc.StartInfo.Arguments = "--port=" + _extraPorts[port != _extraPorts[0] ? 0 : 1];
                proc.Start();
            });
            Console.Clear();
            thread.Start();
            Environment.Exit(0);
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
            }
            catch (Exception ex)
            {
                ChangePort(_port);
            }
        }

        public void HandelRequest()
        {
            try
            {
                var inter = new LABLibary.Interface.CommunicationInterface();

                while (true)
                {
                    try
                    {
                        var responseString = inter.ReceiveFromDefaultBuffer();
                        if (responseString != null) { LogRequest(null, false, responseString); responseString = null; }

                    }
                    catch { }

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
                    if(request.Url.AbsolutePath == "/api/login")
                    {
                        var indexHtml = GenerateLoginHtml();
                        var content = Encoding.UTF8.GetBytes(indexHtml);
                        response.ContentLength64 = content.Length;
                        response.OutputStream.Write(content, 0, content.Length);
                        LogRequest(request, true);
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

                            var rq = new RequestLogger.WriteWithoutServerConnection($"[{DateTime.UtcNow}] : ReceviedCommand : ShutDown", ".\\");
                            rq.WriteLog();
                            Process.GetProcessesByName("srvlocal")[0].Kill();
                        }
                        else
                        {
                            var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : UnknownCommandException. (Command {command})");
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
                            LogRequest(request, true);
                        }
                        else if (Directory.Exists(filePath))
                        {
                            var indexFilePath = Path.Combine(filePath, "index.html");
                            if (File.Exists(indexFilePath))
                            {
                                var content = File.ReadAllBytes(indexFilePath);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                                LogRequest(request, true);
                            }
                            else
                            {
                                var indexHtml = GenerateIndexHtml(filePath);
                                var content = Encoding.UTF8.GetBytes(indexHtml);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                                LogRequest(request, true);
                            }
                        }
                        else
                        {

                            //HandelError(context, request);


                            var indexFilePath = Path.Combine(_directory + "\\error\\404\\index.html");

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
                SetColor(colors[2]);
                Console.WriteLine("[{0}] - An Error Accured\n\n{1}\n{2}", DateTime.Now.ToString("HH:mm"), ex.Message, ex.Data.ToString());
                HandelRequest();
            }

        }

        private void ProcessData(string data)
        {
            var logEntry = data;
            var logFilePath = Path.Combine(logDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "_API.log");

            if (data.Contains("password") && data.Contains("username"))
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

        public string GenerateLoginHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>Login Page</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/favlogo.png\">");

            // Add modern CSS styling
            sb.Append("<style>");
            sb.Append("body {");
            sb.Append("  font-family: 'Roboto', sans-serif;");
            sb.Append("  background-color: #fafafa;");
            sb.Append("}");
            sb.Append(".login-form {");
            sb.Append("  margin: 0 auto;");
            sb.Append("  width: 400px;");
            sb.Append("  margin-top: 5rem;");
            sb.Append("  padding: 2rem;");
            sb.Append("  background-color: #fff;");
            sb.Append("  border-radius: 8px;");
            sb.Append("  box-shadow: 0px 0px 20px 0px rgba(0, 0, 0, 0.1);");
            sb.Append("}");
            sb.Append("h1 {");
            sb.Append("  font-size: 2rem;");
            sb.Append("  margin-top: 0;");
            sb.Append("  margin-bottom: 1rem;");
            sb.Append("  text-align: center;");
            sb.Append("}");
            sb.Append("label {");
            sb.Append("  display: block;");
            sb.Append("  font-size: 1.2rem;");
            sb.Append("  margin-bottom: 0.5rem;");
            sb.Append("}");
            sb.Append("input[type=\"text\"], input[type=\"password\"] {");
            sb.Append("  padding: 8px;");
            sb.Append("  width: 100%;");
            sb.Append("  margin-bottom: 1rem;");
            sb.Append("  font-size: 1.2rem;");
            sb.Append("  border: 1px solid #ddd;");
            sb.Append("  border-radius: 4px;");
            sb.Append("}");
            sb.Append(".submit-button {");
            sb.Append("  background-color: #4CAF50;");
            sb.Append("  border: none;");
            sb.Append("  color: white;");
            sb.Append("  padding: 8px 16px;");
            sb.Append("  text-align: center;");
            sb.Append("  text-decoration: none;");
            sb.Append("  display: inline-block;");
            sb.Append("  font-size: 14px;");
            sb.Append("  margin-top: 1rem;");
            sb.Append("  margin-bottom: 0;");
            sb.Append("  border-radius: 4px;");
            sb.Append("  cursor: pointer;");
            sb.Append("}");
            sb.Append(".submit-button:hover {");
            sb.Append("  background-color: #3e8e41;");
            sb.Append("}");
            sb.Append("</style>");
            sb.Append("<script>\r\nfunction verifyPassword() {\r\n    var username = document.getElementById('username').value;\r\n    var password = document.getElementById('password').value;\r\n    \r\n    // Check if password is correct\r\n    if (username === 'admin' && password === 'lilodev420') {\r\n        alert('Login successful!');\r\n        window.location.href = '/home';\r\n    } else {\r\n        alert('Invalid username or password.');\r\n    }\r\n}\r\n</script>");

            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<div class='login-form'>");
            sb.Append("<h1>API Login</h1>");
            sb.Append("<form>");
            sb.Append("<label for='username'>Username:</label>");
            sb.Append("<input type='text' id='username' name='username' placeholder='Enter your username'>");
            sb.Append("<label for='password'>Password:</label>");
            sb.Append("<input type='password' id='password' name='password' placeholder='Enter your password'>");
            sb.Append("<input type='button' class='submit-button' value='Login' onclick='verifyPassword()'>");
            sb.Append("</form>");
            sb.Append("</div>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
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

        private void LogRequest(HttpListenerRequest request = null, bool req = false, string message = null)
        {
            if (message != null)
            {
                Console.WriteLine($"[LILO SERVER - {DateTime.UtcNow}] : {message}");
            }
            else
            {
                Console.ForegroundColor = req ? ConsoleColor.Blue : ConsoleColor.Green;
                Console.WriteLine($"[LILO SERVER - {DateTime.UtcNow}] : {(req ? "SUCCEED" : request.HttpMethod)} {request.Url}");
                Console.ForegroundColor = ConsoleColor.White;

                if (advancedDebugg)
                {
                    Console.WriteLine($"User-Agent: {request.UserAgent}");
                    Console.WriteLine($"Accept-Encoding: {request.Headers["Accept-Encoding"]}");
                    Console.WriteLine($"Accept-Language: {request.Headers["Accept-Language"]}");
                    Console.WriteLine();
                }
            }

        }
        private string GenerateIndexHtml(string reqDirectory)
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>Index of Files</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/favlogo.png\">");

            // Add modern CSS styling
            sb.Append("<style>");
            sb.Append("body {");
            sb.Append("  font-family: 'Roboto', sans-serif;");
            sb.Append("  background-color: #fafafa;");
            sb.Append("}");
            sb.Append("h1 {");
            sb.Append("  font-size: 2rem;");
            sb.Append("  margin-top: 2rem;");
            sb.Append("  margin-bottom: 1rem;");
            sb.Append("}");
            sb.Append("table {");
            sb.Append("  border-collapse: collapse;");
            sb.Append("  width: 100%;");
            sb.Append("}");
            sb.Append("table th, table td {");
            sb.Append("  border: 1px solid #ddd;");
            sb.Append("  padding: 8px;");
            sb.Append("  text-align: left;");
            sb.Append("}");
            sb.Append("table th {");
            sb.Append("  background-color: #f2f2f2;");
            sb.Append("}");
            sb.Append(".download-link {");
            sb.Append("  background-color: #4CAF50;");
            sb.Append("  border: none;");
            sb.Append("  color: white;");
            sb.Append("  padding: 8px 16px;");
            sb.Append("  text-align: center;");
            sb.Append("  text-decoration: none;");
            sb.Append("  display: inline-block;");
            sb.Append("  font-size: 14px;");
            sb.Append("  margin-right: 8px;");
            sb.Append("  border-radius: 4px;");
            sb.Append("  cursor: pointer;");
            sb.Append("}");
            sb.Append(".download-link:hover {");
            sb.Append("  background-color: #3e8e41;");
            sb.Append("}");
            sb.Append("</style>");

            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>Index of Directory : {reqDirectory.Replace("C:\\LILO\\", "")}</h1>");
            sb.Append("<table>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th>Name</th>");
            sb.Append("<th>Size</th>");
            sb.Append("<th>Last Modified</th>");
            sb.Append("<th>Download</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            var currentDirectory = new DirectoryInfo(reqDirectory);
            var parentDirectory = currentDirectory.Parent;

            if (parentDirectory != null)
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href='../'>../</a></td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("</tr>");
            }

            foreach (var directory in currentDirectory.GetDirectories())
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href='{directory.Name}/'>{directory.Name}/</a></td>");
                sb.Append("<td></td>");
                sb.Append($"<td>{directory.LastWriteTime}</td>");
                sb.Append("<td></td>");
                sb.Append("</tr>");
            }

            foreach (var file in currentDirectory.GetFiles())
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href='{file.Name}'>{file.Name}</a></td>");
                sb.Append($"<td>{GetSizeString(file.Length)}</td>");
                sb.Append($"<td>{file.LastWriteTime}</td>");
                sb.Append("<td>");
                sb.Append($"<a class='download-link' href='{file.Name}' download>Download</a>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

        private string GetSizeString(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }
            return $"{size} {sizes[order]}";
        }
        private string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;
            while (bytes >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                bytes /= 1024;
                suffixIndex++;
            }
            return $"{bytes} {suffixes[suffixIndex]}";
        }

    }

    /// <summary>
    /// <see href="Api"/>
    /// </summary>

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
            if (_process != null && !_process.HasExited)
            {
                _process.Kill();
            }
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