namespace SavingsAccount
{
    public class SavingsAccount
    {
        private decimal _rate;
        private decimal _balance;

        public SavingsAccount(decimal rate, decimal balance)
        {
            _rate = rate / 100;
            _balance = balance;
        }

        public void withdraw(decimal amount)
        {
            _balance -= amount;
        }

        public void deposit(decimal amount)
        {
            _balance += amount;
        }

        public void interest()
        {
            _balance += _rate / 12 * _balance;
        }

        public decimal getBalance()
        {
            return _balance;
        }
    }
}