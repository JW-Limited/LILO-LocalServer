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
using System.Windows.Forms;
using srvlocal.Api;
using srvlocal.error_handling;
using srvlocal.data_handling;

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
            if (Process.GetProcessesByName("crypterv2").Length > 0) menu = false;

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

                    Task.Run(async () =>
                    {
                        await server.Start();
                    });
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

        public async Task Start()
        {
            try
            {
                var mediasvr = new MediaServer();
                mediasvr.Start();

                //InitializeInterfaceConnection();
                await WaitForMediaServerRunning(mediasvr);
                _listener.Start();
                if (_listener.IsListening)
                {
                    Console.WriteLine($"Local Server server started at http://localhost:{_port}/");
                    Console.WriteLine();
                    Console.WriteLine("Listening for requests...");

                    HandelRequest();
                }
            }
            catch (Exception ex)
            {
                ChangePort(_port);
            }
        }

        private async Task WaitForMediaServerRunning(MediaServer mediasvr)
        {
            var timeout = TimeSpan.FromSeconds(10);
            var stopwatch = Stopwatch.StartNew();

            while (!mediasvr._isRunning)
            {
                if (stopwatch.Elapsed > timeout)
                {
                    var error = new Errorhandling();
                    error.ThrowError("The MediaServer is not reachable!");
                }

                await Task.Delay(500);
            }
        }

        private void InitializeInterfaceConnection()
        {
            var inter = new LABLibary.Interface.CommunicationInterface();

            try
            {
                Console.WriteLine(inter.ToString());

                var responseString = inter.ReceiveFromDefaultBuffer();
                if (responseString is not null)
                {
                    LogRequest(null, false, responseString);
                    responseString = null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Accoured : {ex.Message}\n\n");
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

                    // <----- API GET METHODS ----->

                    if (request.Url.AbsolutePath == "/api/login")
                    {
                        var indexHtml = srvlocal.auto_generators.GenerateLoginHtml.Instance().v1();
                        var content = Encoding.UTF8.GetBytes(indexHtml);
                        response.ContentLength64 = content.Length;
                        response.OutputStream.Write(content, 0, content.Length);
                        LogRequest(request, true);
                    }
                    if (request.Url.AbsolutePath == "/api/home")
                    {
                        var indexHtml = srvlocal.auto_generators.GenerateLoginHtml.Instance().v1();
                        var content = Encoding.UTF8.GetBytes(indexHtml);
                        response.ContentLength64 = content.Length;
                        response.OutputStream.Write(content, 0, content.Length);
                        LogRequest(request, true);
                    }

                    // <----- API POST METHODS ----->

                    else if (request.Url.AbsolutePath == "/api/data" && request.HttpMethod == "POST")
                    {
                        var key = request.QueryString["key"];

                        if (key == _apiKey)
                        {
                            var body = new StreamReader(request.InputStream).ReadToEnd();

                            PublicApi.Instance().ProcessData(body, ".\\log.log");

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
                        string[] commands = command.Split(' ');

                        PublicApi.Instance().CommandHandling(command, commands, request, response);
                    }

                    if (request.Url.AbsolutePath == "/api/resources/data")
                    {
                        AddFiles.JSONDATAHANDLER.ProcessRequest(context);
                    }
                    if (request.Url.AbsolutePath == "/api/projects/data")
                    {
                        AddProject.JSONDATAHANDLER.ProcessRequest(context);
                    }
                    if (request.Url.AbsolutePath == "/api/subdirectories")
                    {
                        srvlocal.data_handling.DirectoryController.GetSubdirectories(context);
                    }

                    // <----- SERVER FILE OPERATIONS ----->

                    else
                    {
                        var filePath = Path.Combine(_directory, request.Url.LocalPath.TrimStart('/'));
                        if (File.Exists(filePath))
                        {
                            var info = new FileInfo(filePath);
                            if(info.Extension is ".txt" or ".log" or ".lrc" or "" or ".ini" or ".dll")
                            {
                                var wrapperIndex = srvlocal.auto_generators.GenerateIndexHtml.Instance().MicrosoftWordWrapper(filePath);
                                var content = Encoding.UTF8.GetBytes(wrapperIndex);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                                LogRequest(request, true);
                            }
                            else
                            {
                                var content = File.ReadAllBytes(filePath);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                                LogRequest(request, true);
                            }
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
                                var indexHtml = srvlocal.auto_generators.GenerateIndexHtml.Instance().v1(filePath);
                                var content = Encoding.UTF8.GetBytes(indexHtml);
                                response.ContentLength64 = content.Length;
                                response.OutputStream.Write(content, 0, content.Length);
                                LogRequest(request, true);
                            }
                        }
                        else
                        {

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
                                var errorHtml = srvlocal.auto_generators.GenerateErrorHtml.Instance().v1(HttpStatusCode.NotFound, "The File, you searching for doesn´t exist.");
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

        public void Stop()
        {
            _listener.Stop();
        }

        private void SendLog(HttpListenerRequest request)
        {
            var logger = new RequestLogger(logDirectory, serverUrl);

            if(request is not null)
            {
                if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") == "enabled")
                {
                    logger.LogRequest(request);
                    //logger.SendRequestToServer(request);
                }
                else 
                { 
                    
                }
            }
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