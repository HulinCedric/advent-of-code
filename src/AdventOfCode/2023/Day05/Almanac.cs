using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day05;

public class Almanac
{
    private readonly Dictionary<string, Map> maps;
    private readonly List<Range> seeds;

    public Almanac(List<Range> seeds, List<Map> maps)
    {
        this.seeds = seeds;
        this.maps = maps.ToDictionary(map => map.DestinationCategory, map => map);
    }

    public long GetLowestLocation()
        => seeds.Select(r => r).Select(GetTransformedSeed).Select(r => r.Start).Min();

    private Range GetTransformedSeed(Range seed)
        => maps.Keys.Aggregate(seed, (current, category) => maps[category].GetDestinationForSource(current));
}