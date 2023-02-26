namespace Exercise3
{
    public class FuelGauge
    {
        private int _fuel;

        public void setFuel(int fuel)
        {
            _fuel = fuel;
        }

        public int getFuel()
        {
            return _fuel;
        }

        public void increaseFuel()
        {
            _fuel += _fuel < 70 ? 1 : 0;
        }

        public void decreaseFuel()
        {
            _fuel -= _fuel > 0 ? 1 : 0;
        }
    }
}