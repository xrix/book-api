using Buku.Contract;
using System;
using Buku.BussinessObject;
using Buku.DAL;
using static Buku.Core.ExceptionCode;
using Buku.Core;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Collections.Generic;

namespace Buku.BLL
{
    public class BukuBLL : IBukuBLL
    {
        private BukuDALContext db = new BukuDALContext();

        public Book CreateBook(Book book)
        {
            db.Book.Add(book);
            db.SaveChanges();
            return book;
        }

        public void DeleteBook(Book bookId)
        {
            Book book = db.Book.Find(bookId);
            if (book == null){throw new BukuExceptions(BukuExceptionCode.BukuNotFound);}
            db.Book.Remove(bookId);
            db.SaveChanges();
        }

        public Book CreateOrUpdateBook(Book book)
        {
            var existing = ReadBookById(book.Id);
            if (existing != null)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            else {
                book = CreateBook(book);
            }
            return book;
        }

        public Book ReadBookById(int bookId)
        {
            Book book = db.Book.Find(bookId);
            return book;
        }

        public List<Book> ReadBooks()
        {
            return db.Book.ToList();
        }

        public Book CreateBookAsync(Book book)
        {
            db.Book.Add(book);
            db.SaveChangesAsync();
            return book;
        }
    }
}
