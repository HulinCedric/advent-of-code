namespace AdventOfCode._2023.Day16;

public readonly record struct Direction
{
    public static readonly Direction Down = new(0, 1);
    public static readonly Direction Up = new(0, -1);
    public static readonly Direction Left = new(-1, 0);
    public static readonly Direction Right = new(1, 0);

    private Direction(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public int X { get; }
    public int Y { get; }

    public Direction Orthogonal()
        => new(Y, X);

    public Direction OppositeDirection()
        => new(-X, -Y);
}