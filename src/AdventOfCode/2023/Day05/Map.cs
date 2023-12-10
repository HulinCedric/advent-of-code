using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day05;

public class Map
{
    public string DestinationCategory { get; }
    private readonly List<SeedConverter> mapConverters;
    public string SourceCategory { get; }

    public Map(string sourceCategory, string destinationCategory, List<SeedConverter> mapConverters)
    {
        this.SourceCategory = sourceCategory;
        this.DestinationCategory = destinationCategory;
        this.mapConverters = mapConverters;
    }

    public long GetDestinationForSource(long source)
    {
        var converter = mapConverters.FirstOrDefault(map => map.IsInRange(source));

        if (converter == null)
            return source;

        return converter.GetDestination(new Range(source)).Start;
    }
}