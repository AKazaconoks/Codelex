var list = new List<string>();
while (true)
{
    Console.Write("Enter name: ");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) break;
    else list.Add(input);
}

Console.WriteLine($"Unique names from provided: {string.Join(" ", list.Distinct().ToList())}");