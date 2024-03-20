using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryBuilder
{
    public class Book : IBookInfo
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }

        public string ReleaseYear { get; set; }

    

        public Book(string title, string author, string description, int pages, string releaseyear)
        {
            Title = title;

            Author = author;

            Description = description;

            Pages = pages;

            ReleaseYear = releaseyear;

          
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetDescription()
        {
            return Description;
        }

        public string GetAuthor()
        {
            return Author;
        }

        public int GetPages()
        {
            return Pages;
        }

        public string GetReleaseYear()
        {
            return ReleaseYear;
        }

        

    }
}
