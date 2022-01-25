using BookCatalogApp.BookEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book("First title");
            var book2 = new Book("Second title");

            var catalog = new Catalog();

            catalog.AddBook("0123456789012", book1);
            catalog.AddBook("012-3-45-678901-2", book2);
        }
    }
}
