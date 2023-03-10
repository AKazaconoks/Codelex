using System;

namespace DragRace;

public class Ford : ICars
{
    private int _currentSpeed = 0;
    public void SpeedUp()
    {
        _currentSpeed += 4;
    }

    public void SlowDown()
    {
        _currentSpeed -= 4;
    }

    public string ShowCurrentSpeed()
    {
        return _currentSpeed.ToString();
    }

    public void StartEngine()
    {
        Console.WriteLine("Trrrrmm...");
    }
}