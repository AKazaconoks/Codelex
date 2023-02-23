using System;

namespace Exercise2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            bool isEven = int.Parse(Console.ReadLine()) % 2 == 0;
            if (isEven) Console.WriteLine("Even Number");
            else Console.WriteLine("Odd Number");
            Console.WriteLine("bye!");
        }
    }
}