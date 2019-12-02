using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();

            var connectionString = ConfigurationManager.ConnectionStrings["Bookish"].ConnectionString;
            var connection = new NpgsqlConnection(connectionString);

            connection.Open();
        }

    }
}
