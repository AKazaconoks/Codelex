using System;

namespace Exercise7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string");
            var input = Console.ReadLine();
            var count = 0;
            foreach(var ch in input)
            {
                count += Char.IsUpper(ch) ? 1 : 0;
            }

            Console.WriteLine("There is " + count + " uppercase characters in input");
        }
    }
}