using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal
{
    using Microsoft.Win32;
    using System.Diagnostics;

    class CommandRegistrar
    {
        public static void RegisterCommand(string commandName, string commandPath)
        {
            string path = Environment.GetEnvironmentVariable("PATH");
            path = commandPath + ";" + path;
            Environment.SetEnvironmentVariable("PATH", path);

            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Command Processor", true);
            key.SetValue("AutoRun", "%COMSPEC% /k " + commandName);
        }

        public static void UnregisterCommand(string commandName)
        {
            string path = Environment.GetEnvironmentVariable("PATH");
            string[] paths = path.Split(';');
            path = "";
            for (int i = 0; i < paths.Length; i++)
            {
                if (paths[i] != commandName)
                {
                    path += paths[i] + ";";
                }
            }
            Environment.SetEnvironmentVariable("PATH", path);
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Command Processor", true);
            key.DeleteValue("AutoRun", false);
        }

        public static string SetEnvVar()
        {
            string variableName = "srvlocal";
            string variableValue = AppDomain.CurrentDomain.BaseDirectory + "srvlocal.exe";

            if (Environment.GetEnvironmentVariable(variableName) == null)
            {
                Environment.SetEnvironmentVariable(variableName, variableValue);
                return($"Environment variable '{variableName}' has been created.");
            }
            else
            {
                return($"Environment variable '{variableName}' already exists.");
            }
        }

        public class ConsoleC
        {
            public static bool IsCommandRegistered(string commandName)
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = $"/c where {commandName}";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    return !string.IsNullOrEmpty(output);
                }
            }

            public static void RegisterCommand(string commandName, string commandPath)
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "reg.exe";
                    process.StartInfo.Arguments = $"add HKCU\\Software\\Microsoft\\Command Processor /v AutoRun /t REG_SZ /d \"\"\"{commandPath}\"\"\" /f";
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                    process.WaitForExit();
                }
            }
        }
    }


}
