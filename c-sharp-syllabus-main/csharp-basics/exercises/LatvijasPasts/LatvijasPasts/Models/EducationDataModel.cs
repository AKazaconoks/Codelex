using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Models
{
    public class EducationDataModel
    {
        [Display(Name = "Iestādes nosaukums")] public string EducationName { get; set; }
        [Display(Name = "Fakultāte")] public string EducationFaculty { get; set; }
        [Display(Name = "Virziens")] public string EducationDirection { get; set; }
        [Display(Name = "Izglitības līmenis")] public string EducationLevel { get; set; }
        [Display(Name = "Statuss")] public string EducationStatus { get; set; }
    }
}