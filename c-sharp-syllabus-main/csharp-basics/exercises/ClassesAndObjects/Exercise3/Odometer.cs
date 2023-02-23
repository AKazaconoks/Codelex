using System;

namespace Exercise3
{
    public class Odometer
    {
        private int mileage;
        private FuelGauge fg;

        public Odometer(FuelGauge fg)
        {
            this.fg = fg;
        }

        public void setMileage(int mileage)
        {
            this.mileage = mileage;
        }

        public int getMileage()
        {
            return this.mileage;
        }

        public void drive()
        {
            if (fg.getFuel() > 0) this.mileage = this.mileage == 999999 ? 0 : ++this.mileage;
            else Console.WriteLine("Not enough fuel");
            impactFuel();
        }

        public void impactFuel()
        {
            if(this.mileage % 10 == 0) fg.decreaseFuel();
        }
    }
}