using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Models
{
    public class PrimaryDataModel
    {
        public int Id { get; set; }
        [Display(Name = "Vārds")] public string FirstName { get; set; }
        [Display(Name = "Uzvārds")] public string LastName { get; set; }
        [Display(Name = "Numurs")] public string PhoneNumber { get; set; }
        [Display(Name = "Email")] public string EmailAddress { get; set; }
    }
}