using System;

namespace Persons
{
    public class Student : Person
    {
        private double _gpa { get; set; }

        public Student(string firstName, string lastName, string address, int id, double gpa ) : base(firstName, lastName, address, id)
        {
            _gpa = gpa;
        }

        public override void Display()
        {
            Console.WriteLine($"{_firstName} {_lastName} living in {_address} and GPA is {_gpa}");
        }
    }
}