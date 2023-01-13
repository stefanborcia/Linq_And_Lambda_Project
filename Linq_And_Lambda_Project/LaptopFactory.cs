using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Linq_And_Lambda_Project
{
    class LaptopFactory
    {
        // Here we use the Factory Design Pattern for generating how many laptops we need

        private static Random rnd = new Random();

        private static List<string> brands = new List<string>
            { "Asus", "HP", "Toshiba", "Lenovo", "Dell", "Samsung", "Acer", "Sony", "Apple","MSI", "LG","Huawei","Microsoft"};

        private static List<int> ramList = new List<int> { 8, 16, 32, 4, 24, 12, 20 };

        private static List<string> cpuList = new List<string>
            { "Intel i3", "Intel i5", "Intel i7", "Ryzen 3", "Ryzen 5", "Ryzen 7", "DualCore", "QuadCore" };

        private static List<double> diagonalList = new List<double> { 13.5, 15.3, 17.3, 16.9, 18.2 };

        private static List<double> priceList = new List<double> { 499.99, 359.99, 650.99, 799.99, 1210.99, 1400.00 };
        public static Laptop GenerateLaptop()
        {
            return new Laptop
            (
                brands[rnd.Next(brands.Count)],
                ramList[rnd.Next(ramList.Count)],
                cpuList[rnd.Next(cpuList.Count)],
                diagonalList[rnd.Next(diagonalList.Count)],
                priceList[rnd.Next(priceList.Count)]
            );
            
        }

    }
}
