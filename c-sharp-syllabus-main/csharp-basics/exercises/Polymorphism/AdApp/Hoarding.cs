namespace AdApp
{
    public class Hoarding : Advert
    {
        private int _rate;
        private int _numDays;
        private bool _isPrimeLocation;

        public Hoarding(int fee, int rate, int numDays, bool isPrimeLocation) : base(fee)
        {
            _rate = rate;
            _numDays = numDays;
            _isPrimeLocation = isPrimeLocation;
        }

        public override int Cost()
        {
            return (int)(_isPrimeLocation ? base.Cost() + _rate * _numDays * 1.5 : base.Cost() + _rate * _numDays);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}