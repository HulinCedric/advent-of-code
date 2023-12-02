using System;

namespace AdventOfCode._2020.Day14
{
    public record MemoryValue
    {
        private readonly string representation;
        private readonly long value;

        public MemoryValue(string representation)
        {
            this.representation = representation;
            value = Convert.ToInt64(representation, 2);
        }

        public MemoryValue(long value)
        {
            this.value = value;
            representation = Convert.ToString(value, 2)
                .PadLeft(36, '0');
        }

        public static MemoryValue operator +(MemoryValue first, MemoryValue second)
            => new(first.value + second.value);

        public override string ToString()
            => representation;
    }
}