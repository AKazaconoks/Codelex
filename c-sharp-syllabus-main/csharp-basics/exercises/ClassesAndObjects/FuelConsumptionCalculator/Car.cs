using System;

namespace FuelConsumptionCalculator
{
    public class Car
    {
        private double _startKilometers;
        private double _endKilometers;
        private double _liters;
        private string _carName;
        
        public Car(double startKilometers, string carName)
        {
            _startKilometers = startKilometers;
            _carName = carName;
        }

        public double CalculateConsumption()
        {
            return Math.Round((_endKilometers - _startKilometers) / _liters, 2);
        }

        public string GetName()
        {
            return _carName;
        }

        private double ConsumptionPer100Km()
        {
            return 100 / CalculateConsumption();
        }

        public string CarType()
        {
            return ConsumptionPer100Km() > 15 ? "Gas Hog" : "Economy Car";
        }

        public void FillUp(int mileage, double liters)
        {
            _endKilometers = _startKilometers + mileage;
            _liters = liters;
        }
    }
}
