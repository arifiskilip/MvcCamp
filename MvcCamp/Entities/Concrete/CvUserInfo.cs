using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CvUserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Age { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
        public string LinkedinUrl { get; set; }

        public ICollection<CvSkill> CvSkills { get; set; }
    }
}
