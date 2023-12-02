using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day17
{
    public static class ConwayCubesParser
    {
        public static Dictionary<string, bool> ParseTo3Dimension(string conwayCubesDescription)
            => Parse(conwayCubesDescription, Get3DimensionCoordinate);

        public static Dictionary<string, bool> ParseTo4Dimension(string conwayCubesDescription)
            => Parse(conwayCubesDescription, Get4DimensionCoordinate);

        private static Dictionary<string, bool> Parse(
            string conwayCubesDescription,
            Func<int, int, int[]> coordinateFactory)
            => conwayCubesDescription
                .Split("\n")
                .SelectMany((l, y) => l.Select((c, x) => (string.Join(',', coordinateFactory(x, y)), b: c.Equals('#'))))
                .ToDictionary(t => t.Item1, t => t.b);

        private static int[] Get3DimensionCoordinate(int x, int y)
            => new[] { x, y, 0 };

        private static int[] Get4DimensionCoordinate(int x, int y)
            => new[] { x, y, 0, 0 };
    }
}