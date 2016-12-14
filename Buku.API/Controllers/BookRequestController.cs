using AutoMapper;
using Buku.API.Models;
using Buku.BussinessObject;
using Buku.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Buku.API.Controllers
{
    public class BookRequestController : ApiController
    {
        private IBukuBLL _bukuBll;

        public BookRequestController() { }

        /// <summary>
        /// Initialize a new instance of the class
        /// </summary>
        /// <param name="bukuBll"></param>
        public BookRequestController(IBukuBLL bukuBll)
        {
            _bukuBll = bukuBll;
        }

        // POST: api/Books/Create
        [Route("api/Book/Create")]
        [ResponseType(typeof(BookRequest))]
        public async Task<IHttpActionResult> Post([FromBody]BookRequest bookInput)
        {
            var book = Mapper.Map<Book>(bookInput);
            book.Id = GetNewBookId();
            var new_book = _bukuBll.CreateBookAsync(book);

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        [Route("Delete")]
        [HttpPost]
        public IHttpActionResult Delete(BookResponse bookResponse)
        {
            var bookToDelete = Mapper.Map<Book>(bookResponse);
            _bukuBll.DeleteBook(bookToDelete);
            return Ok(new BaseMessageResponse());
        }

        [NonAction]
        public int GetNewBookId()
        {
            var books = _bukuBll.ReadBooks();
            int newId = 1;
            if (books.Count > 1)
            {
                int index = books.Count() - 1;
                newId = books[index].Id + 1;
            }
            return newId;
        }
    }
}
