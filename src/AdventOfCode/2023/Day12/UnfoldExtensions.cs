using System.Linq;

namespace AdventOfCode._2023.Day12;

public static class UnfoldExtensions
{
    public static string Unfold(string value, char separator, int repeatCount)
        => string.Join(separator, Enumerable.Repeat(value, repeatCount));
}