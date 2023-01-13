using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_And_Lambda_Project
{
    class Laptop
    {
        public int ID { get; set; }
        private static int counterID = 0;
        public string Brand { get; set; }
        public int Ram { get; set; }
        public string CPU { get; set; }
        public double Diagonal { get; set; }
        public double Price { get; set; }

        public Laptop(string brand, int ram, string cpu, double diagonal, double price)
        {
            Brand = brand;
            Ram = ram;
            CPU = cpu;
            Diagonal = diagonal;
            Price = price;
            ID = ++counterID;
        }

        public string ShowDetails()
        {
            return $"Laptop {ID}, brand {Brand}, with ram {Ram} and cpu {CPU} has diagonal {Diagonal} and cost {Price:C}";
        }
    }
}
