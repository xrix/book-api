using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buku.API.Controllers;
using Buku.Contract;
using NSubstitute;
using Buku.BussinessObject;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using Buku.API.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace Buku.Tests
{
    [TestClass]
    public class BukuControllerTest
    {
        private IBukuBLL _bukuBLL;

        [TestInitialize]
        public void TestSetup()
        {
            _bukuBLL = Substitute.For<IBukuBLL>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _bukuBLL = null;
        }



        [TestMethod]
        public void TestGetBook_WhenOk_ReturnOk()
        {

            var initBooks = _bukuBLL.ReadBooks().ReturnsForAnyArgs(new List<Book>() { GetTestBook() });

            _bukuBLL.CreateBookAsync(new Book()).ReturnsForAnyArgs(GetTestBook());

            var controller = new BookResponsesController(_bukuBLL)
            {
                Request = Substitute.For<HttpRequestMessage>()
            };
            var response = controller.GetBookResponses();
            //int newCount = response.Count;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreNotEqual(initBooks, response);
        }


        private Book GetTestBook()
        {
            var testBook = new Book()
            {
                Id = 999,
                Title = "Test Book",
                Year = 1813,
                Price = 9.99M,
                Genre = "Fake",
                AuthorId = 1,
                StudentId = 4
            };

            return testBook;
        }

    }
}
