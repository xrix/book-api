using Buku.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Buku.MVC.Services
{
    internal class BookRESTService
    {
        readonly static string baseUri = "http://book-api.api.local/api/Books/";

        // GET:/Books
        public List<BookViewModel> GetBooks()
        {
            string uri = baseUri;
            HttpClient httpClient = new HttpClient();
            Task<String> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<List<BookViewModel>>(response.Result).Result;
        }

        // GET:/Books/{Id}
        public BookViewModel GetBookById(int id)
        {
            string uri = baseUri + id;
            HttpClient httpClient = new HttpClient();
            Task<String> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<BookViewModel>(response.Result).Result;
        }

        // POST: /Books/{book}
        [HttpPost]
        public BookViewModel CreateBook(BookViewModel book)
        {
            string uri = "http://book-api.api.local/api/Book/Create";
            HttpClient client = new HttpClient();
            var result = client.PostAsync(uri, book, new JsonMediaTypeFormatter()).Result;
            string content = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Book instance successfully sent to the API");
            }
            else
            {
                Console.WriteLine("oops, an error occurred, here's the raw response: {0}", content);
            }
            return book;
        }
    }
}