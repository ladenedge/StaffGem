using System.Collections.Generic;
using NUnit.Framework;

namespace StaffGem
{
    [TestFixture]
    public class CustomDuplicateFinderTests : DuplicateFinderTests
    {
        protected override IDuplicateFinder Finder => new DuplicateFinder(new CustomHashSet<int>());
    }
}
