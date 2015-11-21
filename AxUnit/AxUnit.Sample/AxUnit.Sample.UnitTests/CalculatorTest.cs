using System;
using System.Collections.Generic;
using System.Linq;
using AxEnum;
using AxEnumerable;
using AxUnit.Sample.Interfaces;
using Moq;
using NUnit.Framework;

namespace AxUnit.Sample.UnitTests
{
    public class CalculatorTest : ArrangeActAssert
    {
        /// <summary>
        /// The object to stress.
        /// </summary>
        protected Accumulator TestedObject;

        /// <summary>
        /// The validator mock need by the calculator.
        /// </summary>
        protected Mock<IValidator> ValidatorMock;

        public CalculatorTest()
        {
            // Create the validator mock.
            ValidatorMock = new Mock<IValidator>();

            // Create the object to test.
            TestedObject = new Accumulator(ValidatorMock.Object);
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
            // Numbers to add.
            Numbers = new[] {1.0, -2.0, 3.0, -4.0, 5.0};

            // The expected result.
            ExpectedResult = Numbers.Sum();

            // Setup the validator for each added number.
            Numbers.ForEach(number => { ValidatorMock.Setup(v => v.IsValid(number)).Returns(true); });
        }

        /// <summary>
        /// Act.
        /// </summary>
        public override void Act()
        {
            // Reset the accumulator value.
            TestedObject.Value = 0;

            // Run the test case : the Add method is called on all the numbers.
            Numbers.ForEach(number =>
            {
                Exception ex = Try(() => TestedObject.Add(number));
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
            Assert.AreEqual(TestedObject.Value, ExpectedResult);
        }

        [Test]
        public void Assert_calculator_should_check_the_validity_of_all_the_added_numbers()
        {
            // The calculator must call the validator to check the validity of each number we have added.
            Numbers.ForEach(number => { ValidatorMock.Verify(v => v.IsValid(number), Times.Once); });
        }

        [Test]
        public void Assert_calculator_should_not_raise_any_exception()
        {
            // The calculator must not raise any exceptions in our test case.
            Assert.IsNull(ResultException);
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
            // Reset the accumulator value.
            TestedObject.Value = 0;

            // Invalid numbers to add.
            Numbers = new[] {double.NaN, double.NegativeInfinity, double.PositiveInfinity};

            // Setup the validator, returns "false" validity for all the numbers.
            Numbers.ForEach(number => { ValidatorMock.Setup(v => v.IsValid(number)).Returns(false); });

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
            Numbers.ForEach(number => { ResultExceptions.Add(Try(() => TestedObject.Add(number))); });
        }

        /// <summary>
        /// Assert.
        /// </summary>
        [Test]
        public void Assert_calculator_should_raise_argument_exception_for_all_the_inavalid_numbers()
        {
            // Check the calculator exceptions are matching the expected exception.
            ResultExceptions.ForEach(x => Assert.AreEqual(x.GetType(), ExpectedException.GetType()));
        }

        [Test]
        public void Assert_calculator_should_check_the_numbers_validity()
        {
            // The calculator must call the validator to check the validitity of the added numbers.
            Numbers.ForEach(number => { ValidatorMock.Verify(v => v.IsValid(number), Times.Once); });
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
            // Reset the accumulator value.
            TestedObject.Value = 0;

            // Invalid/valid sequence of numbers to add.
            Numbers = new[] {1.0, double.NaN, 4.0, double.NegativeInfinity, double.PositiveInfinity, 7.5};

            // Setup the validator mock.
            ValidatorMock.Setup(v => v.IsValid(It.IsAny<double>()))
                .Returns((double number) => !double.IsNaN(number) &&
                                            !double.IsNegativeInfinity(number) &&
                                            !double.IsNegativeInfinity(number));

            // The expected exceptions sequence when we add the numbers.
            ExpectedExceptions = new List<Type>
            {
                null,
                typeof (ArgumentException),
                null,
                typeof (ArgumentException),
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
                Exception ex = Try(() => TestedObject.Add(number));
                ResultExceptions.Add(ex != null ? ex.GetType() : null);
            });
        }

        /// <summary>
        /// Assert.
        /// </summary>
        [Test]
        public void Assert_calculator_should_raise_expected_exceptions()
        {
            // Check the calculator has raised the expected exceptions.
            Assert.IsTrue(ResultExceptions.SequenceEqual(ExpectedExceptions));
        }

        [Test]
        public void Assert_calculator_should_check_the_numbers_validity()
        {
            // The calculator must call the validator to check the validitity of the added numbers.
            Numbers.ForEach(number => { ValidatorMock.Verify(validator => validator.IsValid(number), Times.Once); });
        }
    }
}