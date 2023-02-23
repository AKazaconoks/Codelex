using System;

namespace VariablesAndNames
{
    class Program
    {
        private static void Main(string[] args)
        {
            int cars = 100;
            int drivers = 28;
            int passengers= 90;
            int carsNotDriven = cars - drivers;
            int carsDriven = drivers;
            int seatsInACar = 4;
            int carPoolCapacity = seatsInACar * carsDriven;
            double averagePassengersPerCar = 1.0 * passengers / carsDriven;

            Console.WriteLine("There are " + cars + " cars available.");
            Console.WriteLine("There are only " + drivers + " drivers available.");
            Console.WriteLine("There will be " + carsNotDriven + " empty cars today.");
            Console.WriteLine("We can transport " + carPoolCapacity + " people today.");
            Console.WriteLine("We have " + passengers + " to carpool today.");
            Console.WriteLine("We need to put about " + Math.Round(averagePassengersPerCar, 2) + " in each car.");
            Console.ReadKey();
        }
    }
}