using System;

namespace Exercise3
{
    public class Odometer
    {
        private int _mileage;
        private FuelGauge _fg;

        public Odometer(FuelGauge fg)
        {
            _fg = fg;
        }

        public void SetMileage(int mileage)
        {
            _mileage = mileage;
        }

        public int GetMileage()
        {
            return _mileage;
        }

        public void Drive()
        {
            if (_fg.getFuel() > 0) _mileage = _mileage == 999999 ? 0 : ++_mileage;
            else Console.WriteLine("Not enough fuel");
            ImpactFuel();
        }

        public void ImpactFuel()
        {
            if(_mileage % 10 == 0) _fg.decreaseFuel();
        }
    }
}