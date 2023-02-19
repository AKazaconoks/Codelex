using System;

namespace MoreVariablesAndPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "Zed A. Shaw";
            var eyes = "Blue"; 
            var teeth = "White"; 
            var hair = "Brown";
            var age = 35;
            var height = Math.Round(74 * 2.54, 2); 
            var weight = Math.Round(180 * 0.453592, 2);
            
            Console.WriteLine("Let's talk about " + name + ".");
            Console.WriteLine("He's " + height + " centimeters tall.");
            Console.WriteLine("He's " + weight + " kilograms heavy.");
            Console.WriteLine("Actually, that's not too heavy.");
            Console.WriteLine("He's got " + eyes + " eyes and " + hair + " hair.");
            Console.WriteLine("His teeth are usually " + teeth + " depending on the coffee.");

            Console.WriteLine("If I add " + age + ", " + height + ", and " + weight
                               + " I get " + (age + height + weight) + ".");

            Console.ReadKey();
        }
    }
}