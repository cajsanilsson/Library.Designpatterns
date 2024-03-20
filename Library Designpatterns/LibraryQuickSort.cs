using Library_Designpatterns.LibraryProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns
{
    public class LibraryQuickSort
    {
        public static void QuickSort(List<BookProxy> books)
        {
            QuickSort(books, 0, books.Count - 1);
        }

        private static void QuickSort(List<BookProxy> books, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(books, left, right);
                QuickSort(books, left, pivotIndex - 1);
                QuickSort(books, pivotIndex + 1, right);
            }
        }

        private static int Partition(List<BookProxy> books, int left, int right)
        {
            string pivot = books[right].Title;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (String.Compare(books[j].Title, pivot, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    i++;
                    Swap(books, i, j);
                }
            }

            Swap(books, i + 1, right);
            return i + 1;
        }

        private static void Swap(List<BookProxy> books, int i, int j)
        {
            BookProxy temp = books[i];
            books[i] = books[j];
            books[j] = temp;
        }
    }
}
