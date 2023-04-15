using System.ComponentModel.DataAnnotations;

namespace SunFinanceApi.Models;

public class NotificationsCreateRequest
{
    [Required] public int ClientId { get; set; }

    [Required]
    [RegularExpression("(sms|email)")]
    public string Channel { get; set; }

    [Required] public string Content { get; set; }
}