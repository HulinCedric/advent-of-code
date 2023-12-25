namespace AdventOfCode._2023.Day13;

public readonly record struct Direction(double X, double Y)
{
    public static readonly Direction Down = new(0.0, 1.0);
    public static readonly Direction Right = new(1.0, 0.0);

    public Direction Reverse()
        => new(-X, -Y);

    public Direction Orthogonal()
        => this == Down ? Right : Down;
}