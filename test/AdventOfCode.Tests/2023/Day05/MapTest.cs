using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day05;

public class MapTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(48, 48)]
    [InlineData(49, 49)]
    [InlineData(50, 52)]
    [InlineData(51, 53)]
    [InlineData(96, 98)]
    [InlineData(97, 99)]
    [InlineData(98, 50)]
    [InlineData(99, 51)]
    [InlineData(100, 100)]
    public void Should_map_source_to_destination_across_ranges(int source, int expectedDestination)
    {
        var map = new Map(
            "seed",
            "soil",
            [
                new SeedConverter(50, 98, 2),
                new SeedConverter(52, 50, 48)
            ]);

        var destination = map.GetDestinationForSource(source);

        destination.Should().Be(expectedDestination);
    }

    [Theory]
    [InlineData(79, 81)]
    [InlineData(14, 14)]
    [InlineData(55, 57)]
    [InlineData(13, 13)]
    public void Should_map_seed_to_soil(int source, int expectedDestination)
    {
        var map = new Map(
            "seed",
            "soil",
            [
                new SeedConverter(50, 98, 2),
                new SeedConverter(52, 50, 48)
            ]);

        var destination = map.GetDestinationForSource(source);

        destination.Should().Be(expectedDestination);
    }
}