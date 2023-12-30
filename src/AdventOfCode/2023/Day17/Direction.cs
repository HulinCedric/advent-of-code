namespace AdventOfCode._2023.Day17;

public readonly record struct Direction(int X, int Y)
{
    public static readonly Direction Right = new(0, 1);
    public static readonly Direction Left = new(0, -1);
    public static readonly Direction Down = new(1, 0);
    public static readonly Direction Up = new(-1, 0);

    public static Direction operator *(Direction a, Direction b)
        => new(a.Y * b.X + a.X * b.Y, a.Y * b.Y - a.X * b.X);

    public Direction Rotate90ClockWise()
        => this * Down;

    public Direction Rotate90CounterClockWise()
        => this * Up;
}