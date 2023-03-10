using System;

namespace Hierarchy
{
    public class Cat : Felime
    {
        private string _catBreed;

        public Cat(string animalName, string animalType, double animalWeight, string livingRegion, string catBreed) :
            base(animalName, animalType, animalWeight, livingRegion)
        {
            _catBreed = catBreed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowww");
        }

        public override void EatFood(Food food)
        {
            _foodEaten += food.GetFoodQuantity();
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {_catBreed}, {_foodEaten}]";
        }
    }
}