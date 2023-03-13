using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class WorkplaceDataModel
    {
        public int Id { get; set; }
        public int PrimaryDataId { get; set; }
        public string WorkplaceName { get; set; }
        public string WorkplaceTitle { get; set; }
        public string WorkplaceTenure { get; set; }
    }
}
