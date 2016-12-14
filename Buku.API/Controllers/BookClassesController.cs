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
    public class BookClassesController : ApiController
    {
        private BukuAPIContext db = new BukuAPIContext();

        // GET: api/BookClasses1
        public IQueryable<BookClass> GetBookClasses()
        {
            return db.BookClasses;
        }

        // GET: api/BookClasses1/5
        [ResponseType(typeof(BookClass))]
        public IHttpActionResult GetBookClass(int id)
        {
            BookClass bookClass = db.BookClasses.Find(id);
            if (bookClass == null)
            {
                return NotFound();
            }

            return Ok(bookClass);
        }

        // PUT: api/BookClasses1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookClass(int id, BookClass bookClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookClass.Id)
            {
                return BadRequest();
            }

            db.Entry(bookClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookClassExists(id))
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

        // POST: api/BookClasses1
        [ResponseType(typeof(BookClass))]
        public IHttpActionResult PostBookClass(BookClass bookClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookClasses.Add(bookClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bookClass.Id }, bookClass);
        }

        // DELETE: api/BookClasses1/5
        [ResponseType(typeof(BookClass))]
        public IHttpActionResult DeleteBookClass(int id)
        {
            BookClass bookClass = db.BookClasses.Find(id);
            if (bookClass == null)
            {
                return NotFound();
            }

            db.BookClasses.Remove(bookClass);
            db.SaveChanges();

            return Ok(bookClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookClassExists(int id)
        {
            return db.BookClasses.Count(e => e.Id == id) > 0;
        }
    }
}