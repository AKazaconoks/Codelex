using Newtonsoft.Json;

namespace CountryTaskFileOutput;

public class Program
{
    public static async Task Main(string[] args)
    {
        await GetFile();
        var countries = GetCountriesFromFile();
        Console.WriteLine(
            $"Top 10 countries with the biggest population:\n{string.Join("\n", GetTenBiggestPopulation(countries).Select(x => $"{x.Name} {x.Population.ToString("N")}"))}\n");
        Console.WriteLine(
            $"Top 10 countries with the biggest area:\n{string.Join("\n", GetTenBiggestArea(countries).Select(x => $"{x.Name} {x.Area.ToString("N")} km2"))}\n");
        Console.WriteLine(
            $"Top 10 countries with the biggest population density:\n{string.Join("\n", GetTenBiggestPopulationDensity(countries).Select(x => $"{x.Name} {(x.Population / x.Area).ToString("F2")} people/km2"))}");
    }

    public static async Task GetFile()
    {
        var client = new HttpClient();
        var url = "https://restcountries.com/v2/regionalbloc/eu";
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        var countries = JsonConvert.DeserializeObject<List<dynamic>>(content);
        var filteredCountries = countries.Select(x => new CountryData()
        {
            Name = x.name,
            Capital = x.capital,
            Currencies = JsonConvert.DeserializeObject<List<CurrencyData>>(x.currencies.ToString()),
            Population = x.population,
            Area = x.area != null ? double.Parse(x.area.ToString()) : 0
        }).ToList();
        var json = JsonConvert.SerializeObject(filteredCountries, Formatting.Indented);
        await File.WriteAllTextAsync("data.json", json);
        Console.WriteLine("JSON file has been successfully created");
    }

    public static List<CountryData> GetCountriesFromFile()
    {
        var jsonContent = File.ReadAllText("data.json");
        return JsonConvert.DeserializeObject<List<CountryData>>(jsonContent);
    }

    public static List<CountryData> GetTenBiggestPopulation(List<CountryData> countries)
    {
        countries.Sort((x, y) => y.Population.CompareTo(x.Population));
        return countries.Take(10).ToList();
    }

    public static List<CountryData> GetTenBiggestArea(List<CountryData> countries)
    {
        countries.Sort((x, y) => y.Area.CompareTo(x.Area));
        return countries.Take(10).ToList();
    }
    
    public static List<CountryData> GetTenBiggestPopulationDensity(List<CountryData> countries)
    {
        countries.RemoveAll(x => x.Area == 0);
        countries.Sort((x, y) => (y.Population / y.Area).CompareTo(x.Population / x.Area));
        return countries.Take(10).ToList();
    }
}