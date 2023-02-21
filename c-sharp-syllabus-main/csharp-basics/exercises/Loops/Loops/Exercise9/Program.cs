using System;

namespace Exercise9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Desired sum: ");
            var input = int.Parse(Console.ReadLine());
            Random random = new Random();
            while (true)
            {
                var first = random.Next(1, 7);
                var second = random.Next(1, 7);
                Console.WriteLine(first + " and " + second + " = " + (first + second));
                if (first + second == input) break;
            }
        }
    }
}