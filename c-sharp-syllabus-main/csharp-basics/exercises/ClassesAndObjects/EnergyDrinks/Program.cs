using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyDrinks
{
    class Program
    {
        private const int _numberedSurveyed = 12467;
        private const double _purchasedEnergyDrinks = 0.14;
        private const double _preferCitrusDrinks = 0.64;

        private static void Main(string[] args)
        {
            Console.WriteLine("Total number of people surveyed " + _numberedSurveyed);
            Console.WriteLine("Approximately " + EnergyDrinkers(_numberedSurveyed) + " bought at least one energy drink");
            Console.WriteLine(PreferCitrus(_numberedSurveyed) + " of those " + "prefer citrus flavored energy drinks.");
        }

        static double EnergyDrinkers(int numberSurveyed)
        {
            return numberSurveyed * _purchasedEnergyDrinks;
        }

        static double PreferCitrus(int numberSurveyed)
        {
            return EnergyDrinkers(numberSurveyed) * _preferCitrusDrinks;
        }
    }
}
