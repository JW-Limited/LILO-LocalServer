using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LABLibary.LicenseScheme;

namespace LABLibary.Assistant
{
    public class ReadLicense
    {
        public static Config Read(string file)
        {
            try
            {
                Config config = Config.ReadFromXmlFile(file);

                return config;
            }
            catch (Exception e)
            {
                LABLibary.Forms.ErrorDialog.message[0] = e.Message;
                LABLibary.Forms.ErrorDialog.Show();

                var con = new Config();

                return con; 
            }
            /*
            Console.WriteLine($"StartUpBoost: {config.StartUpBoost}");
            Console.WriteLine($"StartSound: {config.StartSound}");
            Console.WriteLine($"UserId: {config.UserId}");
            Console.WriteLine($"Background: {config.Background}");
            Console.WriteLine($"UserRightStatus: {config.UserRightStatus}");
            Console.WriteLine($"Code: {config.Code}");
            Console.WriteLine($"InstallAgent: {config.InstallAgent}");
            Console.WriteLine($"Assembly.Name: {config.Assembly.Name}");
            Console.WriteLine($"Assembly.Version: {config.Assembly.Version}");
            Console.WriteLine($"Assembly.BuildChannel.Channel: {config.Assembly.BuildChannel.Channel}");
            Console.WriteLine($"Assembly.BuildChannel.DevTools: {config.Assembly.BuildChannel.DevTools}");
            Console.WriteLine($"Assembly.BuildChannel.DevInsight: {config.Assembly.BuildChannel.DevInsight}");
            foreach (Value value in config.Properties.Values)
            {
                Console.WriteLine($"Properties.{value.Name}: {value.Val}");
            }
            */
        }
    }
}
