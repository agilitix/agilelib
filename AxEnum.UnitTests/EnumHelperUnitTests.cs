using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AxUnit;
using NUnit.Framework;

namespace AxEnum.UnitTests
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
                EnumUnderTest[] parsed = stringEnumValues.Select(x => (EnumUnderTest) Enum.Parse(typeof (EnumUnderTest), x)).ToArray();
                return parsed.SequenceEqual(enumValues);
            }
            return false;
        }

        protected IList<string> GetDescriptions()
        {
            Type type = typeof (EnumUnderTest);
            return Enum.GetValues(typeof (EnumUnderTest))
                       .Cast<EnumUnderTest>()
                       .AsEnumerable()
                       .Select(enumValue => type.GetField(enumValue.ToString()))
                       .Select(fieldInfo => fieldInfo.GetCustomAttributes(typeof (System.ComponentModel.DescriptionAttribute), false)
                                                     .Cast<System.ComponentModel.DescriptionAttribute>())
                       .Select(attribute => attribute.Select(x => x.Description).FirstOrDefault())
                       .ToList();
        }

        protected IList<EnumUnderTest> GetValues()
        {
            return Enum.GetValues(typeof (EnumUnderTest)).Cast<EnumUnderTest>().ToList();
        }
    }

    public class EnumHelperUnitTests_check_descriptions : EnumHelperUnitTests
    {
        protected string[] ExpectedDescriptions;
        protected IList<string> Result;

        public override void Arrange()
        {
            ExpectedDescriptions = new[] {"DescA", null, "DescC", "DescD"};
        }

        public override void Act()
        {
            Result = EnumHelper<EnumUnderTest>.GetDescriptions().ToList();
        }

        [Test]
        public void Assert_all_descriptions_are_matching()
        {
            Assert.IsTrue(ExpectedDescriptions.SequenceEqual(Result));
        }
    }

    public class EnumHelperUnitTests_check_descriptions_one_by_one : EnumHelperUnitTests_check_descriptions
    {
        public override void Arrange()
        {
            base.Arrange();
            Result = new List<string>();
        }

        public override void Act()
        {
            foreach (EnumUnderTest enumValue in Enum.GetValues(typeof (EnumUnderTest)))
            {
                Result.Add(EnumHelper<EnumUnderTest>.GetDescription(enumValue));
            }
        }
    }

    public class EnumHelperUnitTests_check_values_and_descriptions_pairs : EnumHelperUnitTests
    {
        protected KeyValuePair<EnumUnderTest, string>[] ExpectedPairs;
        protected IList<KeyValuePair<EnumUnderTest, string>> Result;

        public override void Arrange()
        {
            ExpectedPairs = new[]
                            {
                                new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.A, "DescA"),
                                new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.B, null),
                                new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.C, "DescC"),
                                new KeyValuePair<EnumUnderTest, string>(EnumUnderTest.D, "DescD"),
                            };
        }

        public override void Act()
        {
            Result = EnumHelper<EnumUnderTest>.GetValuesAndDescriptions().ToList();
        }

        [Test]
        public void Assert_all_descriptions_are_matching()
        {
            Assert.IsTrue(ExpectedPairs.SequenceEqual(Result));
        }
    }

    public class EnumHelperUnitTests_check_parsing_descriptions_to_retrieve_values : EnumHelperUnitTests
    {
        protected IList<EnumUnderTest> ExpectedValues;
        protected IList<EnumUnderTest> Result;

        public override void Arrange()
        {
            ExpectedValues = Enum.GetValues(typeof (EnumUnderTest)).Cast<EnumUnderTest>().ToList();
            ExpectedValues.Remove(EnumUnderTest.B); // "B" has no description
            Result = new List<EnumUnderTest>();
        }

        public override void Act()
        {
            Type type = typeof (EnumUnderTest);
            foreach (EnumUnderTest enumValue in Enum.GetValues(typeof (EnumUnderTest)).Cast<EnumUnderTest>().AsEnumerable())
            {
                FieldInfo fieldInfo = type.GetField(enumValue.ToString());
                IEnumerable<System.ComponentModel.DescriptionAttribute> attributes =
                    fieldInfo.GetCustomAttributes(typeof (System.ComponentModel.DescriptionAttribute), false)
                             .Cast<System.ComponentModel.DescriptionAttribute>();
                string description = attributes.Select(x => x.Description)
                                               .FirstOrDefault();
                if (description != null)
                {
                    Result.Add(EnumHelper<EnumUnderTest>.ParseDescription(description));
                }
            }
        }

        [Test]
        public void Assert_all_descriptions_are_matching()
        {
            Assert.IsTrue(ExpectedValues.SequenceEqual(Result));
        }
    }

    public class EnumHelperUnitTests_check_parsing_undefined_descriptions_should_raise_exceptions : EnumHelperUnitTests
    {
        protected IList<Exception> Result;

        public override void Arrange()
        {
            Result = new List<Exception>();
        }

        public override void Act()
        {
            Result.Add(Trying(() => EnumHelper<EnumUnderTest>.ParseDescription(null)));
            Result.Add(Trying(() => EnumHelper<EnumUnderTest>.ParseDescription("")));
            Result.Add(Trying(() => EnumHelper<EnumUnderTest>.ParseDescription("  ")));
            Result.Add(Trying(() => EnumHelper<EnumUnderTest>.ParseDescription("Toto")));
        }

        [Test]
        public void Assert_we_got_the_expected_exception_for_unknow_definitions()
        {
            foreach (Exception ex in Result)
            {
                Assert.IsInstanceOf<InvalidEnumArgumentException>(ex);
            }
        }
    }

    public class EnumHelperUnitTests_check_trying_to_parse_undefined_description_always_return_false : EnumHelperUnitTests
    {
        protected IList<bool> Result;

        public override void Arrange()
        {
            Result = new List<bool>();
        }

        public override void Act()
        {
            EnumUnderTest output;
            Result.Add(EnumHelper<EnumUnderTest>.TryParseDescription(null, out output));
            Result.Add(EnumHelper<EnumUnderTest>.TryParseDescription("", out output));
            Result.Add(EnumHelper<EnumUnderTest>.TryParseDescription("  ", out output));
            Result.Add(EnumHelper<EnumUnderTest>.TryParseDescription("Toto", out output));
        }

        [Test]
        public void Assert_all_the_tries_returned_false_for_unknown_descriptions()
        {
            foreach (bool b in Result)
            {
                Assert.IsFalse(b);
            }
        }
    }

    public class EnumHelperUnitTests_check_trying_to_parse_existing_descriptions_always_succeed : EnumHelperUnitTests
    {
        protected IList<bool> Result;

        public override void Arrange()
        {
            Result = new List<bool>();
        }

        public override void Act()
        {
            Type type = typeof (EnumUnderTest);
            foreach (EnumUnderTest enumValue in Enum.GetValues(typeof (EnumUnderTest)).Cast<EnumUnderTest>().AsEnumerable())
            {
                FieldInfo fieldInfo = type.GetField(enumValue.ToString());
                IEnumerable<System.ComponentModel.DescriptionAttribute> attributes =
                    fieldInfo.GetCustomAttributes(typeof (System.ComponentModel.DescriptionAttribute), false)
                             .Cast<System.ComponentModel.DescriptionAttribute>();
                string description = attributes.Select(x => x.Description)
                                               .FirstOrDefault();
                if (description != null)
                {
                    EnumUnderTest output;
                    Result.Add(EnumHelper<EnumUnderTest>.TryParseDescription(description, out output));
                }
            }
        }

        [Test]
        public void Assert_all_descriptions_tries_have_succeeded()
        {
            Assert.IsTrue(Result.All(x => x));
        }
    }

    public class EnumHelperUnitTests_check_parsing_from_strings_base : EnumHelperUnitTests
    {
        protected string[] InputStringEnumValues;
        protected EnumUnderTest[] ExpectedEnumValuesFromStringValues;
        protected IList<EnumUnderTest> Results;

        public override void Arrange()
        {
            InputStringEnumValues = new[] {"A", "B", "C", "D"};
            Results = new List<EnumUnderTest>();
            ExpectedEnumValuesFromStringValues = new[] {EnumUnderTest.A, EnumUnderTest.B, EnumUnderTest.C, EnumUnderTest.D};
        }
    }

    public class EnumHelperUnitTests_check_parsename_from_strings :
        EnumHelperUnitTests_check_parsing_from_strings_base
    {
        public override void Act()
        {
            foreach (string strEnum in InputStringEnumValues)
            {
                EnumUnderTest result = EnumHelper<EnumUnderTest>.ParseName(strEnum);
                Results.Add(result);
            }
        }

        [Test]
        public void Assert_the_strings_and_the_enum_values_are_matching_together()
        {
            Assert.IsTrue(AreMatching(InputStringEnumValues, Results.ToArray()));
        }
    }

    public class EnumHelperUnitTests_check_tryparsename_from_strings :
        EnumHelperUnitTests_check_parsing_from_strings_base
    {
        protected bool Succedded;

        public override void Act()
        {
            Succedded = true;
            foreach (string strEnum in InputStringEnumValues)
            {
                EnumUnderTest result;
                Succedded &= EnumHelper<EnumUnderTest>.TryParseName(strEnum, out result);
                Results.Add(result);
            }
        }

        [Test]
        public void Assert_all_try_parse_calls_succeeded()
        {
            Assert.IsTrue(Succedded);
        }

        [Test]
        public void Assert_the_strings_and_the_enum_values_are_matching_together()
        {
            Assert.IsTrue(AreMatching(InputStringEnumValues, Results.ToArray()));
        }
    }
}