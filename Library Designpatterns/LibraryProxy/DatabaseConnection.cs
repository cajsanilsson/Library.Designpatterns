using Library_Designpatterns.LibraryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryProxy
{
    public class DatabaseConnection
    {
        

        private Book book = null;

        //Skapa lista med böcker som finns i "databasen"
        List<Book> bookInDatabase = new List<Book>();

        BookBuilder bookBuilder = new BookBuilder();

        public DatabaseConnection()
        {
            BookBuilder bookBuilder = new BookBuilder();

            Book book1 = bookBuilder.setTitle("A Confederacy of Dunces")
                                 .setDescription("Great book, go read it!")
                                 .setPages(350)
                                 .setReleaseYear("1980")
                                 .Build();

            Book book2 = bookBuilder.setTitle("Crime and Punishment")
                                .setAuthor("Fyodor Dostoyevsky")
                                .setDefaultDescription()
                                .setPages(490)
                                .setReleaseYear("2003")
                                .Build();

            Book book3 = bookBuilder.setTitle("Beyond Good and Evil")
                                .setDescription("You can't go wrong with this one!")
                                .setAuthor("Friedrich Nietzsche")
                                .setPages(800)
                                .setReleaseYear("2019")
                                .Build();

            Book book4 = bookBuilder.setTitle("Flush")
                               .setDefaultDescription()
                               .setAuthor("Virginia Wolf")
                               .setPages(850)
                               .setReleaseYear("1955")
                               .Build();

            Book book5 = bookBuilder.setTitle("Dune")
                                .setDescription("Science fiction at it's best!")
                                .setAuthor("Frank Herbet")
                                .setPages(900)
                                .setReleaseYear("2015")
                                .Build();

            Book book6 = bookBuilder.setTitle("English dictionary")
                                .setDefaultAuthor()
                                .setDescription("Many many words!")
                                .setPages(2000)
                                .setReleaseYear("2015")
                                .Build();




            //Adds books to database list.
            bookInDatabase.Add(book1);
            bookInDatabase.Add(book2);
            bookInDatabase.Add(book3);
            bookInDatabase.Add(book4);
            bookInDatabase.Add(book5);
            bookInDatabase.Add(book6);
        }

        
        public List<BookProxy> GetBookProxies()
        {
            List<BookProxy> bookProxies  = new List<BookProxy>();
            foreach (var book in bookInDatabase)
            {
                bookProxies.Add(new BookProxy(this, book.Title, book.Author));
            }
            return bookProxies;
        }

        public Book? GetBook(string title)
        {
            foreach (var book in bookInDatabase)
            {
                if (book.Title == title)
                {
                    return book;
                }
            }
            return null;
        }

        public List<Book> GetBookDatabase()
        {
            return bookInDatabase;
        }

        public void AddBookToDatabase(Book newBook)
        {
            bookInDatabase.Add(newBook);
        }

    }
}
