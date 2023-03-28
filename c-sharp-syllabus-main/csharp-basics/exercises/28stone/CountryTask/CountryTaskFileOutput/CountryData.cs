namespace CountryTaskFileOutput;

public class CountryData
{
    public string Name { get; set; }
    public string Capital { get; set; }
    public List<CurrencyData> Currencies { get; set; }
    public int Population { get; set; }
    public double Area { get; set; }
}