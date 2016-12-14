using Buku.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buku.Contract
{
    public interface IAuthorBLL
    {
        //Author CreateAuthor(Author author);
        List<Author> ReadAuthors();
        Author ReadAuthorById(int authorId);
        //void DeleteAuthor(int authorId);
        //Author EditAuthor(Author author, int authorId);
    }
}
