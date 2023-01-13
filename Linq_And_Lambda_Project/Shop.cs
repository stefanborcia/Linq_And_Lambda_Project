using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Linq_And_Lambda_Project
{
    class Shop
    {
        static void Main(string[] args)
        {
            List<Laptop> laptopList = new List<Laptop>();

            for (int i = 0; i < 15; i++)
            {
                laptopList.Add(LaptopFactory.GenerateLaptop());
            }
            Utils.Print(laptopList);

            // Sort the list by brand using Linq
            var sortedByBrand = from laptop in laptopList orderby laptop.Brand select laptop;
            Utils.Print(sortedByBrand);

            // Sort the list by ram using Linq
            var sortedByRam = from laptop in laptopList orderby laptop.Ram select laptop;
            Utils.Print(sortedByRam);

            // Sort the list by Diagonal using Linq
            var sortedByDiagonal = from laptop in laptopList orderby laptop.Diagonal select laptop;
            Utils.Print(sortedByDiagonal);

            // Sort the list by Price using Lambda
            var sortedByPrice = laptopList.OrderBy(laptop => laptop.Price);
            Utils.Print(sortedByPrice);

            // Sort the list descending by CPU using Lambda
            var sortedByCpu = laptopList.OrderByDescending(laptop => laptop.CPU);
            Utils.Print(sortedByCpu);

            // Filter and how many laptops with Dell brand and over 18 inch diagonal exist - Using Linq
            int result = Query.CheckBiggerDiagonalLaptop(laptopList, "Dell", 18);
            Console.WriteLine($"We have {result} laptop Dell over 18 inch ");

            // Filter and print if there is at least one laptop cheaper than 400euro using Lambda
            var laptopCheaperThan400 = laptopList.Exists(laptop => laptop.Price < 400);
            Console.WriteLine($"We {(laptopCheaperThan400 ? "" : "don't")} have at least one laptop cheaper than 400 on stock");

            // Select and Print all the brands of laptops more expensive than 1000euro using Lambda and an Array
            string [] moreExpensiveThan1000 = laptopList.FindAll(laptop => laptop.Price >= 1000).Select(laptop => laptop.Brand).ToArray();
            Utils.Print(moreExpensiveThan1000);

            // Select and Print all the price from laptop brand Asus in array using Lambda
            double[] priceAsus = laptopList.FindAll(laptop => laptop.Brand == "Asus").Select(laptop => laptop.Price)
                .ToArray();
            Utils.Print(priceAsus);

            // Print all the laptop from the list sort by price and memory ram
            var sortedListByPriceAndRam = laptopList.OrderBy(laptop => laptop.Price).ThenBy(laptop => laptop.Ram);
            Utils.Print(sortedListByPriceAndRam);

            // Print the first laptop from the list which is HP
            bool existHp = laptopList.Exists(laptop => laptop.Brand == "HP");
            if (existHp)
            {
                var laptopHP = laptopList.Find(laptop => laptop.Brand == "HP");
                laptopHP.ShowDetails();
            }
            
            // Clear the list
            laptopList.Clear();
            Utils.Print(laptopList);

            // Add 50 new Laptops in list
            Utils.AddLaptops(laptopList, 50);

            Utils.Print(laptopList);
            // Print all the laptops with user requirements for brand, ram and cpu if exist.

            while (true)
            {
                Console.WriteLine("Welcome to our Shop!");
                Console.WriteLine();

                Console.WriteLine("What brand do you like?");
                string inputBrand = Console.ReadLine();

                Console.WriteLine("How many Gb of memory ram? ");
                int inputRam = int.Parse(Console.ReadLine());

                Console.WriteLine("What kind of Cpu you like?");
                string inputCpu = Console.ReadLine();

                Console.WriteLine("From your information with brand, cpu and ram we have:");

                List<Laptop> userRequiredList = Query.FilterLaptops(laptopList, inputRam, inputBrand, inputCpu);

                if (userRequiredList.Count > 0)
                {
                    Utils.Print(userRequiredList);
                    Console.WriteLine("Which one would you like to buy? Insert Laptop Number:");
                    int numberLaptop = Convert.ToInt32(Console.ReadLine());
                    Laptop chosenLaptop = userRequiredList.Find(laptop => laptop.ID == numberLaptop);
                    Console.WriteLine("You bought the laptop " + chosenLaptop.ShowDetails());
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, we don't have laptop with all your specifications.");
                }
            }
            Console.ReadKey();
        }
    }
}
