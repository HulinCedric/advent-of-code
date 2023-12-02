using System.Linq;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class ExpirationYearPassportField
        : PassportField
    {
        private const int AtLeast = 2020;
        private const int AtMost = 2030;

        internal ExpirationYearPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            =>
            value.All(char.IsDigit) &&
            int.Parse(value) >= AtLeast &&
            int.Parse(value) <= AtMost;
    }
}