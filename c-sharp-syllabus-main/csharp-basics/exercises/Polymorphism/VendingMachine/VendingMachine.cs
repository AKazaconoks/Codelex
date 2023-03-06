using System;

namespace VendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public string Manufacturer { get; }
        public bool HasProducts { get; }
        public Money Amount { get; set; }
        public Product[] Products { get; set; }

        public Money InsertCoin(Money amount)
        {
            if (amount.Euros is 1 or 2 || amount.Cents is 10 or 20 or 50)
            {
                return amount;
            }
            throw new SystemException("Incorrect coin type");
        }

        public Money ReturnMoney()
        {
            throw new System.NotImplementedException();
        }

        public bool AddProduct(string name, Money price, int count)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}