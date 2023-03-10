using System;

namespace Persons
{
    public class Employee : Person
    {
        private string _jobTitle { get; set; }

        public Employee(string firstName, string lastName, string address, int id, string jobTitle ) : base(firstName, lastName, address, id)
        {
            _jobTitle = jobTitle;
        }

        public override void Display()
        {
            Console.WriteLine($"{_firstName} {_lastName} living in {_address} and works as a {_jobTitle}");
        }
    }
}