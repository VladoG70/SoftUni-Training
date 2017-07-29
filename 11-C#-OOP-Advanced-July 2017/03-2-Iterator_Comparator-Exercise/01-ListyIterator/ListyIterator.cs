
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ListyIterator
    {
    public class ListyIterator<T>
        {
        private int currentIndex;
        private readonly List<T> elements;

        public ListyIterator() : this(Enumerable.Empty<T>())
            { }

        public ListyIterator(IEnumerable<T> collection)
            {
            this.currentIndex = 0;
            this.elements = new List<T>(collection);
            }

        public bool Move()
            {
            if (this.HasNext())
                {
                this.currentIndex++;
                return true;
                }

            return false;
            }

        public bool HasNext()
            {
            return (this.currentIndex + 1) < this.elements.Count;
            }

        public void Print()
            {
            if (this.elements.Count == 0)
                {
                throw new ArgumentException("Invalid Operation!");
                }
            Console.WriteLine(this.elements[this.currentIndex]);
            }
        }
    }
