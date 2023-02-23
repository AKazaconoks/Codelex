using System;

namespace Exercise10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", CountPosSumNeg(new int []{92, 6, 73, -77, 81, -90, 99, 8, -85, 34})));
            Console.WriteLine(string.Join(", ", CountPosSumNeg(new int[]{91, -4, 80, -73, -28})));
            Console.WriteLine(string.Join(", ", CountPosSumNeg(new int[]{})));
        }

        public static int[] CountPosSumNeg(int[] array)
        {
            if (array.Length == 0) return new int []{};
            else
            {
                var pos = 0;
                var sum = 0;
                foreach (var a in array)
                {
                    pos += a > 0 ? 1 : 0;
                    sum += a < 0 ? a : 0;
                }

                return new int[] { pos, sum };
            }
        }
    }
}