using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day17
{
    public class ConwayCubes
    {
        private readonly Neighbors neighbors;

        public ConwayCubes()
            => neighbors = new Neighbors();

        public long Play6Cycles(Dictionary<string, bool> coordinates)
        {
            for (var i = 0; i < 6; i++)
            {
                foreach (var newCoordinate in GetNewCoordinates(coordinates))
                    coordinates[newCoordinate] = false;

                var cubeNextCycle = new Dictionary<string, bool>();

                foreach (var coordinate in coordinates.Keys)
                {
                    var activeNeighborsCount = neighbors.GetNeighbors(coordinate)
                        .Where(t => coordinates.ContainsKey(t))
                        .Select(t => coordinates[t])
                        .Count(v => v);

                    cubeNextCycle[coordinate] = coordinates[coordinate] switch
                    {
                        true when activeNeighborsCount is < 2 or > 3 => false,
                        false when activeNeighborsCount == 3 => true,
                        _ => coordinates[coordinate]
                    };
                }

                coordinates = cubeNextCycle;
            }

            return coordinates.Values.Count(v => v);
        }

        private IEnumerable<string> GetNewCoordinates(Dictionary<string, bool> coordinates)
            => coordinates.Keys
                .ToList()
                .SelectMany(
                    coordinate => neighbors.GetNeighbors(coordinate)
                        .Where(t => !coordinates.ContainsKey(t)));
    }
}