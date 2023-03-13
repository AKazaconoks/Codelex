using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLibrary.Models
{
    public class WorkplaceSkillDataModel
    {
        public int SkillId { get; set; }
        public int WorkplaceId { get; set; }
        public string SkillDescription { get; set; }
        public string SkillType { get; set; }
    }
}
