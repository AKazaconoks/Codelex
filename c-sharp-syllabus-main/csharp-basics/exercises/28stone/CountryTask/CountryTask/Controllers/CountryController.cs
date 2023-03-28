using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace CountryTask.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : Controller
{
    [HttpGet]
    [Route("{filter}/{value}")]
    public async Task<ActionResult<IEnumerable<string>>> GetDataFromApi(string filter, string value)
    {
        var client = new HttpClient();
        var url = $"https://restcountries.com/v2/{filter}/{value}";
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        return Ok(jsonString);
    }
    
    [HttpGet]
    [Route("{filter}")]
    public async Task<ActionResult<IEnumerable<string>>> GetDataFromApi(string filter)
    {
        var client = new HttpClient();
        var url = $"https://restcountries.com/v2/{filter}";
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        return Ok(jsonString);
    }
}