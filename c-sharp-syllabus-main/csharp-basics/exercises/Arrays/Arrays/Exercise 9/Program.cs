using System;

namespace Exercise_9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CapMe(new string[]{"mavis", "senaida", "letty"});
            CapMe(new string[]{"samuel", "MABELLE", "letitia", "meridith"});
            CapMe( new string[]{"Slyvia", "Kristal", "Sharilyn", "Calista"});
        }

        public static void CapMe(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
               array[i] = Char.ToUpper(array[i][0]) + array[i].Substring(1).ToLower();
            } 
           
            Console.WriteLine(string.Join(", ", array));
        }
    }
}