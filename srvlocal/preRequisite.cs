using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal
{
    internal class Visuals
    {
        public Visuals() 
        {

        }   
        
        public class Loaders
        {
            public void BalkLoading()
            {
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
                    Console.WriteLine(animationFrames[counter % animationFrames.Length]);
                    System.Threading.Thread.Sleep(rnd.Next(50,200));
                    counter++;
                }

                Console.CursorVisible = true;
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

