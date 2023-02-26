using System;
using System.IO;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"..\..\lear.txt");
            var text = sr.ReadToEnd();
            Console.WriteLine($"Lines = {line(text)}");
            Console.WriteLine($"Words = {words(text)}");
            Console.WriteLine($"Chars = {text.Length}");
        }

        static int words(string text)
        {
            return text.Split(' ').Length;
        }

        static int line(string text)
        {
            return text.Split('\n').Length;
        }
    }
}