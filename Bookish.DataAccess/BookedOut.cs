using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookish.DataAccess;

namespace Bookish.DataAccess
{
    public class BookedOut : Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public DateTime? due_date { get; set; } 
    }
}