using System;

namespace Persons
{
    public class Person
    {
        protected string _firstName { get; set; }
        protected string _lastName{ get; set; }
        protected string _address{ get; set; }
        private int _id{ get; set; }

        protected Person()
        {
            
        }

        protected Person(string firstName, string lastName, string address, int id)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _id = id;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{_firstName} {_lastName} living in {_address}");
        }
    }
}