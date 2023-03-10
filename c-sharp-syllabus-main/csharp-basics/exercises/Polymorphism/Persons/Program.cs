using System;

namespace Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            new Student("Elvis", "Presleys", "Duntes iela 7, Rīga", 1, 5.65).Display();
            new Employee("Janis", "Liepins", "Liela Darza 20, Daugavpils", 2, "arsts").Display();
        }
    }
}