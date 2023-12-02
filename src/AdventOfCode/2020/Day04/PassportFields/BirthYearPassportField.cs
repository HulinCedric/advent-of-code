using System.Linq;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class BirthYearPassportField
        : PassportField
    {
        private const int AtLeast = 1920;
        private const int AtMost = 2002;

        internal BirthYearPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            =>
            value.All(char.IsDigit) &&
            int.Parse(value) >= AtLeast &&
            int.Parse(value) <= AtMost;
    }
}