using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryBuilder
{
    public interface IBookInfo
    {
        string GetTitle();

        string GetDescription();

        string GetAuthor();

        int GetPages();

        string GetReleaseYear();

       
    }
}
