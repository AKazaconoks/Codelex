using System;

namespace Product1ToN
{
    internal class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine("Enter an end number for factorial");
            var n = int.Parse(Console.ReadLine());
            var sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
            }
            Console.WriteLine("Factorial of " + n + " is " + sum);
        }
    }
}