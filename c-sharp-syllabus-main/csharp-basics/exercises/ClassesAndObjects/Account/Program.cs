using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    class Program
    {
        private static void Main(string[] args)
        {
            Account bartosAccount = new Account("Barto's account",100.00m);
            Account bartosSwissAccount = new Account("Barto's account in Switzerland",1000000.00m);
            Bank bank = new Bank();
            bank.addAcount(bartosAccount);
            bank.addAcount(bartosSwissAccount);

            Console.WriteLine("Initial state");
            Console.WriteLine(bartosAccount);
            Console.WriteLine(bartosSwissAccount);

            bartosAccount.Withdrawal(20);
            Console.WriteLine($"Barto's account balance is now: {bartosAccount.Balance()}");
            bartosSwissAccount.Deposit(200);
            Console.WriteLine($"Barto's Swiss account balance is now: {bartosSwissAccount.Balance()}");
            
            bank.Transfer(bartosSwissAccount, bartosAccount, 10000.00m);

            Console.WriteLine("Final state");
            Console.WriteLine(bartosAccount);
            Console.WriteLine(bartosSwissAccount);
        }
    }
}
