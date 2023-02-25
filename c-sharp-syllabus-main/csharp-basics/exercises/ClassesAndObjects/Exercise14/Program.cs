using System;
using System.Globalization;

namespace Exercise14
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WeekdayInDutch(1970, 9, 21);
            WeekdayInDutch(1945, 9, 2);
            WeekdayInDutch(2001, 9, 11);
        }

        public static void WeekdayInDutch(int year, int month, int day)
        {
            var dt = new DateTime(year, month, day);
            Console.WriteLine(dt.ToString("dddd", CultureInfo.CreateSpecificCulture("nl-NL")));
        }
    }
}