using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public string Manufacturer { get; }
        public bool HasProducts { get; }
        public Money Amount { get; set; }
        public Product[] Products { get; set; }
        private Money _lastMoneyInput;
        private List<int> _numbers;

        public VendingMachine(string manufacturer, bool hasProducts, Money amount)
        {
            Manufacturer = manufacturer;
            HasProducts = hasProducts;
            Amount = amount;
            Products = new Product[50];
            _lastMoneyInput = new Money(0, 0);
            _numbers = Enumerable.Range(1, 50).ToList();
        }

        public Money InsertCoin(Money amount)
        {
            if (amount.Euros is 1 or 2 || amount.Cents is 10 or 20 or 50)
            {
                _lastMoneyInput = _lastMoneyInput.Add(amount);
                Amount = Amount.Add(amount);
                return Amount;
            }

            throw new VendingMachineExceptions("Incorrect coin type");
        }

        public Money ReturnMoney()
        {
            var returnMoney = _lastMoneyInput;
            _lastMoneyInput = new Money(0, 0);
            Amount = Amount.Remove(returnMoney);
            return returnMoney;
        }

        public bool AddProduct(string name, Money price, int count)
        {
            if (_numbers.Count > 0)
            {
                var productNumber = _numbers.First();
                _numbers.Remove(productNumber);
                Products[productNumber] = new Product(count, price, name, productNumber);
                return true;
            }

            throw new VendingMachineExceptions("Vending machine is full");
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            try
            {
                var product = Products[productNumber];
                if (price != null)
                {
                    product.Price = (Money)price;
                }

                product.Name = name;
                product.Available = amount;
                return true;
            }
            catch
            {
                throw new VendingMachineExceptions("Unable to find this product");
            }
        }

        public Product BuyProduct(string name)
        {
            var product = Array.Find(Products, a => a.Name == name);
            if (product.Available == 0)
            {
                throw new VendingMachineExceptions("Product is not available");
            }
            if (_lastMoneyInput.Euros > product.Price.Euros)
            {
                product.Available -= 1;
                _lastMoneyInput = _lastMoneyInput.Remove(product.Price);
                ReturnMoney();
                Products[product.ProductNumber] = product;
                return product;
            }
            else if (_lastMoneyInput.Euros == product.Price.Euros && _lastMoneyInput.Cents >= product.Price.Cents)
            {
                product.Available -= 1;
                _lastMoneyInput = _lastMoneyInput.Remove(product.Price);
                ReturnMoney();
                Products[product.ProductNumber] = product;
                return product;
            }
            throw new VendingMachineExceptions("Not enough money");
        }
    }
}