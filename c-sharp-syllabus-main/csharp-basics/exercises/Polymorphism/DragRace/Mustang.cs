using System;

namespace DragRace;

public class Mustang : ICars, IBoost
{
    private int _currentSpeed = 0;
    
    public void SpeedUp()
    {
        _currentSpeed += 10;
    }

    public void SlowDown()
    {
        _currentSpeed -= 10;
    }

    public string ShowCurrentSpeed()
    {
        return _currentSpeed.ToString();
    }

    public void StartEngine()
    {
        Console.WriteLine("Vrrrrrrrum...");
    }

    public void UseNitrousOxideEngine()
    {
        _currentSpeed += 12;
    }
}