using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03_Stack
    {
    public class Stack<T> : IEnumerable<T>
        {
        private List<T> elements;

        public Stack()
            {
            this.elements = new List<T>();
            }

        public void Push(params T[] collection)
            {
            for (int i = 0; i < collection.Length; i++)
                {
                this.elements.Add(collection[i]);
                }
            }

        public void Pop()
            {
            if (this.elements.Count == 0)
                {
                throw new ArgumentException("No elements");
                }
            var lastIndex = this.elements.Count - 1;
            this.elements.RemoveAt(lastIndex);
            }


        public IEnumerator<T> GetEnumerator()
            {
            //return this.elements.GetEnumerator();
            for (int i = this.elements.Count - 1; i >= 0; i--)
                {
                yield return this.elements[i];
                }
            for (int i = this.elements.Count - 1; i >= 0; i--)
                {
                yield return this.elements[i];
                }
            }

        IEnumerator IEnumerable.GetEnumerator()
            {
            return this.GetEnumerator();
            }
        }
    }
