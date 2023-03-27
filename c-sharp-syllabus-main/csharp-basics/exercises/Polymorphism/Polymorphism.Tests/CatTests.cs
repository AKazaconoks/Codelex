using Hierarchy;

namespace Polymorphism.Tests;

public class CatTests
{
    private Cat _cat;
    private Meat _meat;
    private Vegetable _vegetable;
    private StringWriter _stringWriter;

    [SetUp]
    public void Setup()
    {
        _cat = new Cat("Kitty", "Cat", 2.0, "Home", "Domestic");
        _meat = new Meat(10);
        _vegetable = new Vegetable(10);
        _stringWriter = new StringWriter();
    }
    
    [Test]
    public void Cat_EatMeat_ShouldIncreaseFoodEaten()
    {
        _cat.EatFood(_meat);
        var stringParts = _cat.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(10));
    }
        
    [Test]
    public void Cat_EatVegetable_ShouldNotIncreaseFoodEaten()
    {
        _cat.EatFood(_vegetable);
        var stringParts = _cat.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(10));
    }

    [Test]
    public void Cat_ToString_ShouldReturnCorrectString()
    {
        var expected = "Cat[Kitty, 2, Home, Domestic, 0]";
        var actual = _cat.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Cat_MakeSound_ReturnsCorrectSound()
    {
        var expected = "Meowww";
        _cat.MakeSound();
        var actual = "";
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            _cat.MakeSound();
            sw.Flush();
            actual = sw.ToString();
        }

        Assert.That(actual.Trim(), Is.EqualTo(expected));
    }
}