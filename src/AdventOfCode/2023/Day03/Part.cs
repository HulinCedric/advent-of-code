namespace AdventOfCode._2023.Day03;

public abstract class Part
{
    protected Part(string text, int rowIndex, int columnIndex)
    {
        ColumnIndex = columnIndex;
        RowIndex = rowIndex;
        Text = text;
    }

    internal int ColumnIndex { get; }
    internal int RowIndex { get; }
    internal string Text { get; }
}