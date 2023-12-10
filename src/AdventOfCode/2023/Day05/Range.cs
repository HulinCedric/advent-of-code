namespace AdventOfCode._2023.Day05;

public readonly struct Range
{
    public Range(long start) : this(start, start)
    {
    }

    public Range(long start, long end)
    {
        Start = start;
        End = end;
    }

    public long End { get; }

    public long Start { get; }

    public static implicit operator Range(long value)
        => new(value);

    public bool Includes(Range other)
        => Start <= other.Start && End >= other.End;

    public bool OverlapsWith(Range other)
        => Start <= other.End && End >= other.Start;

    public Range GetLeftComplement(Range other)
        => new(other.Start, Start - 1);

    public Range GetExtendedTo(Range other)
        => new(Start, other.End);

    public Range GetOverlapWith(Range other)
        => new(other.Start, End);

    public Range GetRightComplement(Range other)
        => new(End + 1, other.End);
}