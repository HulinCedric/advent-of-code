using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day10;

public static class GroundParser
{
    public static Dictionary<(int, int), char> ParseGround(this string ground)
    {
        var lines = ground.Split("\n");
        return (
                   from x in Enumerable.Range(0, lines.Length)
                   from y in Enumerable.Range(0, lines[0].Length)
                   let position = (x, y)
                   let tile = lines[x][y]
                   select new KeyValuePair<(int, int), char>(position, tile)
               ).ToDictionary();
    }
}