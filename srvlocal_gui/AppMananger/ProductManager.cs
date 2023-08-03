using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    internal class ProductManager
    {
        public static void Main(string[] args)
        {

            string[] user = new string[]
            {
                "Arthur",
                "Guest"
            };

            string[] products = new string[]
            {
                "Stuhl",
                "Tisch",
                "Fenster"
            };

            double[] prdPrice = new double[]
            {
                99.45,
                4423.34,
                3343.23
            };

            Console.Write("Welcome, please provide a Username : ");
            var input = Console.ReadLine();

            if (input is null or "" || user.Contains(input))
            {
                Console.WriteLine("\nPlease provide valid credentials.");
                return;
            }

            Console.Write($"\nPlease provide a valid Password for the User Account \"{input.ToUpper()}\" : ");

            var pswInput = Console.ReadLine();

            if(pswInput is not null) 
            {
                int.TryParse(pswInput, out int value);

                if(value == 12345)
                {
                    Console.WriteLine("We have specials today for you : ");

                    int product = 1;

                    foreach(var item in products) 
                    { 
                        Console.WriteLine($"[{product}] " + item + " - for only : " + prdPrice[product - 1]);

                        product++;  
                    }

                    Console.Write("\n\nPlease provide a valid number : ");

                    var seletedProduct = Console.ReadLine();

                    int.TryParse(seletedProduct, out int buyedProduct);

                    Console.WriteLine($"You succesfully bought \"{products[buyedProduct - 1]}\"");
                }

                else
                {
                    Console.WriteLine("Somethin went wrong!");
                }
            }
        }
    }
}