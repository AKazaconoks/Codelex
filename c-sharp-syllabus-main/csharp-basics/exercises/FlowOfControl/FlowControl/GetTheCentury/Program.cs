using System;

namespace GetTheCentury
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Century(1756);
            Century(1555);
            Century(1000);
            Century(1001);
            Century(2005);
        }

        static void Century(int year)
        {
            if(year > 2000) Console.WriteLine("21st century");
            else Console.WriteLine(year % 100 == 0 ? (year / 100) + "th century" : (year / 100 + 1) + "th century");
        }
    }
}
