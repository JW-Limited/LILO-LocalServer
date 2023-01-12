using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal
{
    using Microsoft.Win32;

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
    }
}
