using System;
using System.Linq;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;

namespace AxCommandLine.UnitTests
{
    internal class CommandLineArgumentsTests_argument_without_value : ArrangeActAssert
    {
        protected CommandLineArguments ObjectUnderTest;
        protected string[] Arguments;

        protected string ExpectedValue;
        protected string GetValueResult;
        protected bool TryGetValueCall;
        protected string TryGetValueOutput;

        public override void Arrange()
        {
            Arguments = new[] {"-test"};
            ExpectedValue = string.Empty;
        }

        public override void Act()
        {
            ObjectUnderTest = new CommandLineArguments(Arguments);
            GetValueResult = ObjectUnderTest.Get<string>("test");
            TryGetValueCall = ObjectUnderTest.TryGet("test", out TryGetValueOutput);
        }

        [Test]
        public void Assert_argument_without_value_exists_as_empty_string()
        {
            GetValueResult.Should().Be(ExpectedValue);

            TryGetValueCall.Should().BeTrue();
            TryGetValueOutput.Should().Be(ExpectedValue);
        }

        [Test]
        public void Assert_command_line_arguments_has_only_one_entry()
        {
            ObjectUnderTest.Count().Should().Be(1);
        }

        [Test]
        public void Assert_command_line_arguments_contains_requested_name()
        {
            ObjectUnderTest.Contains("test").Should().BeTrue();
        }
    }

    internal class CommandLineArgumentsTests_argument_with_integer_value : ArrangeActAssert
    {
        protected CommandLineArguments[] ObjectsUnderTest;
        protected string[] Arguments;

        protected int ExpectedValue;

        protected int[] GetValueResult;
        protected bool[] TryGetValueCall;
        protected int[] TryGetValueOutput;

        public override void Arrange()
        {
            Arguments = new[]
                        {
                            "--testInt=12345",
                            "--testInt:12345",
                            "/testInt=12345",
                            "/testInt:12345",
                            "-testInt=12345",
                            "-testInt:12345",
                        };
            ExpectedValue = 12345;

            GetValueResult = new int[Arguments.Length];
            TryGetValueCall = new bool[Arguments.Length];
            TryGetValueOutput = new int[Arguments.Length];

            ObjectsUnderTest = new CommandLineArguments[Arguments.Length];
            foreach (string argument in Arguments)
            {
                ObjectsUnderTest[Array.IndexOf(Arguments, argument)] = new CommandLineArguments(argument);
            }
        }

        public override void Act()
        {
            for (int index = 0; index < Arguments.Length; ++index)
            {
                GetValueResult[index] = ObjectsUnderTest[index].Get<int>("testInt");
                TryGetValueCall[index] = ObjectsUnderTest[index].TryGet("testInt", out TryGetValueOutput[index]);
            }
        }

        [Test]
        public void Assert_getting_integer_value_has_succeeded()
        {
            GetValueResult.All(x => x == ExpectedValue).Should().BeTrue();
        }

        [Test]
        public void Assert_argument_has_only_one_entry()
        {
            ObjectsUnderTest.All(x => x.Count() == 1).Should().BeTrue();
        }

        [Test]
        public void Assert_trying_to_get_integer_value_has_succeeded()
        {
            TryGetValueCall.All(x => x).Should().BeTrue();
            TryGetValueOutput.All(x => x == ExpectedValue).Should().BeTrue();
        }

        [Test]
        public void Assert_command_line_arguments_contains_requested_name()
        {
            ObjectsUnderTest.All(x => x.Contains("testInt")).Should().BeTrue();
        }
    }

    internal class CommandLineArgumentsTests_argument_with_string_value : ArrangeActAssert
    {
        protected CommandLineArguments[] ObjectsUnderTest;
        protected string[] Arguments;

        protected string ExpectedValue;

        protected string[] GetValueResult;
        protected bool[] TryGetValueCall;
        protected string[] TryGetValueOutput;

        public override void Arrange()
        {
            Arguments = new[]
                        {
                            "--testStr=\"abcd efgh\"",
                            "--testStr:\"abcd efgh\"",
                            "/testStr=\"abcd efgh\"",
                            "/testStr:\"abcd efgh\"",
                            "-testStr=\"abcd efgh\"",
                            "-testStr:\"abcd efgh\"",
                        };
            ExpectedValue = "\"abcd efgh\"";

            GetValueResult = new string[Arguments.Length];
            TryGetValueCall = new bool[Arguments.Length];
            TryGetValueOutput = new string[Arguments.Length];

            ObjectsUnderTest = new CommandLineArguments[Arguments.Length];
            foreach (string argument in Arguments)
            {
                ObjectsUnderTest[Array.IndexOf(Arguments, argument)] = new CommandLineArguments(argument);
            }
        }

        public override void Act()
        {
            for (int index = 0; index < Arguments.Length; ++index)
            {
                GetValueResult[index] = ObjectsUnderTest[index].Get<string>("testStr");
                TryGetValueCall[index] = ObjectsUnderTest[index].TryGet("testStr", out TryGetValueOutput[index]);
            }
        }

        [Test]
        public void Assert_getting_string_value_has_succeeded()
        {
            GetValueResult.All(x => x.Equals(ExpectedValue)).Should().BeTrue();
        }

        [Test]
        public void Assert_argument_has_only_one_entry()
        {
            ObjectsUnderTest.All(x => x.Count() == 1).Should().BeTrue();
        }

        [Test]
        public void Assert_trying_to_get_string_value_has_succeeded()
        {
            TryGetValueCall.All(x => x).Should().BeTrue();
            TryGetValueOutput.All(x => x.Equals(ExpectedValue)).Should().BeTrue();
        }

        [Test]
        public void Assert_command_line_arguments_contains_requested_name()
        {
            ObjectsUnderTest.All(x => x.Contains("testStr")).Should().BeTrue();
        }
    }

    internal class CommandLineArgumentsTests_argument_with_filename_value : ArrangeActAssert
    {
        protected CommandLineArguments[] ObjectsUnderTest;
        protected string[] Arguments;

        protected string ExpectedValue;

        protected string[] GetValueResult;
        protected bool[] TryGetValueCall;
        protected string[] TryGetValueOutput;

        public override void Arrange()
        {
            Arguments = new[]
                        {
                            "--testFile=\"C:\\path\\to\\file\\file.txt\"",
                            "--testFile:\"C:\\path\\to\\file\\file.txt\"",
                            "/testFile=\"C:\\path\\to\\file\\file.txt\"",
                            "/testFile:\"C:\\path\\to\\file\\file.txt\"",
                            "-testFile=\"C:\\path\\to\\file\\file.txt\"",
                            "-testFile:\"C:\\path\\to\\file\\file.txt\"",
                        };
            ExpectedValue = "\"C:\\path\\to\\file\\file.txt\"";

            GetValueResult = new string[Arguments.Length];
            TryGetValueCall = new bool[Arguments.Length];
            TryGetValueOutput = new string[Arguments.Length];

            ObjectsUnderTest = new CommandLineArguments[Arguments.Length];
            foreach (string argument in Arguments)
            {
                ObjectsUnderTest[Array.IndexOf(Arguments, argument)] = new CommandLineArguments(argument);
            }
        }

        public override void Act()
        {
            for (int index = 0; index < Arguments.Length; ++index)
            {
                GetValueResult[index] = ObjectsUnderTest[index].Get<string>("testFile");
                TryGetValueCall[index] = ObjectsUnderTest[index].TryGet("testFile", out TryGetValueOutput[index]);
            }
        }

        [Test]
        public void Assert_getting_string_value_has_succeeded()
        {
            GetValueResult.All(x => x.Equals(ExpectedValue)).Should().BeTrue();
        }

        [Test]
        public void Assert_argument_has_only_one_entry()
        {
            ObjectsUnderTest.All(x => x.Count() == 1).Should().BeTrue();
        }

        [Test]
        public void Assert_trying_to_get_string_value_has_succeeded()
        {
            TryGetValueCall.All(x => x).Should().BeTrue();
            TryGetValueOutput.All(x => x.Equals(ExpectedValue)).Should().BeTrue();
        }

        [Test]
        public void Assert_command_line_arguments_contains_requested_name()
        {
            ObjectsUnderTest.All(x => x.Contains("testFile")).Should().BeTrue();
        }
    }

    internal class CommandLineArgumentsTests_argument_does_not_exists : ArrangeActAssert
    {
        protected CommandLineArguments ObjectUnderTest;
        protected string[] Arguments;

        protected string ExpectedValue;
        protected bool TryGetValueCall;
        protected string TryGetValueOutput;

        public override void Arrange()
        {
            Arguments = new string[] { };
            ExpectedValue = default(string);
        }

        public override void Act()
        {
            ObjectUnderTest = new CommandLineArguments(Arguments);
            TryGetValueCall = ObjectUnderTest.TryGet("doesNotExists", out TryGetValueOutput);
        }

        [Test]
        public void Assert_argument_does_not_exists()
        {
            TryGetValueCall.Should().BeFalse();
            TryGetValueOutput.Should().Be(ExpectedValue);
        }

        [Test]
        public void Assert_command_line_arguments_has_no_entries()
        {
            ObjectUnderTest.Count().Should().Be(0);
        }

        [Test]
        public void Assert_command_line_arguments_does_not_contains_requesting_name()
        {
            ObjectUnderTest.Contains("doesNotExists").Should().BeFalse();
        }
    }

    internal class CommandLineArgumentsTests_setting_arguments : ArrangeActAssert
    {
        protected CommandLineArguments ObjectUnderTest;
        protected object[] InputArguments;

        public override void Arrange()
        {
            InputArguments = new object[] {100, true, "test"};
            ObjectUnderTest = new CommandLineArguments();
        }

        public override void Act()
        {
            ObjectUnderTest.Set("a", (int) InputArguments[0]);
            ObjectUnderTest.Set("b", (bool) InputArguments[1]);
            ObjectUnderTest.Set("c", (string) InputArguments[2]);
        }

        [Test]
        public void Assert_arguments_count()
        {
            ObjectUnderTest.Count().Should().Be(InputArguments.Length);
        }

        [Test]
        public void Assert_argument1_is_integer()
        {
            ObjectUnderTest.Get<int>("a").Should().Be((int) InputArguments[0]);
        }

        [Test]
        public void Assert_argument2_is_boolean()
        {
            ObjectUnderTest.Get<bool>("b").Should().Be((bool) InputArguments[1]);
        }

        [Test]
        public void Assert_argument3_is_string()
        {
            ObjectUnderTest.Get<string>("c").Should().Be((string) InputArguments[2]);
        }
    }
}
