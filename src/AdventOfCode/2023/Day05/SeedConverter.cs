namespace AdventOfCode._2023.Day05;

public class SeedConverter
{
    private readonly Range destinationRange;
    private readonly Range sourceRange;

    public SeedConverter(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        destinationRange = new Range(destinationRangeStart, destinationRangeStart + rangeLength - 1);
        sourceRange = new Range(sourceRangeStart, sourceRangeStart + rangeLength - 1);
    }

    public bool DoesIntersect(Range seed)
        => sourceRange.DoesIntersect(seed);

    public Range GetDestination(Range seed)
        => IsSubsetOf(seed) ?
               Map(seed) :
               seed;

    private bool IsSubsetOf(Range seed)
        => sourceRange.IsSubsetOf(seed);

    private Range Map(Range seed)
    {
        var offset = destinationRange.Start - sourceRange.Start;
        return new Range(seed.Start + offset, seed.End + offset);
    }

    public Range[] DifferenceWith(Range seed)
        => sourceRange.DifferenceWith(seed);
}