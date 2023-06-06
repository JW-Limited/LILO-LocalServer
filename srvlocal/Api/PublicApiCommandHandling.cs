using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal.Api
{
    public class PublicApi
    {
        private static object _lock = new object();
        private static PublicApi _instance;

        public static PublicApi Instance()
        {
            lock (_lock)
            {
                if(_instance == null)
                {
                    _instance = new PublicApi();
                }

                return _instance;
            }
        }

        private PublicApi() 
        {
        
        }

        public void CommandHandling(string command, string[] commands, HttpListenerRequest request, HttpListenerResponse response)
        {
            if (command == "close")
            {
                var body = new StreamReader(request.InputStream).ReadToEnd();
                ProcessData(body,".\\log.log");
                var buffer = Encoding.UTF8.GetBytes("[LOCAL-SERVER] : Closed");
                SendResponse(response, buffer);
                KillProcessByName("srvlocal");
            }
            else if (command == "restart")
            {
                var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : Restarting");
                SendResponse(response, buffer);
                StartLocalServer();
                Environment.Exit(0);
            }
            else if (command == "status")
            {
                var status = GetStatus();
                var buffer = Encoding.UTF8.GetBytes($"[LOCAL-SERVER] : {status}");
                SendResponse(response, buffer);
            }
            else if (command == "info")
            {
                var info = GetInfo();
                var buffer = Encoding.UTF8.GetBytes($"[LOCAL-SERVER] : {info}");
                SendResponse(response, buffer);
            }
            else if (commands[0] == "execute")
            {
                var result = ExecuteCommand(command);
                var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : Execution Result - {result}");
                SendResponse(response, buffer);
            }
            else if (commands[0] == "message")
            {
                var result = HandleMessage(commands[1]);
                var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : Message - {result}");
                SendResponse(response, buffer);
                PrintClientMessage(commands[1]);
            }
            else
            {
                var buffer = Encoding.UTF8.GetBytes($"[{DateTime.UtcNow}] : UnknownCommandException. (Command: {command})");
                SendResponse(response, buffer);
            }
        }

        private void SendResponse(HttpListenerResponse response, byte[] buffer)
        {
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        private void KillProcessByName(string processName)
        {
            var process = Process.GetProcessesByName(processName).FirstOrDefault();
            process?.Kill();
        }

        private void StartLocalServer()
        {
            var application = AppDomain.CurrentDomain.BaseDirectory + "srvlocal.exe";
            Process.Start(application);
        }

        private string HandleMessage(string message)
        {
            return "Hey, I'm your LocalServer.";
        }

        private string GetSizeString(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                size /= 1024;
                order++;
            }

            return $"{size} {sizes[order]}";
        }

        private string GetInfo()
        {
            try
            {
                var process = Process.GetCurrentProcess();

                var info = new StringBuilder();
                info.AppendLine("Process Information:");
                info.AppendLine("--------------------");
                info.AppendLine($"| {"Property"} | {"Value",-30} ");
                info.AppendLine($"| {"Process ID"} | {process.Id,-30} ");
                info.AppendLine($"| {"Process Name"} | {process.ProcessName,-30} ");
                info.AppendLine($"| {"Start Time"} | {process.StartTime,-30}");
                info.AppendLine($"| {"Total Time"} | {process.TotalProcessorTime,-30} ");
                info.AppendLine($"| {"Memory Usage"} | {GetSizeString(process.WorkingSet64),-30} ");
                info.AppendLine($"| {"Threads Count"} | {process.Threads.Count,-30} ");
                info.AppendLine($"| {"Priority Class"} | {process.PriorityClass,-30} ");
                info.AppendLine("\nSystem Information:");
                info.AppendLine("-------------------");
                info.AppendLine($"| {"Operating System"} | {Environment.OSVersion,-30} ");
                info.AppendLine($"| {"Machine Name    "} | {Environment.MachineName,-30} ");
                info.AppendLine($"| {"Processor Count "} | {Environment.ProcessorCount,-30} ");

                return info.ToString();
            }
            catch (Exception ex)
            {
                return $"Failed to retrieve process information: {ex.Message}";
            }
        }

        private string GetStatus()
        {
            try
            {
                var process = Process.GetCurrentProcess();
                return process.HasExited ? "The Client has exited." : "The Client is currently running.";
            }
            catch (Exception ex)
            {
                return $"Failed to retrieve Client status: {ex.Message}";
            }
        }

        private string ExecuteCommand(string command)
        {
            string[] commands = command.Split(' ');

            try
            {
                var process = Process.GetCurrentProcess();

                if (commands[1] == "example")
                {
                    return "Command executed successfully.";
                }
                else if (commands[1] == "terminate")
                {
                    process.CloseMainWindow();

                    if (!process.WaitForExit(5000))
                    {
                        process.Kill();
                    }

                    return "Process terminated.";
                }
                else
                {
                    return "Unknown command.";
                }
            }
            catch (Exception ex)
            {
                return $"Command execution failed: {ex.Message}";
            }
        }

        public void ProcessData(string data, string logDirectory)
        {
            var logEntry = data;
            var logFilePath = Path.Combine(logDirectory, DateTime.Now.ToString("yyyy-MM-dd") + "_API.log");

            if (data.Contains("password") && data.Contains("username"))
            {
                File.AppendAllText(logFilePath, logEntry.ToString());
            }
        }


        private void PrintClientMessage(string message)
        {
            if (!Console.IsOutputRedirected)
            {
                Console.WriteLine("A Client sent you a Message: " + message.Replace("_", " "));
            }
        }
    }
}
