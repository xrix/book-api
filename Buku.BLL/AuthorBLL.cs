using Buku.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buku.BussinessObject;
using Buku.DAL;

namespace Buku.BLL
{
    public class AuthorBLL : IAuthorBLL
    {
        private BukuDALContext db = new BukuDALContext();

        public Author ReadAuthorById(int authorId)
        {
            Author author = db.Author.Find(authorId);
            return author;
        }

        public List<Author> ReadAuthors()
        {
            return db.Author.ToList();
        }
    }
}
