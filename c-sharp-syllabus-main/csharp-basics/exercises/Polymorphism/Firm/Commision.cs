namespace Firm
{
    public class Commision : Hourly
    {
        private double _totalSales;
        private double _commissionRate;

        public Commision(string eName, string eAddress, string ePhone, string socSecNumber, double rate,
            double commissionRate) : base(eName, eAddress, ePhone, socSecNumber, rate)
        {
            _commissionRate = commissionRate;
            _totalSales = 0;
        }

        public void AddSales(double sales)
        {
            _totalSales += sales;
        }
        
        public override double Pay() 
        {
            var payment = base.Pay() + _totalSales * _commissionRate;
            _totalSales = 0;
            return payment;
        }

        public override string ToString()
        {
            return base.ToString() + $" total sales: {_totalSales}";
        }
    }
}