using Hierarchy;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Polymorphism.Tests;

public class MammalTests
{
    private MammalStub _mammal;

    [SetUp]
    public void Setup()
    {
        _mammal = new MammalStub("Test Animal", "Unknown", 10.0, "Unknown");
    }

    [Test]
    public void Mammal_MakeSound_DoesNotThrowException()
    {
        Assert.DoesNotThrow(() => _mammal.MakeSound());
    }

    [Test]
    public void Mammal_EatFood_DoesNotThrowException()
    {
        var food = new FoodStub(1);
        Assert.DoesNotThrow(() => _mammal.EatFood(food));
    }

    [Test]
    public void Mammal_ToString_ReturnsExpectedString()
    {
        var expected = "Unknown[Test Animal, 10, Unknown";
        var actual = _mammal.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }

    private class MammalStub : Mammal
    {
        public MammalStub(string animalName, string animalType, double animalWeight,
            string livingRegion) : base(animalName, animalType, animalWeight,
            livingRegion)
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