using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookCatalogApp.BookEntities
{
    internal class Catalog
    {
        private SortedDictionary<string, Book> books;

        public Catalog()
        {
            books = new SortedDictionary<string, Book>();
        }

        public void AddBook(string iSBN, Book newBook)
        {
            var newISBN = String.Empty;
            var digitsOnly = new Regex(@"^\d{13}$");
            var digitsWithHyphens = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");
            var matchDigitsOnly = digitsOnly.Match(iSBN);
            var matchDigitsWithHyphens = digitsWithHyphens.Match(iSBN);

            if (matchDigitsOnly.Success)
            {
                newISBN = matchDigitsOnly.Value;
            }
            else if (matchDigitsWithHyphens.Success)
            {
                newISBN = matchDigitsWithHyphens.Value.Replace("-", String.Empty);
            }
            else
            {
                throw new ArgumentException("Invalid ISBN number format.");
            }

            if (!books.ContainsKey(newISBN))
            {
                books.Add(newISBN, newBook);
            }
            else
            {
                throw new ArgumentException("ISBN number already in catalog.");
            }
           
        }
    }
}
