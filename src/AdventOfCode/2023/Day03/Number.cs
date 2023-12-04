using System;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day03;

public partial class Number : Part
{
    internal Number(string text, int rowIndex, int columnIndex) : base(text, rowIndex, columnIndex)
        => Value = int.Parse(text);

    internal int Value { get; }

    [GeneratedRegex(@"\d+")]
    internal static partial Regex Regex();

    internal bool IsAdjacent(Part part)
        => Math.Abs(part.RowIndex - RowIndex) <= 1 &&
           ColumnIndex <= part.ColumnIndex + part.Text.Length &&
           part.ColumnIndex <= ColumnIndex + Text.Length;
}