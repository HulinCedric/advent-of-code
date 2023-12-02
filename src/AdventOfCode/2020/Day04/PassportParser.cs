using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2020.Day04.PassportFields;

namespace AdventOfCode._2020.Day04
{
    public static class PassportParser
    {
        private const string BlankLineDescription = "\n\n";

        public static IEnumerable<string> ParseBatchFile(string batchFileDescription)
        => batchFileDescription
        .Split(BlankLineDescription)
        .Select(passportDescription => passportDescription.Trim());

        public static IEnumerable<string> ParsePassportDescription(string passportDescription)
        => passportDescription
        .Split(new[] { " ", "\n" }, StringSplitOptions.RemoveEmptyEntries)
        .Select(passportFieldDescription => passportFieldDescription);

        public static PassportFieldInformation ParsePassportFieldDescription(
            string passportFieldDescription)
            => new(
                passportFieldDescription.Split(":").First(),
                passportFieldDescription.Split(":").Last());
    }
}