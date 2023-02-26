using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        /**
           * Origination:
           * Audi -> Germany
           * BMW -> Germany
           * Honda -> Japan
           * Mercedes -> Germany
           * VolksWagen -> Germany
           * Tesla -> USA
           */

        private static void Main(string[] args)
        {
            string[] array = { "Audi", "BMW", "Honda", "Mercedes", "VolksWagen", "Mercedes", "Tesla" };
            Console.WriteLine(string.Join(" ", array.ToList()));
            //todo - replace array with a HashSet and print out the results
            Console.WriteLine(string.Join(" ", array.ToHashSet()));
            //todo - replace array with a Dictionary (use brand as key and origination as value) and print out the results
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"Audi", "Germany"}, {"BMW", "Germany"}, {"Honda", "Japan"}, 
                {"Mercedes", "Germany"}, {"VolksWagen", "Germany"}, {"Tesla", "USA"}
            };
            Console.Write(string.Join(" ", dict.Select(x => $"{x.Key} {x.Value}")));
        }
    }
}
