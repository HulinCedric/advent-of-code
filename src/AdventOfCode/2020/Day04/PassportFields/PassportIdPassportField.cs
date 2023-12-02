using System.Linq;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class PassportIdPassportField
        : PassportField
    {
        internal PassportIdPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => value.Length == 9 &&
            value.All(char.IsDigit);
    }
}