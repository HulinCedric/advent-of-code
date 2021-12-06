using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace AdventOfCode
{
    public class InputFileDataAttribute : DataAttribute
    {
        private readonly string filePath;
        private readonly object[] theoryData;

        /// <summary>
        ///     Load data from a input file as the data source for a theory.
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the input file to load.</param>
        /// <param name="theoryData">The theory data.</param>
        public InputFileDataAttribute(
            string filePath,
            params object[] theoryData)
        {
            this.filePath = filePath;
            this.theoryData = theoryData;
        }

        /// <summary>
        ///     Gets the content of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The file content.</returns>
        /// <remarks>
        ///     All lines in file are separated by a LF (Line Feed) for normalization purpose.
        /// </remarks>
        private static string GetFileContent(string filePath)
            => string.Join(
                "\n",
                File.ReadAllLines(filePath));

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                throw new ArgumentNullException(nameof(testMethod));

            // Get the absolute path to the input file
            var path = Path.IsPathRooted(filePath) ?
                filePath :
                Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

            if (!File.Exists(path))
                throw new ArgumentException($"Could not find file at path: {path}");

            var theoryDataWithFileContent = new List<object>
            {
                GetFileContent(filePath)
            };

            theoryDataWithFileContent.AddRange(theoryData);

            yield return theoryDataWithFileContent.ToArray();
        }
    }
}