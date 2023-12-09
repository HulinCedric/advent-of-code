using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day05;

public class SeedConverterTest
{
    [Theory]
    [InlineData(98, 50)]
    [InlineData(99, 51)]
    public void Should_map_source_to_destination(int source, int expectedDestination)
    {
        var converter = new SeedConverter(50, 98, 2);

        var destination = converter.GetDestination(source);

        destination.Should().Be(expectedDestination);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(48, 48)]
    public void Should_Return_Same_Number_When_Source_Not_In_Range(int source, int expectedDestination)
    {
        var converter = new SeedConverter(50, 98, 2);

        var destination = converter.GetDestination(source);

        destination.Should().Be(expectedDestination);
    }
}

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