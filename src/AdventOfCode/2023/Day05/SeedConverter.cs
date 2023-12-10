namespace AdventOfCode._2023.Day05;

public class SeedConverter
{
    private readonly long destinationRangeStart;
    private readonly long rangeLength;
    private readonly long sourceRangeStart;

    public SeedConverter(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        this.destinationRangeStart = destinationRangeStart;
        this.sourceRangeStart = sourceRangeStart;
        this.rangeLength = rangeLength;
    }
   
    public bool IsInRange(Range source)
        => source.Start <= sourceRangeStart + rangeLength &&
           sourceRangeStart <= source.End;
    
    public long GetDestination(long source)
    {
        if (IsInRange(source) == false)
            return source;

        return destinationRangeStart + (source - sourceRangeStart);
    }

    public bool IsInRange(long source)
        => source >= sourceRangeStart &&
           source < sourceRangeStart + rangeLength;
}

