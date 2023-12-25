namespace AdventOfCode._2023.Day13;

public readonly record struct Direction(int X, int Y)
{
    public static readonly Direction Down = new(0, 1);
    public static readonly Direction Right = new(1, 0);

    public Direction Reverse()
        => new(-X, -Y);

    public Direction Orthogonal()
        => this == Down ? Right : Down;
}