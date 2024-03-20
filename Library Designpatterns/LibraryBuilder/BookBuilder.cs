using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryBuilder
{
    public class BookBuilder
    {
        private string Title { get; set; } = "";

        private string Author { get; set; } = "Unknown";

        private string Description { get; set; } = "No description available.";

        private int Pages { get; set; } = 0;

        private string ReleaseYear { get; set; } = "1900 something";

        

        public BookBuilder setDefaultAuthor()
        {
            
            Author = "Unknown";
            return this;
        }

        public BookBuilder setDefaultDescription()
        {
            Description = "No description available.";
            return this;
        }

        public BookBuilder setDefaultPage()
        {
            Pages = 0;
            return this;
        }
        public BookBuilder setDefaultReleaseYear()
        {
            ReleaseYear = "1900 something";
            return this;
        }

        public BookBuilder setTitle(string title)
        {
            Title = title;
            return this;
        }

        public BookBuilder setDescription(string description)
        {
            Description = description;
            return this;
        }

        public BookBuilder setAuthor(string author)
        {
            Author = author;
            return this;
        }

        public BookBuilder setPages(int pages)
        {
            Pages = pages;
            return this;
        }

        public BookBuilder setReleaseYear(string releaseyear)
        {
            ReleaseYear = releaseyear;
            return this;
        }

        public Book Build()
        {
            return new Book(Title, Author, Description, Pages, ReleaseYear);
        }
    }
}
