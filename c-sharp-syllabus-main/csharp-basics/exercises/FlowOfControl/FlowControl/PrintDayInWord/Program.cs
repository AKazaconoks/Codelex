using System;
using System.Collections.Generic;

namespace PrintDayInWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>
            {
                {0, "Sunday"}, {1, "Monday"}, {2, "Tuesday"},
                {3, "Wednesday"}, {4, "Thursday"}, {5, "Friday"}, {6, "Saturday"}
            };
            Console.WriteLine("Please enter a number 0 - 6");
            int day = int.Parse(Console.ReadLine());
            string value = "";
            if(dict.TryGetValue(day, out value)) Console.WriteLine(value);
            else Console.WriteLine("Not a valid day");
        }
    }
}