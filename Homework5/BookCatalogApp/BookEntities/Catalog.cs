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
        // This class models a book catalog.

        private SortedDictionary<string, Book> _books;

        public Catalog()
        {
            _books = new SortedDictionary<string, Book>();
        }

        // Adds a book to the catalog.
        public void AddBook(string iSBN, Book newBook)
        {            
            if (IsISBNFormatCorrect(iSBN))
            {
                var newISBN = iSBN.Replace("-", String.Empty);
                _books.Add(newISBN, newBook);                
            }
            else
            {
                throw new ArgumentException("Invalid ISBN format.");
            }
        }

        // Inputs ISBN identifier and outputs a Book object.
        public Book GetBook(string iSBN)
        {            
            if (IsISBNFormatCorrect(iSBN))
            {
                Book result = null;
                _books.TryGetValue(iSBN.Replace("-", String.Empty), out result);
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid ISBN format.");
            }            
        }

        // Checks if input string matches ISBN 13 digit format. Returns true if it does.
        private bool IsISBNFormatCorrect(string iSBN)
        {            
            var digitsOnly = new Regex(@"^\d{13}$");
            var digitsWithHyphens = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");

            return digitsOnly.Match(iSBN).Success || digitsWithHyphens.Match(iSBN).Success;                 
        }
    }
}
