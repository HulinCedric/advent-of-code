using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day14;

public class Map : IEnumerable<Row>
{
    private readonly Row[] map;

    public Map(char[][] map)
        => this.map = map.Select((row, rowIndex) => new Row(rowIndex, map.Length, row)).ToArray();

    public IEnumerator<Row> GetEnumerator()
        => ((IEnumerable<Row>)map).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public int TotalRows()
        => map.Length;
}