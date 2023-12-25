using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day13;

public static class MapParser
{
    public static Map Parse(string input)
    {
        var rows = input.Split("\n");
        return new Map(
            from rowIndex in Enumerable.Range(0, rows.Length)
            from columnIndex in Enumerable.Range(0, rows[0].Length)
            let position = new Position(rowIndex, columnIndex)
            let element = rows[rowIndex][columnIndex]
            select new KeyValuePair<Position, char>(position, element));
    }

    public static IEnumerable<Map> ParseMany(string mapsInformation)
    {
        return mapsInformation.Split("\n\n")
            .Select(MapParser.Parse);
    }
}