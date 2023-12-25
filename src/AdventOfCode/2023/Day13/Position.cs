namespace AdventOfCode._2023.Day13;

public readonly record struct Position(double Row, double Column)
{
       public static Position operator +(Position left, Direction right)
        => new(left.Row + right.X, left.Column + right.Y);

    public override string ToString()
        => $"<{Row}; {Column}>";
}