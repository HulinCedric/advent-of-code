namespace AdventOfCode._2023.Day05;

public struct Range
{
    public Range(long start) : this(start, start)
    {
    }

    public Range(long start, long end)
    {
        Start = start;
        End = end;
    }

    public long End { get; set; }

    public long Start { get; set; }

    public static implicit operator Range(long value)
        => new(value);

    public static Range Parse(string arg)
        => new(long.Parse(arg));
}