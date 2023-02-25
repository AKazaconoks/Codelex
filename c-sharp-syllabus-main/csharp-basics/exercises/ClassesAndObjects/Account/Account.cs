namespace Account
{
    public class Account
    {
        private string _name;
        private decimal _balance;

        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        public void Withdrawal(decimal withdrawAmount)
        {
            _balance -= withdrawAmount;
        }

        public void Deposit(decimal depositAmount)
        {
            _balance += depositAmount;
        }

        public decimal Balance()
        {
            return _balance;
        }

        public override string ToString()
        {
            return $"{_name}: {_balance.ToString("C")}";
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
