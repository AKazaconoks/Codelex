using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyDrinks
{
    class Program
    {
        private const int NumberedSurveyed = 12467;
        private const double PurchasedEnergyDrinks = 0.14;
        private const double PreferCitrusDrinks = 0.64;

        private static void Main(string[] args)
        {
            Console.WriteLine("Total number of people surveyed " + NumberedSurveyed);
            Console.WriteLine("Approximately " + energyDrinkers(NumberedSurveyed) + " bought at least one energy drink");
            Console.WriteLine(preferCitrus(NumberedSurveyed) + " of those " + "prefer citrus flavored energy drinks.");
        }

        static double energyDrinkers(int numberSurveyed)
        {
            return numberSurveyed * 0.14;
        }

        static double preferCitrus(int numberSurveyed)
        {
            return energyDrinkers(numberSurveyed) * 0.64;
        }
    }
}
