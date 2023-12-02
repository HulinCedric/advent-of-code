using System;

namespace AdventOfCode._2023.Day02;

internal class Cube
{
    private Cube(int count, string color)
    {
        Count = count;
        Color = color;
    }

    internal string Color { get; }
    internal int Count { get; }

    /// <example>3 blue</example>
    internal static Cube Parse(string cubesInformation)
    {
        var parts = cubesInformation.Split(" ", StringSplitOptions.TrimEntries);

        return new Cube(int.Parse(parts[0]), parts[1]);
    }

    internal bool IsPossible()
        => Color switch
        {
            "red" => Count <= 12,
            "green" => Count <= 13,
            "blue" => Count <= 14,
            _ => false
        };
}