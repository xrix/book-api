using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Buku.API.Models;

namespace Buku.API.Controllers
{
    public class StudentClassesController : ApiController
    {
        private BukuAPIContext db = new BukuAPIContext();

        // GET: api/StudentClasses
        public IQueryable<StudentClass> GetStudentClasses()
        {
            return db.StudentClasses;
        }

        // GET: api/StudentClasses/5
        [ResponseType(typeof(StudentClass))]
        public IHttpActionResult GetStudentClass(int id)
        {
            StudentClass studentClass = db.StudentClasses.Find(id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return Ok(studentClass);
        }

        // PUT: api/StudentClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentClass(int id, StudentClass studentClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentClass.Id)
            {
                return BadRequest();
            }

            db.Entry(studentClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentClasses
        [ResponseType(typeof(StudentClass))]
        public IHttpActionResult PostStudentClass(StudentClass studentClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentClasses.Add(studentClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentClass.Id }, studentClass);
        }

        // DELETE: api/StudentClasses/5
        [ResponseType(typeof(StudentClass))]
        public IHttpActionResult DeleteStudentClass(int id)
        {
            StudentClass studentClass = db.StudentClasses.Find(id);
            if (studentClass == null)
            {
                return NotFound();
            }

            db.StudentClasses.Remove(studentClass);
            db.SaveChanges();

            return Ok(studentClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentClassExists(int id)
        {
            return db.StudentClasses.Count(e => e.Id == id) > 0;
        }
    }
}