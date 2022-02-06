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
            var book3 = new Book("Third title");

            var catalog = new Catalog();

            catalog.AddBook("312-3-45-678901-3", book1);
            catalog.AddBook("3123456789012", book2);
            catalog.AddBook("111-2-45-666666-7", book3);            
        }
    }
}
