using AutoMapper;
using Buku.API.Models;
using Buku.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace Buku.API.Controllers
{
    public class StudentResponsesController : ApiController
    {
        private IStudentBLL _studentBll;

        public StudentResponsesController(IStudentBLL studentBll)
        {
            _studentBll = studentBll;
        }

        // GET: api/Students
        [Route("api/Students")]
        public List<StudentResponse> GetStudentResponse()
        {
            var std = _studentBll.ReadStudents();
            var output = Mapper.Map<List<StudentResponse>>(std);
            return output;
        }

        // GET : api/Students/{id}
        [Route("api/Students/{id}")]
        public IHttpActionResult GetStudentById(int id)
        {
            var student = _studentBll.ReadStudentById(id);
            var output = Mapper.Map<StudentResponse>(student);
            return Ok(output);
        }

    }
}
