namespace AdventOfCode._2023.Day13;

public readonly record struct Position(double Row, double Column)
{

    public override string ToString()
        => $"<{Row}; {Column}>";
}