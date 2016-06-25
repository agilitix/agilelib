using System;
using System.Collections.Generic;
using System.Linq;
using AxUnit;
using NUnit.Framework;

namespace AxEnum.UnitTests
{
    public class EnumUnitTests : ArrangeActAssert
    {
        protected enum EnumUnderTest
        {
            A,
            B = 10,
            C,
            D
        }

        protected IEnumerable<EnumUnderTest> AsEnumerable;

        protected bool AreMatching(string[] stringEnumValues, EnumUnderTest[] enumValues)
        {
            bool matching = stringEnumValues.Length == enumValues.Length;
            for (int i = 0; matching && i < stringEnumValues.Length; ++i)
            {
                EnumUnderTest result = enumValues.ElementAt(i);
                EnumUnderTest input = (EnumUnderTest) Enum.Parse(typeof (EnumUnderTest), stringEnumValues.ElementAt(i));
                matching &= result == input;
            }
            return matching;
        }
    }

    public class EnumUnitTests_check_parsing_from_valid_enum_strings_base : EnumUnitTests
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

    public class EnumUnitTests_check_parsing_from_valid_enum_strings :
        EnumUnitTests_check_parsing_from_valid_enum_strings_base
    {
        public override void Act()
        {
            foreach (string strEnum in InputStringEnumValues)
            {
                EnumUnderTest result = Enum<EnumUnderTest>.ParseName(strEnum);
                Results.Add(result);
            }
        }

        [Test]
        public void Assert_the_strings_and_the_enum_values_are_matching_together()
        {
            Assert.IsTrue(AreMatching(InputStringEnumValues, Results.ToArray()));
        }
    }

    public class EnumUnitTests_check_try_parsing_from_valid_enum_strings :
        EnumUnitTests_check_parsing_from_valid_enum_strings_base
    {
        protected bool Succedded;

        public override void Act()
        {
            Succedded = true;
            foreach (string strEnum in InputStringEnumValues)
            {
                EnumUnderTest result;
                Succedded &= Enum<EnumUnderTest>.TryParseName(strEnum, out result);
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