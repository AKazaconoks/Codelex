using Hierarchy;

namespace Polymorphism.Tests;

public class MouseTests
{
    private Mouse _mouse;
    private Meat _meat;
    private Vegetable _vegetable;
    private StringWriter _stringWriter;

    [SetUp]
    public void Setup()
    {
        _mouse = new Mouse("Jerry", "Mouse", 0.1, "Home");
        _meat = new Meat(10);
        _vegetable = new Vegetable(10);
        _stringWriter = new StringWriter();
    }

    [Test]
    public void Mouse_EatFood_ShouldNotThrow()
    {
        Assert.DoesNotThrow(() => _mouse.EatFood(_vegetable));
    }

    [Test]
    public void Mouse_EatFood_ShouldIncreaseFoodEaten()
    {
        _mouse.EatFood(_vegetable);
        var stringParts = _mouse.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(10));
    }

    [Test]
    public void Mouse_EatFood_ShouldNotIncreaseFoodEaten_IfFoodIsNotVegetables()
    {
        _mouse.EatFood(_meat);
        var stringParts = _mouse.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(0));
    }
    
    [Test]
    public void Mouse_MakeSound_ReturnsCorrectSound()
    {
        var expected = "Pipipipi";
        var actual = "";
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            _mouse.MakeSound();
            sw.Flush();
            actual = sw.ToString();
        }

        Assert.That(actual.Trim(), Is.EqualTo(expected));
    }

    [Test]
    public void Mouse_EatFood_IncorrectFoodReturnString()
    {
        var expected = "Mouse are not eating that type of food!";
        var actual = "";
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            _mouse.EatFood(_meat);
            sw.Flush();
            actual = sw.ToString();
        }
        
        Assert.That(actual.Trim(), Is.EqualTo(expected));
    }
}