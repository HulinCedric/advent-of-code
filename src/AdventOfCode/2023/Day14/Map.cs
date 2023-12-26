using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day14;

public class Map : IEnumerable<Row>
{
    private readonly char[][] map;
    private readonly Row[] rows;

    public Map(char[][] map)
    {
        this.map = map;
        rows = map.Select((row, rowIndex) => new Row(rowIndex, map.Length, row)).ToArray();
    }

    public IEnumerator<Row> GetEnumerator()
        => ((IEnumerable<Row>)rows).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    private int TotalRows()
        => map.Length;

    private int TotalColumns()
        => map[0].Length;

    public Map Tilt()
    {
        for (var columnIndex = 0; columnIndex < TotalColumns(); columnIndex++)
        {
            var indexForRoundedRock = 0;
            for (var rowIndex = 0; rowIndex < TotalRows(); rowIndex++)
            {
                switch (map[rowIndex][columnIndex])
                {
                    case '#':
                        indexForRoundedRock = rowIndex + 1;
                        break;
                    case 'O':
                        map[rowIndex][columnIndex] = '.';
                        map[indexForRoundedRock][columnIndex] = 'O';
                        indexForRoundedRock++;
                        break;
                }
            }
        }

        return new Map(map);
    }

    public override string ToString()
        => string.Join('\n', map.Select(row => new string(row)));
}