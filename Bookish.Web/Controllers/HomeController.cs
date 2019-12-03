using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.DataAccess;

namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Search(string title)
        {
            return View();
        }

    }
}