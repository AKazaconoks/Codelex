using System;

namespace Exercise6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sum = 0;
            while (true)
            {
                Console.WriteLine("Please enter a series of single digit numbers");
                string input = Console.ReadLine();
                var allDigits = true;
                foreach (var num in input)
                {
                    if (Char.IsLetter(num))
                    {
                        Console.WriteLine("String contains letter, please use digits only");
                        sum = 0;
                        allDigits = false;
                        break;
                    }
                    else sum += int.Parse(num.ToString());
                }

                if (allDigits) break;
            }
            
            Console.WriteLine("Sum for digits is: " + sum);
        }
    }
}