using System.Linq;

namespace AdventOfCode._2020.Day03
{
    public class MapLine
    {
        private const char TreeDescription = '#';
        private readonly string description;

        public MapLine(string description)
            => this.description = description;

        public bool GetTreePresenceAtPosition(int position)
            => description.ElementAt(GetIndexForPosition(position)) == TreeDescription;

        private int GetIndexForPosition(int position)
            => GetIndexWithPatternRepeats(position - 1);

        private int GetIndexWithPatternRepeats(int index)
            => index % description.Length;
    }
}