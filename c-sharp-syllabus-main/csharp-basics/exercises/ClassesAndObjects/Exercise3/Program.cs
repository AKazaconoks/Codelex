using System;

namespace Exercise3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fg = new FuelGauge();
            var od = new Odometer(fg);
            fg.setFuel(40);
            var i = 0;
            while (i < 450)
            {
                od.Drive();
                Console.WriteLine(od.GetMileage());
                Console.WriteLine(fg.getFuel());
                i++;
            }
        }
    }
}