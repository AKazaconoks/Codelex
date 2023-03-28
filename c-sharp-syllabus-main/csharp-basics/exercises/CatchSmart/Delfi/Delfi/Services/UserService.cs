using System.Security.Claims;
using Delfi.Models;
using Microsoft.AspNetCore.Identity;

namespace Delfi;

public class UserService
{
    private static UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public static async Task<ApplicationUser> GetUser(ClaimsPrincipal user)
    {
        return await _userManager.GetUserAsync(user);
    }

    public static string GetCategory(ApplicationUser user)
    {
        return user.Category ?? "delfi";
    }

    public static int GetAmount(ApplicationUser user)
    {
        return user.Amount == null ? 10 : user.Amount;
    }

    public static async void UpdateSettings(ApplicationUser model, ApplicationUser user, IFormFile file)
    {
        var defaultImage = "ebc3bf16-564b-4737-b010-c39dd9bf3234nofile.png";
        var fileName = Services.UploadPhoto(file);
        user.UserName = model.UserName;
        user.Email = model.Email;
        user.Category = model.Category;
        user.Amount = model.Amount;
        user.Avatar = fileName == defaultImage ? user.Avatar ?? defaultImage : fileName;
    }
}