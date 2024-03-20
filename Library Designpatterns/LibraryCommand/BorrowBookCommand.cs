using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryCommand
{
    public class BorrowBookCommand : ICommand
    {
        private LibraryManager LibraryManager;

       

        public BorrowBookCommand(LibraryManager libraryManager) 
        {
            LibraryManager = libraryManager;

        }

        public void Execute()
        {
            LibraryManager.BorrowBook();
        }

    }
}
