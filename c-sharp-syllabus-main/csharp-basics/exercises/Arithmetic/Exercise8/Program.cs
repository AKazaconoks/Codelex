using System;

namespace Exercise8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Employee1 salary is " + new Employee(7.50, 35).calculateSalary() + "$");
            Console.WriteLine("Employee2 salary is " + new Employee(8.20, 47).calculateSalary() + "$");
            Console.WriteLine("Employee3 salary is " + new Employee(10, 73).calculateSalary() + "$");
        }
    }

    public class Employee
    {
        private double salary;
        private int hoursWorked;

        public Employee(double salary, int hoursWorked)
        {
            this.salary = salary;
            this.hoursWorked = hoursWorked;
        }

        public string calculateSalary()
        {
            return hoursWorked > 60 ? "Error, because hours more than 60." :
                hoursWorked > 40 ? (salary * 40 + salary * 1.5 * (hoursWorked - 40)).ToString() :
                (hoursWorked * salary).ToString();
        }
    }
}