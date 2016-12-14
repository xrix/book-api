using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Buku.API.Models
{
    public class BookRequest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int StudentId { get; set; }

        // Navigation property
        //public AuthorResponse Author { get; set; }
        //public StudentResponse Student { get; set; }
    }
}