using System.Collections.Generic;

namespace Account
{
    public class Bank
    {
        private List<Account> list;

        public Bank()
        {
            this.list = new List<Account>();
        }

        public void addAcount(Account account)
        {
            this.list.Add(account);
        }

        public void Transfer(Account from, Account to, decimal amount)
        {
            from.Withdrawal(amount);
            to.Deposit(amount);
        }
        
    }
}