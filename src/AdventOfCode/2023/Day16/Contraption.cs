using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2023.Day16;

public static class Contraption
{
    // follow the beam in the map and return the energized cell count. 
    public static int EnergizedCells(Dictionary<Position, char> map, Beam startBeam)
    {
        // this is essentially just a flood fill algorithm.
        var q = new Queue<Beam>([startBeam]);
        var seen = new HashSet<Beam>();

        while (q.TryDequeue(out var beam))
        {
            seen.Add(beam);
            foreach (var dir in Tiles.Exits(map[beam.Position], beam.Direction))
            {
                var pos = beam.Position + dir;
                if (map.ContainsKey(pos) &&
                    !seen.Contains(new Beam(pos, dir)))
                {
                    q.Enqueue(new Beam(pos, dir));
                }
            }
        }

        return seen.Select(energizedTile => energizedTile.Position).Distinct().Count();
    }

    // using a dictionary helps with bounds check (simply containskey):
    public static Dictionary<Position, char> ParseContraption(string input)
    {
        var lines = input.Split('\n');
        return (
                   from irow in Enumerable.Range(0, lines.Length)
                   from icol in Enumerable.Range(0, lines[0].Length)
                   let tile = lines[irow][icol]
                   let position = new Position(icol, irow)
                   select new KeyValuePair<Position, char>(position, tile)
               ).ToDictionary();
    }

    // go around the edges (top, right, bottom, left order) of the map
    // and return the inward pointing directions
    private static IEnumerable<Beam> StartBeams(Dictionary<Position, char> map)
    {
        var br = map.Keys.MaxBy(pos => pos.Imaginary + pos.Real);
        return
        [
            ..from pos in map.Keys where pos.Real == 0 select new Beam(pos, Directions.Down),
            ..from pos in map.Keys where pos.Real == br.Real select new Beam(pos, Directions.Left),
            ..from pos in map.Keys where pos.Imaginary == br.Imaginary select new Beam(pos, Directions.Up),
            ..from pos in map.Keys where pos.Imaginary == 0 select new Beam(pos, Directions.Right)
        ];
    }
}