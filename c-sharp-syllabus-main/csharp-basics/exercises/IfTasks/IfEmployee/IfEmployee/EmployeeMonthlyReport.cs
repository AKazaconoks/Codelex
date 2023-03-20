namespace IfEmployee;

public class EmployeeMonthlyReport
{
    private int _employeeId { get; set; }

    private int _year { get; set; }

    private int _month { get; set; }

    private decimal _salary { get; set; }

    private decimal _hoursWorked { get; set; }

    public EmployeeMonthlyReport(int employeeId, int year, int month, decimal salary, decimal hoursWorked)
    {
        _employeeId = employeeId;
        _year = year;
        _month = month;
        _salary = salary;
        _hoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return
            $"Employee monthly report for {_employeeId} for date: {_month}.{_year}. Worked hours: {_hoursWorked}, salary: {_salary}";
    }
}