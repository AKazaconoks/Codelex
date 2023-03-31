using Hierarchy;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Polymorphism.Tests;

public class AnimalTests
{
    private Animal _animal;

    [SetUp]
    public void Setup()
    {
        _animal = new AnimalStub("Test Animal", "Unknown", 10.0);
    }

    [Test]
    public void Animal_MakeSound_DoesNotThrowException()
    {
        Assert.DoesNotThrow(() => _animal.MakeSound());
    }

    [Test]
    public void Animal_EatFood_DoesNotThrowException()
    {
        var food = new FoodStub(1);
        Assert.DoesNotThrow(() => _animal.EatFood(food));
    }

    [Test]
    public void Animal_ToString_ReturnsExpectedString()
    {
        var expected = "Unknown[Test Animal, 10";
        var actual = _animal.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    private class AnimalStub : Animal
    {
        public AnimalStub(string animalName, string animalType, double animalWeight)
            : base(animalName, animalType, animalWeight)
        {
        }
    }

    private class FoodStub : Food
    {
        public FoodStub(int quantity)
            : base(quantity)
        {
        }
        
    }
}