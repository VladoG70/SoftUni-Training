using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
    {
    private List<Book> books;

    public Library(params Book[] books)
        {
        this.books = new List<Book>(books);
        }

    public IEnumerator<Book> GetEnumerator()
        {
        return new LibraryIterator(this.books);
        }

    IEnumerator IEnumerable.GetEnumerator()
        {
        return this.GetEnumerator();
        }


    private class LibraryIterator : IEnumerator<Book>
        {
        private List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
            {
            this.Reset();
            this.books = new List<Book>(books);
            }

        public void Dispose()
            { }

        public bool MoveNext()
            {
            this.currentIndex++;
            if (this.currentIndex < this.books.Count)
                {
                return true;
                }
            return false;
            }

        public void Reset()
            {
            this.currentIndex = -1;
            }

        public Book Current
            {
            get { return this.books[this.currentIndex]; }
            }

        object IEnumerator.Current
            {
            get { return this.Current; }
            }
        }
    }