using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    public record Measurement
    {
        private readonly IEnumerable<ushort> values;

        public Measurement(IEnumerable<ushort> values)
            => this.values = values;

        private int Sum
            => values.Sum(v => v);

        public static bool operator >(Measurement a, Measurement b)
            => a.Sum > b.Sum;

        public static bool operator <(Measurement a, Measurement b)
            => a.Sum < b.Sum;
    }
}