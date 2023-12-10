using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day05;

public static class AlmanacParser
{
    public static Almanac Parse(string almanacInformation)
    {
        var almanacParts = AlmanacParts(almanacInformation);

        return AlmanacWith(almanacParts, ParseSeeds(almanacParts[0]));
    }

    public static Almanac ParseWithRange(string almanacInformation)
    {
        var almanacParts = AlmanacParts(almanacInformation);

        return AlmanacWith(almanacParts, ParseSeedsWithRange(almanacParts[0]));
    }

    private static string[] AlmanacParts(string almanacInformation)
        => almanacInformation.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

    private static Almanac AlmanacWith(string[] almanacParts, List<Range> seeds)
        => new(seeds, ParseMaps(almanacParts.Skip(1)));

    private static List<Range> ParseSeeds(string almanacSeedPart)
        => almanacSeedPart
            .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(seed => new Range(long.Parse(seed)))
            .ToList();

    private static List<Range> ParseSeedsWithRange(string almanacSeedPart)
        => almanacSeedPart
            .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(long.Parse)
            .Chunk(2)
            .Select(pair => (start: pair[0], length: pair[1]))
            .Select(pair => new Range(pair.start, pair.start + pair.length - 1))
            .ToList();

    private static List<Map> ParseMaps(IEnumerable<string> mapsParts)
        => (from mapPart in mapsParts
            select mapPart.Split("\n", StringSplitOptions.RemoveEmptyEntries)
            into lines
            let categories = lines[0].Split("-to-")
            let sourceCategory = categories[0]
            let destinationCategory = categories[1].Replace(" map:", "")
            select new Map(sourceCategory, destinationCategory, ParseSeedConverters(lines.Skip(1)))).ToList();

    private static List<SeedConverter> ParseSeedConverters(IEnumerable<string> lines)
        => lines.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray())
            .Select(values => new SeedConverter(values[0], values[1], values[2]))
            .ToList();
}