using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal
{
    internal class Visuals
    {
        public static string[] log = new string[10];

        public Visuals() 
        {
            
        }   
        
        public class Loaders
        {
            public void BalkLoading()
            {
                string commandName = "srvlocal";
                string commandPath = AppDomain.CurrentDomain.BaseDirectory + "srvlocal.exe";

                if (!CommandRegistrar.ConsoleC.IsCommandRegistered(commandName))
                {
                    CommandRegistrar.ConsoleC.RegisterCommand(commandName, commandPath);
                    log[0] = ($"  Command '{commandName}' has been registered with path '{commandPath}'.");
                }
                else
                {
                    log[0] = ($"  You can use this programm also in cmd with \"{commandName}\"");
                }

                Console.CursorVisible = false;

                int counter = 0;
                string[] animationFrames =
                {
                @"  Loading   [                    ]",
                @"  Loading   [=                   ]",
                @"  Loading   [==                  ]",
                @"  Loading   [===                 ]",
                @"  IndexDB   [====                ]",
                @"  IndexDB   [=====               ]",
                @"  Loading   [======              ]",
                @"  Loading   [=======             ]",
                @"  CheckReg  [========            ]",
                @"  CheckReg  [=========           ]",
                @"  Loading   [==========          ]",
                @"  Loading   [===========         ]",
                @"  Fetch     [============        ]",
                @"  Save      [=============       ]",
                @"  Connect   [==============      ]",
                @"  Connect   [===============     ]",
                @"  Connect   [================    ]",
                @"  Login     [=================   ]",
                @"  Login     [==================  ]",
                @"  Get Token [=================== ]",
                @"  Get Token [====================]",
                };

                while (counter < 20)
                {
                    Random rnd = new Random();
                    Console.Title = "Loading srvlocal";
                    Console.Clear();
                    Console.WriteLine(animationFrames[counter % animationFrames.Length] + $" {counter * 5}%");
                    Console.WriteLine();
                    foreach(var l in log)
                    {
                        Console.WriteLine(l);
                    }
                    log[1] = $"  {CommandRegistrar.SetEnvVar()}";
                    System.Threading.Thread.Sleep(rnd.Next(20,200));

                    if (counter == 3) log[2] = $"  Opend Port at {Convert.ToString(GetExternalIPAddress())}:8080";
                    if (counter == 4) log[3] = $"  Opend Port at {Convert.ToString(GetInternalIPAddress())}:8080";
                    if (counter == 18) { log[3] = $"  Requesting Token to Storage Controller (Network (lilo.storage.jwlmt.com))  ";  };
                    if (counter == 19) { Thread.Sleep(rnd.Next(10,250)); }
                    if (counter == 20) { log[4] = $"  SUCCES"; };
                    counter++;
                }

                Console.CursorVisible = true;
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

            public void Spiner()
            {
                Console.CursorVisible = false;

                int counter = 0;
                string[] animationFrames = { "|", "/", "-", "\\" };

                while (counter < 100)
                {
                    Console.Clear();
                    Console.Write("  Loading {0}", animationFrames[counter % animationFrames.Length]);
                    System.Threading.Thread.Sleep(100);
                    counter++;
                }

                Console.CursorVisible = true;
                Console.WriteLine("\nLoading complete!");
            }
        }
    }
}

