using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Buku.API.Models
{
    public class BukuAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BukuAPIContext() : base("name=BukuAPIContext")
        {
        }

        public System.Data.Entity.DbSet<Buku.API.Models.BookClass> BookClasses { get; set; }

        public System.Data.Entity.DbSet<Buku.API.Models.AuthorClass> AuthorClasses { get; set; }

        public System.Data.Entity.DbSet<Buku.API.Models.StudentClass> StudentClasses { get; set; }
    }
}
