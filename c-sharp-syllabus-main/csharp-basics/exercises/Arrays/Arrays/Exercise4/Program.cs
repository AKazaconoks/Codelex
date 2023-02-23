using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        //TODO: Write a C# program to test if an array contains a specific value.
        private static void Main(string[] args)
        {
            int[] myArray =
            {
                1789, 2035, 1899, 1456, 2013,
                1458, 2458, 1254, 1472, 2365,
                1456, 2265, 1457, 2456
            };
            Console.WriteLine("Enter a value to check if it is in an array");
            int value = int.Parse(Console.ReadLine());
            bool contains = false;
            foreach (var num in myArray)
            {
                if (num == value) contains = true;
            }

            if(contains) Console.WriteLine("Array contains " + value);
            else Console.WriteLine("Array does not contain " + value);
        }
    }
}
