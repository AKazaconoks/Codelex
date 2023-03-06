namespace Hierarchy
{
    public abstract class Mammal : Animal
    {
        private string _livingRegion;

        protected Mammal(string animalName, string animalType, double animalWeight,
            string livingRegion) : base(animalName,
            animalType, animalWeight)
        {
            _livingRegion = livingRegion;
            _foodEaten = 0;
        }

        public override void MakeSound()
        {
        }

        public override void EatFood(Food food)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {_livingRegion}";
        }
    }
}