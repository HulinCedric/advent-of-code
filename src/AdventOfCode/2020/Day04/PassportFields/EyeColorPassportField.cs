using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class EyeColorPassportField
        : PassportField
    {
        private static readonly IEnumerable<string> EyeColors = new List<string>
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        internal EyeColorPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => EyeColors.Any(eyeColor => eyeColor == value);
    }
}