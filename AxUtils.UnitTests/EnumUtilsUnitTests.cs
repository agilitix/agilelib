using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AxQuality;
using NUnit.Framework;

namespace AxUtils.UnitTests
{
    public class EnumUtilsUnitTests : ArrangeActAssert
    {
        protected AnonymousEqualityComparer<EnumInfos<EnumUnderTest>> _comparer = new AnonymousEqualityComparer<EnumInfos<EnumUnderTest>>((x, y) =>
                                                                                                                                          x.Value == y.Value
                                                                                                                                          && x.Description
                                                                                                                                          == y.Description
                                                                                                                                          && x.Name == y.Name);

        protected enum EnumUnderTest
        {
            [System.ComponentModel.Description("DescA")]
            A,

            B = 10,

            [System.ComponentModel.Description("DescC")]
            C,

            [System.ComponentModel.Description("DescD")]
            D
        }

        protected bool AreMatching(string[] stringEnumValues, EnumUnderTest[] enumValues)
        {
            if (stringEnumValues.Length == enumValues.Length)
            {
                EnumUnderTest[] parsed = stringEnumValues.Select(x => (EnumUnderTest) Enum.Parse(typeof (EnumUnderTest), x)).ToArray();
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
            return GetAllValues().Except(new[] {EnumUnderTest.B}).ToArray();
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

    public class EnumUtilsUnitTestsRetrieveAllTheDescriptions : EnumUtilsUnitTests
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
            Assert.IsTrue(ExpectedDescriptions.SequenceEqual(Result));
        }
    }

    public class EnumUtilsUnitTestsRetrieveDescriptionsOneByOne : EnumUtilsUnitTestsRetrieveAllTheDescriptions
    {
        public override void Act()
        {
            Result = GetAllValues().Select(EnumUtils<EnumUnderTest>.GetDescription)
                                   .Where(description => description != null)
                                   .ToList();
        }
    }

    public class EnumUtilsUnitTestsRetrieveValuesAndDescriptionsPairs : EnumUtilsUnitTests
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
            Assert.IsTrue(ExpectedPairs.SequenceEqual(Result, _comparer));
        }
    }

    public class EnumUtilsUnitTestsParsingOnlyExistingDescriptionsToRetrieveEnumValues : EnumUtilsUnitTests
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
            Assert.IsTrue(ExpectedValues.SequenceEqual(Result));
        }
    }

    public class EnumUtilsUnitTestsParsingUndefinedDescriptionsShouldRaiseExceptions : EnumUtilsUnitTests
    {
        protected IList<Exception> Result;

        public override void Arrange()
        {
            Result = new List<Exception>();
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
            foreach (Exception ex in Result)
            {
                Assert.IsInstanceOf<InvalidEnumArgumentException>(ex);
            }
        }
    }

    public class EnumUtilsUnitTestsTryingToParseUndefinedDescriptionAlwaysReturnFalse : EnumUtilsUnitTests
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
            Assert.IsTrue(!Result.All(x => x));
        }
    }

    public class EnumUtilsUnitTestsTryingToParseExistingDescriptionsAlwaysReturnTrue : EnumUtilsUnitTests
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
            Assert.IsTrue(Result.All(x => x));
        }
    }

    public class EnumUtilsUnitTestsParsingNameFromStringsBase : EnumUtilsUnitTests
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
                EnumUnderTest result = EnumUtils<EnumUnderTest>.ParseName(strEnum);
                Results.Add(result);
            }
        }

        [Test]
        public void Assert_the_strings_and_the_enum_values_are_matching_together()
        {
            Assert.IsTrue(AreMatching(InputStringEnumValues, Results.ToArray()));
        }
    }

    public class EnumUtilsUnitTestsTryparsenameFromStrings : EnumUtilsUnitTests
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
                Result.Add(EnumUtils<EnumUnderTest>.TryParseName(strEnum, out result));
            }
        }

        [Test]
        public void Assert_all_try_parse_calls_succeeded()
        {
            Assert.IsTrue(Result.All(x => x));
        }
    }
}