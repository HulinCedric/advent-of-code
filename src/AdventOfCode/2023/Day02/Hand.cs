using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day02;

public class Hand
{
    internal Hand(List<Cube> cubes)
        => Cubes = cubes;

    internal List<Cube> Cubes { get; }

    /// <example>3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green</example>
    internal static List<Hand> ParseMany(string handsInformation)
    {
        var cubesSets = handsInformation.Trim().Split(";", StringSplitOptions.TrimEntries);

        return cubesSets.Select(Parse).ToList();
    }

    /// <example>3 blue, 4 red</example>
    private static Hand Parse(string handInformation)
        => new(
            handInformation
                .Split(",", StringSplitOptions.TrimEntries)
                .Select(Cube.Parse)
                .ToList());

    public int Power()
        => Cubes.Select(c => c.Count).Aggregate(1, (current, next) => current * next);
}