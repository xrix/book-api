using Buku.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Buku.MVC.Services
{
    internal class AuthorRESTService
    {
        readonly static string baseUri = "http://localhost:58982/api/Authors/";

        // GET : Index
        public List<AuthorViewModel> GetAuthors()
        {
            string uri = baseUri;
            HttpClient httpClient = new HttpClient();
            Task<string> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<List<AuthorViewModel>>(response.Result).Result;
        }

        // GET : api/Authors/{Id}
        public AuthorViewModel GetAuthorById(int id)
        {
            string uri = baseUri + id;
            HttpClient httpClient = new HttpClient();
            Task<string> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<AuthorViewModel>(response.Result).Result;
        }
    }
}