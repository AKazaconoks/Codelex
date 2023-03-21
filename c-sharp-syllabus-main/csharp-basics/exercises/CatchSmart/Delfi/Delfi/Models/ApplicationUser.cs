using Microsoft.AspNetCore.Identity;

namespace Delfi.Models;

public class ApplicationUser : IdentityUser
{
    public string Avatar { get; set; }
    public string Category { get; set; }
    public int Amount { get; set; }
}