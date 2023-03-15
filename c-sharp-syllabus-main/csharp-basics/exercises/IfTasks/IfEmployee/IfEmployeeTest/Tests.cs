using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IfEmployee;
using NUnit.Framework;

namespace IfEmployeeTest
{
    [TestFixture]
    public class Tests
    {
        private Company _company;
        private Employee _employee;
        private DateTime _startPeriod;
        private DateTime _endPeriod;

        [SetUp]
        public void Setup()
        {
            _company = new Company("If");
            _employee = new Employee("Janis Berzins", (decimal)6.60);
            _startPeriod = new DateTime(2023, 3, 1);
            _endPeriod = new DateTime(2023, 3, 31);
        }

        [Test]
        public void Add_BigAmountOfEmployees_ReturnsSameNumber()
        {
            for (int i = 0; i < 100000; i++)
            {
                _company.AddEmployee(new Employee($"employee{i}", (decimal)6.60), DateTime.Now);
            }

            Assert.True(_company.Employees.Length == 100000);
        }

        [Test]
        public void Readd_Employee_ReturnedEmployeeShouldHaveSameData()
        {
            var name = _employee.FullName;
            var id = _employee.Id;
            var salary = _employee.HourlySalary;
            _company.AddEmployee(_employee, DateTime.Today);
            _company.RemoveEmployee(id, DateTime.Now);
            _company.AddEmployee(id, DateTime.Now);
            Assert.True(_company.Employees.Contains(_employee));
        }

        [Test]
        public void Add_ReportingHours_ReturnsReportedHoursAsString()
        {
            _company.AddEmployee(_employee, DateTime.Now);
            var date = DateTime.Now;
            var hours = 2;
            var minutes = 45;
            _company.ReportHours(_employee.Id, date, hours, minutes);
            Assert.True(_employee.GetReportedHoursAsString(date) == $"{date} worked hours: 2:45");
        }

        [Test]
        public void Add_ReportingHours_ReturnsReportedHoursAsHours()
        {
            _company.AddEmployee(_employee, DateTime.Now);
            for (var i = 8; i < 32; i++)
            {
                _company.ReportHours(_employee.Id, new DateTime(2023, 3, i), 8, 0);
            }

            Assert.True(192 == _employee.GetReportedHoursForPeriodAsHours(_startPeriod, _endPeriod));
        }

        [Test]
        public void Add_ReportingHours_ReturnsCorrectSalary()
        {
            _company.AddEmployee(_employee, DateTime.Now);
            for (var i = 8; i < 32; i++)
            {
                _company.ReportHours(_employee.Id, new DateTime(2023, 3, i), 8, 0);
            }

            Assert.True(_employee.GetMonthlySalary(2023, 3) == 24 * 8 * _employee.HourlySalary);
        }

        [Test]
        public void Create_MonthlyReport_ReturnsListOfMonthlyReportForEach()
        {
            var resultAsShouldList = new List<EmployeeMonthlyReport>();
            for (var i = 0; i < 50; i++)
            {
                var employee = new Employee($"Employee{i}", (decimal)7.80);
                _company.AddEmployee(employee, DateTime.Now);
                for (var j = 8; j < 32; j++)
                {
                    _company.ReportHours(employee.Id, new DateTime(2023, 3, j), 8, 0);
                }

                resultAsShouldList.Add(new EmployeeMonthlyReport(employee.Id, 2023, 3,
                    employee.GetMonthlySalary(2023, 3),
                    employee.GetReportedHoursForPeriodAsHours(_startPeriod, _endPeriod)));
            }

            var asIsArray = _company.GetMonthlyReport(_startPeriod, _endPeriod);
            var resultAsIsToString = "";
            var resultToBeToString = "";
            Array.ForEach(asIsArray, a => resultAsIsToString += a.ToString() + "\n");
            resultAsShouldList.ForEach(a => resultToBeToString += a.ToString() + "\n");
            Assert.True(resultAsIsToString == resultToBeToString);
        }
    }
}