using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookish.DataAccess;

namespace Bookish.Web.Models
{
    public class SearchResultsModel
    {
        public string title { get; set; }
        public List<Book> results { get; set; }
    }
}