using System.Linq;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class HeightInInchPassportField
        : HeightPassportField
    {
        private const int AtLeast = 59;
        private const int AtMost = 76;

        internal HeightInInchPassportField(string value)
            : base(value)
        {
        }

        public override bool IsValid()
        {
            if (!value.EndsWith("in"))
                return false;

            var numberPart = value[..^2];
            return numberPart.All(char.IsDigit) &&
                   int.Parse(numberPart) >= AtLeast &&
                   int.Parse(numberPart) <= AtMost;
        }
    }
}