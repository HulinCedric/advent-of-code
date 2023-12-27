using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day14;

public class Map : IEnumerable<Row>
{
    private readonly char[][] map;

    private Map(char[][] map)
        => this.map = map;

    public IEnumerator<Row> GetEnumerator()
        => ((IEnumerable<Row>)map.Select((row, rowIndex) => new Row(rowIndex, TotalRows(), row)).ToArray())
            .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    private int TotalRows()
        => map.Length;

    private int TotalColumns()
        => map[0].Length;

    public Map Tilt()
    {
        var newMap = Clone();
        for (var columnIndex = 0; columnIndex < TotalColumns(); columnIndex++)
        {
            var indexForRoundedRock = 0;
            for (var rowIndex = 0; rowIndex < TotalRows(); rowIndex++)
            {
                switch (newMap[rowIndex][columnIndex])
                {
                    case '#':
                        indexForRoundedRock = rowIndex + 1;
                        break;

                    // Move Rounded Rock
                    case 'O':
                        newMap[rowIndex][columnIndex] = '.';
                        newMap[indexForRoundedRock][columnIndex] = 'O';
                        indexForRoundedRock++;
                        break;
                }
            }
        }

        return new Map(newMap);
    }

    public Map Rotate()
    {
        var newMap = new char[TotalRows()][];
        for (var rowIndex = 0; rowIndex < TotalColumns(); rowIndex++)
        {
            newMap[rowIndex] = new char[TotalColumns()];
            for (var columnIndex = 0; columnIndex < TotalRows(); columnIndex++)
            {
                newMap[rowIndex][columnIndex] = map[TotalRows() - columnIndex - 1][rowIndex];
            }
        }

        return new Map(newMap);
    }

    private char[][] Clone()
        => Parse(ToString()).map;

    public override string ToString()
        => string.Join('\n', map.Select(row => new string(row)));

    public static Map Parse(string mapInformation)
        => new(
            mapInformation
                .Split('\n')
                .Select(row => row.ToCharArray())
                .ToArray());
}