namespace AdventOfCode._2023.Day18;

public readonly record struct DigStep(long X, long Y)
{
    public static Coordinate operator +(Coordinate a, DigStep b)
        => new(a.X + b.X, a.Y + b.Y);
}