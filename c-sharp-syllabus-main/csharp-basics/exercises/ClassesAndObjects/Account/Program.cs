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
            var bartosAccount = new Account("Barto's account",100.00m);
            var bartosSwissAccount = new Account("Barto's account in Switzerland",1000000.00m);

            Console.WriteLine("Initial state");
            Console.WriteLine(bartosAccount);
            Console.WriteLine(bartosSwissAccount);

            bartosAccount.Withdrawal(20);
            Console.WriteLine($"Barto's account balance is now: {bartosAccount.Balance()}");
            bartosSwissAccount.Deposit(200);
            Console.WriteLine($"Barto's Swiss account balance is now: {bartosSwissAccount.Balance()}");
            
            Transfer(bartosSwissAccount, bartosAccount, 10000.00m);

            Console.WriteLine("Final state");
            Console.WriteLine(bartosAccount);
            Console.WriteLine(bartosSwissAccount);
        }
        
        public static void Transfer(Account from, Account to, decimal amount)
        {
            from.Withdrawal(amount);
            to.Deposit(amount);
        }
    }
}
