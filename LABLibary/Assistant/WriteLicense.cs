using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static LABLibary.LicenseScheme;

namespace LABLibary.Assistant
{
    public class WriteLicense
    {
        public static void Write(string dir)
        {
            Config config = new Config()
            {
                License_Engine = new LicenseEngine()
                {
                    Version = 2,
                    Scheme = "LAB-LICENSE-SCHEME-23"
                },
                StartUpBoost = true,
                StartSound = true,
                UserId = 32956,
                Background = "default",
                UserRightStatus = "default",
                Code = LicenseGenerator.GenerateCode("lab-suite", "trail",DateTime.Now.AddDays(30)),
                InstallAgent = true,
                Assembly = new Assembly()
                {
                    Name = "LILO App Builder (LAB)",
                    Version = "Suite",
                    BuildChannel = new BuildChannel()
                    {
                        Channel = "dev_preview",
                        DevTools = true,
                        DevInsight = true
                    }
                },
                Properties = new Properties()
                {
                    Values = new Value[]
                    {
                        new Value() { Name = "KeyClass", Val = "7" },
                        new Value() { Name = "KeyType", Val = "1" },
                        new Value() { Name = "ReferencePitch", Val = "440.1941223144531" }
                    }
                }
            };

            config.WriteToXmlFile(dir + "\\license.labl");
        }
    }

}
 