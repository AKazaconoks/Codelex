using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Models
{
    public class LanguageDataModel
    {
        [Display(Name = "Valoda")] public string Language { get; set; }
    }
}