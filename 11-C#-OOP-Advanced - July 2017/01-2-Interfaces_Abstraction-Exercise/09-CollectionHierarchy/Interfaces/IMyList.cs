using System.Collections.Generic;

namespace _09_CollectionHierarchy.Action
    {
    public interface IMyList<T> : IAddRemoveCollection<T>
        {
        IReadOnlyCollection<T> Used { get; }
        }
    }