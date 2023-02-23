using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberSquare
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Min? ");
            var min = int.Parse(Console.ReadLine());
            Console.Write("Max? ");
            var max = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (int i = min; i <= max; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(string.Join("", list));
                list = list.Skip(1).Concat(list.Take(1)).ToList();
            }
        }
    }
}