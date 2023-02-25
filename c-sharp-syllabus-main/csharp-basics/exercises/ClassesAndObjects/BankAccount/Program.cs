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
        private string _name;
        private double _balance;

        public Account(string name, double balance)
        {
            _name = name;
            _balance = balance;
        }

        public string ShowUserNameAndBalance()
        {
            return $"{_name}, {(_balance < 0 ? "-" + (-_balance).ToString("C") : _balance.ToString())}";
        }
    }
}
