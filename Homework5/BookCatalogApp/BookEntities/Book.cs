using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogApp.BookEntities
{
    internal class Book
    {
        private string _title;
        public string Title 
        {
            get => _title;
            
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid book title. Must be not null and not empty.");
                }
                _title = value;
            } 
        }
        public DateTime? PublicationDate { get; set; }
        private HashSet<string> _authors;

        public Book(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Invalid book title. Must be not null and not empty.");
            }
            Title = title;
            _authors = new HashSet<string>();
        }

        public Book(string title, DateTime? publicationDate) : this(title)
        {
            PublicationDate = publicationDate;            
        }

        public bool AddAuthor(string author)
        {
            return _authors.Add(author);
        }

        public bool RemoveAuthor(string author)
        {
            return _authors.Remove(author);
        }
    }
}
