using System;
using System.Linq;

namespace Exercise6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 101);
            }
            
            int[] array2 = new int[10];
            Array.Copy(array, array2, array.Length);
            array2[9] = -7;
            Console.WriteLine("Array 1: " + string.Join(" ", array));
            Console.WriteLine("Array 2: " + string.Join(" ", array2));
        }
    }
}