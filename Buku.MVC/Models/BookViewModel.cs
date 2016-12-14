using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Buku.MVC.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public int StudentId { get; set; }

        // Navigation property
        [Display(Name = "Author")]
        public virtual AuthorViewModel AuthorResponse { get; set; }
        [Display(Name = "Student")]
        public virtual StudentViewModel StudentResponse { get; set; }
    }
}