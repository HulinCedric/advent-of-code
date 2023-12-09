using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day05;

public class AlmanacTest
{
    [Fact]
    public void Should_Get_Lowest_Location()
    {
        var seeds = new List<long> { 79, 14, 55, 13 };
        var maps = new List<Map>
        {
            new(
                "seed",
                "soil",
                [
                    new SeedConverter(50, 98, 2),
                    new SeedConverter(52, 50, 48)
                ]),
            new(
                "soil",
                "fertilizer",
                [
                    new SeedConverter(0, 15, 37),
                    new SeedConverter(37, 52, 2),
                    new SeedConverter(39, 0, 15)
                ]),
            new(
                "fertilizer",
                "water",
                [
                    new SeedConverter(49, 53, 8),
                    new SeedConverter(0, 11, 42),
                    new SeedConverter(42, 0, 7),
                    new SeedConverter(57, 7, 4)
                ]),
            new(
                "water",
                "light",
                [
                    new SeedConverter(88, 18, 7),
                    new SeedConverter(18, 25, 70)
                ]),
            new(
                "light",
                "temperature",
                [
                    new SeedConverter(45, 77, 23),
                    new SeedConverter(81, 45, 19),
                    new SeedConverter(68, 64, 13)
                ]),
            new(
                "temperature",
                "humidity",
                [
                    new SeedConverter(0, 69, 1),
                    new SeedConverter(1, 0, 69)
                ]),
            new(
                "humidity",
                "location",
                [
                    new SeedConverter(60, 56, 37),
                    new SeedConverter(56, 93, 4)
                ])
        };

        var gardener = new Almanac(seeds, maps);

        var lowestLocation = gardener.GetLowestLocation();

        lowestLocation.Should().Be(35);
    }
}

public class Almanac
{
    private readonly Dictionary<string, Map> maps;
    private readonly List<long> seeds;

    public Almanac(List<long> seeds, List<Map> maps)
    {
        this.seeds = seeds;
        this.maps = maps.ToDictionary(map => map.DestinationCategory, map => map);
    }

    public long GetLowestLocation()
        => seeds.Select(GetTransformedSeed).Min();

    private long GetTransformedSeed(long seed)
        => maps.Keys.Aggregate(seed, (current, category) => maps[category].GetDestinationForSource(current));
}