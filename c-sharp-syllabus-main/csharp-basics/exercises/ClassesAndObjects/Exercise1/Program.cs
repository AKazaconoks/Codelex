using System;

namespace Exercise1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Product product1 = new Product("Logitech mouse", 70.00, 14);
            Product product2 = new Product("iPhone 5s", 999.99, 3);
            Product produt3 = new Product("Epson EB-U05", 440.46, 1);
            product1.PrintProduct();
            product1.changePrice(88);
            product1.changeQuantity(5);
            product1.PrintProduct();
        }
    }

    internal class Product
    {
        private string name;
        private double priceAtStart;
        private int amountAtStart;

        public Product(string name, double priceAtStart, int amountAtStart)
        {
            this.name = name;
            this.priceAtStart = priceAtStart;
            this.amountAtStart = amountAtStart;
        }

        public void PrintProduct()
        {
            Console.WriteLine(this.name + ", price " + this.priceAtStart + ", amount " + this.amountAtStart);
        }

        public void changePrice(int newPrice)
        {
            this.priceAtStart = newPrice;
        }

        public void changeQuantity(int newQuantity)
        {
            this.amountAtStart = newQuantity;
        }
    }
}