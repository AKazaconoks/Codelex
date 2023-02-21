using System;

namespace Piglet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Play();
        }

        public static void Play()
        {
            Console.WriteLine("Welcome to Piglet!");
            Random random = new Random();
            var rolled = 0;
            var points = 0;
            while (true)
            {
                rolled = random.Next(1, 7);
                points += rolled;
                Console.WriteLine("You rolled " + rolled);
                if (rolled == 1)
                {
                    points = 0; 
                    break;
                }
                Console.Write("Roll again? ");
                if (Console.ReadLine().Contains("n")) break;
            }

            Console.WriteLine("You got " + points + " points.");
            Console.WriteLine("Wanna play again?");
            if (Console.ReadLine().Contains("y")) Play();
            else Console.WriteLine("Goodbye!");
        }
    }
}