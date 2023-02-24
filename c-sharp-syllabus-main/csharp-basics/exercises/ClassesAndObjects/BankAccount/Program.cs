using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = new Account("Benson", -17.50);
            Console.WriteLine(acc.ShowUserNameAndBalance());
        }
    }

    class Account
    {
        private string name;
        private double balance;

        public Account(string name, double balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public string ShowUserNameAndBalance()
        {
            return $"{this.name}, {(this.balance < 0 ? "-" + (-this.balance).ToString("C") : this.balance.ToString())}";
        }
    }
}
