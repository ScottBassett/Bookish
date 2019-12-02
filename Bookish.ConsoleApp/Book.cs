using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.ConsoleApp
{
    class Book
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int isbn { get; set; }
        public int copies { get; set; }
    }
}
