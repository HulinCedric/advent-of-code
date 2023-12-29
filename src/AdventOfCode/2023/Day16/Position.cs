namespace AdventOfCode._2023.Day16;

public readonly record struct Position(int Row, int Column)
{
    public Position GoTo(Direction direction)
        => new(Row + direction.Y, Column + direction.X);
}