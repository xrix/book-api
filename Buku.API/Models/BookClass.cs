using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Buku.API.Models
{
    public class BookClass
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public int Stock { get; set; }
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public string Genre { get; set; }
        //public int StudentID { get; set; }

        // Foreign Key
        public int AuthorClassId { get; set; }
        public int StudentClassId { get; set; }
        // Navigation property
        public AuthorClass AuthorClass { get; set; }
        public StudentClass StudentClass { get; set; }
        //O2m reverse
        //public virtual StudentClass Student { get; set; }
    }
}