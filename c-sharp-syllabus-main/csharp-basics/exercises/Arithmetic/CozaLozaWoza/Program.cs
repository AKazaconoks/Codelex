using System;

namespace CozaLozaWoza
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var line = "";
            for (int j = 1; j <= 110; j++)
            {
                if (j % 3 == 0 && j % 5 == 0 && j % 7 == 0) line += "CozaLozaWoza ";
                else if (j % 3 == 0 && j % 5 == 0) line += "CozaLoza ";
                else if (j % 3 == 0 && j % 5 == 0) line += "CozaWoza ";
                else if (j % 5 == 0 && j % 7 == 0) line += "LozaWoza ";
                else if (j % 3 == 0) line += "Coza ";
                else if (j % 5 == 0) line += "Loza ";
                else if (j % 7 == 0) line += "Woza ";
                else line += j + " ";
                if (j % 11 == 0)
                {
                    Console.WriteLine(line.Trim());
                    line = "";
                }
            }
        }
    }
}