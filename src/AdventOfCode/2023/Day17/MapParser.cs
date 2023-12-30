using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day17;

public static class MapParser
{
    public static Map ParseMap(string input)
    {
        var lines = input.Split('\n');
        return new Map(
            from rowIndex in Enumerable.Range(0, lines.Length)
            from columnIndex in Enumerable.Range(0, lines[0].Length)
            let blockHeatLoss = (int)char.GetNumericValue(lines[rowIndex][columnIndex])
            let position = new Position(rowIndex, columnIndex)
            select new KeyValuePair<Position, int>(position, blockHeatLoss));
    }
}