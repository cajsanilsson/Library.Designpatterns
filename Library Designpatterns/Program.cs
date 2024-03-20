using Library_Designpatterns.LibraryBuilder;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace Library_Designpatterns
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Library library = new Library();
            library.MainMenu();
           
        }
    }
}
