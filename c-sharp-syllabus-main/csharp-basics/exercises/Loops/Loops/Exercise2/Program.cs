using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n;
            
            Console.WriteLine("Input number of terms : ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input number to multiply : ");
            i = int.Parse(Console.ReadLine());
            var result = i;
            /*
            todo - complete loop to multiply i with itself n times, it is NOT allowed to use Math.Pow()
            */
            for (int j = 0; j < n; j++)
            {
                result *= i;
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
