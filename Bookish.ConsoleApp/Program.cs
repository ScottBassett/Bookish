using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Bookish.DataAccess;
using Npgsql;
using Dapper;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach ( var book in BookRepository.GetBooks())
            {
                Console.WriteLine($"Title: {book.title}, Author: {book.author}, ISBN: {book.isbn}");
            }

            Console.ReadLine();
        }
    }
}
