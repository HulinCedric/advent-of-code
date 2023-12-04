using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day03;

public partial class Gear : Part
{
    internal Gear(string text, int rowIndex, int columnIndex) : base(text, rowIndex, columnIndex)
    {
    }

    [GeneratedRegex(@"\*")]
    internal static partial Regex Regex();
}