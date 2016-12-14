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
    public class AuthorClassesController : ApiController
    {
        private BukuAPIContext db = new BukuAPIContext();

        // GET: api/AuthorClasses
        public IQueryable<AuthorClass> GetAuthorClasses()
        {
            return db.AuthorClasses;
        }

        // GET: api/AuthorClasses/5
        [ResponseType(typeof(AuthorClass))]
        public IHttpActionResult GetAuthorClass(int id)
        {
            AuthorClass authorClass = db.AuthorClasses.Find(id);
            if (authorClass == null)
            {
                return NotFound();
            }

            return Ok(authorClass);
        }

        // PUT: api/AuthorClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthorClass(int id, AuthorClass authorClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authorClass.Id)
            {
                return BadRequest();
            }

            db.Entry(authorClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorClassExists(id))
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

        // POST: api/AuthorClasses
        [ResponseType(typeof(AuthorClass))]
        public IHttpActionResult PostAuthorClass(AuthorClass authorClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AuthorClasses.Add(authorClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = authorClass.Id }, authorClass);
        }

        // DELETE: api/AuthorClasses/5
        [ResponseType(typeof(AuthorClass))]
        public IHttpActionResult DeleteAuthorClass(int id)
        {
            AuthorClass authorClass = db.AuthorClasses.Find(id);
            if (authorClass == null)
            {
                return NotFound();
            }

            db.AuthorClasses.Remove(authorClass);
            db.SaveChanges();

            return Ok(authorClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorClassExists(int id)
        {
            return db.AuthorClasses.Count(e => e.Id == id) > 0;
        }
    }
}