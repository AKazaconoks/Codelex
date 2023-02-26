using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        private const string Path = @"../../midtermscores.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path).SelectMany(x => x.Split(' ')).ToArray();
            Console.WriteLine($"00 - 09: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 0 and < 10))}");
            Console.WriteLine($"10 - 19: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 10 and < 20))}");
            Console.WriteLine($"20 - 29: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 20 and < 30))}");
            Console.WriteLine($"30 - 39: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 30 and < 40))}");
            Console.WriteLine($"40 - 49: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 40 and < 50))}");
            Console.WriteLine($"50 - 59: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 50 and < 60))}");
            Console.WriteLine($"60 - 69: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 60 and < 70))}");
            Console.WriteLine($"70 - 79: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 70 and < 80))}");
            Console.WriteLine($"80 - 89: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 80 and < 90))}");
            Console.WriteLine($"90 - 99: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is >= 90 and < 100))}");
            Console.WriteLine($"100: {new string('*', readText.Count(x => int.TryParse(x, out var r) && r is 100))}");
        }
    }
}
