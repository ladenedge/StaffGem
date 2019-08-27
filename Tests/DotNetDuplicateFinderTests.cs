using System.Collections.Generic;
using NUnit.Framework;

namespace StaffGem
{
    [TestFixture]
    public class DotNetDuplicateFinderTests : DuplicateFinderTests
    {
        protected override IDuplicateFinder Finder => new DuplicateFinder(new DotNetHashSet<int>());
    }
}
