using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day11;

public static class UniverseExtension
{
    public static string[] Universe(string input)
        => input.Split("\n");

    private static IEnumerable<int> Columns(string[] universe)
        => Enumerable.Range(0, universe[0].Length);

    private static IEnumerable<int> Rows(string[] universe)
        => Enumerable.Range(0, universe.Length);

    public static List<Galaxy> Galaxies(string[] universe)
        => (from x in Rows(universe)
            from y in Columns(universe)
            where Galaxy.IsGalaxy(universe[x][y])
            select new Galaxy(x, y)).ToList();
}