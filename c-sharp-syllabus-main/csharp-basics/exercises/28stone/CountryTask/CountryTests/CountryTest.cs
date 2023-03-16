using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using CountryTask;
using static CountryTaskFileOutput.Program;

namespace CountryTests;

public class Tests
{
    private HttpClient _client;

    [SetUp]
    public async Task Setup()
    {
        await GetFile();
        var appFactory = new WebApplicationFactory<Program>();
        _client = appFactory.CreateClient();
    }

    [Test]
    public async Task StatusTest_CountryName_ReturnsSuccessStatusCode()
    {
        var url = "/country/name/lv";
        var response = await _client.GetAsync(url);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task ContentTest_CountryName_ReturnsSameInfoAsAPI()
    {
        var url = "/country/name/lv";
        var response = await _client.GetAsync(url);
        var resultAsIs = await response.Content.ReadAsStringAsync();
        var responseAsShould = await new HttpClient().GetAsync("https://restcountries.com/v2/name/lv");
        var resultAsShould = await responseAsShould.Content.ReadAsStringAsync();
        Assert.That(resultAsIs, Is.EqualTo(resultAsShould));
    }

    [Test]
    public async Task FileContentTest_Countries_DoNotContainFullData()
    {
        var url = "https://restcountries.com/v2/regionalbloc/eu";
        var response = await new HttpClient().GetAsync(url);
        var fullData = await response.Content.ReadAsStringAsync();
        var result = File.ReadAllText("data.json");
        Assert.That(result, Is.Not.EqualTo(fullData));
    }

    [Test]
    public void TopTenTest_Population_ReturnsListOfNeededData()
    {
        var countries = GetTenBiggestPopulation(GetCountriesFromFile());
        var isPopulationDescending = true;
        var previous = Int32.MaxValue;
        foreach (var a in countries)
        {
            isPopulationDescending = a.Population < previous;
            previous = a.Population;
            if (!isPopulationDescending)
            {
                break;
            }
        }
        Assert.That(isPopulationDescending && countries.Count == 10, Is.True);
    }
    
    [Test]
    public void TopTenTest_Area_ReturnsListOfNeededData()
    {
        var countries = GetTenBiggestArea(GetCountriesFromFile());
        var isAreaDescending = true;
        var previous = Double.MaxValue;
        foreach (var a in countries)
        {
            isAreaDescending = a.Area < previous;
            previous = a.Area;
            if (!isAreaDescending)
            {
                break;
            }
        }
        Assert.That(isAreaDescending && countries.Count == 10, Is.True);
    }
    
    [Test]
    public void TopTenTest_Density_ReturnsListOfNeededData()
    {
        var countries = GetTenBiggestPopulationDensity(GetCountriesFromFile());
        var isDensityDescending = true;
        var previous = Double.MaxValue;
        foreach (var a in countries)
        {
            isDensityDescending = (a.Population / a.Area) < previous;
            previous = a.Population / a.Area;
            if (!isDensityDescending)
            {
                break;
            }
        }
        Assert.That(isDensityDescending && countries.Count == 10, Is.True);
    }
}