using System;
using System.Linq;

namespace AdventOfCode._2020.Day20
{
    public static class TilesParser
    {
        public static Tile[] ParseAll(string tilesDescription)
            => tilesDescription
                .Split("\n\n")
                .Select(ParseOne)
                .ToArray();

        public static Tile ParseOne(string tileDescription)
            => new(
                ExtractId(tileDescription),
                ExtractContent(tileDescription));

        private static string ExtractContent(string tileDescription)
            => tileDescription[tileDescription.IndexOf("\n", StringComparison.Ordinal)..];

        private static int ExtractId(string tileDescription)
            => int.Parse(tileDescription[5..tileDescription.IndexOf(":", StringComparison.Ordinal)]);
    }
}