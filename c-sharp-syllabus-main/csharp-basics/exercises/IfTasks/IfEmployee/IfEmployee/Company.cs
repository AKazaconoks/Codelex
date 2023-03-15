namespace IfEmployee;

public class Company : ICompany
{
    public string Name { get; }

    public Employee[] Employees
    {
        get { return _employees.ToArray(); }
    }

    private List<Employee> _employees;

    private static int _idCounter;
    private List<Employee> _terminatedEmployees;

    public Company(string name)
    {
        Name = name;
        _employees = new List<Employee>();
        _idCounter = 0;
        _terminatedEmployees = new List<Employee>();
    }

    public void AddEmployee(Employee employee, DateTime contractStartDate)
    {
        if (_employees.Contains(employee))
        {
            Console.WriteLine("Employee has already been added");
        }
        else
        {
            _employees.Add(employee);
            employee.StartContract(contractStartDate);
            _idCounter++;
        }
    }

    public void AddEmployee(int id, DateTime contractStartDate)
    {
        var employee = _terminatedEmployees.First(x => x.Id == id);
        employee.StartContract(contractStartDate);
        employee.EndContract(DateTime.MaxValue);
        _employees.Add(employee);
        _terminatedEmployees.Remove(employee);
    }

    public void RemoveEmployee(int employeeId, DateTime contractEndDate)
    {
        try
        {
            var employee = _employees.First(x => x.Id == employeeId);
            employee.EndContract(contractEndDate);
            _terminatedEmployees.Add(employee);
            _employees.Remove(employee);
        }
        catch
        {
            Console.WriteLine("Employee with this id is not found");
            throw;
        }
    }

    public void ReportHours(int employeeId, DateTime dateAndTime, int hours, int minutes)
    {
        var employee = _employees.First(a => a.Id == employeeId);
        employee.AddReportedHours(dateAndTime, hours * 60 + minutes);
    }

    public EmployeeMonthlyReport[] GetMonthlyReport(DateTime periodStartDate, DateTime periodEndDate)
    {
        var monthlyReports = new List<EmployeeMonthlyReport>();
        foreach (var employee in Employees)
        {
            var monthlyReport = new EmployeeMonthlyReport(employee.Id, periodStartDate.Year, periodStartDate.Month,
                employee.GetMonthlySalary(periodStartDate.Year, periodStartDate.Month),
                employee.GetReportedHoursForPeriodAsHours(periodStartDate, periodEndDate));
            monthlyReports.Add(monthlyReport);
        }

        return monthlyReports.ToArray();
    }

    public static int GetId()
    {
        return _idCounter;
    }
}