using System;

namespace Exercise11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(FindNemo("I am finding Nemo !"));
            Console.WriteLine(FindNemo("Nemo is me"));
            Console.WriteLine(FindNemo("I Nemo am"));
            Console.WriteLine(FindNemo("I dont know what is going on here"));
        }

        public static string FindNemo(string input)
        {
            string[] parts = input.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "Nemo") return "I found Nemo at " + (i + 1) + "!";
            }
            return "I can't find Nemo :(";
        }
    }
}