using System;

namespace Exercise9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input distance in meters:");
            decimal distance = int.Parse(Console.ReadLine());
            Console.WriteLine("Input hour:");
            var hour = int.Parse(Console.ReadLine());
            Console.WriteLine("Input minutes:");
            var minutes = int.Parse(Console.ReadLine());
            Console.WriteLine("Input seconds:");
            decimal totalSeconds = int.Parse(Console.ReadLine()) + minutes * 60 + hour * 3600;
            decimal ms = distance / totalSeconds;
            decimal kmh = (distance / 1000) / (totalSeconds / 3600);
            decimal mh = (distance / 1609) / (totalSeconds / 3600);
            Console.WriteLine("Your speed in meters/second is " + Math.Round(ms, 8));
            Console.WriteLine("Your speed in km/h is " + Math.Round(kmh, 8));
            Console.WriteLine("Your speed in miles/h is " + Math.Round(mh, 8));
        }
    }
}