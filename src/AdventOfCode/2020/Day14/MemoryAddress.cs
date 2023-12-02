using System;

namespace AdventOfCode._2020.Day14
{
    public record MemoryAddress
    {
        public MemoryAddress(long position)
            => Position = position;

        public MemoryAddress(string representation)
            => Position = Convert.ToInt64(representation, 2);

        public long Position { get; }

        public override string ToString()
            => Convert.ToString(Position, 2)
                .PadLeft(36, '0');
    }
}