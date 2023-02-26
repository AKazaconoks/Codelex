Dictionary<int, string> dict = new Dictionary<int, string>()
{
    {1, "Monday"}, {2, "Tuesday"}, {3, "Wednesday"}, {4, "Thursday"}, {5, "Friday"}, {6, "Saturday"}, {7, "Sunday"}
};
Console.WriteLine("Enter number of a day");
if(dict.TryGetValue(int.Parse(Console.ReadLine()), out var value)) Console.WriteLine($"It is {value}");