namespace _09_CollectionHierarchy.Controllers
    {
    public interface IAddCollection<T>
        {
        int Add(T element);
        }
    }