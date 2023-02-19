using System;
using System.Collections.Generic;

namespace Exercise5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            while (true)
            {
                Console.WriteLine("Please provide the name of class");
                string className = Console.ReadLine();
                Console.WriteLine("Please provide the name of teacher");
                string teacherName = Console.ReadLine();
                dict.Add(className, teacherName);
                Console.WriteLine("Are you done? y/n");
                string input = Console.ReadLine();
                if (input == "y") break;
            }

            int i = 1;
            Console.WriteLine("+------------------------------------------------------------+");
            foreach (var key in dict.Keys)
            {
                string classColumn = "";
                for (int j = 0; j < 26 - key.Length - 1; j++)
                {
                    classColumn += " ";
                }

                classColumn += key + " ";
                string teacherColumn = "";
                string value;
                if(dict.TryGetValue(key, out value)) {
                    for (int j = 0; j < 15 - value.Length - 1; j++)
                    {
                        teacherColumn += " ";
                    }

                    teacherColumn += value + " ";
                    Console.WriteLine("| " + i + " |" + classColumn + "|" + teacherColumn + "|");
                }

                i++;
            }
            Console.WriteLine("+------------------------------------------------------------+");
        }
    }
}