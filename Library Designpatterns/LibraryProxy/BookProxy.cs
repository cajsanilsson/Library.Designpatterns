using Library_Designpatterns.LibraryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryProxy
{
    public class BookProxy 
    {
        private Book book = null;

        private DatabaseConnection db = new DatabaseConnection();

        public string Title { get; set; }

        public string Author { get; set; }

        public BookProxy(DatabaseConnection db, string title, string author) 
        {
            this.db = db;
            Title = title;
            Author = author;
        }

        public string Description
        {
            get
            {
                Load();
                return book.Description;
            }
            set
            {
                Load();
                book.Description = value;
            }

        }

        public string ReleaseYear
        {
            get
            {

                Load();
                return book.ReleaseYear;
            }
            set
            {
                Load();
                book.ReleaseYear = value;
            }
                 
        }

        public int Pages 
        { 
            get
            {
                Load();
                return book.Pages;
            }
            set 
            { 
                book.Pages = value;
            }
        }

        public void Load()
        {
            if (book == null)
            {
                
                book = db.GetBook(Title);
            }
        }
        

    }
}
