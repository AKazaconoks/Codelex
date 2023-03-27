using Hierarchy;

namespace Polymorphism.Tests;

public class ZebraTests
{
    private Meat _meat;
    private Vegetable _vegetable;
    private Zebra _zebra;
    private StringWriter _stringWriter;

    [SetUp]
    public void Setup()
    {
        _meat = new Meat(10);
        _vegetable = new Vegetable(10);
        _zebra = new Zebra("Jack", "Zebra", 180, "savanna");
        _stringWriter = new StringWriter();
    }

    [Test]
    public void Zebra_EatFood_ShouldNotThrow()
    {
        Assert.DoesNotThrow(() => _zebra.EatFood(_meat));
    }

    [Test]
    public void Zebra_EatFood_ShouldIncreaseFoodEaten()
    {
        _zebra.EatFood(_vegetable);
        var stringParts = _zebra.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(10));
    }

    [Test]
    public void Zebra_EatFood_ShouldNotIncreaseFoodEaten()
    {
        _zebra.EatFood(_meat);
        var stringParts = _zebra.ToString().Split(", ");

        Assert.That(int.Parse(stringParts[stringParts.Length - 1].Replace("]", "")), Is.EqualTo(0));
    }

    [Test]
    public void Zebra_ToString_ShouldReturnCorrectString()
    {
        Assert.That(_zebra.ToString(), Is.EqualTo("Zebra[Jack, 180, savanna, 0]"));
    }

    [Test]
    public void Zebra_MakeSound_ReturnsCorrectSound()
    {
        var expected = "Trrrrrrigogogo";
        var actual = "";
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            _zebra.MakeSound();
            sw.Flush();
            actual = sw.ToString();
        }

        Assert.That(actual.Trim(), Is.EqualTo(expected));
    }

    [Test]
    public void Mouse_EatFood_IncorrectFoodReturnString()
    {
        var expected = "Zebra are not eating that type of food!";
        var actual = "";
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            _zebra.EatFood(_meat);
            sw.Flush();
            actual = sw.ToString();
        }

        Assert.That(actual.Trim(), Is.EqualTo(expected));
    }
}