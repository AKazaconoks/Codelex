namespace Hierarchy
{
    public abstract class Animal
    {
        protected string _animalName;
        protected string _animalType;
        protected double _animalWeight;
        protected int _foodEaten;

        protected Animal(string animalName, string animalType, double animalWeight)
        {
            _animalName = animalName;
            _animalType = animalType;
            _animalWeight = animalWeight;
            _foodEaten = 0;
        }

        public virtual void MakeSound()
        {
        }

        public virtual void EatFood(Food food)
        {
        }

        public virtual string ToString()
        {
            return $"{_animalType}[{_animalName}, {_animalWeight}";
        }
    }
}