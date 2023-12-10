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
        => seeds
            .SelectMany(SeedLocations)
            .Select(r => r.Start)
            .Min();

    private List<Range> SeedLocations(Range seed)
        => maps.Values
            .Aggregate(
                (IEnumerable<Range>)new List<Range> { seed },
                (locations, map) => locations.SelectMany(map.GetDestinations))
            .ToList();
}