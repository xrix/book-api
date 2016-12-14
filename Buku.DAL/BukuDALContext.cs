using System.Data.Entity;

namespace Buku.DAL
{
    public class BukuDALContext : DbContext
    {
        public BukuDALContext() : base("name=bukuconn")
        { }

        public System.Data.Entity.DbSet<Buku.BussinessObject.Book> Book { get; set; }

        public System.Data.Entity.DbSet<Buku.BussinessObject.Author> Author { get; set; }

        public System.Data.Entity.DbSet<Buku.BussinessObject.Student> Student { get; set; }

        //public System.Data.Entity.DbSet<Buku.API.Models.BookResponse> BookResponses { get; set; }
    }
}
