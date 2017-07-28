using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ComparableBook
    {
    class ComparableBookStartUp
        {
        static void Main(string[] args)
            {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryFull = new Library(bookOne, bookTwo, bookThree);

            //foreach (var book in libraryFull.OrderBy(b => b))
            foreach (var book in libraryFull)
                {
                Console.WriteLine(book);
                }
            }
        }
    }
