using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2023.Day16.Tiles;
using static AdventOfCode._2023.Day16.Tiles.TileFactory;

namespace AdventOfCode._2023.Day16;

public static class ContraptionParser
{
    public static Contraption Parse(string input)
    {
        var lines = input.Split('\n');
        return
            new Contraption(
                from rowIndex in Enumerable.Range(0, lines.Length)
                from columnIndex in Enumerable.Range(0, lines[0].Length)
                let position = new Position(rowIndex, columnIndex)
                let tile = Tile(lines[rowIndex][columnIndex])
                select new KeyValuePair<Position, Tile>(position, tile));
    }
}