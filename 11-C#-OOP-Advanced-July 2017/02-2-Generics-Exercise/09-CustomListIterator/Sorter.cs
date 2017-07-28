using System;
using System.Linq;

namespace _09_CustomListIterator
    {
    public class Sorter
        {

        public static CustomList<T> Sort<T>(CustomList<T> customList)
            where T : IComparable<T>
            {
            var temp = customList.Elements.OrderBy(e => e);

            return new CustomList<T>(temp);
            }
        }
    }
