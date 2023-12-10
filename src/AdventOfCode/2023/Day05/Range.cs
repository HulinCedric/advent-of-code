using System;

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

    public bool IsSubsetOf(Range other)
        => Start <= other.Start && End >= other.End;

    public bool DoesIntersect(Range other)
        => Start <= other.End && End >= other.Start;

    public Range ComplementBefore(Range other)
        => new(other.Start, Start - 1);

    public Range IntersectionToEnd(Range other)
        => new(Start, other.End);

    public Range IntersectionFromStart(Range other)
        => new(other.Start, End);

    public Range ComplementAfter(Range other)
        => new(End + 1, other.End);

    public bool StartsBefore(Range other)
        => other.Start < Start;

    public Range[] DifferenceWith(Range other)
    {
        if (IsSubsetOf(other))
            return Array.Empty<Range>();
        
        if (StartsBefore(other))
            return new[]
            {
                ComplementBefore(other),
                IntersectionToEnd(other)
            };

        
        return new[]
        {
            IntersectionFromStart(other),
            ComplementAfter(other)
        };
    }
    
    public override string ToString()
        => $"{Start} ; {End}";
}