using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BookMVC.Models
{
    public class BookRestService
    {
        readonly static string baseUri = "http://localhost:58982/api/BookClasses/";

        // GET:/Index
        public List<Book> GetBooks()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
               Task<String> response = httpClient.GetStringAsync(uri);
               return JsonConvert.DeserializeObjectAsync<List<Book>>(response.Result).Result;
            }

        }

        // PUT:/Book/Id
        [HttpPost]
        public Book CreateBook(Book book)
        {
            string uri = baseUri;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                var result = client.PostAsync(baseUri, book, new JsonMediaTypeFormatter()).Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Book instance successfully sent to the API");
                    return book;
                }
                else
                {
                    string content = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("oops, an error occurred, here's the raw response: {0}", content);
                    return book;
                }
            }
        }

        // Get:/5
        public Book GetBookById(int id)
        {
            string uri = baseUri + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<Book>(response.Result).Result;
            }
        }

        // GET: Book/Create
        /// Use mvc model-view

        // Delete:/5
        public string DeleteBook(string id)
        {
            string uri = baseUri+id;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(uri).Result;
                return response.Content.ToString();
            }
        }

        // Put: /5
        public async void Put(string Id, Book book)
        {
            string uri = baseUri+Id;
            
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(book);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}/{1}", uri, Id), content);
            }


        }


    }
}