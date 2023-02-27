using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    public class PhoneDirectory
    {
        private SortedDictionary<string, string> _data;

        public PhoneDirectory() 
        {
            _data = new SortedDictionary<string, string>();
        }

        public void ListAll()
        {
            Console.WriteLine(string.Join("\n", _data.Select(x => $"{x.Key} {x.Value}")));
        }

        public int GetIndex(string name) 
        {
            return new List<string>(_data.Keys).IndexOf(name);
        }

        public void GetNumber(string name)
        {
            if (_data.TryGetValue(name, out var phone)) Console.WriteLine(phone);
            else  Console.WriteLine($"No number found for {name}");
        }

        public void PutNumber(string name, string number) 
        {
            if (name == null || number == null) 
            {
                throw new Exception("name and number cannot be null");
            }

            try
            {
                _data.Add(name, number);
            }
            catch
            {
                throw new Exception("this name already has been added");
            }
        }
    }
}