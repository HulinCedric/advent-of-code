using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode._2023.Day10;

public static class GroundParser
{
    public static Dictionary<Complex, char> ParseGround(this string ground)
    {
        var lines = ground.Split('\n');
        return (
                   from x in Enumerable.Range(0, lines.Length)
                   from y in Enumerable.Range(0, lines[0].Length)
                   let position = new Complex(y, x)
                   let tile = lines[x][y]
                   select new KeyValuePair<Complex, char>(position, tile)
               ).ToDictionary();
    }
}