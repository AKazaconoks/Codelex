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
            Console.WriteLine(string.Join(" ", array.ToHashSet()));
            
            var carDictionary = new Dictionary<string, string>()
            {
                {"Audi", "Germany"}, {"BMW", "Germany"}, {"Honda", "Japan"}, 
                {"Mercedes", "Germany"}, {"VolksWagen", "Germany"}, {"Tesla", "USA"}
            };
            Console.Write(string.Join(" ", carDictionary.Select(x => $"{x.Key} {x.Value}")));
        }
    }
}
