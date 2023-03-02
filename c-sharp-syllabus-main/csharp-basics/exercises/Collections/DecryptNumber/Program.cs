using System;
using System.Collections.Generic;

namespace DecryptNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cryptedNumbers = new List<string>
            {
                "())(",
                "*$(#&",
                "!!!!!!!!!!",
                "$*^&@!",
                "!)(^&(#@",
                "!)(#&%(*@#%"
            };
            
            Dictionary<char, string> dict = new ()
            {
                ['('] = "9",
                [')'] = "0",
                ['!'] = "1",
                ['@'] = "2",
                ['#'] = "3",
                ['$'] = "4",
                ['%'] = "5",
                ['^'] = "6",
                ['&'] = "7",
                ['*'] = "8"
            };
            
            foreach (var s in cryptedNumbers)
            {
                var result = "";
                foreach (var ch in s)
                {
                    if (dict.TryGetValue(ch, out var value)) result += value;
                }
                
                Console.WriteLine(result);
            }
        }
    }
}
