namespace AdApp
{
    public class TVAd : Advert
    {
        private int _seconds;
        private int _rate;
        private bool _isPrimeHour;

        public TVAd(int fee, int seconds, int rate, bool isPrimeHour) : base(fee)
        {
            _seconds = seconds;
            _rate = rate;
            _isPrimeHour = isPrimeHour;
        }

        public override int Cost()
        {
            return _isPrimeHour ? base.Cost() + 2 * (_rate * _seconds) : base.Cost() + _rate * _seconds;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}