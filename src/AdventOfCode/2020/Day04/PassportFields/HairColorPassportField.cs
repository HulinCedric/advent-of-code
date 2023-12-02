using System.Text.RegularExpressions;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class HairColorPassportField
        : PassportField
    {
        private const string CharactersFrom0To9 = "[0-9]";
        private const string CharactersFromaTof = "[a-f]";
        private const int Exactly6 = 6;
        private const string StartWithSharp = "#";

        internal HairColorPassportField(string value)
            : base(value)
        {
        }

        private static string ValidRegexPattern
            => $"{StartWithSharp}({CharactersFrom0To9}|{CharactersFromaTof}){{{Exactly6}}}";

        public override bool IsValid()
            => Regex.IsMatch(value, ValidRegexPattern);
    }
}