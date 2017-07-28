using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_CustomList
    {
    public class CustomList<T> : ICustomList<T>
        where T : IComparable<T>
        {
        private readonly IList<T> elements;

        public CustomList()
            {
            this.elements = new List<T>();
            }

        //public CustomList() : this(Enumerable.Empty<T>())
        //    { }

        //public CustomList(IEnumerable<T> collection)
        //    {
        //    this.elements = new List<T>(collection);
        //    }

        public IList<T> Elements
            {
            get { return this.elements; }
            }

        // Methods
        public void Add(T element)
            {
            this.elements.Add(element);
            }

        public bool Contains(T element)
            {
            if (this.elements.Contains(element))
                {
                return true;
                }
            return false;
            }

        public int CountGreaterThan(T element)
            {
            int count = this.elements.Count(e => e.CompareTo(element) > 0);

            return count;
            }

        public T Max()
            {
            return this.Elements.Max();
            }

        public T Min()
            {
            return this.Elements.Min();
            }

        public T Remove(int index)
            {
            var removedElement = this.elements[index];
            this.elements.RemoveAt(index);

            return removedElement;
            }

        public void Swap(int index1, int index2)
            {
            T temp = this.elements[index1];
            this.elements[index1] = this.elements[index2];
            this.elements[index2] = temp;
            }

        //public IEnumerator<T> GetEnumerator()
        //    {
        //    return this.elements.GetEnumerator();
        //    }

        //IEnumerator IEnumerable.GetEnumerator()
        //    {
        //    return this.GetEnumerator();
        //    }

        public string Print()
            {
            var sb = new StringBuilder();

            foreach (var element in this.elements)
                {
                sb.AppendLine(element.ToString());
                }

            return sb.ToString().Trim();
            }
        }
    }
