using System;

namespace FuelConsumptionCalculator
{
    public class Car
    {
        private double startKilometers;
        private double endKilometers;
        private double liters;
        private string carName;
        
        public Car(double startKilometers, string carName)
        {
            this.startKilometers = startKilometers;
            this.carName = carName;
        }

        public double CalculateConsumption()
        {
            return Math.Round((this.endKilometers - this.startKilometers) / this.liters, 2);
        }

        public string getName()
        {
            return this.carName;
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
            this.endKilometers = this.startKilometers + mileage;
            this.liters = liters;
        }
    }
}
