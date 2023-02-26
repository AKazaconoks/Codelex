using System;

namespace Exercise6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var max = new Dog("Max", "male");
            var rocky = new Dog("Rocky", "male");
            var sparky = new Dog("Sparky", "male");
            var buster = new Dog("Buster", "male");
            var sam = new Dog("Sam", "male");
            var lady = new Dog("Lady", "male");
            var molly = new Dog("Molly", "male");
            var coco = new Dog("Coco", "male");
            max.SetParents(lady, rocky);
            coco.SetParents(molly, buster);
            rocky.SetParents(molly, sam);
            buster.SetParents(lady, sparky);
            Console.WriteLine(coco.GetName() + "'s father's name is " + coco.FathersName());
            Console.WriteLine(sparky.GetName() + "'s father's name is " + sparky.FathersName());
            Console.WriteLine(coco.HasSameMother(rocky));
        }
    }
}