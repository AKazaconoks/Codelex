using System;

namespace Exercise4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Write your name");
            string name = Console.ReadLine();
            Console.WriteLine("Write your year of birth");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("My name is " + name + " and I was born in " + year +".");
        }
    }
}