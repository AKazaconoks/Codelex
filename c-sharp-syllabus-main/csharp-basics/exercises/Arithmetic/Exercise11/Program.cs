using System;
using System.Reflection;

namespace Exercise11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Moran(132);
            Moran(133);
            Moran(134);
        }

        public static void Moran(int n)
        {
            var sum = 0;
            foreach (var num in n.ToString())
            {
                sum += int.Parse(num.ToString());
            }
            
            var isPrime = true;
            for (int i = 2; i < n / sum / 2; i++)
            {
                if ((n / sum) % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine(isPrime ? "M" : n % sum == 0 ? "H" : "Neither");
        }
    }
}