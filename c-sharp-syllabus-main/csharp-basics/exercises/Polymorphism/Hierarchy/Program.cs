using System;
using System.Collections.Generic;

namespace Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var isEnd = false;
            var animals = new List<String>();
            while (!isEnd)
            {
                var inputs = Console.ReadLine().Split(" ");
                if (inputs[0] == "End")
                {
                    break;
                }
                
                object[] ctor;
                ctor = inputs[0] == "Cat"
                    ? new object[] { inputs[1], inputs[0], double.Parse(inputs[2]), inputs[3], inputs[4] }
                    : new object[] { inputs[1], inputs[0], double.Parse(inputs[2]), inputs[3] };
                var animalObject = Activator.CreateInstance(Type.GetType("Hierarchy." + inputs[0]), ctor);
                ((Animal)animalObject).MakeSound();
                var foodInputs = Console.ReadLine().Split(" ");
                var foodObject = Activator.CreateInstance(Type.GetType("Hierarchy." + foodInputs[0]), int.Parse(foodInputs[1]));
                ((Animal)animalObject).EatFood((Food)foodObject);
                var listItem = ((Animal)animalObject).ToString();
                animals.Add(listItem);
            }

            Console.WriteLine(string.Join(", ", animals));
        }
    }
}