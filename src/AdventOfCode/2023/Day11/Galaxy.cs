using System;

namespace AdventOfCode._2023.Day11;

public class Galaxy(long x, long y)
{
    private const int Representation = '#';

    public long X { get; set; } = x;
    public long Y { get; set; } = y;

    public long Distance(Galaxy second)
        => Math.Abs(X - second.X) + Math.Abs(Y - second.Y);

    public static bool IsGalaxy(char representation)
        => representation == Representation;
}