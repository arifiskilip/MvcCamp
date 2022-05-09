using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class HeadingDetailDto
    {
        public int Id { get; set; }
        public string HeadingName { get; set; }
        public string CategoryName { get; set; }
        public string WriterName { get; set; }
    }
}
