using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var pd = new PhoneDirectory();
            while (true)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("List all contacts - 1");
                Console.WriteLine("Get number - 2");
                Console.WriteLine("Add a contact - 3");
                Console.WriteLine("Exit - 4");
                var input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        pd.ListAll();
                        break;
                    case 2:
                        Console.WriteLine("Enter contacts name: ");
                        pd.GetNumber(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Enter a name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter a number: ");
                        var number = Console.ReadLine();
                        pd.PutNumber(name, number);
                        break;
                    case 4:
                        return;
                }
            }
        }
    }
}
