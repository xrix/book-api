using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buku.MVC.Services;
using Buku.MVC.Models;

namespace Buku.MVC.Controllers
{
    public class BookController : Controller
    {
        private BookRESTService bookService = new BookRESTService();
        private AuthorRESTService authorServices = new AuthorRESTService();
        private StudentRESTService studentServices = new StudentRESTService();

        // GET: Book
        public ActionResult Index()
        {
            return View(bookService.GetBooks());
        }

        // GET : Book/BookId/{Id}
        public ActionResult Details(int id)
        {
            BookViewModel book = bookService.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // Get : Create
        public ActionResult Create()
        {
            ViewBag.AuthorSelect = GetAllAuthors();
            ViewBag.StudentSelect = GetAllStudents();
            return View();
        }

        // POST : Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Title, Year, Stock, Price, Genre, AuthorId, StudentId")] BookViewModel book, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                book.AuthorId = GetIntString(form["AuthorSelect"]);
                book.StudentId = GetIntString(form["StudentSelect"]);

                bookService.CreateBook(book);

                return RedirectToAction("Index");
            }
            return View(book);
        }

        [NonAction]
        public int GetIntString(string value)
        {
            int outValue = -1;
            bool parsed = Int32.TryParse(value, out outValue);
            if (parsed)
            {
                outValue = Int32.Parse(value);
            }
            return outValue;
        }

        [NonAction]
        public List<SelectListItem> GetAllAuthors()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            authorServices.GetAuthors().ForEach(a => items.Add(new SelectListItem { Text = a.Name, Value = a.Id.ToString() }));
            return items;
        }

        [NonAction]
        public List<SelectListItem> GetAllStudents()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            studentServices.GetStudents().ForEach(a => items.Add(new SelectListItem { Text = a.Name, Value = a.Id.ToString() }));
            return items;
        }
    }
}