using Library_Designpatterns.LibraryProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryCommand
{
    public class AddBookCommand : ICommand
    {
        private LibraryManager LibraryManager;

        
        public AddBookCommand(LibraryManager libraryManager)
        {
            LibraryManager = libraryManager;
            
        }
        public void Execute()
        {
            LibraryManager.AddBook();
            
        }
    }
}
