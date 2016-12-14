using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BookMVC.Models
{
    public class BookRestService
    {
        readonly static string baseUri = "http://localhost:51981/api/Books/";

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

        
    }
}