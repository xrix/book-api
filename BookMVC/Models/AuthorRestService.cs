using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BookMVC.Models
{
    public class AuthorRestService
    {
        readonly static string authUri = "http://localhost:58982/api/AuthorClasses/";

        // GET:/Index
        public List<Author> GetAuthors()
        {
            string uri = authUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<Author>>(response.Result).Result;
            }

        }
    }
}