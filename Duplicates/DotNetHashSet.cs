using System.Collections.Generic;

namespace StaffGem
{
    /// <summary>
    /// Simplified wrapper for System.Collections.Generic.HashSet.
    /// </summary>
    /// <typeparam name="T">Type of items to be contained in this set.</typeparam>
    public class DotNetHashSet<T> : ISimpleSet<T>
    {
        private HashSet<T> HashSet { get; } = new HashSet<T>();

        public bool Add(T item)
        {
            return HashSet.Add(item);
        }
    }
}
