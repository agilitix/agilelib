using System;
using System.Collections.Generic;
using System.Linq;
using AxExtensions;
using AxQuality.Sample.Interfaces;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace AxQuality.Sample.UnitTests
{
    public class CalculatorTest : ArrangeActAssert
    {
        protected Accumulator ObjectUnderTest;
        protected IValidator ValidatorMock;

        public override void Arrange()
        {
            // Create the validator mock.
            ValidatorMock = Substitute.For<IValidator>();

            // Create the object to test.
            ObjectUnderTest = new Accumulator(ValidatorMock);
        }
    }

    public class CalculatorTest_adding_sequence_of_valid_numbers : CalculatorTest
    {
        protected Exception ResultException;
        protected double[] Numbers;
        protected double ExpectedResult;

        /// <summary>
        /// Arrange.
        /// </summary>
        public override void Arrange()
        {
            base.Arrange();

            // Numbers to add.
            Numbers = new[] {1.0, -2.0, 3.0, -4.0, 5.0};

            // The expected result.
            ExpectedResult = Numbers.Sum();

            // Setup the validator for each added number.
            Numbers.ForEach(number => { ValidatorMock.IsValid(number).Returns(true); });
        }

        /// <summary>
        /// Act.
        /// </summary>
        public override void Act()
        {
            // Reset the accumulator value.
            ObjectUnderTest.Value = 0;

            // Run the test case : the Add method is called on all the numbers.
            Numbers.ForEach(number =>
                            {
                                Exception ex = Trying(() => ObjectUnderTest.Add(number));
                                if (ResultException == null)
                                {
                                    ResultException = ex; // Store any exception.
                                }
                            });
        }

        /// <summary>
        /// Assert.
        /// </summary>
        [Test]
        public void Assert_accumulator_must_be_equal_to_the_sum_of_all_numbers()
        {
            // The accumulator must be equal to the expected result.
            Check.That(ObjectUnderTest.Value).IsEqualTo(ExpectedResult);
        }

        [Test]
        public void Assert_calculator_should_check_the_validity_of_all_the_added_numbers()
        {
            // The calculator must call the validator to check the validity of each number we have added.
            Numbers.ForEach(number => ValidatorMock.Received(1).IsValid(number));
        }

        [Test]
        public void Assert_calculator_should_not_raise_any_exception()
        {
            // The calculator must not raise any exceptions in our test case.
            Check.That(ResultException).IsNull();
        }
    }

    public class CalculatorTest_adding_sequence_of_invalid_numbers : CalculatorTest
    {
        protected IList<Exception> ResultExceptions;
        protected double[] Numbers;
        protected Exception ExpectedException;

        /// <summary>
        /// Arrange.
        /// </summary>
        public override void Arrange()
        {
            base.Arrange();

            // Reset the accumulator value.
            ObjectUnderTest.Value = 0;

            // Invalid numbers to add.
            Numbers = new[] {double.NaN, double.NegativeInfinity, double.PositiveInfinity};

            // Setup the validator, returns "false" validity for all the numbers.
            Numbers.ForEach(number => { ValidatorMock.IsValid(number).Returns(false); });

            // The expected exception when we try to add invalid numbers.
            ExpectedException = new ArgumentException();

            // The exceptions got from the calculator.
            ResultExceptions = new List<Exception>();
        }

        /// <summary>
        /// Act.
        /// </summary>
        public override void Act()
        {
            // Run the test case.
            Numbers.ForEach(number => { ResultExceptions.Add(Trying(() => ObjectUnderTest.Add(number))); });
        }

        /// <summary>
        /// Assert.
        /// </summary>
        [Test]
        public void Assert_calculator_should_raise_argument_exception_for_all_the_inavalid_numbers()
        {
            // Check the calculator exceptions are matching the expected exception.
            ResultExceptions.ForEach(x => Check.That(x.GetType()).IsEqualTo(ExpectedException.GetType()));
        }

        [Test]
        public void Assert_calculator_should_check_the_numbers_validity()
        {
            // The calculator must call the validator to check the validity of the added numbers.
            Numbers.ForEach(number => ValidatorMock.Received(1).IsValid(number));
        }
    }

    public class CalculatorTest_adding_sequence_of_valid_and_invalid_numbers : CalculatorTest
    {
        protected IList<Type> ResultExceptions;
        protected double[] Numbers;
        protected IList<Type> ExpectedExceptions;

        /// <summary>
        /// Arrange.
        /// </summary>
        public override void Arrange()
        {
            base.Arrange();

            // Reset the accumulator value.
            ObjectUnderTest.Value = 0;

            // Invalid/valid sequence of numbers to add.
            Numbers = new[] {1.0, double.NaN, 4.0, double.NegativeInfinity, double.PositiveInfinity, 7.5};

            // Setup the validator mock.
            ValidatorMock.IsValid(Arg.Any<double>())
                         .Returns(arg =>  !double.IsNaN(arg.Arg<double>())
                                         && !double.IsNegativeInfinity(arg.Arg<double>())
                                         && !double.IsNegativeInfinity(arg.Arg<double>()));

            // The expected exceptions sequence when we add the numbers.
            ExpectedExceptions = new List<Type>
                                 {
                                     null,
                                     typeof(ArgumentException),
                                     null,
                                     typeof(ArgumentException),
                                     null,
                                     null
                                 };

            // The exceptions got from the calculator.
            ResultExceptions = new List<Type>();
        }

        /// <summary>
        /// Act.
        /// </summary>
        public override void Act()
        {
            // Run the test case and store the exceptions types.
            Numbers.ForEach(number =>
                            {
                                Exception ex = Trying(() => ObjectUnderTest.Add(number));
                                ResultExceptions.Add(ex?.GetType());
                            });
        }

        /// <summary>
        /// Assert.
        /// </summary>
        [Test]
        public void Assert_calculator_should_raise_expected_exceptions()
        {
            // Check the calculator has raised the expected exceptions.
            Check.That(ResultExceptions).ContainsExactly(ExpectedExceptions);
        }

        [Test]
        public void Assert_calculator_should_check_the_numbers_validity()
        {
            // The calculator must call the validator to check the validity of the added numbers.
            Numbers.ForEach(number => ValidatorMock.Received(1).IsValid(number));
        }
    }
}
