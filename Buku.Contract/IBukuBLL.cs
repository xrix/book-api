using Buku.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buku.Contract
{
    public interface IBukuBLL
    {
        Book CreateBook(Book book);
        Book CreateBookAsync(Book book);
        List<Book> ReadBooks();
        Book ReadBookById(int bookId);
        //Book PutBook(Book book, int bookId);
        Book CreateOrUpdateBook(Book book);
        void DeleteBook(Book bookId);


    }
}
