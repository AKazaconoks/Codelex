using System;

namespace Exercise3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FuelGauge fg = new FuelGauge();
            Odometer od = new Odometer(fg);
            fg.setFuel(40);
            var i = 0;
            while (i < 450)
            {
                od.drive();
                Console.WriteLine(od.getMileage());
                Console.WriteLine(fg.getFuel());
                i++;
            }
        }
    }
}