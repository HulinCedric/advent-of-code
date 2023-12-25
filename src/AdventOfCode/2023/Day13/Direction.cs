namespace AdventOfCode._2023.Day13;

public readonly record struct Direction(double X, double Y)
{
    public static readonly Direction Right = new(0.0, 1.0);

}