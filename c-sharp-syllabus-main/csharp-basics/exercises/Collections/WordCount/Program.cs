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
            Console.WriteLine($"Lines = {CountLines(text)}");
            Console.WriteLine($"Words = {CountWords(text)}");
            Console.WriteLine($"Chars = {text.Length}");
        }

        static int CountWords(string text)
        {
            return text.Split(' ').Length;
        }

        static int CountLines(string text)
        {
            return text.Split('\n').Length;
        }
    }
}