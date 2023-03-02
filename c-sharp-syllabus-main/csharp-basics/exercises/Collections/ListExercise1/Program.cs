using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExercise1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<string>();
            list.Add("blue");
            list.Add("yellow");
            list.Add("red");
            list.Add("black");
            list.Add("orange");
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
