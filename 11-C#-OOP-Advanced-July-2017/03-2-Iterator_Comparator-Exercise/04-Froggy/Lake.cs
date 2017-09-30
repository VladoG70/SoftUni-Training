using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04_Froggy
    {
    public class Lake<T> : IEnumerable<int>
        {
        private readonly List<int> stones;
        private int length;

        public Lake() : this(Enumerable.Empty<int>())
            { }

        public Lake(IEnumerable<int> stoneCollection)
            {
            this.length = stoneCollection.Count();
            this.stones = new List<int>(stoneCollection);
            }

        public IEnumerator<int> GetEnumerator()
            {
            // Even Indexes - Ascending
            for (int i = 0; i < this.length; i += 2)
                {
                yield return this.stones[i];
                }
            // Odd Indexes - Descending
            var lastOddIndex = this.length - 1;
            if (lastOddIndex % 2 == 0)
                {
                lastOddIndex--;
                }
            for (int i = lastOddIndex; i >= 0; i -= 2)
                {
                yield return this.stones[i];
                }
            }

        IEnumerator IEnumerable.GetEnumerator()
            {
            return this.GetEnumerator();
            }
        }
    }
