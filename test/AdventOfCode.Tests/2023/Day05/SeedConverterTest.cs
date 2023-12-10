using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day05;

public class SeedConverterTest
{
    private readonly SeedConverter converter = new(50, 98, 2);

    [Theory]
    [InlineData(98, 50)]
    [InlineData(99, 51)]
    public void Should_map_source_to_destination(int source, int expectedDestination)
    {
        var destination = converter.GetDestination(source);

        destination.Should().Be(new Range(expectedDestination));
    }

    [Theory]
    [InlineData(98, 99, 50, 51)]
    public void Should_map_source_range_to_destination_range(
        int sourceRangeStart,
        int sourceRangeEnd,
        int destinationRangeStart,
        int destinationRangeEnd)
    {
        var destination = converter.GetDestination(new Range(sourceRangeStart, sourceRangeEnd));

        destination.Should().Be(new Range(destinationRangeStart, destinationRangeEnd));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(48, 48)]
    [InlineData(100, 100)]
    public void Should_Return_Same_Number_When_Source_Not_In_Range(int source, int expectedDestination)
    {
        var destination = converter.GetDestination(source);

        destination.Should().Be(new Range(expectedDestination));
    }

    [Theory]
    [InlineData(98, 196, 98L, 196L)]
    public void Should_return_same_range_when_range_is_not_a_subset(
        int sourceRangeStart,
        int sourceRangeEnd,
        int destinationRangeStart,
        int destinationRangeEnd)
    {
        var destination = converter.GetDestination(new Range(sourceRangeStart, sourceRangeEnd));

        destination.Should().Be(new Range(destinationRangeStart, destinationRangeEnd));
    }
}