using System;

namespace Hierarchy
{
    public class Zebra : Mammal
    {
        public Zebra(string animalName, string animalType, double animalWeight, string livingRegion) :
            base(animalName, animalType, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Trrrrrrigogogo");
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name == "Vegetables")
            {
                _foodEaten += food.GetFoodQuantity();
                Console.WriteLine(ToString());
            }
            else
            {
                Console.WriteLine($"{_animalType} are not eating that type of food!");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {_foodEaten}]";
        }
    }
}