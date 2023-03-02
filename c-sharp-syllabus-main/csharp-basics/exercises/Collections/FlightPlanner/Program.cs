using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class Program
    {
        private const string Path = @"../../flights.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path);
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (var s in readText)
            {
                
                var list = new List<string>();
                foreach (var a in readText)
                {
                    if (a.Contains(s.Split('>')[0]))
                    {
                        list.Add(a.Split('>')[1].Trim());
                    }
                }

                try
                {
                    dict.Add(s.Split('-')[0].Trim(), list);
                }
                catch
                {
                    continue;
                }
            }

            Start(dict);
        }

        private static void Start(Dictionary<string, List<string>> dict)
        {
            Console.WriteLine("What would you like to do: ");
            Console.WriteLine("To display list of the cities press 1");
            Console.WriteLine("To exit program press #");
            var firstInput = Console.ReadLine();
            switch (firstInput)
            {
                case "#":
                    Console.WriteLine("Goodbye!");
                    return;
                case "1":
                    Console.WriteLine("To select a city from which you would like to start press 1");
                    var secondInput = Console.ReadLine();
                    switch (secondInput)
                    {
                        case "1":
                            Console.WriteLine($"Available cities: {string.Join(", ", dict.Select(x => x.Key))}");
                            Console.Write("Please enter a city to start: ");
                            var start = Console.ReadLine();
                            var next = start;
                            var travelPlan = new List<string>(){start};
                            var isTripRounded = false;
                            while (!isTripRounded)
                            {
                                if (dict.TryGetValue(next, out var value))
                                {
                                    Console.WriteLine($"Available destinations from {next}: {string.Join(", ", value)}");
                                    Console.Write("Please enter a destination to flight to: ");
                                    next = Console.ReadLine();
                                    travelPlan.Add(next);
                                }

                                if (start == next)
                                {
                                    isTripRounded = true;
                                }
                            }

                            Console.WriteLine($"Thank you! Here is your round trip plan: {string.Join(" -> ", travelPlan)}");
                            break;
                    }
                    break;
            }
        }
        
    }
}
