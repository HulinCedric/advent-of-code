using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day05;

public class Map
{
    private readonly List<SeedConverter> mapConverters;

    public Map(string sourceCategory, string destinationCategory, List<SeedConverter> mapConverters)
    {
        SourceCategory = sourceCategory;
        DestinationCategory = destinationCategory;
        this.mapConverters = mapConverters;
    }

    public string DestinationCategory { get; }
    public string SourceCategory { get; }

    public List<Range> GetDestinations(Range source)
    {
        var seeds = new Queue<Range>(new[] { source });
        var destinations = new List<Range>();

        while (seeds.TryDequeue(out var seed))
        {
            var map = FindCorrespondingMap(seed);
            if (map is null)
            {
                destinations.Add(seed);
                continue;
            }

            var differences = map.DifferenceWith(seed);
            if (!differences.Any())
            {
                destinations.Add(map.GetDestination(seed));
                continue;
            }

            seeds.AddRange(differences);
        }

        return destinations;
    }

    private SeedConverter? FindCorrespondingMap(Range currentSource)
        => mapConverters
            .FirstOrDefault(m => m.DoesIntersect(currentSource));
}

public static class QueueExtensions
{
    public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> source)
    {
        foreach (var item in source)
        {
            queue.Enqueue(item);
        }
    }
}