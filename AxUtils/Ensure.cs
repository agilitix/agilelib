using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AxUtils
{
    public static class Ensure
    {
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public static void That<TException>(bool condition, string message = "Condition failed.") where TException : Exception
        {
            if (!condition)
            {
                throw (TException) Activator.CreateInstance(typeof(TException), message);
            }
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public static void That(bool condition, string message = "Condition failed.")
        {
            That<ArgumentException>(condition, message);
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public static void NotNull<T>(T value, string argName) where T : class
        {
            if (string.IsNullOrWhiteSpace(argName))
            {
                argName = nameof(value);
            }

            That<ArgumentNullException>(value != null, argName);
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public static void NotNullOrEmpty<T>(IEnumerable<T> collection, string argName)
        {
            if (string.IsNullOrWhiteSpace(argName))
            {
                argName = nameof(collection);
            }

            That<ArgumentException>(collection != null && collection.Any(), argName);
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public static void FileExists(string file)
        {
            That<FileNotFoundException>(File.Exists(file), "File not found.");
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public static void DirectoryExists(string directory)
        {
            That<DirectoryNotFoundException>(Directory.Exists(directory), "Directory not found.");
        }
    }
}
