using System;

namespace Exercise1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            var first = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            var second = int.Parse(Console.ReadLine());
            Console.WriteLine(isFifteen(first, second));
        }

        static bool isFifteen(int first, int second)
        {
            return first == 15 || second == 15 || first + second == 15 || Math.Abs(first - second) == 15;
        }
        
    }
}