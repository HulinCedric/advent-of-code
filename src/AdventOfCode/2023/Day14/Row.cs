using System.Linq;

namespace AdventOfCode._2023.Day14;

public class Row
{
    private readonly int index;
    private readonly char[] row;
    private readonly int totalRows;

    public Row(int index, int totalRows, char[] row)
    {
        this.index = index;
        this.totalRows = totalRows;
        this.row = row;
    }

    /// <summary>
    ///     The amount of load caused by a single rounded rock (O)
    /// </summary>
    private int RoundedRocksCount()
        => row.Count(ch => ch == 'O');

    /// <summary>
    ///     Number of rows from the rock to the south edge of the platform, including the row the rock is on.
    /// </summary>
    private int RowNumber()
        => totalRows - index;

    public int RoundedRockLoad()
        => RowNumber() * RoundedRocksCount();
}