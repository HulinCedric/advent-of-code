using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day03;

public partial class Symbol : Part
{
    internal Symbol(string text, int rowIndex, int columnIndex) : base(text, rowIndex, columnIndex)
    {
    }

    [GeneratedRegex("[^.0-9]")]
    internal static partial Regex Regex();
}