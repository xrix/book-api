using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buku.BussinessObject
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }

        // Foreign Key
        public int AuthorId { get; set; }
        public int StudentId { get; set; }

        // Navigation property
        public virtual Author Author { get; set; }
        public virtual Student Student { get; set; }
    }
}
