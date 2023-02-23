using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The first 10 natural numbers are: ");
            var list = new List<int>();
            for(int i = 1; i < 11; i++) list.Add(i);
            Console.Write(string.Join(" ", list));
        }
    }
}
