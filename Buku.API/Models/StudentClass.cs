using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Buku.API.Models
{
    public class StudentClass
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //O2m
        //public virtual ICollection<BookClass> Books { get; set; }
    }
}