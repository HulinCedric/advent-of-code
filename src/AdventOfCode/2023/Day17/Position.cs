namespace AdventOfCode._2023.Day17;

public readonly record struct Position(int X, int Y)
{
    public Position GoTo(Direction direction)
        => new(X + direction.X, Y + direction.Y);
}