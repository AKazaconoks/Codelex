using Hierarchy;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Polymorphism.Tests;

public class FelimeTests
{
    private FelimeStub _felime;

    [SetUp]
    public void Setup()
    {
        _felime = new FelimeStub("Test Animal", "Unknown", 10.0, "Unknown");
    }

    [Test]
    public void Mammal_MakeSound_DoesNotThrowException()
    {
        Assert.DoesNotThrow(() => _felime.MakeSound());
    }

    [Test]
    public void Mammal_EatFood_DoesNotThrowException()
    {
        var food = new FoodStub(1);
        Assert.DoesNotThrow(() => _felime.EatFood(food));
    }

    [Test]
    public void Mammal_ToString_ReturnsExpectedString()
    {
        var expected = "Unknown[Test Animal, 10, Unknown";
        var actual = _felime.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    private class FelimeStub : Felime
    {
        public FelimeStub(string animalName, string animalType, double animalWeight, string livingRegion) : base(animalName,
            animalType, animalWeight, livingRegion)
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