using AutoMapper;
using Buku.API.Models;
using Buku.BussinessObject;
using Buku.Contract;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Buku.API.Controllers
{
    public class BookResponsesController : ApiController
    {
        private IBukuBLL _bukuBLL;

        public BookResponsesController(IBukuBLL bukuBll)
        {
            _bukuBLL = bukuBll;
        }

        // GET: api/Books
        //[Authorize(Roles = "User")]
        [Route("api/Books")]
        [HttpGet]
        public List<BookResponse> GetBookResponses()
        {
            var res = _bukuBLL.ReadBooks();
            var output = Mapper.Map<List<BookResponse>>(res);
            return output;
        }

        // GET: api/Book/5
        [Route("api/Books/{Id}")]
        [ResponseType(typeof(BookResponse))]
        public IHttpActionResult GetBookById(int id)
        {
            var res = _bukuBLL.ReadBookById(id);
            var output = Mapper.Map<BookResponse>(res);
            return Ok(output);
        }

    }
};