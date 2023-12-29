using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2023.Day16.Tiles;

namespace AdventOfCode._2023.Day16;

public class Contraption
{
    private readonly Dictionary<Position, Tile> contraption;

    public Contraption(IEnumerable<KeyValuePair<Position, Tile>> keyValuePairs)
        => contraption = keyValuePairs.ToDictionary();

    public int EnergizedTilesCount(Beam startingBeam)
    {
        var queue = new Queue<Beam>([startingBeam]);
        var seen = new HashSet<Beam>();

        while (queue.TryDequeue(out var beam))
        {
            seen.Add(beam);

            var tile = contraption[beam.Position];
            foreach (var bouncedBeam in beam.Bounce(tile))
            {
                if (contraption.ContainsKey(bouncedBeam.Position) &&
                    !seen.Contains(bouncedBeam))
                {
                    queue.Enqueue(bouncedBeam);
                }
            }
        }

        return seen.Select(beam => beam.Position).Distinct().Count();
    }

    public Dictionary<Position, Tile>.KeyCollection Positions()
        => contraption.Keys;

    public Position TopLeft()
        => new(contraption.Keys.Min(pos => pos.Row), contraption.Keys.Min(pos => pos.Column));

    public Position BottomRight()
        => new(contraption.Keys.Max(pos => pos.Row), contraption.Keys.Max(pos => pos.Column));
}