using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class EducationDataModel
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public string EducationFaculty { get; set; }
        public string EducationDirection { get; set; }
        public string EducationLevel { get; set; }
        public string EducationStatus { get; set; }
        public int PrimaryDataId { get; set; }
    }
}
