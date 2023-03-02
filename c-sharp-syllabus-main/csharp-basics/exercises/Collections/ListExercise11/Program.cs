using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>()
            {
                "Un", "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept", "Huit", "Neuf", "Dix"
            };
            
            list.Insert(4, "Bonbon");
            list[list.Count - 1] = "Neu";
            list.Sort();
            
            Console.WriteLine(list.Contains("Foobar") ? "List contains foobar" : "List does not contain foobar");
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
