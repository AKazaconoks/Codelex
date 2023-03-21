using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Delfi.Models;

namespace Delfi.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfileController(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ApplicationUser model, IFormFile file)
        {
            var defaultImage = "ebc3bf16-564b-4737-b010-c39dd9bf3234nofile.png";
            var user = await _userManager.GetUserAsync(User);
            var fileName = UploadPhoto(file);
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Category = model.Category;
            user.Amount = model.Amount;
            user.Avatar = fileName == defaultImage ? user.Avatar ?? defaultImage : fileName;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Index", model);
            }

            return RedirectToAction("Index");
        }
        
        public string UploadPhoto(IFormFile file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var random = Guid.NewGuid() + fileName;
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Content/Images/UserPhotos", random);
                var filePathToSave = "UserPhotos/" + random;
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
                using var fileStream = new FileStream(path, FileMode.Create);
                file.CopyTo(fileStream);

                return random;
            }
            return "ebc3bf16-564b-4737-b010-c39dd9bf3234nofile.png";
        }


    }
}