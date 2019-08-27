using System.Collections.Generic;
using NUnit.Framework;

namespace StaffGem
{
    [TestFixture]
    public abstract class DuplicateFinderTests
    {
        protected abstract IDuplicateFinder Finder { get; }

        [Test]
        public void HasDuplicates_throws_with_null_input()
        {
            Assert.That(() => Finder.HasDuplicates(null), Throws.ArgumentNullException);
        }

        protected static readonly IEnumerable<int[]> DuplicatingFixtures = new[]
        {
            new[] { 1, 1 },
            new[] { 42, 1, 42 },
            new[] { 1, -1, -1 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 11 },
        };

        protected static readonly IEnumerable<int[]> NonDuplicatingFixtures = new[]
        {
            new int[0],
            new[] { 0, 1, 2 },
            new[] { 42, 52, 62 },
            new[] { 0, -1, -2 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        };

        [TestCaseSource(nameof(DuplicatingFixtures))]
        public void HasDuplicates_is_true_for_arrays_with_duplicates(int[] input)
        {
            var result = Finder.HasDuplicates(input);
            Assert.That(result, Is.True);
        }

        [TestCaseSource(nameof(NonDuplicatingFixtures))]
        public void HasDuplicates_is_false_for_arrays_without_duplicates(int[] input)
        {
            var result = Finder.HasDuplicates(input);
            Assert.That(result, Is.False);
        }
    }
}
