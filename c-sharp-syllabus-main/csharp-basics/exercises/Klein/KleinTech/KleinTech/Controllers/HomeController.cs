using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KleinTech.Models;
using System.Linq;
using KleinTech.Data;
using KleinTech.Services;

namespace KleinTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbServices _dbServices;

        public HomeController(DbServices dbServices)
        {
            _dbServices = dbServices;
        }

        public async Task<ActionResult> Index()
        {
            var people = await _dbServices.GetPeopleWithSpouseDetailsAsync();
            return View(people);
        }

        [HttpPost]
        public async Task<ActionResult> SavePerson(Person person)
        {
            await _dbServices.AddPersonAsync(person);
            var people = await _dbServices.GetPeopleWithSpouseDetailsAsync();
            return PartialView("_PeopleTable", people);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSpouse(int personId, int spouseId)
        {
            await _dbServices.UpdateSpouseDetailsAsync(personId, spouseId);
            var people = await _dbServices.GetPeopleWithSpouseDetailsAsync();
            return PartialView("_PeopleTable", people);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSingle(int personId)
        {
            await _dbServices.UpdateSingleAsync(personId);
            var people = await _dbServices.GetPeopleWithSpouseDetailsAsync();
            return PartialView("_PeopleTable", people);
        }

        public async Task<JsonResult> GetSpouseOptions()
        {
            var spouseOptions = await _dbServices.GetSpouseOptionsAsync();
            return Json(spouseOptions);
        }
    }
}