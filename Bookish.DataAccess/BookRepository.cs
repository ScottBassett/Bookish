using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookish.ConsoleApp;
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

            var bookList = connection.Query<Book>("Select * from books order by author");
            return bookList.ToList();
        }
    }
}
