using System;

namespace Exercise1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var product1 = new Product("Logitech mouse", 70.00, 14);
            var product2 = new Product("iPhone 5s", 999.99, 3);
            var product3 = new Product("Epson EB-U05", 440.46, 1);
            product1.PrintProduct();
            product1.ChangePrice(88);
            product1.ChangeQuantity(5);
            product1.PrintProduct();
        }
    }

    internal class Product
    {
        private string _name;
        private double _priceAtStart;
        private int _amountAtStart;

        public Product(string name, double priceAtStart, int amountAtStart)
        {
            _name = name;
            _priceAtStart = priceAtStart;
            _amountAtStart = amountAtStart;
        }

        public void PrintProduct()
        {
            Console.WriteLine(_name + ", price " + _priceAtStart + ", amount " + _amountAtStart);
        }

        public void ChangePrice(int newPrice)
        {
            _priceAtStart = newPrice;
        }

        public void ChangeQuantity(int newQuantity)
        {
            _amountAtStart = newQuantity;
        }
    }
}