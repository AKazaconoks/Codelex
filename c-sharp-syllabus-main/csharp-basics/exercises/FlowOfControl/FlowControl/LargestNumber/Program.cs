using System;

namespace LargestNumber
{
    class Program
    {
        //TODO: Write a C# program to to find the largest of three numbers.
        static void Main(string[] args)
        {
            Console.WriteLine("Input the 1st number: ");
            var input1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the 2nd number: ");
            var input2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the 3rd number: ");
            var input3 = int.Parse(Console.ReadLine());
        
            /*
            todo - expected output:
            Input the 1st number: 25
            Input the 2nd number: 78
            Input the 3rd number: 87
             */
            Console.WriteLine("Largest number is " + Math.Max(input1, Math.Max(input2, input3)));
        }
    }
}
