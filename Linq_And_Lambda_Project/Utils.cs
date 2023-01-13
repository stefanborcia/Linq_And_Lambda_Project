using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_And_Lambda_Project
{
     class Utils
    {
        public static void Print(IEnumerable<Laptop> listLaptop)
        {
            foreach (var laptop in listLaptop)
            {
                Console.WriteLine(laptop.ShowDetails());
            }

            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        public static void Print(object[] arr)
        {
            foreach (var laptop in arr)
            {
                Console.Write(laptop + " ");
            }

            Console.WriteLine("\n----------------------------------------------------------------------------------");
        }
        public static void Print(double[] arr)
        {
            foreach (var laptop in arr)
            {
                Console.Write(laptop + " ");
            }

            Console.WriteLine("\n----------------------------------------------------------------------------------");
        }
        // write a method that take a list and a number of elements as parameters and populate that list with the number of elements
        public static List<Laptop> AddLaptops(List<Laptop> list, int number)
        {
            for (int i = 0; i <= number; i++)
            {
                list.Add(LaptopFactory.GenerateLaptop());
            }
            return list;
        }
    }
}
