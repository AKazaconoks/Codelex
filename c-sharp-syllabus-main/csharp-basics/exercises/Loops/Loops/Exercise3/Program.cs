using System;
using System.Collections.Generic;

namespace Exercise3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 20; )
            {
                int num = random.Next(1, 101);
                if (!list.Contains(num))
                {
                    list.Add(num);
                    i++;
                }
            }
            
            Console.WriteLine("Here are 20 random numbers " + string.Join(" ", list));
            Console.WriteLine("Please enter a number 1 - 100 which position you want to find on list");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(input + " position in list is " + (list.IndexOf(input) + 1));
        }
    }
}