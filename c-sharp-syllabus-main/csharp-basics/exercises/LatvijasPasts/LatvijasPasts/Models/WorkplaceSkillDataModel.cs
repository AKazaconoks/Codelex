using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Models
{
    public class WorkplaceSkillDataModel
    {
        public int WorkplaceId { get; set; }
        [Display(Name = "Apraksts")] public string SkillDescription { get; set; }
        [Display(Name = "Veids (pamatdarbs/sasniegums/papildus prasme)")] public string SkillType { get; set; }
    }
}
