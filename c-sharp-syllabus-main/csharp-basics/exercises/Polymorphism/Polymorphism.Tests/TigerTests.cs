using Hierarchy;

namespace Polymorphism.Tests;

public class TigerTests
{
    private Tiger _tiger;
    private Meat _meat;
    private Vegetable _vegetable;
    private StringWriter _stringWriter;

    [SetUp]
    public void Setup()
    {
        _tiger = new Tiger("Richard Parker", "Tiger", 200.0, "jungle");
        _meat = new Meat(10);
        _vegetable = new Vegetable(10);
        _stringWriter = new StringWriter();
    }

    [Test]
    public void Tiger_EatFood_ShouldNotThrow()
    {
        Assert.DoesNotThrow(() => _tiger.EatFood(_meat));
    }

    [Test]
    public void Tiger_EatFood_ShouldIncreaseFoodEaten()
    {
        _tiger.EatFood(_meat);
        var stringParts = _tiger.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(10));
    }
        
    [Test]
    public void Tiger_EatFood_ShouldNotIncreaseFoodEaten()
    {
        _tiger.EatFood(_vegetable);
        var stringParts = _tiger.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(0));
    }

    [Test]
    public void Tiger_ToString_ShouldReturnCorrectString()
    {
        Assert.That(_tiger.ToString(), Is.EqualTo("Tiger[Richard Parker, 200, jungle, 0]"));
    }
    
    [Test]
    public void Animal_MakeSound_ReturnsCorrectSound()
    {
        var expected = "Rrrrrrrrrrr";
        var actual = "";
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            _tiger.MakeSound();
            sw.Flush();
            actual = sw.ToString();
        }

        Assert.That(actual.Trim(), Is.EqualTo(expected));
    }
    
    [Test]
    public void Mouse_EatFood_IncorrectFoodReturnString()
    {
        var expected = "Tiger are not eating that type of food!";
        var actual = "";
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            _tiger.EatFood(_vegetable);
            sw.Flush();
            actual = sw.ToString();
        }
        
        Assert.That(actual.Trim(), Is.EqualTo(expected));
    }
}