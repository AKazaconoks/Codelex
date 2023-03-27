using Hierarchy;

namespace Polymorphism.Tests;

public class FoodTests
{
    private Meat _meat;
    private Vegetable _vegetable;
    
    [SetUp]
    public void Setup()
    {
        _meat = new Meat(10);
        _vegetable = new Vegetable(10);
    }
    
    [Test]
    public void Meat_GetFoodQuantity_ShouldReturnCorrectValue()
    {
        var expected = 10;
        var actual = _meat.GetFoodQuantity();
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Vegetable_GetFoodQuantity_ShouldReturnCorrectValue()
    {
        var expected = 10;
        var actual = _vegetable.GetFoodQuantity();
        Assert.That(actual, Is.EqualTo(expected));
    }
}