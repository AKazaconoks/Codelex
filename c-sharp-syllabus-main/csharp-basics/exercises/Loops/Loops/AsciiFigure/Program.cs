using System;

namespace AsciiFigure
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a figure size: ");
            var size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                var line = "";
                if (i == 0)
                {
                    for (int j = 0; j < 4 * (size - 1); j++)
                    {
                        line += "/";
                    }
                    for (int j = 0; j < 4 * (size - 1); j++)
                    {
                        line += "\\";
                    }
                }

                else if (i == size - 1)
                {
                    for (int j = 0; j < 8 * (size - 1); j++)
                    {
                        line += "*";
                    }
                }

                else
                {
                    for (int j = 0; j < 4 * (size - i - 1); j++)
                    {
                        line += "/";
                    }
                    for (int j = 0; j < i * 8; j++)
                    {
                        line += "*";
                    }
                    for (int j = 0; j < 4 * (size - i - 1); j++)
                    {
                        line += "\\";
                    }
                }

                Console.WriteLine(line);
            }
        }
    }
}