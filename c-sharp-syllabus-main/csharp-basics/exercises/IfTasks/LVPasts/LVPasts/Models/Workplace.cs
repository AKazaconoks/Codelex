namespace LVPasts.Models;

public class Workplace
{
    public string WorkplaceName { get; set; }
    public string WorkplaceTitle { get; set; }
    public string WorkplaceTenure { get; set; }
    public string WorkplaceTime { get; set; }
    public WorkplaceSkill[] WorkplaceSkills { get; set; }
    public Address[] Addresses { get; set; }
}