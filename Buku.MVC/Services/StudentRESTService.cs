using Buku.MVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Buku.MVC.Controllers
{
    internal class StudentRESTService
    {
        private static string baseUri = "http://localhost:58982/api/Students/";

        public List<AuthorViewModel> GetStudents()
        {
            string uri = baseUri;
            HttpClient httpClient = new HttpClient();
            Task<string> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<List<AuthorViewModel>>(response.Result).Result;
        }

        public StudentViewModel GetStudentById(int id)
        {
            string uri = baseUri+id;
            HttpClient httpClient = new HttpClient();
            Task<string> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<StudentViewModel>(response.Result).Result;
        }
    }
}