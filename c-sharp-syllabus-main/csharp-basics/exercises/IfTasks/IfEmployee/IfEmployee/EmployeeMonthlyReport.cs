namespace IfEmployee;

public class EmployeeMonthlyReport
{
    public int EmployeeId { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public decimal Salary { get; set; }

    public decimal HoursWorked { get; set; }

    public EmployeeMonthlyReport(int employeeId, int year, int month, decimal salary, decimal hoursWorked)
    {
        EmployeeId = employeeId;
        Year = year;
        Month = month;
        Salary = salary;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return
            $"Employee monthly report for {EmployeeId} for date: {Month}.{Year}. Worked hours: {HoursWorked}, salary: {Salary}";
    }
}