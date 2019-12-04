using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class Book
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public int copies { get; set; }

    }

    public class BookWithAvailableCopies : Book {
        public BookWithAvailableCopies(Book book)
        {
            book_id = book.book_id;
            title = book.title;
            author = book.author;
            copies = book.copies;
            isbn = book.isbn;
            available_copies = book.copies;
        }

        public int available_copies { get; set; }
    }
}
