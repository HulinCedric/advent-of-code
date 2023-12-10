using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day05;

public static class AlmanacParser
{
    public static Almanac Parse(string almanacInformation)
    {
        var almanacParts = almanacInformation.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        return new Almanac(ParseSeeds(almanacParts[0]), ParseMaps(almanacParts.Skip(1)));
    }

    private static List<Range> ParseSeeds(string almanacSeedPart)
        => almanacSeedPart
            .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(Range.Parse)
            .ToList();

    private static List<Map> ParseMaps(IEnumerable<string> mapsParts)
    {
        var maps = new List<Map>();
        foreach (var mapPart in mapsParts)
        {
            var lines = mapPart.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            var categories = lines[0].Split("-to-");
            var sourceCategory = categories[0];
            var destinationCategory = categories[1].Replace(" map:", "");

            maps.Add(new Map(sourceCategory, destinationCategory, ParseSeedConverters(lines.Skip(1))));
        }

        return maps;
    }

    private static List<SeedConverter> ParseSeedConverters(IEnumerable<string> lines)
        => lines.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray())
            .Select(values => new SeedConverter(values[0], values[1], values[2]))
            .ToList();

    public static Almanac Parse_Two(string almanacInformation)
    {
        var almanacParts = almanacInformation.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        return new Almanac(ParseSeeds_Two(almanacParts[0]), ParseMaps(almanacParts.Skip(1)));
    }

    private static List<Range> ParseSeeds_Two(string almanacSeedPart)
    {
        var seedParts = almanacSeedPart
            .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .ToList();

        var seeds = new List<Range>();
        for (var i = 0; i < seedParts.Count; i += 2)
        {
            var start = seedParts[i];
            var length = seedParts[i + 1];
            // seeds.Add(new Range(start, start+length));
            seeds.AddRange(Enumerable.Range(start, length).Select(v => new Range(v)));
        }

        return seeds;
    }
}