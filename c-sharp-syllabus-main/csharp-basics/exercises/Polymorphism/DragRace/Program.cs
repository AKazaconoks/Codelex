using System;
using System.Collections.Generic;
using System.Linq;

namespace DragRace
{
    class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<ICars>
            {
                new Ford(),
                new Bmw(),
                new Audi(),
                new Lexus(),
                new Mustang(),
                new Tesla()
            };

            for (var i = 0; i < 10; i++)
            {
                foreach (var car in cars)
                {
                    car.SpeedUp();
                    if (i == 2 && car is IBoost)
                    {
                        ((IBoost)car).UseNitrousOxideEngine();
                    }
                }
            }

            var fastest = cars.OrderByDescending(c => int.Parse(c.ShowCurrentSpeed())).First();

            Console.WriteLine($"Fastest car is {fastest.GetType().Name} with a speed of {fastest.ShowCurrentSpeed()}");
        }
    }
}