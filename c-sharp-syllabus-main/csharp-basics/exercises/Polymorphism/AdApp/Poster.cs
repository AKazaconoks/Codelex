namespace AdApp
{
    public class Poster : Advert
    {
        private int _dimensionX;
        private int _dimensionY;
        private int _numberOfCopies;
        private int _costPerCopy;

        public Poster(int fee, int dimensionX, int dimensionY, int numberOfCopies, int costPerCopy) : base(fee)
        {
            _dimensionX = dimensionX;
            _dimensionY = dimensionY;
            _numberOfCopies = numberOfCopies;
            _costPerCopy = costPerCopy;
        }
        
        public override int Cost()
        {
            return base.Cost() + _numberOfCopies * _costPerCopy;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}