namespace Exercise3
{
    public class FuelGauge
    {
        private int fuel;

        public FuelGauge()
        {
            
        }

        public void setFuel(int fuel)
        {
            this.fuel = fuel;
        }

        public int getFuel()
        {
            return this.fuel;
        }

        public void increaseFuel()
        {
            this.fuel += fuel < 70 ? 1 : 0;
        }

        public void decreaseFuel()
        {
            this.fuel -= fuel > 0 ? 1 : 0;
        }
    }
}