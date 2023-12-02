using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day03
{
    public class Map
    {
        public Map(string description)
            => Lines = Parse(description);

        internal IEnumerable<MapLine> Lines { get; }

        private static IEnumerable<MapLine> Parse(string mapDescription)
            => mapDescription
                .Split("\n")
                .Select(lineDescription => new MapLine(lineDescription));

        public bool GetTreePresenceAt(int lineNumber, int position)
            => Lines
                .ElementAt(lineNumber - 1)
                .GetTreePresenceAtPosition(position);
    }
}