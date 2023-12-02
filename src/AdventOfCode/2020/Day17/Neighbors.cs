using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day17
{
    public class Neighbors
    {
        private readonly Dictionary<int, int[][]> cachedDimensions = new();
        private readonly Dictionary<string, string[]> cachedNeighbors = new();

        public IEnumerable<string> GetNeighbors(string coordinate)
        {
            if (!cachedNeighbors.ContainsKey(coordinate))
                cachedNeighbors[coordinate] = DimensionalNeighbors(
                        coordinate.Split(',')
                            .Select(int.Parse))
                    .Select(t => string.Join(',', t))
                    .ToArray();

            return cachedNeighbors[coordinate];
        }

        private static IEnumerable<IEnumerable<int>> DimensionalNeighborsGenerator(int dimensions)
        {
            if (dimensions == 1)
                foreach (var n in Enumerable.Range(-1, 3))
                    yield return new[] { n };
            else
                foreach (var b in DimensionalNeighborsGenerator(dimensions - 1))
                foreach (var a in Enumerable.Range(-1, 3))
                    yield return b.Append(a);
        }

        private IEnumerable<IEnumerable<int>> DimensionalNeighbors(int dimensions)
        {
            if (!cachedDimensions.ContainsKey(dimensions))
                cachedDimensions[dimensions] =
                    DimensionalNeighborsGenerator(dimensions)
                        .Where(x => x.Any(n => n != 0))
                        .Select(t => t.ToArray())
                        .ToArray();

            return cachedDimensions[dimensions];
        }

        private IEnumerable<IEnumerable<int>> DimensionalNeighbors(IEnumerable<int> pos)
        {
            var positions = pos as int[] ?? pos.ToArray();
            return DimensionalNeighbors(positions.Length)
                .Select(
                    x => x.Zip(positions)
                        .Select(t => t.First + t.Second));
        }
    }
}