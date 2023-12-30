namespace AdventOfCode._2023.Day18;

public readonly record struct Direction(long X, long Y)
{
    public static readonly Direction Right = new(0, 1);
    public static readonly Direction Left = new(0, -1);
    public static readonly Direction Down = new(1, 0);
    public static readonly Direction Up = new(-1, 0);

    public static Direction operator *(Direction a, long b)
        => new(a.X * b, a.Y * b);
}