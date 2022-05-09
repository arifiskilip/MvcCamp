using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Detail1 { get; set; }
        [StringLength(1000)]
        public string Detail2 { get; set; }
        [StringLength(100)]
        public string Image1 { get; set; }
        [StringLength(100)]
        public string Image2 { get; set; }
        public bool Statu { get; set; }
    }
}
