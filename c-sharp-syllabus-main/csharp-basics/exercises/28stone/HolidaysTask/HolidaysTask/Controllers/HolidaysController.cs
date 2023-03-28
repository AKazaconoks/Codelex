using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace HolidaysTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidaysController : ControllerBase
    {
        [HttpGet]
        [Route("{countryCode1}/{countryCode2}/{year}")]
        public async Task<ActionResult<IEnumerable<string>>> GetHolidays(string countryCode1, string countryCode2,
            int year)
        {
            using var client = new HttpClient();
            var response1 = await client.GetAsync($"https://date.nager.at/api/v3/publicholidays/{year}/{countryCode1}");
            var response2 = await client.GetAsync($"https://date.nager.at/api/v3/publicholidays/{year}/{countryCode2}");

            response1.EnsureSuccessStatusCode();
            response2.EnsureSuccessStatusCode();

            var holidays1 = await JsonSerializer.DeserializeAsync<List<Holiday>>(await response1.Content.ReadAsStreamAsync());
            var holidays2 = await JsonSerializer.DeserializeAsync<List<Holiday>>(await response2.Content.ReadAsStreamAsync());
            var holidays = (from h1 in holidays1 from h2 in holidays2 where h1.Date == h2.Date select new Holiday()
            {
                Name = h1.Name,
                Date = h1.Date,
                Counties = h1.Counties,
                LocalName = $"{countryCode1}: {h1.LocalName} / {countryCode2}: {h2.LocalName}",
                CountryCode = $"{h1.CountryCode} / {h2.CountryCode}",
                Fixed = h1.Fixed,
                Global = h1.Global,
                LaunchYear = h1.LaunchYear,
                Types = h1.Types
            }).ToList();
            var output = new StringBuilder();
            foreach (var holiday in holidays)
            {
                output.Append($"{holiday.Date} {holiday.Name} ({holiday.LocalName})\n");
            }
            return Ok(output.ToString());
        }
    }
}