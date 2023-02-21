using System;

namespace Exercise5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter first word: ");
            var first = Console.ReadLine();
            Console.WriteLine("Enter second word: ");
            var second = Console.ReadLine();
            var result = first;
            for (int i = 0; i < 30 - first.Length - second.Length; i++) result += ".";
            Console.WriteLine(result + second);
        }
    }
}