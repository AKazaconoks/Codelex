using System.Net;
using HolidaysTask;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HolidayTest;

public class Tests
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        var appFactory = new WebApplicationFactory<Program>();
        _client = appFactory.CreateClient();
    }

    [Test]
    public async Task TestStatus_GetHolidays_ReturnsSuccessStatusCode()
    {
        var url = "/Holidays/PL/LV/2023";
        var response = await _client.GetAsync(url);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task TestContent_GetHolidays_ReturnsCorrectContent()
    {
        var url = "/Holidays/PL/LV/2023";
        var response = await _client.GetAsync(url);
        var resultAsShould = "2023-01-01 New Year's Day (PL: Nowy Rok / LV: Jaunais Gads)";
        var resultAsIs = await response.Content.ReadAsStringAsync();
        Assert.That(resultAsIs, Does.Contain(resultAsShould));
    }
}