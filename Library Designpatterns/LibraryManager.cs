using Library_Designpatterns.LibraryBuilder;
using Library_Designpatterns.LibraryProxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Designpatterns
{
    public class LibraryManager 
    {

        //List of books.
        private List<Book> _bookInDatabase;

        //List of borrowed books.
        List<BookProxy> borrowedBooks = new List<BookProxy>();

        //List of bookproxy.
        List<BookProxy> proxy = new List<BookProxy>();  

        //Instance of LibraryQuickSort.
        LibraryQuickSort sort;

        //Instance of Database connection.
        DatabaseConnection db = new DatabaseConnection();

        //Instance of BookBuilder.
        BookBuilder bookBuilder = new BookBuilder();

        public LibraryManager(List<Book> bookInDatabase) 
        {
            proxy = db.GetBookProxies();

            _bookInDatabase = bookInDatabase;
        }

        //Function that let's user borrow book.
        public void BorrowBook()
        {
            Console.WriteLine("Which book do you want to borrow?");
            
            for (int i = 0; i < proxy.Count; i++)
            {
                LibraryQuickSort.QuickSort(proxy);
                Console.WriteLine($"{i + 1}. {proxy[i].Title} by {proxy[i].Author}");
            }

            try
            {
                int selectedIndex = int.Parse(Console.ReadLine()) - 1;

                if (selectedIndex >= 0 && selectedIndex < proxy.Count)
                {
                    BookProxy selectedBook = proxy[selectedIndex];


                    Console.WriteLine();
                    Console.WriteLine($"You borrowed the book: {selectedBook.Title} written by {selectedBook.Author}");
                    Console.WriteLine($"Description: {selectedBook.Description}");
                    Console.WriteLine($"Release year: {selectedBook.ReleaseYear}");
                    Console.WriteLine($"Number of pages: {selectedBook.Pages}");
                    Console.ReadKey();

                    borrowedBooks.Add(selectedBook);
                    proxy.Remove(selectedBook);
                }
                else
                {
                    Console.WriteLine("Invalid book selection.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            
        }

        //Function that let's user add a new book to the library.
        public void AddBook()
        {
            try
            {
                BookBuilder bookBuilder = new BookBuilder(); // Skapa en instans av BookBuilder

                Console.WriteLine("Title: ");
                string newTitle = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newTitle))
                {
                    Console.WriteLine("You have to give the book a title.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Author (Press Enter for default): ");
                string newAuthor = Console.ReadLine();

                Console.WriteLine("Description (Press Enter for default): ");
                string newDescription = Console.ReadLine();
                Console.WriteLine("Pages: ");
                int newPages = int.Parse(Console.ReadLine());

                Console.WriteLine("Release year (Press Enter for default): ");
                string newYear = Console.ReadLine();

                Book newbook;

                if (string.IsNullOrWhiteSpace(newAuthor) && string.IsNullOrWhiteSpace(newDescription) && string.IsNullOrWhiteSpace(newYear))
                {
                    newbook = bookBuilder.setTitle(newTitle)
                                         .setDefaultAuthor()
                                         .setDefaultDescription()
                                         .setPages(newPages)
                                         .setDefaultReleaseYear()
                                         .Build();
                    db.AddBookToDatabase(newbook);
                    proxy.Add(new BookProxy(db, newTitle, "Unknown"));

                }
                else
                {
                    newbook = bookBuilder.setTitle(newTitle)
                                         .setAuthor(newAuthor)
                                         .setDescription(newDescription)
                                         .setPages(newPages)
                                         .setReleaseYear(newYear)
                                         .Build();
                    db.AddBookToDatabase(newbook);
                    proxy.Add(new BookProxy(db, newTitle, newAuthor));

                    Console.WriteLine($"{newTitle} is now added to the library!");
                    Console.ReadKey();
                }
            }
            catch 
            {
                Console.WriteLine("You forgot to fill in pages or used letters instead of numbers, try again.");
                Console.ReadKey();
            }
        }

        //Function that let's user return book.
        public void ReturnBook()
        {
            Console.WriteLine("Which book do you want to return?");

            for (int i = 0; i < borrowedBooks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {borrowedBooks[i].Title} by {borrowedBooks[i].Author}");
            }

            try
            {
                int selectedIndex = int.Parse(Console.ReadLine()) - 1;

                if (selectedIndex >= 0 && selectedIndex < borrowedBooks.Count)
                {
                    BookProxy returnedBook = borrowedBooks[selectedIndex];

                    Console.WriteLine($"You returned the book: {returnedBook.Title}");
                    Console.ReadKey();

                    borrowedBooks.RemoveAt(selectedIndex);
                    proxy.Add(returnedBook);
                }
                else
                {
                    Console.WriteLine("Invalid book selection.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

