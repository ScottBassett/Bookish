using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Bookish.DataAccess
{
    public static class BookRepository 
    {
        public static List<Book> GetBooks()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var bookList = connection.Query<Book>("Select * from books order by title ASC NULLS LAST");
            
           return bookList.ToList();
        }
        public static List<Users> GetUsers()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var userList = connection.Query<Users>("Select * from users");
            return userList.ToList();
        }
        public static List<BookedOut> CheckedOut()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var bookList = connection.Query<BookedOut>("Select title, author, due_date from checked_out join books using(book_id)");

            return bookList.ToList();
        }

        public static Book BookDetail(int book_id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var book = connection.QueryFirst<Book>("select title, author, copies from books where book_id = @id", new { id = book_id });

            return book;
        }

        //public static BookWithAvailableCopies BookDetail2(int book_id)
        //{
        //     var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
        //     var connection = new NpgsqlConnection(connectionString);
        //     connection.Open();

        //     var book = connection.QueryFirst<Book>("select title, author, copies from books where book_id = @id", new { id = book_id });
        //     var checkOuts = connection.QueryFirst<int>("select count(*) from checked_out where book_id = @id", new { id = book_id });

        //     var bookWithAvailableCopies = new BookWithAvailableCopies(book);
        //     bookWithAvailableCopies.available_copies -= checkOuts;
        //     return bookWithAvailableCopies;
        //}

        //public static BookWithAvailableCopies BookDetail3(int book_id)
        //{
        //    var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
        //    var connection = new NpgsqlConnection(connectionString);
        //    connection.Open();

        //    var book = connection.QueryFirst<BookWithAvailableCopies>(@"select title, author, copies,
        //                     copies - (select count(*) from checked_out where checked_out.book_id = books.book_id) as available_copies
        //                     from books where book_id = @id", new { id = book_id });

        //    return book;
        //}

        public static List<Book> AvailableCopies()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var availableCopies = connection.Query<Book>("Select book_id from checked_out");

            return availableCopies.ToList();
        }
    }
}
