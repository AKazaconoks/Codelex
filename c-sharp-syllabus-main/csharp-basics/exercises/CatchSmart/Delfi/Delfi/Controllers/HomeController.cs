using System.Xml;
using System.Xml.Linq;
using Delfi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Delfi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IHttpClientFactory clientFactory, UserManager<ApplicationUser> userManager)
        {
            _clientFactory = clientFactory;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var category = user.Category ?? "delfi";
            var amount = user.Amount == null ? 10 : user.Amount;

            var url = $"https://www.delfi.lv/rss/?channel={category}";
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Ignore;
            var xmlReader = XmlReader.Create(url, settings);
            var xml = XDocument.Load(xmlReader, LoadOptions.None);

            XNamespace mediaNamespace = "http://search.yahoo.com/mrss/";
            var items = xml.Descendants("item")
                .Take(amount)
                .Select(item => new
                {
                    Title = item.Element("title").Value,
                    Link = item.Element("link").Value,
                    Description = item.Element("description").Value,
                    PubDate = DateTime.Parse(item.Element("pubDate").Value),
                    Category = item.Element("category").Value,
                    ImageUrl = item.Element(mediaNamespace + "content").Attribute("url").Value
                })
                .ToList();

            ViewData["Items"] = items;

            return View(items);
        }
    }
}