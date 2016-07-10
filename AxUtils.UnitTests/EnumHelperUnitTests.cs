using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AxQuality;
using NUnit.Framework;

namespace AxUtils.UnitTests
{
    public class EnumHelperUnitTests : ArrangeActAssert
    {
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
                EnumUnderTest[] parsed = stringEnumValues.Select(x => (EnumUnderTest) System.Enum.Parse(typeof (EnumUnderTest), x)).ToArray();
                return parsed.SequenceEqual(enumValues);
            }
            return false;
        }

        protected string[] GetAllNames()
        {
            return new[] { "A", "B", "C", "D" };
        }

        protected string[] GetAllDescriptions()
        {
            return new[] {"DescA", null, "DescC", "DescD"};
        }

        protected string[] GetExistingDescriptions()
        {
            return GetAllDescriptions().Except(new string[] {null}).ToArray();
        }

        protected EnumUnderTest[] GetAllValues()
        {
            return new[] {EnumUnderTest.A, EnumUnderTest.B, EnumUnderTest.C, EnumUnderTest.D};
        }

        protected EnumUnderTest[] GetValuesHavingDescriptions()
        {
            return GetAllValues().Except(new[] {EnumUnderTest.B}).ToArray();
        }

        protected KeyValuePair<EnumUnderTest, string>[] GetValuesAndDescriptions()
        {
            return new[]
                   {
                       new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.A, "DescA"),
                       new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.B, null),
                       new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.C, "DescC"),
                       new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.D, "DescD"),
                   };
        }
    }

    public class EnumHelperUnitTests_retrieve_all_the_descriptions : EnumHelperUnitTests
    {
        protected string[] ExpectedDescriptions;
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

    public class EnumHelperUnitTests_retrieve_descriptions_one_by_one : EnumHelperUnitTests_retrieve_all_the_descriptions
    {
        public override void Arrange()
        {
            base.Arrange();
            Result = new List<string>();
        }

        public override void Act()
        {
            foreach (EnumUnderTest enumValue in GetAllValues())
            {
                Result.Add(EnumUtils<EnumUnderTest>.GetDescription(enumValue));
            }
        }
    }

    public class EnumHelperUnitTests_retrieve_values_and_descriptions_pairs : EnumHelperUnitTests
    {
        protected KeyValuePair<EnumUnderTest, string>[] ExpectedPairs;
        protected IList<KeyValuePair<EnumUnderTest, string>> Result;

        public override void Arrange()
        {
            ExpectedPairs = GetValuesAndDescriptions();
        }

        public override void Act()
        {
            Result = EnumUtils<EnumUnderTest>.GetValuesAndDescriptions().ToList();
        }

        [Test]
        public void Assert_all_descriptions_pairs_were_retrieved_as_expected()
        {
            Assert.IsTrue(ExpectedPairs.SequenceEqual(Result));
        }
    }

    public class EnumHelperUnitTests_parsing_only_existing_descriptions_to_retrieve_enum_values : EnumHelperUnitTests
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
            foreach (string description in GetExistingDescriptions())
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

    public class EnumHelperUnitTests_parsing_undefined_descriptions_should_raise_exceptions : EnumHelperUnitTests
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

    public class EnumHelperUnitTests_trying_to_parse_undefined_description_always_return_false : EnumHelperUnitTests
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

    public class EnumHelperUnitTests_trying_to_parse_existing_descriptions_always_return_true : EnumHelperUnitTests
    {
        protected IList<bool> Result;

        public override void Arrange()
        {
            Result = new List<bool>();
        }

        public override void Act()
        {
            foreach (string description in GetExistingDescriptions())
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

    public class EnumHelperUnitTests_parsing_name_from_strings_base : EnumHelperUnitTests
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

    public class EnumHelperUnitTestsTryparsenameFromStrings : EnumHelperUnitTests
    {
        protected string[] InputStringEnumValues;
        protected EnumUnderTest[] ExpectedEnumValuesFromStringValues;
        protected IList<bool> Result;

        public override void Arrange()
        {
            InputStringEnumValues = GetAllNames();
            ExpectedEnumValuesFromStringValues = new[] { EnumUnderTest.A, EnumUnderTest.B, EnumUnderTest.C, EnumUnderTest.D };
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