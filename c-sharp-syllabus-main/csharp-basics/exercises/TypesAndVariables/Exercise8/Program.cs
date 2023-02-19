using System;

namespace Exercise8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter seconds amount");
            var seconds = int.Parse(Console.ReadLine());
            int days = seconds / (60 * 60 * 24);
            int years = days >= 365 ? days / 365 : 0;
            Console.WriteLine("There is " + years + " years and " + (days - years * 365) + " days in " + seconds + " seconds");
        }
    }
}