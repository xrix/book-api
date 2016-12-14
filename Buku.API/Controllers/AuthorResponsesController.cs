using AutoMapper;
using Buku.API.Models;
using Buku.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace Buku.API.Controllers
{
    public class AuthorResponsesController : ApiController
    {
        private IAuthorBLL _authorBll;

        public AuthorResponsesController(IAuthorBLL authorBll)
        {
            _authorBll = authorBll;
        }

        // GET: api/Authors
        [Route("api/Authors")]
        [HttpGet]
        public List<AuthorResponse> GetAuthorResponse()
        {
            var authors = _authorBll.ReadAuthors();
            var output = Mapper.Map<List<AuthorResponse>>(authors);
            return output;
        }

        // GET : api/Authors/{id}
        [Route("api/Authors/{id}")]
        [HttpGet]
        public IHttpActionResult GetStudentById(int id)
        {
            var student = _authorBll.ReadAuthorById(id);
            var output = Mapper.Map<AuthorResponse>(student);
            return Ok(output);
        }

    }
}
