using System.Collections.Generic;
using System.Linq;
using AxQuality;
using NFluent;
using NUnit.Framework;

namespace AxUtils.UnitTests
{
    public class AnonymousEqualityComparerUnitTests : ArrangeActAssert
    {
        public class ItemToCompare
        {
            public string Name { get; set; }
        }

        protected AnonymousEqualityComparer<ItemToCompare> ObjectUnderTest;

        protected IList<ItemToCompare> FirstItemsToCompare;
        protected IList<ItemToCompare> SecondItemsToCompare;

        protected IList<bool> ExpectedResults;
        protected IList<bool> ActualResults;
    }

    public class AnonymousEqualityComparer_test_objects_are_equal : AnonymousEqualityComparerUnitTests
    {
        public override void Arrange()
        {
            FirstItemsToCompare = new List<ItemToCompare>
                                  {
                                      new ItemToCompare {Name = null},
                                      new ItemToCompare {Name = "A"},
                                      new ItemToCompare {Name = "B"},
                                      new ItemToCompare {Name = "C"}
                                  };

            SecondItemsToCompare = new List<ItemToCompare>
                                   {
                                       new ItemToCompare {Name = null},
                                       new ItemToCompare {Name = null},
                                       new ItemToCompare {Name = "B"},
                                       new ItemToCompare {Name = "A"}
                                   };

            ExpectedResults = new List<bool>
                              {
                                  true,
                                  false,
                                  true,
                                  false
                              };

            ObjectUnderTest = new AnonymousEqualityComparer<ItemToCompare>((x, y) => x.Name == y.Name);
        }

        public override void Act()
        {
            ActualResults = FirstItemsToCompare.Zip(SecondItemsToCompare, (a, b) => new {First = a, Second = b})
                                               .Select(x => ObjectUnderTest.Equals(x.First, x.Second))
                                               .ToList();
        }

        [Test]
        public void Assert_comparing_equality_based_on_same_key_is_working()
        {
            Check.That(ActualResults).ContainsExactly(ExpectedResults);
        }
    }
}