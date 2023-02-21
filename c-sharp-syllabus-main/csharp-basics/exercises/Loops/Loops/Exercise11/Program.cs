using System;

namespace Exercise11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ReverseCase("Happy Birthday");
            ReverseCase("MANY THANKS");
            ReverseCase("sPoNtAnEoUs");
        }

        public static void ReverseCase(string input)
        {
            var result = "";
            foreach (var a in input) result += Char.IsLower(a) ? Char.ToUpper(a) : Char.ToLower(a);
            Console.WriteLine(result);
        }
    }
}