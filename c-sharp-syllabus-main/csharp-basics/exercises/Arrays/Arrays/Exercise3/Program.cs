using System;

namespace Exercise3
{
    class Program
    {
        //TODO: Write a C# program to calculate the average value of array elements.
        private static void Main(string[] args)
        {
            int[] numbers = {20, 30, 25, 35, -16, 60, -100};

            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }

            Console.WriteLine("Average value of the array elements is : " + sum / numbers.Length);
        }
    }
}
