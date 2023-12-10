namespace AdventOfCode._2023.Day05;

public class SeedConverter
{
    private readonly Range destinationRange;
    private readonly Range sourceRange;

    public SeedConverter(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        destinationRange = new Range(destinationRangeStart, destinationRangeStart + rangeLength);
        sourceRange = new Range(sourceRangeStart, sourceRangeStart + rangeLength);
    }

    public Range GetDestination(Range source)
    {
        if (IsInRange(source) == false)
            return source;

        var offset = destinationRange.Start - sourceRange.Start;
        return new Range(source.Start + offset, source.End + offset);
    }

    public bool IsInRange(Range source)
        => source.Start <= sourceRange.End &&
           sourceRange.Start <= source.End;
}