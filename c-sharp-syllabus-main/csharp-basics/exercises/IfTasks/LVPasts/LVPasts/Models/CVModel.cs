namespace LVPasts.Models;

public class CVModel
{
    public int CvId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Education[] Educations { get; set; }
    public Workplace[] Workplaces { get; set; }
    public Language[] Languages { get; set; } 
}