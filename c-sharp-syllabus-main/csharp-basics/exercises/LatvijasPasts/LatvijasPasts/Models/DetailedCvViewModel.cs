namespace LatvijasPasts.Models
{
    public class DetailedCvViewModel
    {
        public DataLibrary.Models.PrimaryDataModel PrimaryData { get; set; }
        public List<DataLibrary.Models.EducationDataModel> EducationData { get; set; }
        public List<DataLibrary.Models.WorkplaceDataModel> WorkplaceData { get; set; }
        public List<DataLibrary.Models.WorkplaceSkillDataModel> WorkplaceSkillData { get; set; }
        public List<DataLibrary.Models.LanguageDataModel> LanguageData { get; set; }
    }
}