using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local
{
    internal class Menu
    {
        public Menu() 
        {
            Console.WriteLine("\nLILO© LocalServer Host Application by JW Limited®:");
            Console.WriteLine("----------------");
        }

        int top = Console.CursorTop;
        int left = Console.CursorLeft;

        //-----------
        // Menu Items
        //-----------

        public string[] menuItems = { "Start", "Advanced Start", "Account", "Settings", "Help", "Quit" };

        public void Show()
        {
            ConsoleKeyInfo key;
            int selectedIndex = 0;
            

            

            do
            {

                //---------------------------
                // Show the Items in Console
                //---------------------------

                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.CursorTop = top + 4 + i;
                    Console.CursorLeft = left;
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                key = Console.ReadKey();

                //----------------------------
                // Switch betwen the MenuItems
                //----------------------------

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0)
                        {
                            selectedIndex--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex < menuItems.Length - 1)
                        {
                            selectedIndex++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        //Console.WriteLine("\nYou selected " + menuItems[selectedIndex]);
                        Handler(menuItems[selectedIndex]);
                        selectedIndex = 5;
                        break;
                }
            } 
            while (key.Key != ConsoleKey.Escape && menuItems[selectedIndex] != "Quit");

        }

        private void Handler(string selectedMenuItem)
        {
            string[] args = {

            };

            if (selectedMenuItem == menuItems[0])
            {
                Console.Clear();
                Console.CursorTop = top;
                Console.CursorLeft = left;

                Console.WriteLine("We Setting all up...");

                Console.CursorTop = top + 2;
                Console.CursorLeft = left;

                var loaders = new srvlocal.Visuals.Loaders();
                loaders.BalkLoading();
                Console.Clear();
                Server.menu = false;
                Server.Main(args);
            }
            else if (selectedMenuItem == menuItems[1])
            {

            }
            else if (selectedMenuItem == menuItems[2])
            {

            }
            else if (selectedMenuItem == menuItems[3])
            {
                Process.Start("explorer.exe","srvlocal.runtimeconfig.json");
                Process.Start("explorer.exe", "documentation.xml");
                Show();
            }
            else
            {
                Show();
            }
        }
    }
}
