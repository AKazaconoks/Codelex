namespace IfEmployee;

public class Employee
{
    public int Id { get; set; }
    private string _fullName { get; set; }
    private decimal _hourlySalary { get; set; }
    private DateTime _contractStartDate;
    private DateTime _contractEndDate;
    private Dictionary<DateTime, int> _reportedHours;

    public Employee(string fullName, decimal hourlySalary)
    {
        _fullName = fullName;
        _hourlySalary = hourlySalary;
        Id = Company.GetId();
        _contractStartDate = DateTime.MinValue;
        _contractEndDate = DateTime.MaxValue;
        _reportedHours = new Dictionary<DateTime, int>();
    }

    public void StartContract(DateTime contractStartDate)
    {
        _contractStartDate = contractStartDate;
    }

    public void EndContract(DateTime contractEndDate)
    {
        _contractEndDate = contractEndDate;
    }

    public void AddReportedHours(DateTime date, int minutes)
    {
        if (_reportedHours.ContainsKey(date))
        {
            _reportedHours.Remove(date);
        }

        _reportedHours.Add(date, minutes);
    }

    public string GetReportedHoursAsString(DateTime date)
    {
        if (_reportedHours.TryGetValue(date, out var value))
        {
            return $"{date} worked hours: {(int)(value / 60)}:{value % 60}";
        }

        return $"No reported hours found for {date}";
    }

    public decimal GetReportedHoursAsHours(DateTime date)
    {
        if (_reportedHours.TryGetValue(date, out var value))
        {
            return value / 60;
        }

        Console.WriteLine("No hours worked for this time period");
        return 0;
    }

    public List<string> GetReportedHoursForPeriodAsString(DateTime periodStartDate, DateTime periodEndDate)
    {
        var hoursForPeriod = new List<string>();
        foreach (var key in _reportedHours.Keys)
        {
            if (key >= periodStartDate && key <= periodEndDate)
            {
                hoursForPeriod.Add(GetReportedHoursAsString(key));
            }
        }

        return hoursForPeriod;
    }

    public decimal GetReportedHoursForPeriodAsHours(DateTime periodStartDate, DateTime periodEndDate)
    {
        decimal hoursForPeriod = 0;
        foreach (var key in _reportedHours.Keys)
        {
            if (key >= periodStartDate && key <= periodEndDate)
            {
                hoursForPeriod += GetReportedHoursAsHours(key);
            }
        }

        return hoursForPeriod;
    }

    public decimal GetMonthlySalary(int year, int month)
    {
        return (decimal)(_hourlySalary * GetReportedHoursForPeriodAsHours(new DateTime(year, month, 1),
            new DateTime(year, month, DateTime.DaysInMonth(year, month))));
    }
}