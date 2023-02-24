namespace SavingsAccount
{
    public class SavingsAccount
    {
        private decimal rate;
        private decimal balance;

        public SavingsAccount(decimal rate, decimal balance)
        {
            this.rate = rate / 100;
            this.balance = balance;
        }

        public void withdraw(decimal amount)
        {
            this.balance -= amount;
        }

        public void deposit(decimal amount)
        {
            this.balance += amount;
        }

        public void interest()
        {
            balance += rate / 12 * balance;
        }

        public decimal getBalance()
        {
            return this.balance;
        }
    }
}