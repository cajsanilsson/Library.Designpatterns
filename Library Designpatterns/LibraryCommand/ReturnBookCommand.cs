using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryCommand
{
    public class ReturnBookCommand : ICommand
    {
        private LibraryManager LibraryManager;


        public ReturnBookCommand(LibraryManager libraryManager) 
        {
           LibraryManager = libraryManager;
        }

        public void Execute()   
        {
            LibraryManager.ReturnBook();
        
        }
    }
}
