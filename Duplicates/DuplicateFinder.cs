using System;

namespace StaffGem
{
    public class DuplicateFinder : IDuplicateFinder
    {
        public DuplicateFinder(ISimpleSet<int> hashSet)
        {
            HashSet = hashSet;
        }

        private ISimpleSet<int> HashSet { get; }

        public bool HasDuplicates(int[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                if (!HashSet.Add(item))
                    return true;

            return false;
        }
    }
}
