using _09_CollectionHierarchy.Controllers;

namespace _09_CollectionHierarchy.Action
    {
    public interface IAddRemoveCollection<T> : IAddCollection<T>
        {
        T Remove();
        }
    }