using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day05;

public class MapConverterTests
{
    /// The first line has a destination range start of 50, a source range start of 98, and a range length of 2. This line means that the source range starts at 98 and contains two values: 98 and 99. The destination range is the same length, but it starts at 50, so its two values are 50 and 51. With this information, you know that seed number 98 corresponds to soil number 50 and that seed number 99 corresponds to soil number 51.
    [Theory]
    [InlineData(98, 50)]
    [InlineData(99, 51)]
    public void Should_map_source_to_correct_number(int source, int expectedDestination)
    {
        var destinationRangeStart = 50;
        var sourceRangeStart = 98;
        var rangeLength = 2;

        var converter = new MapConverter(destinationRangeStart, sourceRangeStart, rangeLength);
        var destination = converter.GetDestinationForSource(source);

        destination.Should().Be(expectedDestination);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(48, 48)]
    public void Should_Return_Same_Number_When_Source_Not_In_Range(int source, int expectedDestination)
    {
        var destinationRangeStart = 50;
        var sourceRangeStart = 98;
        var rangeLength = 2;

        var converter = new MapConverter(destinationRangeStart, sourceRangeStart, rangeLength);
        var destination = converter.GetDestinationForSource(source);

        destination.Should().Be(expectedDestination);
    }
}

public class MapConverter
{
    private readonly int destinationRangeStart;
    private readonly int rangeLength;
    private readonly int sourceRangeStart;

    public MapConverter(int destinationRangeStart, int sourceRangeStart, int rangeLength)
    {
        this.destinationRangeStart = destinationRangeStart;
        this.sourceRangeStart = sourceRangeStart;
        this.rangeLength = rangeLength;
    }

    public int GetDestinationForSource(int source)
    {
        if (source < sourceRangeStart ||
            source > sourceRangeStart + rangeLength)
            return source;

        return destinationRangeStart + (source - sourceRangeStart);
    }
}