using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BookMVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        //public string AuthorName { get; set; }
        [Display(Name = "Author")]
        public int AuthorClassId { get; set; }
        [Display(Name = "Student")]
        public int StudentClassId { get; set; }
    }

}