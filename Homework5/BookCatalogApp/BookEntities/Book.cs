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
            get
            {
                return _title;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid book title. Must be not null and not empty.");
                }
                _title = value;
            } 
        }
        public string PublicationDate { get; set; }
        public HashSet<string> Authors { get; set; }

        public Book(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Invalid book title. Must be not null and not empty.");
            }
            Title = title;
            Authors = new HashSet<string>();
        }

        public Book(string title, string publicationDate) : this(title)
        {
            PublicationDate = publicationDate;            
        }

        public bool AddAuthor(string author)
        {
            return Authors.Add(author);
        }
    }
}
