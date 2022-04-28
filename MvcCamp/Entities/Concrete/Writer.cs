﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        [StringLength(100)]
        public string About { get; set; }
        [StringLength(100)]
        public string WriterImage { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public bool WriterStatus { get; set; }


        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
