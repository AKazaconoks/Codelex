namespace VendingMachine
{
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }

        public Money(int euros, int cents)
        {
            Euros = euros;
            Cents = cents;
        }

        public Money Add(Money amount)
        {
            var newEuros = Euros + amount.Euros;
            var newCents = Cents + amount.Cents;
            if (newCents >= 100)
            {
                newEuros++;
                newCents -= 100;
            }
            return new Money(newEuros, newCents);
        }

        public Money Remove(Money amount)
        {
            var newEuros = Euros - amount.Euros;
            var newCents = Cents - amount.Cents;
            if (newCents < 0)
            {
                newEuros--;
                newCents += 100;
            }
            return new Money(newEuros, newCents);
        }
        
    }
}
