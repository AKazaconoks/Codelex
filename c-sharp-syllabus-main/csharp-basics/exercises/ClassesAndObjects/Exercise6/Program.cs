using System;

namespace Exercise6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dog max = new Dog("Max", "male");
            Dog rocky = new Dog("Rocky", "male");
            Dog sparky = new Dog("Sparky", "male");
            Dog buster = new Dog("Buster", "male");
            Dog sam = new Dog("Sam", "male");
            Dog lady = new Dog("Lady", "male");
            Dog molly = new Dog("Molly", "male");
            Dog coco = new Dog("Coco", "male");
            max.setParents(lady, rocky);
            coco.setParents(molly, buster);
            rocky.setParents(molly, sam);
            buster.setParents(lady, sparky);
            Console.WriteLine(coco.getName() + "'s father's name is " + coco.fathersName());
            Console.WriteLine(sparky.getName() + "'s father's name is " + sparky.fathersName());
            Console.WriteLine(coco.hasSameMother(rocky));
        }
    }
}