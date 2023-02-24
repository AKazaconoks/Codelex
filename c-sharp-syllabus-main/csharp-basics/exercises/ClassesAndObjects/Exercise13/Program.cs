using System;

namespace Exercise13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s1 = new Smoothie(new string[] { "Banana" });
            Console.WriteLine(s1.Ingredients());
            Console.WriteLine(s1.getCost());
            Console.WriteLine(s1.getPrice());
            Console.WriteLine(s1.getName());

            var s2 = new Smoothie(new string[] { "Raspberries", "Strawberries", "Blueberries" });
            Console.WriteLine(s2.Ingredients());
            Console.WriteLine(s2.getCost());
            Console.WriteLine(s2.getPrice());
            Console.WriteLine(s2.getName());
        }
    }
}