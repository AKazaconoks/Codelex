using System;

namespace Exercise9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter your weight in grams");
            var weight = double.Parse(Console.ReadLine()) * 0.00220462;
            Console.WriteLine("Please enter your height in meters");
            var height = double.Parse(Console.ReadLine()) * 39.3701;
            var bmi = weight * 703 / (height * height);
            if(bmi < 18.5) Console.WriteLine("You are underweight" + ", your BMI is " + bmi);
            else if (bmi > 25) Console.WriteLine("You are overweight" + ", your BMI is " + bmi);
            else Console.WriteLine("You have optimal weight" + ", your BMI is " + bmi);
        }
    }
}