using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.DataAccess;
using Bookish.Web.Models;

namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var checkedOut = BookRepository.CheckedOut();
            return View(checkedOut);
        }

        public ActionResult Book_Library()
        {
            ViewBag.Message = "The Book Library";

            var gotBooks = BookRepository.GetBooks();

            return View(gotBooks);
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpPost]
        public ActionResult Search(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return RedirectToAction("Index");
            }

            var gotBooks = BookRepository.GetBooks();
            string userInputLower = userInput.ToLower();
            var searchList = gotBooks.FindAll(x =>
                x.title.ToLower().Contains(userInputLower) || x.author.ToLower().Contains(userInputLower));
            return View(new SearchResultsModel()
            {
                title = userInput,
                results = searchList
            });
        }

        public ActionResult BookedOut()
        {
            var checkedOut = BookRepository.CheckedOut();
            return View(checkedOut);
        }

        public ActionResult Book_Detail(int book_id)
        {
            var book = new BookWithAvailableCopies(BookRepository.BookDetail(book_id));

            int checkOuts = BookRepository.AvailableCopies().Count(item => item.book_id == book_id);
            book.available_copies -= checkOuts;

            return View(book);
        }

        //public ActionResult AvailableCopies()
        //{
        //    var availableCopies = BookRepository.AvailableCopies();
        //    var books = BookRepository.GetBooks().Select(book => new BookWithAvailableCopies(book)).ToList();
        //    var bookDictionary = books.ToDictionary(book => book.book_id);

        //    foreach (var checkOut in availableCopies)
        //    {
        //        var book = bookDictionary[checkOut.book_id];
        //        --book.available_copies;
        //    }

        //    return View(books);
        //}
    }
}