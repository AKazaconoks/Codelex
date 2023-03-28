using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Models
{
    public class WorkplaceDataModel
    {
        public int Id { get; set; }
        [Display(Name = "Darbavietas nosaukums")] public string WorkplaceName { get; set; }
        [Display(Name = "Darbavietas amats")] public string WorkplaceTitle { get; set; }
        [Display(Name = "Slodzes apmērs")] public string WorkplaceTenure { get; set; }
    }
}