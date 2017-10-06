using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;

namespace AxUtils.UnitTests
{
    internal class EnumUtilsUnitTests : ArrangeActAssert
    {
        protected enum EnumUnderTest
        {
            [System.ComponentModel.Description("DescA")] A,

            B = 10,

            [System.ComponentModel.Description("DescC")] C,

            [System.ComponentModel.Description("DescD")] D
        }

        protected bool AreMatching(string[] stringEnumValues, EnumUnderTest[] enumValues)
        {
            if (stringEnumValues.Length == enumValues.Length)
            {
                EnumUnderTest[] parsed = stringEnumValues.Select(x => (EnumUnderTest)Enum.Parse(typeof(EnumUnderTest), x)).ToArray();
                return parsed.SequenceEqual(enumValues);
            }

            return false;
        }

        protected string[] GetAllNames()
        {
            return new[] {"A", "B", "C", "D"};
        }

        protected string[] GetAllDescriptions()
        {
            return new[] {"DescA", "DescC", "DescD"};
        }

        protected EnumUnderTest[] GetAllValues()
        {
            return new[] {EnumUnderTest.A, EnumUnderTest.B, EnumUnderTest.C, EnumUnderTest.D};
        }

        protected EnumUnderTest[] GetValuesHavingDescriptions()
        {
            return GetAllValues().Where(x => x != EnumUnderTest.B).ToArray();
        }

        protected EnumInfos<EnumUnderTest>[] GetInfos()
        {
            return new[]
                   {
                       new EnumInfos<EnumUnderTest> {Value = EnumUnderTest.A, Name = "A", Description = "DescA"},
                       new EnumInfos<EnumUnderTest> {Value = EnumUnderTest.B, Name = "B", Description = null},
                       new EnumInfos<EnumUnderTest> {Value = EnumUnderTest.C, Name = "C", Description = "DescC"},
                       new EnumInfos<EnumUnderTest> {Value = EnumUnderTest.D, Name = "D", Description = "DescD"},
                   };
        }
    }

    internal class EnumUtilsUnitTestsRetrieveAllTheDescriptions : EnumUtilsUnitTests
    {
        protected IList<string> ExpectedDescriptions;
        protected IList<string> Result;

        public override void Arrange()
        {
            ExpectedDescriptions = GetAllDescriptions();
        }

        public override void Act()
        {
            Result = EnumUtils<EnumUnderTest>.GetDescriptions().ToList();
        }

        [Test]
        public void Assert_all_descriptions_were_retrieved_as_expected()
        {
            Result.Should().ContainInOrder(ExpectedDescriptions);
        }
    }

    internal class EnumUtilsUnitTestsRetrieveDescriptionsOneByOne : EnumUtilsUnitTestsRetrieveAllTheDescriptions
    {
        public override void Act()
        {
            Result = GetAllValues().Select(EnumUtils<EnumUnderTest>.GetDescription)
                                   .Where(description => description != null)
                                   .ToList();
        }
    }

    internal class EnumUtilsUnitTestsRetrieveValuesAndDescriptionsPairs : EnumUtilsUnitTests
    {
        protected IList<EnumInfos<EnumUnderTest>> ExpectedPairs;
        protected IList<EnumInfos<EnumUnderTest>> Result;

        public override void Arrange()
        {
            ExpectedPairs = GetInfos();
        }

        public override void Act()
        {
            Result = EnumUtils<EnumUnderTest>.GetEnumInfos().ToList();
        }

        [Test]
        public void Assert_all_descriptions_pairs_were_retrieved_as_expected()
        {
            Result.ShouldAllBeEquivalentTo(ExpectedPairs);
        }
    }

    internal class EnumUtilsUnitTestsParsingOnlyExistingDescriptionsToRetrieveEnumValues : EnumUtilsUnitTests
    {
        protected EnumUnderTest[] ExpectedValues;
        protected IList<EnumUnderTest> Result;

        public override void Arrange()
        {
            ExpectedValues = GetValuesHavingDescriptions();
            Result = new List<EnumUnderTest>();
        }

        public override void Act()
        {
            foreach (string description in GetAllDescriptions())
            {
                Result.Add(EnumUtils<EnumUnderTest>.ParseDescription(description));
            }
        }

        [Test]
        public void Assert_all_descriptions_pairs_are_expected()
        {
            Result.Should().ContainInOrder(ExpectedValues);
        }
    }

    internal class EnumUtilsUnitTestsParsingUndefinedDescriptionsShouldRaiseExceptions : EnumUtilsUnitTests
    {
        protected IList<Exception> Result;
        protected IList<Type> Expected;

        public override void Arrange()
        {
            Result = new List<Exception>();
            Expected = new List<Type>
                       {
                           typeof(ArgumentNullException),
                           typeof(KeyNotFoundException),
                           typeof(KeyNotFoundException),
                           typeof(KeyNotFoundException),
                       };
        }

        public override void Act()
        {
            Result.Add(Trying(() => EnumUtils<EnumUnderTest>.ParseDescription(null)));
            Result.Add(Trying(() => EnumUtils<EnumUnderTest>.ParseDescription("")));
            Result.Add(Trying(() => EnumUtils<EnumUnderTest>.ParseDescription("  ")));
            Result.Add(Trying(() => EnumUtils<EnumUnderTest>.ParseDescription("Toto")));
        }

        [Test]
        public void Assert_we_got_expected_exceptions_for_unknow_definitions()
        {
            Result.Select( x => x.GetType()).ShouldAllBeEquivalentTo(Expected);
        }
    }

    internal class EnumUtilsUnitTestsTryingToParseUndefinedDescriptionAlwaysReturnFalse : EnumUtilsUnitTests
    {
        protected IList<bool> Result;

        public override void Arrange()
        {
            Result = new List<bool>();
        }

        public override void Act()
        {
            EnumUnderTest output;
            Result.Add(EnumUtils<EnumUnderTest>.TryParseDescription(null, out output));
            Result.Add(EnumUtils<EnumUnderTest>.TryParseDescription("", out output));
            Result.Add(EnumUtils<EnumUnderTest>.TryParseDescription("  ", out output));
            Result.Add(EnumUtils<EnumUnderTest>.TryParseDescription("Toto", out output));
        }

        [Test]
        public void Assert_all_the_attempts_returned_false_for_unknown_descriptions()
        {
            Result.All(x => x).Should().BeFalse();
        }
    }

    internal class EnumUtilsUnitTestsTryingToParseExistingDescriptionsAlwaysReturnTrue : EnumUtilsUnitTests
    {
        protected IList<bool> Result;

        public override void Arrange()
        {
            Result = new List<bool>();
        }

        public override void Act()
        {
            foreach (string description in GetAllDescriptions())
            {
                EnumUnderTest output;
                Result.Add(EnumUtils<EnumUnderTest>.TryParseDescription(description, out output));
            }
        }

        [Test]
        public void Assert_all_the_attempts_returned_true_for_existing_descriptions()
        {
            Result.All(x => x).Should().BeTrue();
        }
    }

    internal class EnumUtilsUnitTestsParsingNameFromStringsBase : EnumUtilsUnitTests
    {
        protected string[] InputStringEnumValues;
        protected EnumUnderTest[] ExpectedEnumValuesFromStringValues;
        protected IList<EnumUnderTest> Results;

        public override void Arrange()
        {
            InputStringEnumValues = GetAllNames();
            ExpectedEnumValuesFromStringValues = new[] {EnumUnderTest.A, EnumUnderTest.B, EnumUnderTest.C, EnumUnderTest.D};
            Results = new List<EnumUnderTest>();
        }

        public override void Act()
        {
            foreach (string strEnum in InputStringEnumValues)
            {
                EnumUnderTest result = EnumUtils<EnumUnderTest>.Parse(strEnum);
                Results.Add(result);
            }
        }

        [Test]
        public void Assert_the_strings_and_the_enum_values_are_matching_together()
        {
            AreMatching(InputStringEnumValues, Results.ToArray()).Should().BeTrue();
        }
    }

    internal class EnumUtilsUnitTestsTryparsenameFromStrings : EnumUtilsUnitTests
    {
        protected string[] InputStringEnumValues;
        protected EnumUnderTest[] ExpectedEnumValuesFromStringValues;
        protected IList<bool> Result;

        public override void Arrange()
        {
            InputStringEnumValues = GetAllNames();
            ExpectedEnumValuesFromStringValues = new[] {EnumUnderTest.A, EnumUnderTest.B, EnumUnderTest.C, EnumUnderTest.D};
            Result = new List<bool>();
        }

        public override void Act()
        {
            foreach (string strEnum in InputStringEnumValues)
            {
                EnumUnderTest result;
                Result.Add(EnumUtils<EnumUnderTest>.TryParse(strEnum, out result));
            }
        }

        [Test]
        public void Assert_all_try_parse_calls_succeeded()
        {
            Result.All(x => x).Should().BeTrue();
        }
    }
}
