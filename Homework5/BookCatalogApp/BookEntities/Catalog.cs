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
            var newISBN = FormatISBN(iSBN);            
                       
            if (!books.ContainsKey(newISBN))
            {
                books.Add(newISBN, newBook);
            }
            else
            {
                throw new ArgumentException("ISBN number already in catalog.");
            }           
        }

        // Formats input string to 13 digit ISBN string.
        public string FormatISBN(string iSBN)
        {            
            var digitsOnly = new Regex(@"^\d{13}$");
            var digitsWithHyphens = new Regex(@"^\d{3}-\d-\d{2}-\d{6}-\d$");            

            if (digitsOnly.Match(iSBN).Success)
            {
                return iSBN;
            }
            else if (digitsWithHyphens.Match(iSBN).Success)
            {
                return iSBN.Replace("-", String.Empty);
            }
            else
            {
                throw new ArgumentException("Invalid ISBN number format.");
            }            
        }
    }
}
