using System;

namespace TenBillion
{
    class Program
    {
        //TODO Write a C# program that reads an positive integer and count the number of digits the number (less than ten billion) has.
        static void Main(string[] args)
        {
            Console.WriteLine("Input an integer number less than ten billion: ");

            var input = long.Parse(Console.ReadLine());
            if(input <= 0) Console.WriteLine("Number is non positive");
            else if(input >= Math.Pow(10, 10)) Console.WriteLine("Number is larger than ten billion");
            else Console.WriteLine("Number has " + input.ToString().Length + " digits");
        }
    }
}
