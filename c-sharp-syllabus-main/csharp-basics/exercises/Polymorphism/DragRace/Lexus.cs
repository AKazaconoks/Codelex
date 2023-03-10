using System;

namespace DragRace
{
    public class Lexus : ICars, IBoost
    {
        private int currentSpeed = 0;

        public void SpeedUp() 
        {
            currentSpeed += 5;
        }

        public void SlowDown() 
        {
            currentSpeed -= 5;
        }

        public string ShowCurrentSpeed() 
        {
            return currentSpeed.ToString();
        }

        public void UseNitrousOxideEngine() 
        {
            currentSpeed += 12;
        }

        public void StartEngine() 
        {
            Console.WriteLine("Rrrrrrr.....");
        }
    }
}