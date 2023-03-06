namespace Hierarchy
{
    public class Felime : Mammal
    {
        public Felime(string animalName, string animalType, double animalWeight, string livingRegion) :
            base(animalName, animalType, animalWeight,  livingRegion)
        {
        }
        
        public override void MakeSound()
        {
        }

        public override void EatFood(Food food)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}