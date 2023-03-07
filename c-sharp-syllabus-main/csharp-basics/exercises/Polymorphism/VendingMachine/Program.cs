using System;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vm = new VendingMachine("Toshiba", false, new Money(5, 70));
            Console.WriteLine(vm.AddProduct("chips", new Money(0, 80), 10));
            Console.WriteLine(vm.InsertCoin(new Money(1, 0)));
            Console.WriteLine(vm.BuyProduct("chips"));
            Console.WriteLine(vm.BuyProduct("chips"));
        }
    }
}
