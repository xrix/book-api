using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookMVC.Models;

namespace BookMVC.Controllers
{
    public class BookController : Controller
    {
        private BookRestService bookRestService = new BookRestService();
        private AuthorRestService authorRestService = new AuthorRestService();

        // GET: /Book/
        public ActionResult Index()
        {
            return View(bookRestService.GetBooks());
        }

        // GET: /Book/5
        public ActionResult Details(int id = 0)
        {
            Book book = bookRestService.GetBookById(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Book/Create
        public ActionResult Create()
        {
            ViewBag.Authors = GetAllAuthors();
            return View();
        }


        // POST: /Book/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Title, Year, Stock, Price, Genre, AuthorId, Authors, StudentClassId")] Book book, FormCollection bookform)
        {
            if (ModelState.IsValid)
            {
                // need so get last id to assign to new book
                int newId = GetNewBookId();

                book.Id = newId;
                book.AuthorClassId = GetAuthId(bookform);
                book.StudentClassId = 1;
                bookRestService.CreateBook(book);

                //harus pake await >> var act = String.Format("Details/{0}", newId);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // Assingn nextID based in max([Id])+1
        // default:1
        [NonAction]
        public int GetNewBookId()
        {
            var books = bookRestService.GetBooks();
            int newId = 1;
            if (books.Count > 1)
            {
                int index = books.Count() - 1;
                newId = books[index].Id + 1;
            }
            return newId;
        }

        // Convert author id from str to int, default 1 if source is none 
        [NonAction]
        public int GetAuthId(FormCollection bookform)
        {
            int autValue = 1;
            string autString = bookform["Authors"];
            bool parsed = Int32.TryParse(autString, out autValue);
            if (parsed)
            {
                autValue = Int32.Parse(autString);
            }
            return autValue;
        }

        // Convert author id from str to int, default 1 if source is none 
        [NonAction]
        public List<SelectListItem> GetAllAuthors()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            bool select = false;
            authorRestService.GetAuthors().ForEach(a => items.Add(new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected=select }));

            return items;
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int id2 = id.GetValueOrDefault();
            Book book = bookRestService.GetBookById(id2);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == string.Empty)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int id2 = Int32.Parse(id);
            Book book = bookRestService.GetBookById(id2);
            if (book == null)
            {
                return HttpNotFound();
            }
            string statusCode = bookRestService.DeleteBook(id);
            Console.WriteLine($"Deleted (HTTP Status = {statusCode})");
            return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int id2 = id.GetValueOrDefault();
            Book book = bookRestService.GetBookById(id2);
            if (book == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> ats = GetAllAuthors();
            ViewBag.Authors = ats;
            var i = ats.FindIndex(a => a.Value == "1");
            if (i >= 0) { ats[i].Selected = true; }
            return View(book);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Title, Year, Stock, Price, Genre, AuthorId, Authors")] Book book, FormCollection bookform)
        {
            if (ModelState.IsValid)
            {
                //book.AuthorId = GetAuthId(bookform);
                //bookRestService.Put(bookform["Id"], book);

                var act = String.Format("Details/{0}", book.Id); 
                return RedirectToAction(act); //if << the value need to refresh
                //return RedirectToAction("Index"); 
            }
            return View(book);
        }

    }
}
