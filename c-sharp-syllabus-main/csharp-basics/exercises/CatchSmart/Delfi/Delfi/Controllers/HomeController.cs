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

        public HomeController(IHttpClientFactory clientFactory, UserManager<ApplicationUser> userManager)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var user = await UserService.GetUser(User);
            var xml = await Services.GetXmlContent(
                $"https://www.delfi.lv/rss/?channel={UserService.GetCategory(user)}");
            var items = Services.ParseXmlItems(xml, UserService.GetAmount(user));
            ViewData["Items"] = items;
            return View(items);
        }
    }
}