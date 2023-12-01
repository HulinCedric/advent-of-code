using System.Linq;

namespace AdventOfCode._2021.Day08;

public static class StringExtensions
{
    public static string Sort(this string @string)
        => string.Concat(@string.OrderBy(c => c));
}