namespace Account
{
    public class Account
    {
        private string name;
        private decimal balance;

        public Account(string name, decimal balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public void Withdrawal(decimal withdrawAmount)
        {
            this.balance -= withdrawAmount;
        }

        public void Deposit(decimal depositAmount)
        {
            this.balance += depositAmount;
        }

        public decimal Balance()
        {
            return this.balance;
        }

        public override string ToString()
        {
            return $"{this.name}: {this.balance.ToString("C")}";
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
    }
}
