using System.Linq;

namespace AdventOfCode.Day08;

public static class StringExtensions
{
    public static string Sort(this string @string)
        => string.Concat(@string.OrderBy(c => c));
}