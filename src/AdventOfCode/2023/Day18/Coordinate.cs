using System;

namespace AdventOfCode._2023.Day18;

public readonly record struct Coordinate(long X, long Y)
{
    public long Length
        => (long)Math.Sqrt(Y * Y + X * X);

    public static Coordinate operator -(Coordinate a, Coordinate b)
        => new(a.X - b.X, a.Y - b.Y);
}