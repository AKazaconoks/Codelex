var set = new HashSet<string>()
{
    "Une", "Deux", "Trois", "Quatre", "Cinq"
};
Console.WriteLine(string.Join(", ", set));
set.Clear();
set.Add("Une");
set.Add("Une");
Console.WriteLine(string.Join(", ", set));
    