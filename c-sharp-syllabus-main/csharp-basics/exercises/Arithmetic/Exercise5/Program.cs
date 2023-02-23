using System;

namespace Exercise5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("I'm thinking of a number between 1-100.  Try to guess it.");
            int n = new Random().Next(1, 101);
            var input = int.Parse(Console.ReadLine());
            if(n == input) Console.WriteLine("You guessed it!  What are the odds?!?");
            else if (n > input) Console.WriteLine("Sorry, you are too low.  I was thinking of " + n + ".");
            else Console.WriteLine("Sorry, you are too high.  I was thinking of " + n + ".");
        }
    }
}