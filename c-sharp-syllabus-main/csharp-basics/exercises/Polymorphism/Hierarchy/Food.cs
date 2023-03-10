namespace Hierarchy
{
    public class Food
    {
        private int _quantity;

        public Food(int quantity)
        {
            _quantity = quantity;
        }

        public int GetFoodQuantity()
        {
            return _quantity;
        }
    }
}