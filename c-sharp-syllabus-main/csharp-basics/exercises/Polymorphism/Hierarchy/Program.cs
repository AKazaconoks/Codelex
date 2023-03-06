using System;
using System.Collections.Generic;

namespace Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isEnd = false;
            var animals = new List<String>();
            while (!isEnd)
            {
                var inputs = Console.ReadLine().Split(" ");
                if (inputs[0] == "End")
                {
                    break;
                }

                var animalObject = CreateAnimalObject(inputs);
                ((Animal)animalObject).MakeSound();
                var foodInputs = Console.ReadLine().Split(" ");
                var foodObject = CreateFoodObject(foodInputs);
                ((Animal)animalObject).EatFood((Food)foodObject);
                var listItem = ((Animal)animalObject).ToString();
                animals.Add(listItem);
            }

            Console.WriteLine(string.Join(", ", animals));
        }

        static object CreateAnimalObject(string[] inputs)
        {
            var type = inputs[0];
            var name = inputs[1];
            var weight = double.Parse(inputs[2]);
            var livingRegion = inputs[3];

            switch (type)
            {
                case "Cat":
                    var breed = inputs[4];
                    return new Cat(name, type, weight, livingRegion, breed);
                case "Tiger":
                    return new Tiger(name, type, weight, livingRegion);
                case "Mouse":
                    return new Mouse(name, type, weight, livingRegion);
                case "Zebra":
                    return new Zebra(name, type, weight, livingRegion);
            }

            return null;
        }

        static object CreateFoodObject(string[] inputs)
        {
            var className = inputs[0];
            var quantity = int.Parse(inputs[1]);

            switch (className)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Meat":
                    return new Meat(quantity);
            }

            return null;
        }
    }
}