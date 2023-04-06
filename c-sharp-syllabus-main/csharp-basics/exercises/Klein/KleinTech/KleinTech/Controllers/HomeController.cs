using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KleinTech.Models;
using System.Linq;
using KleinTech.Data;

namespace KleinTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var people = await _context.People
                .Include(p => p.SpouseDetails)
                .ToListAsync();
            return View(people);
        }

        [HttpPost]
        public async Task<ActionResult> SavePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            var people = await _context.People
                .Include(p => p.SpouseDetails)
                .ToListAsync();
            return PartialView("_PeopleTable", people);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSpouse(int personId, int spouseId)
        {
            var person = await _context.People.FindAsync(personId);
            var spouse = await _context.People.FindAsync(spouseId);
            if (person != null && spouse != null)
            {
                person.SpouseDetails = new SpouseDetails
                {
                    SpouseId = spouseId,
                    MaritalStatus = "Married",
                    PersonId = person.Id
                };

                spouse.SpouseDetails = new SpouseDetails
                {
                    SpouseId = personId,
                    MaritalStatus = "Married",
                    PersonId = spouse.Id
                };

                _context.Entry(person).State = EntityState.Modified;
                _context.Entry(spouse).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            var people = await _context.People
                .Include(p => p.SpouseDetails)
                .ToListAsync();
            return PartialView("_PeopleTable", people);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSingle(int personId)
        {
            var person = await _context.People.FindAsync(personId);
            person.SpouseDetails = new SpouseDetails { MaritalStatus = "Single", PersonId = personId };
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var people = await _context.People
                .Include(p => p.SpouseDetails)
                .ToListAsync();
            return PartialView("_PeopleTable", people);
        }

        public async Task<JsonResult> GetSpouseOptions()
        {
            var people = await _context.People.ToListAsync();
            return Json(people.Select(p => new
                { Id = p.Id, Name = $"{p.FirstName} {p.LastName}", Age = (DateTime.Now - p.BirthDate).Days / 365 }));
        }
    }
}