using System;
using System.Linq;

namespace ReplaceSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new[] { "near", "speak", "tonight", "weapon", "customer", "deal", "lawyer" };
            Console.WriteLine(string.Join(" ", words.Select(x => x.Replace("ea", "*"))));
        }
    }
}
