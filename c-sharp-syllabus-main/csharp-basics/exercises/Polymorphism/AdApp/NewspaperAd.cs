namespace AdApp
{
    public class NewspaperAd : Advert
    {
        private int _column;
        private int _rate;

        public NewspaperAd(int fee, int column, int rate) : base(fee)
        {
            _rate = rate;
            _column = column;
        }

        public override int Cost()
        {
            return base.Cost() + _rate * _column;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}