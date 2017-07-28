using System.Collections.Generic;
using _09_CollectionHierarchy.Controllers;

namespace _09_CollectionHierarchy.Action
    {
    public class AddCollection<T> : IAddCollection<T>
        {
        public AddCollection()
            {
            this.Data = new List<T>();
            }

        protected List<T> Data { get; set; }

        public virtual int Add(T element)
            {
            this.Data.Add(element);
            return this.Data.Count - 1;
            }
        }
    }
