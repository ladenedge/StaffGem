using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StaffGem
{
    /// <summary>
    /// A simple hashing set implementation with chaining on collisions.
    /// </summary>
    /// <typeparam name="T">Type of items to be contained in this set.</typeparam>
    public class CustomHashSet<T> : ISimpleSet<T>
    {
        /// <summary>
        /// Creates a new hashing set with the default equality comparer.
        /// </summary>
        public CustomHashSet()
        {
            _comparer = EqualityComparer<T>.Default;
        }

        const int _bucketCount = 10;
        readonly Bucket[] _buckets = new Bucket[_bucketCount];
        readonly IEqualityComparer<T> _comparer;

        /// <summary>
        /// Adds the supplied item to the set if it's not already present.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns><b>true</b> if the item was added to the set, or <b>false</b> if it was already present.</returns>
        public bool Add(T item)
        {
            var bucket = FindBucketFor(item);
            return bucket.TryAddItem(item);
        }

        private Bucket FindBucketFor(T item)
        {
            var index = Math.Abs(item.GetHashCode()) % _bucketCount;
            Debug.Assert(index >= 0 && index < _buckets.Length);

            if (_buckets[index] == null)
                _buckets[index] = new Bucket(_comparer);

            return _buckets[index];
        }

        private class Bucket : List<T>
        {
            public Bucket(IEqualityComparer<T> comparer)
            {
                _comparer = comparer;
            }

            readonly IEqualityComparer<T> _comparer;

            public bool TryAddItem(T item)
            {
                foreach (var node in this)
                    if (_comparer.Equals(node, item))
                        return false;

                Add(item);
                return true;
            }
        }
    }
}
