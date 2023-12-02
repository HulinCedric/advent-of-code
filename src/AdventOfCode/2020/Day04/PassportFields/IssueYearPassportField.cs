using System.Linq;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class IssueYearPassportField
        : PassportField
    {
        private const int AtLeast = 2010;
        private const int AtMost = 2020;

        internal IssueYearPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            =>
            value.All(char.IsDigit) &&
            int.Parse(value) >= AtLeast &&
            int.Parse(value) <= AtMost;
    }
}