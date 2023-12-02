using System;

namespace AdventOfCode._2023.Day02;

public class Cubes
{
    private Cubes(int count, string color)
    {
        Count = count;
        Color = color;
    }

    public string Color { get; }
    public int Count { get; }

    /// <example>3 blue</example>
    public static Cubes Parse(string cubesInformation)
    {
        var parts = cubesInformation.Split(" ", StringSplitOptions.TrimEntries);

        return new Cubes(int.Parse(parts[0]), parts[1]);
    }

    public bool IsPossible()
        => Color switch
        {
            "red" => Count <= 12,
            "green" => Count <= 13,
            "blue" => Count <= 14,
            _ => false
        };
}