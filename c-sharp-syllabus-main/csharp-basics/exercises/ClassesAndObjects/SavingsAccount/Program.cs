using System;

namespace SavingsAccount
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("How much money is in the account?: ");
            var balance = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the annual interest rate: ");
            var rate = decimal.Parse(Console.ReadLine());
            SavingsAccount sa = new SavingsAccount(rate, balance);
            Console.Write("How long has the account been opened? ");
            var input = int.Parse(Console.ReadLine());
            for (var i = 0; i < input; i++)
            {
                sa.interest();
            }

            decimal deposits = 0;
            decimal withdraws = 0;
            for (var i = 1; i < 5; i++)
            {
                Console.Write($"Enter amount deposited for month {i}: "); 
                var dep = decimal.Parse(Console.ReadLine());
                sa.deposit(dep);
                deposits += dep;
                Console.Write($"Enter amount withdrawn for month {i}: ");
                var with = decimal.Parse(Console.ReadLine());
                sa.withdraw(with);
                withdraws += with;
                sa.interest();
            }

            Console.WriteLine($"Total deposited: {deposits.ToString("C")}");
            Console.WriteLine($"Total withdrawn: {withdraws.ToString("C")}");
            Console.WriteLine($"Total interest earned: {(sa.getBalance() - balance).ToString("C")}");
            Console.WriteLine($"Ending balance: {sa.getBalance().ToString("C")}");
        }
    }
}