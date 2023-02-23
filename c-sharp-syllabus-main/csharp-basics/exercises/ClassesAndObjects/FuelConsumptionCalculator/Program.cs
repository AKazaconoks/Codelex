using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelConsumptionCalculator
{
    class Program
    {
        private static void Main(string[] args)
        {
            int startKilometers;
            int liters;
            int mileage;

            var list = new List<Car>();

            while(true)
            {
                Console.WriteLine("Enter car name: ");
                var name = Console.ReadLine();
                Console.Write("Enter first reading: ");
                startKilometers = Convert.ToInt32(Console.ReadLine());    
                Console.Write("Enter liters reading: ");
                liters = Convert.ToInt32(Console.ReadLine());
                Car car = new Car(startKilometers, name);
                Console.Write("Enter mileage: ");
                mileage = Convert.ToInt32(Console.ReadLine());
                car.FillUp(mileage, liters);
                Console.WriteLine("Want to add another car?");
                var input = Console.ReadLine();
                list.Add(car);
                if (input.Contains("n")) break;
            }

            foreach (var car in list)
            {
                Console.WriteLine(car.getName() + " kilometers per liter are " + car.CalculateConsumption() + " car type:" + car.CarType());
            }
            
        }
    }
}
