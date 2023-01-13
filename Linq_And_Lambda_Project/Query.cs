using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_And_Lambda_Project
{
    class Query
    {
        // write a method that take a list, a ram, a brand and a cpu as parameters and filter that list related the parameters
        public static List<Laptop> FilterLaptops(List<Laptop> list, int ram, string brand, string cpu)
        {
            List<Laptop> filteredList = new List<Laptop>();

            bool existFilteredLaptop = list
                .Where(laptop => laptop.Brand == brand)
                .Where(laptop => laptop.Ram == ram)
                .Any(laptop => laptop.CPU == cpu);

            if (existFilteredLaptop)
            {
                filteredList = list
                    .FindAll(laptop => laptop.Brand == brand)
                    .FindAll(laptop => laptop.Ram == ram)
                    .FindAll(laptop => laptop.CPU == cpu);
            }
            return (List<Laptop>)filteredList;  // Explicit cast
        }

        // Write a method that takes a list a brand and diagonal and returns true if a laptop bigger than diagonal and related to brand exist.
        public static int CheckBiggerDiagonalLaptop(List<Laptop> laptopList, string brand, double diagonal)
        {
            var laptopsDellOver18 = from laptop in laptopList
                                    where laptop.Brand == brand
                                    where laptop.Diagonal >= diagonal
                                    select laptop;
            var result = laptopsDellOver18.Count();
            return result;
        }
    }
}
